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

        [Tooltip("Tốc độ làm ướt lại của nước mưa (% mỗi giây)")]
        [Min(0.1f)]
        public float rainDecaySpeedPerSecond = 8f;

        [Tooltip("Tự động đồng bộ trạng thái thời tiết từ FarmingWeatherSystem nếu có")]
        public bool autoConnectToWeatherSystem = true;

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
        // Sự kiện cảnh báo khi lúa bị dính mưa
        public event Action OnRainSoakingWarning;

        private float rainWarningCooldown = 0f;

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
            // Tự động đồng bộ với FarmingWeatherSystem nếu tồn tại
            if (autoConnectToWeatherSystem && FarmingWeatherSystem.Instance != null)
            {
                isSunny = FarmingWeatherSystem.Instance.IsSunny;
            }

            bool isRaining = (FarmingWeatherSystem.Instance != null && FarmingWeatherSystem.Instance.IsRaining);

            if (bundlesOnYard.Count == 0)
            {
                if (steamParticleFX != null && steamParticleFX.isPlaying)
                    steamParticleFX.Stop();
                return;
            }

            if (isRaining)
            {
                // Trời mưa -> Dừng hiệu ứng bốc hơi và giảm độ khô của các bó lúa không được che chắn
                if (steamParticleFX != null && steamParticleFX.isPlaying)
                    steamParticleFX.Stop();

                float rainDecayDelta = rainDecaySpeedPerSecond * Time.deltaTime;
                bool hasUnshelteredBundle = false;

                for (int i = bundlesOnYard.Count - 1; i >= 0; i--)
                {
                    RiceBundleItem bundle = bundlesOnYard[i];
                    if (bundle == null)
                    {
                        bundlesOnYard.RemoveAt(i);
                        continue;
                    }

                    if (!bundle.isSheltered)
                    {
                        hasUnshelteredBundle = true;
                        bundle.AddDryness(-rainDecayDelta);
                    }
                }

                if (hasUnshelteredBundle)
                {
                    rainWarningCooldown -= Time.deltaTime;
                    if (rainWarningCooldown <= 0f)
                    {
                        rainWarningCooldown = 5f; // Cảnh báo mỗi 5s
                        OnRainSoakingWarning?.Invoke();
                        Debug.LogWarning("<color=orange>Trời đang mưa! Lúa phơi trên sân đang bị ướt, hãy cất lúa vào nhà hoặc nơi có mái che!</color>");
                    }
                }
                return;
            }

            if (!isSunny)
            {
                if (steamParticleFX != null && steamParticleFX.isPlaying)
                    steamParticleFX.Stop();
                return;
            }

            // Trời nắng -> Phơi khô lúa bình thường
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
