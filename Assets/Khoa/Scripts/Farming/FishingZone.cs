using UnityEngine;

public enum FishType
{
    Default,    // Cá rô / Cá diếc
    Catfish,    // Cá tra (khu vực cầu cá tra)
    Snakehead   // Cá lóc (khu vực sông sâu / xa)
}

[DisallowMultipleComponent]
public class FishingZone : MonoBehaviour
{
    [Header("Cấu hình Vùng Câu Cá (Fishing Zone)")]
    public string zoneName = "Vùng câu cá";
    public FishType fishType = FishType.Default;

    [Header("Loại cá xuất hiện trong vùng")]
    public GameObject customFishPrefab;

    [Header("Thời gian cá cắn mồi (giây)")]
    public float minBiteDelay = 2.0f;
    public float maxBiteDelay = 5.0f;

    [Header("Độ khó giật cần (Hệ số lực kéo)")]
    public float pullThresholdMultiplier = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        // Debug log khi có vật thể chạm vào vùng câu cá
        if (other.GetComponent<FishingHookTrigger>() != null)
        {
            Debug.Log($"<b>[FISHING ZONE]</b> Lưỡi câu đã đi vào vùng câu: {zoneName} ({fishType})");
        }
    }
}
