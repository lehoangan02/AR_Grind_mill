using UnityEngine;

public class CapsuleFollowCamera : MonoBehaviour
{
    private Transform m_Capsule;
    [SerializeField]
    private Transform m_Camera;
    void Start()
    {
        m_Capsule = this.transform;
    }

    void Update()
    {
        // get the camera position
        Vector3 cameraPosition = m_Camera.position;
        Vector3 cameraForward = m_Camera.forward;
        // set the capsule position to the camera position
        // a small distance behind the camera
        // a small distance below the camera
        m_Capsule.position = cameraPosition + cameraForward * -0.5f + Vector3.up * -0.3f;
        // set the capsule rotation to the camera rotation
        m_Capsule.rotation = m_Camera.rotation;
    }
}
