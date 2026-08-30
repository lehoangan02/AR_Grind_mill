using UnityEngine;

namespace AR_Grind_mill.Dialogue.Runtime
{
    /// <summary>
    /// Smoothly rotates an NPC head bone so it tracks <c>Camera.main</c> while dialogue
    /// is active. Yaw and pitch are clamped to artist-friendly ranges (default ±70°/±30°)
    /// so the head never snaps behind its own shoulders.
    ///
    /// NOTE — IK vs direct rotation:
    /// For HUMANOID rigs the same effect can be achieved more physically-correctly via
    /// Animator IK (OnAnimatorIK + Animator.SetLookAtPosition / SetLookAtWeight). This
    /// implementation uses DIRECT TRANSFORM ROTATION instead because:
    ///   1. it works on any rig type (Generic, humanoid, custom) without an Animator
    ///      Controller that exposes an IK pass;
    ///   2. it has zero Animator overhead — useful when many NPCs are in the scene;
    ///   3. it composes predictably with additive animation states that already write
    ///      head rotation in the muscle space.
    /// If you need true IK-driven look-at for a specific NPC, swap this script for an
    /// OnAnimatorIK implementation that calls <c>animator.SetLookAtPosition(...)</c>.
    /// </summary>
    public class HeadLookAtPlayer : MonoBehaviour
    {
        [Header("References")]
        [Tooltip("Head bone transform. Defaults to this GameObject's transform when empty.")]
        public Transform headBone;

        [Tooltip("Player camera transform. Auto-resolved from Camera.main in Start() if left empty.")]
        public Transform playerCamera;

        [Header("Behaviour")]
        [Tooltip("0 = do not look at all, 1 = fully commit to the target rotation.")]
        [Range(0f, 1f)]
        public float weight = 1f;

        [Tooltip("Approx seconds for the head to catch up to the target. 0 = snap immediately.")]
        [Range(0f, 1f)]
        public float smoothTime = 0.15f;

        [Tooltip("Maximum yaw (left/right) the head will turn from its rest forward.")]
        [Range(0f, 90f)]
        public float maxYawDegrees = 70f;

        [Tooltip("Maximum pitch (up/down) the head will turn from its rest forward.")]
        [Range(0f, 45f)]
        public float maxPitchDegrees = 30f;

        private Quaternion currentRotation;
        private bool isActive = true;
        private bool warnedMissingCamera;

        private void Start()
        {
            if (headBone == null)
            {
                headBone = transform;
            }

            if (playerCamera == null)
            {
                Camera mainCam = Camera.main;
                if (mainCam != null)
                {
                    playerCamera = mainCam.transform;
                }
            }

            // Seed the smoothing so the first LateUpdate doesn't pop from identity.
            currentRotation = headBone != null ? headBone.rotation : Quaternion.identity;
        }

        /// <summary>Enable/disable the look-at. Use from the dialogue controller while talking.</summary>
        public void SetActive(bool value)
        {
            isActive = value;
        }

        private void LateUpdate()
        {
            if (!isActive) return;
            if (headBone == null) return;

            if (playerCamera == null)
            {
                // Try to recover in case the camera spawned late (XR rig initialisation order).
                Camera mainCam = Camera.main;
                if (mainCam == null)
                {
                    if (!warnedMissingCamera)
                    {
                        Debug.LogWarning(
                            $"[{nameof(HeadLookAtPlayer)}] No playerCamera assigned and Camera.main is null. " +
                            $"Head look-at will skip until the headset is initialised.",
                            this);
                        warnedMissingCamera = true;
                    }
                    return;
                }
                playerCamera = mainCam.transform;
                warnedMissingCamera = false;
            }

            Transform restReference = headBone.parent != null ? headBone.parent : transform;
            Vector3 restForward = restReference.forward;

            Vector3 toPlayer = playerCamera.position - headBone.position;
            if (toPlayer.sqrMagnitude < 0.0001f) return;

            Quaternion desiredWorld = Quaternion.LookRotation(toPlayer.normalized, Vector3.up);
            Quaternion restRot = Quaternion.LookRotation(restForward, Vector3.up);

            // Delta from rest forward → desired forward, expressed in rest-local space.
            Quaternion deltaRot = Quaternion.Inverse(restRot) * desiredWorld;
            Vector3 deltaEuler = NormalizeEuler(deltaRot.eulerAngles);

            deltaEuler.y = Mathf.Clamp(deltaEuler.y, -maxYawDegrees, maxYawDegrees);
            deltaEuler.x = Mathf.Clamp(deltaEuler.x, -maxPitchDegrees, maxPitchDegrees);
            // We never let the head roll.
            deltaEuler.z = 0f;

            // Re-clamp for cases where the clamp on one axis pushed the other out of range
            // (clamping a 3D rotation axis-by-axis isn't exact, but it's stable enough for a
            // head-and-shoulders NPC). Final clamp pass keeps the magnitude sane.
            deltaEuler.y = Mathf.Clamp(deltaEuler.y, -maxYawDegrees, maxYawDegrees);
            deltaEuler.x = Mathf.Clamp(deltaEuler.x, -maxPitchDegrees, maxPitchDegrees);

            Quaternion clampedDelta = Quaternion.Euler(deltaEuler);
            Quaternion targetWorld = restRot * clampedDelta;

            if (weight <= 0f)
            {
                // Pure no-op: keep whatever rotation was there.
                return;
            }
            else if (weight < 1f)
            {
                Quaternion restWorld = headBone.rotation; // not used directly — slerp from current
                targetWorld = Quaternion.Slerp(restWorld, targetWorld, weight);
            }

            if (smoothTime <= 0f)
            {
                currentRotation = targetWorld;
            }
            else
            {
                currentRotation = Quaternion.Slerp(
                    currentRotation,
                    targetWorld,
                    SmoothFactor(smoothTime, Time.deltaTime));
            }

            headBone.rotation = currentRotation;
        }

        /// <summary>Converts Unity's 0..360 Euler into a signed -180..180 representation.</summary>
        private static Vector3 NormalizeEuler(Vector3 euler)
        {
            return new Vector3(
                Mathf.DeltaAngle(0f, euler.x),
                Mathf.DeltaAngle(0f, euler.y),
                Mathf.DeltaAngle(0f, euler.z));
        }

        /// <summary>Frame-rate independent smoothing factor from a "time to converge" value.</summary>
        private static float SmoothFactor(float smoothTime, float deltaTime)
        {
            if (smoothTime <= 0f) return 1f;
            // Mathf.SmoothDamp uses t / (t + smoothing); approximate the same curve for slerp.
            return 1f - Mathf.Exp(-deltaTime / smoothTime);
        }
    }
}