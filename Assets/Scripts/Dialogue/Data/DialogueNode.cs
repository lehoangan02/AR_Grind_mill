using System.Collections.Generic;
using UnityEngine;

namespace AR_Grind_mill.Dialogue.Data
{
    /// <summary>
    /// One node in a dialogue tree. Holds a single spoken <see cref="DialogueLine"/>
    /// and the player <see cref="DialogueChoice"/>s that lead to other nodes.
    /// Designers author these as standalone ScriptableObject assets and link them
    /// into a <see cref="DialogueGraph"/>.
    /// </summary>
    [CreateAssetMenu(fileName = "DialogueNode", menuName = "AR_Grind_mill/Dialogue/Node")]
    public class DialogueNode : ScriptableObject
    {
        [Header("Designer Notes")]
        [TextArea(2, 4)]
        [Tooltip("Designer-only comment. Not read by the runtime layer.")]
        public string editorNotes;

        [Header("Spoken Line")]
        [Tooltip("The line spoken at this node. Includes speaker, text, optional animation tag and voice clip.")]
        public DialogueLine line;

        [Header("Choices")]
        [Tooltip("Player responses. Empty list = auto-end after this line.")]
        public List<DialogueChoice> choices = new List<DialogueChoice>();

        [Header("Flow")]
        [Tooltip("Force the dialogue to end after this node even if choices exist. " +
                 "Useful for 'Goodbye' variants or hard stops.")]
        public bool isEndNode;

        /// <summary>
        /// True when this node has no outgoing flow: either explicitly flagged as an end,
        /// or simply missing choices.
        /// </summary>
        public bool IsTerminal()
        {
            return isEndNode || choices == null || choices.Count == 0;
        }

        /// <summary>
        /// Returns the node reached via <paramref name="choiceIndex"/>, or null if the
        /// index is out of range or the choice points at nothing.
        /// </summary>
        public DialogueNode GetNext(int choiceIndex)
        {
            if (choices == null) return null;
            if (choiceIndex < 0 || choiceIndex >= choices.Count) return null;
            return choices[choiceIndex].nextNode;
        }

        private void OnValidate()
        {
            // Defensive: ScriptableObjects created via code (or older assets) may have a null list.
            if (choices == null)
            {
                choices = new List<DialogueChoice>();
            }
        }
    }
}
