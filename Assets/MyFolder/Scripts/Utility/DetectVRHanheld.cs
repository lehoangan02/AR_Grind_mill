using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DetectVRHanheld : MonoBehaviour
{
    // [SerializeField]
    // private TextMeshProUGUI textMeshProUGUI;

    private InputAction rightTriggerAction;

    void OnEnable()
    {
        rightTriggerAction = new InputAction(type: InputActionType.Value, binding: "<XRController>{RightHand}/trigger");
        rightTriggerAction.Enable();
    }

    void OnDisable()
    {
        rightTriggerAction.Disable();
    }

    void Update()
    {
        float triggerValue = rightTriggerAction.ReadValue<float>();
        bool isPressed = triggerValue > 0.1f;
        // textMeshProUGUI.text = isPressed ? "Trigger Pressed" : "Trigger Released";
    }
}
