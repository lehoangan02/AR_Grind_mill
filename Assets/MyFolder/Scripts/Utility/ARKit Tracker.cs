using UnityEngine;

public class ARKitTracker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform cameraTransform = Camera.main.transform;
        Quaternion deviceRotation = Camera.main.transform.rotation;
        Debug.Log("Device Position: " + cameraTransform + " Device Rotation: " + deviceRotation);
    }
}
