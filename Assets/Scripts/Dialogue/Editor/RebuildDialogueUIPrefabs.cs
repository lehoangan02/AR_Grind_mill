// SPDX-License-Identifier: Internal
// Rebuilds DialogueCanvas.prefab and DialogueChoiceButton.prefab using the project's
// established UI framework (UIScreenCanvas + Button + Panel + UIButton) so the dialogue
// UI matches the rest of the game's visual style. Also re-wires MrSix and MrsFour NPC
// prefabs so their DialogueCanvas children point at the freshly built asset and the
// DialogueUIController fields are wired correctly.
//
// Replaces the older hand-rolled prefabs that used a hardcoded dark background and the
// default Unity TMP font.
//
// Idempotent: re-running the menu item overwrites the prefabs in place (same path, same
// GUID) and re-wires the NPC prefabs to a clean state. Already-placed NPC scene
// instances will reconnect automatically because the prefab GUID is preserved.

#if UNITY_EDITOR
using AR_Grind_mill.Dialogue.UI;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace AR_Grind_mill.Dialogue.EditorTools
{
    public static class RebuildDialogueUIPrefabs
    {
        private const string DialogueCanvasPath       = "Assets/Prefabs/UI/Dialogue/DialogueCanvas.prefab";
        private const string DialogueChoiceButtonPath = "Assets/Prefabs/UI/Dialogue/DialogueChoiceButton.prefab";
        private const string UIScreenCanvasPath       = "Assets/Prefabs/UI/Screens/UIScreenCanvas.prefab";
        private const string ButtonPrefabPath         = "Assets/Prefabs/UI/Components/Button.prefab";
        private const string PanelPrefabPath          = "Assets/Prefabs/UI/Components/Panel.prefab";
        private const string NpcPrefabFolder          = "Assets/Prefabs/NPCs/";

        // Sprout Lands TMP font asset — same one used by MainMenuScreen/ConfirmationDialog
        // so the dialogue matches the rest of the UI.
        private const string SproutLandsFontGuid      = "dcbba2b32d21ad9cd8853e5e10b8eab6";

        [MenuItem("AR_Grind_mill/Dialogue/REBUILD_UI_PREFABS")]
        public static void Run()
        {
            DialogueChoiceButton choiceBtn = BuildDialogueChoiceButton();
            if (choiceBtn == null)
            {
                Debug.LogError("[RebuildDialogueUIPrefabs] Failed to build DialogueChoiceButton — aborting.");
                return;
            }

            DialogueUIController canvas = BuildDialogueCanvas(choiceBtn);
            if (canvas == null)
            {
                Debug.LogError("[RebuildDialogueUIPrefabs] Failed to build DialogueCanvas — aborting.");
                return;
            }

            foreach (var npcName in new[] { "MrSix", "MrsFour" })
            {
                RewireNpc(npcName);
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log("[RebuildDialogueUIPrefabs] All dialogue UI prefabs rebuilt.");
        }

        // ─── Choice Button ─────────────────────────────────────────────
        // Reuses Button.prefab so the dialogue buttons inherit the Sprout Lands sprites,
        // the UIButton hover/click audio + scale bounce behaviour, the transition
        // Animator, and the same TMP label layout that MainMenu / Confirmation use.
        private static DialogueChoiceButton BuildDialogueChoiceButton()
        {
            GameObject buttonPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(ButtonPrefabPath);
            if (buttonPrefab == null)
            {
                Debug.LogError($"[RebuildDialogueUIPrefabs] Missing source prefab at {ButtonPrefabPath}.");
                return null;
            }

            GameObject root = (GameObject)PrefabUtility.InstantiatePrefab(buttonPrefab);
            root.name = "DialogueChoiceButton";

            // Stretch to fill parent — the VerticalLayoutGroup on ChoicesRoot owns height.
            RectTransform rt = root.GetComponent<RectTransform>();
            rt.anchorMin = new Vector2(0f, 0f);
            rt.anchorMax = new Vector2(1f, 1f);
            rt.pivot = new Vector2(0.5f, 0.5f);
            rt.anchoredPosition = Vector2.zero;
            rt.sizeDelta = Vector2.zero;
            rt.localScale = Vector3.one;

            // Label is sized for VR world-space readability. AutoSizing keeps it tidy
            // when the same prefab is used in nested layouts.
            TMP_Text labelTmp = root.GetComponentInChildren<TMP_Text>(true);
            if (labelTmp != null)
            {
                labelTmp.fontSize = 24f;
                labelTmp.alignment = TextAlignmentOptions.Center;
                labelTmp.enableAutoSizing = true;
                labelTmp.fontSizeMin = 18f;
                labelTmp.fontSizeMax = 32f;
                labelTmp.color = new Color(0.15f, 0.10f, 0.05f, 1f); // Dark brown, matches Sprout Lands text.
            }

            // DialogueChoiceButton.Reset() auto-wires `button` + `label`.
            root.AddComponent<DialogueChoiceButton>();

            // SaveAsPrefabAsset overwrites the existing prefab in place — GUID is preserved.
            GameObject saved = PrefabUtility.SaveAsPrefabAsset(root, DialogueChoiceButtonPath);
            Object.DestroyImmediate(root);

            DialogueChoiceButton leaf = saved != null ? saved.GetComponent<DialogueChoiceButton>() : null;
            Debug.Log($"[RebuildDialogueUIPrefabs] Rebuilt {DialogueChoiceButtonPath}.");
            return leaf;
        }

        // ─── Canvas ────────────────────────────────────────────────────
        // Mirrors MainMenu.prefab / Confirmation.prefab structure: UIScreenCanvas root
        // hosts a Panel.prefab background; inside the panel a Content VerticalLayoutGroup
        // holds SpeakerLabel + LineText + ChoicesRoot. DialogueUIController lives on the
        // root and drives billboard + choice instantiation.
        private static DialogueUIController BuildDialogueCanvas(DialogueChoiceButton choiceBtn)
        {
            GameObject screenPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(UIScreenCanvasPath);
            GameObject panelPrefab  = AssetDatabase.LoadAssetAtPath<GameObject>(PanelPrefabPath);
            if (screenPrefab == null || panelPrefab == null)
            {
                Debug.LogError("[RebuildDialogueUIPrefabs] Missing UIScreenCanvas or Panel source prefab.");
                return null;
            }

            // Root: Canvas + CanvasScaler + CanvasGroup + TrackedDeviceGraphicRaycaster.
            GameObject root = (GameObject)PrefabUtility.InstantiatePrefab(screenPrefab);
            root.name = "DialogueCanvas";

            // Sized so that canvasScale 0.0018 (= 0.0018 × 720 / 100 ≈ 0.013 m? No — see note)
            // World-space size = rect.sizeDelta × canvasScale. The controller applies
            // canvasScale in Awake, so we set the rect to match: 720×540 × 0.001 ≈ 0.72m×0.54m.
            RectTransform rootRect = root.GetComponent<RectTransform>();
            rootRect.sizeDelta = new Vector2(720f, 540f);
            rootRect.localScale = Vector3.one;

            // Visual background — Sprout Lands panel sprite.
            GameObject panel = (GameObject)PrefabUtility.InstantiatePrefab(panelPrefab);
            panel.name = "Panel";
            panel.transform.SetParent(root.transform, false);
            RectTransform panelRect = panel.GetComponent<RectTransform>();
            panelRect.anchorMin = Vector2.zero;
            panelRect.anchorMax = Vector2.one;
            panelRect.pivot = new Vector2(0.5f, 0.5f);
            panelRect.anchoredPosition = Vector2.zero;
            panelRect.sizeDelta = new Vector2(-30f, -20f); // Inset 15px left/right, 10px top/bottom.
            panelRect.localScale = Vector3.one;

            // Content area inside the panel — drives the dialogue layout.
            GameObject content = new GameObject("Content", typeof(RectTransform));
            content.transform.SetParent(panel.transform, false);
            RectTransform contentRect = content.GetComponent<RectTransform>();
            contentRect.anchorMin = Vector2.zero;
            contentRect.anchorMax = Vector2.one;
            contentRect.pivot = new Vector2(0.5f, 0.5f);
            contentRect.anchoredPosition = Vector2.zero;
            contentRect.sizeDelta = new Vector2(-40f, -40f);
            contentRect.localScale = Vector3.one;

            VerticalLayoutGroup contentVlg = content.AddComponent<VerticalLayoutGroup>();
            contentVlg.padding = new RectOffset(20, 20, 20, 20);
            contentVlg.spacing = 16f;
            contentVlg.childAlignment = TextAnchor.UpperCenter;
            contentVlg.childControlWidth = true;
            contentVlg.childControlHeight = true;
            contentVlg.childForceExpandWidth = true;
            contentVlg.childForceExpandHeight = false;

            // Speaker label — bold, dark brown, smaller than the body text.
            GameObject speaker = CreateTmpText(
                name: "SpeakerLabel",
                parent: content.transform,
                fontSize: 28f,
                style: FontStyles.Bold,
                color: new Color(0.35f, 0.22f, 0.10f, 1f),
                alignment: TextAlignmentOptions.Center);

            LayoutElement speakerLE = speaker.AddComponent<LayoutElement>();
            speakerLE.preferredHeight = 36f;
            speakerLE.minHeight = 28f;

            // Line text — body, dark, word-wrapped, fills available middle space.
            GameObject line = CreateTmpText(
                name: "LineText",
                parent: content.transform,
                fontSize: 22f,
                style: FontStyles.Normal,
                color: new Color(0.15f, 0.10f, 0.05f, 1f),
                alignment: TextAlignmentOptions.TopLeft);

            LayoutElement lineLE = line.AddComponent<LayoutElement>();
            lineLE.flexibleHeight = 1f;
            lineLE.minHeight = 80f;

            // Choices container — VerticalLayoutGroup that the controller instantiates
            // DialogueChoiceButton instances into.
            GameObject choices = new GameObject("ChoicesRoot", typeof(RectTransform));
            choices.transform.SetParent(content.transform, false);
            RectTransform choicesRect = choices.GetComponent<RectTransform>();
            choicesRect.anchorMin = new Vector2(0f, 0f);
            choicesRect.anchorMax = new Vector2(1f, 0f);
            choicesRect.pivot = new Vector2(0.5f, 0f);
            choicesRect.anchoredPosition = Vector2.zero;
            choicesRect.sizeDelta = new Vector2(0f, 0f);
            choicesRect.localScale = Vector3.one;

            VerticalLayoutGroup choicesVlg = choices.AddComponent<VerticalLayoutGroup>();
            choicesVlg.spacing = 10f;
            choicesVlg.childAlignment = TextAnchor.UpperCenter;
            choicesVlg.childControlWidth = true;
            choicesVlg.childControlHeight = false;
            choicesVlg.childForceExpandWidth = true;
            choicesVlg.childForceExpandHeight = false;

            LayoutElement choicesLE = choices.AddComponent<LayoutElement>();
            choicesLE.preferredHeight = 200f;
            choicesLE.minHeight = 60f;

            // Add DialogueUIController and wire all serialized fields. SerializedObject is
            // the durable path — direct field assignment would not persist across the
            // prefab save.
            DialogueUIController ui = root.AddComponent<DialogueUIController>();

            SerializedObject so = new SerializedObject(ui);
            so.FindProperty("canvas").objectReferenceValue            = root.GetComponent<Canvas>();
            so.FindProperty("contentRoot").objectReferenceValue       = panelRect;
            so.FindProperty("speakerLabel").objectReferenceValue      = speaker.GetComponent<TMP_Text>();
            so.FindProperty("lineText").objectReferenceValue          = line.GetComponent<TMP_Text>();
            so.FindProperty("choicesRoot").objectReferenceValue       = choicesRect;
            so.FindProperty("choiceButtonPrefab").objectReferenceValue = choiceBtn;
            so.FindProperty("headHeightOffset").floatValue            = 1.7f;
            so.FindProperty("forwardOffset").floatValue               = 0.35f;
            so.FindProperty("canvasScale").floatValue                 = 0.001f;
            so.FindProperty("lockPitchToHorizontal").boolValue         = true;
            so.ApplyModifiedPropertiesWithoutUndo();

            GameObject saved = PrefabUtility.SaveAsPrefabAsset(root, DialogueCanvasPath);
            Object.DestroyImmediate(root);

            DialogueUIController savedUi = saved != null ? saved.GetComponent<DialogueUIController>() : null;
            Debug.Log($"[RebuildDialogueUIPrefabs] Rebuilt {DialogueCanvasPath}.");
            return savedUi;
        }

        // Helper: build a properly configured TMP_Text GameObject with the Sprout Lands font.
        private static GameObject CreateTmpText(string name, Transform parent, float fontSize, FontStyles style, Color color, TextAlignmentOptions alignment)
        {
            GameObject go = new GameObject(name, typeof(RectTransform));
            go.transform.SetParent(parent, false);

            RectTransform rt = go.GetComponent<RectTransform>();
            rt.anchorMin = Vector2.zero;
            rt.anchorMax = Vector2.one;
            rt.pivot = new Vector2(0.5f, 0.5f);
            rt.anchoredPosition = Vector2.zero;
            rt.sizeDelta = Vector2.zero;
            rt.localScale = Vector3.one;

            go.AddComponent<CanvasRenderer>();

            TMP_Text tmp = go.AddComponent<TextMeshProUGUI>();
            tmp.fontSize = fontSize;
            tmp.fontStyle = style;
            tmp.color = color;
            tmp.alignment = alignment;
            tmp.textWrappingMode = TextWrappingModes.Normal;
            tmp.richText = true;
            tmp.raycastTarget = false;

            // Apply the Sprout Lands font asset so the dialogue visually matches the rest
            // of the game's UI (MainMenu, Confirmation, Pause, Settings all use this font).
            string fontPath = AssetDatabase.GUIDToAssetPath(SproutLandsFontGuid);
            TMP_FontAsset sproutFont = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(fontPath);
            if (sproutFont != null)
            {
                tmp.font = sproutFont;
            }

            return go;
        }

        // ─── NPC re-wire ───────────────────────────────────────────────
        // The NPC prefabs previously held PrefabInstance overrides that referenced file
        // IDs of the old DialogueCanvas's children. After the rebuild those references
        // are stale, so we strip the child entirely and drop in a fresh prefab instance
        // with the standard overrides applied.
        private static void RewireNpc(string npcName)
        {
            string prefabPath = NpcPrefabFolder + npcName + ".prefab";
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            if (prefab == null)
            {
                Debug.LogWarning($"[RebuildDialogueUIPrefabs] Missing NPC prefab at {prefabPath} — skipping.");
                return;
            }

            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            if (instance == null)
            {
                Debug.LogError($"[RebuildDialogueUIPrefabs] Failed to instantiate {prefabPath}.");
                return;
            }

            try
            {
                // 1. Strip the old DialogueCanvas child (its source-prefab file IDs are
                //    stale after the rebuild).
                Transform oldCanvasT = instance.transform.Find("DialogueCanvas");
                if (oldCanvasT != null)
                {
                    Object.DestroyImmediate(oldCanvasT.gameObject);
                }

                // 2. Drop in a fresh DialogueCanvas instance.
                GameObject canvasPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(DialogueCanvasPath);
                GameObject newCanvas = (GameObject)PrefabUtility.InstantiatePrefab(canvasPrefab);
                newCanvas.name = "DialogueCanvas";
                newCanvas.transform.SetParent(instance.transform, false);

                newCanvas.transform.localPosition = Vector3.zero;
                newCanvas.transform.localRotation = Quaternion.identity;
                newCanvas.transform.localScale = Vector3.one;

                // 3. Apply standard VR dialogue positioning / wiring.
                DialogueUIController ui = newCanvas.GetComponent<DialogueUIController>();
                if (ui != null)
                {
                    SerializedObject so = new SerializedObject(ui);
                    so.FindProperty("anchor").objectReferenceValue         = instance.transform;
                    so.FindProperty("forwardOffset").floatValue            = 0.35f;
                    so.FindProperty("canvasScale").floatValue              = 0.0018f;
                    so.FindProperty("headHeightOffset").floatValue         = 1.7f;
                    so.FindProperty("lockPitchToHorizontal").boolValue     = true;
                    so.ApplyModifiedPropertiesWithoutUndo();
                }

                // 4. Adjust the proximity prompt so it sits above the new panel layout
                //    (was sized against the old canvas in FixDialogueUIUX).
                Transform promptT = instance.transform.Find("PromptRoot");
                if (promptT != null)
                {
                    promptT.localPosition = new Vector3(0f, 2.1f, 0.4f);
                    promptT.localScale    = new Vector3(0.0055f, 0.0055f, 0.0055f);
                }

                PrefabUtility.SaveAsPrefabAsset(instance, prefabPath);
                Debug.Log($"[RebuildDialogueUIPrefabs] Rewired {prefabPath}.");
            }
            finally
            {
                Object.DestroyImmediate(instance);
            }
        }
    }
}
#endif