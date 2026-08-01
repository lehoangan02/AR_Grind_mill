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
    private TextMeshPro floatingText;

    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();

        // 1. Create the "Water Buffalo" text dynamically so it appears like an item
        GameObject textObj = new GameObject("WaterBuffaloText");
        textObj.transform.SetParent(transform);
        textObj.transform.localPosition = new Vector3(0, 2.5f, 0); // Position slightly above the buffalo
        
        floatingText = textObj.AddComponent<TextMeshPro>();
        floatingText.text = "Water Buffalo";
        floatingText.fontSize = 5;
        floatingText.alignment = TextAlignmentOptions.Center;
        floatingText.gameObject.SetActive(false);

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
            // 3. Show text when hovered
            bool isHovered = interactable.interactorsHovering.Count > 0;
            
            if (isHovered)
            {
                floatingText.gameObject.SetActive(true);
                // Make text face the camera
                if (Camera.main != null)
                {
                    floatingText.transform.LookAt(Camera.main.transform);
                    floatingText.transform.Rotate(0, 180, 0);
                }

                // 4. Mount if BOTH hands are hovering and BOTH triggers are pressed
                if (interactable.interactorsHovering.Count >= 2)
                {
                    if (CheckBothTriggersPressed())
                    {
                        Mount();
                    }
                }
            }
            else
            {
                floatingText.gameObject.SetActive(false);
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
        floatingText.gameObject.SetActive(false);
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
