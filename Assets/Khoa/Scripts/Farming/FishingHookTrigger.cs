using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FishingHookTrigger : MonoBehaviour
{
    [Header("Tham chiếu Controller")]
    public VRFishingController fishingController;

    [Header("Visual & Sound Effects")]
    public ParticleSystem waterSplashParticle;
    public AudioSource audioSource;
    public AudioClip splashSound;

    [Header("Cấu hình Water Layer / Tag")]
    public LayerMask waterLayerMask = -1;
    public string waterTag = "Water";

    private void Awake()
    {
        EnsureControllerReference();

        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.isTrigger = true;
        }
    }

    public void EnsureControllerReference()
    {
        if (fishingController == null)
        {
            fishingController = GetComponentInParent<VRFishingController>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsWaterCollider(other))
        {
            FishingZone zone = other != null ? (other.GetComponent<FishingZone>() ?? other.GetComponentInParent<FishingZone>()) : null;

            PlayWaterSplash();

            EnsureControllerReference();
            if (fishingController != null)
            {
                fishingController.StartFishingInWater(zone);
            }
        }
    }

    public bool IsWaterCollider(Collider other)
    {
        if (other == null) return false;

        // 1. Kiểm tra Tag "Water"
        try
        {
            if (!string.IsNullOrEmpty(waterTag) && other.CompareTag(waterTag)) return true;
        }
        catch
        {
            // Bỏ qua nếu Tag chưa được định nghĩa trong TagManager
        }

        // 2. Kiểm tra Layer "Water" (Layer 4 trong Unity mặc định)
        if (other.gameObject != null && other.gameObject.layer == LayerMask.NameToLayer("Water")) return true;

        // 3. Kiểm tra xem có script FishingZone hoặc name chứa Water/Nước không
        if (other.GetComponent<FishingZone>() != null || other.GetComponentInParent<FishingZone>() != null) return true;

        if (!string.IsNullOrEmpty(other.name))
        {
            string nameLower = other.name.ToLower();
            if (nameLower.Contains("water") || nameLower.Contains("nuoc") || nameLower.Contains("river") || nameLower.Contains("pond")) return true;
        }

        return false;
    }

    public void PlayWaterSplash()
    {
        if (waterSplashParticle != null)
        {
            waterSplashParticle.Play();
        }

        if (audioSource != null && splashSound != null)
        {
            audioSource.PlayOneShot(splashSound);
        }
    }
}
