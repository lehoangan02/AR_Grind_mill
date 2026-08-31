using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(Rigidbody))]
public class CaughtFishItem : MonoBehaviour
{
    [Header("Thông tin Con Cá")]
    public string fishName = "Cá Lóc";
    public FishType fishType = FishType.Default;
    public float weightInKg = 1.2f;

    [Header("Trạng thái Cầm Nắm")]
    public bool isGrabbedFromHook = false;

    public VRFishingController ownerRod;

    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;

    public delegate void FishCollectedHandler(CaughtFishItem fish);
    public event FishCollectedHandler OnFishCollected;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable == null)
        {
            grabInteractable = gameObject.AddComponent<XRGrabInteractable>();
        }

        // Tự động gán event grab
        grabInteractable.selectEntered.AddListener(OnGrabbed);
    }

    private void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        }
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        CollectFish();
    }

    public void CollectFish()
    {
        if (isGrabbedFromHook) return;

        isGrabbedFromHook = true;

        // Tháo khỏi dây câu/lưỡi câu
        transform.SetParent(null);

        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }

        Debug.Log($"<b>[CÂU CÁ]</b> Người chơi đã gỡ con cá {fishName} ({weightInKg:F1}kg) khỏi lưỡi câu!");

        OnFishCollected?.Invoke(this);

        if (ownerRod != null)
        {
            ownerRod.OnFishCollected(this);
        }
    }

    /// Cho phép nhặt trực tiếp trong Editor / Desktop test
    private void OnMouseDown()
    {
        CollectFish();
    }
}
