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
    [Tooltip("Optional: Assign an empty GameObject located on the buffalo's back.")]
    public Transform ridePoint; 
    
    [Header("Input References")]
    [Tooltip("Input Action for the Left Controller Trigger (e.g., XRI LeftHand/Select)")]
    public InputActionReference leftTriggerAction;
    [Tooltip("Input Action for the Right Controller Trigger (e.g., XRI RightHand/Select)")]
    public InputActionReference rightTriggerAction;
    [Tooltip("Input Action for movement (e.g., XRI LeftHand/Move)")]
    public InputActionReference moveAction;

    private XRSimpleInteractable interactable;
    private bool isRiding = false;
    private GameObject playerRig;
    private Transform originalPlayerParent;

    void Awake()
    {
        // 1. Auto-configure InteractableObject so the user doesn't have to manually set it up
        InteractableObject io = GetComponent<InteractableObject>();
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
                    // Remove small box trigger if added previously
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
    }

    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();

        // 2. Try to find the XR Origin (Player)
        var origin = FindObjectOfType<Unity.XR.CoreUtils.XROrigin>();
        if (origin != null)
        {
            playerRig = origin.gameObject;
        }
        else
        {
            // Fallback for older Unity XR or different setups
            Camera mainCam = Camera.main;
            if (mainCam != null && mainCam.transform.parent != null)
            {
                playerRig = mainCam.transform.parent.gameObject;
            }
        }
    }

    void Update()
    {
        if (isRiding)
        {
            HandleRidingMovement();
            
            // Dismount if both triggers are pressed again
            if (CheckBothTriggersPressed())
            {
                // Ensure we only dismount if the buttons were just pressed to avoid instant remount
                if (leftTriggerAction.action.WasPressedThisFrame() && rightTriggerAction.action.WasPressedThisFrame())
                {
                    Dismount();
                }
            }
        }
        else
        {
            // 3. Mount if BOTH hands are hovering and BOTH triggers are pressed
            bool isHovered = interactable.interactorsHovering.Count > 0;
            if (isHovered && interactable.interactorsHovering.Count >= 2)
            {
                if (CheckBothTriggersPressed())
                {
                    Mount();
                }
            }
        }
    }

    private bool CheckBothTriggersPressed()
    {
        if (leftTriggerAction == null || rightTriggerAction == null) return false;
        return leftTriggerAction.action.IsPressed() && rightTriggerAction.action.IsPressed();
    }

    private void Mount()
    {
        if (playerRig == null) return;
        
        isRiding = true;
        originalPlayerParent = playerRig.transform.parent;
        
        // Parent the player to the buffalo (or ride point)
        playerRig.transform.SetParent(ridePoint != null ? ridePoint : transform);
        playerRig.transform.localPosition = Vector3.zero;
        
        // Optionally match rotation
        playerRig.transform.localRotation = Quaternion.identity;
    }

    private void Dismount()
    {
        isRiding = false;
        if (playerRig != null)
        {
            // Unparent and move slightly to the side to avoid dismounting inside the buffalo
            playerRig.transform.SetParent(originalPlayerParent);
            playerRig.transform.position = transform.position + transform.right * 2f; 
        }
    }

    private void HandleRidingMovement()
    {
        if (moveAction == null) return;
        
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
        
        // Move forward/back
        transform.Translate(Vector3.forward * moveInput.y * moveSpeed * Time.deltaTime);
        
        // Turn left/right
        transform.Rotate(Vector3.up * moveInput.x * turnSpeed * Time.deltaTime);
    }
}
