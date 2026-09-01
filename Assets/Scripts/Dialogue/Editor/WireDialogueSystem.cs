#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEditor.Animations;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.UI;
using AR_Grind_mill.Dialogue.Data;
using AR_Grind_mill.Dialogue.Runtime;
using AR_Grind_mill.Dialogue.UI;

namespace AR_Grind_mill.Dialogue.EditorTools
{
    /// <summary>
    /// One-shot editor builder that wires the entire NPC Dialogue System:
    ///   - Primitive NPC prefabs (Body/Head + proximity trigger
    ///     + head look + controller + dialogue UI)
    ///   - World-space UI prefabs (DialogueCanvas, ChoiceButton)
    ///   - DialogueNode + DialogueGraph ScriptableObject assets
    ///   - Re-opens each NPC prefab to wire graph + UI prefabs + canvas anchor
    ///   - Drops MrSix/MrsFour instances into "VR UI.unity"
    ///
    /// Invoke from the Editor menu (AR_Grind_mill > Dialogue > Wire System) or
    /// headlessly from batchmode via:
    ///   -executeMethod AR_Grind_mill.Dialogue.EditorTools.WireDialogueSystem.Wire
    /// </summary>
    public static class WireDialogueSystem
    {
        // ─── Asset paths ────────────────────────────────────────────────
        private const string NpcPrefabDir   = "Assets/Prefabs/NPCs";
        private const string UiPrefabDir    = "Assets/Prefabs/UI/Dialogue";
        private const string DialogueDir    = "Assets/Dialogue";
        private const string NodesDir       = "Assets/Dialogue/Nodes";
        private const string GraphsDir      = "Assets/Dialogue/Graphs";
        private const string InputActionAssetPath = "Assets/InputSystem_Actions.inputactions";
        private const string AttackActionRefPath = "Assets/Dialogue/PlayerAttackActionRef.asset";
        private const string ScenePath      = "Assets/Scenes/VR UI.unity";

        // NPC identifiers
        private const string MrSixName   = "MrSix";
        private const string MrsFourName = "MrsFour";

        // UI prefab names
        private const string UiCanvasName        = "DialogueCanvas.prefab";
        private const string UiChoiceButtonName  = "DialogueChoiceButton.prefab";

        // NPC scene positions (scene-space, root transform)
        private static readonly Vector3 MrSixScenePos   = new Vector3( 2f, 0f, 3f);
        private static readonly Vector3 MrsFourScenePos = new Vector3(-2f, 0f, 3f);

        // ─── Tally counters (for summary) ──────────────────────────────
        private static int s_npcPrefabsCreated;
        private static int s_uiPrefabsCreated;
        private static int s_nodesCreated;
        private static int s_graphsCreated;
        private static int s_prefabsRewired;
        private static int s_scenePlacements;
        private static int s_inputActionRefSaved;
        private static readonly List<string> s_warnings = new List<string>();
        private static readonly List<string> s_errors = new List<string>();

        private static InputActionReference s_attackActionRef;
        private static DialogueChoiceButton s_choiceButtonComponent;

        // ─── Entry points ───────────────────────────────────────────────
        [MenuItem("AR_Grind_mill/Dialogue/Wire System")]
        public static void WireMenu()
        {
            try
            {
                Build();
            }
            catch (Exception ex)
            {
                Debug.LogError($"[WireDialogueSystem] FATAL: {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}");
                EditorUtility.DisplayDialog(
                    "Wire Dialog System",
                    $"Wire-up failed:\n{ex.GetType().Name}: {ex.Message}\n\nSee Console for the stack trace.",
                    "OK");
            }
        }

        /// <summary>Headless batchmode entry point.</summary>
        public static void Wire()
        {
            try
            {
                Build();
            }
            catch (Exception ex)
            {
                Debug.LogError($"[WireDialogueSystem] FATAL: {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}");
                s_errors.Add($"{ex.GetType().Name}: {ex.Message}");
                PrintSummary();
                // Re-throw so batchmode surfaces a non-zero exit code.
                throw;
            }
        }

