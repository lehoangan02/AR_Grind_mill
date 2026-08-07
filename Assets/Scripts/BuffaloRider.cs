using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

[RequireComponent(typeof(XRSimpleInteractable))]
public class BuffaloRider : MonoBehaviour
{
    [Header("Riding Settings")]
    [Tooltip("Movement speed of the buffalo.")]
    public float moveSpeed = 3f;
    [Tooltip("Turning speed of the buffalo.")]
    public float turnSpeed = 60f;
    [Tooltip("Optional: Assign an empty GameObject located on the plough or behind the buffalo.")]
    public Transform ridePoint; 
    
    [Header("Input References")]
    [Tooltip("Input Action for the Left Controller Trigger (e.g., XRI LeftHand/Select)")]
    public InputActionReference leftTriggerAction;
    [Tooltip("Input Action for the Right Controller Trigger (e.g., XRI RightHand/Select)")]
    public InputActionReference rightTriggerAction;
    [Tooltip("Input Action for movement (e.g., XRI LeftHand/Move)")]
    public InputActionReference moveAction;

    private XRSimpleInteractable interactable;
    private InteractableObject io;
    private bool isRiding = false;
    private GameObject playerRig;
    private Transform originalPlayerParent;

    private InputAction fallbackMoveAction;
    private InputAction internalRightTriggerAction;
    private bool prevRightTriggerState = false;

    void Awake()
    {
        // 1. Auto-configure InteractableObject so the user doesn't have to manually set it up
        io = GetComponent<InteractableObject>();
        if (io == null)
        {
            io = gameObject.AddComponent<InteractableObject>();
        }
        io.ItemName = "Water Buffalo";

        // 2. Ensure there is a trigger sphere collider with a large radius (matching Basket/GrindMill)
        // so InteractableObject detects player in range when pointing at the buffalo from a distance
        Collider[] colliders = GetComponents<Collider>();
        SphereCollider triggerSphere = null;
        foreach (var col in colliders)
        {
            if (col.isTrigger)
            {
                if (col is SphereCollider sphere)
                {
                    triggerSphere = sphere;
                }
                else
                {
                    Destroy(col);
                }
            }
        }

        if (triggerSphere == null)
        {
            triggerSphere = gameObject.AddComponent<SphereCollider>();
            triggerSphere.isTrigger = true;
        }
        triggerSphere.radius = 15f;
        triggerSphere.center = Vector3.zero;

        // 3. Fallback input actions for right trigger click and left thumbstick/keyboard movement
        internalRightTriggerAction = new InputAction(type: InputActionType.Button, binding: "<XRController>{RightHand}/trigger");
        internalRightTriggerAction.AddBinding("<Mouse>/leftButton");
        internalRightTriggerAction.Enable();

        fallbackMoveAction = new InputAction(type: InputActionType.Value);
        fallbackMoveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d")
            .With("Up", "<Keyboard>/upArrow")
            .With("Down", "<Keyboard>/downArrow")
            .With("Left", "<Keyboard>/leftArrow")
            .With("Right", "<Keyboard>/rightArrow");
        fallbackMoveAction.AddBinding("<XRController>{LeftHand}/primary2DAxis");
        fallbackMoveAction.Enable();
    }

    void OnDestroy()
    {
        if (internalRightTriggerAction != null)
        {
            internalRightTriggerAction.Disable();
            internalRightTriggerAction.Dispose();
        }
        if (fallbackMoveAction != null)
        {
            fallbackMoveAction.Disable();
            fallbackMoveAction.Dispose();
        }
    }

    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();

