#if UNITY_EDITOR
using AR_Grind_mill.Dialogue.UI;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace AR_Grind_mill.Dialogue.EditorTools
{
    /// <summary>
    /// One-shot fix-up for the Mr. Six / Mrs. Four NPC prefabs: the original
    /// wire script left their <see cref="DialogueUIController.canvas"/> field
    /// unassigned and the "DialogueCanvas" child empty. This populates the
    /// child by parenting an instance of the existing DialogueCanvas.prefab
    /// under each NPC and wiring the controller's references.
    /// Idempotent — safe to re-run.
    /// </summary>
    public static class FixNPCDialogueCanvases
    {
        private const string NpcPrefabFolder = "Assets/Prefabs/NPCs/";
        private const string DialogueCanvasPrefabPath = "Assets/Prefabs/UI/Dialogue/DialogueCanvas.prefab";

        [MenuItem("AR_Grind_mill/Dialogue/FIX_CANVAS_NOW")]
        public static void Run()
        {
            GameObject canvasPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(DialogueCanvasPrefabPath);
            if (canvasPrefab == null)
            {
                Debug.LogError($"[FixNPCDialogueCanvases] Missing prefab at {DialogueCanvasPrefabPath}. Cannot fix.");
                return;
            }

            foreach (var npcName in new[] { "MrSix", "MrsFour" })
            {
                FixNpc(npcName, canvasPrefab);
            }
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log("[FixNPCDialogueCanvases] Done.");
        }

        private static void FixNpc(string npcName, GameObject canvasPrefab)
        {
            string prefabPath = NpcPrefabFolder + npcName + ".prefab";
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            if (prefab == null)
            {
                Debug.LogWarning($"[FixNPCDialogueCanvases] Prefab not found at {prefabPath}. Skipping.");
                return;
            }

            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            if (instance == null)
            {
                Debug.LogError($"[FixNPCDialogueCanvases] Failed to instantiate {prefabPath}.");
                return;
            }

            try
            {
                Transform oldHolder = instance.transform.Find("DialogueCanvas");
                Vector3 localPos = Vector3.zero;
                Quaternion localRot = Quaternion.identity;
                int siblingIndex = -1;
                if (oldHolder != null)
                {
                    localPos = oldHolder.localPosition;
                    localRot = oldHolder.localRotation;
                    siblingIndex = oldHolder.GetSiblingIndex();
                    DestroyImmediateSafely(oldHolder.gameObject);
                }

                GameObject canvasInstance = (GameObject)PrefabUtility.InstantiatePrefab(canvasPrefab, instance.transform);
                if (canvasInstance == null)
                {
                    Debug.LogError($"[FixNPCDialogueCanvases] Failed to instantiate canvas prefab on {npcName}.");
                    return;
                }

                canvasInstance.name = "DialogueCanvas";
                canvasInstance.transform.localPosition = localPos;
                canvasInstance.transform.localRotation = localRot;
                if (siblingIndex >= 0)
                {
                    canvasInstance.transform.SetSiblingIndex(siblingIndex);
                }

                Canvas canvas = canvasInstance.GetComponent<Canvas>();
                if (canvas == null)
                {
                    canvas = canvasInstance.GetComponentInChildren<Canvas>();
                }
                if (canvas == null)
                {
                    Debug.LogError($"[FixNPCDialogueCanvases] Instantiated canvas on {npcName} has no Canvas component.");
                    return;
                }

                Transform content = canvasInstance.transform.Find("Content");
                RectTransform contentRoot = content != null ? content.GetComponent<RectTransform>() : null;

                TMP_Text speakerLabel = null;
                TMP_Text lineText = null;
                RectTransform choicesRoot = null;
                if (content != null)
                {
                    Transform speakerT = content.Find("SpeakerLabel");
                    if (speakerT != null) speakerLabel = speakerT.GetComponent<TMPro.TMP_Text>();

                    Transform lineT = content.Find("LineText");
                    if (lineT != null) lineText = lineT.GetComponent<TMPro.TMP_Text>();

Transform choicesT = canvasInstance.transform.Find("ChoicesRoot");
                if (choicesT == null)
                {
                    GameObject choicesGo = new GameObject("ChoicesRoot", typeof(RectTransform));
                    choicesGo.transform.SetParent(canvasInstance.transform, worldPositionStays: false);
                    choicesT = choicesGo.transform;
                }
                choicesRoot = choicesT.GetComponent<RectTransform>();
                choicesRoot.anchorMin = new Vector2(0.1f, 0f);
                choicesRoot.anchorMax = new Vector2(0.9f, 0.3f);
                choicesRoot.pivot = new Vector2(0.5f, 0f);
                choicesRoot.offsetMin = Vector2.zero;
                choicesRoot.offsetMax = Vector2.zero;
                }

                DialogueUIController ui = instance.GetComponent<DialogueUIController>();
                if (ui == null)
                {
                    Debug.LogError($"[FixNPCDialogueCanvases] '{npcName}' root has no DialogueUIController.");
                    return;
                }

                SerializedObject so = new SerializedObject(ui);
                if (canvas != null) so.FindProperty("canvas").objectReferenceValue = canvas;
                if (contentRoot != null) so.FindProperty("contentRoot").objectReferenceValue = contentRoot;
                if (speakerLabel != null) so.FindProperty("speakerLabel").objectReferenceValue = speakerLabel;
                if (lineText != null) so.FindProperty("lineText").objectReferenceValue = lineText;
                if (choicesRoot != null) so.FindProperty("choicesRoot").objectReferenceValue = choicesRoot;
                so.ApplyModifiedPropertiesWithoutUndo();

                PrefabUtility.SaveAsPrefabAsset(instance, prefabPath);
                Debug.Log($"[FixNPCDialogueCanvases] Wired canvas for {npcName}.");
            }
            finally
            {
                DestroyImmediateSafely(instance);
            }
        }

        private static void DestroyImmediateSafely(Object obj)
        {
            if (obj == null) return;
            if (Application.isPlaying) Object.Destroy(obj);
            else Object.DestroyImmediate(obj);
        }
    }
}
#endif