        // ─── Master pipeline ────────────────────────────────────────────
        private static void Build()
        {
            ResetTally();
            Log("=== WireDialogueSystem starting ===");

            EnsureFolder(NpcPrefabDir);
            EnsureFolder(UiPrefabDir);
            EnsureFolder(DialogueDir);
            EnsureFolder(NodesDir);
            EnsureFolder(GraphsDir);

            s_attackActionRef = TryFindAttackActionReference();

            // C. World-space UI prefabs (build BEFORE NPC prefabs so we can
            // reference the canvas / button prefabs from the NPC).
            BuildDialogueCanvasPrefab();
            s_choiceButtonComponent = BuildDialogueChoiceButtonPrefab();

            // B. Primitive NPC prefabs (graph not yet assigned — D handles that).
            BuildNpcPrefab(MrSixName,   new Color(0.2f,  0.4f,  0.9f, 1f), new Color(0.45f, 0.65f, 1.0f, 1f));
            BuildNpcPrefab(MrsFourName, new Color(0.95f, 0.45f, 0.55f, 1f), new Color(1.0f,  0.7f,  0.78f, 1f));

            // D. Dialogue ScriptableObjects
            BuildDialogueAssets();

            // E. Re-open NPC prefabs, wire graph + UI prefabs + anchors
            RewireNpcPrefab(MrSixName);
            RewireNpcPrefab(MrsFourName);

            // F. Modify VR UI.unity scene
            PlaceNpcsInScene();

            // G. Final save pass
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Log("=== WireDialogueSystem finished ===");
            PrintSummary();
        }

        // ═════════════════════════════════════════════════════════════════
        // B. Primitive NPC prefabs
        // ═════════════════════════════════════════════════════════════════
        private static void BuildNpcPrefab(string npcName, Color bodyColor, Color headColor)
        {
            string path = $"{NpcPrefabDir}/{npcName}.prefab";
            if (AssetDatabase.LoadAssetAtPath<GameObject>(path) != null)
            {
                Log($"[B] NPC prefab already exists: {path} — skipping.");
                return;
            }

            Shader urpLit = Shader.Find("Universal Render Pipeline/Lit");
            if (urpLit == null)
            {
                // Fallback to standard shader so we never produce pink materials.
                urpLit = Shader.Find("Standard");
            }
            if (urpLit == null)
            {
                Warn($"[B] No usable lit shader found — prefab will be created without materials.");
            }

            Material bodyMat = urpLit != null ? new Material(urpLit) { color = bodyColor } : null;
            Material headMat = urpLit != null ? new Material(urpLit) { color = headColor } : null;

            // Root
            GameObject root = new GameObject(npcName);
            root.transform.position = Vector3.zero;

            SphereCollider sphere = root.AddComponent<SphereCollider>();
            sphere.isTrigger = true;
            sphere.radius    = 2f;
            sphere.center    = Vector3.zero;

            NPCProximityTrigger proximity = root.AddComponent<NPCProximityTrigger>();
            HeadLookAtPlayer    headLook = root.AddComponent<HeadLookAtPlayer>();
            NPCDialogueController controller2 = root.AddComponent<NPCDialogueController>();
            DialogueUIController dialogueUi = root.AddComponent<DialogueUIController>();

            // Body — capsule (strip its built-in collider)
            GameObject body = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            body.name = "Body";
            Collider bodyCollider = body.GetComponent<Collider>();
            if (bodyCollider != null) UnityEngine.Object.DestroyImmediate(bodyCollider);
            body.transform.SetParent(root.transform, worldPositionStays: false);
            body.transform.localPosition = new Vector3(0f, 1f, 0f);
            body.transform.localScale    = new Vector3(0.6f, 0.9f, 0.6f);
            if (bodyMat != null)
            {
                body.GetComponent<Renderer>().sharedMaterial = bodyMat;
            }

            // Head — sphere (strip its built-in collider)
            GameObject head = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            head.name = "Head";
            Collider headCollider = head.GetComponent<Collider>();
            if (headCollider != null) UnityEngine.Object.DestroyImmediate(headCollider);
            head.transform.SetParent(root.transform, worldPositionStays: false);
            head.transform.localPosition = new Vector3(0f, 1.9f, 0f);
            head.transform.localScale    = new Vector3(0.5f, 0.5f, 0.5f);
            if (headMat != null)
            {
                head.GetComponent<Renderer>().sharedMaterial = headMat;
            }

            // DialogueCanvas anchor (world-space canvas is instantiated per-NPC at runtime
            // by DialogueUIController.Awake's billboard logic — keep this empty slot for now).
            GameObject canvasAnchor = new GameObject("DialogueCanvas");
            canvasAnchor.transform.SetParent(root.transform, worldPositionStays: false);
            canvasAnchor.transform.localPosition = new Vector3(0f, 1.7f, 0.6f);

            // Wire component references (graph left null — assigned in RewireNpcPrefab)
            headLook.headBone            = head.transform;
            headLook.playerCamera        = null;
            controller2.headLook         = headLook;
            controller2.proximityTrigger = proximity;

            // Wire the InputActionReference captured at the top of Build()
            // so the reference points at a saved asset (in-memory references
            // cannot survive PrefabUtility.SaveAsPrefabAsset).
            if (s_attackActionRef != null)
            {
                controller2.startAction = s_attackActionRef;
            }

            // Save prefab
            try
            {
                GameObject saved = PrefabUtility.SaveAsPrefabAsset(root, path);
                if (saved == null)
                {
                    Warn($"[B] PrefabUtility.SaveAsPrefabAsset returned null for {path}");
                }
                else
                {
                    s_npcPrefabsCreated++;
                    Log($"[B] Created NPC prefab: {path}");
                }
            }
            finally
            {
                UnityEngine.Object.DestroyImmediate(root);
            }
        }

