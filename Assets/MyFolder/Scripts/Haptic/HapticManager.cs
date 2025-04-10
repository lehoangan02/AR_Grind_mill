using UnityEngine;
using CandyCoded.HapticFeedback;
public static class HapticManager
{
    /// <summary>
    /// </summary>
    public static void HeavyHapticFeedback()
    {
    #if UNITY_IOS && !UNITY_EDITOR
        HapticFeedback.HeavyFeedback();
    #elif UNITY_ANDROID && !UNITY_EDITOR
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        using (AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
        using (AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator"))
        {
            if (vibrator != null)
            {
                AndroidJavaObject vibrationEffect = null;
                AndroidJavaClass vibrationEffectClass = new AndroidJavaClass("android.os.VibrationEffect");

                try
                {
                    // Use predefined heavy click as our "heavy" intensity.
                    int effectHeavyClick = vibrationEffectClass.GetStatic<int>("EFFECT_HEAVY_CLICK");
                    vibrationEffect = vibrationEffectClass.CallStatic<AndroidJavaObject>("createPredefined", effectHeavyClick);
                }
                catch (System.Exception)
                {
                    // Fallback for earlier Android versions.
                    vibrationEffect = vibrationEffectClass.CallStatic<AndroidJavaObject>("createOneShot", 20, 256);
                }
                vibrator.Call("vibrate", vibrationEffect);
            }
        }
#endif
    }

    /// <summary>
    /// Triggers a medium haptic feedback using the predefined heavy click effect.
    /// (Treated as medium intensity here.)
    /// </summary>
    public static void MediumHapticFeedback()
    {
    #if UNITY_IOS && !UNITY_EDITOR
        HapticFeedback.MediumFeedback();
    #elif UNITY_ANDROID && !UNITY_EDITOR
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        using (AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
        using (AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator"))
        {
            if (vibrator != null)
            {
                AndroidJavaObject vibrationEffect = null;
                AndroidJavaClass vibrationEffectClass = new AndroidJavaClass("android.os.VibrationEffect");

                try
                {
                    // Use predefined heavy click as our "medium" intensity.
                    int effectClick = vibrationEffectClass.GetStatic<int>("EFFECT_CLICK");
                    vibrationEffect = vibrationEffectClass.CallStatic<AndroidJavaObject>("createPredefined", effectClick);
                }
                catch (System.Exception)
                {
                    // Fallback for earlier Android versions.
                    vibrationEffect = vibrationEffectClass.CallStatic<AndroidJavaObject>("createOneShot", 20, 180);
                }
                vibrator.Call("vibrate", vibrationEffect);
            }
        }
#endif
    }

    /// <summary>
    /// Triggers a light haptic feedback using a predefined tick effect.
    /// </summary>
    public static void LightHapticFeedback()
    {
    #if UNITY_IOS && !UNITY_EDITOR
        HapticFeedback.LightFeedback();
    #elif UNITY_ANDROID && !UNITY_EDITOR
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        using (AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
        using (AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator"))
        {
            if (vibrator != null)
            {
                AndroidJavaObject vibrationEffect = null;
                AndroidJavaClass vibrationEffectClass = new AndroidJavaClass("android.os.VibrationEffect");

                try
                {
                    // Use predefined tick effect as a light feedback.
                    int effectTick = vibrationEffectClass.GetStatic<int>("EFFECT_TICK");
                    vibrationEffect = vibrationEffectClass.CallStatic<AndroidJavaObject>("createPredefined", effectTick);
                }
                catch (System.Exception)
                {
                    // Fallback for earlier Android versions: a very short, lower-amplitude vibration.
                    vibrationEffect = vibrationEffectClass.CallStatic<AndroidJavaObject>("createOneShot", 10, 128);
                }
                vibrator.Call("vibrate", vibrationEffect);
            }
        }
#endif
    }
}
