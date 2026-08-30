// DedupeContentSizeFitter: removes duplicate ContentSizeFitter components from
// any GameObject (ChoicesRoot got two from a prior pass).

using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace AR_Grind_mill.Dialogue.EditorTools
{
    public static class DedupeContentSizeFitter
    {
        [MenuItem("AR_Grind_mill/Dialogue/DEDUPE_CONTENT_SIZE_FITTER")]
        private static void Run()
        {
            int removed = 0;
            var allFitters = Object.FindObjectsByType<ContentSizeFitter>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            foreach (var fitter in allFitters)
            {
                var go = fitter.gameObject;
                var fitters = go.GetComponents<ContentSizeFitter>();
                if (fitters.Length > 1)
                {
                    for (int i = 1; i < fitters.Length; i++)
                    {
                        Object.DestroyImmediate(fitters[i]);
                        removed++;
                        Debug.Log($"[DedupeContentSizeFitter] Removed duplicate ContentSizeFitter from '{go.transform.name}'.");
                    }
                }
            }
            Debug.Log($"[DedupeContentSizeFitter] Done. Removed {removed} duplicate(s).");
        }
    }
}
