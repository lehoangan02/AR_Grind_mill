using System;
using System.Collections.Generic;
using UnityEngine;

namespace AR_Grind_mill.Dialogue.Data
{
    /// <summary>
    /// Process-wide event hub that decouples the dialogue runtime from the
    /// dialogue UI. Any system can subscribe; nothing here holds Unity object
    /// references on its own.
    /// </summary>
    public static class DialogueEvents
    {
        /// <summary>Raised when an NPC begins speaking. Carries the active graph.</summary>
        public static event Action<DialogueGraph> OnDialogueStarted;

        /// <summary>Raised when an NPC stops speaking (player walked away, choice ended, or interrupted).</summary>
        public static event Action OnDialogueEnded;

        /// <summary>Raised when the orchestrator advances to a new node. UI subscribes to render it.</summary>
        public static event Action<DialogueLine, IReadOnlyList<DialogueChoice>> OnNodePresented;

        /// <summary>Raised when the player makes a choice. Carries the choice index into the last presented list.</summary>
        public static event Action<int> OnChoiceSelected;

        /// <summary>
        /// Raised when the player enters or exits an NPC's proximity sphere.
        /// The first argument is the NPC's <c>Transform</c> (the source) so subscribers
        /// that are bound to a specific NPC can filter for their own NPC instead of
        /// reacting to every NPC in the scene.
        /// </summary>
        public static event Action<Transform, bool> OnProximityChanged;

        public static void RaiseDialogueStarted(DialogueGraph graph)
            => OnDialogueStarted?.Invoke(graph);

        public static void RaiseDialogueEnded()
            => OnDialogueEnded?.Invoke();

        public static void RaiseNodePresented(DialogueLine line, IReadOnlyList<DialogueChoice> choices)
            => OnNodePresented?.Invoke(line, choices);

        public static void RaiseChoiceSelected(int index)
            => OnChoiceSelected?.Invoke(index);

        public static void RaiseProximityChanged(Transform npc, bool isInRange)
            => OnProximityChanged?.Invoke(npc, isInRange);

        /// <summary>Wipes all subscribers. Call from domain-reload tests or scene shutdown if needed.</summary>
        public static void ClearAllSubscribers()
        {
            OnDialogueStarted = null;
            OnDialogueEnded = null;
            OnNodePresented = null;
            OnChoiceSelected = null;
            OnProximityChanged = null;
        }
    }
}