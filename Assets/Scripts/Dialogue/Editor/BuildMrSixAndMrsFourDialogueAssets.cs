#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using AR_Grind_mill.Dialogue.Data;

namespace AR_Grind_mill.Dialogue.Editor
{
    /// <summary>
    /// One-shot editor builder for the neighbor NPCs ("Mr. Six" and "Mrs. Four").
    ///
    /// Each NPC has a 9-node dialogue tree with depth 3 (Greeting → Topic →
    /// SubTopic → Farewell) and 1-3 choices at every node. A few sub-topics are
    /// shared across multiple parent paths so the same neighborly cross-reference
    /// can surface from different conversation angles.
    ///
    /// Generated assets:
    ///   Assets/Dialogue/Nodes/MrSix_*.asset     (9 nodes)
    ///   Assets/Dialogue/Nodes/MrsFour_*.asset   (9 nodes)
    ///   Assets/Dialogue/Graphs/MrSix.asset      (9 nodes, entry = Greeting)
    ///   Assets/Dialogue/Graphs/MrsFour.asset    (9 nodes, entry = Greeting)
    ///
    /// Invoke from the editor menu
    ///   AR_Grind_mill > MrSix+MrsFour > Build Dialogue Assets
    /// or headlessly via:
    ///   unity run . -- -executeMethod AR_Grind_mill.Dialogue.Editor.BuildMrSixAndMrsFourDialogueAssets.BuildAll -quit -batchmode
    ///
    /// The builder is idempotent — running it again updates the existing assets
    /// in place rather than duplicating them.
    /// </summary>
    public static class BuildMrSixAndMrsFourDialogueAssets
    {
        // ─── Asset paths ────────────────────────────────────────────────
        private const string NodesDir         = "Assets/Dialogue/Nodes";
        private const string MrSixGraphPath   = "Assets/Dialogue/Graphs/MrSix.asset";
        private const string MrsFourGraphPath = "Assets/Dialogue/Graphs/MrsFour.asset";

        private const string MrSixSpeaker   = "Mr. Six";
        private const string MrsFourSpeaker = "Mrs. Four";

        // ─── Tally + report state ───────────────────────────────────────
        private static int s_nodesCreated;
        private static int s_nodesUpdated;
        private static int s_graphsCreated;
        private static int s_graphsUpdated;
        private static readonly List<string> s_validationErrors = new List<string>();

        // ─── Menu entry point ──────────────────────────────────────────
        [MenuItem("AR_Grind_mill/MrSix+MrsFour/Build Dialogue Assets")]
        public static void BuildMenu()
        {
            BuildResult result = BuildAll();
            string banner = result.ValidationErrors.Count == 0
                ? "[MrSix+MrsFour] Build complete — 0 validation errors."
                : $"[MrSix+MrsFour] Build complete — {result.ValidationErrors.Count} validation error(s). See Console.";
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

            EnsureFolder(NodesDir);

            BuildMrSix();
            BuildMrsFour();

            ValidateGraph(MrSixGraphPath,   9);
            ValidateGraph(MrsFourGraphPath, 9);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log($"[MrSix+MrsFour] Summary: nodes created={s_nodesCreated}, updated={s_nodesUpdated}; " +
                      $"graphs created={s_graphsCreated}, updated={s_graphsUpdated}; " +
                      $"validationErrors={s_validationErrors.Count}.");

            return new BuildResult(
                s_nodesCreated,
                s_nodesUpdated,
                s_graphsCreated,
                s_graphsUpdated,
                new List<string>(s_validationErrors));
        }

        // ═══════════════════════════════════════════════════════════════
        // MR. SIX — old mill keeper, three generations on the same stone.
        //
        // Depth-3 tree, 9 nodes:
        //   Greeting
        //     ├── AboutTheMill (Greeting→Mill→Rice→Farewell)
        //     │   ├── AboutTheRice
        //     │   └── Farewell
        //     ├── AboutHarvestSeason (Greeting→Harvest→{Tips|MrsFour}→Farewell)
        //     │   ├── FarmingTips
        //     │   ├── AboutMrsFour ← shared with Family branch
        //     │   └── Farewell
        //     └── AboutHisFamily (Greeting→Family→{Village|MrsFour}→Farewell)
        //         ├── AboutTheVillage
        //         ├── AboutMrsFour ← shared with Harvest branch
        //         └── Farewell
        // ═══════════════════════════════════════════════════════════════

