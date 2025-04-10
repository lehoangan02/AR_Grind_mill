using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using System;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlacementIndicatorControlloer : MonoBehaviour
{
    private XROrigin m_XROrigin_AR_Mobile;
    private Pose m_PlacementPose;
    public GameObject PlacementIndicator;
    bool m_PlacementPoseIsValid = false;
    public GameObject m_PrebabToPlace;
    void Start()
    {
        EnhancedTouchSupport.Enable();
        m_XROrigin_AR_Mobile = FindFirstObjectByType<XROrigin>();
        if (m_XROrigin_AR_Mobile == null)
        {
            Debug.LogError("No XROrigin found in the scene");
            return;
        }
        
        var raycastManager = m_XROrigin_AR_Mobile.GetComponent<ARRaycastManager>();
        if (raycastManager == null)
        {
            Debug.LogError("ARRaycastManager is missing on XROrigin.");
        }
        else
        {
            Debug.Log("ARRaycastManager found successfully.");
        }
    }
    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();
        if (m_PlacementPoseIsValid && UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches.Count > 0 && UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches[0].phase == UnityEngine.InputSystem.TouchPhase.Began)
        {
            PlaceObject();
        }
    }

    private void PlaceObject()
    {
        Instantiate(m_PrebabToPlace, m_PlacementPose.position, m_PlacementPose.rotation);
        Debug.Log("Placed object at " + m_PlacementPose.position);
        Debug.Log("Current player position is " + m_XROrigin_AR_Mobile.transform.position);
    }

    private void UpdatePlacementIndicator()
    {
        if (m_PlacementPoseIsValid)
        {
            PlacementIndicator.SetActive(true);
            PlacementIndicator.transform.SetPositionAndRotation(m_PlacementPose.position, m_PlacementPose.rotation);
        }
        else
        {
            PlacementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        m_XROrigin_AR_Mobile.GetComponent<ARRaycastManager>().Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
        if (hits.Count > 0)
        {
            m_PlacementPose = hits[0].pose;
            m_PlacementPoseIsValid = true;
            var CameraForward = Camera.main.transform.forward;
            var CameraBearing = new Vector3(CameraForward.x, 0, CameraForward.z).normalized;
            m_PlacementPose.rotation = Quaternion.LookRotation(CameraBearing);
        }
        else
        {
            m_PlacementPoseIsValid = false;
        }
    }
}