        // Try to find the XR Origin (Player)
        var origin = FindObjectOfType<Unity.XR.CoreUtils.XROrigin>();
        if (origin != null)
        {
            playerRig = origin.gameObject;
        }
        else
        {
            Camera mainCam = Camera.main;
            if (mainCam != null && mainCam.transform.parent != null)
            {
                playerRig = mainCam.transform.parent.gameObject;
            }
            else if (mainCam != null)
            {
                playerRig = mainCam.gameObject;
            }
        }
    }

    void Update()
    {
        bool rightTriggerClicked = IsRightTriggerJustPressed();

        if (isRiding)
        {
            HandleRidingMovement();
            
            // Clicking Right Trigger again dismounts
            if (rightTriggerClicked)
            {
                Dismount();
            }
        }
        else
        {
            // Point at buffalo with right controller raycast and click right trigger to ride
            bool isPointedAtBuffalo = false;

            if (SelectionController.instance != null && SelectionController.instance.IsPlayerPointedAtObject())
            {
                InteractableObject currentObj = SelectionController.instance.GetCurrentPointedInteractableObject();
                if (currentObj != null && (currentObj == io || currentObj.gameObject == gameObject))
                {
                    isPointedAtBuffalo = true;
                }
            }

            if (interactable != null && interactable.isHovered)
            {
                isPointedAtBuffalo = true;
            }

            if (isPointedAtBuffalo && rightTriggerClicked)
            {
                Mount();
            }
        }
    }

    private bool IsRightTriggerJustPressed()
    {
        bool isPressedNow = false;

        if (VRController.instance != null)
        {
            isPressedNow = isPressedNow || VRController.instance.IsRightTriggerPressed();
        }

        if (rightTriggerAction != null && rightTriggerAction.action != null)
        {
            isPressedNow = isPressedNow || rightTriggerAction.action.IsPressed();
        }

        if (internalRightTriggerAction != null)
        {
            isPressedNow = isPressedNow || internalRightTriggerAction.IsPressed();
        }

        bool justPressed = isPressedNow && !prevRightTriggerState;
        prevRightTriggerState = isPressedNow;

        return justPressed;
    }

    private void Mount()
    {
        if (playerRig == null) return;
        
        isRiding = true;
        originalPlayerParent = playerRig.transform.parent;
        
        // Find ride point or plough transform
        Transform targetRideTransform = ridePoint;
        if (targetRideTransform == null)
        {
            Transform ploughChild = transform.Find("plough");
            if (ploughChild == null) ploughChild = transform.Find("Plough");
            if (ploughChild == null) ploughChild = transform.Find("ridePoint");
            if (ploughChild == null) ploughChild = transform.Find("RidePoint");

            if (ploughChild != null)
            {
                targetRideTransform = ploughChild;
            }
        }

        if (targetRideTransform != null)
        {
            playerRig.transform.SetParent(targetRideTransform);
            // Position slightly behind the plough handles facing forward
            playerRig.transform.localPosition = new Vector3(0f, 0.1f, -0.3f);
            playerRig.transform.localRotation = Quaternion.identity;
        }
        else
        {
            // Default ploughing position: Standing behind the buffalo at plough position (-2.0m on Z)
            playerRig.transform.SetParent(transform);
            playerRig.transform.localPosition = new Vector3(0f, 0.2f, -2.0f);
            playerRig.transform.localRotation = Quaternion.identity;
        }
    }

    private void Dismount()
    {
        isRiding = false;
        if (playerRig != null)
        {
            playerRig.transform.SetParent(originalPlayerParent);
            playerRig.transform.position = transform.position + transform.right * 2f; 
        }
    }

    private void HandleRidingMovement()
    {
        Vector2 moveInput = Vector2.zero;

        if (moveAction != null && moveAction.action != null)
        {
            moveInput = moveAction.action.ReadValue<Vector2>();
        }

        if (moveInput == Vector2.zero && fallbackMoveAction != null)
        {
            moveInput = fallbackMoveAction.ReadValue<Vector2>();
        }

        if (moveInput != Vector2.zero)
        {
            // Move forward/back
            transform.Translate(Vector3.forward * moveInput.y * moveSpeed * Time.deltaTime);
            
            // Turn left/right
            transform.Rotate(Vector3.up * moveInput.x * turnSpeed * Time.deltaTime);
        }
    }
}
