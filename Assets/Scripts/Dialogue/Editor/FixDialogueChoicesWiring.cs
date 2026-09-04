#if UNITY_EDITOR
using AR_Grind_mill.Dialogue.UI;
using UnityEditor;
using UnityEngine;

namespace AR_Grind_mill.Dialogue.EditorTools
{
    /// <summary>
    /// Repairs two wiring bugs left by FixNPCDialogueCanvases:
    ///   1. The controller's <see cref="DialogueUIController.choicesRoot"/> field was
    ///      wired to a stray ChoicesRoot that the fix script created as a direct child
    ///      of the canvas. The real one lives under Content/ChoicesRoot (built by
    ///      WireDialogueSystem) and is the only one whose layout settings get used.
    ///   2. <see cref="DialogueUIController.choiceButtonPrefab"/> was never wired so
    ///      choice buttons never spawn when a node presents choices.
    ///
    /// Both fixes are applied via SerializedObject so they survive prefab save/load.
    /// Idempotent.
    /// </summary>
    public static class FixDialogueChoicesWiring
    {
        private const string NpcPrefabFolder = "Assets/Prefabs/NPCs/";
        private const string ChoiceButtonPrefabPath = "Assets/Prefabs/UI/Dialogue/DialogueChoiceButton.prefab";

        [MenuItem("AR_Grind_mill/Dialogue/FIX_CHOICES_WIRING_NOW")]
        public static void Run()
        {
            var choicePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(ChoiceButtonPrefabPath);
            if (choicePrefab == null)
            {
                Debug.LogError($"[FixDialogueChoicesWiring] Missing {ChoiceButtonPrefabPath} — cannot wire.");
                return;
            }
            var choiceBtn = choicePrefab.GetComponent<DialogueChoiceButton>();
            if (choiceBtn == null)
            {
                Debug.LogError($"[FixDialogueChoicesWiring] {ChoiceButtonPrefabPath} has no DialogueChoiceButton component.");
                return;
            }

            int fixedCount = 0;
            foreach (var npcName in new[] { "MrSix", "MrsFour" })
            {
                if (FixNpc(npcName, choiceBtn)) fixedCount++;
            }
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log($"[FixDialogueChoicesWiring] Done. Repaired {fixedCount} NPC prefab(s).");
        }

        private static bool FixNpc(string npcName, DialogueChoiceButton choiceBtn)
        {
            string prefabPath = NpcPrefabFolder + npcName + ".prefab";
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            if (prefab == null) return false;

            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            if (instance == null) return false;

            try
            {
                Transform canvasT = instance.transform.Find("DialogueCanvas");
                if (canvasT == null) return false;
                DialogueUIController ui = canvasT.GetComponent<DialogueUIController>();
                if (ui == null) return false;

                // The legitimate layout-aware choices container lives at Content/ChoicesRoot.
                Transform contentT = canvasT.Find("Content");
                if (contentT == null) return false;
                Transform legitChoices = contentT.Find("ChoicesRoot");
                if (legitChoices == null)
                {
                    Debug.LogError($"[FixDialogueChoicesWiring] {npcName}/DialogueCanvas/Content has no ChoicesRoot.");
                    return false;
                }

                bool changed = false;
                SerializedObject so = new SerializedObject(ui);

                // 1. Repoint choicesRoot to the Content/ChoicesRoot.
                SerializedProperty choicesProp = so.FindProperty("choicesRoot");
                bool alreadyCorrect = choicesProp.objectReferenceValue == (Object)legitChoices.GetComponent<RectTransform>();
                if (!alreadyCorrect)
                {
                    choicesProp.objectReferenceValue = legitChoices.GetComponent<RectTransform>();
                    changed = true;
                }

                // 2. Wire choiceButtonPrefab.
                SerializedProperty prefabProp = so.FindProperty("choiceButtonPrefab");
                if (prefabProp.objectReferenceValue == null)
                {
                    prefabProp.objectReferenceValue = choiceBtn;
                    changed = true;
                }
                else if (prefabProp.objectReferenceValue != (Object)choiceBtn)
                {
                    Debug.Log($"[FixDialogueChoicesWiring] {npcName} already has choiceButtonPrefab wired ({(prefabProp.objectReferenceValue as Object)?.name}). Leaving untouched.");
                }

                // 3. Remove the stray direct-child ChoicesRoot if it survived — buttons
                //    spawned there would ignore Content's layout and float over the panel.
                Transform stray = canvasT.Find("ChoicesRoot");
                if (stray != null && stray != legitChoices)
                {
                    Object.DestroyImmediate(stray.gameObject);
                    changed = true;
                }

                if (changed)
                {
                    so.ApplyModifiedPropertiesWithoutUndo();
                    PrefabUtility.SaveAsPrefabAsset(instance, prefabPath);
                    Debug.Log($"[FixDialogueChoicesWiring] Fixed {npcName}: choicesRoot → Content/ChoicesRoot, choiceButtonPrefab wired, stray ChoicesRoot removed.");
                }
                return changed;
            }
            finally
            {
                Object.DestroyImmediate(instance);
            }
        }
    }
}
#endif
