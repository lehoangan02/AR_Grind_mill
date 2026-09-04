// FixEventSystemInputModule: replace legacy StandaloneInputModule with InputSystemUIInputModule
// because the project is configured for "Input System Package (New)" only and
// StandaloneInputModule reads through UnityEngine.Input, which is disabled.

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace AR_Grind_mill.Dialogue.EditorTools
{
    public static class FixEventSystemInputModule
    {
        private const string InputActionsPath = "Assets/InputSystem_Actions.inputactions";

        [MenuItem("AR_Grind_mill/Dialogue/FIX_EVENTSYSTEM_INPUT_MODULE")]
        private static void Run()
        {
            int changedScenes = 0;
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (!scene.isLoaded) continue;
                GameObject[] roots = scene.GetRootGameObjects();
                foreach (var root in roots)
                {
                    var es = root.GetComponentInChildren<EventSystem>(true);
                    if (es == null) continue;
                    changedScenes += FixOne(es.gameObject);
                }
            }

            if (changedScenes > 0)
            {
                EditorSceneManager.MarkAllScenesDirty();
                EditorSceneManager.SaveOpenScenes();
                Debug.Log($"[FixEventSystemInputModule] Done. Repaired {changedScenes} EventSystem(s) across open scenes.");
            }
            else
            {
                Debug.Log("[FixEventSystemInputModule] Nothing to do.");
            }
        }

        private static int FixOne(GameObject go)
        {
            int changed = 0;

            // Remove legacy StandaloneInputModule (reads UnityEngine.Input -> InvalidOp when new input only)
            var legacy = go.GetComponent<StandaloneInputModule>();
            if (legacy != null)
            {
                Object.DestroyImmediate(legacy, true);
                Debug.Log($"[FixEventSystemInputModule] Removed legacy StandaloneInputModule on '{GetPath(go)}'.");
                changed++;
            }

            // Add new InputSystemUIInputModule if absent
            var modern = go.GetComponent<InputSystemUIInputModule>();
            if (modern == null)
            {
                modern = go.AddComponent<InputSystemUIInputModule>();
                Debug.Log($"[FixEventSystemInputModule] Added InputSystemUIInputModule on '{GetPath(go)}'.");
                changed++;
            }

            // Wire actions asset if not already assigned
            var actions = AssetDatabase.LoadAssetAtPath<InputActionAsset>(InputActionsPath);
            if (actions == null)
            {
                Debug.LogWarning($"[FixEventSystemInputModule] Could not load {InputActionsPath} - actions not assigned.");
            }
            else
            {
                var so = new SerializedObject(modern);
                var prop = so.FindProperty("m_ActionsAsset");
                if (prop != null && prop.objectReferenceValue == null)
                {
                    prop.objectReferenceValue = actions;
                    so.ApplyModifiedPropertiesWithoutUndo();
                    Debug.Log($"[FixEventSystemInputModule] Wired actions asset '{InputActionsPath}' on '{GetPath(go)}'.");
                    changed++;
                }
            }

            // Mark scene dirty via EditorUtility so the saving above picks it up
            if (changed > 0) EditorUtility.SetDirty(go);
            return 1;
        }

        private static string GetPath(GameObject go)
        {
            var t = go.transform;
            string path = go.name;
            while (t.parent != null)
            {
                t = t.parent;
                path = t.name + "/" + path;
            }
            return path;
        }
    }
}
