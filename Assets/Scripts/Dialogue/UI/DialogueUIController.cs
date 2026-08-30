using System.Collections.Generic;
using AR_Grind_mill.Dialogue.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AR_Grind_mill.Dialogue.UI
{
    /// <summary>
    /// World-space dialogue canvas that billboards toward <see cref="Camera.main"/>,
    /// renders the current speaker/line, and instantiates one button per choice.
    /// Pure subscriber — never publishes <see cref="DialogueEvents"/>; the choice
    /// buttons themselves route clicks back via <see cref="DialogueEvents.RaiseChoiceSelected"/>.
    /// </summary>
    public class DialogueUIController : MonoBehaviour
    {
        [Header("Canvas")]
        [Tooltip("World-space canvas that holds the dialogue panel. Auto-hidden on Awake.")]
        public Canvas canvas;

        [Tooltip("Root that contains the speaker label, line text, and choice container. " +
                 "Used for show/hide so the canvas GameObject itself stays alive.")]
        public RectTransform contentRoot;

        [Header("Text")]
        [Tooltip("Speaker name label above the line. Hidden when the line's speakerName is empty.")]
        public TMP_Text speakerLabel;

        [Tooltip("Body text of the current line.")]
        public TMP_Text lineText;

        [Header("Choices")]
        [Tooltip("Empty container under the canvas where choice buttons are instantiated.")]
        public RectTransform choicesRoot;

        [Tooltip("Button prefab carrying a DialogueChoiceButton component. " +
                 "Instantiated once per choice, parented under choicesRoot.")]
        public DialogueChoiceButton choiceButtonPrefab;

        [Header("Positioning")]
        [Tooltip("Anchor the canvas is offset from — typically the NPC's head or root transform. " +
                 "If null, the controller falls back to its own transform.")]
        public Transform anchor;

        [Tooltip("Meters above the anchor that the canvas sits at (≈ 1.7 = NPC eye height).")]
        [Min(0f)]
        public float headHeightOffset = 1.7f;

        [Tooltip("Meters in front of the anchor (toward the player) the canvas is pushed to.")]
        [Min(0f)]
        public float forwardOffset = 0.6f;

        [Tooltip("Uniform local scale applied to the canvas. 0.005 ≈ 30 cm tall panel in world space.")]
        [Range(0.1f, 5f)]
        public float canvasScale = 0.005f;

        [Header("Billboard")]
        [Tooltip("If true the canvas stays upright (no pitch) and only yaws toward the player — " +
                 "the typical VR preference. If false it tilts up/down with the player's elevation.")]
        public bool lockPitchToHorizontal = true;

        private void Awake()
        {
            if (canvas == null)
            {
                Debug.LogWarning(
                    "[DialogueUIController] canvas is not assigned. The controller cannot show anything.",
                    this);
            }
            else
            {
                canvas.renderMode = RenderMode.WorldSpace;

                canvas.transform.localScale = Vector3.one * canvasScale;

                // Canvas stays enabled at all times so children (prompt + content) can
                // independently toggle their own visibility. The world-space canvas
                // itself is invisible when all its children are inactive.
            }

            if (contentRoot != null)
            {
                contentRoot.gameObject.SetActive(false);
            }
        }

        private void OnEnable()
        {
            DialogueEvents.OnDialogueStarted += HandleDialogueStarted;
            DialogueEvents.OnNodePresented += HandleNodePresented;
            DialogueEvents.OnDialogueEnded += HandleDialogueEnded;
        }

        private void OnDisable()
        {
            DialogueEvents.OnDialogueStarted -= HandleDialogueStarted;
            DialogueEvents.OnNodePresented -= HandleNodePresented;
            DialogueEvents.OnDialogueEnded -= HandleDialogueEnded;

            // Tearing down — clear any buttons we instantiated so a disabled-and-re-enabled
            // controller doesn't leave stale choices in the scene.
            ClearChoiceButtons();
        }

        private void LateUpdate()
        {
            UpdateBillboard();
        }

        /// <summary>
        /// Positions the canvas at the anchor's head height + horizontal offset toward the
        /// headset, then aims its forward axis at the headset (pitch-locked when configured).
        /// No-ops cleanly when the camera is missing (scene transitions, headless tests).
        /// </summary>
        private void UpdateBillboard()
        {
            Camera mainCam = Camera.main;
            if (mainCam == null)
            {
                // No headset in the scene this frame — skip. Common during scene loads
                // before XR finishes initialising, or in unit tests.
                return;
            }

            Vector3 headPos = anchor != null
                ? anchor.position + Vector3.up * headHeightOffset
                : transform.position;

            // Horizontal direction from anchor head toward the player, normalised.
            // Projected onto the XZ plane so a player at a different elevation doesn't
            // drag the canvas into the floor or above the NPC's head.
            Vector3 horizontalToPlayer = Vector3.ProjectOnPlane(
                mainCam.transform.position - headPos,
                Vector3.up);

            // Guard against the degenerate case where the headset sits directly above
            // (or below) the anchor — both ProjectOnPlane and LookRotation would
            // otherwise receive the zero vector.
            if (horizontalToPlayer.sqrMagnitude < 0.0001f)
            {
                return;
            }

            Vector3 horizontalDir = horizontalToPlayer.normalized;

            // Park the canvas between the NPC's head and the player.
            transform.position = headPos + horizontalDir * forwardOffset;

            // Face the canvas at the headset. When pitch is locked we yawing only;
            // when unlocked we pitch toward the actual player elevation.
            Vector3 lookDir = lockPitchToHorizontal
                ? horizontalDir
                : (mainCam.transform.position - headPos);

            // Even with pitch unlocked, normalise to avoid feeding a near-zero vector
            // when the player teleports to the exact anchor position.
            if (lookDir.sqrMagnitude < 0.0001f)
            {
                return;
            }

            // World-space canvases render their visible face on the canvas's -Z side;
            // negate the look direction so that face points at the player.
            transform.rotation = Quaternion.LookRotation(-lookDir.normalized, Vector3.up);
        }

        /// <summary>
        /// Shows the canvas when an NPC begins speaking. We intentionally do NOT
        /// pre-seed <see cref="speakerLabel"/> with the graph's characterName —
        /// the first <see cref="HandleNodePresented"/> will overwrite it with the
        /// authoritative speaker for this node (NPCs can change speaker mid-graph).
        /// </summary>
        private void HandleDialogueStarted(DialogueGraph graph)
        {
            if (contentRoot != null)
            {
                contentRoot.gameObject.SetActive(true);
            }
        }

        /// <summary>
        /// Renders a new line, clears the previous choice buttons, and instantiates
        /// one <see cref="DialogueChoiceButton"/> per choice wired to
        /// <see cref="DialogueEvents.RaiseChoiceSelected"/>.
        /// </summary>
        private void HandleNodePresented(DialogueLine line, IReadOnlyList<DialogueChoice> choices)
        {
            if (contentRoot != null)
            {
                contentRoot.gameObject.SetActive(true);
            }

            // Speaker label — show only when the line provides a non-empty name.
            if (speakerLabel != null)
            {
                bool hasSpeaker = !string.IsNullOrEmpty(line.speakerName);
                speakerLabel.gameObject.SetActive(hasSpeaker);
                if (hasSpeaker)
                {
                    speakerLabel.text = line.speakerName;
                }
            }

            if (lineText != null)
            {
                lineText.text = line.text;
            }

            // Rebuild choice list. Destroy (not DestroyImmediate) so prefab workflow
            // in the editor doesn't break — Instantiate/Instantiate-in-editor handle it.
            ClearChoiceButtons();

            if (choices != null && choices.Count > 0 && choiceButtonPrefab != null && choicesRoot != null)
            {
                for (int i = 0; i < choices.Count; i++)
                {
                    DialogueChoice choice = choices[i];
                    DialogueChoiceButton button = Instantiate(choiceButtonPrefab, choicesRoot);
                    button.SetData(i, choice.choiceText, DialogueEvents.RaiseChoiceSelected);
                }
            }
        }

        /// <summary>
        /// Hides the dialogue content and clears any choice buttons when the
        /// conversation ends. The world-space canvas itself stays enabled so the
        /// NPC's prompt can still render.
        /// </summary>
        private void HandleDialogueEnded()
        {
            ClearChoiceButtons();

            if (contentRoot != null)
            {
                contentRoot.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Destroys every instantiated choice button child of <see cref="choicesRoot"/>.
        /// Iterates top-down and breaks the parent link before destruction so any
        /// teardown listener sees a stable hierarchy.
        /// </summary>
        private void ClearChoiceButtons()
        {
            if (choicesRoot == null)
            {
                return;
            }

            for (int i = choicesRoot.childCount - 1; i >= 0; i--)
            {
                Transform child = choicesRoot.GetChild(i);
                if (child != null)
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }
}
