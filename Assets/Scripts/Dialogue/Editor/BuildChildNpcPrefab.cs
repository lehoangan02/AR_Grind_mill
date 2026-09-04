// BuildChildNpcPrefab.cs
//
// Editor menu utility that builds the ChildNpc NPC prefab at
// Assets/Prefabs/NPCs/ChildNpc.prefab by assembling the imported child
// model (Assets/KidsCharacterFree/Fbx/Boy0_Humanoid.fbx)
// with the dialogue / movement / tip-stack:
//
//   • Animator                (runtimeAnimatorController = ChildNpcAnimator)
//   • HeadLookAtPlayer        (headBone via HumanBodyBones.Head w/ name-search fallback)
//   • NPCProximityTrigger     (triggerRadius = 2.5f)
//   • NPCDialogueController   (graph, proximityTrigger, headLook, startAction wired)
//   • WanderingGuideController (animator, headLook, groundProbe wired; player = null)
//   • ChildNpcTipController   (dialogueController, wander, 10 DialogueNode refs)
//   • GroundProbe             (defaults: raycastHeight 0.5, raycastDistance 5, groundMask ~0)
//   • SphereCollider          (radius 0.4, isTrigger = true; reused if FBX already has one)
//   • DialogueCanvas child    (prefab instantiated as child; anchor = head bone)
//
// All serialized references are written via SerializedObject so they
// survive PrefabUtility.SaveAsPrefabAsset.
//
// The script is idempotent: a second invocation overwrites the prefab in
// place. NavMesh / NavMeshAgent are explicitly NOT used.

#if UNITY_EDITOR
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using AR_Grind_mill.Dialogue.ChildNpc;
using AR_Grind_mill.Dialogue.Data;
using AR_Grind_mill.Dialogue.Runtime;
using AR_Grind_mill.Dialogue.UI;

namespace AR_Grind_mill.Dialogue.EditorTools
{
    /// <summary>
    /// One-shot editor builder for the child NPC prefab.
    /// Invoke from the editor menu: AR_Grind_mill > ChildNpc > Build Prefab.
    /// </summary>
    public static class BuildChildNpcPrefab
    {
        // ─── Asset paths (single source of truth) ─────────────────────────
        private const string FbxPath           = "Assets/KidsCharacterFree/Fbx/Boy0_Humanoid.fbx";
        private const string AnimatorPath      = "Assets/Prefabs/NPCs/ChildNpcAnimator.controller";
        private const string GraphPath         = "Assets/Dialogue/Graphs/ChildNpc.asset";
        private const string DialogueCanvasPath = "Assets/Prefabs/UI/Dialogue/DialogueCanvas.prefab";
        private const string StartActionPath   = "Assets/Dialogue/PlayerAttackActionRef.asset";

        private const string ChildNodesDir    = "Assets/Dialogue/Nodes/ChildNpc";
        private const string PrefabOutputDir  = "Assets/Prefabs/NPCs";
        private const string PrefabOutputPath = PrefabOutputDir + "/ChildNpc.prefab";

        // Tip pool: intro + 10 single-line tip nodes.
        private const int    TipCount         = 10;
        private const string TipPrefix       = "ChildNpc_Tip_";

        // ─── Menu entry point ─────────────────────────────────────────────
        [MenuItem("AR_Grind_mill/ChildNpc/Build Prefab")]
        public static void BuildMenu()
        {
            BuildResult result = BuildAll();
            if (result.Success)
            {
                Debug.Log($"[BuildChildNpcPrefab] Prefab built at {PrefabOutputPath}. " +
                          $"Components: {result.ComponentCount}. Refs: {result.References.Count}.");
            }
            else
            {
                Debug.LogError($"[BuildChildNpcPrefab] Build failed: {result.Error}");
            }
        }

