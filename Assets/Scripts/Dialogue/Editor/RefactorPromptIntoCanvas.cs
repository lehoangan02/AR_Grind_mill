// RefactorPromptIntoCanvas: relocates each NPC's "Press [Trigger] to talk" prompt
// from its own world-space canvas (under a separate PromptRoot) into a child
// slot inside the existing DialogueCanvas. The prompt's child RectTransform rides
// the dialogue canvas's billboard, so DialoguePromptUI no longer needs its own
// LateUpdate. The old PromptRoot subtree and DialoguePrompt.prefab are deleted.

using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using AR_Grind_mill.Dialogue.UI;

namespace AR_Grind_mill.Dialogue.EditorTools
{
    public static class RefactorPromptIntoCanvas
    {
        private const string PromptPrefabPath = "Assets/Prefabs/UI/Dialogue/DialoguePrompt.prefab";

        private const string DefaultPromptText = "Press [Trigger] to talk";

        [MenuItem("AR_Grind_mill/Dialogue/REFACTOR_PROMPT_INTO_CANVAS_NOW")]
        private static void Run()
        {
            int total = 0;
            int totalScenes = 0;
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (!scene.isLoaded) continue;
                totalScenes++;
                GameObject[] roots = scene.GetRootGameObjects();
                foreach (var root in roots)
                {
                    var prompts = root.GetComponentsInChildren<DialoguePromptUI>(true);
                    foreach (var prompt in prompts)
                    {
                        if (RefactorOne(prompt, scene.name))
                        {
                            total++;
                        }
                    }
                }
            }

            if (total > 0)
            {
                EditorSceneManager.MarkAllScenesDirty();
                EditorSceneManager.SaveOpenScenes();
            }

            // Delete the now-obsolete prefab so future scene work doesn't reference it.
            if (AssetDatabase.LoadAssetAtPath<GameObject>(PromptPrefabPath) != null)
            {
                AssetDatabase.DeleteAsset(PromptPrefabPath);
                Debug.Log($"[RefactorPromptIntoCanvas] Deleted obsolete prefab '{PromptPrefabPath}'.");
            }

            Debug.Log($"[RefactorPromptIntoCanvas] Done. Refactored {total} NPC(s) across {totalScenes} scene(s).");
        }

        private static bool RefactorOne(DialoguePromptUI prompt, string sceneName)
        {
            var npc = prompt.transform;
            if (npc.name != "MrSix" && npc.name != "MrsFour")
            {
                return false;
            }

            // Find the existing DialogueCanvas.
            var dialogueCanvas = npc.Find("DialogueCanvas");
            if (dialogueCanvas == null)
            {
                Debug.LogWarning($"[RefactorPromptIntoCanvas] {npc.name}: no DialogueCanvas found - skipped.");
                return false;
            }

            // Already refactored? (idempotency check)
            var existing = dialogueCanvas.Find("Prompt");
            if (existing != null && existing.GetComponentInChildren<TMP_Text>(true) != null)
            {
                Debug.Log($"[RefactorPromptIntoCanvas] {npc.name}: already refactored - skipped.");
                return false;
            }

            // Build the new Prompt child inside the dialogue canvas.
            var promptGo = new GameObject("Prompt", typeof(RectTransform), typeof(CanvasRenderer));
            promptGo.transform.SetParent(dialogueCanvas, false);
            var promptRect = (RectTransform)promptGo.transform;
            promptRect.anchorMin = new Vector2(0.5f, 1f);
            promptRect.anchorMax = new Vector2(0.5f, 1f);
            promptRect.pivot = new Vector2(0.5f, 1f);
            promptRect.anchoredPosition = new Vector2(0f, -10f);
            promptRect.sizeDelta = new Vector2(280f, 36f);
            promptRect.localScale = Vector3.one;

            // Background image for legibility against the world.
            var bg = new GameObject("Background", typeof(RectTransform), typeof(CanvasRenderer), typeof(Image));
            bg.transform.SetParent(promptGo.transform, false);
            var bgRect = (RectTransform)bg.transform;
            bgRect.anchorMin = Vector2.zero;
            bgRect.anchorMax = Vector2.one;
            bgRect.offsetMin = Vector2.zero;
            bgRect.offsetMax = Vector2.zero;
            var bgImg = bg.GetComponent<Image>();
            bgImg.color = new Color(0f, 0f, 0f, 0.55f);
            bgImg.raycastTarget = false;

            // Text label.
            var labelGo = new GameObject("PromptLabel", typeof(RectTransform), typeof(CanvasRenderer));
            labelGo.transform.SetParent(promptGo.transform, false);
            var labelRect = (RectTransform)labelGo.transform;
            labelRect.anchorMin = Vector2.zero;
            labelRect.anchorMax = Vector2.one;
            labelRect.offsetMin = new Vector2(8f, 4f);
            labelRect.offsetMax = new Vector2(-8f, -4f);

            var label = labelGo.AddComponent<TextMeshProUGUI>();
            label.text = DefaultPromptText;
            label.fontSize = 6f;
            label.alignment = TextAlignmentOptions.Center;
            label.color = Color.white;
            label.raycastTarget = false;
            label.enableWordWrapping = false;
            label.textWrappingMode = TextWrappingModes.NoWrap;

            // Wire DialoguePromptUI references.
            prompt.promptRoot = promptGo;
            prompt.promptLabel = label;

            // Hide the prompt until proximity fires.
            promptGo.SetActive(false);

            // Delete the old PromptRoot subtree if it exists.
            var oldRoot = npc.Find("PromptRoot");
            if (oldRoot != null)
            {
                Object.DestroyImmediate(oldRoot.gameObject, true);
            }

            EditorUtility.SetDirty(prompt);
            EditorUtility.SetDirty(dialogueCanvas);
            Debug.Log($"[RefactorPromptIntoCanvas] {npc.name}: created Prompt child of DialogueCanvas and removed old PromptRoot.");
            return true;
        }
    }
}
