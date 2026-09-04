// WanderingGuideController.cs — full implementation (replaces Wave 2 / Todo 4 placeholder)
//
// Drives the child NPC guide between random orbit waypoints around the VR
// player. Listens to the global DialogueEvents hub so dialogue (started by
// any NPC, not just this one) freezes the wander in place and the Animator's
// IsTalking flag flips on; when the dialogue ends the child resumes idle
// pacing. Subscribes to XRI 3.3.2's TeleportationProvider.locomotionEnded so
// that when the player teleports the child immediately recomputes its orbit
// instead of trying to walk a stale path.
//
// Public API contract (preserved across the placeholder -> implementation swap):
//
//     public void ForceGoto(Vector3 worldPos);
//
// ChildNpcTipController.TryCallForceGoto calls this via reflection. Renaming
// or removing it would break the tip controller, so the signature is frozen
// even though the implementation now does far more than a no-op.
//
// Subsystem composition:
//   - Animator        : from GetComponentInChildren (incl. inactive) at Awake
//   - HeadLookAtPlayer: from GetComponentInChildren (incl. inactive) at Awake
//   - GroundProbe     : from GetComponent at Awake
//   - Player (XROrigin): resolved at Start via FindObjectOfType, with the
//                        same fallback chain as BuffaloRider.cs:76-90.
//
// No NavMesh, no agent, no bake. Movement is straight Transform.Translate by
// walkSpeed * dt toward the current waypoint, with the snap-to-ground step
// delegated to GroundProbe.LateUpdate.

using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit.Locomotion;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation;
using AR_Grind_mill.Dialogue.Data;
using AR_Grind_mill.Dialogue.Runtime;

