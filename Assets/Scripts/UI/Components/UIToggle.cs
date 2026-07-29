using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class UIToggle : MonoBehaviour
{
    [SerializeField] TMP_Text label;

    public UnityEvent<bool> onValueChanged = new UnityEvent<bool>();

    void Awake()
    {
        var toggle = GetComponent<Toggle>();
        if (toggle != null)
        {
            toggle.onValueChanged.AddListener(HandleValueChanged);
        }
    }

    void HandleValueChanged(bool isOn)
    {
        if (label != null)
        {
            label.color = isOn ? Color.white : new Color(0.5f, 0.5f, 0.5f, 1f);
        }

        onValueChanged.Invoke(isOn);
    }
}
