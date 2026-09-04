using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Locomotion;
using Unity.XR.CoreUtils;

namespace Khoa.Farming.Mounting
{
    /// <summary>Ensures one XR rig can only be controlled by one mount at a time.</summary>
    public static class XRMountCoordinator
    {
        private static readonly Dictionary<GameObject, Object> Owners = new Dictionary<GameObject, Object>();

        public static bool TryAcquire(GameObject rig, Object owner)
        {
            if (rig == null || owner == null) return false;
            if (Owners.TryGetValue(rig, out Object current) && current != null && current != owner) return false;
            Owners[rig] = owner;
            return true;
        }

        public static void Release(GameObject rig, Object owner)
        {
            if (rig != null && Owners.TryGetValue(rig, out Object current) && (current == null || current == owner))
                Owners.Remove(rig);
        }

        public static GameObject ResolveRig(Transform interactionSource = null)
        {
            XROrigin origin = interactionSource != null ? interactionSource.GetComponentInParent<XROrigin>() : null;
            if (origin == null) origin = Object.FindFirstObjectByType<XROrigin>();
            return origin != null ? origin.gameObject : null;
        }
    }

    /// <summary>Caches and restores the XR rig state without losing tracked-head offset.</summary>
    public sealed class XRPlayerMountState
    {
        private readonly GameObject rig;
        private readonly Transform originalParent;
        private readonly Behaviour[] locomotionProviders;
        private readonly bool[] locomotionEnabled;

        public XRPlayerMountState(GameObject playerRig)
        {
            rig = playerRig;
            originalParent = rig.transform.parent;
            LocomotionProvider[] providers = rig.GetComponentsInChildren<LocomotionProvider>(true);
            locomotionProviders = new Behaviour[providers.Length];
            locomotionEnabled = new bool[providers.Length];
            for (int i = 0; i < providers.Length; i++)
            {
                locomotionProviders[i] = providers[i];
                locomotionEnabled[i] = providers[i].enabled;
                providers[i].enabled = false;
            }
        }

        public void Attach(Transform headTarget)
        {
            if (rig == null || headTarget == null) return;
            Camera camera = rig.GetComponentInChildren<Camera>(true);
            if (camera != null)
            {
                Vector3 cameraForward = Vector3.ProjectOnPlane(camera.transform.forward, Vector3.up);
                Vector3 targetForward = Vector3.ProjectOnPlane(headTarget.forward, Vector3.up);
                if (cameraForward.sqrMagnitude > 0.001f && targetForward.sqrMagnitude > 0.001f)
                {
                    float yaw = Vector3.SignedAngle(cameraForward, targetForward, Vector3.up);
                    rig.transform.RotateAround(camera.transform.position, Vector3.up, yaw);
                }
                rig.transform.position += headTarget.position - camera.transform.position;
            }
            else
            {
                rig.transform.SetPositionAndRotation(headTarget.position, Quaternion.Euler(0f, headTarget.eulerAngles.y, 0f));
            }
            rig.transform.SetParent(headTarget, true);
        }

        public void Detach(Vector3 landingPosition, Quaternion landingRotation)
        {
            if (rig == null) return;
            rig.transform.SetParent(originalParent, true);
            Camera camera = rig.GetComponentInChildren<Camera>(true);
            if (camera != null)
            {
                Vector3 cameraForward = Vector3.ProjectOnPlane(camera.transform.forward, Vector3.up);
                Vector3 targetForward = landingRotation * Vector3.forward;
                targetForward = Vector3.ProjectOnPlane(targetForward, Vector3.up);
                if (cameraForward.sqrMagnitude > 0.001f && targetForward.sqrMagnitude > 0.001f)
                    rig.transform.RotateAround(camera.transform.position, Vector3.up,
                        Vector3.SignedAngle(cameraForward, targetForward, Vector3.up));
                rig.transform.position += landingPosition - camera.transform.position;
            }
            else
                rig.transform.SetPositionAndRotation(landingPosition, Quaternion.Euler(0f, landingRotation.eulerAngles.y, 0f));

            for (int i = 0; i < locomotionProviders.Length; i++)
                if (locomotionProviders[i] != null) locomotionProviders[i].enabled = locomotionEnabled[i];
        }
    }
}
