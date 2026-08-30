using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AR_Grind_mill.Dialogue.UI
{
    /// <summary>
    /// Leaf component attached to a choice button prefab. Pure UI leaf — does not
    /// subscribe to <see cref="AR_Grind_mill.Dialogue.Data.DialogueEvents"/> itself;
    /// the parent controller pushes data in via <see cref="SetData(int, string, System.Action{int})"/>.
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class DialogueChoiceButton : MonoBehaviour
    {
        [Header("References")]
        [Tooltip("Button on this GameObject. Auto-fetched if left empty.")]
        [SerializeField] private Button button;

        [Tooltip("TextMeshPro label inside the button. Optional — may be null for icon-only buttons.")]
        [SerializeField] private TMP_Text label;

        private void Reset()
        {
            // Auto-wire serialized references when the component is added in the editor.
            button = GetComponent<Button>();
            label = GetComponentInChildren<TMP_Text>(includeInactive: true);
        }

        private void Awake()
        {
            if (button == null)
            {
                button = GetComponent<Button>();
            }
        }

        /// <summary>
        /// Stores the choice index, updates the visible label, and replaces any
        /// previously-bound click listener with one that raises <paramref name="onSelect"/>
        /// carrying this button's index.
        /// </summary>
        public void SetData(int index, string text, System.Action<int> onSelect)
        {
            if (button == null)
            {
                Debug.LogWarning(
                    $"[DialogueChoiceButton] No Button reference on '{name}'. Cannot bind click.",
                    this);
                return;
            }

            if (label != null)
            {
                label.text = text;
            }

            // Replace any previously-bound listener so re-used buttons don't double-fire.
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => onSelect?.Invoke(index));
        }

        /// <summary>
        /// Removes every click listener. Call when the button is being recycled or
        /// when the dialogue panel is being torn down so we don't leak closures.
        /// </summary>
        public void ClearListeners()
        {
            if (button != null)
            {
                button.onClick.RemoveAllListeners();
            }
        }
    }
}
