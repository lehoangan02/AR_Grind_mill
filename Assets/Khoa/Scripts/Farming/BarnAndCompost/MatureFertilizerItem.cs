using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Khoa.Farming
{
    /// <summary>
    /// Phân bón sinh học đã ủ hoai mục (thành phẩm từ CompostPile).
    /// Dùng để bón lót ruộng lúa (CropPlot ở trạng thái Tilled hoặc đang trồng).
    /// Sử dụng 1 lần duy nhất; chỉ tiêu thụ khi bón thành công vào ruộng hợp lệ.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(XRGrabInteractable))]
    public class MatureFertilizerItem : MonoBehaviour
    {
        [Header("Trạng thái")]
        [SerializeField] private bool isConsumed = false;
        public bool IsConsumed => isConsumed;

        [Header("Hiệu ứng khi bón")]
        public ParticleSystem applyParticleFX;
        public AudioClip applyAudioClip;

        public event Action<MatureFertilizerItem> OnApplied;

        private XRGrabInteractable grabInteractable;
        private Rigidbody rb;
        private Collider col;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            col = GetComponent<Collider>();
            grabInteractable = GetComponent<XRGrabInteractable>();

            if (string.IsNullOrEmpty(gameObject.tag) || gameObject.tag == "Untagged")
            {
                // Giữ tag Fertilizer để tương thích ngược
                try
                {
                    gameObject.tag = "Fertilizer";
                }
                catch
                {
                    // Ignore nếu tag chưa được đăng ký trong tag manager
                }
            }
        }

        /// <summary>
        /// Thử bón phân vào ô ruộng chỉ định.
        /// </summary>
        public bool TryApplyTo(CropPlot plot)
        {
            if (isConsumed || plot == null) return false;

            bool success = plot.TryApplyFertilizer(this);
            if (success)
            {
                ConsumeItem(plot.transform.position);
                return true;
            }

            return false;
        }

        private void ConsumeItem(Vector3 targetPos)
        {
            if (isConsumed) return;
            isConsumed = true;

            if (col != null) col.enabled = false;
            if (rb != null) rb.isKinematic = true;

            if (applyParticleFX != null)
            {
                applyParticleFX.transform.SetParent(null);
                applyParticleFX.transform.position = targetPos + Vector3.up * 0.1f;
                applyParticleFX.Play();
                if (Application.isPlaying) Destroy(applyParticleFX.gameObject, 2f);
                else DestroyImmediate(applyParticleFX.gameObject);
            }

            if (applyAudioClip != null)
            {
                AudioSource.PlayClipAtPoint(applyAudioClip, targetPos, 0.9f);
            }

            OnApplied?.Invoke(this);
            if (Application.isPlaying) Destroy(gameObject, 0.05f);
            else DestroyImmediate(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            HandleCollision(other);
        }

        private void OnCollisionEnter(Collision collision)
        {
            HandleCollision(collision.collider);
        }

        private void HandleCollision(Collider other)
        {
            if (isConsumed || other == null) return;

            CropPlot plot = other.GetComponent<CropPlot>() ?? other.GetComponentInParent<CropPlot>();
            if (plot == null)
            {
                RicePlant plant = other.GetComponent<RicePlant>() ?? other.GetComponentInParent<RicePlant>();
                if (plant != null)
                {
                    plot = plant.assignedPlot;
                }
            }

            if (plot != null)
            {
                TryApplyTo(plot);
            }
        }
    }
}
