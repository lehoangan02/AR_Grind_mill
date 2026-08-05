using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle), typeof(Animator))]
public class UIToggle : MonoBehaviour
{
    private Toggle toggle;
    private Animator animator;
    
    public Toggle.ToggleEvent onValueChanged => toggle.onValueChanged;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        animator = GetComponent<Animator>();

        animator.SetBool("IsOn", toggle.isOn);
        toggle.onValueChanged.AddListener(value => animator.SetBool("IsOn", value));
    }
}
