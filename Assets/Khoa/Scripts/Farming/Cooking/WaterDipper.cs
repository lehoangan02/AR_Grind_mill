using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Khoa.Farming
{
    /// <summary>
    /// Gáo múc nước dừa / Ca múc nước truyền thống miền Tây.
    /// Dùng để múc nước từ chum vại (WaterJar) và rót vào thau vo gạo (RiceWashingPot) hoặc nồi cơm (CookingPot).
    /// Hỗ trợ cầm nắm bằng XRGrabInteractable, tự động nhận diện múc nước và rót nước khi nghiêng gáo.
    /// </summary>
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(XRGrabInteractable))]
    public class WaterDipper : MonoBehaviour
    {
        [Header("State")]
        [Tooltip("Gáo hiện đang có nước hay không")]
        public bool hasWater = false;

        [Tooltip("Lượng nước chứa trong gáo (đơn vị ml / phần)")]
        public float waterAmount = 1.0f;

        [Header("Visual & FX")]
        [Tooltip("Mặt nước trong gáo (hiện khi có nước)")]
        public GameObject waterSurfaceVisual;

        [Tooltip("Hiệu ứng hạt dòng nước rót ra khi nghiêng gáo")]
        public ParticleSystem pourWaterFX;

        [Tooltip("Âm thanh múc nước / rót nước")]
        public AudioSource audioSource;
        public AudioClip scoopSound;
        public AudioClip pourSound;

        [Header("Pour Settings")]
        [Tooltip("Góc nghiêng tối thiểu để nước tự động rót ra (độ)")]
        [Range(30f, 90f)]
        public float pourTiltAngle = 50f;
        [Tooltip("Mouth of the dipper. Its local down direction defines the pour ray.")]
        public Transform pourOrigin;
        [Min(0.05f)] public float pourRadius = 0.12f;
        [Min(0.1f)] public float pourDistance = 0.8f;

        // Events
        public event Action OnWaterScooped;
        public event Action<float> OnWaterPoured;
        public event Action<float> OnWaterSpilled;

        private Rigidbody rb;
        private XRGrabInteractable grabInteractable;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            grabInteractable = GetComponent<XRGrabInteractable>();

            if (rb != null)
            {
                rb.mass = 0.5f;
                rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                rb.interpolation = RigidbodyInterpolation.Interpolate;
            }

            if (grabInteractable != null)
            {
                grabInteractable.throwOnDetach = true;
                grabInteractable.throwSmoothingDuration = 0.2f;
            }

            if (audioSource == null)
            {
                audioSource = GetComponent<AudioSource>();
                if (audioSource == null)
                {
                    audioSource = gameObject.AddComponent<AudioSource>();
                    audioSource.spatialBlend = 1f;
                    audioSource.playOnAwake = false;
                }
            }
            if (audioSource != null)
            {
                audioSource.playOnAwake = false;
                audioSource.spatialBlend = 1f;
            }

            UpdateVisuals();
        }

        private void Update()
        {
            if (!hasWater) return;

            // Kiểm tra góc nghiêng của gáo so với phương thẳng đứng
            float tilt = Vector3.Angle(transform.up, Vector3.up);
            if (tilt >= pourTiltAngle)
            {
                PourWater();
            }
        }

        /// <summary>
        /// Múc nước vào gáo từ chum/vại nước.
        /// </summary>
        public void ScoopWater()
        {
            if (hasWater) return;

            hasWater = true;
            UpdateVisuals();

            if (audioSource != null && scoopSound != null)
            {
                audioSource.PlayOneShot(scoopSound);
            }

            OnWaterScooped?.Invoke();
            Debug.Log("<color=cyan>[WaterDipper] Đã múc đầy gáo nước trong mát từ chum!</color>");
        }

        /// <summary>
        /// Rót nước ra khỏi gáo.
        /// </summary>
        public bool PourWater()
        {
            if (!hasWater) return false;

            Transform origin = pourOrigin != null ? pourOrigin : transform;
            RaycastHit[] hits = Physics.SphereCastAll(origin.position, pourRadius, -origin.up, pourDistance, ~0, QueryTriggerInteraction.Collide);
            Array.Sort(hits, (a, b) => a.distance.CompareTo(b.distance));
            foreach (RaycastHit hit in hits)
            {
                IWaterReceiver receiver = FindWaterReceiver(hit.collider);
                if (receiver != null && TryPourInto(receiver))
                {
                    return true;
                }
            }

            SpillWater();
            return false;
        }

        public bool TryPourInto(IWaterReceiver receiver)
        {
            if (!hasWater || receiver == null || !receiver.TryAddWater(waterAmount))
            {
                return false;
            }

            hasWater = false;
            UpdateVisuals();

            if (pourWaterFX != null)
            {
                pourWaterFX.Play();
            }

            if (audioSource != null && pourSound != null)
            {
                audioSource.PlayOneShot(pourSound);
            }

            OnWaterPoured?.Invoke(waterAmount);
            Debug.Log("<color=cyan>[WaterDipper] Đã rót nước ra khỏi gáo.</color>");
            return true;
        }

        public bool SpillWater()
        {
            if (!hasWater) return false;

            hasWater = false;
            UpdateVisuals();
            if (pourWaterFX != null) pourWaterFX.Play();
            if (audioSource != null && pourSound != null) audioSource.PlayOneShot(pourSound);
            OnWaterSpilled?.Invoke(waterAmount);
            Debug.Log("[WaterDipper] Nước đã đổ ra ngoài, không có dụng cụ nào nhận nước.");
            return true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other == null) return;

            if (other.GetComponentInParent<WaterSource>() != null)
            {
                ScoopWater();
            }
        }

        private static IWaterReceiver FindWaterReceiver(Collider collider)
        {
            if (collider == null) return null;
            MonoBehaviour[] behaviours = collider.GetComponentsInParent<MonoBehaviour>();
            foreach (MonoBehaviour behaviour in behaviours)
            {
                if (behaviour is IWaterReceiver receiver) return receiver;
            }
            return null;
        }

        private void UpdateVisuals()
        {
            if (waterSurfaceVisual != null)
            {
                waterSurfaceVisual.SetActive(hasWater);
            }
        }
    }
}