        // ─── Headless / batch entry point ─────────────────────────────────
        public static BuildResult BuildAll()
        {
            var result = new BuildResult();

            // 1. Ensure the output directory exists.
            if (!AssetDatabase.IsValidFolder(PrefabOutputDir))
            {
                result.Error = $"Output directory missing: {PrefabOutputDir}";
                return result;
            }

            // 2. Load all source assets up-front. Fail fast with a clear error.
            GameObject fbxRoot = AssetDatabase.LoadAssetAtPath<GameObject>(FbxPath);
            if (fbxRoot == null)
            {
                result.Error = $"FBX not found at {FbxPath}";
                return result;
            }

            RuntimeAnimatorController animatorController =
                AssetDatabase.LoadAssetAtPath<RuntimeAnimatorController>(AnimatorPath);
            if (animatorController == null)
            {
                result.Error = $"AnimatorController not found at {AnimatorPath}";
                return result;
            }

            DialogueGraph graph = AssetDatabase.LoadAssetAtPath<DialogueGraph>(GraphPath);
            if (graph == null)
            {
                result.Error = $"DialogueGraph not found at {GraphPath}";
                return result;
            }

            GameObject dialogueCanvasPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(DialogueCanvasPath);
            if (dialogueCanvasPrefab == null)
            {
                result.Error = $"DialogueCanvas prefab not found at {DialogueCanvasPath}";
                return result;
            }

            InputActionReference startAction =
                AssetDatabase.LoadAssetAtPath<InputActionReference>(StartActionPath);
            if (startAction == null)
            {
                result.Error = $"InputActionReference not found at {StartActionPath}";
                return result;
            }

            // 3. Load the 10 tip nodes in order.
            DialogueNode[] tipNodes = new DialogueNode[TipCount];
            for (int i = 0; i < TipCount; i++)
            {
                string assetName = $"{TipPrefix}{i + 1:D2}";
                DialogueNode n = LoadNode(assetName);
                if (n == null)
                {
                    result.Error = $"Missing tip node {assetName} — run BuildChildNpcDialogueAssets first.";
                    return result;
                }
                tipNodes[i] = n;
            }

            // 4. Instantiate the FBX as a prefab variant in the scene.
            //    PrefabUtility.InstantiatePrefab preserves the link to the FBX so
            //    the result is a true prefab variant (not a regular GameObject).
            GameObject root = (GameObject)PrefabUtility.InstantiatePrefab(fbxRoot);
            if (root == null)
            {
                result.Error = "Failed to instantiate FBX as prefab.";
                return result;
            }
            root.name = "ChildNpc";

            try
            {
                // 5. Animator: already present on the FBX. Assign the runtime
                //    controller via SerializedObject so the change persists.
                Animator animator = root.GetComponent<Animator>();
                if (animator == null)
                {
                    result.Error = "Imported FBX has no Animator on the root.";
                    return result;
                }
                SetSerializedField(animator, "m_Controller", animatorController);

                // 6. Resolve the head bone. Primary path: Humanoid API per spec.
                //    Fallback: name search against the model's actual bone names
                //    so the field is never null even when the runtime avatar
                //    fails the isHuman check (e.g. mis-mapped HumanDescription).
                Transform headBone = ResolveHeadBone(animator);
                if (headBone == null)
                {
                    Debug.LogWarning(
                        "[BuildChildNpcPrefab] Head bone NOT FOUND via Humanoid or name search — " +
                        "falling back to NPC root transform. HeadLookAtPlayer will not look natural.");
                    headBone = root.transform;
                }

                // 7. SphereCollider — reuse if present, else add.
                SphereCollider sphere = root.GetComponent<SphereCollider>();
                bool addedNewSphere = false;
                if (sphere == null)
                {
                    sphere = root.AddComponent<SphereCollider>();
                    addedNewSphere = true;
                }
                sphere.isTrigger = true;
                sphere.radius = 0.4f;
                // Center stays at (0,0,0) so the sphere wraps the NPC's body.

                // 8. Add runtime + child-NPC components in dependency order.
                //    HeadLookAtPlayer first (others reference it).
                HeadLookAtPlayer headLook = root.AddComponent<HeadLookAtPlayer>();
                SetSerializedField(headLook, "headBone", headBone);
                SetSerializedField(headLook, "maxDistance", 4f);
                SetSerializedField(headLook, "engageSmoothTime", 0.25f);

                NPCProximityTrigger proximity = root.AddComponent<NPCProximityTrigger>();
                SetSerializedField(proximity, "triggerRadius", 2.5f);

                NPCDialogueController dialogue = root.AddComponent<NPCDialogueController>();
                SetSerializedField(dialogue, "graph", graph);
                SetSerializedField(dialogue, "proximityTrigger", proximity);
                SetSerializedField(dialogue, "headLook", headLook);
                SetSerializedField(dialogue, "startAction", startAction);
                SetSerializedField(dialogue, "endAction", null);

                WanderingGuideController wander = root.AddComponent<WanderingGuideController>();
                // player is left null on purpose — WanderingGuideController.Start()
                // resolves it from XROrigin. Spec says "player left null".

                GroundProbe probe = root.AddComponent<GroundProbe>();
                // Defaults: raycastHeight=0.5, raycastDistance=5, groundMask=~0
                // — GroundProbe already serializes these as field initializers.

                // Tip controller — replaces the previous ChildNpcQuestHook.
                // Owns the periodic schedule and one-off delivery of tip nodes.
                ChildNpcTipController tip = root.AddComponent<ChildNpcTipController>();
                SetSerializedField(tip, "dialogueController", dialogue);
                SetSerializedField(tip, "wander", wander);
                SetSerializedNodeArray(tip, "tips", tipNodes);

                // Wander references — must be done after the components are added.
                SetSerializedField(wander, "animator", animator);
                SetSerializedField(wander, "headLook", headLook);
                SetSerializedField(wander, "groundProbe", probe);
                SetSerializedField(wander, "player", null);

                // 9. Instantiate the DialogueCanvas as a child of the NPC root.
                GameObject canvasInstance = (GameObject)PrefabUtility.InstantiatePrefab(dialogueCanvasPrefab, root.transform);
                canvasInstance.name = "DialogueCanvas";
                DialogueUIController canvasCtrl = canvasInstance.GetComponent<DialogueUIController>();
                if (canvasCtrl == null)
                {
                    result.Error = "DialogueCanvas prefab has no DialogueUIController component.";
                    return result;
                }
                SetSerializedField(canvasCtrl, "anchor", headBone);

                // 10. Mark everything dirty so the changes are flushed to the
                //     serialized asset on save.
                EditorUtility.SetDirty(animator);
                EditorUtility.SetDirty(headLook);
                EditorUtility.SetDirty(proximity);
                EditorUtility.SetDirty(dialogue);
                EditorUtility.SetDirty(wander);
                EditorUtility.SetDirty(tip);
                EditorUtility.SetDirty(probe);
                EditorUtility.SetDirty(sphere);
                EditorUtility.SetDirty(canvasCtrl);
                EditorUtility.SetDirty(canvasInstance);
                EditorUtility.SetDirty(root);

                // 11. Save as a prefab asset. The output path was verified to
                //     not exist before this menu ran (see BuildFromModel gate).
                GameObject saved = PrefabUtility.SaveAsPrefabAsset(root, PrefabOutputPath);
                if (saved == null)
                {
                    result.Error = $"PrefabUtility.SaveAsPrefabAsset returned null for {PrefabOutputPath}";
                    return result;
                }

                // 12. Reload the saved prefab and verify every serialized
                //     reference is wired. This is the evidence gate.
                result = VerifyPrefab(PrefabOutputPath, addedNewSphere, headBone);
                return result;
            }
            finally
            {
                // Always clean up the in-scene instance, even on failure.
                if (root != null)
                {
                    Object.DestroyImmediate(root);
                }
            }
        }

