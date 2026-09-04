using UnityEngine;

namespace AR_Grind_mill.Dialogue.Runtime
{
    /// <summary>
    /// Drives <see cref="DialogueData.DialogueEvents.OnProximityChanged"/> based on
    /// whether the VR player rig is inside the trigger collider attached to this NPC.
    ///
    /// Originally required a <see cref="SphereCollider"/> via <c>RequireComponent</c>;
    /// that was loosened to any <see cref="Collider"/> so humanoid rigs (which ship
    /// with a <see cref="CapsuleCollider"/>) can be swapped in without authoring a
    /// throwaway sphere. For SphereColliders the <see cref="triggerRadius"/> field is
    /// applied at Awake; for non-sphere colliders, size the collider yourself and treat
    /// <see cref="triggerRadius"/> as a documentation-only hint.
    ///
    /// Player detection matches the BuffaloRider.cs convention: a collider counts as
    /// "the player" if its <c>transform.root</c> hierarchy contains a
    /// <c>Unity.XR.CoreUtils.XROrigin</c>, OR if it is an ancestor of <c>Camera.main</c>.
    /// The layer mask adds a cheap early-out so non-player colliders (NPCs, props,
    /// trigger volumes on other systems) never even reach the lookup.
    /// </summary>
    public class NPCProximityTrigger : MonoBehaviour
    {
        [Header("Proximity")]
        [Tooltip("Radius of the proximity volume (metres). Applied to a SphereCollider at Awake; " +
                 "ignored for other collider types — size those yourself.")]
        [Min(0.1f)]
        public float triggerRadius = 2f;

        [Header("Player Filter")]
        [Tooltip("Layers considered for the player. Default ~0 = every collider is checked.")]
        public LayerMask playerLayers = ~0;

        /// <summary>True while the local player rig is currently inside the trigger volume.</summary>
        public bool IsPlayerInRange { get; private set; }

        private Collider triggerCollider;

        private void Awake()
        {
            triggerCollider = GetComponent<Collider>();
            if (triggerCollider == null)
            {
                Debug.LogWarning(
                    $"[{nameof(NPCProximityTrigger)}] No Collider found on '{name}'. " +
                    $"Add a SphereCollider / CapsuleCollider / BoxCollider to enable proximity detection.",
                    this);
                return;
            }

            triggerCollider.isTrigger = true;
            if (triggerCollider is SphereCollider sphere)
            {
                sphere.radius = triggerRadius;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsPlayerCollider(other)) return;

            IsPlayerInRange = true;
            AR_Grind_mill.Dialogue.Data.DialogueEvents.RaiseProximityChanged(transform, true);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!IsPlayerCollider(other)) return;

            IsPlayerInRange = false;
            AR_Grind_mill.Dialogue.Data.DialogueEvents.RaiseProximityChanged(transform, false);
        }

        /// <summary>
        /// Returns true when <paramref name="other"/> belongs to the VR player rig.
        /// Layer-mask filter is applied first as a cheap early-out; then we look for
        /// either an XROrigin in the root hierarchy or an ancestor relationship to
        /// <c>Camera.main</c>.
        /// </summary>
        private bool IsPlayerCollider(Collider other)
        {
            if (other == null) return false;
            if ((playerLayers.value & (1 << other.gameObject.layer)) == 0) return false;

            Transform root = other.transform.root;
            if (root == null) return false;

            // Fast path: VR rig has an XROrigin component at the rig root.
            if (root.GetComponentInChildren<Unity.XR.CoreUtils.XROrigin>(true) != null)
            {
                return true;
            }

            // Fallback: any collider whose transform is an ancestor of Camera.main
            // (covers projects that don't expose an XROrigin on the same GameObject).
            Camera mainCam = Camera.main;
            if (mainCam != null && mainCam.transform != null)
            {
                Transform walker = mainCam.transform;
                while (walker != null)
                {
                    if (walker == other.transform) return true;
                    walker = walker.parent;
                }
            }

            return false;
        }
    }
}