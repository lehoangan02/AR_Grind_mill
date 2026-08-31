#if UNITY_EDITOR
using AR_Grind_mill.Dialogue.UI;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.UI;

namespace AR_Grind_mill.Dialogue.EditorTools
{
    /// <summary>
    /// One-shot sizing + raycaster fixes for the dialogue prefabs and scene wiring:
    ///
    /// A. Per-NPC (MrSix, MrsFour) prefab edits:
    ///   • Set DialogueUIController.canvasScale to 0.0018 (≈ 0.72m × 0.54m panel)
    ///     and forwardOffset to 0.35m so the panel reads at face-distance.
    ///   • Add a GraphicRaycaster alongside the existing TrackedDeviceGraphicRaycaster
    ///     so the Unity StandaloneInputModule (mouse) can click choices in the editor.
    ///   • Reposition + resize the PromptRoot GameObject (under NPC) so the world-space
    ///     "Press [Trigger] to talk" label is small and centered above the head instead of
    ///     200m-wide and buried at the NPC's feet.
    ///
    /// B. Scene edit (current open scene):
    ///   • Add a StandaloneInputModule to /EventSystem so mouse picks register on the
    ///     GraphicRaycaster we just added. XRUIInputModule stays active for VR builds.
    ///
    /// Idempotent — re-run safely.
    /// </summary>
    public static class FixDialogueUIUX
    {
        private const string NpcPrefabFolder        = "Assets/Prefabs/NPCs/";
        private const string CanvasPrefabPath       = "Assets/Prefabs/UI/Dialogue/DialogueCanvas.prefab";
        private const string PromptPrefabPath       = "Assets/Prefabs/UI/Dialogue/DialoguePrompt.prefab";

        private const float NewCanvasScale   = 0.0018f;  // 400px × 0.0018 = 0.72m wide
        private const float NewForwardOffset = 0.35f;   // place 35cm in front of NPC head

        [MenuItem("AR_Grind_mill/Dialogue/FIX_UI_UX_NOW")]
        public static void Run()
        {
            int npcPrefabsChanged = 0;
            foreach (var npcName in new[] { "MrSix", "MrsFour" })
            {
                if (FixNpcPrefab(npcName)) npcPrefabsChanged++;
            }
            FixBasePromptPrefab();
            FixEventSystemInScene();
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log($"[FixDialogueUIUX] Done. Changed {npcPrefabsChanged} NPC prefab(s).");
        }

        private static bool FixNpcPrefab(string npcName)
        {
            string prefabPath = NpcPrefabFolder + npcName + ".prefab";
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            if (prefab == null)
            {
                Debug.LogWarning($"[FixDialogueUIUX] Missing prefab {prefabPath} — skipping.");
                return false;
            }

            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            if (instance == null)
            {
                Debug.LogError($"[FixDialogueUIUX] Failed to instantiate {prefabPath}.");
                return false;
            }

            try
            {
                bool changed = false;

                Transform canvasT = instance.transform.Find("DialogueCanvas");
                if (canvasT != null)
                {
                    DialogueUIController ui = canvasT.GetComponent<DialogueUIController>();
                    if (ui != null)
                    {
                        ui.canvasScale   = NewCanvasScale;
                        ui.forwardOffset = NewForwardOffset;
                        changed = true;
                    }

                    // The world-space canvas came from DialogueCanvas.prefab — add the
                    // regular GraphicRaycaster on the canvas child *here*, not on the prefab,
                    // so other UIAnchor canvases keep TrackedDevice-only behaviour.
                    if (canvasT.GetComponent<GraphicRaycaster>() == null)
                    {
                        canvasT.gameObject.AddComponent<GraphicRaycaster>();
                        changed = true;
                    }
                }

                Transform promptT = instance.transform.Find("PromptRoot");
                if (promptT != null)
                {
                    // 200 × 50 sizeDelta @ localScale 1 is a 200m × 50m panel. Shrink it.
                    promptT.localScale = new Vector3(0.0055f, 0.0055f, 0.0055f);
                    // Park it roughly above the NPC's head, slightly forward of the body so
                    // the player walking toward the NPC sees it from head height.
                    promptT.localPosition = new Vector3(0f, 2.1f, 0.4f);
                    changed = true;
                }

                if (changed)
                {
                    PrefabUtility.SaveAsPrefabAsset(instance, prefabPath);
                }
                return changed;
            }
            finally
            {
                Object.DestroyImmediate(instance);
            }
        }

