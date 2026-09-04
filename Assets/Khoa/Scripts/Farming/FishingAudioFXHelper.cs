using UnityEngine;

public static class FishingAudioFXHelper
{
    public static AudioClip CreateWaterSplashClip()
    {
        int sampleRate = 44100;
        float duration = 0.4f;
        int samples = (int)(sampleRate * duration);
        float[] data = new float[samples];

        for (int i = 0; i < samples; i++)
        {
            float t = (float)i / sampleRate;
            float envelope = Mathf.Exp(-t * 12f);
            float noise = (Random.value * 2f - 1f) * envelope;
            float tone = Mathf.Sin(2f * Mathf.PI * 220f * t) * envelope * 0.3f;
            data[i] = noise * 0.7f + tone;
        }

        AudioClip clip = AudioClip.Create("WaterSplash_Procedural", samples, 1, sampleRate, false);
        clip.SetData(data, 0);
        return clip;
    }

    public static AudioClip CreateBiteAlertClip()
    {
        int sampleRate = 44100;
        float duration = 0.3f;
        int samples = (int)(sampleRate * duration);
        float[] data = new float[samples];

        for (int i = 0; i < samples; i++)
        {
            float t = (float)i / sampleRate;
            float envelope = Mathf.Exp(-t * 10f);
            float freq = 440f + Mathf.Sin(t * 50f) * 120f;
            data[i] = Mathf.Sin(2f * Mathf.PI * freq * t) * envelope;
        }

        AudioClip clip = AudioClip.Create("BiteAlert_Procedural", samples, 1, sampleRate, false);
        clip.SetData(data, 0);
        return clip;
    }

    public static AudioClip CreateCatchSuccessClip()
    {
        int sampleRate = 44100;
        float duration = 0.6f;
        int samples = (int)(sampleRate * duration);
        float[] data = new float[samples];

        for (int i = 0; i < samples; i++)
        {
            float t = (float)i / sampleRate;
            float envelope = Mathf.Exp(-t * 4f);
            float note = (t < 0.2f) ? 523.25f : ((t < 0.4f) ? 659.25f : 783.99f); // C5 -> E5 -> G5
            data[i] = Mathf.Sin(2f * Mathf.PI * note * t) * envelope * 0.5f;
        }

        AudioClip clip = AudioClip.Create("CatchSuccess_Procedural", samples, 1, sampleRate, false);
        clip.SetData(data, 0);
        return clip;
    }

    public static void PlaySpatialClip(AudioClip clip, Vector3 position, float volume = 1f)
    {
        if (clip == null) return;

        GameObject audioGO = new GameObject("Temp_FishingSpatialAudio");
        audioGO.transform.position = position;

        AudioSource source = audioGO.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = Mathf.Clamp01(volume);
        source.spatialBlend = 1.0f; // 3D VR Spatial
        source.minDistance = 1f;
        source.maxDistance = 25f;
        source.Play();

        Object.Destroy(audioGO, clip.length + 0.1f);
    }
}