        // ═════════════════════════════════════════════════════════════════
        // C. World-space UI prefabs
        // ═════════════════════════════════════════════════════════════════
        private static void BuildDialogueCanvasPrefab()
        {
            string path = $"{UiPrefabDir}/{UiCanvasName}";
            if (AssetDatabase.LoadAssetAtPath<GameObject>(path) != null)
            {
                Log($"[C] UI prefab already exists: {path} — skipping.");
                return;
            }

            // Root: world-space Canvas + XR-aware raycaster + DialogueUIController
            GameObject root = new GameObject("DialogueCanvas", typeof(RectTransform));
            Canvas canvas = root.AddComponent<Canvas>();
            canvas.renderMode    = RenderMode.WorldSpace;
            canvas.sortingOrder  = 100;

            CanvasScaler scaler = root.AddComponent<CanvasScaler>();
            scaler.dynamicPixelsPerUnit = 10f;
            scaler.referencePixelsPerUnit = 100f;

            // XR-aware graphic raycaster so XR controllers can hover/click.
            root.AddComponent<TrackedDeviceGraphicRaycaster>();

            DialogueUIController ui = root.AddComponent<DialogueUIController>();

            RectTransform rootRect = root.GetComponent<RectTransform>();
            rootRect.sizeDelta = new Vector2(400f, 300f);

            // Content (RectTransform)
            GameObject content = new GameObject("Content", typeof(RectTransform));
            content.transform.SetParent(root.transform, worldPositionStays: false);
            RectTransform contentRect = content.GetComponent<RectTransform>();
            contentRect.anchorMin      = new Vector2(0f, 0f);
            contentRect.anchorMax      = new Vector2(1f, 1f);
            contentRect.pivot          = new Vector2(0.5f, 0.5f);
            contentRect.anchoredPosition = Vector2.zero;
            contentRect.sizeDelta       = Vector2.zero;
            contentRect.localScale      = Vector3.one;

            // SpeakerLabel — TMP_Text anchored top-center
            GameObject speaker = CreateTmpText("SpeakerLabel", content.transform, new Vector2(0f, 1f), new Vector2(1f, 1f), new Vector2(0.5f, 1f), 8, TextAlignmentOptions.Center, new Vector2(0f, 20f));
            TMP_Text speakerTmp = speaker.GetComponent<TMP_Text>();

            // LineText — TMP_Text anchored top-center with SpeakerLabel offset
            GameObject line = CreateTmpText("LineText", content.transform, new Vector2(0f, 1f), new Vector2(1f, 1f), new Vector2(0.5f, 1f), 6, TextAlignmentOptions.TopLeft, new Vector2(0f, 80f));
            TMP_Text lineTmp = line.GetComponent<TMP_Text>();
            lineTmp.textWrappingMode = TextWrappingModes.Normal;
            // Position LineText below SpeakerLabel by anchoring its pivot at 0.7 of content height
            RectTransform lineRect = line.GetComponent<RectTransform>();
            lineRect.pivot = new Vector2(0.5f, 1f);
            lineRect.anchorMin = new Vector2(0f, 0.5f);
            lineRect.anchorMax = new Vector2(1f, 0.5f);
            lineRect.anchoredPosition = new Vector2(0f, 0f);
            lineRect.sizeDelta = new Vector2(0f, 80f);

            // ChoicesRoot — RectTransform anchored bottom-center
            GameObject choices = new GameObject("ChoicesRoot", typeof(RectTransform));
            choices.transform.SetParent(content.transform, worldPositionStays: false);
            RectTransform choicesRect = choices.GetComponent<RectTransform>();
            choicesRect.anchorMin        = new Vector2(0.1f, 0f);
            choicesRect.anchorMax        = new Vector2(0.9f, 0.5f);
            choicesRect.pivot            = new Vector2(0.5f, 0f);
            choicesRect.anchoredPosition = Vector2.zero;
            choicesRect.sizeDelta        = Vector2.zero;
            choicesRect.localScale       = Vector3.one;

            // Wire DialogueUIController fields
            ui.canvas       = canvas;
            ui.contentRoot  = contentRect;
            ui.speakerLabel = speakerTmp;
            ui.lineText     = lineTmp;
            ui.choicesRoot  = choicesRect;
            // choiceButtonPrefab is wired per-NPC in RewireNpcPrefab.

            try
            {
                GameObject saved = PrefabUtility.SaveAsPrefabAsset(root, path);
                if (saved == null)
                {
                    Warn($"[C] SaveAsPrefabAsset returned null for {path}");
                }
                else
                {
                    s_uiPrefabsCreated++;
                    Log($"[C] Created UI prefab: {path}");
                }
            }
            finally
            {
                UnityEngine.Object.DestroyImmediate(root);
            }
        }

