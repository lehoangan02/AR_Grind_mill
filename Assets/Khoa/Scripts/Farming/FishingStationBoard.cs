using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(Collider))]
public class FishingStationBoard : MonoBehaviour
{
    [Header("Tham chiếu Cần câu")]
    public VRFishingController fishingRod;

    [Header("UI & Hiển thị Text")]
    public TMP_Text statusText;
    public string getRodMessage = "Bấm vào đây để LẤY Cần Câu";
    public string returnRodMessage = "Bấm vào đây để CẤT Cần Câu";

    [Header("Vị trí cất cần (Rack Position)")]
    public Transform rackStandPoint;
    public Vector3 defaultRackPosition = new Vector3(-12.5f, 103.2f, -20.5f);
    public Quaternion defaultRackRotation = Quaternion.Euler(0, 45f, 0);

    [Header("Âm thanh Phản hồi")]
    public AudioSource audioSource;
    public AudioClip toggleSound;

    private XRSimpleInteractable simpleInteractable;

    private void Awake()
    {
        simpleInteractable = GetComponent<XRSimpleInteractable>();
        if (simpleInteractable == null)
        {
            simpleInteractable = gameObject.AddComponent<XRSimpleInteractable>();
        }

        if (audioSource == null) audioSource = GetComponent<AudioSource>();

        // Đảm bảo Collider để XRI Ray Interactor bấm được
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.isTrigger = false; 
        }
    }

    private void OnEnable()
    {
        if (simpleInteractable != null)
        {
            simpleInteractable.selectEntered.AddListener(OnBoardClicked);
            simpleInteractable.activated.AddListener(OnBoardActivated);
        }
    }

    private void OnDisable()
    {
        if (simpleInteractable != null)
        {
            simpleInteractable.selectEntered.RemoveListener(OnBoardClicked);
            simpleInteractable.activated.RemoveListener(OnBoardActivated);
        }
    }

    private void Start()
    {
        if (fishingRod == null)
        {
            fishingRod = Object.FindAnyObjectByType<VRFishingController>();
        }

        if (fishingRod != null)
        {
            fishingRod.OnStateChanged += OnRodStateChanged;
        }

        if (rackStandPoint != null)
        {
            defaultRackPosition = rackStandPoint.position;
            defaultRackRotation = rackStandPoint.rotation;
        }

        UpdateBoardUI();
    }

    private void OnDestroy()
    {
        if (fishingRod != null)
        {
            fishingRod.OnStateChanged -= OnRodStateChanged;
        }
    }

    private void OnXRIClicked()
    {
        ToggleFishingRod();
    }

    private void OnBoardClicked(SelectEnterEventArgs args)
    {
        ToggleFishingRod();
    }

    private void OnBoardActivated(ActivateEventArgs args)
    {
        ToggleFishingRod();
    }

    public void ToggleFishingRod()
    {
        if (fishingRod == null)
        {
            fishingRod = Object.FindAnyObjectByType<VRFishingController>();
            if (fishingRod == null)
            {
                Debug.LogWarning("<b>[BẢNG CÂU CÁ]</b> Không tìm thấy VRFishingController trong Scene!");
                return;
            }
        }

        if (audioSource != null && toggleSound != null)
        {
            audioSource.PlayOneShot(toggleSound);
        }

        if (!fishingRod.isEquipped)
        {
            // Người chơi chưa cầm -> LẤY cần câu dính vào tay
            Debug.Log("<b>[BẢNG CÂU CÁ]</b> Người chơi bấm bảng: LẤY CẦN CÂU dính vào tay!");
            fishingRod.EquipRod();
        }
        else
        {
            // Người chơi đang cầm -> CẤT cần câu về giá/bảng
            Debug.Log("<b>[BẢNG CÂU CÁ]</b> Người chơi bấm bảng: CẤT CẦN CÂU về giá!");
            fishingRod.UnequipRod(defaultRackPosition, defaultRackRotation);
        }

        UpdateBoardUI();
    }

    private void OnRodStateChanged(VRFishingController.FishingState state)
    {
        UpdateBoardUI();
    }

    public void UpdateBoardUI()
    {
        if (statusText == null) statusText = GetComponentInChildren<TMP_Text>();

        if (statusText != null)
        {
            if (fishingRod != null && fishingRod.isEquipped)
            {
                statusText.text = $"<color=yellow>{returnRodMessage}</color>";
            }
            else
            {
                statusText.text = $"<color=green>{getRodMessage}</color>";
            }
        }
    }

    /// Hỗ trợ click chuột trong Editor / Desktop Mode
    private void OnMouseDown()
    {
        ToggleFishingRod();
    }
}
