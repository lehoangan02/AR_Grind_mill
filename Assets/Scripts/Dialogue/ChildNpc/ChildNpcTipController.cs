// ChildNpcTipController.cs
//
// Drives the child NPC's periodic tip behaviour: every 45-75 seconds (configurable),
// picks a random tip from the inspector-wired pool, walks over to the player via
// WanderingGuideController.ForceGoto, waits until in proximity, then delivers the
// tip by temporarily swapping the dialogue graph's entry node and invoking
// NPCDialogueController.BeginDialogue via reflection.
//
// This is the only proactive dialogue source for the child. All previous quest /
// cooking / farming-event subscriptions live in the now-removed
// ChildNpcQuestHook; the child no longer guides the player through any task — it
// simply wanders, watches, and offers the occasional neighbourly tip.
//
// Reactive fallback: pressing the start action near the child still triggers the
// graph's normal entry node (Intro). The tip loop subscribes to DialogueEvents
// and pauses both the timer and any in-flight delivery while ANY NPC in the
// scene is talking — so a tip never collides with a reactive conversation or
// with another NPC's line.
//
// Delivery mechanism mirrors the (now-removed) ChildNpcQuestHook pattern:
//   1. cache graph / BeginDialogue / isTalking via reflection at Awake;
//   2. save the graph's current entryNode;
//   3. set graph.entryNode = tipNode; invoke BeginDialogue();
//   4. restore entryNode in a finally block so the next reactive press starts
//      at the graph's real entry, not our swapped tip.
// The same swap/restore is wrapped in a try/finally to guarantee the entry
// node is restored even if BeginDialogue throws.
//
// No NavMesh, no agent. Movement comes from WanderingGuideController.Ground-snap
// + ForceGoto. Cooldown is per-cycle, not per-line: after a tip is delivered the
// timer fully resets, then a fresh random [minDelay, maxDelay] window starts.
// The last delivered tip is excluded from the next pick so the player does not
// hear the same line twice in a row.

using System;
using System.Collections;
using System.Reflection;
using Unity.XR.CoreUtils;
using UnityEngine;
using AR_Grind_mill.Dialogue.Data;
using AR_Grind_mill.Dialogue.Runtime;

