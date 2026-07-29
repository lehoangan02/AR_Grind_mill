using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class UISlider : MonoBehaviour
{
    [SerializeField] private TMP_Text label;
    [SerializeField] private TMP_Text valueText;
    [SerializeField] private string valueFormat = "F0";

    public UnityEvent<float> onValueChanged = new UnityEvent<float>();

    private void Awake()
    {
        Slider slider = GetComponent<Slider>();
        if (slider != null)
        {
            slider.onValueChanged.AddListener(HandleValueChanged);
        }
    }

    private void HandleValueChanged(float value)
    {
        if (valueText != null)
        {
            valueText.text = value.ToString(valueFormat);
        }
        onValueChanged.Invoke(value);
    }
}
