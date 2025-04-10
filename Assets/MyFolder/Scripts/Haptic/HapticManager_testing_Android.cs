using UnityEngine;
using UnityEngine.UI;
using MobileHapticsForUnity;

public class HapticController_testing_Android : MonoBehaviour
{
    [SerializeField] private Button defaultVibrationButton_Android;
    [SerializeField] private Button lightVibrationButton_Android;
    [SerializeField] private Button mediumVibrationButton_Android;
    [SerializeField] private Button heavyVibrationButton_Android;
    private void Start()
    {
        Vibration.Init();   
    }
    private void OnEnable()
    {
        defaultVibrationButton_Android.onClick.AddListener(DefaultVibration_Android);
        lightVibrationButton_Android.onClick.AddListener(LightVibration_Android);
        mediumVibrationButton_Android.onClick.AddListener(MediumVibration_Android);
        heavyVibrationButton_Android.onClick.AddListener(HeavyVibration_Android);
    }
    private void OnDisable()
    {
        defaultVibrationButton_Android.onClick.RemoveListener(DefaultVibration_Android);
        lightVibrationButton_Android.onClick.RemoveListener(LightVibration_Android);
        mediumVibrationButton_Android.onClick.RemoveListener(MediumVibration_Android);
        heavyVibrationButton_Android.onClick.RemoveListener(HeavyVibration_Android);
    }
    private void DefaultVibration_Android()
    {
        Debug.Log("Default Vibration");
        Handheld.Vibrate();
    }
    private void LightVibration_Android()
    {
        Debug.Log("Light Vibration");
        HapticManager.LightHapticFeedback();

    }
    private void MediumVibration_Android()
    {
        Debug.Log("Medium Vibration");
        HapticManager.MediumHapticFeedback();
    }
    private void HeavyVibration_Android()
    {
        Debug.Log("Heavy Vibration");
        HapticManager.HeavyHapticFeedback();
    }
}