namespace AR_Grind_mill.Dialogue.ChildNpc
{
    /// <summary>
    /// Periodic-tip scheduler and one-off delivery controller for the child NPC.
    /// Sits next to <see cref="WanderingGuideController"/> on the same GameObject.
    /// Movement is delegated to the wander controller; this component owns the
    /// schedule, the proximity gate, and the entry-node swap that lets the child
    /// speak any pool node without changing <see cref="NPCDialogueController"/>.
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("AR Grind Mill/Dialogue/Child NPC/Tip Controller")]
    public class ChildNpcTipController : MonoBehaviour
    {
        // ─── Inspector wiring ──────────────────────────────────────────

        [Header("References (auto-resolved when left null)")]
        [Tooltip("NPC dialogue controller on this same NPC. Used as the delivery " +
                 "target — its private BeginDialogue() is invoked via reflection after " +
                 "temporarily swapping graph.entryNode.")]
        [SerializeField] private NPCDialogueController dialogueController;

        [Tooltip("Wandering controller on this same NPC. ForceGoto(Vector3) is called " +
                 "to send the child toward a horizontal offset from the player before " +
                 "each tip is delivered.")]
        [SerializeField] private WanderingGuideController wander;

        [Header("Tip Pool")]
        [Tooltip("Dialogue nodes the child may speak as tips. Each must have isEndNode " +
                 "true and an empty choices list (the tip is a single auto-advancing line).")]
        [SerializeField] private DialogueNode[] tips;

        [Header("Schedule (seconds)")]
        [Tooltip("Lower bound of the random delay between tip deliveries.")]
        [Min(0f)]
        [SerializeField] private float minDelaySeconds = 45f;

        [Tooltip("Upper bound of the random delay between tip deliveries.")]
        [Min(0f)]
        [SerializeField] private float maxDelaySeconds = 75f;

        [Tooltip("Initial wait before the FIRST tip is considered. Gives the player " +
                 "a moment to settle into the scene before the child speaks.")]
        [Min(0f)]
        [SerializeField] private float firstDelaySeconds = 15f;

        [Header("Delivery")]
        [Tooltip("Horizontal distance (m) the child tries to reach before delivering. " +
                 "Used as offset from player when calling WanderingGuideController.ForceGoto.")]
        [Min(0f)]
        [SerializeField] private float approachOffset = 1.5f;

        [Tooltip("Horizontal-only angle (deg) for the approach offset. 0 = due east " +
                 "of the player, positive = counter-clockwise. Negative = deterministic " +
                 "so the same delivery always approaches from the same side.")]
        [SerializeField] private float approachAngleDeg = -45f;

        [Tooltip("Proximity threshold (m) inside which the child is allowed to deliver. " +
                 "Coroutine waits for this distance before triggering the line.")]
        [Min(0f)]
        [SerializeField] private float deliverProximity = 2f;

        [Tooltip("Maximum seconds the child will wait to reach the proximity threshold " +
                 "before giving up on the current tip and rescheduling. Keeps a stuck " +
                 "wander from freezing the schedule.")]
        [Min(1f)]
        [SerializeField] private float deliveryTimeoutSeconds = 30f;

        // ─── Runtime state ─────────────────────────────────────────────

        private Coroutine tipLoop;
        private Transform playerTransform;

        // Tracks whether ANY NPC is currently in a conversation (reactive or proactive).
        // Toggled by DialogueEvents subscribers — we do not need a per-NPC flag because
        // the tip loop pauses on any global dialogue, not just our own.
        private bool anyDialogueActive;

        // Last delivered tip index; -1 = none yet. Used to avoid repeating the same
        // tip twice in a row even when the pool only has 2-3 nodes.
        private int lastDeliveredIndex = -1;

        // ─── Reflection cache (mirrors the pattern from ChildNpcQuestHook so the
        //     NPCDialogueController source stays untouched and the same swap/restore
        //     trick plays nicely with reactive conversations) ───────────────

        private static readonly BindingFlags PrivateInstance =
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

        private FieldInfo graphFieldCached;
        private MethodInfo beginDialogueMethodCached;
        private FieldInfo isTalkingFieldCached;

        // Tracks whether we mutated graph.entryNode so OnDisable can restore it.
        // Without this the editor-time entry node would stay permanently swapped
        // to the last delivered tip.
        private DialogueNode previousEntryNode;
        private bool entryNodeSwapped;

        // ─── Lifecycle ─────────────────────────────────────────────────

        private void Awake()
        {
            if (dialogueController == null)
            {
                dialogueController = GetComponent<NPCDialogueController>();
            }

            if (wander == null)
            {
                wander = GetComponent<WanderingGuideController>();
            }

            playerTransform = ResolvePlayerTransform();
            if (playerTransform == null)
            {
                Debug.LogWarning(
                    $"[{nameof(ChildNpcTipController)}] '{name}' could not resolve the VR " +
                    "player transform (XROrigin + Camera.main fallback). Tips will fall " +
                    "back to the child's current position.",
                    this);
            }

            CacheReflectionTargets();
            ValidateTipPool();
        }

        private void OnEnable()
        {
            DialogueEvents.OnDialogueStarted += HandleDialogueStarted;
            DialogueEvents.OnDialogueEnded   += HandleDialogueEnded;

            if (tipLoop == null)
            {
                tipLoop = StartCoroutine(TipLoopCoroutine());
            }
        }

        private void OnDisable()
        {
            DialogueEvents.OnDialogueStarted -= HandleDialogueStarted;
            DialogueEvents.OnDialogueEnded   -= HandleDialogueEnded;

            if (tipLoop != null)
            {
                StopCoroutine(tipLoop);
                tipLoop = null;
            }

            // If we swapped the graph entry node mid-delivery, restore it so the
            // next reactive conversation starts at the graph's real entry.
            RestoreEntryNodeIfSwapped();
        }

        // ─── Reflection cache ──────────────────────────────────────────

        private void CacheReflectionTargets()
        {
            if (dialogueController == null) return;

            Type t = dialogueController.GetType();
            graphFieldCached        = t.GetField("graph", PrivateInstance);
            beginDialogueMethodCached = t.GetMethod("BeginDialogue",
                PrivateInstance, null, Type.EmptyTypes, null);
            isTalkingFieldCached    = t.GetField("isTalking", PrivateInstance);

            if (graphFieldCached == null)
            {
                Debug.LogError(
                    $"[{nameof(ChildNpcTipController)}] Could not reflect NPCDialogueController.graph. " +
                    "Tip delivery will be skipped.", this);
            }
            if (beginDialogueMethodCached == null)
            {
                Debug.LogError(
                    $"[{nameof(ChildNpcTipController)}] Could not reflect NPCDialogueController.BeginDialogue. " +
                    "Tip delivery will be skipped.", this);
            }
        }

        // ─── Pool validation ───────────────────────────────────────────

        private void ValidateTipPool()
        {
            if (tips == null || tips.Length == 0)
            {
                Debug.LogWarning(
                    $"[{nameof(ChildNpcTipController)}] '{name}' has no tips wired in the Inspector. " +
                    "No tips will be delivered until at least one DialogueNode is assigned.",
                    this);
                return;
            }

            int nullCount = 0;
            for (int i = 0; i < tips.Length; i++)
            {
                if (tips[i] == null) nullCount++;
            }

            if (nullCount > 0)
            {
                Debug.LogWarning(
                    $"[{nameof(ChildNpcTipController)}] '{name}' has {nullCount} null entries in the tip pool " +
                    "(of " + tips.Length + "). Those slots will be skipped.",
                    this);
            }
        }

        // ─── Player resolution ─────────────────────────────────────────

        private Transform ResolvePlayerTransform()
        {
            // Same fallback chain as WanderingGuideController.Start and the
            // (removed) ChildNpcQuestHook: XROrigin first, Camera.main second.
            XROrigin origin = FindObjectOfType<XROrigin>(includeInactive: true);
            if (origin != null) return origin.transform;

            Camera cam = Camera.main;
            if (cam != null) return cam.transform;

            return null;
        }

        // ─── Tip loop ──────────────────────────────────────────────────

        private IEnumerator TipLoopCoroutine()
        {
            // Initial wait so the player can settle in before the first tip.
            float initialWait = Mathf.Max(0f, firstDelaySeconds);
            if (initialWait > 0f)
            {
                yield return new WaitForSeconds(initialWait);
            }

            while (true)
            {
                // Schedule the next tip with a fresh random delay. We wait BEFORE
                // picking so a long delay doesn't get eaten by an in-flight delivery.
                float delay = RandomDelay();
                yield return new WaitForSeconds(delay);

                // Bail if any NPC is currently in a conversation — reactive (player
                // press) or another proactive delivery. We resume next iteration.
                if (anyDialogueActive)
                {
                    continue;
                }

                int index = PickTipIndex();
                if (index < 0)
                {
                    // Empty / null pool — try again next cycle.
                    continue;
                }

                yield return DeliverTip(tips[index]);
            }
        }

        private float RandomDelay()
        {
            float lo = Mathf.Min(minDelaySeconds, maxDelaySeconds);
            float hi = Mathf.Max(minDelaySeconds, maxDelaySeconds);
            return UnityEngine.Random.Range(lo, hi);
        }

        /// <summary>
        /// Pick a random non-null tip from the pool, avoiding the most-recently
        /// delivered index so the same line never repeats back-to-back.
        /// Returns -1 if no valid tip is available.
        /// </summary>
        private int PickTipIndex()
        {
            if (tips == null || tips.Length == 0) return -1;

            // Count valid (non-null) entries first so we can choose uniformly
            // without biasing against the null slots.
            int validCount = 0;
            for (int i = 0; i < tips.Length; i++)
            {
                if (tips[i] != null) validCount++;
            }
            if (validCount == 0) return -1;

            // Walk the pool in random order; return the first valid entry that
            // is NOT the last delivered one. If every valid entry equals
            // lastDeliveredIndex (degenerate single-tip pool), fall back to it.
            int start = UnityEngine.Random.Range(0, tips.Length);
            for (int step = 0; step < tips.Length; step++)
            {
                int i = (start + step) % tips.Length;
                if (tips[i] == null) continue;
                if (validCount == 1) return i;
                if (i != lastDeliveredIndex) return i;
            }

            // Shouldn't reach here — validCount > 0 — but be defensive.
            for (int i = 0; i < tips.Length; i++)
            {
                if (tips[i] != null) return i;
            }
            return -1;
        }

        // ─── Delivery ──────────────────────────────────────────────────

        private IEnumerator DeliverTip(DialogueNode node)
        {
            if (node == null) yield break;

            // Step 1: send the child toward the approach point so the proximity
            // gate can clear promptly. ForceGoto is a hint — the wander controller
            // may take time to actually arrive.
            Vector3 target = ComputeApproachTarget();
            TryCallForceGoto(target);

            // Step 2: wait for proximity, with a hard timeout so a stuck wander
            // never freezes the schedule. Bail early if a reactive conversation
            // starts up while we're walking.
            float waited = 0f;
            while (waited < deliveryTimeoutSeconds)
            {
                if (anyDialogueActive)
                {
                    // Reactive conversation took priority — drop this tip. The
                    // outer loop will wait its full delay before trying again.
                    yield break;
                }

                if (IsWithinProximity())
                {
                    break;
                }

                yield return new WaitForSeconds(0.1f);
                waited += 0.1f;
            }

            // Step 3: re-check before delivery — a reactive conversation may have
            // started during the final wait tick.
            if (anyDialogueActive)
            {
                yield break;
            }

            // Step 4: deliver.
            int deliveredIndex = IndexOf(node);
            if (TriggerDialogue(node))
            {
                lastDeliveredIndex = deliveredIndex;
            }
        }

        private bool IsWithinProximity()
        {
            if (playerTransform == null) return true; // no player → can't gate
            return Vector3.Distance(transform.position, playerTransform.position) <= deliverProximity;
        }

        private int IndexOf(DialogueNode node)
        {
            if (tips == null) return -1;
            for (int i = 0; i < tips.Length; i++)
            {
                if (tips[i] == node) return i;
            }
            return -1;
        }

        // ─── Delivery trigger (entry-node swap trick) ─────────────────

        /// <summary>
        /// Swap the graph's entry node to <paramref name="node"/> and invoke the
        /// private <c>BeginDialogue()</c>. Returns true on success. The entry node
        /// is restored in <see cref="RestoreEntryNodeIfSwapped"/> regardless of
        /// whether the invocation threw, so reactive conversations always start
        /// from the graph's real entry.
        /// </summary>
        private bool TriggerDialogue(DialogueNode node)
        {
            if (dialogueController == null || node == null) return false;
            if (graphFieldCached == null || beginDialogueMethodCached == null) return false;

            object currentGraph = graphFieldCached.GetValue(dialogueController);
            if (!(currentGraph is DialogueGraph graph))
            {
                Debug.LogWarning(
                    $"[{nameof(ChildNpcTipController)}] dialogueController.graph is not a " +
                    $"DialogueGraph (got {currentGraph?.GetType().Name ?? "null"}); " +
                    "delivery aborted.",
                    this);
                return false;
            }

            // Save + swap. Restore in finally so an exception in BeginDialogue
            // cannot leave the graph pointing at a tip node.
            previousEntryNode = graph.entryNode;
            graph.entryNode = node;
            entryNodeSwapped = true;

            try
            {
                beginDialogueMethodCached.Invoke(dialogueController, null);
                return true;
            }
            catch (Exception ex)
            {
                Debug.LogError(
                    $"[{nameof(ChildNpcTipController)}] BeginDialogue threw: {ex.Message}",
                    this);
                return false;
            }
            finally
            {
                RestoreEntryNodeIfSwapped();
            }
        }

        private void RestoreEntryNodeIfSwapped()
        {
            if (!entryNodeSwapped) return;
            entryNodeSwapped = false;

            if (graphFieldCached == null || dialogueController == null) return;

            object currentGraph = graphFieldCached.GetValue(dialogueController);
            if (currentGraph is DialogueGraph graph && previousEntryNode != null)
            {
                graph.entryNode = previousEntryNode;
            }
            previousEntryNode = null;
        }

        // ─── ForceGoto via reflection (cross-worker safe) ──────────────
        // Same pattern ChildNpcQuestHook used — survives even if
        // WanderingGuideController hasn't been compiled into the same assembly yet.

        private void TryCallForceGoto(Vector3 worldPos)
        {
            if (wander == null) return;

            Type wType = wander.GetType();
            MethodInfo forceGoto = wType.GetMethod("ForceGoto",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                null, new Type[] { typeof(Vector3) }, null);

            if (forceGoto != null)
            {
                try
                {
                    forceGoto.Invoke(wander, new object[] { worldPos });
                    return;
                }
                catch (Exception ex)
                {
                    Debug.LogWarning(
                        $"[{nameof(ChildNpcTipController)}] ForceGoto reflection threw: {ex.Message}",
                        this);
                }
            }

            // Last-resort fallback: SendMessage ignores access modifiers and only
            // requires the method to exist on any attached component.
            wander.SendMessage("ForceGoto", worldPos, SendMessageOptions.DontRequireReceiver);
        }

        // ─── Helpers ───────────────────────────────────────────────────

        private Vector3 ComputeApproachTarget()
        {
            if (playerTransform == null) return transform.position;

            float angleRad = approachAngleDeg * Mathf.Deg2Rad;
            Vector3 forward = playerTransform.forward;
            forward.y = 0f;
            if (forward.sqrMagnitude < 0.001f)
            {
                forward = Vector3.forward;
            }
            else
            {
                forward.Normalize();
            }

            float cosA = Mathf.Cos(angleRad);
            float sinA = Mathf.Sin(angleRad);
            Vector3 rotated = new Vector3(
                forward.x * cosA - forward.z * sinA,
                0f,
                forward.x * sinA + forward.z * cosA);

            Vector3 origin = playerTransform.position;
            origin.y = transform.position.y; // keep on child's plane
            return origin + rotated * approachOffset;
        }

        // ─── Dialogue event handlers ───────────────────────────────────

        private void HandleDialogueStarted(DialogueGraph graph)
        {
            anyDialogueActive = true;
        }

        private void HandleDialogueEnded()
        {
            anyDialogueActive = false;
        }
    }
}

