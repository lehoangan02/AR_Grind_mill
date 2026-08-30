using System.Collections.Generic;
using UnityEngine;

namespace AR_Grind_mill.Dialogue.Runtime
{
    /// <summary>
    /// Thin wrapper over the NPC's <see cref="Animator"/>. Translates the dialogue
    /// layer's high-level intent ("set talking", "play this gesture tag", "play this
    /// voice clip") into Animator parameters + AudioSource one-shots. All operations
    /// tolerate a missing Animator gracefully — designers can drop the script on a
    /// rig before the controller is authored and nothing will throw.
    /// </summary>
    public class NPCAnimatorDriver : MonoBehaviour
    {
        [System.Serializable]
        public struct GestureMapping
        {
            [Tooltip("Logical tag passed from DialogueLine.animationTag, e.g. \"gesture_point\".")]
            public string tag;

            [Tooltip("Name of the Trigger parameter on the Animator, e.g. \"GesturePoint\".")]
            public string animatorTrigger;
        }

        [Header("Animator")]
        [Tooltip("Animator that drives this NPC. Auto-resolved from this GameObject if left empty.")]
        [SerializeField] private Animator animator;

        [Header("Parameters")]
        [Tooltip("Animator Bool parameter toggled while the NPC is mid-conversation (Idle ↔ Talking).")]
        public string isTalkingBool = "IsTalking";

        [Tooltip("Fallback Animator Trigger fired when a dialogue tag has no explicit mapping. " +
                 "Leave the mapping list empty to drive everything from this single trigger.")]
        public string gestureTrigger = "GestureTrigger";

        [Header("Gestures")]
        [Tooltip("Maps dialogue tags (from DialogueLine.animationTag) to Animator Trigger parameter names.")]
        public List<GestureMapping> gestureMappings = new List<GestureMapping>();

        [Header("Voice")]
        [Tooltip("Optional AudioSource used to play DialogueLine.voiceClip one-shots.")]
        public AudioSource voiceSource;

        private bool warnedMissingAnimator;

        private void Awake()
        {
            if (animator == null)
            {
                animator = GetComponent<Animator>();
            }

            if (animator == null && !warnedMissingAnimator)
            {
                Debug.LogWarning(
                    $"[{nameof(NPCAnimatorDriver)}] No Animator assigned or found on '{name}'. " +
                    $"Talking/gesture calls will be no-ops until one is provided.",
                    this);
                warnedMissingAnimator = true;
            }
        }

        /// <summary>Toggle the talking bool on the Animator. No-op if the parameter is missing.</summary>
        public void SetTalking(bool isTalking)
        {
            if (animator == null) return;
            if (string.IsNullOrEmpty(isTalkingBool)) return;
            if (!HasParameter(isTalkingBool, AnimatorControllerParameterType.Bool)) return;

            animator.SetBool(isTalkingBool, isTalking);
        }

        /// <summary>
        /// Resolve <paramref name="tag"/> through <see cref="gestureMappings"/> and fire the
        /// matching Trigger parameter. Falls back to <see cref="gestureTrigger"/> when the
        /// tag is unmapped. Silently does nothing if neither path finds a Trigger parameter.
        /// </summary>
        public void PlayGesture(string tag)
        {
            if (animator == null) return;
            if (string.IsNullOrEmpty(tag)) return;

            string triggerName = ResolveTriggerName(tag);
            if (string.IsNullOrEmpty(triggerName)) return;
            if (!HasParameter(triggerName, AnimatorControllerParameterType.Trigger)) return;

            animator.SetTrigger(triggerName);
        }

        /// <summary>Play a one-shot voice clip on <see cref="voiceSource"/>. No-op if either is null.</summary>
        public void PlayVoice(AudioClip clip)
        {
            if (voiceSource == null) return;
            if (clip == null) return;

            voiceSource.PlayOneShot(clip);
        }

        private string ResolveTriggerName(string tag)
        {
            if (gestureMappings != null)
            {
                for (int i = 0; i < gestureMappings.Count; i++)
                {
                    GestureMapping mapping = gestureMappings[i];
                    if (mapping.tag == tag && !string.IsNullOrEmpty(mapping.animatorTrigger))
                    {
                        return mapping.animatorTrigger;
                    }
                }
            }

            return gestureTrigger;
        }

        /// <summary>Returns true if the Animator has a parameter of the given name and type.</summary>
        private bool HasParameter(string parameterName, AnimatorControllerParameterType type)
        {
            if (animator == null) return false;
            if (animator.runtimeAnimatorController == null) return false;

            AnimatorControllerParameter[] parameters = animator.parameters;
            if (parameters == null) return false;

            for (int i = 0; i < parameters.Length; i++)
            {
                AnimatorControllerParameter p = parameters[i];
                if (p.type == type && p.name == parameterName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}