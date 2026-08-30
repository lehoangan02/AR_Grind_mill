using UnityEngine;

namespace AR_Grind_mill.Dialogue.Data
{
    /// <summary>
    /// One selectable response on a dialogue node.
    /// </summary>
    [System.Serializable]
    public struct DialogueChoice
    {
        [Tooltip("Button label shown to the player.")]
        public string choiceText;

        [Tooltip("Next node to present when this choice is selected. " +
                 "Leave null to end the conversation after this choice is taken.")]
        public DialogueNode nextNode;

        [Tooltip("Optional animation tag triggered when this choice is selected " +
                 "(e.g., \"gesture_nod\"). Empty = no gesture.")]
        public string animationTag;
    }
}