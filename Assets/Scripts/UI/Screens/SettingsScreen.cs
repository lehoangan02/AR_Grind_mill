using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsScreen : UIScreen
{
    [SerializeField] private UITabGroup tabGroup;

    // Audio tab
    [SerializeField] private UISlider masterVolumeSlider;
    [SerializeField] private UISlider sfxVolumeSlider;
    [SerializeField] private UISlider musicVolumeSlider;

    // Graphics tab
    [SerializeField] private UISlider brightnessSlider;
    [SerializeField] private UIToggle vsyncToggle;
    [SerializeField] private TMP_Dropdown qualityDropdown;

    // Controls tab
    [SerializeField] private UISlider lookSensitivitySlider;
    [SerializeField] private UIToggle smoothTurnToggle;
    [SerializeField] private UISlider turnSpeedSlider;

    // Accessibility tab
    [SerializeField] private UIToggle subtitlesToggle;
    [SerializeField] private UISlider textSizeSlider;

    private UISettingsData currentSettings;

    public override void OnOpen(UIScreenData data = null)
    {
        base.OnOpen(data);

        currentSettings = UISettingsData.Load();
        Debug.Log($"[SettingsScreen] Loaded settings");

        ApplySettingsToControls();

        if (tabGroup != null)
        {
            tabGroup.SelectTab(0);
        }
    }

    public override void OnClose()
    {
        CollectSettingsFromControls();
        UISettingsData.Save(currentSettings);
        Debug.Log($"[SettingsScreen] Saved settings");

        base.OnClose();
    }

    private void Start()
    {
        SetupQualityDropdown();
        WireControls();
    }

    private void SetupQualityDropdown()
    {
        if (qualityDropdown == null)
            return;

        qualityDropdown.ClearOptions();
        qualityDropdown.AddOptions(new System.Collections.Generic.List<string>
        {
            "Low",
            "Medium",
            "High",
            "Ultra"
        });
    }

    private void WireControls()
    {
        // Audio tab
        if (masterVolumeSlider != null)
            masterVolumeSlider.onValueChanged.AddListener(v => currentSettings.masterVolume = v);

        if (sfxVolumeSlider != null)
            sfxVolumeSlider.onValueChanged.AddListener(v => currentSettings.sfxVolume = v);

        if (musicVolumeSlider != null)
            musicVolumeSlider.onValueChanged.AddListener(v => currentSettings.musicVolume = v);

        // Graphics tab
        if (brightnessSlider != null)
            brightnessSlider.onValueChanged.AddListener(v => currentSettings.brightness = v);

        if (vsyncToggle != null)
            vsyncToggle.onValueChanged.AddListener(v => currentSettings.vsync = v);

        if (qualityDropdown != null)
            qualityDropdown.onValueChanged.AddListener(v => currentSettings.qualityLevel = v);

        // Controls tab
        if (lookSensitivitySlider != null)
            lookSensitivitySlider.onValueChanged.AddListener(v => currentSettings.lookSensitivity = v);

        if (smoothTurnToggle != null)
            smoothTurnToggle.onValueChanged.AddListener(v => currentSettings.smoothTurn = v);

        if (turnSpeedSlider != null)
            turnSpeedSlider.onValueChanged.AddListener(v => currentSettings.turnSpeed = v);

        // Accessibility tab
        if (subtitlesToggle != null)
            subtitlesToggle.onValueChanged.AddListener(v => currentSettings.subtitles = v);

        if (textSizeSlider != null)
            textSizeSlider.onValueChanged.AddListener(v => currentSettings.textSize = v);
    }

    private void ApplySettingsToControls()
    {
        // Audio tab
        if (masterVolumeSlider != null)
            SetSliderValue(masterVolumeSlider, currentSettings.masterVolume);

        if (sfxVolumeSlider != null)
            SetSliderValue(sfxVolumeSlider, currentSettings.sfxVolume);

        if (musicVolumeSlider != null)
            SetSliderValue(musicVolumeSlider, currentSettings.musicVolume);

        // Graphics tab
        if (brightnessSlider != null)
            SetSliderValue(brightnessSlider, currentSettings.brightness);

        if (vsyncToggle != null)
            SetToggleValue(vsyncToggle, currentSettings.vsync);

        if (qualityDropdown != null)
            qualityDropdown.value = currentSettings.qualityLevel;

        // Controls tab
        if (lookSensitivitySlider != null)
            SetSliderValue(lookSensitivitySlider, currentSettings.lookSensitivity);

        if (smoothTurnToggle != null)
            SetToggleValue(smoothTurnToggle, currentSettings.smoothTurn);

        if (turnSpeedSlider != null)
            SetSliderValue(turnSpeedSlider, currentSettings.turnSpeed);

        // Accessibility tab
        if (subtitlesToggle != null)
            SetToggleValue(subtitlesToggle, currentSettings.subtitles);

        if (textSizeSlider != null)
            SetSliderValue(textSizeSlider, currentSettings.textSize);
    }

    private void CollectSettingsFromControls()
    {
        // Values are already in currentSettings via onValueChanged lambdas,
        // but also collect directly from controls in case a control is set
        // before its value-changed listener fires (e.g., ApplySettingsToControls).

        // Audio tab
        if (masterVolumeSlider != null)
            currentSettings.masterVolume = GetSliderValue(masterVolumeSlider);

        if (sfxVolumeSlider != null)
            currentSettings.sfxVolume = GetSliderValue(sfxVolumeSlider);

        if (musicVolumeSlider != null)
            currentSettings.musicVolume = GetSliderValue(musicVolumeSlider);

        // Graphics tab
        if (brightnessSlider != null)
            currentSettings.brightness = GetSliderValue(brightnessSlider);

        if (vsyncToggle != null)
            currentSettings.vsync = GetToggleValue(vsyncToggle);

        if (qualityDropdown != null)
            currentSettings.qualityLevel = qualityDropdown.value;

        // Controls tab
        if (lookSensitivitySlider != null)
            currentSettings.lookSensitivity = GetSliderValue(lookSensitivitySlider);

        if (smoothTurnToggle != null)
            currentSettings.smoothTurn = GetToggleValue(smoothTurnToggle);

        if (turnSpeedSlider != null)
            currentSettings.turnSpeed = GetSliderValue(turnSpeedSlider);

        // Accessibility tab
        if (subtitlesToggle != null)
            currentSettings.subtitles = GetToggleValue(subtitlesToggle);

        if (textSizeSlider != null)
            currentSettings.textSize = GetSliderValue(textSizeSlider);
    }

    private static void SetSliderValue(UISlider uiSlider, float value)
    {
        Slider slider = uiSlider.GetComponent<Slider>();
        if (slider != null)
        {
            slider.SetValueWithoutNotify(value);
        }
    }

    private static float GetSliderValue(UISlider uiSlider)
    {
        Slider slider = uiSlider.GetComponent<Slider>();
        if (slider != null)
        {
            return slider.value;
        }

        return 0f;
    }

    private static void SetToggleValue(UIToggle uiToggle, bool value)
    {
        Toggle toggle = uiToggle.GetComponent<Toggle>();
        if (toggle != null)
        {
            toggle.SetIsOnWithoutNotify(value);
        }
    }

    private static bool GetToggleValue(UIToggle uiToggle)
    {
        Toggle toggle = uiToggle.GetComponent<Toggle>();
        if (toggle != null)
        {
            return toggle.isOn;
        }

        return false;
    }
}
