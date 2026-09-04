// AddLayoutGroupToChoicesRoot: gives ChoicesRoot a VerticalLayoutGroup +
// ContentSizeFitter so instantiated choice buttons stack vertically instead of
// all rendering on top of each other. Re-anchors ChoicesRoot to bottom-stretched
// so it can grow downward as more choices appear.

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AR_Grind_mill.Dialogue.EditorTools
{
    public static class AddLayoutGroupToChoicesRoot
    {
        private const string DialogueCanvasPrefabPath = "Assets/Prefabs/UI/Dialogue/DialogueCanvas.prefab";

        [MenuItem("AR_Grind_mill/Dialogue/ADD_LAYOUT_GROUP_TO_CHOICES_ROOT")]
        private static void Run()
        {
            int sceneFixed = 0;
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (!scene.isLoaded) continue;
                if (FixInScene(scene, out int n))
                {
                    sceneFixed += n;
                }
            }

            if (FixPrefab(out int prefabFixed))
            {
                AssetDatabase.SaveAssets();
            }

            if (sceneFixed > 0)
            {
                EditorSceneManager.MarkAllScenesDirty();
                EditorSceneManager.SaveOpenScenes();
            }

            Debug.Log($"[AddLayoutGroupToChoicesRoot] Done. Fixed {sceneFixed} ChoicesRoot(s) in scene(s), {prefabFixed} in prefab.");
        }

        private static bool FixInScene(Scene scene, out int fixedCount)
        {
            fixedCount = 0;
            GameObject[] roots = scene.GetRootGameObjects();
            foreach (var root in roots)
            {
                var choicesRoots = root.GetComponentsInChildren<RectTransform>(true);
                foreach (var rt in choicesRoots)
                {
                    if (rt.name == "ChoicesRoot" && rt.parent != null && rt.parent.name == "Content")
                    {
                        if (ApplyLayout(rt.gameObject))
                        {
                            fixedCount++;
                        }
                    }
                }
            }
            return fixedCount > 0;
        }

        private static bool FixPrefab(out int fixedCount)
        {
            fixedCount = 0;
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(DialogueCanvasPrefabPath);
            if (prefab == null) return false;
            var choicesRoot = prefab.transform.Find("Content/ChoicesRoot");
            if (choicesRoot == null) return false;
            if (ApplyLayout(choicesRoot.gameObject))
            {
                fixedCount = 1;
                EditorUtility.SetDirty(prefab);
            }
            return fixedCount > 0;
        }

        private static bool ApplyLayout(GameObject choicesRootGo)
        {
            var rt = (RectTransform)choicesRootGo.transform;
            bool changed = false;

            // Re-anchor: full-width, anchored to bottom. ContentSizeFitter below
            // will drive the height based on the stacked button count.
            var newAnchorMin = new Vector2(0f, 0f);
            var newAnchorMax = new Vector2(1f, 0f);
            if (rt.anchorMin != newAnchorMin || rt.anchorMax != newAnchorMax)
            {
                rt.anchorMin = newAnchorMin;
                rt.anchorMax = newAnchorMax;
                rt.pivot = new Vector2(0.5f, 0f);
                rt.anchoredPosition = new Vector2(0f, 4f);
                rt.sizeDelta = new Vector2(0f, 0f);
                changed = true;
            }

            var vlg = choicesRootGo.GetComponent<VerticalLayoutGroup>();
            if (vlg == null)
            {
                vlg = choicesRootGo.AddComponent<VerticalLayoutGroup>();
                changed = true;
            }
            vlg.padding = new RectOffset(8, 8, 4, 4);
            vlg.spacing = 4f;
            vlg.childAlignment = TextAnchor.UpperCenter;
            vlg.childControlWidth = true;
            vlg.childControlHeight = true;
            vlg.childForceExpandWidth = true;
            vlg.childForceExpandHeight = false;
            vlg.childScaleWidth = false;
            vlg.childScaleHeight = false;
            vlg.reverseArrangement = false;

            var fitter = choicesRootGo.GetComponent<ContentSizeFitter>();
            if (fitter == null)
            {
                fitter = choicesRootGo.AddComponent<ContentSizeFitter>();
                changed = true;
            }
            fitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
            fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

            if (changed)
            {
                EditorUtility.SetDirty(choicesRootGo);
                Debug.Log($"[AddLayoutGroupToChoicesRoot] Configured layout on '{GetPath(choicesRootGo.transform)}'.");
            }
            return changed;
        }

        private static string GetPath(Transform t)
        {
            if (t.parent == null) return t.name;
            return GetPath(t.parent) + "/" + t.name;
        }
    }
}