        private static void BuildMrSix()
        {
            // ─── Nodes ──────────────────────────────────────────────────
            DialogueNode greeting = CreateNode("MrSix_Greeting",
                "Hello there, traveler. Welcome to my little mill. What would you like to know?");

            DialogueNode aboutTheMill = CreateNode("MrSix_AboutTheMill",
                "This old stone mill has been turning grain for three generations. " +
                "My grandfather laid these stones before the French came, and the river " +
                "still turns the wheel as faithfully as it did on his first morning.");

            DialogueNode aboutTheRice = CreateNode("MrSix_AboutTheRice",
                "I mill the sticky ones for Tết flour and the long-grain for everyday " +
                "rice. Each one sings a different tune against the stones.");

            DialogueNode aboutHarvestSeason = CreateNode("MrSix_AboutHarvestSeason",
                "When the paddies turn gold, the whole village works from dawn to dusk. " +
                "Even the children carry bundles. The mill runs day and night, and I sleep " +
                "by the wheel — best music I know.");

            DialogueNode farmingTips = CreateNode("MrSix_FarmingTips",
                "If your seedlings yellow, it is the water. Open the sluice, let the field " +
                "drink its fill, then close it before dusk. A patient farmer reads the " +
                "paddy like a book.");

            DialogueNode aboutMrsFour = CreateNode("MrSix_AboutMrsFour",
                "Mrs. Four next door? Her bánh chưng at Tết could make a stone shed a tear. " +
                "Don't tell her I said so — she would never let me hear the end of it.");

            DialogueNode aboutHisFamily = CreateNode("MrSix_AboutHisFamily",
                "My boy works the river boats now. Comes home only at Tết. The mill is too " +
                "quiet without him — but the wheel still turns, so I turn with it.");

            DialogueNode aboutTheVillage = CreateNode("MrSix_AboutTheVillage",
                "Three generations on the same stone — the village has grown around us, " +
                "but the mill has not moved an inch. Some things are meant to stay where " +
                "they were first set down.");

            DialogueNode farewell = CreateNode("MrSix_Farewell",
                "Safe travels — and if you bring me paddy, I will turn it to flour for you.",
                isEnd: true);

            // ─── Choices (1-3 per node, max depth 3) ────────────────────

            greeting.choices = new List<DialogueChoice>
            {
                Choice("Tell me about the mill",       aboutTheMill),
                Choice("How is the harvest?",          aboutHarvestSeason),
                Choice("Tell me about your family",    aboutHisFamily),
            };
            EditorUtility.SetDirty(greeting);

            aboutTheMill.choices = new List<DialogueChoice>
            {
                Choice("What rice do you mill?", aboutTheRice),
                Choice("Farewell",               farewell),
            };
            EditorUtility.SetDirty(aboutTheMill);

            aboutTheRice.choices = SingleChoice("Farewell", farewell);
            EditorUtility.SetDirty(aboutTheRice);

            aboutHarvestSeason.choices = new List<DialogueChoice>
            {
                Choice("Any tips for my plot?",  farmingTips),
                Choice("Tell me about Mrs Four", aboutMrsFour),
                Choice("Farewell",               farewell),
            };
            EditorUtility.SetDirty(aboutHarvestSeason);

            farmingTips.choices = SingleChoice("Farewell", farewell);
            EditorUtility.SetDirty(farmingTips);

            aboutHisFamily.choices = new List<DialogueChoice>
            {
                Choice("How long has your family been here?", aboutTheVillage),
                Choice("Tell me about Mrs Four",              aboutMrsFour),
                Choice("Farewell",                            farewell),
            };
            EditorUtility.SetDirty(aboutHisFamily);

            aboutTheVillage.choices = SingleChoice("Farewell", farewell);
            EditorUtility.SetDirty(aboutTheVillage);

            aboutMrsFour.choices = SingleChoice("Farewell", farewell);
            EditorUtility.SetDirty(aboutMrsFour);

            // ─── Graph ──────────────────────────────────────────────────
            List<DialogueNode> allNodes = new List<DialogueNode>
            {
                greeting,
                aboutTheMill,
                aboutTheRice,
                aboutHarvestSeason,
                farmingTips,
                aboutMrsFour,
                aboutHisFamily,
                aboutTheVillage,
                farewell,
            };
            CreateGraph(MrSixGraphPath, MrSixSpeaker, greeting, allNodes);
        }

