using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRController : MonoBehaviour
{
    public static VRController instance { get; private set; }
    public GameObject UI;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        
        if (inputSystemReference != null && inputSystemReference.action != null)
        {
            inputSystemReference.action.Enable();
            inputSystemReference.action.performed += Toggle;
        }
        InputSystem.onDeviceChange += OnDeviceChange;

        // Initialize InputActions here instead of Start to prevent NullReferenceExceptions
        // if other scripts call these methods before this script's Start() runs.
        rightTriggerAction = new InputAction(type: InputActionType.Value, binding: "<XRController>{RightHand}/trigger");
        rightTriggerAction.Enable();
        leftTriggerAction = new InputAction(type: InputActionType.Value, binding: "<XRController>{LeftHand}/trigger");
        leftTriggerAction.Enable();
        rightGripAction = new InputAction(type: InputActionType.Value, binding: "<XRController>{RightHand}/grip");
        rightGripAction.Enable();
        leftGripAction = new InputAction(type: InputActionType.Value, binding: "<XRController>{LeftHand}/grip");
        leftGripAction.Enable();
        rightActions = new InputAction(type: InputActionType.Button, binding: "<XRController>{LeftHand}/PrimaryAction");
        rightActions.Enable();
        rightBctions = new InputAction(type: InputActionType.Button, binding: "<XRController>{RightHand}/buttonNorth");
        rightBctions.Enable();
    }
    void OnDestroy()
    {
        if (inputSystemReference != null && inputSystemReference.action != null)
        {
            inputSystemReference.action.Disable();
            inputSystemReference.action.performed -= Toggle;
        }
        InputSystem.onDeviceChange -= OnDeviceChange;
    }
    private InputAction rightTriggerAction;
    private InputAction leftTriggerAction;
    private InputAction rightGripAction;
    private InputAction leftGripAction;
    private InputAction rightActions;
    private InputAction rightBctions;
    [SerializeField]
    private Transform rightControllerTransform;
    public InputActionReference inputSystemReference;
    void Start()
    {
    }
    void Update()
    {
        IsRightButtonAPressed();

    }
    public bool IsRightTriggerPressed()
    {
        float therreshold = 0.1f;
        float triggerValue = rightTriggerAction.ReadValue<float>();
        bool isPressed = triggerValue > therreshold;
        return isPressed;
    }
    public bool IsLeftTriggerPressed()
    {
        float therreshold = 0.1f;
        float triggerValue = leftTriggerAction.ReadValue<float>();
        bool isPressed = triggerValue > therreshold;
        return isPressed;
    }
    public bool IsRightGripPressed()
    {
        float therreshold = 0.1f;
        float gripValue = rightGripAction.ReadValue<float>();
        bool isPressed = gripValue > therreshold;
        if (isPressed)
        {
            Debug.Log($"Right Grip Pressed: {isPressed}");
        }
        return isPressed;
    }
    public bool IsLeftGripPressed()
    {
        float therreshold = 0.1f;
        float gripValue = leftGripAction.ReadValue<float>();
        bool isPressed = gripValue > therreshold;
        return isPressed;
    }
    public Transform GetRightControllerTransform()
    {
        return rightControllerTransform;
    }
    public bool IsRightButtonAPressed()
    {

        bool res = rightActions.ReadValue<bool>();
        if (res)
        {
            Debug.Log($"Button A Pressed: {res}");
        }
        return res;
    }
    public bool IsRightButtonBPressed()
    {
        Debug.Log($"Button B Pressed: {rightBctions.ReadValue<float>()}");
        return rightBctions.ReadValue<bool>();
    }
    private void Toggle(InputAction.CallbackContext context)
    {
        if (UIManager.instance != null)
        {
            UIManager.instance.TogglePauseMenu();
            return;
        }
        if (UI != null)
        {
            UI.SetActive(!UI.activeSelf);
        }
    }
    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        switch (change)
        {
            case InputDeviceChange.Disconnected:
                inputSystemReference.action.Disable();
                break;
            case InputDeviceChange.Reconnected:
                inputSystemReference.action.Enable();
                break;
        }
    }

}
