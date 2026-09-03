using UnityEngine;

namespace Khoa.Farming.Boating
{
    /// <summary>
    /// Quản lý âm thanh 3D (khua nước, cọt kẹt thân gỗ, nước vỗ mạn thuyền)
    /// và hiệu ứng hạt bọt nước rẽ sóng cho Xuồng Ba Lá.
    /// </summary>
    [DisallowMultipleComponent]
    public class SampanAudioAndVFX : MonoBehaviour
    {
        [Header("Nguồn phát âm thanh")]
        public AudioSource mainAudioSource;
        public AudioSource waterLapSource;

        [Header("Âm thanh hiệu ứng")]
        public AudioClip paddleStrokeClip;
        public AudioClip bladeSplashClip;
        public AudioClip woodCreakClip;

        [Header("Hiệu ứng hạt bọt nước")]
        public ParticleSystem splashParticlePrefab;
        public ParticleSystem boatWakeFX;

        private float nextCreakTime = 0f;

        private void Start()
        {
            if (mainAudioSource == null)
            {
                mainAudioSource = gameObject.AddComponent<AudioSource>();
                mainAudioSource.spatialBlend = 1f; // 3D Audio
                mainAudioSource.maxDistance = 15f;
            }

            if (boatWakeFX != null && !boatWakeFX.isPlaying)
            {
                boatWakeFX.Play();
            }
        }

        private void Update()
        {
            // Tiếng cọt kẹt thân gỗ ngẫu nhiên theo thời gian
            if (Time.time >= nextCreakTime)
            {
                nextCreakTime = Time.time + Random.Range(6f, 14f);
                PlayWoodCreak();
            }
        }

        public void PlayBladeSplash(Vector3 position, float speed)
        {
            if (bladeSplashClip != null && mainAudioSource != null)
            {
                float vol = Mathf.Clamp(speed / 3f, 0.2f, 0.8f);
                mainAudioSource.PlayOneShot(bladeSplashClip, vol);
            }

            if (splashParticlePrefab != null)
            {
                ParticleSystem fx = Instantiate(splashParticlePrefab, position, Quaternion.identity);
                fx.Play();
                if (Application.isPlaying) Destroy(fx.gameObject, 1.5f);
                else DestroyImmediate(fx.gameObject);
            }
        }

        public void OnPaddleStroke(float strokeForce)
        {
            if (paddleStrokeClip != null && mainAudioSource != null)
            {
                float vol = Mathf.Clamp(strokeForce / 150f, 0.3f, 0.9f);
                mainAudioSource.pitch = Random.Range(0.9f, 1.1f);
                mainAudioSource.PlayOneShot(paddleStrokeClip, vol);
            }
        }

        public void PlayWoodCreak()
        {
            if (woodCreakClip != null && mainAudioSource != null)
            {
                mainAudioSource.PlayOneShot(woodCreakClip, 0.4f);
            }
        }
    }
}