        private static DialogueChoiceButton BuildDialogueChoiceButtonPrefab()
        {
            string path = $"{UiPrefabDir}/{UiChoiceButtonName}";
            GameObject existingPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (existingPrefab != null)
            {
                Log($"[C] UI prefab already exists: {path} — skipping.");
                return existingPrefab.GetComponent<DialogueChoiceButton>();
            }

            // Root with Image + Button
            GameObject root = new GameObject("DialogueChoiceButton", typeof(RectTransform), typeof(Image), typeof(Button));
            Image image = root.GetComponent<Image>();
            image.color = new Color(0.15f, 0.18f, 0.22f, 0.92f);
            image.type  = Image.Type.Sliced;

            Button button = root.GetComponent<Button>();
            ColorBlock cb = button.colors;
            cb.normalColor      = new Color(0.18f, 0.22f, 0.28f, 1f);
            cb.highlightedColor = new Color(0.25f, 0.32f, 0.40f, 1f);
            cb.pressedColor    = new Color(0.10f, 0.14f, 0.18f, 1f);
            cb.selectedColor   = cb.highlightedColor;
            button.colors = cb;

            RectTransform rootRect = root.GetComponent<RectTransform>();
            rootRect.sizeDelta = new Vector2(280f, 36f);

            // Label child
            GameObject label = CreateTmpText("Label", root.transform, Vector2.zero, Vector2.one, new Vector2(0.5f, 0.5f), 6, TextAlignmentOptions.Center, Vector2.zero);
            TMP_Text labelTmp = label.GetComponent<TMP_Text>();
            RectTransform labelRect = label.GetComponent<RectTransform>();
            labelRect.anchorMin        = Vector2.zero;
            labelRect.anchorMax        = Vector2.one;
            labelRect.pivot            = new Vector2(0.5f, 0.5f);
            labelRect.anchoredPosition = Vector2.zero;
            labelRect.sizeDelta        = new Vector2(-16f, -8f);

            DialogueChoiceButton leaf = root.AddComponent<DialogueChoiceButton>();

            // Wire DialogueChoiceButton serialized fields via reflection-friendly assignment
            // (public fields aren't serialized private — we use SerializedObject for persistence).
            ApplySerializedField(leaf, "button", button);
            ApplySerializedField(leaf, "label",  labelTmp);

            try
            {
                GameObject saved = PrefabUtility.SaveAsPrefabAsset(root, path);
                if (saved == null)
                {
                    Warn($"[C] SaveAsPrefabAsset returned null for {path}");
                }
                else
                {
                    s_uiPrefabsCreated++;
                    Log($"[C] Created UI prefab: {path}");
                }
            }
            finally
            {
                UnityEngine.Object.DestroyImmediate(root);
            }
            return leaf;
        }

