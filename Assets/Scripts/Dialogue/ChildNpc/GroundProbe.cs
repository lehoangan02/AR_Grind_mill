using UnityEngine;

namespace AR_Grind_mill.Dialogue.ChildNpc
{
    /// <summary>
    /// Snap-walks the GameObject to the ground each <see cref="LateUpdate"/> by
    /// raycasting straight down from <see cref="raycastHeight"/> above the current
    /// XZ position. Used by the child NPC guide to stay glued to rolling terrain
    /// without a Rigidbody, CharacterController, or any agent-based pathing.
    ///
    /// The down-ray is intentionally simple (no slope follow, no interpolation) so
    /// the probe cost stays O(1) per frame and there is zero per-frame state to
    /// desync if a parent rig rebases the transform mid-frame.
    ///
    /// Public helpers <see cref="TryGetGroundY(float, float, out float)"/> and
    /// <see cref="SampleGround(Vector3)"/> are exposed for
    /// <c>WanderingGuideController</c> (Todo 4) to project candidate waypoints
    /// onto the terrain before queueing them as <c>Transform.position</c> targets
    /// for <see cref="LateUpdate"/> to follow.
    ///
    /// Spawn-time overlap check: a one-shot <see cref="Physics.OverlapSphere"/>
    /// at <see cref="Start"/> warns if a non-Ground collider is intersecting
    /// the spawn footprint — typically a sign the child is being dropped
    /// inside another NPC, a prop, or the player rig.
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("AR Grind Mill/Dialogue/Child NPC/Ground Probe")]
    public class GroundProbe : MonoBehaviour
    {
        [Header("Raycast")]
        [Tooltip("Distance above the GameObject's current Y where the down-ray starts. " +
                 "Keep small (0.1–1 m) so the ray stays inside the collider's vertical bounds " +
                 "even on small terrain meshes.")]
        [Min(0f)]
        [SerializeField] private float raycastHeight = 0.5f;

        [Tooltip("Maximum downward distance the ray will travel before giving up. " +
                 "Pick larger than the steepest height delta the NPC can encounter " +
                 "between two frames (typical: 2–5 m for a walkable surface).")]
        [Min(0.01f)]
        [SerializeField] private float raycastDistance = 5f;

        [Tooltip("Layers considered 'ground'. Default ~0 = everything; override to " +
                 "exclude props, the player rig, and other NPCs from the snap ray.")]
        [SerializeField] private LayerMask groundMask = ~0;

        [Header("Spawn Check")]
        [Tooltip("Radius of the one-shot OverlapSphere at Start. Default 0.5 m covers " +
                 "a small child's body footprint; raise if the rig is unusually wide.")]
        [Min(0.01f)]
        [SerializeField] private float spawnCheckRadius = 0.5f;

        /// <summary>
        /// Public read-only view of the active ground mask. Used by editor tooling
        /// and by future debug overlays; not intended to be mutated at runtime.
        /// </summary>
        public LayerMask GroundMask => groundMask;

        /// <summary>
        /// Snap to the ground in <see cref="LateUpdate"/> so any parent rig motion
        /// (XR camera, Cinemachine, animation) has already settled for the frame.
        /// <para>
        /// Ray origin is <c>transform.position + Vector3.up * raycastHeight</c> —
        /// placing the origin above the foot prevents the snap from being eaten
        /// by the NPC's own collider if the rig root has a CapsuleCollider on it.
        /// </para>
        /// <para>
        /// Direction is <see cref="Vector3.down"/>; a single <see cref="Physics.Raycast"/>
        /// (NOT <c>Physics.RaycastAll</c>) is used because we only care about the
        /// first ground hit. <see cref="QueryTriggerInteraction.Ignore"/> skips
        /// trigger volumes (zone triggers, interaction prompts) so a trigger on
        /// the ground layer doesn't redirect the snap.
        /// </para>
        /// </summary>
        private void LateUpdate()
        {
            Vector3 origin = transform.position + Vector3.up * raycastHeight;

            if (Physics.Raycast(origin, Vector3.down, out RaycastHit hit,
                                raycastDistance, groundMask, QueryTriggerInteraction.Ignore))
            {
                Vector3 p = transform.position;
                transform.position = new Vector3(p.x, hit.point.y, p.z);
            }
        }

        /// <summary>
        /// Returns the ground Y under the supplied world XZ, mirroring the snap
        /// raycast used in <see cref="LateUpdate"/>. Used by
        /// <c>WanderingGuideController.PickNextWaypoint</c> to project random
        /// XZ samples onto terrain before they become targets.
        /// </summary>
        /// <param name="x">World X coordinate to probe.</param>
        /// <param name="z">World Z coordinate to probe.</param>
        /// <param name="y">Ground height at (<paramref name="x"/>, <paramref name="z"/>) if a hit is found; otherwise the previous value (set to 0 on failure).</param>
        /// <returns>True if a collider on <see cref="groundMask"/> was hit within <see cref="raycastDistance"/>.</returns>
        public bool TryGetGroundY(float x, float z, out float y)
        {
            Vector3 origin = new Vector3(x, transform.position.y + raycastHeight, z);
            if (Physics.Raycast(origin, Vector3.down, out RaycastHit hit,
                                raycastDistance, groundMask, QueryTriggerInteraction.Ignore))
            {
                y = hit.point.y;
                return true;
            }

            y = 0f;
            return false;
        }

        /// <summary>
        /// Convenience wrapper around <see cref="TryGetGroundY(float, float, out float)"/>
        /// for callers that already hold a <see cref="Vector3"/> waypoint candidate.
        /// Returns the candidate unchanged when no ground is found, so callers can
        /// chain it as a no-op fallback (e.g. guard against picking a waypoint
        /// over a cliff edge by also checking the returned Y against a minimum).
        /// </summary>
        /// <param name="candidate">World-space point whose X/Z should be projected to the ground.</param>
        /// <returns><paramref name="candidate"/> with Y replaced by the ground height if a hit was found; otherwise the original <paramref name="candidate"/>.</returns>
        public Vector3 SampleGround(Vector3 candidate)
        {
            if (TryGetGroundY(candidate.x, candidate.z, out float y))
            {
                return new Vector3(candidate.x, y, candidate.z);
            }
            return candidate;
        }

        private void Start()
        {
            // One-shot spawn-time overlap check. The mask is ~0 (everything) so we
            // catch any collider; we then warn if the hit's layer is NOT in
            // groundMask — i.e. the child is clipping something it shouldn't be
            // (another NPC, the player rig, a prop, the XR camera anchor, etc.).
            Collider[] overlaps = Physics.OverlapSphere(transform.position, spawnCheckRadius,
                                                        ~0, QueryTriggerInteraction.Ignore);
            for (int i = 0; i < overlaps.Length; i++)
            {
                Collider c = overlaps[i];
                if (c == null) continue;

                int layer = c.gameObject.layer;
                if ((groundMask.value & (1 << layer)) == 0)
                {
                    Debug.LogWarning(
                        $"[GroundProbe] Spawn position {transform.position} overlaps " +
                        $"{c.name} on layer {LayerMask.LayerToName(layer)} ({layer}); " +
                        "child may spawn-clipped.",
                        this);
                }
            }
        }

#if UNITY_EDITOR
        /// <summary>
        /// Scene-view gizmo so designers can see the down-ray in action while
        /// tweaking <see cref="raycastHeight"/> / <see cref="raycastDistance"/>.
        /// Editor-only; stripped from player builds.
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            Vector3 origin = transform.position + Vector3.up * raycastHeight;
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(origin, origin + Vector3.down * raycastDistance);
            Gizmos.color = new Color(1f, 0.5f, 0f, 0.35f);
            Gizmos.DrawWireSphere(transform.position, spawnCheckRadius);
        }
#endif
    }
}
