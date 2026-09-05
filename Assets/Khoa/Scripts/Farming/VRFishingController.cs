using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class VRFishingController : MonoBehaviour
{
    [Header("Simple click fishing")]
    [Tooltip("The rod stays at a fixed point. Cast once, wait for the bite message, then click the rod to catch.")]
    public bool simpleClickMode = true;
    public Transform fixedFishingPoint;
    public Vector3 fixedFishingRotation = new Vector3(180f, 210f, 0f);
    public float simpleDropDuration = 0.6f;
    public float simpleBiteDelay = 1.5f;

    [Header("VR Controller / Hand Mapping")]
    public GameObject rightHandController;

    [Header("Input Action Bindings (XRI / XR Device Simulator)")]
    public InputActionProperty grabAction; 
    public InputActionProperty reelAction; // Secondary action (Ví dụ: Nút B/Y hoặc Trigger)

    [Header("Cấu hình Cầm nắm (XR Grab)")]
    public float pickupDistance = 2.0f;
    public Vector3 holdPosition = new Vector3(0f, -0.05f, 0.25f);
    public Vector3 holdRotation = new Vector3(180f, 210f, 0f);
    public bool isEquipped = false;

    [Header("Anchor Ngọn Cần & Dây Câu")]
    public Transform topAnchor;        // Object Anchor đặt tại điểm cao nhất của ngọn cần câu
    public Transform hookWithLine;     // Gốc dây câu
    public Transform hookMesh;         // Phao / Lưỡi câu
    public GameObject fishPrefab;      // Prefab con cá mặc định
    [Tooltip("Vị trí xuất hiện của cá khi câu được, tính theo trục (local) của cần câu: X = lệch sang bên trái/khéo, Y = lên/xuống, Z = trước/sau. Mặc định đặt cá ngay BÊN CẠNH cần.")]
    public Vector3 fishSpawnOffset = new Vector3(0.6f, 0.9f, 0f);

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
    private Vector3 fixedWorldPosition;

    // Biến lưu lại Scale gốc để chống méo
    private Vector3 rodOriginalScale;
    private Vector3 hookOriginalScale;

    private XRGrabInteractable grabInteractable;
    private XRSimpleInteractable clickInteractable;
    private Rigidbody rodRigidbody;
    private bool originalUseGravity;
    private bool originalIsKinematic;

    // Delegate & Events
    public delegate void StateChangedHandler(FishingState newState);
    public event StateChangedHandler OnStateChanged;

    public event System.Action<FishingZone> OnLineCast;
    public event System.Action OnFishBiting;
    public event System.Action<CaughtFishItem> OnFishCaughtEvent;
    public event System.Action OnFishEscaped;

    private void Awake()
    {
        fixedWorldPosition = transform.position;

        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable == null)
        {
            grabInteractable = gameObject.AddComponent<XRGrabInteractable>();
        }
        // The rod is a fixed click target, never a grabbable object.
        grabInteractable.enabled = false;

        clickInteractable = GetComponent<XRSimpleInteractable>();
        if (clickInteractable == null)
        {
            clickInteractable = gameObject.AddComponent<XRSimpleInteractable>();
        }

        rodRigidbody = GetComponent<Rigidbody>();
        if (rodRigidbody != null)
        {
            originalUseGravity = rodRigidbody.useGravity;
            originalIsKinematic = rodRigidbody.isKinematic;
        }
    }

    private void OnEnable()
    {
        if (grabAction.action != null) grabAction.action.Enable();
        if (reelAction.action != null) reelAction.action.Enable();

        if (clickInteractable != null)
        {
            clickInteractable.selectEntered.AddListener(OnRodClicked);
        }
    }

    private void OnDisable()
    {
        if (grabAction.action != null) grabAction.action.Disable();
        if (reelAction.action != null) reelAction.action.Disable();

        if (clickInteractable != null)
        {
            clickInteractable.selectEntered.RemoveListener(OnRodClicked);
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

        // 2. Tự động tìm topAnchor nếu chưa gán trong Inspector
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
        // Keep the station pose locked during dropping, waiting, bite, and catch.
        if (isEquipped)
        {
            transform.position = fixedFishingPoint != null ? fixedFishingPoint.position : fixedWorldPosition;
            transform.rotation = Quaternion.Euler(fixedFishingRotation);
        }

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
            HandlePrimaryClick();
            return;
        }

        if (!isEquipped) return;

        // Cập nhật độ dài dây câu mượt mà theo trục Y
        if (hookWithLine != null)
        {
            float currentY = hookWithLine.localScale.y;
            float newY = Mathf.Lerp(currentY, targetScaleY, Time.deltaTime * scaleSpeed);
            hookWithLine.localScale = new Vector3(hookOriginalScale.x, newY, hookOriginalScale.z);
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
            GameObject hand = FindRightHandController();

            if (hand != null)
            {
                rightHandController = hand;
            }
            else if (rightHandController == null)
            {
                // Dự phòng cho Simulator / rig không nhận diện được tay:
                // gắn mặc định vào Camera.main (luôn tồn tại, rod luôn nhìn thấy phía trước).
                Camera cam = Camera.main;
                if (cam != null)
                {
                    rightHandController = cam.gameObject;
                }
            }
        }
    }

    /// <summary>
    /// Dò tìm controller/tay PHẢI một cách robust, hoạt động cả trên XR Device Simulator lẫn thiết bị thật.
    /// Vì XR Interaction Toolkit dùng chung cấu trúc rig cho cả hai, ta dò theo:
    ///   1. Tên chuẩn XRI (RightHand Controller / Right Controller / ...).
    ///   2. Interactor có tên gợi ý tay/controller + nằm ở BÊN PHẢI so với camera (phân biệt trái/phải
    ///      theo vị trí, không phụ thuộc tên — robust trên mọi rig hands/controller).
    ///   3. Bất kỳ interactor tay/controller nào có scale hợp lệ (chặn object scale ~0 gây "biến mất").
    /// </summary>
    private GameObject FindRightHandController()
    {
        // Bước 1: tên chuẩn XRI
        string[] names = {
            "RightHand Controller", "RightHand Direct Interactor", "Right Controller",
            "RightHand", "RightHand Controller (XR Interaction Toolkit)", "Right Hand",
            "RightController"
        };
        foreach (string n in names)
        {
            GameObject go = GameObject.Find(n);
            if (go != null && go.transform.lossyScale.sqrMagnitude > 0.0001f)
            {
                return go;
            }
        }

        Camera cam = Camera.main;
        Vector3 camPos = cam != null ? cam.transform.position : Vector3.zero;
        Vector3 camRight = cam != null ? cam.transform.right : Vector3.right;

        var interactors = Object.FindObjectsByType<UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor>(FindObjectsSortMode.None);
        if (interactors == null) return null;

        bool IsHandLike(UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor it)
            => it != null && it.name.ToLower().Contains("hand")
                          && it.transform.lossyScale.sqrMagnitude > 0.0001f;

        bool IsControllerLike(UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor it)
            => it != null && (it.name.ToLower().Contains("hand")
                          || it.name.ToLower().Contains("controller")
                          || it.name.ToLower().Contains("interactor"))
                          && it.transform.lossyScale.sqrMagnitude > 0.0001f;

        // Bước 2: tiêu chí phần “PHẢI” theo tên => ưu tiên rồi mới đến vị trí bên phải
        // Ưu tiên 2a: interactor “hand-like” ở bên phải camera (chắc chắn là tay phải)
        foreach (var it in interactors)
        {
            if (!IsHandLike(it)) continue;
            if (Vector3.Dot(it.transform.position - camPos, camRight) > 0f)
            {
                return it.gameObject;
            }
        }

        // Ưu tiên 2b: interactor có tên chứa "right"
        foreach (var it in interactors)
        {
            if (IsControllerLike(it) && it.name.ToLower().Contains("right"))
            {
                return it.gameObject;
            }
        }

        // Bước 3: bất kỳ interactor tay/controller nào có scale hợp lệ (không dùng object scale ~0)
        foreach (var it in interactors)
        {
            if (IsControllerLike(it))
            {
                return it.gameObject;
            }
        }

        return null;
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

    private void OnRodClicked(SelectEnterEventArgs args)
    {
        if (isEquipped)
        {
            Debug.Log("<b>[SIMPLE FISHING]</b> Fishing rod clicked.");
            HandlePrimaryClick();
        }
    }

    /// <summary>
    /// Fixed-rod fishing flow. Cast first, wait until FishBiting, then click the
    /// rod once to catch. Clicks during the waiting states are intentionally ignored.
    /// </summary>
    public void HandlePrimaryClick(FishingZone zone = null)
    {
        if (!isEquipped)
        {
            Debug.LogWarning("<b>[SIMPLE FISHING]</b> Equip the fishing rod before casting.");
            return;
        }

        switch (currentState)
        {
            case FishingState.Idle:
                StartFishingInWater(zone);
                break;

            case FishingState.DroppingLine:
            case FishingState.WaitingForFish:
                Debug.Log("<b>[SIMPLE FISHING]</b> Chưa có cá cắn câu. Hãy chờ thông báo trên bảng.");
                break;

            case FishingState.FishBiting:
                CatchFish();
                break;

            case FishingState.FishCaught:
                Debug.Log("<b>[SIMPLE FISHING]</b> Fish is already visible. Collect it before casting again.");
                break;
        }
    }

    public void EquipRod(Transform handTarget = null)
    {
        isEquipped = true;

        // handTarget is deliberately ignored. The rod never follows a hand/controller.
        if (fixedFishingPoint != null)
        {
            transform.SetParent(fixedFishingPoint, false);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(fixedFishingRotation);
        }
        else
        {
            transform.SetParent(null, true);
            transform.position = fixedWorldPosition;
            transform.rotation = Quaternion.Euler(fixedFishingRotation);
        }

        // Lock physics so casting and clicking cannot change the fixed pose.
        if (rodRigidbody == null) rodRigidbody = GetComponent<Rigidbody>();
        if (rodRigidbody != null)
        {
            rodRigidbody.useGravity = false;
            rodRigidbody.isKinematic = true;
        }

        foreach (Renderer rodRenderer in GetComponentsInChildren<Renderer>(true))
        {
            rodRenderer.enabled = true;
        }

        Debug.Log($"<b>[SIMPLE FISHING]</b> Cần câu đã cố định tại điểm câu, rotation = {fixedFishingRotation}.");
    }

    public void UnequipRod(Vector3 rackPosition = default, Quaternion rackRotation = default)
    {
        isEquipped = false;
        transform.SetParent(null);

        if (rodRigidbody == null) rodRigidbody = GetComponent<Rigidbody>();
        if (rodRigidbody != null)
        {
            rodRigidbody.isKinematic = originalIsKinematic;
            rodRigidbody.useGravity = originalUseGravity;
        }

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

            if (simpleClickMode)
            {
                StopAllCoroutines();
                StartCoroutine(SimpleFishingRoutine());
            }
            else
            {
                StartCoroutine(FishingRoutine());
            }
        }
    }

    private IEnumerator SimpleFishingRoutine()
    {
        // The rod remains fixed for the whole sequence.
        transform.rotation = Quaternion.Euler(fixedFishingRotation);
        SetState(FishingState.DroppingLine);
        targetScaleY = waterScaleY;
        SetLineLengthImmediately(waterScaleY);
        Debug.Log("<b>[SIMPLE FISHING]</b> Đã thả câu. Đang chờ cá...");

        yield return new WaitForSeconds(Mathf.Max(0f, simpleDropDuration));
        if (currentState != FishingState.DroppingLine) yield break;

        SetState(FishingState.WaitingForFish);
        yield return new WaitForSeconds(Mathf.Max(0f, simpleBiteDelay));
        if (currentState != FishingState.WaitingForFish) yield break;

        SignalFishBite();
    }

    /// <summary>Marks the bite and waits indefinitely for the player to click the fixed rod.</summary>
    public void SignalFishBite()
    {
        if (currentState != FishingState.DroppingLine && currentState != FishingState.WaitingForFish) return;

        SetState(FishingState.FishBiting);
        Debug.Log("<b>[SIMPLE FISHING] CÁ CẮN CÂU! Bấm vào cần câu để kéo cá lên.</b>");
        TriggerHaptic(1.0f, 0.3f);

        if (audioSource != null && biteSound != null) audioSource.PlayOneShot(biteSound);
        if (biteParticleFX != null) biteParticleFX.Play();
        OnFishBiting?.Invoke();
    }

    private void SetLineLengthImmediately(float scaleY)
    {
        if (hookWithLine == null) return;

        if (hookOriginalScale == Vector3.zero)
        {
            hookOriginalScale = hookWithLine.localScale;
            if (hookOriginalScale == Vector3.zero) hookOriginalScale = Vector3.one;
        }

        hookWithLine.localScale = new Vector3(hookOriginalScale.x, scaleY, hookOriginalScale.z);
        PlaceBobberAtLineEnd();
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
        SetLineLengthImmediately(idleScaleY);

        if (audioSource != null && catchSound != null)
        {
            audioSource.PlayOneShot(catchSound);
        }

        GameObject prefabToSpawn = fishPrefab;
        if (currentZone != null && currentZone.customFishPrefab != null)
        {
            prefabToSpawn = currentZone.customFishPrefab;
        }

        Transform fishAttachPoint = hookMesh != null ? hookMesh : (topAnchor != null ? topAnchor : transform);
        if (prefabToSpawn != null)
        {
            // Spawn the fish BESIDE the rod (configurable offset in the rod's local space)
            // instead of hanging it on the hook/bobber, so the player can easily see & grab it.
            // We still parent to the rod while keeping worldPositionStays=true so the fish
            // keeps its world position & scale and is NOT flattened by the scaled line/bobber.
            Vector3 fishWorldPos = transform.position + transform.rotation * fishSpawnOffset;
            currentFishInstance = Instantiate(prefabToSpawn, fishWorldPos, fishAttachPoint.rotation);
            currentFishInstance.transform.SetParent(topAnchor != null ? topAnchor : transform, true);

            // FishSimulation lives outside this assembly in the imported fish pack.
            // Resolve it by name so this gameplay assembly stays independent.
            Behaviour swimming = currentFishInstance.GetComponent("FishSimulation") as Behaviour;
            if (swimming != null) swimming.enabled = false;
            
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

            Rigidbody fishBody = currentFishInstance.GetComponent<Rigidbody>();
            if (fishBody != null)
            {
                fishBody.useGravity = false;
                fishBody.isKinematic = true;
            }

            OnFishCaughtEvent?.Invoke(fishItem);
        }
        else
        {
            Debug.LogError("<b>[SIMPLE FISHING]</b> No fish prefab is assigned, so a caught fish cannot be displayed.");
        }
    }

    /// <summary>Desktop/editor fallback: click the equipped rod itself.</summary>
    private void OnMouseDown()
    {
        if (isEquipped) HandlePrimaryClick();
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
