using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using AR_Grind_mill.Dialogue.Data;

namespace AR_Grind_mill.Dialogue.Runtime
{
    /// <summary>
    /// Per-NPC orchestrator. Owns the dialogue graph, drives the animator + head look,
    /// listens for the player's start action while they are in proximity, and emits the
    /// shared <see cref="DialogueEvents"/> so the UI layer can render the conversation.
    ///
    /// Wiring (Inspector):
    ///   graph              — DialogueGraph ScriptableObject (assignable at runtime)
    ///   proximityTrigger   — NPCProximityTrigger on the same NPC root
    ///   animatorDriver     — NPCAnimatorDriver on the same NPC root
    ///   headLook           — HeadLookAtPlayer on the head bone (or anywhere)
    ///   startAction        — InputActionReference, bind to &lt;XRController&gt;/{PrimaryAction}
    ///   endAction          — InputActionReference, optional, lets player dismiss early
    /// </summary>
    public class NPCDialogueController : MonoBehaviour
    {
        [Header("Dialogue")]
        [Tooltip("Dialogue graph asset played when the player presses the start action while in range.")]
        public DialogueGraph graph;

        [Header("Components")]
        [Tooltip("Proximity sphere that tells us whether the player can start a conversation.")]
        public NPCProximityTrigger proximityTrigger;

        [Tooltip("Animator + voice wrapper. Talks / plays gestures / plays voice clips.")]
        public NPCAnimatorDriver animatorDriver;

        [Tooltip("Head look-at-player rig. Enabled only while talking.")]
        public HeadLookAtPlayer headLook;

        [Header("VR Input")]
        [Tooltip("Action that BEGINS a conversation. Bind to <XRController>/{PrimaryAction} (trigger).")]
        public InputActionReference startAction;

        [Tooltip("Optional action that ENDS a conversation early (e.g. right-hand grip).")]
        public InputActionReference endAction;

        private DialogueNode currentNode;
        private IReadOnlyList<DialogueChoice> currentChoices;
        private bool isTalking;
        private float autoAdvanceTimer;

        private bool startActionWasEnabled;
        private bool endActionWasEnabled;

        // ──────────────────────────────────────────────────────────────────────
        // Lifecycle
        // ──────────────────────────────────────────────────────────────────────

        private void Awake()
        {
            if (graph == null)
            {
                Debug.LogError(
                    $"[{nameof(NPCDialogueController)}] '{name}' has no DialogueGraph assigned. " +
                    $"Drag a graph asset into the Inspector.",
                    this);
            }
            if (animatorDriver == null)
            {
                Debug.LogError(
                    $"[{nameof(NPCDialogueController)}] '{name}' has no NPCAnimatorDriver assigned.",
                    this);
            }
            if (proximityTrigger == null)
            {
                Debug.LogError(
                    $"[{nameof(NPCDialogueController)}] '{name}' has no NPCProximityTrigger assigned.",
                    this);
            }
        }

        private void OnEnable()
        {
            // Player input → choice/route selection (raised by UI buttons).
            DialogueEvents.OnChoiceSelected += OnChoiceSelectedHandler;

            // Proximity gating — only let the start action fire while we can talk.
            DialogueEvents.OnProximityChanged += OnProximityChanged;

            // Wire input action callbacks + enable the start action conditionally.
            if (startAction != null && startAction.action != null)
            {
                startAction.action.performed += OnStartPerformed;
                bool inRange = proximityTrigger != null && proximityTrigger.IsPlayerInRange;
                if (inRange)
                {
                    startAction.action.Enable();
                    startActionWasEnabled = true;
                }
            }

            if (endAction != null && endAction.action != null)
            {
                endAction.action.performed += OnEndPerformed;
                // End action is always available while we're alive; controller decides
                // whether to do anything with it.
                endAction.action.Enable();
                endActionWasEnabled = true;
            }
        }

        private void OnDisable()
        {
            DialogueEvents.OnChoiceSelected -= OnChoiceSelectedHandler;
            DialogueEvents.OnProximityChanged -= OnProximityChanged;

            if (startAction != null && startAction.action != null)
            {
                startAction.action.performed -= OnStartPerformed;
                if (startActionWasEnabled)
                {
                    startAction.action.Disable();
                    startActionWasEnabled = false;
                }
            }

            if (endAction != null && endAction.action != null)
            {
                endAction.action.performed -= OnEndPerformed;
                if (endActionWasEnabled)
                {
                    endAction.action.Disable();
                    endActionWasEnabled = false;
                }
            }

            if (isTalking)
            {
                EndDialogue();
            }
        }

