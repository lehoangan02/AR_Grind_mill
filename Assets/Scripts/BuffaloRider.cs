using Khoa.Farming.Mounting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[DisallowMultipleComponent]
[RequireComponent(typeof(XRSimpleInteractable))]
public class BuffaloRider : MonoBehaviour
{
    [Header("Riding Settings")]
    [Min(0f)] public float moveSpeed = 3f;
    [Min(0f)] public float turnSpeed = 60f;
    [Tooltip("Head position while riding. A safe default is created when omitted.")]
    public Transform ridePoint;
    public Transform dismountPoint;
    [Min(0.5f)] public float maxMountDistance = 2.5f;

    [Header("Input References")]
    [Tooltip("Right trigger used by the project's pointer interaction path.")]
    public InputActionReference rightTriggerAction;
    [Tooltip("Left locomotion Move action. It controls the buffalo while mounted.")]
    public InputActionReference moveAction;

    [Header("State (Read-Only)")]
    [SerializeField] private bool isRiding;
    [SerializeField] private GameObject playerRig;

    public bool IsRiding => isRiding;

    private XRSimpleInteractable interactable;
    private InteractableObject description;
    private XRPlayerMountState mountState;
    private Khoa.Farming.BuffaloPlowAttachment[] plowAttachments;
    private bool previousRightTriggerState;

    private void Awake()
    {
        description = GetComponent<InteractableObject>();
        if (description == null) description = gameObject.AddComponent<InteractableObject>();
        description.ItemName = "Trâu cày - bấm Select/Trigger để cưỡi hoặc xuống";

        interactable = GetComponent<XRSimpleInteractable>();
        EnsureInteractionCollider();
        EnsureMountPoints();
        plowAttachments = GetComponentsInChildren<Khoa.Farming.BuffaloPlowAttachment>(true);
        SetPlowing(false);
    }

    private void OnEnable()
    {
        if (interactable == null) interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnSelected);
    }

    private void OnDisable()
    {
        if (interactable != null) interactable.selectEntered.RemoveListener(OnSelected);
        if (isRiding) Dismount();
    }

    private void Update()
    {
        if (Application.isEditor && Keyboard.current != null && Keyboard.current.fKey.wasPressedThisFrame)
        {
            if (isRiding) Dismount();
            else Mount(XRMountCoordinator.ResolveRig());
        }

        if (WasRightTriggerPressedThisFrame())
        {
            if (isRiding) Dismount();
            else if (IsPointerAimingAtBuffalo()) Mount(XRMountCoordinator.ResolveRig());
        }

        if (isRiding) HandleRidingMovement();
    }

    private void OnSelected(SelectEnterEventArgs args)
    {
        if (isRiding)
        {
            Dismount();
            return;
        }
        GameObject rig = XRMountCoordinator.ResolveRig(args.interactorObject != null ? args.interactorObject.transform : null);
        Mount(rig);
    }

    public bool Mount(GameObject rig)
    {
        if (isRiding || rig == null) return false;
        Camera head = rig.GetComponentInChildren<Camera>(true);
        Vector3 playerPosition = head != null ? head.transform.position : rig.transform.position;
        if (DistanceFromBuffalo(playerPosition) > maxMountDistance) return false;
        if (!XRMountCoordinator.TryAcquire(rig, this)) return false;

        playerRig = rig;
        mountState = new XRPlayerMountState(rig);
        mountState.Attach(ridePoint);
        isRiding = true;
        SetPlowing(true);
        return true;
    }

    public bool Dismount()
    {
        if (!isRiding || playerRig == null) return false;
        Vector3 landing = dismountPoint != null
            ? dismountPoint.position
            : transform.position + transform.right * 1.6f + Vector3.up * 0.1f;
        mountState?.Detach(landing, transform.rotation);
        XRMountCoordinator.Release(playerRig, this);
        mountState = null;
        playerRig = null;
        isRiding = false;
        SetPlowing(false);
        return true;
    }

    private void HandleRidingMovement()
    {
        Vector2 input = moveAction != null && moveAction.action != null
            ? moveAction.action.ReadValue<Vector2>()
            : Vector2.zero;
        if (Application.isEditor && Keyboard.current != null)
        {
            float x = (Keyboard.current.dKey.isPressed ? 1f : 0f) - (Keyboard.current.aKey.isPressed ? 1f : 0f);
            float y = (Keyboard.current.wKey.isPressed ? 1f : 0f) - (Keyboard.current.sKey.isPressed ? 1f : 0f);
            Vector2 keyboardInput = new Vector2(x, y);
            if (keyboardInput.sqrMagnitude > input.sqrMagnitude) input = keyboardInput;
        }
        input = Vector2.ClampMagnitude(input, 1f);
        transform.Rotate(0f, input.x * turnSpeed * Time.deltaTime, 0f, Space.World);
        transform.position += transform.forward * (input.y * moveSpeed * Time.deltaTime);
    }

    private bool WasRightTriggerPressedThisFrame()
    {
        bool pressed = VRController.instance != null && VRController.instance.IsRightTriggerPressed();
        if (rightTriggerAction != null && rightTriggerAction.action != null)
            pressed |= rightTriggerAction.action.IsPressed();
        bool down = pressed && !previousRightTriggerState;
        previousRightTriggerState = pressed;
        return down;
    }

    private bool IsPointerAimingAtBuffalo()
    {
        if (interactable != null && interactable.isHovered) return true;
        if (SelectionController.instance == null || !SelectionController.instance.IsPlayerPointedAtObject()) return false;
        InteractableObject pointed = SelectionController.instance.GetCurrentPointedInteractableObject();
        return pointed != null && (pointed == description || pointed.gameObject == gameObject);
    }

    private float DistanceFromBuffalo(Vector3 position)
    {
        float closest = Vector3.Distance(position, transform.position);
        foreach (Collider collider in GetComponentsInChildren<Collider>(true))
        {
            if (collider == null || collider.isTrigger) continue;
            closest = Mathf.Min(closest, Vector3.Distance(position, collider.ClosestPoint(position)));
        }
        return closest;
    }

    private void EnsureMountPoints()
    {
        if (ridePoint == null)
        {
            Transform existing = transform.Find("Khoa_RidePoint");
            if (existing == null)
            {
                existing = new GameObject("Khoa_RidePoint").transform;
                existing.SetParent(transform, false);
                existing.localPosition = new Vector3(0f, 1.55f, -0.1f);
            }
            ridePoint = existing;
        }
        if (dismountPoint == null)
        {
            Transform existing = transform.Find("Khoa_DismountPoint");
            if (existing == null)
            {
                existing = new GameObject("Khoa_DismountPoint").transform;
                existing.SetParent(transform, false);
                existing.localPosition = new Vector3(1.6f, 0.1f, 0f);
            }
            dismountPoint = existing;
        }
    }

    private void EnsureInteractionCollider()
    {
        foreach (Collider collider in GetComponentsInChildren<Collider>(true))
            if (collider != null && !collider.isTrigger) return;

        CapsuleCollider capsule = gameObject.AddComponent<CapsuleCollider>();
        capsule.isTrigger = false;
        capsule.center = new Vector3(0f, 0.9f, 0f);
        capsule.radius = 0.55f;
        capsule.height = 1.8f;
    }

    private void SetPlowing(bool active)
    {
        if (plowAttachments == null) return;
        foreach (Khoa.Farming.BuffaloPlowAttachment plow in plowAttachments)
            if (plow != null) plow.isPlowingActive = active;
    }
}