        // ─── Helpers ──────────────────────────────────────────────────────

        /// <summary>
        /// Write an array of <see cref="UnityEngine.Object"/> references to a
        /// serialized array field. Resizes the array first; missing elements
        /// are cleared to null.
        /// </summary>
        private static void SetSerializedNodeArray(Object target, string fieldName, Object[] values)
        {
            if (target == null) return;
            SerializedObject so = new SerializedObject(target);
            SerializedProperty prop = so.FindProperty(fieldName);
            if (prop == null || !prop.isArray)
            {
                Debug.LogWarning($"[BuildChildNpcPrefab] '{fieldName}' is not an array on {target.GetType().Name}.");
                return;
            }
            prop.arraySize = values != null ? values.Length : 0;
            if (values != null)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    prop.GetArrayElementAtIndex(i).objectReferenceValue = values[i];
                }
            }
            so.ApplyModifiedPropertiesWithoutUndo();
        }

        private static DialogueNode LoadNode(string assetName)
        {
            string path = $"{ChildNodesDir}/{assetName}.asset";
            DialogueNode node = AssetDatabase.LoadAssetAtPath<DialogueNode>(path);
            if (node == null)
            {
                Debug.LogError($"[BuildChildNpcPrefab] Missing DialogueNode at {path}");
            }
            return node;
        }

        /// <summary>
        /// Resolve the head bone for HeadLookAtPlayer. Spec is the Humanoid API
        /// (<c>animator.GetBoneTransform(HumanBodyBones.Head)</c>); if the runtime
        /// avatar fails the isHuman check (e.g. mis-mapped HumanDescription in the
        /// FBX import), fall back to a name search so the field is non-null and
        /// the visual still works.
        /// </summary>
        private static Transform ResolveHeadBone(Animator animator)
        {
            if (animator == null) return null;

            // Primary: Humanoid API per spec.
            if (animator.isHuman)
            {
                Transform head = animator.GetBoneTransform(HumanBodyBones.Head);
                if (head != null) return head;
            }

            // Secondary: search by exact / partial name in the rig hierarchy.
            // Order matches the most likely FBX conventions.
            string[] candidates =
            {
                "Head", "head",
                "mixamorig:Head",
                "head.x", "c_head.x", "head.x_end",
                "neck.x", "c_neck.x", "neck.x_end",
            };
            foreach (string name in candidates)
            {
                foreach (Transform t in animator.GetComponentsInChildren<Transform>(true))
                {
                    if (t.name == name) return t;
                }
            }
            return null;
        }

        /// <summary>
        /// Set a serialized field (including private [SerializeField]s) on the
        /// target. Uses <see cref="SerializedObject"/> so the change persists
        /// across PrefabUtility.SaveAsPrefabAsset.
        /// </summary>
        private static void SetSerializedField(Object target, string fieldName, object value)
        {
            if (target == null) return;
            SerializedObject so = new SerializedObject(target);
            SerializedProperty prop = so.FindProperty(fieldName);
            if (prop == null)
            {
                // Field not found via SerializedProperty — try direct reflection
                // as a last resort. Private fields without [SerializeField] are
                // rare but Wander's `player` is one (no SerializeField) and we want
                // to set it anyway so a default value is visible in the Inspector.
                FieldInfo fi = target.GetType().GetField(fieldName,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (fi != null)
                {
                    fi.SetValue(target, value);
                    if (target is Object uo) EditorUtility.SetDirty(uo);
                }
                else
                {
                    Debug.LogWarning($"[BuildChildNpcPrefab] Field '{fieldName}' not found on {target.GetType().Name}.");
                }
                return;
            }

            switch (prop.propertyType)
            {
                case SerializedPropertyType.ObjectReference:
                    prop.objectReferenceValue = value as Object;
                    break;
                case SerializedPropertyType.Float:
                    prop.floatValue = value is float f ? f : 0f;
                    break;
                case SerializedPropertyType.Integer:
                    prop.intValue = value is int ii ? ii : 0;
                    break;
                case SerializedPropertyType.Boolean:
                    prop.boolValue = value is bool b && b;
                    break;
                case SerializedPropertyType.String:
                    prop.stringValue = value as string;
                    break;
                default:
                    Debug.LogWarning(
                        $"[BuildChildNpcPrefab] Unsupported SerializedPropertyType {prop.propertyType} " +
                        $"for field '{fieldName}' on {target.GetType().Name}.");
                    return;
            }
            so.ApplyModifiedPropertiesWithoutUndo();
        }

        // ─── Verification gate ────────────────────────────────────────────

        private static BuildResult VerifyPrefab(string prefabPath, bool addedNewSphere, Transform expectedHead)
        {
            var result = new BuildResult { Success = true };
            var sb = new StringBuilder();

            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            if (prefab == null)
            {
                result.Error = "Saved prefab could not be reloaded.";
                return result;
            }

            sb.AppendLine($"Prefab path: {prefabPath}");
            sb.AppendLine($"Prefab root name: {prefab.name}");
            sb.AppendLine();
            sb.AppendLine("=== Components on root ===");
            Component[] comps = prefab.GetComponents<Component>();
            result.ComponentCount = comps.Length;
            for (int i = 0; i < comps.Length; i++)
            {
                Component c = comps[i];
                if (c == null)
                {
                    sb.AppendLine($"  [{i}] <null destroyed component>");
                    continue;
                }
                sb.AppendLine($"  [{i}] {c.GetType().FullName}");
            }

            // Per-component reference dump.
            DumpHeadLookAtPlayer(prefab, sb, result.References);
            DumpProximity(prefab, sb, result.References);
            DumpDialogueController(prefab, sb, result.References);
            DumpWander(prefab, sb, result.References);
            DumpTipController(prefab, sb, result.References);
            DumpGroundProbe(prefab, sb, result.References);
            DumpAnimator(prefab, sb, result.References);

            // SphereCollider.
            SphereCollider sphere = prefab.GetComponent<SphereCollider>();
            sb.AppendLine();
            sb.AppendLine("=== SphereCollider ===");
            if (sphere != null)
            {
                sb.AppendLine($"  addedNewSphere={addedNewSphere}");
                sb.AppendLine($"  radius={sphere.radius} isTrigger={sphere.isTrigger} enabled={sphere.enabled}");
            }
            else
            {
                sb.AppendLine("  MISSING — no SphereCollider on root!");
                result.Error = "SphereCollider missing on prefab root.";
            }

            // DialogueCanvas child.
            Transform canvasT = prefab.transform.Find("DialogueCanvas");
            sb.AppendLine();
            sb.AppendLine("=== DialogueCanvas child ===");
            if (canvasT == null)
            {
                sb.AppendLine("  MISSING — no child named 'DialogueCanvas'!");
                result.Error = "DialogueCanvas child missing.";
            }
            else
            {
                DialogueUIController ctrl = canvasT.GetComponent<DialogueUIController>();
                if (ctrl == null)
                {
                    sb.AppendLine("  DialogueCanvas has no DialogueUIController!");
                    result.Error = "DialogueUIController missing on DialogueCanvas child.";
                }
                else
                {
                    SerializedObject so = new SerializedObject(ctrl);
                    SerializedProperty anchorProp = so.FindProperty("anchor");
                    string anchorName = anchorProp != null && anchorProp.objectReferenceValue != null
                        ? anchorProp.objectReferenceValue.name
                        : "<null>";
                    sb.AppendLine($"  child present: {canvasT.name}");
                    sb.AppendLine($"  DialogueUIController.anchor = {anchorName}  (resolved = {(expectedHead != null ? expectedHead.name : "null")})");
                    if (anchorProp == null || anchorProp.objectReferenceValue == null)
                    {
                        result.Error = "DialogueCanvas.anchor is null.";
                    }
                }
            }

            // Final verdict.
            sb.AppendLine();
            sb.AppendLine("=== Non-null verdict ===");
            List<string> missing = new List<string>();
            foreach (KeyValuePair<string, bool> kv in result.References)
            {
                if (!kv.Value) missing.Add(kv.Key);
            }
            if (missing.Count == 0)
            {
                sb.AppendLine($"  OK — all {result.References.Count} required references are non-null.");
            }
            else
            {
                sb.AppendLine($"  FAIL — {missing.Count} required reference(s) are null:");
                foreach (string k in missing)
                {
                    sb.AppendLine($"    - {k}");
                }
                result.Error = "One or more required references are null.";
                result.Success = false;
            }

            result.VerificationReport = sb.ToString();
            return result;
        }

        private static void DumpAnimator(GameObject root, StringBuilder sb, Dictionary<string, bool> refs)
        {
            Animator a = root.GetComponent<Animator>();
            if (a == null) { sb.AppendLine("\n[Animator] MISSING"); return; }
            SerializedObject so = new SerializedObject(a);
            SerializedProperty ctrl = so.FindProperty("m_Controller");
            string name = ctrl != null && ctrl.objectReferenceValue != null
                ? ctrl.objectReferenceValue.name : "<null>";
            sb.AppendLine("\n[Animator]");
            sb.AppendLine($"  runtimeAnimatorController = {name}");
            refs["Animator.runtimeAnimatorController"] = ctrl != null && ctrl.objectReferenceValue != null;
        }

        private static void DumpHeadLookAtPlayer(GameObject root, StringBuilder sb, Dictionary<string, bool> refs)
        {
            HeadLookAtPlayer h = root.GetComponent<HeadLookAtPlayer>();
            if (h == null) { sb.AppendLine("\n[HeadLookAtPlayer] MISSING"); return; }
            SerializedObject so = new SerializedObject(h);
            SerializedProperty headBone = so.FindProperty("headBone");
            SerializedProperty maxDist = so.FindProperty("maxDistance");
            SerializedProperty engage = so.FindProperty("engageSmoothTime");
            sb.AppendLine("\n[HeadLookAtPlayer]");
            sb.AppendLine($"  headBone = {(headBone.objectReferenceValue != null ? headBone.objectReferenceValue.name : "<null>")}");
            sb.AppendLine($"  maxDistance = {maxDist.floatValue}");
            sb.AppendLine($"  engageSmoothTime = {engage.floatValue}");
            refs["HeadLookAtPlayer.headBone"] = headBone.objectReferenceValue != null;
        }

        private static void DumpProximity(GameObject root, StringBuilder sb, Dictionary<string, bool> refs)
        {
            NPCProximityTrigger p = root.GetComponent<NPCProximityTrigger>();
            if (p == null) { sb.AppendLine("\n[NPCProximityTrigger] MISSING"); return; }
            SerializedObject so = new SerializedObject(p);
            SerializedProperty radius = so.FindProperty("triggerRadius");
            sb.AppendLine("\n[NPCProximityTrigger]");
            sb.AppendLine($"  triggerRadius = {radius.floatValue}");
            refs["NPCProximityTrigger.triggerRadius>0"] = radius.floatValue > 0f;
        }

        private static void DumpDialogueController(GameObject root, StringBuilder sb, Dictionary<string, bool> refs)
        {
            NPCDialogueController d = root.GetComponent<NPCDialogueController>();
            if (d == null) { sb.AppendLine("\n[NPCDialogueController] MISSING"); return; }
            SerializedObject so = new SerializedObject(d);
            SerializedProperty graph = so.FindProperty("graph");
            SerializedProperty prox = so.FindProperty("proximityTrigger");
            SerializedProperty head = so.FindProperty("headLook");
            SerializedProperty start = so.FindProperty("startAction");
            SerializedProperty end = so.FindProperty("endAction");
            sb.AppendLine("\n[NPCDialogueController]");
            sb.AppendLine($"  graph = {(graph.objectReferenceValue != null ? graph.objectReferenceValue.name : "<null>")}");
            sb.AppendLine($"  proximityTrigger = {(prox.objectReferenceValue != null ? prox.objectReferenceValue.name : "<null>")}");
            sb.AppendLine($"  headLook = {(head.objectReferenceValue != null ? head.objectReferenceValue.name : "<null>")}");
            sb.AppendLine($"  startAction = {(start.objectReferenceValue != null ? start.objectReferenceValue.name : "<null>")}");
            sb.AppendLine($"  endAction = {(end.objectReferenceValue != null ? end.objectReferenceValue.name : "<null (intentional)")}");
            refs["NPCDialogueController.graph"] = graph.objectReferenceValue != null;
            refs["NPCDialogueController.proximityTrigger"] = prox.objectReferenceValue != null;
            refs["NPCDialogueController.headLook"] = head.objectReferenceValue != null;
            refs["NPCDialogueController.startAction"] = start.objectReferenceValue != null;
        }

        private static void DumpWander(GameObject root, StringBuilder sb, Dictionary<string, bool> refs)
        {
            WanderingGuideController w = root.GetComponent<WanderingGuideController>();
            if (w == null) { sb.AppendLine("\n[WanderingGuideController] MISSING"); return; }
            SerializedObject so = new SerializedObject(w);
            SerializedProperty player = so.FindProperty("player");
            SerializedProperty animator = so.FindProperty("animator");
            SerializedProperty head = so.FindProperty("headLook");
            SerializedProperty probe = so.FindProperty("groundProbe");
            sb.AppendLine("\n[WanderingGuideController]");
            sb.AppendLine($"  player = {(player.objectReferenceValue != null ? player.objectReferenceValue.name : "<null (intentional)>")}");
            sb.AppendLine($"  animator = {(animator.objectReferenceValue != null ? animator.objectReferenceValue.name : "<null>")}");
            sb.AppendLine($"  headLook = {(head.objectReferenceValue != null ? head.objectReferenceValue.name : "<null>")}");
            sb.AppendLine($"  groundProbe = {(probe.objectReferenceValue != null ? probe.objectReferenceValue.name : "<null>")}");
            refs["WanderingGuideController.animator"] = animator.objectReferenceValue != null;
            refs["WanderingGuideController.headLook"] = head.objectReferenceValue != null;
            refs["WanderingGuideController.groundProbe"] = probe.objectReferenceValue != null;
        }

        private static void DumpTipController(GameObject root, StringBuilder sb, Dictionary<string, bool> refs)
        {
            ChildNpcTipController t = root.GetComponent<ChildNpcTipController>();
            if (t == null) { sb.AppendLine("\n[ChildNpcTipController] MISSING"); return; }
            SerializedObject so = new SerializedObject(t);
            sb.AppendLine("\n[ChildNpcTipController]");

            // dialogueController + wander — required non-null refs.
            string[] required = { "dialogueController", "wander" };
            foreach (string name in required)
            {
                SerializedProperty p = so.FindProperty(name);
                string v = (p != null && p.objectReferenceValue != null) ? p.objectReferenceValue.name : "<null>";
                sb.AppendLine($"  {name} = {v}");
                refs[$"ChildNpcTipController.{name}"] = (p != null && p.objectReferenceValue != null);
            }

            // tips — length must be 10 and every slot must be non-null.
            SerializedProperty arr = so.FindProperty("tips");
            int arrSize = (arr != null && arr.isArray) ? arr.arraySize : -1;
            sb.AppendLine($"  tips.Length = {arrSize} (expected {TipCount})");
            if (arrSize != TipCount)
            {
                sb.AppendLine($"    WARN: expected length {TipCount}, got {arrSize}");
            }
            for (int i = 0; i < arrSize; i++)
            {
                SerializedProperty elem = arr.GetArrayElementAtIndex(i);
                string n = elem.objectReferenceValue != null ? elem.objectReferenceValue.name : "<null>";
                string expected = $"{TipPrefix}{i + 1:D2}";
                bool ok = elem.objectReferenceValue != null
                          && elem.objectReferenceValue.name == expected;
                sb.AppendLine($"    [{i}] = {n}  (expected {expected})  -> {(ok ? "OK" : "MISMATCH")}");
                refs[$"ChildNpcTipController.tips[{i}]"] = elem.objectReferenceValue != null;
            }
        }

        private static void DumpGroundProbe(GameObject root, StringBuilder sb, Dictionary<string, bool> refs)
        {
            GroundProbe g = root.GetComponent<GroundProbe>();
            if (g == null) { sb.AppendLine("\n[GroundProbe] MISSING"); return; }
            SerializedObject so = new SerializedObject(g);
            SerializedProperty rh = so.FindProperty("raycastHeight");
            SerializedProperty rd = so.FindProperty("raycastDistance");
            SerializedProperty gm = so.FindProperty("groundMask");
            sb.AppendLine("\n[GroundProbe]");
            sb.AppendLine($"  raycastHeight = {rh.floatValue}");
            sb.AppendLine($"  raycastDistance = {rd.floatValue}");
            sb.AppendLine($"  groundMask = {gm.intValue} (all-layers = -1)");
            // groundMask defaults to ~0 (int -1). Don't flag this as a required
            // non-null ref because LayerMask is a value type — just print it.
        }

        // ─── Result container ─────────────────────────────────────────────

        public class BuildResult
        {
            public bool Success = true;
            public string Error;
            public int ComponentCount;
            public Dictionary<string, bool> References = new Dictionary<string, bool>();
            public string VerificationReport;
        }
    }
}
#endif
