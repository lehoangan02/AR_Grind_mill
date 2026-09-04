#if UNITY_EDITOR
using AR_Grind_mill.Dialogue.UI;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace AR_Grind_mill.Dialogue.EditorTools
{
    /// <summary>
    /// Repairs the "NPCs fly upward" bug by relocating <see cref="DialogueUIController"/>
    /// to the canvas child with each field wired explicitly via SerializedProperty.
    ///
    /// ROOT CAUSE: the wire-up script placed <see cref="DialogueUIController"/> on
    /// the NPC root. Its <c>LateUpdate</c> writes <c>transform.position = anchor.position +
    /// Vector3.up * headHeightOffset</c>; because <c>anchor</c> is the NPC's own transform,
    /// every LateUpdate added <c>headHeightOffset</c> (1.7m) to the NPC's Y — infinite ascent.
    /// The controller must live on the canvas child so its <c>transform</c> refers to the canvas.
    /// </summary>
    public static class FixAddDialogueUIControllerToCanvas
    {
        private const string NpcPrefabFolder = "Assets/Prefabs/NPCs/";
        private const string DialogueCanvasPrefabPath = "Assets/Prefabs/UI/Dialogue/DialogueCanvas.prefab";

        [MenuItem("AR_Grind_mill/Dialogue/ADD_UI_TO_CANVAS_NOW")]
        public static void Run()
        {
            int changed = 0;
            foreach (var npcName in new[] { "MrSix", "MrsFour" })
            {
                if (FixNpc(npcName)) changed++;
            }
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log($"[FixAddDialogueUIControllerToCanvas] Done. Changed {changed} prefab(s).");
        }

        private static bool FixNpc(string npcName)
        {
            string prefabPath = NpcPrefabFolder + npcName + ".prefab";
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            if (prefab == null)
            {
                Debug.LogWarning($"[FixAddDialogueUIControllerToCanvas] Missing prefab at {prefabPath}.");
                return false;
            }

            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            if (instance == null)
            {
                Debug.LogError($"[FixAddDialogueUIControllerToCanvas] Failed to instantiate {prefabPath}.");
                return false;
            }

            try
            {
                Transform canvasT = instance.transform.Find("DialogueCanvas");
                if (canvasT == null)
                {
                    Debug.LogError($"[FixAddDialogueUIControllerToCanvas] {npcName} has no DialogueCanvas child.");
                    return false;
                }

                DialogueUIController ui = canvasT.GetComponent<DialogueUIController>();
                bool created = false;
                if (ui == null)
                {
                    ui = canvasT.gameObject.AddComponent<DialogueUIController>();
                    created = true;
                }

                Canvas canvas = canvasT.GetComponent<Canvas>();
                if (canvas == null)
                {
                    canvas = canvasT.GetComponentInChildren<Canvas>(true);
                }
                Transform contentT = canvasT.Find("Content");
                RectTransform contentRoot = contentT != null ? contentT.GetComponent<RectTransform>() : null;

                TMP_Text speakerLabel = null;
                TMP_Text lineText = null;
                if (contentT != null)
                {
                    Transform sp = contentT.Find("SpeakerLabel");
                    if (sp != null) speakerLabel = sp.GetComponent<TMPro.TMP_Text>();
                    Transform lt = contentT.Find("LineText");
                    if (lt != null) lineText = lt.GetComponent<TMPro.TMP_Text>();
                }

                Transform choicesT = canvasT.Find("ChoicesRoot");
                if (choicesT == null) choicesT = canvasT.Find("contentRoot");
                RectTransform choicesRoot = choicesT != null ? choicesT.GetComponent<RectTransform>() : null;

                SerializedObject so = new SerializedObject(ui);
                if (canvas != null) so.FindProperty("canvas").objectReferenceValue = canvas;
                if (contentRoot != null) so.FindProperty("contentRoot").objectReferenceValue = contentRoot;
                if (speakerLabel != null) so.FindProperty("speakerLabel").objectReferenceValue = speakerLabel;
                if (lineText != null) so.FindProperty("lineText").objectReferenceValue = lineText;
                if (choicesRoot != null) so.FindProperty("choicesRoot").objectReferenceValue = choicesRoot;
                so.FindProperty("anchor").objectReferenceValue = instance.transform;
                so.ApplyModifiedPropertiesWithoutUndo();

                Debug.Log($"[FixAddDialogueUIControllerToCanvas] {(created ? "Added" : "Reused")} DialogueUIController on canvas child of {npcName}.");

                PrefabUtility.SaveAsPrefabAsset(instance, prefabPath);
                return true;
            }
            finally
            {
                if (Application.isPlaying) Object.Destroy(instance);
                else Object.DestroyImmediate(instance);
            }
        }
    }
}
#endif