        /// <summary>
        /// Update the shared DialoguePrompt prefab — its root RectTransform sizeDelta is
        /// 200 × 50 which, combined with localScale 1, makes the prompt enormous. We
        /// rebuild the prompt root from scratch onto a sized pre-fab-instantiation copy
        /// so the change persists without altering other dialogue references.
        /// </summary>
        private static void FixBasePromptPrefab()
        {
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(PromptPrefabPath);
            if (prefab == null)
            {
                Debug.LogWarning($"[FixDialogueUIUX] Missing base prompt prefab {PromptPrefabPath}.");
                return;
            }

            GameObject inst = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            if (inst == null) return;

            try
            {
                // Shrink the world-space canvas + its background; the PromptLabel already
                // anchors 0..1 so it tracks the new content area.
                RectTransform rt = inst.GetComponent<RectTransform>();
                if (rt != null)
                {
                    rt.sizeDelta = new Vector2(140f, 36f);
                }
                Transform bg = inst.transform.Find("Background");
                if (bg != null)
                {
                    bg.localScale = Vector3.one;
                    Image bgImg = bg.GetComponent<Image>();
                    if (bgImg != null) bgImg.color = new Color(0f, 0f, 0f, 0.55f);
                }
                TMP_Text label = null;
                Transform labelT = inst.transform.Find("PromptLabel");
                if (labelT != null) label = labelT.GetComponent<TMP_Text>();
                if (label != null)
                {
                    label.fontSize = 4f;
                    label.alignment = TextAlignmentOptions.Center;
                }
                // Bring forward a GraphicRaycaster too so clicks on the prompt itself
                // (in case a designer wires one) work in editor mouse mode.
                if (inst.GetComponent<GraphicRaycaster>() == null)
                {
                    inst.AddComponent<GraphicRaycaster>();
                }

                PrefabUtility.SaveAsPrefabAsset(inst, PromptPrefabPath);
                Debug.Log($"[FixDialogueUIUX] Resized base prompt prefab {PromptPrefabPath}.");
            }
            finally
            {
                Object.DestroyImmediate(inst);
            }
        }

        /// <summary>
        /// Adds a StandaloneInputModule to /EventSystem in the currently-open scene so
        /// mouse picks register on the new GraphicRaycaster we added above. The scene's
        /// XRUIInputModule stays in place for the VR build path.
        /// </summary>
        private static void FixEventSystemInScene()
        {
            var scene = EditorSceneManager.GetActiveScene();
            if (!scene.IsValid() || !scene.isLoaded) return;

            GameObject esGo = null;
            foreach (var root in scene.GetRootGameObjects())
            {
                if (root.name == "EventSystem") { esGo = root; break; }
            }
            if (esGo == null)
            {
                Debug.LogWarning("[FixDialogueUIUX] No EventSystem in active scene — skipping input module fix.");
                return;
            }

            EventSystem es = esGo.GetComponent<EventSystem>();
            if (es == null)
            {
                Debug.LogWarning("[FixDialogueUIUX] /EventSystem has no EventSystem component — skipping.");
                return;
            }

            // Don't double-add.
            if (esGo.GetComponent<StandaloneInputModule>() != null)
            {
                Debug.Log("[FixDialogueUIUX] StandaloneInputModule already present on /EventSystem.");
                return;
            }

            // If an XRUIInputModule is present, leave it — both modules can coexist; the
            // EventSystem queries all of them, with Standalone owning mouse and XR owning
            // device input. (Standard pattern in Unity 6 + XR Interaction Toolkit.)
            var xrModule = esGo.GetComponent<XRUIInputModule>();
            esGo.AddComponent<StandaloneInputModule>();
            EditorUtility.SetDirty(esGo);
            EditorSceneManager.MarkSceneDirty(scene);
            EditorSceneManager.SaveScene(scene);
            Debug.Log($"[FixDialogueUIUX] Added StandaloneInputModule to /EventSystem (XRUIInputModule was {(xrModule != null ? "kept" : "missing")}).");
        }
    }
}
#endif
