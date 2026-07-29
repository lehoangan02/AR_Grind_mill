using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;

public class VRFishingController : MonoBehaviour
{
    [Header("VR Controller")]
    public GameObject rightHandController;

    [Header("Binding Nút Bấm Tay Cầm VR")]
    public InputActionProperty grabAction; 

    [Header("Cấu hình Cầm nắm (Snap to Hand)")]
    public float pickupDistance = 2.0f;
    public Vector3 holdPosition = new Vector3(0, 0, 0);
    public Vector3 holdRotation = new Vector3(0, 0, 0);
    private bool isEquipped = false;

    [Header("Prefab Mapping (Gán từ Hierarchy)")]
    public Transform hookWithLine;     
    public Transform hookMesh;         
    public GameObject fishPrefab;      

    [Header("Cấu hình Chiều dài Dây câu (Trục Y)")]
    public float idleScaleY = 0.1f;    // Độ dài dây khi thu gọn
    public float waterScaleY = 2.5f;   // Độ dài dây khi thả xuống nước
    public float scaleSpeed = 3.0f;    
    public float pullThreshold = 1.3f; 

    public enum FishingState { Idle, DroppingLine, WaitingForFish, FishBiting, FishCaught }
    public FishingState currentState = FishingState.Idle;

    private GameObject currentFishInstance;
    private float targetScaleY;
    private Vector3 lastPosition;
    private float upwardSpeed;

    // Biến lưu lại Scale gốc để chống méo
    private Vector3 rodOriginalScale;
    private Vector3 hookOriginalScale;

    void OnEnable()
    {
        if (grabAction.action != null) grabAction.action.Enable();
    }

    void OnDisable()
    {
        if (grabAction.action != null) grabAction.action.Disable();
    }

    void Start()
    {
        // 1. Lưu lại Scale ban đầu của Cần câu
        rodOriginalScale = transform.localScale;

        // 2. Lưu lại Scale ban đầu của Dây câu và cài độ dài mặc định
        if (hookWithLine != null)
        {
            hookOriginalScale = hookWithLine.localScale;
            targetScaleY = idleScaleY;
            hookWithLine.localScale = new Vector3(hookOriginalScale.x, idleScaleY, hookOriginalScale.z);
        }

        Debug.Log("<b>[VR CÂU CÁ]</b> Script đã khởi tạo thành công!");
    }

    void Update()
    {
        if (rightHandController == null) return;

        // ==========================================
        // 1. LOGIC NHẶT CẦN CÂU (Chỉ chạy khi chưa cầm)
        // ==========================================
        if (!isEquipped)
        {
            float dist = Vector3.Distance(transform.position, rightHandController.transform.position);
            
            if (CheckInputPressed())
            {
                if (dist <= pickupDistance)
                {
                    EquipRod();
                }
                else
                {
                    Debug.LogWarning($"<b>[VR NHẶT ĐỒ] THẤT BẠI:</b> Đứng quá xa! Cần <= {pickupDistance}m (Hiện tại: {dist:F2}m).");
                }
            }
            return;
        }

        // ==========================================
        // 2. LOGIC CÂU CÁ (Chỉ chạy khi đã cầm cần)
        // ==========================================
        upwardSpeed = (transform.position.y - lastPosition.y) / Time.deltaTime;
        lastPosition = transform.position;

        // CHỈ SCALE MỖI TRỤC Y CỦA DÂY CÂU, GIỮ NGUYÊN X VÀ Z
        if (hookWithLine != null)
        {
            float currentY = hookWithLine.localScale.y;
            float newY = Mathf.Lerp(currentY, targetScaleY, Time.deltaTime * scaleSpeed);
            
            hookWithLine.localScale = new Vector3(hookOriginalScale.x, newY, hookOriginalScale.z);
        }

        if (currentState == FishingState.FishBiting)
        {
            TriggerHaptic(0.4f, Time.deltaTime);

            if (upwardSpeed > pullThreshold)
            {
                Debug.Log($"<b>[VR CÂU CÁ]</b> Vung tay lên với tốc độ {upwardSpeed} -> BẮT ĐƯỢC CÁ!");
                CatchFish();
            }
        }
    }

    private bool CheckInputPressed()
    {
        if (grabAction.action != null && grabAction.action.WasPressedThisFrame()) return true;
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame) return true;
        return false;
    }

    private void EquipRod()
    {
        isEquipped = true;

        // Ép dính vào tay cầm
        transform.SetParent(rightHandController.transform, false);
        transform.localPosition = holdPosition;
        transform.localEulerAngles = holdRotation;
        
        // ÉP CẦN CÂU GIỮ NGUYÊN 100% SCALE GỐC (Không bị ảnh hưởng bởi Controller)
        transform.localScale = rodOriginalScale; 

        lastPosition = transform.position; 
        
        Debug.Log("<b>[VR NHẶT ĐỒ] THÀNH CÔNG:</b> Đã dính cần câu vào tay!");
    }

    public void StartFishingInWater()
    {
        if (currentState == FishingState.Idle && isEquipped) 
        {
            Debug.Log("<b>[VR CÂU CÁ]</b> Phao chạm nước! Bắt đầu thả dây...");
            StartCoroutine(FishingRoutine());
        }
    }

    private IEnumerator FishingRoutine()
    {
        currentState = FishingState.DroppingLine;
        targetScaleY = waterScaleY;
        yield return new WaitForSeconds(1.0f);

        currentState = FishingState.WaitingForFish;
        Debug.Log("<b>[VR CÂU CÁ]</b> Đang chờ cá cắn mồi...");
        yield return new WaitForSeconds(Random.Range(2f, 5f));

        currentState = FishingState.FishBiting;
        Debug.Log("<b>[VR CÂU CÁ] CÁ ĐÃ CẮN MỒI!!! Giật cần nhanh lên!</b>");
        TriggerHaptic(1.0f, 0.2f); 

        float timer = 0f;
        while (timer < 2.5f && currentState == FishingState.FishBiting)
        {
            timer += Time.deltaTime;
            float jerk = Mathf.Sin(timer * 20f) * 0.3f;
            
            // Chỉ làm rung lắc độ dài trục Y
            targetScaleY = waterScaleY + jerk;
            yield return null;
        }

        if (currentState == FishingState.FishBiting)
        {
            Debug.LogWarning("<b>[VR CÂU CÁ]</b> Giật quá chậm, CÁ ĐÃ XỔNG MẤT!");
            ResetToIdle();
        }
    }

    private void CatchFish()
    {
        StopAllCoroutines();
        currentState = FishingState.FishCaught;
        TriggerHaptic(0.8f, 0.4f);
        
        targetScaleY = idleScaleY;

        if (fishPrefab != null && hookMesh != null)
        {
            currentFishInstance = Instantiate(fishPrefab, hookMesh.position, hookMesh.rotation, hookMesh);
        }
    }

    public void ResetToIdle()
    {
        if (currentFishInstance != null) Destroy(currentFishInstance);
        currentState = FishingState.Idle;
        targetScaleY = idleScaleY;
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