using UnityEngine;
using UnityEngine.InputSystem;

public class MockKeyboardController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        // forward and backward movement
        Vector3 cameraForward = Camera.main.transform.forward;
        if (Keyboard.current.upArrowKey.isPressed)
        {
            this.transform.position += cameraForward * 0.7f * Time.deltaTime;
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            this.transform.position -= cameraForward * 0.7f * Time.deltaTime;
        }
        // rotate left and right
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            transform.Rotate(Vector3.up, -50 * Time.deltaTime, Space.World);        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            transform.Rotate(Vector3.up, 50 * Time.deltaTime, Space.World);
        }
        // move up and down
        if (Keyboard.current.eKey.isPressed)
        {
            transform.position += Vector3.up * 0.7f * Time.deltaTime;
        }
        if (Keyboard.current.qKey.isPressed)
        {
            transform.position -= Vector3.up * 0.7f * Time.deltaTime;
        }
        // rotate up and down
        Vector3 cameraRight = Camera.main.transform.right;
        Vector3 groundRight = new Vector3(cameraRight.x, 0, cameraRight.z).normalized;
        if (Keyboard.current.wKey.isPressed)
        {
            transform.Rotate(groundRight, -50 * Time.deltaTime, Space.World);
        }
        if (Keyboard.current.sKey.isPressed)
        {
            transform.Rotate(groundRight, 50 * Time.deltaTime, Space.World);
        }
    }
}
