using System;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class RecenterOrigin : MonoBehaviour
{
    public Transform m_Target;
    [SerializeField]
    private XROrigin m_Origin;
    [SerializeField]
    private ARSession m_Session;
    public const float Height = 0.3f;
    void Start()
    {
        
        recenterOrigin();
    }
    private void recenterOrigin()
    {
        if (m_Origin == null)
        {
            Debug.LogError("No XROrigin found on target object");
            return;
        }
        else
        {
            Vector3 HeadPosition = m_Target.position;
            HeadPosition.y = HeadPosition.y + Height;
            m_Origin.MoveCameraToWorldLocation(HeadPosition);
            m_Origin.MatchOriginUpCameraForward(m_Target.up, m_Target.forward);
            m_Session.transform.position = m_Target.position;
            
            m_Origin.transform.rotation = Quaternion.LookRotation(m_Target.forward, m_Target.up);
            m_Session.transform.rotation = Quaternion.identity;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
