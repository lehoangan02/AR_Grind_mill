using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Khoa.Farming
{
    /// <summary>
    /// Bông lúa rơi vãi trên ruộng sau khi gặt (Gleaned Rice Stalk).
    /// Dành cho cơ chế Mót Lúa trong VR: Người chơi cúi xuống nhặt từng bông lúa.
    /// Khi gom đủ số lượng (mặc định 3 bông), tự động kết hợp thành 1 Bó Lúa (RiceBundleItem) hoàn chỉnh.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(XRGrabInteractable))]
    [RequireComponent(typeof(Collider))]
    public class GleanedRiceStalk : MonoBehaviour
    {
        [Header("Gleaning Configuration")]
        [Tooltip("Prefab Bó Lúa (RiceBundleItem) sẽ sinh ra khi gom đủ bông lúa")]
        public GameObject bundlePrefabToSpawn;

        [Tooltip("Số bông lúa mót cần gom để ghép thành 1 bó lúa")]
        [Min(1)]
        public int stalksRequiredForBundle = 3;

        [Tooltip("Bó lúa sinh ra có bao nhiêu hạt thóc")]
        public int grainYieldPerBundle = 10;

        [Header("FX & Audio")]
        [Tooltip("Hiệu ứng hạt phát sáng khi nhặt bông lúa")]
        public ParticleSystem pickupSparkleFX;
        [Tooltip("Âm thanh khi nhặt bông lúa")]
        public AudioClip pickupSound;

        // Tiến độ mót lúa toàn cục của người chơi
        public static int currentGleanedCount = 0;

        // Events
        public static event Action<int, int> OnStalkGleaned; // (currentCount, targetCount)
        public static event Action<RiceBundleItem> OnBundleCraftedFromGleaning;

        private Rigidbody rb;
        private XRGrabInteractable grabInteractable;
        private AudioSource audioSource;
        private bool isCollected = false;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            grabInteractable = GetComponent<XRGrabInteractable>();

            if (rb != null)
            {
                rb.mass = 0.2f;
                rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                rb.interpolation = RigidbodyInterpolation.Interpolate;
            }

            if (grabInteractable != null)
            {
                grabInteractable.selectEntered.AddListener(OnGrabbed);
                grabInteractable.throwOnDetach = true;
            }

            audioSource = GetComponent<AudioSource>();
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
            if (isCollected) return;
            CollectStalk();
        }

        /// <summary>
        /// Xử lý khi người chơi nhặt/mót bông lúa này
        /// </summary>
        public void CollectStalk()
        {
            if (isCollected) return;
            isCollected = true;

            currentGleanedCount++;
            Debug.Log($"<color=yellow>🌾 Đã mót được 1 bông lúa! Tiến độ: {currentGleanedCount}/{stalksRequiredForBundle}</color>");

            PlaySound(pickupSound);

            if (pickupSparkleFX != null)
            {
                pickupSparkleFX.transform.SetParent(null);
                pickupSparkleFX.Play();
                Destroy(pickupSparkleFX.gameObject, 2f);
            }

            OnStalkGleaned?.Invoke(currentGleanedCount, stalksRequiredForBundle);

            // Kiểm tra nếu gom đủ số lượng để kết hợp thành 1 bó lúa
            if (currentGleanedCount >= stalksRequiredForBundle)
            {
                currentGleanedCount = 0;
                SpawnCraftedBundle();
            }

            // Huỷ bông lúa mót
            if (Application.isPlaying)
                Destroy(gameObject);
            else
                DestroyImmediate(gameObject);
        }

        private void SpawnCraftedBundle()
        {
            if (bundlePrefabToSpawn != null)
            {
                Vector3 spawnPos = transform.position + Vector3.up * 0.2f;
                GameObject bundleGO = Instantiate(bundlePrefabToSpawn, spawnPos, Quaternion.identity);

                RiceBundleItem bundle = bundleGO.GetComponent<RiceBundleItem>();
                if (bundle != null)
                {
                    bundle.grainAmount = grainYieldPerBundle;
                    bundle.drynessProgress = 0f;
                    bundle.isDry = false;
                    OnBundleCraftedFromGleaning?.Invoke(bundle);
                }

                Debug.Log("<color=green>✨ Bạn đã mót đủ lúa và bó lại thành 1 Bó Lúa (RiceBundleItem) hoàn chỉnh!</color>");
            }
        }

        private void PlaySound(AudioClip clip)
        {
            if (clip != null)
            {
                AudioSource.PlayClipAtPoint(clip, transform.position);
            }
        }
    }
}