        // ═════════════════════════════════════════════════════════════════
        // D. Dialogue ScriptableObject assets
        // ═════════════════════════════════════════════════════════════════
        private static void BuildDialogueAssets()
        {
            // --- Create all nodes first so choices can reference them ---
            DialogueNode mrsixGreeting    = CreateNodeAsset($"{NodesDir}/{MrSixName}_Greeting.asset",         "Mr. Six",   "Hello there, traveler. Welcome to my little mill.", false);
            DialogueNode mrsixAboutMill   = CreateNodeAsset($"{NodesDir}/{MrSixName}_AboutTheMill.asset",    "Mr. Six",   "This old stone mill has been turning grain for three generations.", false);
            DialogueNode mrsixFarewell    = CreateNodeAsset($"{NodesDir}/{MrSixName}_Farewell.asset",       "Mr. Six",   "Safe travels!", true);

            DialogueNode mrsfourGreeting  = CreateNodeAsset($"{NodesDir}/{MrsFourName}_Greeting.asset",       "Mrs. Four", "Oh, a visitor! How lovely.", false);
            DialogueNode mrsfourWeather   = CreateNodeAsset($"{NodesDir}/{MrsFourName}_AboutTheWeather.asset", "Mrs. Four", "Clear skies over the paddies today. Good for drying the rice.", false);
            DialogueNode mrsfourFarewell  = CreateNodeAsset($"{NodesDir}/{MrsFourName}_Farewell.asset",      "Mrs. Four", "Come back anytime.", true);

            // --- Now populate choices (nodes already exist as assets) ---
            mrsixGreeting.choices = new List<DialogueChoice>
            {
                new DialogueChoice { choiceText = "Tell me about the mill", nextNode = mrsixAboutMill, animationTag = string.Empty },
                new DialogueChoice { choiceText = "Goodbye",                nextNode = mrsixFarewell,  animationTag = string.Empty },
            };
            EditorUtility.SetDirty(mrsixGreeting);

            mrsixAboutMill.choices = new List<DialogueChoice>
            {
                new DialogueChoice { choiceText = "Farewell", nextNode = mrsixFarewell, animationTag = string.Empty },
            };
            EditorUtility.SetDirty(mrsixAboutMill);

            mrsfourGreeting.choices = new List<DialogueChoice>
            {
                new DialogueChoice { choiceText = "How is the weather today?", nextNode = mrsfourWeather,  animationTag = string.Empty },
                new DialogueChoice { choiceText = "I should go",              nextNode = mrsfourFarewell, animationTag = string.Empty },
            };
            EditorUtility.SetDirty(mrsfourGreeting);

            mrsfourWeather.choices = new List<DialogueChoice>
            {
                new DialogueChoice { choiceText = "Take care", nextNode = mrsfourFarewell, animationTag = string.Empty },
            };
            EditorUtility.SetDirty(mrsfourWeather);

            // --- Build graphs ---
            CreateGraphAsset(
                $"{GraphsDir}/{MrSixName}.asset",
                "Mr. Six",
                mrsixGreeting,
                new List<DialogueNode> { mrsixGreeting, mrsixAboutMill, mrsixFarewell });

            CreateGraphAsset(
                $"{GraphsDir}/{MrsFourName}.asset",
                "Mrs. Four",
                mrsfourGreeting,
                new List<DialogueNode> { mrsfourGreeting, mrsfourWeather, mrsfourFarewell });

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        private static DialogueNode CreateNodeAsset(string path, string speaker, string text, bool isEnd)
        {
            DialogueNode node = AssetDatabase.LoadAssetAtPath<DialogueNode>(path);
            if (node != null)
            {
                Log($"[D] Node already exists: {path} — updating fields.");
            }
            else
            {
                node = ScriptableObject.CreateInstance<DialogueNode>();
                AssetDatabase.CreateAsset(node, path);
                s_nodesCreated++;
                Log($"[D] Created node: {path}");
            }
            node.line = new DialogueLine
            {
                speakerName      = speaker,
                text             = text,
                animationTag     = string.Empty,
                voiceClip        = null,
                autoAdvanceAfter = 0f,
            };
            node.choices   = new List<DialogueChoice>();
            node.isEndNode = isEnd;
            EditorUtility.SetDirty(node);
            return node;
        }

        private static void CreateGraphAsset(string path, string characterName, DialogueNode entry, List<DialogueNode> nodes)
        {
            DialogueGraph graph = AssetDatabase.LoadAssetAtPath<DialogueGraph>(path);
            if (graph == null)
            {
                graph = ScriptableObject.CreateInstance<DialogueGraph>();
                AssetDatabase.CreateAsset(graph, path);
                s_graphsCreated++;
                Log($"[D] Created graph: {path}");
            }
            else
            {
                Log($"[D] Graph already exists: {path} — updating fields.");
            }

            graph.characterName = characterName;
            graph.entryNode     = entry;
            graph.nodes         = new List<DialogueNode>(nodes);
            EditorUtility.SetDirty(graph);
        }

        // ═════════════════════════════════════════════════════════════════
        // E. Re-open NPC prefabs, wire graph + UI prefabs + anchor
        // ═════════════════════════════════════════════════════════════════
        private static void RewireNpcPrefab(string npcName)
        {
            string npcPath    = $"{NpcPrefabDir}/{npcName}.prefab";
            string graphPath  = $"{GraphsDir}/{npcName}.asset";
            string canvasPath = $"{UiPrefabDir}/{UiCanvasName}";
            string buttonPath = $"{UiPrefabDir}/{UiChoiceButtonName}";

            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(npcPath);
            if (prefab == null)
            {
                Warn($"[E] NPC prefab not found: {npcPath}");
                return;
            }

            DialogueGraph graph = AssetDatabase.LoadAssetAtPath<DialogueGraph>(graphPath);
            if (graph == null)
            {
                Warn($"[E] Graph not found for {npcName}: {graphPath}");
            }

            GameObject buttonPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(buttonPath);
            DialogueChoiceButton buttonComponent = buttonPrefab != null
                ? buttonPrefab.GetComponent<DialogueChoiceButton>()
                : null;
            if (buttonComponent == null)
            {
                Warn($"[E] DialogueChoiceButton component not found at {buttonPath}");
            }

            // Instantiate into scene to modify, then save back.
            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            if (instance == null)
            {
                Warn($"[E] Failed to instantiate prefab {npcPath}");
                return;
            }
            try
            {
                NPCDialogueController controller = instance.GetComponent<NPCDialogueController>();
                if (controller != null)
                {
                    if (graph != null)
                    {
                        controller.graph = graph;
                    }
                    if (s_attackActionRef != null)
                    {
                        controller.startAction = s_attackActionRef;
                    }
                }

                DialogueUIController ui = instance.GetComponent<DialogueUIController>();
                if (ui != null)
                {
                    ui.anchor = instance.transform;
                    if (buttonComponent != null)
                    {
                        ui.choiceButtonPrefab = buttonComponent;
                    }
                }

                EditorUtility.SetDirty(controller);
                EditorUtility.SetDirty(ui);

                bool saved = PrefabUtility.SaveAsPrefabAsset(instance, npcPath);
                if (!saved)
                {
                    Warn($"[E] SaveAsPrefabAsset returned false for {npcPath}");
                }
                else
                {
                    s_prefabsRewired++;
                    Log($"[E] Rewired NPC prefab: {npcPath}");
                }
            }
            finally
            {
                UnityEngine.Object.DestroyImmediate(instance);
            }
        }

        // ═════════════════════════════════════════════════════════════════
        // F. Modify VR UI.unity scene
        // ═════════════════════════════════════════════════════════════════
        private static void PlaceNpcsInScene()
        {
            Scene scene = EditorSceneManager.OpenScene(ScenePath, OpenSceneMode.Single);
            if (!scene.IsValid())
            {
                Warn($"[F] Failed to open scene: {ScenePath}");
                return;
            }

            EnsureEventSystemHasXRUIInputModule(scene);

            PlacePrefabInScene(MrSixName,   MrSixScenePos,   scene);
            PlacePrefabInScene(MrsFourName, MrsFourScenePos, scene);

            EditorSceneManager.MarkSceneDirty(scene);
            bool saved = EditorSceneManager.SaveScene(scene);
            if (!saved)
            {
                Warn($"[F] Failed to save scene: {ScenePath}");
            }
            else
            {
                Log($"[F] Saved scene: {ScenePath}");
            }
        }

        private static void PlacePrefabInScene(string npcName, Vector3 position, Scene scene)
        {
            string npcPath = $"{NpcPrefabDir}/{npcName}.prefab";
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(npcPath);
            if (prefab == null)
            {
                Warn($"[F] Prefab missing for placement: {npcPath}");
                return;
            }

            GameObject[] roots = scene.GetRootGameObjects();
            for (int i = 0; i < roots.Length; i++)
            {
                if (roots[i] != null && roots[i].name == npcName)
                {
                    Log($"[F] '{npcName}' already present in scene — skipping placement.");
                    roots[i].transform.position = position;
                    return;
                }
            }

            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab, scene);
            if (instance == null)
            {
                Warn($"[F] Failed to instantiate {npcName} into scene");
                return;
            }
            instance.name = npcName;
            instance.transform.position = position;
            s_scenePlacements++;
            Log($"[F] Placed {npcName} at {position}");
        }