        // ═══════════════════════════════════════════════════════════════
        // MRS. FOUR — the warm, welcoming neighbor.
        //
        // Depth-3 tree, 9 nodes:
        //   Greeting
        //     ├── AboutTheWeather (Greeting→Weather→{Garden|Gossip}→Farewell)
        //     │   ├── AboutTheGarden
        //     │   ├── VillageGossip ← shared with Cooking branch
        //     │   └── Take care
        //     ├── AboutCooking (Greeting→Cooking→{Family|Gossip}→Farewell)
        //     │   ├── AboutHerFamily
        //     │   ├── VillageGossip ← shared with Weather branch
        //     │   └── Take care
        //     └── AboutTheChildren (Greeting→Children→MrSix→Farewell)
        //         ├── AboutMrSix
        //         └── Take care
        // ═══════════════════════════════════════════════════════════════

        private static void BuildMrsFour()
        {
            // ─── Nodes ──────────────────────────────────────────────────
            DialogueNode greeting = CreateNode("MrsFour_Greeting",
                "Oh, a visitor! How lovely. Come in, come in — the kettle is always warm.");

            DialogueNode aboutTheWeather = CreateNode("MrsFour_AboutTheWeather",
                "Clear skies over the paddies today. Good for drying the rice — though the " +
                "old knee says rain is coming by the week's end. The knee is never wrong.");

            DialogueNode aboutTheGarden = CreateNode("MrsFour_AboutTheGarden",
                "The herbs in my garden chase away the mosquitoes and lift the spirit. " +
                "Mint, lemongrass, holy basil — they are free for any neighbor who asks. " +
                "Just pinch, do not pull.");

            DialogueNode villageGossip = CreateNode("MrsFour_VillageGossip",
                "Did you hear? Someone saw a kingfisher by the sluice this morning. The " +
                "fish will be running well this week — and the buffalo boys will be " +
                "smiling by sundown.");

            DialogueNode aboutCooking = CreateNode("MrsFour_AboutCooking",
                "Slow fire, a pinch of salt, and patience — that is the whole secret to a " +
                "good pot of rice. My mother said: rush a meal and you will be hungry " +
                "again by sundown.");

            DialogueNode aboutHerFamily = CreateNode("MrsFour_AboutHerFamily",
                "My husband rests under the banyan by the river now. But his garden still " +
                "grows. He would have liked you — he always liked the ones with dirt under " +
                "their nails.");

            DialogueNode aboutTheChildren = CreateNode("MrsFour_AboutTheChildren",
                "The helper boy next door knows every corner of this village. If you are " +
                "lost, follow him — and if he tells you to plant the seed, plant it. He " +
                "knows his rice.");

            DialogueNode aboutMrSix = CreateNode("MrsFour_AboutMrSix",
                "Mr. Six and his mill — that stone has been grinding since my mother was a " +
                "girl. He will chat your ear off if you let him, but his flour is the best " +
                "in the village.");

            DialogueNode farewell = CreateNode("MrsFour_Farewell",
                "Come back anytime, neighbor. The door is never closed here.",
                isEnd: true);

            // ─── Choices (1-3 per node, max depth 3) ────────────────────

            greeting.choices = new List<DialogueChoice>
            {
                Choice("How is the weather today?",  aboutTheWeather),
                Choice("Tell me about your cooking", aboutCooking),
                Choice("Tell me about the children", aboutTheChildren),
            };
            EditorUtility.SetDirty(greeting);

            aboutTheWeather.choices = new List<DialogueChoice>
            {
                Choice("What is growing in your garden?", aboutTheGarden),
                Choice("What is happening around here?",  villageGossip),
                Choice("Take care",                       farewell),
            };
            EditorUtility.SetDirty(aboutTheWeather);

            aboutTheGarden.choices = SingleChoice("Take care", farewell);
            EditorUtility.SetDirty(aboutTheGarden);

            aboutCooking.choices = new List<DialogueChoice>
            {
                Choice("Tell me about your family",      aboutHerFamily),
                Choice("What is happening around here?", villageGossip),
                Choice("Take care",                      farewell),
            };
            EditorUtility.SetDirty(aboutCooking);

            aboutHerFamily.choices = SingleChoice("Take care", farewell);
            EditorUtility.SetDirty(aboutHerFamily);

            villageGossip.choices = SingleChoice("Take care", farewell);
            EditorUtility.SetDirty(villageGossip);

            aboutTheChildren.choices = new List<DialogueChoice>
            {
                Choice("And Mr Six?",  aboutMrSix),
                Choice("Take care",    farewell),
            };
            EditorUtility.SetDirty(aboutTheChildren);

            aboutMrSix.choices = SingleChoice("Take care", farewell);
            EditorUtility.SetDirty(aboutMrSix);

            // ─── Graph ──────────────────────────────────────────────────
            List<DialogueNode> allNodes = new List<DialogueNode>
            {
                greeting,
                aboutTheWeather,
                aboutTheGarden,
                villageGossip,
                aboutCooking,
                aboutHerFamily,
                aboutTheChildren,
                aboutMrSix,
                farewell,
            };
            CreateGraph(MrsFourGraphPath, MrsFourSpeaker, greeting, allNodes);
        }

