using System;
using System.Collections.Generic;
using UnityEngine;

namespace Khoa.Farming
{
    /// <summary>
    /// Sân phơi lúa (Rice Drying Yard).
    /// Khi đặt các bó lúa RiceBundleItem lên sân phơi, độ khô (drynessProgress) sẽ tự động tăng theo thời gian dưới ánh nắng.
    /// </summary>
    [RequireComponent(typeof(BoxCollider))]
    public class RiceDryingYard : MonoBehaviour
    {
        [Header("Drying Settings")]
        [Tooltip("Tốc độ phơi khô (% mỗi giây)")]
        [Min(0.1f)]
        public float dryingSpeedPerSecond = 5f; // 20 giây phơi nắng sẽ khô 100%

        [Tooltip("Có ánh nắng mặt trời hay không (nếu trời mưa hoặc ban đêm thì dừng phơi)")]
        public bool isSunny = true;

        [Header("Runtime Bundles on Yard")]
        [Tooltip("Danh sách các bó lúa hiện đang nằm trên sân phơi")]
        public List<RiceBundleItem> bundlesOnYard = new List<RiceBundleItem>();

        [Header("FX")]
        [Tooltip("Hiệu ứng hơi nước bốc lên khi phơi lúa dưới nắng")]
        public ParticleSystem steamParticleFX;

        // Sự kiện khi một bó lúa phơi khô hoàn tất
        public event Action<RiceBundleItem> OnBundleDriedComplete;

        void Awake()
        {
            BoxCollider col = GetComponent<BoxCollider>();
            if (col != null)
            {
                col.isTrigger = true;
            }
        }

        void Update()
        {
            if (!isSunny || bundlesOnYard.Count == 0)
            {
                if (steamParticleFX != null && steamParticleFX.isPlaying)
                    steamParticleFX.Stop();
                return;
            }

            if (steamParticleFX != null && !steamParticleFX.isPlaying)
            {
                steamParticleFX.Play();
            }

            float drynessDelta = dryingSpeedPerSecond * Time.deltaTime;
            for (int i = bundlesOnYard.Count - 1; i >= 0; i--)
            {
                RiceBundleItem bundle = bundlesOnYard[i];
                if (bundle == null)
                {
                    bundlesOnYard.RemoveAt(i);
                    continue;
                }

                if (!bundle.isDry)
                {
                    bundle.AddDryness(drynessDelta);
                    if (bundle.isDry)
                    {
                        OnBundleDriedComplete?.Invoke(bundle);
                    }
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other == null) return;

            RiceBundleItem bundle = other.GetComponent<RiceBundleItem>();
            if (bundle == null)
            {
                bundle = other.GetComponentInParent<RiceBundleItem>();
            }

            if (bundle != null && !bundlesOnYard.Contains(bundle))
            {
                bundlesOnYard.Add(bundle);
                Debug.Log($"Đã đặt bó lúa lên sân phơi. Tiến độ khô hiện tại: {bundle.drynessProgress:F1}%");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other == null) return;

            RiceBundleItem bundle = other.GetComponent<RiceBundleItem>();
            if (bundle == null)
            {
                bundle = other.GetComponentInParent<RiceBundleItem>();
            }

            if (bundle != null && bundlesOnYard.Contains(bundle))
            {
                bundlesOnYard.Remove(bundle);
                Debug.Log("Đã nhặt bó lúa ra khỏi sân phơi.");
            }
        }
    }
}
