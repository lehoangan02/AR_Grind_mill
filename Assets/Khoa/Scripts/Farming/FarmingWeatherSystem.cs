using System;
using UnityEngine;

namespace Khoa.Farming
{
    public enum WeatherType
    {
        Sunny,      // Trời nắng (thuận lợi phơi lúa)
        Overcast,   // Trời râm mát
        Rainy       // Trời mưa (cần cất lúa vào nhà)
    }

    /// <summary>
    /// Hệ thống quản lý thời tiết nông nghiệp (Farming Weather System).
    /// Quản lý trạng thái Nắng / Mưa / Âm u, phát sự kiện và điều khiển hiệu ứng thời tiết.
    /// </summary>
    public class FarmingWeatherSystem : MonoBehaviour
    {
        public static FarmingWeatherSystem Instance { get; set; }

        [Header("Weather State")]
        [SerializeField]
        private WeatherType currentWeather = WeatherType.Sunny;

        [Header("Auto Weather Cycle (Tự động đổi thời tiết)")]
        [Tooltip("Bật tự động đổi thời tiết theo thời gian")]
        public bool autoCycleWeather = false;

        [Tooltip("Thời gian mỗi chu kỳ thời tiết (giây)")]
        [Min(10f)]
        public float weatherChangeInterval = 120f;

        [Header("FX & Audio")]
        [Tooltip("Particle hiệu ứng trời mưa")]
        public ParticleSystem rainParticleFX;
        [Tooltip("Âm thanh tiếng mưa rơi")]
        public AudioSource rainAudioSource;

        // Sự kiện khi thời tiết thay đổi
        public event Action<WeatherType> OnWeatherChanged;

        public WeatherType CurrentWeather => currentWeather;
        public bool IsSunny => currentWeather == WeatherType.Sunny;
        public bool IsRaining => currentWeather == WeatherType.Rainy;

        private float cycleTimer = 0f;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        private void Start()
        {
            ApplyWeatherVisuals(currentWeather);
        }

        private void Update()
        {
            if (autoCycleWeather)
            {
                cycleTimer += Time.deltaTime;
                if (cycleTimer >= weatherChangeInterval)
                {
                    cycleTimer = 0f;
                    ToggleNextWeather();
                }
            }
        }

        /// <summary>
        /// Chuyển sang thời tiết tiếp theo trong chu kỳ (Sunny -> Overcast -> Rainy -> Sunny)
        /// </summary>
        public void ToggleNextWeather()
        {
            WeatherType next = (WeatherType)(((int)currentWeather + 1) % 3);
            SetWeather(next);
        }

        /// <summary>
        /// Thiết lập trạng thái thời tiết cụ thể
        /// </summary>
        public void SetWeather(WeatherType newWeather)
        {
            if (currentWeather == newWeather) return;

            WeatherType oldWeather = currentWeather;
            currentWeather = newWeather;

            ApplyWeatherVisuals(currentWeather);
            OnWeatherChanged?.Invoke(currentWeather);

            Debug.Log($"<color=cyan>[FarmingWeatherSystem] Thời tiết thay đổi: {oldWeather} -> {currentWeather}</color>");
        }

        private void ApplyWeatherVisuals(WeatherType weather)
        {
            bool isRain = weather == WeatherType.Rainy;

            if (rainParticleFX != null)
            {
                if (isRain && !rainParticleFX.isPlaying)
                    rainParticleFX.Play();
                else if (!isRain && rainParticleFX.isPlaying)
                    rainParticleFX.Stop();
            }

            if (rainAudioSource != null)
            {
                if (isRain && !rainAudioSource.isPlaying)
                    rainAudioSource.Play();
                else if (!isRain && rainAudioSource.isPlaying)
                    rainAudioSource.Stop();
            }
        }

        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }
    }
}
