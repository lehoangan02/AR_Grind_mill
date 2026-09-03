#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using AR_Grind_mill.Dialogue.Data;

namespace AR_Grind_mill.Dialogue.Editor
{
    /// <summary>
    /// One-shot editor utility: force-reimports every <see cref="DialogueGraph"/>
    /// asset under <c>Assets/</c> so Unity re-reads the YAML from disk and
    /// re-syncs the in-memory ScriptableObject. Fixes the case where an
    /// externally-edited YAML field is correct on disk but the loaded asset
    /// still holds the old default.
    ///
    /// Invoke from the editor menu:
    ///   AR_Grind_mill &gt; Dialogue &gt; Reimport Dialogue Graphs
    /// Or headlessly:
    ///   unity run . -- -executeMethod
    ///     AR_Grind_mill.Dialogue.Editor.ReimportDialogueGraphs.ReimportAll -quit -batchmode
    ///
    /// Idempotent — no data is mutated. Running it twice has the same effect as
    /// running it once. Safe to invoke any time; use after editing .asset YAML
    /// by hand or after pulling a change that touched DialogueGraph fields.
    /// </summary>
    public static class ReimportDialogueGraphs
    {
        private const string SearchFolder = "Assets";
        private const string MenuPath     = "AR_Grind_mill/Dialogue/Reimport Dialogue Graphs";

        [MenuItem(MenuPath)]
        public static void ReimportMenu()
        {
            ReimportResult result = ReimportAll();
            Debug.Log($"[ReimportDialogueGraphs] Force-reimported {result.Count} DialogueGraph asset(s).");
        }

        public static ReimportResult ReimportAll()
        {
            string[] guids = AssetDatabase.FindAssets("t:" + nameof(DialogueGraph), new[] { SearchFolder });
            var paths = new List<string>(guids.Length);

            for (int i = 0; i < guids.Length; i++)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                if (string.IsNullOrEmpty(path)) continue;
                paths.Add(path);
                AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            return new ReimportResult(paths.Count);
        }

        public readonly struct ReimportResult
        {
            public readonly int Count;
            public ReimportResult(int count) { Count = count; }
        }
    }
}
#endif
