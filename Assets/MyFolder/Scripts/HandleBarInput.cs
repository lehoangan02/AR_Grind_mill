using System.IO.Compression;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

public class Handlebarinput : MonoBehaviour
{
    public GameObject handlebar;
    private Rigidbody rb;
    private XROrigin m_XROrigin;
    private Vector3 previousPosition;
    private Vector3 currentPosition;
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
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX;
        }
        // get initial position of player
        m_XROrigin = FindFirstObjectByType<XROrigin>();
        previousPosition = m_XROrigin.Camera.transform.position;
    }
    void Update()
    {
        // const float 
        if (Keyboard.current.upArrowKey.isPressed)
        {
            rb.AddForce(handlebar.transform.forward * -0.1f, ForceMode.Impulse);
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            rb.AddForce(handlebar.transform.forward * 0.1f, ForceMode.Impulse);
        }
        // get input force from player movement
        currentPosition = m_XROrigin.Camera.transform.position;
        float Z_movement = currentPosition.z - previousPosition.z;
        Debug.Log("Z movement: " + Z_movement);
        rb.AddForce(handlebar.transform.forward * Z_movement, ForceMode.Impulse);
    }
}