        private static void EnsureEventSystemHasXRUIInputModule(Scene scene)
        {
            EventSystem existing = null;
            GameObject[] roots = scene.GetRootGameObjects();
            for (int i = 0; i < roots.Length; i++)
            {
                EventSystem es = roots[i].GetComponentInChildren<EventSystem>(includeInactive: true);
                if (es != null)
                {
                    existing = es;
                    break;
                }
            }

            if (existing == null)
            {
                GameObject esGo = new GameObject("EventSystem");
                SceneManager.MoveGameObjectToScene(esGo, scene);
                existing = esGo.AddComponent<EventSystem>();
                esGo.AddComponent<XRUIInputModule>();
                Log("[F] Created new EventSystem with XRUIInputModule.");
                return;
            }

            // Replace any non-XR input module with XRUIInputModule so VR controllers can drive UI.
            StandaloneInputModule standalone = existing.GetComponent<StandaloneInputModule>();
            if (standalone != null)
            {
                UnityEngine.Object.DestroyImmediate(standalone);
                Log("[F] Removed StandaloneInputModule.");
            }
            if (existing.GetComponent<XRUIInputModule>() == null)
            {
                existing.gameObject.AddComponent<XRUIInputModule>();
                Log("[F] Added XRUIInputModule to existing EventSystem.");
            }
        }

