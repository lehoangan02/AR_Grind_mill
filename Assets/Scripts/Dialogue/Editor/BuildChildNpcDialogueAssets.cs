#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using AR_Grind_mill.Dialogue.Data;

namespace AR_Grind_mill.Dialogue.Editor
{
    /// <summary>
    /// One-shot editor builder for the child NPC ("Helper Boy") dialogue.
    /// Generates exactly 17 <see cref="DialogueNode"/> ScriptableObject assets
    /// under <c>Assets/Dialogue/Nodes/ChildNpc/</c> plus one
    /// <see cref="DialogueGraph"/> at <c>Assets/Dialogue/Graphs/ChildNpc.asset</c>
    /// that references all 17 nodes. Validates the graph via
    /// <see cref="DialogueGraph.Validate"/> and asserts zero errors.
    ///
    /// Invoke from the editor menu (AR_Grind_mill > ChildNpc > Build Dialogue Assets)
    /// or headlessly from batchmode via:
    ///   unity run . -- -executeMethod AR_Grind_mill.Dialogue.Editor.BuildChildNpcDialogueAssets.BuildAll -quit -batchmode
    ///
    /// The builder is idempotent — running it a second time updates the existing
    /// assets in place rather than duplicating them.
    /// </summary>
    public static class BuildChildNpcDialogueAssets
    {
        // ─── Asset paths ────────────────────────────────────────────────
        private const string NodesDir       = "Assets/Dialogue/Nodes";
        private const string ChildNodesDir  = NodesDir + "/ChildNpc";
        private const string GraphsDir      = "Assets/Dialogue/Graphs";
        private const string GraphName      = "ChildNpc";
        private const string GraphAssetPath = GraphsDir + "/" + GraphName + ".asset";
        private const string SpeakerName     = "Helper Boy";

        // ─── Tally + report state (for the BuildAll summary) ─────────────
        private static int s_nodesCreated;
        private static int s_nodesUpdated;
        private static int s_graphsCreated;
        private static int s_graphsUpdated;
        private static readonly List<string> s_validationErrors = new List<string>();

        // ─── Menu entry point ──────────────────────────────────────────
        [MenuItem("AR_Grind_mill/ChildNpc/Build Dialogue Assets")]
        public static void BuildMenu()
        {
            BuildResult result = BuildAll();
            string banner = result.ValidationErrors.Count == 0
                ? "[ChildNpc] Build complete — 0 validation errors."
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
            s_graphsCreated = 0;
            s_graphsUpdated = 0;
            s_validationErrors.Clear();

            EnsureFolder(ChildNodesDir);
            EnsureFolder(GraphsDir);

            // --- Step text source (matches CookingQuestGuide.UpdateGuideUI) ---
            string step1 = "Pour the paddy into the mill hopper";
            string step2 = "Grip the handle and turn the mill round and round";
            string step3 = "Pick up the white rice and pour it into the washing basin";
            string step4 = "Dip the ladle into the water jar and pour into the basin";
            string step5 = "Stir with the washing stick, then tilt the basin to drain";
            string step6 = "Take the washed rice with the serving ladle";
            string step7 = "Stack firewood and strike the match quickly on the striker";
            string step8 = "Add rice and water to the pot, cover, place on the stove";
            string step9 = "Lift the lid and scoop the cooked rice into a bowl";

            // --- 17 nodes (exact names + texts from the child-npc-guide plan) ---
            DialogueNode intro   = CreateChildNode("ChildNpc_Intro",
                "Hi! I'm the helper boy. I'll show you how a grain of rice becomes dinner.", 6f, false);

            DialogueNode plowed  = CreateChildNode("ChildNpc_PlowedFirst",
                "Great, the soil's ready! Now plant some seedlings — press the seed tool into the tilled plot.", 5f, false);

            DialogueNode planted = CreateChildNode("ChildNpc_PlantedFirst",
                "Nice planting! Your rice is in. Give it water when it's thirsty — use the water tool or open the sluice.", 5f, false);

            DialogueNode harvested = CreateChildNode("ChildNpc_HarvestReady",
                "It's ripe! Use the sickle to harvest it, then take the bundles to the drying yard.", 5f, false);

            DialogueNode dried  = CreateChildNode("ChildNpc_DriedFirst",
                "Bundles are dry — bring them to the thresher. Make sure a basket is nearby.", 5f, false);

            DialogueNode threshed = CreateChildNode("ChildNpc_ThreshedFirst",
                "The thresher separated the grain. Now bring it to the grind mill — but first, let's get the cooking area ready.", 5f, false);

            DialogueNode cooking1 = CreateChildNode("ChildNpc_Cooking_1", step1, 5f, false);
            DialogueNode cooking2 = CreateChildNode("ChildNpc_Cooking_2", step2, 5f, false);
            DialogueNode cooking3 = CreateChildNode("ChildNpc_Cooking_3", step3, 5f, false);
            DialogueNode cooking4 = CreateChildNode("ChildNpc_Cooking_4", step4, 5f, false);
            DialogueNode cooking5 = CreateChildNode("ChildNpc_Cooking_5", step5, 5f, false);
            DialogueNode cooking6 = CreateChildNode("ChildNpc_Cooking_6", step6, 5f, false);
            DialogueNode cooking7 = CreateChildNode("ChildNpc_Cooking_7", step7, 5f, false);
            DialogueNode cooking8 = CreateChildNode("ChildNpc_Cooking_8", step8, 5f, false);
            DialogueNode cooking9 = CreateChildNode("ChildNpc_Cooking_9", step9, 5f, false);

            DialogueNode completed = CreateChildNode("ChildNpc_Cooking_Completed",
                "And that's a bowl of rice! You grew it, milled it, washed it, and cooked it. Eat up — you earned it.",
                6f, true);

            DialogueNode farewell = CreateChildNode("ChildNpc_Farewell",
                "See you soon!",
                0f, true);

            // --- Build the graph (entry = intro, nodes in plan order) ---
            List<DialogueNode> orderedNodes = new List<DialogueNode>
            {
                intro,
                plowed,
                planted,
                harvested,
                dried,
                threshed,
                cooking1, cooking2, cooking3, cooking4, cooking5,
                cooking6, cooking7, cooking8, cooking9,
                completed,
                farewell,
            };

            CreateChildGraph(GraphAssetPath, SpeakerName, intro, orderedNodes, isNodePool: true);

            // --- Validate ---
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

            // --- Summary (for batch logs) ---
            Debug.Log($"[ChildNpc] Summary: nodes created={s_nodesCreated}, updated={s_nodesUpdated}; " +
                      $"graphs created={s_graphsCreated}, updated={s_graphsUpdated}; " +
                      $"validationErrors={s_validationErrors.Count}.");

            return new BuildResult(
                s_nodesCreated,
                s_nodesUpdated,
                s_graphsCreated,
                s_graphsUpdated,
                new List<string>(s_validationErrors));
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
        /// all 17 child-NPC nodes together.
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
            public readonly int GraphsCreated;
            public readonly int GraphsUpdated;
            public readonly List<string> ValidationErrors;

            public BuildResult(int nodesCreated, int nodesUpdated, int graphsCreated, int graphsUpdated, List<string> errors)
            {
                NodesCreated = nodesCreated;
                NodesUpdated = nodesUpdated;
                GraphsCreated = graphsCreated;
                GraphsUpdated = graphsUpdated;
                ValidationErrors = errors;
            }
        }
    }
}
#endif