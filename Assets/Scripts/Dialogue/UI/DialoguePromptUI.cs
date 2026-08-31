using AR_Grind_mill.Dialogue.Data;
using AR_Grind_mill.Dialogue.Runtime;
using TMPro;
using UnityEngine;

namespace AR_Grind_mill.Dialogue.UI
{
    /// <summary>
    /// Lightweight world-space prompt ("Press [Trigger] to talk") that appears when the
    /// player enters an NPC's proximity sphere and disappears once a conversation starts.
    /// Tracks <see cref="DialogueEvents"/> so it correctly hides during dialogue and
    /// re-evaluates visibility when the conversation ends.
    /// </summary>
    public class DialoguePromptUI : MonoBehaviour
    {
        [Header("References")]
        [Tooltip("Root GameObject toggled visible / hidden. Set inactive by default in Awake.")]
        public GameObject promptRoot;

        [Tooltip("TextMeshPro label inside the prompt. Receives promptText on enable if empty.")]
        public TMP_Text promptLabel;

        [Header("Content")]
        [Tooltip("Designer-overridable default label, e.g. \"Press [Trigger] to talk\".")]
        public string promptText = "Press [Trigger] to talk";

        // Cached so we can re-evaluate visibility when a conversation ends without the
        // proximity trigger needing to re-fire OnProximityChanged.
        private bool lastKnownProximity;
        private bool isDialogueActive;

        // The NPC we belong to. Proximity events raised by any other NPC are ignored.
        // Auto-resolved in Awake from the sibling NPCProximityTrigger (or the
        // nearest one up the hierarchy) when the inspector leaves it null.
        private Transform myNpc;

        private void Awake()
        {
            if (promptRoot != null)
            {
                promptRoot.SetActive(false);
            }
            else
            {
                Debug.LogWarning(
                    "[DialoguePromptUI] promptRoot is not assigned. Prompt will never appear.",
                    this);
            }

            if (myNpc == null)
            {
                var trig = GetComponentInParent<NPCProximityTrigger>(true);
                if (trig != null) myNpc = trig.transform;
            }
        }

        private void OnEnable()
        {
            if (promptLabel != null && string.IsNullOrEmpty(promptLabel.text))
            {
                promptLabel.text = promptText;
            }

            DialogueEvents.OnProximityChanged += HandleProximityChanged;
            DialogueEvents.OnDialogueStarted += HandleDialogueStarted;
            DialogueEvents.OnDialogueEnded += HandleDialogueEnded;
        }

        private void OnDisable()
        {
            DialogueEvents.OnProximityChanged -= HandleProximityChanged;
            DialogueEvents.OnDialogueStarted -= HandleDialogueStarted;
            DialogueEvents.OnDialogueEnded -= HandleDialogueEnded;
        }

        /// <summary>
        /// Shows the prompt when the player enters range (and no conversation is active),
        /// hides it when the player leaves. Idempotent — repeated calls with the same
        /// value just re-assert the current state.
        /// </summary>
        private void HandleProximityChanged(Transform source, bool isInRange)
        {
            if (myNpc != null && source != myNpc) return;

            lastKnownProximity = isInRange;

            if (isInRange && !isDialogueActive)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        /// <summary>
        /// Suppresses the prompt while a conversation is in progress.
        /// </summary>
        private void HandleDialogueStarted(DialogueGraph graph)
        {
            isDialogueActive = true;
            Hide();
        }

        /// <summary>
        /// Restores the prompt if the player is still in the NPC's proximity sphere.
        /// </summary>
        private void HandleDialogueEnded()
        {
            isDialogueActive = false;

            if (lastKnownProximity)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        private void Show()
        {
            if (promptRoot != null && !promptRoot.activeSelf)
            {
                promptRoot.SetActive(true);
            }
        }

        private void Hide()
        {
            if (promptRoot != null && promptRoot.activeSelf)
            {
                promptRoot.SetActive(false);
            }
        }
    }
}
