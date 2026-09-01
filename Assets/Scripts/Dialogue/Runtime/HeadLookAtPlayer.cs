using UnityEngine;

namespace AR_Grind_mill.Dialogue.Runtime
{
    /// <summary>
    /// Smoothly rotates an NPC head so it tracks <c>Camera.main</c> while dialogue
    /// is active.
    ///
    /// Two paths:
    /// <list type="bullet">
    /// <item>HUMANOID avatar → Animator IK (<see cref="OnAnimatorIK"/>). The Animator
    /// owns bone rotations in this mode and overwrites any LateUpdate direct
    /// rotation, so we route through <c>SetLookAtPosition</c> / <c>SetLookAtWeight</c>
    /// (requires the controller layer's IK Pass flag enabled).</item>
    /// <item>Generic / custom rig → direct <see cref="LateUpdate"/> rotation on
    /// <see cref="headBone"/> relative to the neck's rest forward. Yaw and pitch
    /// are clamped to artist-friendly ranges so the head never snaps behind its
    /// shoulders.</item>
    /// </list>
    /// </summary>
    public class HeadLookAtPlayer : MonoBehaviour
    {
        [Header("References")]
        [Tooltip("Head bone transform. Only used on non-Humanoid rigs — Humanoid IK uses the avatar's head muscle.")]
        public Transform headBone;

        [Tooltip("Player camera transform. Auto-resolved from Camera.main in Start() if left empty.")]
        public Transform playerCamera;

        [Header("Behaviour")]
        [Tooltip("0 = do not look at all, 1 = fully commit to the target rotation.")]
        [Range(0f, 1f)]
        public float weight = 1f;

        [Tooltip("Approx seconds for the head to catch up to the target. 0 = snap immediately. Only applies to non-Humanoid path.")]
        [Range(0f, 1f)]
        public float smoothTime = 0.15f;

        [Tooltip("Maximum yaw (left/right) the head will turn from its rest forward.")]
        [Range(0f, 90f)]
        public float maxYawDegrees = 70f;

        [Tooltip("Maximum pitch (up/down) the head will turn from its rest forward.")]
        [Range(0f, 45f)]
        public float maxPitchDegrees = 30f;

        [Header("Distance Gating")]
        [Tooltip("Maximum distance from the player camera to the NPC origin for head-look to be active. " +
                 "Beyond this the head returns to rest. 0 = unlimited.")]
        [Min(0f)]
        public float maxDistance = 8f;

        // ---- Cached state ----
        private Animator animator;
        private bool useHumanoidIK;
        private Quaternion currentRotation;
        private Quaternion restRotation;
        private bool warnedMissingCamera;

        private void Awake()
        {
            // Resolve the Animator up the hierarchy. For prefab variants it lives on
            // the same root or a sibling (rig is usually on the NPC root).
            animator = GetComponentInParent<Animator>();
            if (animator != null && animator.isHuman)
            {
                useHumanoidIK = true;
            }

            if (!useHumanoidIK && headBone == null)
            {
                // Fallback: use this GameObject's transform as the head so the script
                // at least runs (debugging the bone binding is the user's job).
                headBone = transform;
            }
        }

        private void Start()
        {
            if (playerCamera == null)
            {
                Camera mainCam = Camera.main;
                if (mainCam != null)
                {
                    playerCamera = mainCam.transform;
                }
            }

            if (!useHumanoidIK && headBone != null)
            {
                // Seed the smoothing so the first LateUpdate doesn't pop from identity,
                // and cache the rest pose so we can return to it when out of range.
                currentRotation = headBone.rotation;
                restRotation    = headBone.rotation;
            }
        }

        /// <summary>Enable/disable the look-at. Use from the dialogue controller while talking.</summary>
        public void SetActive(bool value)
        {
            enabled = value;
        }

        // ----- Humanoid IK path -----

        /// <summary>
        /// Animator calls this when the layer has its IK Pass enabled. We route the
        /// head-look through <c>SetLookAtPosition</c> so the IK solver drives the
        /// head/neck/spine muscles from inside the muscle space — direct bone writes
        /// would be clobbered by the muscle evaluator on the next frame.
        /// </summary>
        private void OnAnimatorIK(int layerIndex)
        {
            if (!useHumanoidIK || animator == null) return;
            if (weight <= 0f) return;
            if (playerCamera == null)
            {
                if (!TryRecoverPlayerCamera()) return;
            }

            // Body=0.3 (slight upper-body lean), Head=1, Eyes=0 (face/eyes only).
            // clampWeight=0.5 limits how far past the cone the head can twist.
            // Weight=0 returns the head to the controller's rest pose.
            float w = Mathf.Clamp01(weight);
            if (maxDistance > 0f &&
                Vector3.Distance(transform.position, playerCamera.position) > maxDistance)
            {
                w = 0f;
            }
            animator.SetLookAtWeight(w, 0.3f, 1f, 0f, 0.5f);
            animator.SetLookAtPosition(playerCamera.position);
        }

        // ----- Generic rig path -----

        private void LateUpdate()
        {
            if (useHumanoidIK) return; // Handled by OnAnimatorIK.
            if (headBone == null) return;

            if (playerCamera == null && !TryRecoverPlayerCamera()) return;

            bool inRange = maxDistance <= 0f ||
                Vector3.Distance(transform.position, playerCamera.position) <= maxDistance;

            Quaternion targetWorld;
            if (inRange)
            {
                Transform restReference = headBone.parent != null ? headBone.parent : transform;
                Vector3 restForward = restReference.forward;

                Vector3 toPlayer = playerCamera.position - headBone.position;
                if (toPlayer.sqrMagnitude < 0.0001f) return;

                Quaternion desiredWorld = Quaternion.LookRotation(toPlayer.normalized, Vector3.up);
                Quaternion restRot = Quaternion.LookRotation(restForward, Vector3.up);

                Quaternion deltaRot = Quaternion.Inverse(restRot) * desiredWorld;
                Vector3 deltaEuler = NormalizeEuler(deltaRot.eulerAngles);

                deltaEuler.y = Mathf.Clamp(deltaEuler.y, -maxYawDegrees, maxYawDegrees);
                deltaEuler.x = Mathf.Clamp(deltaEuler.x, -maxPitchDegrees, maxPitchDegrees);
                deltaEuler.z = 0f;

                // Re-clamp (clamp axis-by-axis isn't exact on a 3D rotation; second pass
                // keeps magnitude sane).
                deltaEuler.y = Mathf.Clamp(deltaEuler.y, -maxYawDegrees, maxYawDegrees);
                deltaEuler.x = Mathf.Clamp(deltaEuler.x, -maxPitchDegrees, maxPitchDegrees);

                Quaternion clampedDelta = Quaternion.Euler(deltaEuler);
                targetWorld = restRot * clampedDelta;
            }
            else
            {
                // Out of range — ease the head back to its captured rest pose.
                targetWorld = restRotation;
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

        // ----- Helpers -----

        /// <summary>
        /// Try to recover <see cref="playerCamera"/> from <c>Camera.main</c> when it
        /// spawned late (XR rig initialisation order). Returns true on success.
        /// </summary>
        private bool TryRecoverPlayerCamera()
        {
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
                return false;
            }
            playerCamera = mainCam.transform;
            warnedMissingCamera = false;
            return true;
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
            return 1f - Mathf.Exp(-deltaTime / smoothTime);
        }
    }
}