namespace AR_Grind_mill.Dialogue.ChildNpc
{
    /// <summary>
    /// Orbiting waypoint wander controller for the child NPC guide. Three
    /// states (<see cref="State.Idle"/> / <see cref="State.Walking"/> /
    /// <see cref="State.Talking"/>) drive both movement and Animator bool
    /// parameters. <see cref="ForceGoto"/> overrides normal orbit behaviour
    /// when an external system (the quest hook) wants the child to walk to
    /// a specific point — typically a delivery location before dialogue.
    /// <para>
    /// Teleport safety: every frame, if the player moves further than
    /// <see cref="lostPlayerDistance"/> away (or XRI fires
    /// <c>locomotionEnded</c>) the child recomputes a fresh orbit waypoint
    /// and immediately starts walking toward it. This avoids the visual
    /// artefact of the child slowly jogging along a stale path back to a
    /// player who has already teleported 20m away.
    /// </para>
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("AR Grind Mill/Dialogue/Child NPC/Wandering Guide")]
    public class WanderingGuideController : MonoBehaviour
    {
        // ─── State machine ──────────────────────────────────────────────

        /// <summary>
        /// Three top-level behaviour states. Transitions:
        /// <list type="bullet">
        /// <item>Idle -> Walking  : idle timer expires (we picked a waypoint).</item>
        /// <item>Walking -> Idle  : arrived at current waypoint (within arriveDistance).</item>
        /// <item>{Idle,Walking} -> Talking : DialogueEvents.OnDialogueStarted fires.</item>
        /// <item>Talking -> {Idle,Walking} : DialogueEvents.OnDialogueEnded fires; resume based on whether an idle timer was running.</item>
        /// </list>
        /// </summary>
        private enum State { Idle, Walking, Talking }

        private State currentState = State.Idle;
        private Vector3 currentWaypoint;
        private float idleTimer;
        private bool hadIdleTimerWhenDialogueStarted;

        // ─── Forced-move override (quest hook delivery target) ──────────

        private Vector3 forceTarget;
        private bool hasForceTarget;

        // ─── Serialized fields ──────────────────────────────────────────

        [Header("References")]
        [Tooltip("Player transform. If left null, Start() resolves it from the XR Origin in the scene.")]
        [SerializeField] private Transform player;

        [Tooltip("Animator on the rigged child. If left null, Awake() resolves it from children (incl. inactive). " +
                 "All SetBool calls are guarded against null so the controller still works without an animator.")]
        [SerializeField] private Animator animator;

        [Tooltip("Head-look-at-player component. LateUpdate enables/disables it based on headLookActivationDistance.")]
        [SerializeField] private HeadLookAtPlayer headLook;

        [Tooltip("Ground sampler. Awake() resolves it from the same GameObject if left null.")]
        [SerializeField] private GroundProbe groundProbe;

        [Header("Orbit")]
        [Tooltip("Minimum horizontal distance (m) from the player a waypoint can land.")]
        [Min(0f)]
        [SerializeField] private float orbitInnerRadius = 1.5f;

        [Tooltip("Maximum horizontal distance (m) from the player a waypoint can land.")]
        [Min(0f)]
        [SerializeField] private float orbitOuterRadius = 3.0f;

        [Tooltip("Reserved for the planned 'round-robin waypoint' mode. The current implementation uses " +
                 "fully random orbit sampling (more organic-looking for a child NPC) but the field is " +
                 "kept so the Inspector surface matches the plan and future code can opt into it.")]
        [Min(1)]
        [SerializeField] private int waypointCount = 6;

        [Header("Locomotion")]
        [Tooltip("Walking speed (m/s) toward the current waypoint.")]
        [Min(0f)]
        [SerializeField] private float walkSpeed = 1.6f;

        [Tooltip("When idle, the child stays still for a random duration in [idleMinSeconds, idleMaxSeconds].")]
        [Min(0f)]
        [SerializeField] private float idleMinSeconds = 2f;

        [Tooltip("Upper bound of the idle-duration random range (see idleMinSeconds).")]
        [Min(0f)]
        [SerializeField] private float idleMaxSeconds = 6f;

        [Tooltip("Distance (m) to current waypoint at which the child is considered 'arrived' and switches to Idle.")]
        [Min(0.01f)]
        [SerializeField] private float arriveDistance = 0.2f;

        [Header("Distance Gates")]
        [Tooltip("If the player is further than this many metres from the child, " +
                 "the orbit is recomputed every frame (teleport safety).")]
        [Min(0f)]
        [SerializeField] private float lostPlayerDistance = 10f;

        [Tooltip("Maximum distance (m) at which HeadLookAtPlayer is allowed to run. " +
                 "LateUpdate sets headLook.enabled = (distance <= headLookActivationDistance).")]
        [Min(0f)]
        [SerializeField] private float headLookActivationDistance = 4f;

        // ─── Runtime / cached state ────────────────────────────────────

        /// <summary>
        /// Cached TeleportationProvider subscription. Cleared on
        /// <see cref="OnDisable"/> to mirror OnEnable; if no provider exists
        /// in the scene we silently rely on the per-frame distance check.
        /// </summary>
        private TeleportationProvider teleportationProvider;
        private Action<LocomotionProvider> onLocomotionEndedHandler;

        // Track whether the head-look was supposed to be enabled at the time
        // dialogue started so OnDialogueEnded can restore the same state.
        private bool headLookWasEnabledBeforeDialogue;

        // Cache animator parameter lookups so we don't HasParameter every frame.
        private HashSet<string> knownAnimatorParameters;

        // ─── Lifecycle ──────────────────────────────────────────────────

        private void Awake()
        {
            // Resolve references defensively. includeInactive: true so prefab
            // variants that hide subcomponents by default still bind.
            if (animator == null)
            {
                animator = GetComponentInChildren<Animator>(includeInactive: true);
            }

            if (headLook == null)
            {
                headLook = GetComponentInChildren<HeadLookAtPlayer>(includeInactive: true);
            }

            if (groundProbe == null)
            {
                groundProbe = GetComponent<GroundProbe>();
            }
        }

        private void OnEnable()
        {
            // Subscribe to the global dialogue hub so we freeze in place any
            // time ANY NPC in the scene is talking (not just us). This matches
            // the plan: movement suspends whenever the dialogue UI is up so
            // the player can focus on reading.
            DialogueEvents.OnDialogueStarted += HandleDialogueStarted;
            DialogueEvents.OnDialogueEnded   += HandleDialogueEnded;
        }

        private void OnDisable()
        {
            // Mirror OnEnable. If we unsubscribe mid-conversation (e.g. the
            // NPC was disabled by a quest step), jump back to Idle so we
            // don't get stuck in the Talking state forever.
            DialogueEvents.OnDialogueStarted -= HandleDialogueStarted;
            DialogueEvents.OnDialogueEnded   -= HandleDialogueEnded;

            if (currentState == State.Talking)
            {
                SwitchToIdleOrWalkingAfterDialogue();
            }

            UnsubscribeFromTeleport();
        }

        private void Start()
        {
            // Resolve the player transform. We mirror BuffaloRider.cs:76-90
            // for consistency with the rest of the codebase: XROrigin first
            // (preferred), Camera.main as a fallback.
            if (player == null)
            {
                XROrigin origin = FindObjectOfType<XROrigin>(includeInactive: true);
                if (origin != null)
                {
                    player = origin.transform;
                }
                else
                {
                    Camera cam = Camera.main;
                    if (cam != null)
                    {
                        player = cam.transform;
                    }
                }
            }

            if (player == null)
            {
                Debug.LogError(
                    $"[{nameof(WanderingGuideController)}] '{name}' could not resolve a player " +
                    "transform (no XROrigin and no Camera.main). Wandering is disabled.",
                    this);
                enabled = false;
                return;
            }

            // Subscribe to XRI teleport so a player teleport (instead of
            // smooth locomotion) recomputes the orbit. TeleportationProvider
            // lives anywhere in the scene (typically under the XROrigin or
            // the XR Interaction Manager) — we search globally.
            SubscribeToTeleport();

            // Seed an idle timer so the child doesn't immediately pick a
            // waypoint on frame 1 (gives the player a moment to see it).
            idleTimer = UnityEngine.Random.Range(idleMinSeconds, idleMaxSeconds);
            currentState = State.Idle;
            UpdateAnimatorBools();
        }

        private void Update()
        {
            // Talking freezes movement; flip the animator and bail.
            if (currentState == State.Talking)
            {
                SetAnimatorBool("IsMoving", false);
                SetAnimatorBool("IsTalking", true);
                return;
            }

            if (player == null)
            {
                // Start() already logged + disabled, but be defensive in
                // case the reference was cleared at runtime.
                return;
            }

            // Teleport safety: every frame, if the player is way too far
            // away, recompute waypoints immediately. This catches both
            // un-mediated teleports (XRI event also fires, but the
            // per-frame check is the safety net) and edge cases where the
            // teleport event was missed.
            float distToPlayer = Vector3.Distance(transform.position, player.position);
            if (distToPlayer > lostPlayerDistance)
            {
                RecomputeWaypointAndWalk();
            }

            // ForceGoto override: if the quest hook queued a forced target,
            // walk straight to it regardless of state. Cleared on arrival.
            if (hasForceTarget)
            {
                StepToward(forceTarget, distToPlayer);
                if (Vector3.Distance(transform.position, forceTarget) <= arriveDistance)
                {
                    hasForceTarget = false;
                    EnterIdleWithFreshTimer();
                }
                return;
            }

            switch (currentState)
            {
                case State.Idle:
                    idleTimer -= Time.deltaTime;
                    if (idleTimer <= 0f)
                    {
                        if (TryPickNextWaypoint(out currentWaypoint))
                        {
                            currentState = State.Walking;
                            UpdateAnimatorBools();
                        }
                        else
                        {
                            // Couldn't sample ground even after retries.
                            // Stay idle and try again next idle window.
                            EnterIdleWithFreshTimer();
                        }
                    }
                    break;

                case State.Walking:
                    StepToward(currentWaypoint, distToPlayer);
                    if (Vector3.Distance(transform.position, currentWaypoint) <= arriveDistance)
                    {
                        EnterIdleWithFreshTimer();
                    }
                    break;
            }
        }

        private void LateUpdate()
        {
            // Gate HeadLookAtPlayer on distance to the player. Same value
            // as the HeadLookAtPlayer.maxDistance designer-set knob so the
            // prefab wires are consistent (Inspector can override this
            // independently and the gate still works as long as the two
            // are kept in sync — or the prefab-side maxDistance is left
            // larger than headLookActivationDistance, which is fine
            // because this gate fires before HeadLookAtPlayer's own gate).
            if (headLook != null && player != null)
            {
                float dist = Vector3.Distance(transform.position, player.position);
                headLook.enabled = dist <= headLookActivationDistance;
            }
        }

        // ─── Public API (reflection-safe contract) ──────────────────────

        /// <summary>
        /// Queue a forced waypoint. The child walks to <paramref name="worldPos"/>
        /// instead of its normal orbit waypoint. Cleared automatically on arrival.
        /// Called by <c>ChildNpcTipController.TryCallForceGoto</c> via reflection.
        /// <para>
        /// SIGNATURE FROZEN: <see cref="ChildNpcTipController"/> binds to this
        /// method at runtime via <c>System.Reflection.MethodInfo.Invoke</c>;
        /// renaming the method, changing its accessibility, or changing the
        /// parameter type would break the tip controller without compile errors
        /// on its side. Keep this signature stable.
        /// </para>
        /// </summary>
        /// <param name="worldPos">World-space destination point. Will be projected onto ground via <see cref="GroundProbe"/>.</param>
        public void ForceGoto(Vector3 worldPos)
        {
            // Project the forced point onto the terrain so we don't ask the
            // child to fly to a 5m-altitude point that's actually a rooftop.
            if (groundProbe != null)
            {
                forceTarget = groundProbe.SampleGround(worldPos);
            }
            else
            {
                forceTarget = worldPos;
            }
            hasForceTarget = true;

            // Walking state, but DON'T touch the idle timer — if dialogue
            // interrupts and ends before we arrive, we want the previous
            // idle timer to resume naturally.
            currentState = State.Walking;
            UpdateAnimatorBools();
        }

        // ─── Teleport subscription ──────────────────────────────────────

        private void SubscribeToTeleport()
        {
            // XRI 3.3.2: TeleportationProvider.locomotionEnded is the
            // canonical post-teleport hook (Action<LocomotionProvider>).
            // It's typically on the same rig as the XROrigin but
            // FindObjectOfType is the simplest cross-rig search. If the
            // project doesn't use XRI teleportation (no provider in the
            // scene), we silently fall back to the per-frame distance
            // check in Update().
            teleportationProvider = FindObjectOfType<TeleportationProvider>(includeInactive: true);
            if (teleportationProvider == null) return;

            onLocomotionEndedHandler = OnLocomotionEnded;
            teleportationProvider.locomotionEnded += onLocomotionEndedHandler;
        }

        private void UnsubscribeFromTeleport()
        {
            if (teleportationProvider != null && onLocomotionEndedHandler != null)
            {
                teleportationProvider.locomotionEnded -= onLocomotionEndedHandler;
            }
            teleportationProvider = null;
            onLocomotionEndedHandler = null;
        }

        private void OnLocomotionEnded(LocomotionProvider provider)
        {
            // We only care about teleport-induced locomotion. Any other
            // provider (snap turn, smooth-locomotion) won't move the
            // player rig by more than a few metres per frame, so the
            // per-frame distance check in Update() catches those — this
            // event handler is just the early-out for teleports.
            if (!(provider is TeleportationProvider)) return;

            // Recompute the orbit immediately. Don't wait for the next
            // idle window or the next Update.
            RecomputeWaypointAndWalk();
        }

        private void RecomputeWaypointAndWalk()
        {
            if (player == null) return;

            if (TryPickNextWaypoint(out currentWaypoint))
            {
                currentState = State.Walking;
                idleTimer = 0f;
                UpdateAnimatorBools();
            }
            else
            {
                // Ground sample failed (player standing over a cliff?):
                // back off to Idle and let the next frame retry.
                EnterIdleWithFreshTimer();
            }
        }

        // ─── Waypoint picking ──────────────────────────────────────────

        /// <summary>
        /// Pick a random horizontal offset inside the [inner, outer] orbit
        /// annulus around the player, project it onto the ground via
        /// <see cref="GroundProbe.SampleGround"/>, and retry up to three
        /// times. Returns false only if every retry landed in an
        /// un-sampleable spot (e.g. the player is hovering over a void).
        /// </summary>
        private bool TryPickNextWaypoint(out Vector3 waypoint)
        {
            if (player == null || groundProbe == null)
            {
                waypoint = transform.position;
                return false;
            }

            // Clamp outer >= inner so a designer typo doesn't invert the
            // range. (Random.Range handles inverted ranges by clamping,
            // which is silently wrong here.)
            float inner = Mathf.Max(0f, Mathf.Min(orbitInnerRadius, orbitOuterRadius));
            float outer = Mathf.Max(inner, Mathf.Max(orbitInnerRadius, orbitOuterRadius));

            const int maxAttempts = 3;
            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                Vector2 offset2D = UnityEngine.Random.insideUnitCircle;
                // Reject the exact centre (insideUnitCircle can return (0,0))
                // and the zero-length vector; otherwise normalize.
                if (offset2D.sqrMagnitude < 1e-4f)
                {
                    offset2D = new Vector2(1f, 0f);
                }
                else
                {
                    offset2D.Normalize();
                }

                float radius = UnityEngine.Random.Range(inner, outer);
                Vector3 candidate = player.position + new Vector3(offset2D.x * radius, 0f, offset2D.y * radius);

                Vector3 sampled = groundProbe.SampleGround(candidate);

                // GroundProbe.SampleGround returns the original candidate
                // unchanged when no ground is found. Detect by comparing
                // Y — if the Y didn't snap, there was no hit.
                if (!Mathf.Approximately(sampled.y, candidate.y))
                {
                    waypoint = sampled;
                    return true;
                }
            }

            waypoint = transform.position;
            return false;
        }

        // ─── Movement helpers ───────────────────────────────────────────

        private void StepToward(Vector3 target, float distToPlayerForGate)
        {
            // Translate by walkSpeed * dt along the horizontal direction.
            // We deliberately do NOT use Transform.Translate so we can
            // compute a rotation step at the same time. GroundProbe.LateUpdate
            // will re-snap the Y to terrain on the next frame.
            //
            // distToPlayerForGate is currently unused inside StepToward (it
            // was a planned per-step distance gate). Kept in the signature
            // so future code can add it without churn.
            _ = distToPlayerForGate;

            Vector3 toTarget = target - transform.position;
            toTarget.y = 0f;

            float distance = toTarget.magnitude;
            if (distance < 1e-4f) return;

            Vector3 direction = toTarget / distance;
            float step = walkSpeed * Time.deltaTime;
            if (step >= distance)
            {
                // Overshoot clamp: snap to within arriveDistance so we
                // don't ping-pong past the waypoint.
                transform.position = new Vector3(target.x, transform.position.y, target.z);
            }
            else
            {
                transform.position += direction * step;
            }

            // Face the direction of motion (horizontal only). LookRotation
            // would tip the child forward/back if we passed the full
            // vector; zeroing Y keeps it yaw-only.
            Quaternion desired = Quaternion.LookRotation(
                new Vector3(direction.x, 0f, direction.z),
                Vector3.up);
            transform.rotation = desired;

            SetAnimatorBool("IsMoving", true);
            SetAnimatorBool("IsTalking", false);
        }

        private void EnterIdleWithFreshTimer()
        {
            currentState = State.Idle;
            idleTimer = UnityEngine.Random.Range(idleMinSeconds, idleMaxSeconds);
            UpdateAnimatorBools();
        }

        private void SwitchToIdleOrWalkingAfterDialogue()
        {
            // If we were Walking when dialogue interrupted, resume Walking
            // (toward whatever waypoint was active). If we were Idle with
            // a remaining timer, resume Idle with the same timer.
            if (hadIdleTimerWhenDialogueStarted)
            {
                currentState = State.Idle;
            }
            else
            {
                currentState = State.Walking;
            }
            UpdateAnimatorBools();
        }

        // ─── Dialogue event handlers ────────────────────────────────────

        private void HandleDialogueStarted(DialogueGraph graph)
        {
            if (currentState == State.Talking) return; // already talking

            // Remember whether we had an idle timer so OnDialogueEnded can
            // decide whether to resume Idle or Walking.
            hadIdleTimerWhenDialogueStarted = (currentState == State.Idle && idleTimer > 0f);

            // Remember head-look state so we can restore it after dialogue.
            headLookWasEnabledBeforeDialogue = headLook != null && headLook.enabled;

            currentState = State.Talking;
            UpdateAnimatorBools();

            // Suppress head-look during dialogue; the dialogue UI takes the
            // player's attention so a head turn would be distracting.
            if (headLook != null) headLook.enabled = false;
        }

        private void HandleDialogueEnded()
        {
            if (currentState != State.Talking) return;

            // Restore head-look to whatever state it was in before
            // dialogue started (usually enabled, gated by distance).
            if (headLook != null) headLook.enabled = headLookWasEnabledBeforeDialogue;

            SwitchToIdleOrWalkingAfterDialogue();
        }

        // ─── Animator helpers ───────────────────────────────────────────

        private void UpdateAnimatorBools()
        {
            // IsTalking is the higher-priority signal. While in the
            // Talking state the child is frozen in place; IsMoving must
            // be false so the Walk->Idle transition can fire if a future
            // talk ends.
            switch (currentState)
            {
                case State.Talking:
                    SetAnimatorBool("IsMoving", false);
                    SetAnimatorBool("IsTalking", true);
                    break;
                case State.Walking:
                    SetAnimatorBool("IsMoving", true);
                    SetAnimatorBool("IsTalking", false);
                    break;
                case State.Idle:
                default:
                    SetAnimatorBool("IsMoving", false);
                    SetAnimatorBool("IsTalking", false);
                    break;
            }
        }

        /// <summary>
        /// SetBool wrapper that swallows null-animator cases. Designer
        /// might attach the wander controller before the prefab is fully
        /// rigged; we still want movement to work even if the animator
        /// hasn't been wired yet.
        /// </summary>
        private void SetAnimatorBool(string name, bool value)
        {
            if (animator == null) return;
            // SetBool is the AnimatorController parameter path; if the
            // parameter doesn't exist on the controller Unity logs an
            // error every frame. Guard with a one-shot param-existence
            // check to keep the console clean.
            if (!HasAnimatorParameter(name)) return;
            animator.SetBool(name, value);
        }

        private bool HasAnimatorParameter(string name)
        {
            if (animator == null) return false;
            if (animator.runtimeAnimatorController == null) return false;

            if (knownAnimatorParameters == null)
            {
                knownAnimatorParameters = new HashSet<string>();
                foreach (AnimatorControllerParameter p in animator.parameters)
                {
                    knownAnimatorParameters.Add(p.name);
                }
            }
            return knownAnimatorParameters.Contains(name);
        }
    }
}
