using System.IO.Compression;
using Unity.XR.CoreUtils;
using UnityEngine;
using CandyCoded.HapticFeedback;
using UnityEngine.InputSystem;
public class HandlebarInput_v3 : MonoBehaviour
{
    public GameObject handlebar;
    private Rigidbody rb;
    private XROrigin m_XROrigin;
    private Vector3 previousPosition;
    private Vector3 currentPosition;
    private int onEnableFrame = -1;

    void Start()
    {
        // apply constraints to handlebar
        rb = handlebar.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody not found on handlebar");
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
        }
        // get initial position of player
        m_XROrigin = FindFirstObjectByType<XROrigin>();
        previousPosition = m_XROrigin.Camera.transform.position;
    }
    void Update()
    {
        Vector3 cameraForward = m_XROrigin.Camera.transform.forward;
        Vector3 cameraRight = m_XROrigin.Camera.transform.right;
        if (Keyboard.current.upArrowKey.isPressed)
        {
            rb.AddForce(cameraForward * 0.7f, ForceMode.Impulse);
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            rb.AddForce(cameraForward * -0.7f, ForceMode.Impulse);
        }


        // get input force from right controller
        const float forceRate = 50.0f;
        currentPosition = VRController.instance.GetRightControllerTransform().position;
        float Z_movement = currentPosition.z - previousPosition.z;
        float X_movement = currentPosition.x - previousPosition.x;
        previousPosition = currentPosition;

        if (onEnableFrame == Time.frameCount - 1)
        {
            // update the previous position to the current position after enabling
            // Debug.Log("HandlebarInput_v2 enabled and updated");
            return;
        }
        float ForceZ = Z_movement * forceRate;
        float ForceX = X_movement * forceRate;
        rb.AddForce(cameraForward * -ForceZ, ForceMode.Impulse);
        rb.AddForce(cameraRight * -ForceX, ForceMode.Impulse);
    }
    void OnEnable()
    {
        onEnableFrame = Time.frameCount;
    }
    void OnDisable()
    {
        onEnableFrame = -1;
    }
}
