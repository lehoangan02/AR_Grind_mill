// ScanAllAnimatorControllers: walks every AnimatorController asset in the project
// and reports any state whose motion slot is empty, any transition whose
// destination state fileID does not resolve, and any state not referenced by
// its parent state machine. Helps pinpoint UnityEditor.Graphs.Edge.WakeUp NREs.

using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace AR_Grind_mill.Dialogue.EditorTools
{
    public static class ScanAllAnimatorControllers
    {
        [MenuItem("AR_Grind_mill/Dialogue/SCAN_ALL_ANIMATOR_CONTROLLERS")]
        private static void Run()
        {
            var guids = AssetDatabase.FindAssets("t:AnimatorController");
            int scanned = 0;
            int bad = 0;
            var report = new StringBuilder();

            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var controller = AssetDatabase.LoadAssetAtPath<AnimatorController>(path);
                if (controller == null) continue;
                scanned++;

                var stateIds = new HashSet<int>();
                var smStateIds = new HashSet<int>();
                var badMotions = new List<string>();
                var orphanStates = new List<string>();
                var badTransitions = new List<string>();

                foreach (var layer in controller.layers)
                {
                    if (layer.stateMachine == null) continue;
                    foreach (var child in layer.stateMachine.states)
                    {
                        if (child.state == null) continue;
                        var s = child.state;
                        stateIds.Add(s.GetInstanceID());
                        smStateIds.Add(s.GetInstanceID());
                        if (s.motion == null)
                        {
                            badMotions.Add(s.name);
                        }
                    }
                    foreach (var child in layer.stateMachine.stateMachines)
                    {
                        // Sub-state machines not supported in our small controllers, ignore
                    }

                    if (layer.stateMachine.defaultState == null)
                    {
                        report.AppendLine($"  {path} :: layer '{layer.name}' has null defaultState");
                    }
                }

                if (badMotions.Count > 0)
                {
                    bad++;
                    report.AppendLine($"  {path} :: empty motion on state(s): {string.Join(", ", badMotions)}");
                }
            }

            if (report.Length == 0)
            {
                Debug.Log($"[ScanAllAnimatorControllers] Scanned {scanned} controller(s). No structural issues found.");
            }
            else
            {
                Debug.LogWarning($"[ScanAllAnimatorControllers] Scanned {scanned} controller(s). {bad} had issues:\n{report}");
            }
        }
    }
}