        private void Update()
        {
            if (!isTalking) return;
            if (currentNode == null) return;

            float autoAdvance = currentNode.line.autoAdvanceAfter;
            if (autoAdvance <= 0f) return;

            autoAdvanceTimer -= Time.deltaTime;
            if (autoAdvanceTimer <= 0f)
            {
                autoAdvanceTimer = 0f;
                AdvanceToNext(-1);
            }
        }

        // ──────────────────────────────────────────────────────────────────────
        // Event handlers
        // ──────────────────────────────────────────────────────────────────────

        private void OnStartPerformed(InputAction.CallbackContext ctx)
        {
            if (isTalking) return;
            if (proximityTrigger == null || !proximityTrigger.IsPlayerInRange) return;
            if (graph == null) return;

            BeginDialogue();
        }

        private void OnEndPerformed(InputAction.CallbackContext ctx)
        {
            if (!isTalking) return;
            EndDialogue();
        }

        private void OnProximityChanged(Transform source, bool isInRange)
        {
            if (proximityTrigger == null || source != proximityTrigger.transform) return;
            if (startAction == null || startAction.action == null) return;

            if (isInRange)
            {
                if (!startAction.action.enabled)
                {
                    startAction.action.Enable();
                }
                startActionWasEnabled = true;
            }
            else
            {
                if (startAction.action.enabled)
                {
                    startAction.action.Disable();
                }
                startActionWasEnabled = false;

                // Walked away mid-conversation → clean up.
                if (isTalking)
                {
                    EndDialogue();
                }
            }
        }

        private void OnChoiceSelectedHandler(int index)
        {
            if (!isTalking) return;
            AdvanceToNext(index);
        }

        // ──────────────────────────────────────────────────────────────────────
        // Conversation flow
        // ──────────────────────────────────────────────────────────────────────

        private void BeginDialogue()
        {
            isTalking = true;
            currentNode = graph != null ? graph.GetEntry() : null;
            if (currentNode == null)
            {
                Debug.LogWarning(
                    $"[{nameof(NPCDialogueController)}] '{name}' tried to begin dialogue but graph has no entry node.",
                    this);
                EndDialogue();
                return;
            }

            if (animatorDriver != null)
            {
                animatorDriver.SetTalking(true);
            }
            if (headLook != null)
            {
                headLook.SetActive(true);
            }

            DialogueEvents.RaiseDialogueStarted(graph);
            PresentCurrentNode();
        }

        private void AdvanceToNext(int choiceIndex)
        {
            if (currentNode == null)
            {
                EndDialogue();
                return;
            }

            // Auto-advance (choiceIndex < 0) OR terminal node → end conversation.
            if (choiceIndex < 0 || currentNode.IsTerminal())
            {
                EndDialogue();
                return;
            }

            DialogueNode next = currentNode.GetNext(choiceIndex);
            if (next == null)
            {
                EndDialogue();
                return;
            }

            currentNode = next;
            PresentCurrentNode();
        }

        private void EndDialogue()
        {
            if (!isTalking) return;

            if (animatorDriver != null)
            {
                animatorDriver.SetTalking(false);
            }
            if (headLook != null)
            {
                headLook.SetActive(false);
            }

            DialogueEvents.RaiseDialogueEnded();

            isTalking = false;
            currentNode = null;
            currentChoices = null;
            autoAdvanceTimer = 0f;
        }

        private void PresentCurrentNode()
        {
            if (currentNode == null) return;

            // Cache choices for the UI layer.
            List<DialogueChoice> choicesSource = currentNode.choices;
            currentChoices = choicesSource != null
                ? choicesSource.AsReadOnly()
                : (IReadOnlyList<DialogueChoice>)System.Array.Empty<DialogueChoice>();

            DialogueLine line = currentNode.line;

            if (animatorDriver != null)
            {
                if (!string.IsNullOrEmpty(line.animationTag))
                {
                    animatorDriver.PlayGesture(line.animationTag);
                }
                if (line.voiceClip != null)
                {
                    animatorDriver.PlayVoice(line.voiceClip);
                }
            }

            DialogueEvents.RaiseNodePresented(line, currentChoices);

            autoAdvanceTimer = line.autoAdvanceAfter > 0f ? line.autoAdvanceAfter : 0f;
        }
    }
}