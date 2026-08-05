using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Slider))]
public class UISlider : MonoBehaviour
{
    [SerializeField] private TMP_Text valueText;
    [SerializeField] private string valueFormat = "F0";

    private Slider slider;

    public Slider.SliderEvent onValueChanged => slider.onValueChanged;

    private void Awake()
    {
        slider = GetComponent<Slider>();

        UpdateValueText(slider.value);
        slider.onValueChanged.AddListener(UpdateValueText);
    }

    private void UpdateValueText(float value)
    {
        if (valueText != null)
            valueText.text = value.ToString(valueFormat);
    }
}