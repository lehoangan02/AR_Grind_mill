using UnityEngine;
using UnityEngine.UI;
using CandyCoded.HapticFeedback;

public class HapticController_testing_iOS : MonoBehaviour
{
    [SerializeField] private Button defaultVibrationButton;
    [SerializeField] private Button lightVibrationButton;
    [SerializeField] private Button mediumVibrationButton;
    [SerializeField] private Button heavyVibrationButton;
    private void OnEnable()
    {
        defaultVibrationButton.onClick.AddListener(DefaultVibration);
        lightVibrationButton.onClick.AddListener(LightVibration);
        mediumVibrationButton.onClick.AddListener(MediumVibration);
        heavyVibrationButton.onClick.AddListener(HeavyVibration);
    }
    private void OnDisable()
    {
        defaultVibrationButton.onClick.RemoveListener(DefaultVibration);
        lightVibrationButton.onClick.RemoveListener(LightVibration);
        mediumVibrationButton.onClick.RemoveListener(MediumVibration);
        heavyVibrationButton.onClick.RemoveListener(HeavyVibration);
    }
    private void DefaultVibration()
    {
        // Debug.Log("Default Vibration");
        Handheld.Vibrate();
    }
    private void LightVibration()
    {
        Debug.Log("Light Vibration");
        HapticFeedback.LightFeedback();
    }
    private void MediumVibration()
    {
        Debug.Log("Medium Vibration");
        HapticFeedback.MediumFeedback();
    }
    private void HeavyVibration()
    {
        Debug.Log("Heavy Vibration");
        HapticFeedback.HeavyFeedback();
    }
}
