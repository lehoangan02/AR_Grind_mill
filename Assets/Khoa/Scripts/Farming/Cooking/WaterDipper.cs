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

        // Events
        public event Action OnWaterScooped;
        public event Action<float> OnWaterPoured;

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
        public void PourWater()
        {
            if (!hasWater) return;

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

            // Nhận diện nồi / thau ở phía dưới dòng nước rót
            Collider[] colliders = Physics.OverlapSphere(transform.position + Vector3.down * 0.35f, 0.65f);
            foreach (Collider col in colliders)
            {
                if (col.TryGetComponent<RiceWashingPot>(out var washingPot) || (col.transform.parent != null && col.transform.parent.TryGetComponent(out washingPot)))
                {
                    washingPot.AddWater(waterAmount);
                    break;
                }
                else if (col.TryGetComponent<CookingPot>(out var cookingPot) || (col.transform.parent != null && col.transform.parent.TryGetComponent(out cookingPot)))
                {
                    cookingPot.AddWater(waterAmount);
                    break;
                }
            }

            OnWaterPoured?.Invoke(waterAmount);
            Debug.Log("<color=cyan>[WaterDipper] Đã rót nước ra khỏi gáo.</color>");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other == null) return;

            // Chạm vào chum nước hoặc nguồn nước
            if (other.name.Contains("Water") || other.name.Contains("Jar"))
            {
                ScoopWater();
            }
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
