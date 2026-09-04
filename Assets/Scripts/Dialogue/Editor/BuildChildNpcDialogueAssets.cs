#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using AR_Grind_mill.Dialogue.Data;

namespace AR_Grind_mill.Dialogue.Editor
{
    /// <summary>
    /// One-shot editor builder for the child NPC ("Helper Boy") dialogue.
    /// Generates exactly 11 <see cref="DialogueNode"/> ScriptableObject assets
    /// under <c>Assets/Dialogue/Nodes/ChildNpc/</c> plus one
    /// <see cref="DialogueGraph"/> at <c>Assets/Dialogue/Graphs/ChildNpc.asset</c>
    /// that references all 11 nodes. Validates the graph via
    /// <see cref="DialogueGraph.Validate"/> and asserts zero errors.
    ///
    /// Layout:
    ///   • ChildNpc_Intro      — reactive conversation entry (player presses button)
    ///   • ChildNpc_Tip_01..10 — random single-line tips delivered periodically by
    ///                            <c>ChildNpcTipController</c>. Each is a
    ///                            terminal node (empty choices, autoAdvance=5s).
    ///
    /// All previous quest / cooking / farming-event dialogue nodes have been
    /// removed. The child no longer guides the player through tasks — it simply
    /// wanders around the village and offers the occasional neighbourly tip.
    ///
    /// Invoke from the editor menu (AR_Grind_mill > ChildNpc > Build Dialogue Assets)
    /// or headlessly from batchmode via:
    ///   unity run . -- -executeMethod AR_Grind_mill.Dialogue.Editor.BuildChildNpcDialogueAssets.BuildAll -quit -batchmode
    ///
    /// The builder is idempotent — running it a second time updates the existing
    /// assets in place rather than duplicating them. It also deletes obsolete
    /// quest-era assets from disk so the pool stays clean across regenerations.
    /// </summary>
    public static class BuildChildNpcDialogueAssets
    {
        // ─── Asset paths ────────────────────────────────────────────────
        private const string NodesDir       = "Assets/Dialogue/Nodes";
        private const string ChildNodesDir  = NodesDir + "/ChildNpc";
        private const string GraphsDir      = "Assets/Dialogue/Graphs";
        private const string GraphName      = "ChildNpc";
        private const string GraphAssetPath = GraphsDir + "/" + GraphName + ".asset";
        private const string SpeakerName    = "Helper Boy";

        // ─── Tip pool (single source of truth — also referenced by the
        //     tip controller's Inspector wiring via BuildChildNpcPrefab) ─────

        private const int TipCount = 10;
        private const string TipPrefix = "ChildNpc_Tip_";

        // All tips are short (~1 sentence), neighbourly, in-character for a village
        // child. They echo the rural-Vietnamese setting established by Mr Six
        // and Mrs Four (rice paddies, traditional mill, river, bánh chưng, Tết).
        private static readonly string[] TipTexts =
        {
            "The river is louder in the evening — that is just it stretching after a long day.",
            "If your tool slips into the paddy, wait until dusk. The water always gives back what it takes.",
            "Mrs Four's mint and holy basil keep the mosquitoes far. Just pinch, do not pull.",
            "The buffalo boys say the rain comes when the heron stands on one leg. Watch the bird, not the sky.",
            "Sun-dried rice keeps best when the morning is bright. Afternoon sun is too hot — it cracks the grain.",
            "Mr Six's mill wheel sings higher when the river is full. Listen before you turn the handle.",
            "Sluice gates creak before they stick. A drop of oil on the hinge saves an hour of work.",
            "Ask the elders — they know which plot gives the best harvest. The young ones only guess.",
            "If your seedling turns yellow, open the sluice. The water is older than any cure in the house.",
            "A clay jar of cool water beats any bottled drink on a hot afternoon. The earth remembers the cold.",
        };

        // ─── Obsolete asset names (deleted on every build so the folder
        //     stays in sync with the new design) ───────────────────────────

        private static readonly string[] ObsoleteNodeNames =
        {
            "ChildNpc_PlowedFirst",
            "ChildNpc_PlantedFirst",
            "ChildNpc_HarvestReady",
            "ChildNpc_DriedFirst",
            "ChildNpc_ThreshedFirst",
            "ChildNpc_Farewell",
            "ChildNpc_Cooking_1",
            "ChildNpc_Cooking_2",
            "ChildNpc_Cooking_3",
            "ChildNpc_Cooking_4",
            "ChildNpc_Cooking_5",
            "ChildNpc_Cooking_6",
            "ChildNpc_Cooking_7",
            "ChildNpc_Cooking_8",
            "ChildNpc_Cooking_9",
            "ChildNpc_Cooking_Completed",
        };

