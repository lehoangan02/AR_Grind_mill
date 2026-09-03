#if UNITY_EDITOR
using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace AR_Grind_mill.Dialogue.Editor
{
    /// <summary>
    /// One-shot menu orchestrator that rebuilds the entire Child NPC pipeline
    /// from the source FBX through to a placed scene instance.
    ///
    /// Invokes in sequence:
    ///   1. <c>AR_Grind_mill.Characters.Editor.BuildChildNpcAnimator.BuildAll</c>
    ///   2. <c>AR_Grind_mill.Dialogue.Editor.BuildChildNpcDialogueAssets.BuildAll</c>
    ///   3. <c>AR_Grind_mill.Dialogue.EditorTools.BuildChildNpcPrefab.BuildAll</c>
    ///   4. <c>AR_Grind_mill.Dialogue.Editor.SceneIntegrator_ChildNpc.Integrate</c>
    ///
    /// Each step is invoked via reflection so this orchestrator stays decoupled
    /// from the concrete editor assemblies — defensive against missing types
    /// and assembly renames. A failure in one step never aborts the rest.
    /// </summary>
    public static class BuildChildNpcFromModel
    {
        private const string MenuPath = "AR_Grind_mill/ChildNpc/Build Child NPC From Model";
        private const string LogTag = "[BuildChildNpcFromModel]";
        private const string EditorAssembly = "Assembly-CSharp-Editor";
        private const string PrefabPath = "Assets/Prefabs/NPCs/ChildNpc.prefab";

        // ─── Reflection targets (step, namespace.typename, method) ────────
        private static readonly (string Label, string TypeName, string MethodName)[] Steps =
        {
            ("Animator",      "AR_Grind_mill.Characters.Editor.BuildChildNpcAnimator",         "BuildAll"),
            ("DialogueAssets","AR_Grind_mill.Dialogue.Editor.BuildChildNpcDialogueAssets",    "BuildAll"),
            ("Prefab",        "AR_Grind_mill.Dialogue.EditorTools.BuildChildNpcPrefab",       "BuildAll"),
            ("SceneIntegrator","AR_Grind_mill.Dialogue.Editor.SceneIntegrator_ChildNpc",      "Integrate"),
        };

        [MenuItem(MenuPath)]
        public static void BuildChildNpcFromModelMenu()
        {
            Debug.Log($"{LogTag} Starting Child NPC pipeline rebuild.");

            int stepIndex = 0;
            int failures = 0;

            foreach (var step in Steps)
            {
                stepIndex++;
                int code = RunStep(stepIndex, step.Label, step.TypeName, step.MethodName);
                if (code != 0) failures++;

                // Each step may have created assets that the next step consumes.
                AssetDatabase.Refresh();
            }

            if (failures == 0)
            {
                Debug.Log($"{LogTag} All steps complete. Child NPC ready at {PrefabPath}");
            }
            else
            {
                Debug.LogWarning($"{LogTag} Done with {failures} failure(s). See preceding errors. Prefab: {PrefabPath}");
            }
        }

        // ─── Internal: invoke one step defensively via reflection ─────────
        private static int RunStep(int index, string label, string typeName, string methodName)
        {
            try
            {
                Type type = Type.GetType($"{typeName}, {EditorAssembly}", throwOnError: false);
                if (type == null)
                {
                    Debug.LogWarning($"{LogTag} Step {index} ({label}): type not found — {typeName}. Skipping.");
                    return 1;
                }

                MethodInfo method = type.GetMethod(
                    methodName,
                    BindingFlags.Public | BindingFlags.Static,
                    binder: null,
                    types: Type.EmptyTypes,
                    modifiers: null);

                if (method == null)
                {
                    Debug.LogWarning($"{LogTag} Step {index} ({label}): method '{methodName}()' not found on {typeName}. Skipping.");
                    return 1;
                }

                object result = method.Invoke(obj: null, parameters: null);

                Debug.Log($"{LogTag} Step {index} ({label}): OK — {typeName}.{methodName}() invoked.");
                return 0;
            }
            catch (TargetInvocationException tie)
            {
                Exception inner = tie.InnerException ?? tie;
                Debug.LogError($"{LogTag} Step {index} ({label}) failed: {inner.GetType().Name}: {inner.Message}\n{inner.StackTrace}");
                return 1;
            }
            catch (Exception ex)
            {
                Debug.LogError($"{LogTag} Step {index} ({label}) failed: {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}");
                return 1;
            }
        }
    }
}
#endif