using UnityEngine;

namespace AR_Grind_mill.Dialogue.Data
{
    /// <summary>
    /// A single spoken line in a dialogue tree. Serialized inline on
    /// <see cref="DialogueNode"/> so designers can author nodes without
    /// touching per-line ScriptableObjects.
    /// </summary>
    [System.Serializable]
    public struct DialogueLine
    {
        [Tooltip("Speaker shown above the line. Leave empty to hide the label.")]
        public string speakerName;

        [TextArea(2, 5)]
        [Tooltip("Body of the spoken line.")]
        public string text;

        [Tooltip("Optional animation tag triggered when this line is presented. " +
                 "Empty string = no gesture.")]
        public string animationTag;

        [Tooltip("Optional voice clip played when this line is presented.")]
        public AudioClip voiceClip;

        [Tooltip("Seconds to wait before auto-advancing. 0 = wait for the player to pick a choice.")]
        public float autoAdvanceAfter;
    }
}