        // ─── Tally + report state (for the BuildAll summary) ─────────────
        private static int s_nodesCreated;
        private static int s_nodesUpdated;
        private static int s_nodesDeleted;
        private static int s_graphsCreated;
        private static int s_graphsUpdated;
        private static readonly List<string> s_validationErrors = new List<string>();

        // ─── Menu entry point ──────────────────────────────────────────
        [MenuItem("AR_Grind_mill/ChildNpc/Build Dialogue Assets")]
        public static void BuildMenu()
        {
            BuildResult result = BuildAll();
            string banner = result.ValidationErrors.Count == 0
                ? $"[ChildNpc] Build complete — 0 validation errors. Created={result.NodesCreated}, Updated={result.NodesUpdated}, Deleted={result.NodesDeleted}."
                : $"[ChildNpc] Build complete — {result.ValidationErrors.Count} validation error(s). See Console.";
            if (result.ValidationErrors.Count == 0)
            {
                Debug.Log(banner);
            }
            else
            {
                Debug.LogWarning(banner);
            }
        }

        // ─── Batch entry point ─────────────────────────────────────────
        public static BuildResult BuildAll()
        {
            s_nodesCreated = 0;
            s_nodesUpdated = 0;
            s_nodesDeleted = 0;
            s_graphsCreated = 0;
            s_graphsUpdated = 0;
            s_validationErrors.Clear();

            EnsureFolder(ChildNodesDir);
            EnsureFolder(GraphsDir);

            // 1. Delete obsolete assets first so the asset list is consistent
            //    BEFORE the graph rebuilds its nodes reference list.
            DeleteObsoleteNodes();

            // 2. Active intro line. Updated copy so existing asset picks up the
            //    new text (the old "I'll show you how a grain of rice becomes
            //    dinner" line promised quest guidance that no longer exists).
            DialogueNode intro = CreateChildNode("ChildNpc_Intro",
                "Hi! I'm the helper boy. If you see me around, come say hi — I always have a tip or two.",
                6f, isEnd: false);

            // 3. Ten single-line tip nodes. Each is a terminal node with empty
            //    choices and a 5-second auto-advance so the dialogue UI
            //    dismisses itself without any player input.
            DialogueNode[] tipNodes = new DialogueNode[TipCount];
            for (int i = 0; i < TipCount; i++)
            {
                string name = $"{TipPrefix}{i + 1:D2}";
                tipNodes[i] = CreateChildNode(name, TipTexts[i], 5f, isEnd: true);
            }

            // 4. Build the ordered node list: intro first (so the reactive
            //    conversation entry is at index 0 in the inspector), then the
            //    tip pool in order.
            List<DialogueNode> orderedNodes = new List<DialogueNode> { intro };
            orderedNodes.AddRange(tipNodes);

            // 5. Recreate the graph. isNodePool stays true so the validator
            //    accepts the tip nodes even though no choice from Intro reaches
            //    any of them (the TipController swaps entryNode at delivery
            //    time — same trick the previous ChildNpcQuestHook used).
            CreateChildGraph(GraphAssetPath, SpeakerName, intro, orderedNodes, isNodePool: true);

            // 6. Validate.
            DialogueGraph graph = AssetDatabase.LoadAssetAtPath<DialogueGraph>(GraphAssetPath);
            if (graph == null)
            {
                s_validationErrors.Add($"[ChildNpc] Graph asset missing at '{GraphAssetPath}' after build.");
            }
            else
            {
                List<string> errors;
                bool ok = graph.Validate(out errors);
                if (!ok)
                {
                    s_validationErrors.AddRange(errors);
                    Debug.LogWarning($"[ChildNpc] Graph validation failed with {errors.Count} error(s):");
                    for (int i = 0; i < errors.Count; i++)
                    {
                        Debug.LogWarning($"  - {errors[i]}");
                    }
                }
                else
                {
                    Debug.Log($"[ChildNpc] Graph validated — 0 errors across {orderedNodes.Count} nodes.");
                }
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log($"[ChildNpc] Summary: created={s_nodesCreated}, updated={s_nodesUpdated}, " +
                      $"deleted={s_nodesDeleted}; graphs created={s_graphsCreated}, updated={s_graphsUpdated}; " +
                      $"validationErrors={s_validationErrors.Count}.");

            return new BuildResult(
                s_nodesCreated,
                s_nodesUpdated,
                s_nodesDeleted,
                s_graphsCreated,
                s_graphsUpdated,
                new List<string>(s_validationErrors));
        }

        // ─── Obsolete-asset cleanup ─────────────────────────────────────

        private static void DeleteObsoleteNodes()
        {
            for (int i = 0; i < ObsoleteNodeNames.Length; i++)
            {
                string path = $"{ChildNodesDir}/{ObsoleteNodeNames[i]}.asset";
                if (!File.Exists(path))
                {
                    continue;
                }

                if (AssetDatabase.DeleteAsset(path))
                {
                    s_nodesDeleted++;
                    Debug.Log($"[ChildNpc] Deleted obsolete node: {path}");
                }
                else
                {
                    Debug.LogWarning($"[ChildNpc] Failed to delete obsolete node: {path}");
                }
            }
        }

        // ─── Helpers (mirror WireDialogueSystem.cs pattern) ──────────────

        /// <summary>
        /// Creates (or updates) a <see cref="DialogueNode"/> asset at
        /// <c>Assets/Dialogue/Nodes/ChildNpc/{name}.asset</c> with the given
        /// speaker / text / auto-advance / isEnd flags. Empty choices list =
        /// auto-end after the line fires.
        /// </summary>
        private static DialogueNode CreateChildNode(
            string name, string text, float autoAdvanceAfter, bool isEnd)
        {
            string path = $"{ChildNodesDir}/{name}.asset";
            DialogueNode node = AssetDatabase.LoadAssetAtPath<DialogueNode>(path);
            if (node == null)
            {
                node = ScriptableObject.CreateInstance<DialogueNode>();
                AssetDatabase.CreateAsset(node, path);
                s_nodesCreated++;
                Debug.Log($"[ChildNpc] Created node: {path}");
            }
            else
            {
                s_nodesUpdated++;
                Debug.Log($"[ChildNpc] Node already exists — updating fields: {path}");
            }

            node.line = new DialogueLine
            {
                speakerName      = SpeakerName,
                text             = text,
                animationTag     = string.Empty,
                voiceClip        = null,
                autoAdvanceAfter = autoAdvanceAfter,
            };
            node.choices   = new List<DialogueChoice>();
            node.isEndNode = isEnd;
            EditorUtility.SetDirty(node);
            return node;
        }

        /// <summary>
        /// Creates (or updates) the <see cref="DialogueGraph"/> asset that links
        /// all 11 child-NPC nodes together.
        /// </summary>
        private static void CreateChildGraph(
            string path, string characterName, DialogueNode entry, List<DialogueNode> nodes, bool isNodePool = false)
        {
            DialogueGraph graph = AssetDatabase.LoadAssetAtPath<DialogueGraph>(path);
            if (graph == null)
            {
                graph = ScriptableObject.CreateInstance<DialogueGraph>();
                AssetDatabase.CreateAsset(graph, path);
                s_graphsCreated++;
                Debug.Log($"[ChildNpc] Created graph: {path}");
            }
            else
            {
                s_graphsUpdated++;
                Debug.Log($"[ChildNpc] Graph already exists — updating fields: {path}");
            }

            graph.characterName = characterName;
            graph.entryNode     = entry;
            graph.nodes         = new List<DialogueNode>(nodes);
            graph.isNodePool    = isNodePool;
            EditorUtility.SetDirty(graph);
        }

        /// <summary>
        /// Ensures the asset path exists (creates intermediate folders).
        /// Mirrors the convention used elsewhere in the editor scripts.
        /// </summary>
        private static void EnsureFolder(string assetFolderPath)
        {
            if (AssetDatabase.IsValidFolder(assetFolderPath))
            {
                return;
            }

            string normalized = assetFolderPath.Replace('\\', '/');
            string[] parts = normalized.Split('/');
            // parts[0] is "Assets" and must already exist for any Editor menu.
            string current = parts[0];
            for (int i = 1; i < parts.Length; i++)
            {
                string next = current + "/" + parts[i];
                if (!AssetDatabase.IsValidFolder(next))
                {
                    AssetDatabase.CreateFolder(current, parts[i]);
                    Debug.Log($"[ChildNpc] Created folder: {next}");
                }
                current = next;
            }
        }

        // ─── Result record (used by tests / external callers) ──────────
        public readonly struct BuildResult
        {
            public readonly int NodesCreated;
            public readonly int NodesUpdated;
            public readonly int NodesDeleted;
            public readonly int GraphsCreated;
            public readonly int GraphsUpdated;
            public readonly List<string> ValidationErrors;

            public BuildResult(int nodesCreated, int nodesUpdated, int nodesDeleted,
                int graphsCreated, int graphsUpdated, List<string> errors)
            {
                NodesCreated     = nodesCreated;
                NodesUpdated     = nodesUpdated;
                NodesDeleted     = nodesDeleted;
                GraphsCreated    = graphsCreated;
                GraphsUpdated    = graphsUpdated;
                ValidationErrors = errors;
            }
        }
    }
}
#endif