        // ═════════════════════════════════════════════════════════════════
        // Helpers
        // ═════════════════════════════════════════════════════════════════
        private static GameObject CreateTmpText(
            string name,
            Transform parent,
            Vector2 anchorMin,
            Vector2 anchorMax,
            Vector2 pivot,
            float fontSize,
            TextAlignmentOptions alignment,
            Vector2 sizeDelta)
        {
            GameObject go = new GameObject(name, typeof(RectTransform));
            go.transform.SetParent(parent, worldPositionStays: false);

            RectTransform rect = go.GetComponent<RectTransform>();
            rect.anchorMin        = anchorMin;
            rect.anchorMax        = anchorMax;
            rect.pivot            = pivot;
            rect.anchoredPosition = Vector2.zero;
            rect.sizeDelta        = sizeDelta;
            rect.localScale       = Vector3.one;

            // Use TextMeshProUGUI (the world-space-canvas-safe TMP UI type).
            TextMeshProUGUI tmp = go.AddComponent<TextMeshProUGUI>();
            tmp.text      = string.Empty;
            tmp.fontSize  = fontSize;
            tmp.alignment = alignment;
            tmp.color     = Color.white;
            tmp.raycastTarget = false;
            return go;
        }

        /// <summary>
        /// Assigns a private serialized field via <see cref="SerializedObject"/> on a
        /// non-asset MonoBehaviour. Necessary because <see cref="DialogueChoiceButton"/>
        /// declares those fields as <c>[SerializeField] private</c>.
        /// </summary>
        private static void ApplySerializedField(MonoBehaviour target, string fieldName, object value)
        {
            if (target == null) return;
            try
            {
                SerializedObject so = new SerializedObject(target);
                SerializedProperty prop = so.FindProperty(fieldName);
                if (prop == null)
                {
                    Warn($"[Helper] SerializedProperty '{fieldName}' not found on {target.GetType().Name}");
                    return;
                }

                switch (prop.propertyType)
                {
                    case SerializedPropertyType.ObjectReference:
                        prop.objectReferenceValue = value as UnityEngine.Object;
                        break;
                    case SerializedPropertyType.String:
                        prop.stringValue = value as string ?? string.Empty;
                        break;
                    default:
                        Warn($"[Helper] SerializedProperty '{fieldName}' is {prop.propertyType} — manual assignment unsupported.");
                        return;
                }
                so.ApplyModifiedPropertiesWithoutUndo();
            }
            catch (Exception ex)
            {
                Warn($"[Helper] Failed to assign '{fieldName}' on {target.GetType().Name}: {ex.Message}");
            }
        }

