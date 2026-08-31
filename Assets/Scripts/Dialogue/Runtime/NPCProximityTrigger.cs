using UnityEngine;

namespace AR_Grind_mill.Dialogue.Runtime
{
    /// <summary>
    /// Drives <see cref="DialogueData.DialogueEvents.OnProximityChanged"/> based on
    /// whether the VR player rig is inside a sphere collider attached to this NPC.
    ///
    /// Player detection matches the BuffaloRider.cs convention: a collider counts as
    /// "the player" if its <c>transform.root</c> hierarchy contains a
    /// <c>Unity.XR.CoreUtils.XROrigin</c>, OR if it is an ancestor of <c>Camera.main</c>.
    /// The layer mask adds a cheap early-out so non-player colliders (NPCs, props,
    /// trigger volumes on other systems) never even reach the lookup.
    /// </summary>
    [RequireComponent(typeof(SphereCollider))]
    public class NPCProximityTrigger : MonoBehaviour
    {
        [Header("Proximity")]
        [Tooltip("Radius of the proximity sphere (metres). Applied to the SphereCollider on Awake.")]
        [Min(0.1f)]
        public float triggerRadius = 2f;

        [Header("Player Filter")]
        [Tooltip("Layers considered for the player. Default ~0 = every collider is checked.")]
        public LayerMask playerLayers = ~0;

        /// <summary>True while the local player rig is currently inside the sphere.</summary>
        public bool IsPlayerInRange { get; private set; }

        private SphereCollider sphere;

        private void Awake()
        {
            sphere = GetComponent<SphereCollider>();
            if (sphere == null)
            {
                Debug.LogWarning(
                    $"[{nameof(NPCProximityTrigger)}] No SphereCollider found on '{name}'. " +
                    $"RequireComponent should have added one — check for stripped components.",
                    this);
                return;
            }

            sphere.isTrigger = true;
            sphere.radius = triggerRadius;
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