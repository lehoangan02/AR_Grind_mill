// ChildNpcQuestHook.cs
// Bridges the child NPC guide to the existing game-flow event sources
// (CookingQuestGuide + CropPlot + RicePlant + RiceThresher) and triggers a
// scripted proactive line when something noteworthy happens.
//
// All subscriptions are read-only: no game-flow source is modified. The hook
// looks up the dialogue controller's private graph / BeginDialogue / isTalking
// members via System.Reflection so NPCDialogueController stays untouched.
//
// Cooldown model (per plan):
//   perLineCooldown   = 6s  → the same key never fires twice in a row inside
//                             this window (each key has its own lastDeliveryTime).
//   crossLineCooldown = 3s  → any line, any key, never within 3s of the previous.
// On the first event ever seen the hook delivers the intro node; afterwards
// it maps events to specific nodes via the inspector-wired references.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Khoa.Farming;
using Unity.XR.CoreUtils;
using UnityEngine;
using AR_Grind_mill.Dialogue.Data;
using AR_Grind_mill.Dialogue.Runtime;

namespace AR_Grind_mill.Dialogue.ChildNpc
{
    /// <summary>
    /// Listens to cooking + farming events and triggers proactive dialogue lines
    /// on the child NPC. Movement (walking toward the player) is delegated to
    /// <c>WanderingGuideController</c> via its public <c>ForceGoto</c> method;
    /// dialogue triggering is delegated to <c>NPCDialogueController</c> via
    /// reflection so the runtime controller class is not modified.
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("AR Grind Mill/Dialogue/Child NPC/Quest Hook")]
    public class ChildNpcQuestHook : MonoBehaviour
    {
        // ─── Inspector wiring ──────────────────────────────────────────

        [Header("References (auto-resolved when left null)")]
        [Tooltip("NPC dialogue controller on this same NPC. graph field is mutated " +
                 "via reflection at delivery time; the BeginDialogue private method " +
                 "is invoked via reflection.")]
        [SerializeField] private NPCDialogueController dialogueController;

        [Tooltip("Movement controller for the child. ForceGoto(Vector3) is called " +
                 "to send the child toward a 1.5m horizontal offset from the player " +
                 "before each line is delivered.")]
        [SerializeField] private WanderingGuideController wander;

        [Header("Dialogue Nodes (ordered by source)")]
        [Tooltip("Spoken once on the very first event ever observed.")]
        [SerializeField] private DialogueNode introNode;

        [Tooltip("First plot state change to Tilled (PlowPlot).")]
        [SerializeField] private DialogueNode plowedNode;

        [Tooltip("First OnCropPlanted after the intro.")]
        [SerializeField] private DialogueNode plantedNode;

        [Tooltip("First RicePlant reaches CropState.ReadyToHarvest.")]
        [SerializeField] private DialogueNode harvestedNode;

        [Tooltip("First RiceBundleItem.isDry becomes true.")]
        [SerializeField] private DialogueNode driedNode;

        [Tooltip("First RiceThresher.OnRiceThreshed event after the intro.")]
        [SerializeField] private DialogueNode threshedNode;

        [Tooltip("Farewell line delivered on CookingQuestStep.Completed.")]
        [SerializeField] private DialogueNode farewellNode;

        [Tooltip("Cooking step nodes, indexed by (int)CookingQuestStep (0..9 = " +
                 "Step1_PourPaddy..Completed). Length must be 10.")]
        [SerializeField] private DialogueNode[] cookingStepNodes = new DialogueNode[10];

        [Header("Debounce")]
        [Tooltip("Per-line cooldown. The same event key cannot fire again within " +
                 "this many seconds.")]
        [Min(0f)]
        [SerializeField] private float perLineCooldown = 6f;

        [Tooltip("Cross-line cooldown. Any line cannot fire within this many " +
                 "seconds of the previous one (regardless of key).")]
        [Min(0f)]
        [SerializeField] private float crossLineCooldown = 3f;

        [Header("Delivery Parameters")]
        [Tooltip("Horizontal distance (m) the child tries to reach before the " +
                 "line is delivered. Used as offset from player when calling " +
                 "WanderingGuideController.ForceGoto.")]
        [Min(0f)]
        [SerializeField] private float approachOffset = 1.5f;

        [Tooltip("Proximity threshold (m) inside which the child is allowed to " +
                 "deliver the queued line. Coroutine waits for this distance.")]
        [Min(0f)]
        [SerializeField] private float deliverProximity = 2f;

        [Tooltip("How often (seconds) the polling coroutine scans for new " +
                 "CropPlot / RicePlant / RiceThresher instances.")]
        [Min(0.1f)]
        [SerializeField] private float pollInterval = 5f;

        [Tooltip("Horizontal-only angle (deg) for the approach offset. 0 = due " +
                 "east of the player, positive = counter-clockwise. Negative = " +
                 "deterministic so the same event type always approaches from the " +
                 "same side.")]
        [SerializeField] private float approachAngleDeg = -45f;

        // ─── Runtime state ─────────────────────────────────────────────

        // Cached references resolved at runtime.
        private CookingQuestGuide cookingGuide;
        private Transform playerTransform;

        // Polled subscriptions.
        private readonly HashSet<CropPlot> subscribedPlots = new HashSet<CropPlot>();
        private readonly HashSet<RicePlant> subscribedPlants = new HashSet<RicePlant>();
        private readonly HashSet<RiceThresher> subscribedThreshers = new HashSet<RiceThresher>();

        // Per-event debounce tracking. Stable string keys so different sources
        // can collide on purpose (e.g. several plowings → same key) and the
        // cooldown throttles them.
        private readonly Dictionary<string, float> lastDeliveryTimes = new Dictionary<string, float>();
        private float lastAnyDelivery = float.NegativeInfinity;

        // Tracks whether we've ever delivered the intro. After the first event
        // ever observed, introNode becomes the payload for that event and this
        // flag flips to true.
        private bool introDelivered;

        // Reflection cache.
        private static readonly BindingFlags PrivateInstance = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
        private FieldInfo graphFieldCached;
        private MethodInfo beginDialogueMethodCached;
        private FieldInfo isTalkingFieldCached;

        // Coroutine handle for the polling loop.
        private Coroutine pollCoroutine;

        // Tracks whether the NPCDialogueController reference had its graph
        // mutated by us so we can restore it on disable. The hook only
        // temporarily rewires entryNode for delivery; without restore the
        // editor-time graph would stay permanently mutated.
        private DialogueNode previousEntryNode;

        // Used to gate ForceGoto via SendMessage / reflection so the file
        // compiles even if WanderingGuideController hasn't landed yet (Todo 4
        // runs in parallel). At runtime, the public method is invoked directly
        // when the type exists.
        private static MethodInfo s_forceGotoMethod;

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
                    $"[{nameof(ChildNpcQuestHook)}] '{name}' could not resolve the VR " +
                    "player transform (XROrigin + Camera.main fallback). " +
                    "Proactive lines will fall back to the child's current position.",
                    this);
            }

            CacheReflectionTargets();
        }

        private void OnEnable()
        {
            ResolveCookingGuide();

            if (cookingGuide != null)
            {
                cookingGuide.OnStepChanged += HandleCookingStepChanged;
            }

            // Initial pass + start the polling coroutine.
            ScanAndSubscribeAll();

            if (pollCoroutine == null)
            {
                pollCoroutine = StartCoroutine(PollRoutine());
            }
        }

        private void OnDisable()
        {
            if (cookingGuide != null)
            {
                cookingGuide.OnStepChanged -= HandleCookingStepChanged;
            }
            cookingGuide = null;

            if (pollCoroutine != null)
            {
                StopCoroutine(pollCoroutine);
                pollCoroutine = null;
            }

            UnsubscribeAllPlots();
            UnsubscribeAllPlants();
            UnsubscribeAllThreshers();
        }

        // ─── Reflection cache ──────────────────────────────────────────

        private void CacheReflectionTargets()
        {
            if (dialogueController == null) return;

            Type t = dialogueController.GetType();

            // graph is declared public on NPCDialogueController but we treat it
            // through reflection anyway so the read/write path is uniform.
            graphFieldCached = t.GetField("graph", PrivateInstance);
            beginDialogueMethodCached = t.GetMethod("BeginDialogue",
                PrivateInstance, null, Type.EmptyTypes, null);
            isTalkingFieldCached = t.GetField("isTalking", PrivateInstance);

            if (graphFieldCached == null)
            {
                Debug.LogError(
                    $"[{nameof(ChildNpcQuestHook)}] Could not reflect NPCDialogueController.graph " +
                    "field. Dialogue delivery will be skipped.", this);
            }
            if (beginDialogueMethodCached == null)
            {
                Debug.LogError(
                    $"[{nameof(ChildNpcQuestHook)}] Could not reflect NPCDialogueController.BeginDialogue(). " +
                    "Dialogue delivery will be skipped.", this);
            }
            if (isTalkingFieldCached == null)
            {
                Debug.LogError(
                    $"[{nameof(ChildNpcQuestHook)}] Could not reflect NPCDialogueController.isTalking " +
                    "field. Debounce busy-check will be skipped.", this);
            }
        }

        // ─── Player / cooking-guide resolution ─────────────────────────

        private Transform ResolvePlayerTransform()
        {
            // Preferred: XROrigin (matches WanderingGuideController.Start and
            // NPCProximityTrigger.FindCameraTransform).
            XROrigin origin = FindObjectOfType<XROrigin>(includeInactive: true);
            if (origin != null) return origin.transform;

            // Fallback: camera main.
            Camera cam = Camera.main;
            if (cam != null) return cam.transform;

            return null;
        }

        private void ResolveCookingGuide()
        {
            if (cookingGuide != null) return;
            cookingGuide = FindObjectOfType<CookingQuestGuide>(includeInactive: true);
            if (cookingGuide == null)
            {
                Debug.LogWarning(
                    $"[{nameof(ChildNpcQuestHook)}] '{name}' could not find a CookingQuestGuide " +
                    "in the scene. Cooking-step lines will not fire.",
                    this);
            }
        }

        // ─── Polling loop ──────────────────────────────────────────────

        private IEnumerator PollRoutine()
        {
            // First wait one frame so other components finish OnEnable before
            // we mutate subscriptions.
            yield return null;

            while (true)
            {
                ScanAndSubscribeAll();
                yield return new WaitForSeconds(pollInterval);
            }
        }

        private void ScanAndSubscribeAll()
        {
            // Re-resolve the cooking guide each pass; if it loads late we
            // still pick it up before a cooking event fires.
            ResolveCookingGuide();

            // ─── CropPlot ─────────────────────────────────────────────
            CropPlot[] plots = FindObjectsOfType<CropPlot>(includeInactive: true);
            for (int i = 0; i < plots.Length; i++)
            {
                CropPlot plot = plots[i];
                if (plot == null) continue;
                if (subscribedPlots.Add(plot))
                {
                    plot.OnStateChanged += HandlePlotStateChanged;
                    plot.OnCropPlanted += HandleCropPlanted;
                    plot.OnCropHarvested += HandleCropHarvested;
                }
            }

            // Remove plots that have been destroyed or disabled.
            CleanupPlots();

            // ─── RicePlant (via each plot's currentCrop, reflective) ──
            CropPlot[] plotsForPlants = FindObjectsOfType<CropPlot>(includeInactive: true);
            for (int i = 0; i < plotsForPlants.Length; i++)
            {
                CropPlot plot = plotsForPlants[i];
                if (plot == null) continue;
                RicePlant plant = ReadPrivateField<RicePlant>(plot, "currentCrop");
                if (plant == null) continue;
                if (subscribedPlants.Add(plant))
                {
                    plant.OnCropStateChanged += HandleCropStateChanged;
                }
            }
            CleanupPlants();

            // ─── RiceThresher ─────────────────────────────────────────
            RiceThresher[] threshers = FindObjectsOfType<RiceThresher>(includeInactive: true);
            for (int i = 0; i < threshers.Length; i++)
            {
                RiceThresher thresher = threshers[i];
                if (thresher == null) continue;
                if (subscribedThreshers.Add(thresher))
                {
                    thresher.OnRiceThreshed += HandleRiceThreshed;
                }
            }
            CleanupThreshers();
        }

        private void CleanupPlots()
        {
            // Compact subscribedPlots in place; HashSet enumerator is safe to
            // mutate against a snapshot.
            List<CropPlot> stale = null;
            foreach (CropPlot p in subscribedPlots)
            {
                // Unity overload: a destroyed MonoBehaviour compares == null
                // even when the C# reference is non-null. Plot reference loss
                // (scene unload) shows up here.
                if (p == null)
                {
                    stale ??= new List<CropPlot>();
                    stale.Add(p);
                }
            }
            if (stale == null) return;
            for (int i = 0; i < stale.Count; i++)
            {
                CropPlot p = stale[i];
                // We can't unsubscribe on a destroyed reference; Unity no-ops
                // event -= on a null target inside its own delegate book,
                // but doing it explicitly is still safe.
                if (p != null)
                {
                    p.OnStateChanged -= HandlePlotStateChanged;
                    p.OnCropPlanted -= HandleCropPlanted;
                    p.OnCropHarvested -= HandleCropHarvested;
                }
                subscribedPlots.Remove(p);
            }
        }

        private void CleanupPlants()
        {
            List<RicePlant> stale = null;
            foreach (RicePlant plant in subscribedPlants)
            {
                if (plant == null)
                {
                    stale ??= new List<RicePlant>();
                    stale.Add(plant);
                }
            }
            if (stale == null) return;
            for (int i = 0; i < stale.Count; i++)
            {
                RicePlant plant = stale[i];
                if (plant != null)
                {
                    plant.OnCropStateChanged -= HandleCropStateChanged;
                }
                subscribedPlants.Remove(plant);
            }
        }

        private void CleanupThreshers()
        {
            List<RiceThresher> stale = null;
            foreach (RiceThresher thresher in subscribedThreshers)
            {
                if (thresher == null)
                {
                    stale ??= new List<RiceThresher>();
                    stale.Add(thresher);
                }
            }
            if (stale == null) return;
            for (int i = 0; i < stale.Count; i++)
            {
                RiceThresher thresher = stale[i];
                if (thresher != null)
                {
                    thresher.OnRiceThreshed -= HandleRiceThreshed;
                }
                subscribedThreshers.Remove(thresher);
            }
        }

        private void UnsubscribeAllPlots()
        {
            foreach (CropPlot p in subscribedPlots)
            {
                if (p == null) continue;
                p.OnStateChanged -= HandlePlotStateChanged;
                p.OnCropPlanted -= HandleCropPlanted;
                p.OnCropHarvested -= HandleCropHarvested;
            }
            subscribedPlots.Clear();
        }

        private void UnsubscribeAllPlants()
        {
            foreach (RicePlant plant in subscribedPlants)
            {
                if (plant == null) continue;
                plant.OnCropStateChanged -= HandleCropStateChanged;
            }
            subscribedPlants.Clear();
        }

        private void UnsubscribeAllThreshers()
        {
            foreach (RiceThresher thresher in subscribedThreshers)
            {
                if (thresher == null) continue;
                thresher.OnRiceThreshed -= HandleRiceThreshed;
            }
            subscribedThreshers.Clear();
        }

        // ─── Event handlers ───────────────────────────────────────────

        private void HandleCookingStepChanged(CookingQuestStep step)
        {
            DialogueNode node;
            int idx = (int)step;
            string key;

            // Step1_PourPaddy → intro on first ever, then cooking[0].
            // Subsequent steps index into cookingStepNodes[stepIndex-1] (the
            // plan's spec: length 10, indexed by (int)CookingQuestStep, so
            // Step1→0, Step2→1, ..., Step9→8, Completed→9).
            if (!introDelivered && idx >= 0)
            {
                key = "intro";
                node = introNode;
            }
            else if (idx >= 0 && idx < cookingStepNodes.Length)
            {
                key = $"cooking:{step}";
                node = cookingStepNodes[idx];
            }
            else
            {
                return; // unknown step, drop silently.
            }

            HandleEvent(key, node);
        }

        private void HandlePlotStateChanged(PlotState state)
        {
            if (state != PlotState.Tilled) return;
            DialogueNode node = introDelivered ? plowedNode : introNode;
            HandleEvent("plot:tilled", node);
        }

        private void HandleCropPlanted(CropPlot plot)
        {
            DialogueNode node = introDelivered ? plantedNode : introNode;
            HandleEvent("crop:planted", node);
        }

        private void HandleCropHarvested(CropPlot plot)
        {
            DialogueNode node = introDelivered ? harvestedNode : introNode;
            HandleEvent("crop:harvested", node);
        }

        private void HandleCropStateChanged(CropState state)
        {
            if (state != CropState.ReadyToHarvest) return;
            DialogueNode node = introDelivered ? harvestedNode : introNode;
            HandleEvent("plant:ready", node);
        }

        private void HandleRiceThreshed(int grains)
        {
            DialogueNode node = introDelivered ? threshedNode : introNode;
            HandleEvent("threshed", node);
        }

        // ─── Per-event dispatch ───────────────────────────────────────

        private void HandleEvent(string key, DialogueNode node)
        {
            if (node == null)
            {
                // Designer hasn't wired this node yet — silently skip.
                return;
            }

            float now = Time.unscaledTime;

            // Per-line cooldown.
            if (lastDeliveryTimes.TryGetValue(key, out float lastForKey))
            {
                if (now - lastForKey < perLineCooldown)
                {
                    Debug.Log($"[ChildNpcQuestHook] Debounced: {key}");
                    return;
                }
            }

            // Cross-line cooldown.
            if (now - lastAnyDelivery < crossLineCooldown)
            {
                Debug.Log($"[ChildNpcQuestHook] Debounced: {key}");
                return;
            }

            // Busy check via reflection (NPCDialogueController.isTalking).
            if (IsDialogueControllerTalking())
            {
                Debug.Log($"[ChildNpcQuestHook] Debounced: {key}");
                return;
            }

            // Bookkeeping BEFORE delivery so a re-entrant event inside the
            // coroutine sees fresh timestamps.
            lastDeliveryTimes[key] = now;
            lastAnyDelivery = now;

            // First event ever → swap to intro on the SAME payload. After
            // this delivery, introDelivered flips and subsequent events map
            // to their dedicated nodes.
            if (!introDelivered)
            {
                introDelivered = true;
                if (introNode != null)
                {
                    node = introNode;
                }
            }

            // Send the child toward a horizontal offset from the player so
            // they're close enough for the proximity + busy check to clear.
            Vector3 target = ComputeApproachTarget();

            // Deliver on a coroutine so we can wait for the proximity gate.
            StartCoroutine(DeliverWhenReady(key, node, target));
        }

        private IEnumerator DeliverWhenReady(string key, DialogueNode node, Vector3 target)
        {
            // Walk the child toward the approach point. ForceGoto is a hint;
            // WanderingGuideController may take time to actually arrive.
            TryCallForceGoto(target);

            // Wait for proximity (and the controller to be idle).
            float safetyTimeout = perLineCooldown * 4f + 2f;
            float waited = 0f;
            while (waited < safetyTimeout)
            {
                if (playerTransform != null &&
                    Vector3.Distance(transform.position, playerTransform.position) <= deliverProximity &&
                    !IsDialogueControllerTalking())
                {
                    break;
                }

                // If the dialogue controller started talking from somewhere
                // else (e.g. reactive press), bail out — our line would be
                // queued behind it.
                if (IsDialogueControllerTalking())
                {
                    yield break;
                }

                yield return new WaitForSeconds(0.1f);
                waited += 0.1f;
            }

            TriggerDialogue(node);
        }

        // ─── Trigger via reflection ────────────────────────────────────

        private void TriggerDialogue(DialogueNode node)
        {
            if (dialogueController == null || node == null) return;
            if (graphFieldCached == null || beginDialogueMethodCached == null) return;

            object currentGraph = graphFieldCached.GetValue(dialogueController);
            if (currentGraph is DialogueGraph graph)
            {
                previousEntryNode = graph.entryNode;
                graph.entryNode = node;
            }
            else
            {
                Debug.LogWarning(
                    $"[{nameof(ChildNpcQuestHook)}] dialogueController.graph is not a " +
                    $"DialogueGraph (got {currentGraph?.GetType().Name ?? "null"}); " +
                    "delivery aborted.",
                    this);
                return;
            }

            try
            {
                beginDialogueMethodCached.Invoke(dialogueController, null);
            }
            catch (Exception ex)
            {
                Debug.LogError(
                    $"[{nameof(ChildNpcQuestHook)}] BeginDialogue threw: {ex.Message}",
                    this);
            }
            finally
            {
                // Restore so the next BeginDialogue (e.g. reactive press)
                // starts from the graph's real entry, not our swapped node.
                if (currentGraph is DialogueGraph g && previousEntryNode != null)
                {
                    g.entryNode = previousEntryNode;
                }
            }
        }

        private bool IsDialogueControllerTalking()
        {
            if (dialogueController == null || isTalkingFieldCached == null) return false;
            object v = isTalkingFieldCached.GetValue(dialogueController);
            return v is bool b && b;
        }

        // ─── ForceGoto via SendMessage/reflection (cross-worker safe) ─

        private void TryCallForceGoto(Vector3 worldPos)
        {
            if (wander == null) return;

            // Fast path: if WanderingGuideController already exists in the
            // compiled assembly, call its public ForceGoto directly.
            Type wType = wander.GetType();
            if (s_forceGotoMethod == null || s_forceGotoMethod.DeclaringType != wType)
            {
                s_forceGotoMethod = wType.GetMethod("ForceGoto",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                    null, new Type[] { typeof(Vector3) }, null);
            }

            if (s_forceGotoMethod != null)
            {
                try
                {
                    s_forceGotoMethod.Invoke(wander, new object[] { worldPos });
                    return;
                }
                catch (Exception ex)
                {
                    Debug.LogWarning(
                        $"[{nameof(ChildNpcQuestHook)}] ForceGoto reflection threw: {ex.Message}",
                        this);
                }
            }

            // Last-resort fallback: SendMessage ignores access modifiers and
            // only requires the method to exist on any attached component.
            wander.SendMessage("ForceGoto", worldPos, SendMessageOptions.DontRequireReceiver);
        }

        // ─── Helpers ───────────────────────────────────────────────────

        private Vector3 ComputeApproachTarget()
        {
            if (playerTransform == null) return transform.position;

            float angleRad = approachAngleDeg * Mathf.Deg2Rad;
            // Horizontal-only: zero out Y so the child approaches on the same
            // plane as the player instead of trying to fly to their head.
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

            // Rotate forward by approachAngleDeg around Y.
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

        // ─── Reflection helper (used to read CropPlot.currentCrop) ─────

        private static T ReadPrivateField<T>(object target, string name) where T : class
        {
            if (target == null) return null;
            FieldInfo f = target.GetType().GetField(name, PrivateInstance);
            if (f == null) return null;
            return f.GetValue(target) as T;
        }
    }
}