        private static InputActionReference TryFindAttackActionReference()
        {
            try
            {
                InputActionReference existing = AssetDatabase.LoadAssetAtPath<InputActionReference>(AttackActionRefPath);
                if (existing != null)
                {
                    return existing;
                }

                InputActionAsset asset = AssetDatabase.LoadAssetAtPath<InputActionAsset>(InputActionAssetPath);
                if (asset == null)
                {
                    Warn($"[B] InputActionAsset not found at {InputActionAssetPath}");
                    return null;
                }
                InputAction attack = asset.FindAction("Player/Attack");
                if (attack == null)
                {
                    Warn($"[B] Action 'Player/Attack' not found in {InputActionAssetPath}");
                    return null;
                }
                InputActionReference reference = InputActionReference.Create(attack);
                if (reference == null)
                {
                    Warn($"[B] InputActionReference.Create returned null for Player/Attack");
                    return null;
                }

                EnsureFolder(Path.GetDirectoryName(AttackActionRefPath)?.Replace('\\', '/'));
                AssetDatabase.CreateAsset(reference, AttackActionRefPath);
                EditorUtility.SetDirty(reference);
                AssetDatabase.SaveAssets();
                s_inputActionRefSaved++;
                Log($"[B] Saved InputActionReference asset: {AttackActionRefPath}");
                return reference;
            }
            catch (Exception ex)
            {
                Warn($"[B] Failed to build InputActionReference: {ex.Message}");
                return null;
            }
        }

        private static void EnsureFolder(string assetPath)
        {
            if (AssetDatabase.IsValidFolder(assetPath))
            {
                return;
            }
            string parent = Path.GetDirectoryName(assetPath)?.Replace('\\', '/');
            string leaf   = Path.GetFileName(assetPath);
            if (string.IsNullOrEmpty(parent) || string.IsNullOrEmpty(leaf))
            {
                Warn($"[Helper] EnsureFolder received invalid path: {assetPath}");
                return;
            }
            if (!AssetDatabase.IsValidFolder(parent))
            {
                EnsureFolder(parent);
            }
            AssetDatabase.CreateFolder(parent, leaf);
        }

        private static void ResetTally()
        {
            s_npcPrefabsCreated  = 0;
            s_uiPrefabsCreated   = 0;
            s_nodesCreated       = 0;
            s_graphsCreated      = 0;
            s_inputActionRefSaved = 0;
            s_prefabsRewired     = 0;
            s_scenePlacements    = 0;
            s_attackActionRef    = null;
            s_choiceButtonComponent = null;
            s_warnings.Clear();
            s_errors.Clear();
        }

        private static void Log(string message)
        {
            Debug.Log($"[WireDialogueSystem] {message}");
        }

        private static void Warn(string message)
        {
            s_warnings.Add(message);
            Debug.LogWarning($"[WireDialogueSystem] {message}");
        }

        private static void PrintSummary()
        {
            int total = s_npcPrefabsCreated + s_uiPrefabsCreated + s_nodesCreated + s_graphsCreated + s_prefabsRewired + s_scenePlacements;

            string banner = "\n" +
                "════════════════════════════════════════════════════════════════════\n" +
                " WireDialogueSystem — SUMMARY\n" +
                "════════════════════════════════════════════════════════════════════\n" +
                $" NPC prefabs created          : {s_npcPrefabsCreated}\n" +
                $" UI prefabs created           : {s_uiPrefabsCreated}\n" +
                $" DialogueNode assets created  : {s_nodesCreated}\n" +
                $" DialogueGraph assets created : {s_graphsCreated}\n" +
                $" InputActionRef saved         : {s_inputActionRefSaved}\n" +
                $" NPC prefabs rewired          : {s_prefabsRewired}\n" +
                $" Scene placements             : {s_scenePlacements}\n" +
                $" ─────────────────────────────────────────────────────────────────\n" +
                $" TOTAL operations             : {total}\n" +
                $" Warnings                     : {s_warnings.Count}\n" +
                $" Errors                       : {s_errors.Count}\n" +
                "════════════════════════════════════════════════════════════════════";

            Debug.Log(banner);
        }
    }
}
#endif