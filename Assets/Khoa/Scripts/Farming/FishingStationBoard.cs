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
    public string castMessage = "Bấm để THẢ CÂU";
    public string droppingMessage = "ĐANG THẢ CÂU...";
    public string waitingMessage = "ĐANG CHỜ CÁ CẮN...";
    public string catchMessage = "CÁ CẮN CÂU! BẤM VÀO CẦN CÂU";
    public string caughtMessage = "ĐÃ BẮT ĐƯỢC CÁ!";

    [Header("Vị trí cất cần (Rack Position)")]
    public Transform rackStandPoint;
    public Vector3 defaultRackPosition = new Vector3(-12.5f, 103.2f, -20.5f);
    public Quaternion defaultRackRotation = Quaternion.Euler(0, 45f, 0);

    [Header("Âm thanh Phản hồi")]
    public AudioSource audioSource;
    public AudioClip toggleSound;

    private XRSimpleInteractable simpleInteractable;
    private int lastInteractionFrame = -1;

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
        }
    }

    private void OnDisable()
    {
        if (simpleInteractable != null)
        {
            simpleInteractable.selectEntered.RemoveListener(OnBoardClicked);
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
        // Some desktop/XR setups can report two callbacks for one physical press.
        if (lastInteractionFrame == Time.frameCount) return;
        lastInteractionFrame = Time.frameCount;

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
            // One board click fixes the rod at the station and casts immediately.
            Debug.Log("<b>[BẢNG CÂU CÁ]</b> Cố định cần tại điểm câu và thả câu.");
            fishingRod.EquipRod();
            fishingRod.HandlePrimaryClick();
        }
        else
        {
            // Rod is already equipped: forward the click to the controller so the board
            // (the big, easy-to-aim target) can ALSO catch the fish.
            //   - During FishBiting  -> CatchFish() (fish appears).
            //   - During Dropping/Waiting -> safely ignored by the controller.
            //   - During FishCaught -> safely ignored ("fish already visible").
            fishingRod.HandlePrimaryClick();
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
                switch (fishingRod.currentState)
                {
                    case VRFishingController.FishingState.Idle:
                        statusText.text = $"<color=cyan>{castMessage}</color>";
                        break;
                    case VRFishingController.FishingState.DroppingLine:
                        statusText.text = $"<color=cyan>{droppingMessage}</color>";
                        break;
                    case VRFishingController.FishingState.WaitingForFish:
                        statusText.text = $"<color=yellow>{waitingMessage}</color>";
                        break;
                    case VRFishingController.FishingState.FishBiting:
                        statusText.text = $"<color=red>{catchMessage}</color>";
                        break;
                    case VRFishingController.FishingState.FishCaught:
                        statusText.text = $"<color=green>{caughtMessage}</color>";
                        break;
                }
            }
            else
            {
                statusText.text = $"<color=green>{castMessage}</color>";
            }
        }
    }

    /// Hỗ trợ click chuột trong Editor / Desktop Mode
    private void OnMouseDown()
    {
        ToggleFishingRod();
    }
}
