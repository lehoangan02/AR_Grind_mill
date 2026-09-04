using UnityEngine;

namespace Khoa.Farming
{
    /// <summary>
    /// Helper phát âm thanh không gian (3D Spatial Audio) cho trải nghiệm VR tự nhiên và phản hồi xúc giác.
    /// </summary>
    public static class FarmingAudioFXHelper
    {
        /// <summary>
        /// Phát một âm thanh tại vị trí 3D xác định trong không gian VR
        /// </summary>
        public static void PlaySpatialClip(AudioClip clip, Vector3 position, float volume = 1f, float pitch = 1f)
        {
            if (clip == null) return;

            GameObject audioGO = new GameObject("Temp_SpatialAudio");
            audioGO.transform.position = position;

            AudioSource source = audioGO.AddComponent<AudioSource>();
            source.clip = clip;
            source.volume = Mathf.Clamp01(volume);
            source.pitch = Mathf.Clamp(pitch, 0.5f, 2.0f);
            source.spatialBlend = 1.0f; // 100% 3D spatial audio
            source.minDistance = 1f;
            source.maxDistance = 20f;
            source.rolloffMode = AudioRolloffMode.Logarithmic;
            source.Play();

            Object.Destroy(audioGO, clip.length / Mathf.Max(0.1f, source.pitch) + 0.1f);
        }

        /// <summary>
        /// Cấu hình một AudioSource có sẵn thành chuẩn 3D Spatial Audio cho VR
        /// </summary>
        public static void SetupVRSpatialAudioSource(AudioSource source, float minDistance = 1f, float maxDistance = 25f)
        {
            if (source == null) return;

            source.spatialBlend = 1.0f;
            source.minDistance = minDistance;
            source.maxDistance = maxDistance;
            source.rolloffMode = AudioRolloffMode.Logarithmic;
            source.dopplerLevel = 0.5f;
            source.playOnAwake = false;
        }
    }
}
