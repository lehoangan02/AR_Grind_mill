using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class VRFishingController : MonoBehaviour
{
    [Header("VR Controller / Hand Mapping")]
    public GameObject rightHandController;

    [Header("Input Action Bindings (XRI / XR Device Simulator)")]
    public InputActionProperty grabAction; 
    public InputActionProperty reelAction; // Secondary action (Ví dụ: Nút B/Y hoặc Trigger)

    [Header("Cấu hình Cầm nắm (XR Grab)")]
    public float pickupDistance = 2.0f;
    public Vector3 holdPosition = new Vector3(0f, -0.05f, 0.25f);
    public Vector3 holdRotation = new Vector3(10f, 0f, 0f);
    public bool isEquipped = false;

    [Header("Anchor Ngọn Cần & Dây Câu")]
    public Transform topAnchor;        // Object Anchor đặt tại điểm cao nhất của ngọn cần câu
    public Transform hookWithLine;     // Gốc dây câu
    public Transform hookMesh;         // Phao / Lưỡi câu
    public GameObject fishPrefab;      // Prefab con cá mặc định

    // Alias tương thích ngược
    public Transform rodTipPoint { get => topAnchor; set => topAnchor = value; }

    [Header("Cấu hình Chiều dài Dây câu (Trục Y)")]
    public float idleScaleY = 0.1f;    // Độ dài dây khi thu gọn
    public float waterScaleY = 2.5f;   // Độ dài dây khi thả xuống nước
    public float scaleSpeed = 3.0f;    
    public float pullThreshold = 1.3f; // Tốc độ vung tay/controller (hoặc XR Device Simulator)

    [Header("Âm thanh & Hiệu ứng Particle")]
    public AudioSource audioSource;
    public AudioClip castSound;
    public AudioClip biteSound;
    public AudioClip catchSound;
    public ParticleSystem biteParticleFX;

    public enum FishingState { Idle, DroppingLine, WaitingForFish, FishBiting, FishCaught }
    public FishingState currentState = FishingState.Idle;

    public GameObject currentFishInstance { get; private set; }
    public FishingZone currentZone { get; private set; }

    private float targetScaleY;
    private Vector3 lastPosition;
    private float upwardSpeed;

    // Biến lưu lại Scale gốc để chống méo
    private Vector3 rodOriginalScale;
    private Vector3 hookOriginalScale;

    private XRGrabInteractable grabInteractable;

    // Delegate & Events
    public delegate void StateChangedHandler(FishingState newState);
    public event StateChangedHandler OnStateChanged;

    public event System.Action<FishingZone> OnLineCast;
    public event System.Action OnFishBiting;
    public event System.Action<CaughtFishItem> OnFishCaughtEvent;
    public event System.Action OnFishEscaped;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable == null)
        {
            grabInteractable = gameObject.AddComponent<XRGrabInteractable>();
        }
    }

    private void OnEnable()
    {
        if (grabAction.action != null) grabAction.action.Enable();
        if (reelAction.action != null) reelAction.action.Enable();

        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnXRISelectEntered);
            grabInteractable.selectExited.AddListener(OnXRISelectExited);
            grabInteractable.activated.AddListener(OnXRIActivated);
        }
    }

    private void OnDisable()
    {
        if (grabAction.action != null) grabAction.action.Disable();
        if (reelAction.action != null) reelAction.action.Disable();

        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnXRISelectEntered);
            grabInteractable.selectExited.RemoveListener(OnXRISelectExited);
            grabInteractable.activated.RemoveListener(OnXRIActivated);
        }
    }

    private void Start()
    {
        // 1. Lưu lại Scale ban đầu của Cần câu
        if (transform.localScale != Vector3.zero)
        {
            rodOriginalScale = transform.localScale;
        }
        else
        {
            rodOriginalScale = Vector3.one;
        }

        // 2. Tự động tìm rightHandController nếu chưa gán
        EnsureRightHandControllerReference();

        // 3. Tự động tìm topAnchor nếu chưa gán trong Inspector
        if (topAnchor == null)
        {
            Transform foundAnchor = transform.Find("TopAnchor") ?? transform.Find("Anchor") ?? transform.Find("Top") ?? transform.Find("RodTipPoint");
            if (foundAnchor != null) topAnchor = foundAnchor;
        }

        // 4. Lưu lại Scale ban đầu của Dây câu và cài độ dài mặc định
        if (hookWithLine != null)
        {
            hookOriginalScale = hookWithLine.localScale;
            targetScaleY = idleScaleY;
            hookWithLine.localScale = new Vector3(hookOriginalScale.x, idleScaleY, hookOriginalScale.z);

            if (topAnchor != null)
            {
                hookWithLine.position = topAnchor.position;
            }
        }

        // Tự động kiểm tra / thêm FishingHookTrigger lên PHAO (hookMesh) cuối dây câu
        // thay vì lên đỉnh cần (hookWithLine) để khớp đúng visual vị trí tiếp xúc mặt nước
        EnsureHookMeshTriggerSetup();

        if (audioSource == null) audioSource = GetComponent<AudioSource>();

        Debug.Log("<b>[VR CÂU CÁ]</b> VRFishingController đã sẵn sàng!");
    }

    /// <summary>
    /// Đảm bảo PHAO (hookMesh) cuối dây có Collider (isTrigger) và FishingHookTrigger,
    /// để việc bắt đầu câu xảy ra đúng khi phao chạm nước (khớp visual), thay vì khi đỉnh cần chạm nước.
    /// </summary>
    public void EnsureHookMeshTriggerSetup()
    {
        if (hookMesh == null) return;

        // Phao phải nằm trong hookWithLine để bám theo chuyển động dây
        if (hookWithLine != null && hookMesh.parent != hookWithLine)
        {
            hookMesh.SetParent(hookWithLine, true);
        }

        // Thay các collider cũ (thường là MeshCollider visual từ Engine tạo primitive)
        // bằng một SphereCollider isTrigger duy nhất, phóng bán kính để dễ chạm nước
        SphereCollider sc = hookMesh.GetComponent<SphereCollider>();
        if (sc == null)
        {
            Collider existing = hookMesh.GetComponent<Collider>();
            if (existing != null)
            {
                Object.Destroy(existing);
            }
            sc = hookMesh.gameObject.AddComponent<SphereCollider>();
        }
        sc.isTrigger = true;
        // Đảm bảo bán kính collider phao đủ lớn trong World Space để chạm nước,
        // kể cả khi hookMesh có localScale nhỏ (visual mảnh). Dùng bán kính xuyên tâm (X/Z).
        float radialScale = Mathf.Max(hookMesh.lossyScale.x, hookMesh.lossyScale.z);
        float minLocalRadius = (radialScale > 0.0001f) ? 0.25f / radialScale : 0.25f;
        if (sc.radius < minLocalRadius) sc.radius = minLocalRadius;

        // Đảm bảo có FishingHookTrigger trên phao
        if (hookMesh.GetComponent<FishingHookTrigger>() == null)
        {
            FishingHookTrigger hookTrigger = hookMesh.gameObject.AddComponent<FishingHookTrigger>();
            hookTrigger.fishingController = this;
        }
    }

    /// <summary>
    /// Đặt PHAO (hookMesh) tại cuối dây câu để khớp đúng visual:
    /// khi thả dây (waterScaleY lớn), phao theo xuống gần mặt nước.
    /// Được gọi mỗi frame trong Update().
    /// </summary>
    public void PlaceBobberAtLineEnd()
    {
        if (hookMesh == null || hookWithLine == null) return;

        if (hookMesh.parent != hookWithLine)
        {
            hookMesh.SetParent(hookWithLine, true);
        }
        hookMesh.localPosition = new Vector3(0f, -hookWithLine.localScale.y, 0f);
        hookMesh.localRotation = Quaternion.identity;
    }

    private void Update()
    {
        // Định vị dây câu luôn bám sát điểm cao nhất TopAnchor của ngọn cần
        if (hookWithLine != null)
        {
            if (topAnchor != null)
            {
                hookWithLine.position = topAnchor.position;
            }
            // Dây câu luôn thả thẳng đứng xuống theo chiều trọng lực
            hookWithLine.rotation = Quaternion.identity;

            PlaceBobberAtLineEnd();
        }

        // Kiểm tra nút cuộn/thu dây (Reel In) qua InputAction
        if (isEquipped && CheckReelInputPressed())
        {
            ReelIn();
            return;
        }

        // Nếu chưa được trang bị qua XRI, kiểm tra proximity fallback khi nhấn Grab
        if (!isEquipped)
        {
            if (rightHandController != null)
            {
                float dist = Vector3.Distance(transform.position, rightHandController.transform.position);
                if (CheckGrabInputPressed() && dist <= pickupDistance)
                {
                    EquipRod();
                }
            }
            return;
        }

        // TÍNH TỐC ĐỘ VUNG CONTROLLER (Upward Speed)
        upwardSpeed = (transform.position.y - lastPosition.y) / Time.deltaTime;
        lastPosition = transform.position;

        // Cập nhật độ dài dây câu mượt mà theo trục Y
        if (hookWithLine != null)
        {
            float currentY = hookWithLine.localScale.y;
            float newY = Mathf.Lerp(currentY, targetScaleY, Time.deltaTime * scaleSpeed);
            hookWithLine.localScale = new Vector3(hookOriginalScale.x, newY, hookOriginalScale.z);
        }

        // Khi cá cắn mồi: kiểm tra lực giật vung tay
        if (currentState == FishingState.FishBiting)
        {
            TriggerHaptic(0.4f, Time.deltaTime);

            float activePullThreshold = pullThreshold;
            if (currentZone != null)
            {
                activePullThreshold *= currentZone.pullThresholdMultiplier;
            }

            if (upwardSpeed > activePullThreshold)
            {
                Debug.Log($"<b>[VR CÂU CÁ]</b> Vung tay/Controller với tốc độ {upwardSpeed:F2} > {activePullThreshold:F2} -> BẮT ĐƯỢC CÁ!");
                CatchFish();
            }
        }
    }

    public void EnsureRightHandControllerReference(Transform interactorTransform = null)
    {
        if (interactorTransform != null)
        {
            rightHandController = interactorTransform.gameObject;
            return;
        }

        if (rightHandController == null)
        {
            GameObject hand = GameObject.Find("RightHand Controller") 
                           ?? GameObject.Find("RightHand Direct Interactor") 
                           ?? GameObject.Find("Right Controller") 
                           ?? GameObject.Find("RightHand")
                           ?? GameObject.Find("RightHand Controller (XR Interaction Toolkit)");

            if (hand == null)
            {
                var interactors = Object.FindObjectsByType<UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor>(FindObjectsSortMode.None);
                foreach (var interactor in interactors)
                {
                    if (interactor != null && interactor.name.ToLower().Contains("right"))
                    {
                        hand = interactor.gameObject;
                        break;
                    }
                }
                if (hand == null && interactors != null && interactors.Length > 0 && interactors[0] != null)
                {
                    hand = interactors[0].gameObject;
                }
            }

            if (hand != null)
            {
                rightHandController = hand;
            }
        }
    }

    private void SetState(FishingState newState)
    {
        if (currentState == newState) return;
        currentState = newState;
        OnStateChanged?.Invoke(newState);
    }

    private bool CheckGrabInputPressed()
    {
        if (grabAction.action != null && grabAction.action.WasPressedThisFrame()) return true;
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame) return true;
        return false;
    }

    private bool CheckReelInputPressed()
    {
        if (reelAction.action != null && reelAction.action.WasPressedThisFrame()) return true;
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame) return true;
        return false;
    }

    private void OnXRISelectEntered(SelectEnterEventArgs args)
    {
        Transform handTarget = args != null && args.interactorObject != null ? args.interactorObject.transform : null;
        EquipRod(handTarget);
        Debug.Log("<b>[XRI CÂU CÁ]</b> Cầm cần câu qua XRI Grab!");
    }

    private void OnXRISelectExited(SelectExitEventArgs args)
    {
        isEquipped = false;
        ResetToIdle();
        Debug.Log("<b>[XRI CÂU CÁ]</b> Đã thả cần câu.");
    }

    private void OnXRIActivated(ActivateEventArgs args)
    {
        if (isEquipped)
        {
            Debug.Log("<b>[XRI CÂU CÁ]</b> Nút Action/Trigger được kích hoạt!");
            ReelIn();
        }
    }

    public void EquipRod(Transform handTarget = null)
    {
        isEquipped = true;
        EnsureRightHandControllerReference(handTarget);

        if (rodOriginalScale == Vector3.zero)
        {
            rodOriginalScale = Vector3.one;
        }

        if (rightHandController != null)
        {
            transform.SetParent(rightHandController.transform, false);
            transform.localPosition = (holdPosition != Vector3.zero) ? holdPosition : new Vector3(0f, -0.05f, 0.25f);
            transform.localEulerAngles = (holdRotation != Vector3.zero) ? holdRotation : new Vector3(10f, 0f, 0f);
            transform.localScale = rodOriginalScale;
            Debug.Log($"<b>[VR NHẶT ĐỒ] THÀNH CÔNG:</b> Đã dính cần câu vào tay [{rightHandController.name}]!");
        }
        else
        {
            Debug.LogWarning("<b>[VR NHẶT ĐỒ] CẢNH BÁO:</b> Không tìm thấy rightHandController! Gắn tạm phía trước Main Camera...");
            Camera mainCam = Camera.main;
            if (mainCam != null)
            {
                transform.SetParent(mainCam.transform, false);
                transform.localPosition = new Vector3(0.2f, -0.2f, 0.5f);
                transform.localEulerAngles = new Vector3(10f, -15f, 0f);
                transform.localScale = rodOriginalScale;
            }
        }

        lastPosition = transform.position;
    }

    public void UnequipRod(Vector3 rackPosition = default, Quaternion rackRotation = default)
    {
        isEquipped = false;
        transform.SetParent(null);

        if (rackPosition != default)
        {
            transform.position = rackPosition;
            transform.rotation = (rackRotation != default) ? rackRotation : Quaternion.identity;
        }

        ResetToIdle();
        Debug.Log("<b>[VR CÂU CÁ]</b> Đã cất cần câu về giá/bảng!");
    }

    public void StartFishingInWater(FishingZone zone = null)
    {
        if (currentState == FishingState.Idle && isEquipped) 
        {
            currentZone = zone;
            Debug.Log($"<b>[VR CÂU CÁ]</b> Phao chạm nước! Vùng: {(zone != null ? zone.zoneName : "Mặc định")}. Bắt đầu thả dây...");
            
            if (audioSource != null && castSound != null)
            {
                audioSource.PlayOneShot(castSound);
            }

            OnLineCast?.Invoke(zone);
            StartCoroutine(FishingRoutine());
        }
    }

    private IEnumerator FishingRoutine()
    {
        SetState(FishingState.DroppingLine);
        targetScaleY = waterScaleY;
        yield return new WaitForSeconds(1.0f);

        SetState(FishingState.WaitingForFish);
        Debug.Log("<b>[VR CÂU CÁ]</b> Đang chờ cá cắn mồi...");

        float minDelay = currentZone != null ? currentZone.minBiteDelay : 2.0f;
        float maxDelay = currentZone != null ? currentZone.maxBiteDelay : 5.0f;
        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

        if (currentState != FishingState.WaitingForFish) yield break;

        SetState(FishingState.FishBiting);
        Debug.Log("<b>[VR CÂU CÁ] CÁ ĐÃ CẮN MỒI!!! Giật cần nhanh lên!</b>");
        TriggerHaptic(1.0f, 0.3f);

        if (audioSource != null && biteSound != null)
        {
            audioSource.PlayOneShot(biteSound);
        }

        if (biteParticleFX != null)
        {
            biteParticleFX.Play();
        }

        OnFishBiting?.Invoke();

        float timer = 0f;
        while (timer < 2.5f && currentState == FishingState.FishBiting)
        {
            timer += Time.deltaTime;
            float jerk = Mathf.Sin(timer * 20f) * 0.3f;
            targetScaleY = waterScaleY + jerk;
            yield return null;
        }

        if (currentState == FishingState.FishBiting)
        {
            Debug.LogWarning("<b>[VR CÂU CÁ]</b> Giật quá chậm, CÁ ĐÃ XỔNG MẤT!");
            OnFishEscaped?.Invoke();
            ResetToIdle();
        }
    }

    private void CatchFish()
    {
        StopAllCoroutines();
        SetState(FishingState.FishCaught);
        TriggerHaptic(0.8f, 0.4f);
        
        targetScaleY = idleScaleY;

        if (audioSource != null && catchSound != null)
        {
            audioSource.PlayOneShot(catchSound);
        }

        GameObject prefabToSpawn = fishPrefab;
        if (currentZone != null && currentZone.customFishPrefab != null)
        {
            prefabToSpawn = currentZone.customFishPrefab;
        }

        Transform targetParent = hookMesh != null ? hookMesh : transform;
        if (prefabToSpawn != null)
        {
            currentFishInstance = Instantiate(prefabToSpawn, targetParent.position, targetParent.rotation, targetParent);
            
            CaughtFishItem fishItem = currentFishInstance.GetComponent<CaughtFishItem>();
            if (fishItem == null)
            {
                fishItem = currentFishInstance.AddComponent<CaughtFishItem>();
            }

            fishItem.ownerRod = this;
            if (currentZone != null)
            {
                fishItem.fishType = currentZone.fishType;
                fishItem.fishName = currentZone.zoneName;
            }

            OnFishCaughtEvent?.Invoke(fishItem);
        }
    }

    public void OnFishCollected(CaughtFishItem fishItem)
    {
        Debug.Log("<b>[VR CÂU CÁ]</b> Đã nhận cá từ người chơi. Reset cần câu về Idle.");
        currentFishInstance = null;
        ResetToIdle();
    }

    public void ReelIn()
    {
        Debug.Log("<b>[VR CÂU CÁ]</b> Đang cuộn dây câu về...");
        StopAllCoroutines();
        ResetToIdle();
    }

    public void ResetToIdle()
    {
        if (currentFishInstance != null)
        {
            CaughtFishItem item = currentFishInstance.GetComponent<CaughtFishItem>();
            if (item != null && !item.isGrabbedFromHook)
            {
                Destroy(currentFishInstance);
            }
            currentFishInstance = null;
        }

        SetState(FishingState.Idle);
        targetScaleY = idleScaleY;
        currentZone = null;
        Debug.Log("<b>[VR CÂU CÁ]</b> Đã reset về trạng thái chờ (Idle).");
    }

    private void TriggerHaptic(float amplitude, float duration)
    {
        UnityEngine.XR.InputDevice rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        if (rightHand.isValid)
        {
            rightHand.SendHapticImpulse(0, amplitude, duration);
        }
    }
}
