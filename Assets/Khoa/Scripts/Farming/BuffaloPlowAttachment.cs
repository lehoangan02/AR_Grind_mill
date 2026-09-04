using System;
using UnityEngine;

namespace Khoa.Farming
{
    /// <summary>
    /// Lưỡi bừa gắn sau đuôi trâu (hoặc nông cụ cày bừa).
    /// Khi trâu kéo bừa đi qua các ô đất CropPlot ở trạng thái Empty, đất sẽ tự động được xới (PlowPlot) thành Tilled.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class BuffaloPlowAttachment : MonoBehaviour
    {
        [Header("Plowing Settings")]
        [Tooltip("Bật/tắt chế độ cày bừa (ví dụ chỉ cày khi người chơi đang điều khiển trâu)")]
        public bool isPlowingActive = true;

        [Tooltip("Tag mặc định nhận diện lưỡi bừa")]
        public string plowTag = "Plow";

        [Header("Visual & Audio FX")]
        [Tooltip("Hiệu ứng bụi đất tung lên khi bừa ruộng")]
        public ParticleSystem plowDustParticles;

        [Tooltip("Âm thanh sột soạt khi bừa xới bùn đất")]
        public AudioSource plowAudioSource;

        // Sự kiện khi cày xong 1 ô đất
        public event Action<CropPlot> OnPlotPlowedByBuffalo;

        void Awake()
        {
            // Tự động gán Tag nếu chưa có
            if (!gameObject.CompareTag(plowTag))
            {
                try
                {
                    gameObject.tag = plowTag;
                }
                catch
                {
                    // Tag Plow chưa được tạo trong Unity TagManager thì vẫn hoạt động qua direct component check
                }
            }

            EnsurePhysicsSetup();
        }

        /// <summary>
        /// Trigger callbacks require at least one Rigidbody in the collision pair.
        /// A kinematic body lets the blade follow the buffalo without gravity or force drift.
        /// </summary>
        public void EnsurePhysicsSetup()
        {
            Collider col = GetComponent<Collider>();
            if (col == null)
            {
                BoxCollider box = gameObject.AddComponent<BoxCollider>();
                box.isTrigger = true;
                box.size = new Vector3(1.2f, 0.5f, 1f);
            }
            else
            {
                col.isTrigger = true;
            }

            Rigidbody body = GetComponent<Rigidbody>();
            if (body == null)
            {
                body = gameObject.AddComponent<Rigidbody>();
            }

            body.isKinematic = true;
            body.useGravity = false;
            body.interpolation = RigidbodyInterpolation.Interpolate;
            body.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!isPlowingActive || other == null) return;

            if (other.TryGetComponent<CropPlot>(out var plot))
            {
                PlowTargetPlot(plot);
            }
        }

        /// <summary>
        /// Xử lý cày xới ô đất mục tiêu
        /// </summary>
        public void PlowTargetPlot(CropPlot plot)
        {
            if (plot == null) return;

            if (plot.currentState == PlotState.Empty)
            {
                plot.PlowPlot();
                PlayPlowEffects(plot.transform.position);
                OnPlotPlowedByBuffalo?.Invoke(plot);
            }
        }

        private void PlayPlowEffects(Vector3 position)
        {
            if (plowDustParticles != null)
            {
                plowDustParticles.transform.position = position;
                plowDustParticles.Play();
            }

            if (plowAudioSource != null && !plowAudioSource.isPlaying)
            {
                plowAudioSource.Play();
            }
        }
    }
}
