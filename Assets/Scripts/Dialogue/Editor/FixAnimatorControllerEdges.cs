// FixAnimatorControllerEdges: assigns a valid empty AnimationClip to every
// AnimatorState in the NPC controllers. Empty m_Motion {fileID: 0} triggers a
// Unity 6 NullReferenceException in UnityEditor.Graphs.Edge.WakeUp when the
// Animator window tries to display the graph. Also strips the unused
// GestureTrigger parameter.

using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace AR_Grind_mill.Dialogue.EditorTools
{
    public static class FixAnimatorControllerEdges
    {
        private const string IdleClipPath = "Assets/Animations/NPC/NPC_Idle.anim";
        private const string TalkingClipPath = "Assets/Animations/NPC/NPC_Talking.anim";

        [MenuItem("AR_Grind_mill/Dialogue/FIX_ANIMATOR_CONTROLLER_EDGES")]
        private static void Run()
        {
            AnimationClip idleClip = GetOrCreateClip(IdleClipPath, "NPC_Idle");
            AnimationClip talkingClip = GetOrCreateClip(TalkingClipPath, "NPC_Talking");

            string[] controllerPaths =
            {
                "Assets/Animations/NPC/MrSix.controller",
                "Assets/Animations/NPC/MrsFour.controller"
            };

            int controllersFixed = 0;
            foreach (var path in controllerPaths)
            {
                var controller = AssetDatabase.LoadAssetAtPath<AnimatorController>(path);
                if (controller == null)
                {
                    Debug.LogWarning($"[FixAnimatorControllerEdges] No controller at {path}.");
                    continue;
                }

                bool changed = false;

                foreach (var clip in controller.animationClips)
                {
                    if (clip != null) continue;
                }

                foreach (var layer in controller.layers)
                {
                    if (layer == null || layer.stateMachine == null) continue;
                    foreach (var state in layer.stateMachine.states)
                    {
                        if (state.state == null) continue;
                        var animState = state.state;
                        var targetClip = animState.name == "Talking" ? talkingClip : idleClip;
                        if (animState.motion != targetClip)
                        {
                            animState.motion = targetClip;
                            changed = true;
                            Debug.Log($"[FixAnimatorControllerEdges] {path} :: {animState.name}.motion -> {targetClip.name}");
                        }
                    }
                }

                if (HasParameter(controller, "GestureTrigger"))
                {
                    int idx = FindParameterIndex(controller, "GestureTrigger");
                    if (idx >= 0)
                    {
                        controller.RemoveParameter(idx);
                    }
                    changed = true;
                    Debug.Log($"[FixAnimatorControllerEdges] {path} :: removed unused GestureTrigger parameter");
                }

                if (changed)
                {
                    EditorUtility.SetDirty(controller);
                    controllersFixed++;
                }
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log($"[FixAnimatorControllerEdges] Done. Fixed {controllersFixed} controller(s).");
        }

        private static AnimationClip GetOrCreateClip(string path, string clipName)
        {
            var existing = AssetDatabase.LoadAssetAtPath<AnimationClip>(path);
            if (existing != null) return existing;

            var clip = new AnimationClip
            {
                name = clipName,
                frameRate = 60f,
                legacy = false
            };
            var settings = AnimationUtility.GetAnimationClipSettings(clip);
            settings.loopTime = true;
            AnimationUtility.SetAnimationClipSettings(clip, settings);

            string dir = System.IO.Path.GetDirectoryName(path);
            if (!AssetDatabase.IsValidFolder(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
                AssetDatabase.Refresh();
            }

            AssetDatabase.CreateAsset(clip, path);
            Debug.Log($"[FixAnimatorControllerEdges] Created empty clip {path}");
            return clip;
        }

        private static bool HasParameter(AnimatorController controller, string name)
        {
            return FindParameterIndex(controller, name) >= 0;
        }

        private static int FindParameterIndex(AnimatorController controller, string name)
        {
            for (int i = 0; i < controller.parameters.Length; i++)
            {
                if (controller.parameters[i].name == name) return i;
            }
            return -1;
        }
    }
}