        // ─── Helpers ────────────────────────────────────────────────────

        private static DialogueNode CreateNode(string name, string text)
        {
            return CreateNode(name, text, isEnd: false);
        }

        private static DialogueNode CreateNode(string name, string text, bool isEnd)
        {
            string speaker = ResolveSpeaker(name);
            string path = $"{NodesDir}/{name}.asset";

            DialogueNode node = AssetDatabase.LoadAssetAtPath<DialogueNode>(path);
            if (node == null)
            {
                node = ScriptableObject.CreateInstance<DialogueNode>();
                AssetDatabase.CreateAsset(node, path);
                s_nodesCreated++;
                Debug.Log($"[MrSix+MrsFour] Created node: {path}");
            }
            else
            {
                s_nodesUpdated++;
                Debug.Log($"[MrSix+MrsFour] Node already exists — updating fields: {path}");
            }

            node.line = new DialogueLine
            {
                speakerName      = speaker,
                text             = text,
                animationTag     = string.Empty,
                voiceClip        = null,
                autoAdvanceAfter = 0f,
            };
            if (node.choices == null)
            {
                node.choices = new List<DialogueChoice>();
            }
            node.isEndNode = isEnd;
            EditorUtility.SetDirty(node);
            return node;
        }

        private static string ResolveSpeaker(string nodeName)
        {
            if (nodeName.StartsWith("MrSix_"))   return MrSixSpeaker;
            if (nodeName.StartsWith("MrsFour_")) return MrsFourSpeaker;
            return nodeName;
        }

        private static DialogueChoice Choice(string text, DialogueNode next)
        {
            return new DialogueChoice { choiceText = text, nextNode = next, animationTag = string.Empty };
        }

        private static List<DialogueChoice> SingleChoice(string text, DialogueNode next)
        {
            return new List<DialogueChoice> { Choice(text, next) };
        }

        private static void CreateGraph(
            string path, string characterName, DialogueNode entryNode, List<DialogueNode> nodes)
        {
            DialogueGraph graph = AssetDatabase.LoadAssetAtPath<DialogueGraph>(path);
            if (graph == null)
            {
                graph = ScriptableObject.CreateInstance<DialogueGraph>();
                AssetDatabase.CreateAsset(graph, path);
                s_graphsCreated++;
                Debug.Log($"[MrSix+MrsFour] Created graph: {path}");
            }
            else
            {
                s_graphsUpdated++;
                Debug.Log($"[MrSix+MrsFour] Graph already exists — updating fields: {path}");
            }

            graph.characterName = characterName;
            graph.entryNode     = entryNode;
            graph.nodes         = new List<DialogueNode>(nodes);
            graph.isNodePool    = false;
            EditorUtility.SetDirty(graph);
        }

        private static void ValidateGraph(string graphPath, int expectedNodeCount)
        {
            DialogueGraph graph = AssetDatabase.LoadAssetAtPath<DialogueGraph>(graphPath);
            if (graph == null)
            {
                s_validationErrors.Add($"[MrSix+MrsFour] Graph asset missing at '{graphPath}' after build.");
                return;
            }

            List<string> errors;
            bool ok = graph.Validate(out errors);
            if (!ok)
            {
                s_validationErrors.AddRange(errors);
                Debug.LogWarning($"[MrSix+MrsFour] Graph validation failed for '{graphPath}' with {errors.Count} error(s):");
                for (int i = 0; i < errors.Count; i++)
                {
                    Debug.LogWarning($"  - {errors[i]}");
                }
            }
            else
            {
                Debug.Log($"[MrSix+MrsFour] Graph '{graphPath}' validated — 0 errors across {expectedNodeCount} nodes.");
            }
        }

        private static void EnsureFolder(string assetFolderPath)
        {
            if (AssetDatabase.IsValidFolder(assetFolderPath))
            {
                return;
            }

            string normalized = assetFolderPath.Replace('\\', '/');
            string[] parts = normalized.Split('/');
            string current = parts[0];
            for (int i = 1; i < parts.Length; i++)
            {
                string next = current + "/" + parts[i];
                if (!AssetDatabase.IsValidFolder(next))
                {
                    AssetDatabase.CreateFolder(current, parts[i]);
                    Debug.Log($"[MrSix+MrsFour] Created folder: {next}");
                }
                current = next;
            }
        }

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
