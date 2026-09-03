// Wave 2 / Todo 2 — ChildNpc AnimatorController build.
// MenuItem: AR_Grind_mill/ChildNpc/Build Animator
// Idempotent: deletes + recreates the controller at the target path so every run
// produces the same deterministic result.
//
// Strategy:
//   1. Ensure Animations folder exists.
//   2. Force-import the FBX so animation data is fresh.
//   3. Discover motion clips (sub-assets of type Motion).
//   4. Delete any pre-existing controller, then CreateAnimatorControllerAtPath.
//   5. Add IsMoving + IsTalking Bool parameters.
//   6. Enable IK Pass on layer 0 (required by HeadLookAtPlayer.OnAnimatorIK at
//      Assets/Scripts/Dialogue/Runtime/HeadLookAtPlayer.cs:119-133).
//   7. Create Idle (default), Walk, Talk states. Bind first 3 clips if available;
//      otherwise leave .motion = null so the Animator still compiles.
//   8. Add Walk→Idle, AnyState→Walk, AnyState→Talk transitions. hasExitTime=false,
//      duration=0.15.
//   9. Save + verify by reloading. Write evidence.

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace AR_Grind_mill.Characters.Editor
{
    public static class BuildChildNpcAnimator
    {
        // ── Paths ──────────────────────────────────────────────────────
        private const string FbxPath = "Assets/KidsCharacterFree/Fbx/Boy0_Humanoid.fbx";
        private const string ClipsDir = "Assets/KidsCharacterFree/AnimationClips/Humanoid";
        // Controller lives next to the prefab; intentionally NOT under Assets/Characters/ChildNpc/
        // which is slated for removal.
        private const string ControllerDir = "Assets/Prefabs/NPCs";
        private const string ControllerPath = ControllerDir + "/ChildNpcAnimator.controller";
        private const string EvidenceRel = ".omo/evidence/task-2-child-npc-guide/animator-result.txt";

        // ── Parameter / state names ────────────────────────────────────
        private const string ParamIsMoving = "IsMoving";
        private const string ParamIsTalking = "IsTalking";
        private const string StateIdle = "Idle";
        private const string StateWalk = "Walk";
        private const string StateTalk = "Talk";

        // ── Transition timing ──────────────────────────────────────────
        private const float TransitionDuration = 0.15f;

        // Procedural sway fallback marker — referenced by Todo 4.
        // If the FBX supplies < 3 Motion clips, the states will have motion=null
        // and WanderingGuideController.LateUpdate (Todo 4) must provide sway/breath.
        private const string FallbackMarker = "procedural sway fallback required (Todo 4 / WanderingGuideController.LateUpdate)";

        [MenuItem("AR_Grind_mill/ChildNpc/Build Animator")]
        public static void BuildAll()
        {
            try
            {
                BuildInternal();
            }
            catch (Exception ex)
            {
                Debug.LogError($"[ChildNpcAnim] BUILD FAILED: {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}");
                throw;
            }
        }

        // Public entrypoint for batch-mode `-executeMethod`.
        public static void BuildAllBatch()
        {
            try
            {
                BuildInternal();
                EditorApplication.Exit(0);
            }
            catch (Exception ex)
            {
                Debug.LogError($"[ChildNpcAnim] BATCH FAILED: {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}");
                EditorApplication.Exit(1);
            }
        }

        // ─────────────────────────────────────────────────────────────────
        // Build
        // ─────────────────────────────────────────────────────────────────
        private static void BuildInternal()
        {
            Debug.Log("[ChildNpcAnim] Building ChildNpcAnimator...");

            EnsureFolder(ControllerDir);

            // Force-import the FBX so the model + humanoid avatar are fresh.
            AssetDatabase.ImportAsset(FbxPath, ImportAssetOptions.ForceUpdate);

            var allClips = LoadMotionClipsFromFolder(ClipsDir);
            Debug.Log($"[ChildNpcAnim] Found {allClips.Count} AnimationClip(s) in {ClipsDir}.");

            // Resolve clips by name (robust to reimport ordering).
            Motion idleClip = FindClipByName(allClips, "idle");
            Motion walkClip = FindClipByName(allClips, "walk");
            // No dedicated "talk" clip in the new asset — fall back to idle for
            // a stable pose while the DialogueCanvas UI carries the speech.
            Motion talkClip = FindClipByName(allClips, "talk") ?? idleClip;
            var resolved = new[] { idleClip, walkClip, talkClip };

            // Delete any pre-existing controller for full determinism.
            if (AssetDatabase.LoadAssetAtPath<AnimatorController>(ControllerPath) != null)
            {
                AssetDatabase.DeleteAsset(ControllerPath);
            }

            // Create fresh controller.
            var controller = AnimatorController.CreateAnimatorControllerAtPath(ControllerPath);
            if (controller == null)
            {
                throw new Exception($"CreateAnimatorControllerAtPath returned null for {ControllerPath}");
            }

            // Add parameters.
            controller.AddParameter(ParamIsMoving, AnimatorControllerParameterType.Bool);
            controller.AddParameter(ParamIsTalking, AnimatorControllerParameterType.Bool);

            // Enable IK Pass on layer 0 — required by HeadLookAtPlayer.OnAnimatorIK.
            // defaultWeight defaults to 0 on a fresh controller, which would disable
            // the layer at runtime; explicitly raise it to 1 so OnAnimatorIK fires.
            var layers = controller.layers;
            layers[0].name = "Base Layer";
            layers[0].iKPass = true;
            layers[0].defaultWeight = 1.0f;
            controller.layers = layers;

            var sm = controller.layers[0].stateMachine;

            // Create states (left-to-right layout for editor view).
            var idleState = sm.AddState(StateIdle, new Vector3(300f, 0f, 0f));
            var walkState = sm.AddState(StateWalk, new Vector3(560f, 0f, 0f));
            var talkState = sm.AddState(StateTalk, new Vector3(300f, 160f, 0f));

            // Bind resolved clips to Idle, Walk, Talk.
            var states = new[] { idleState, walkState, talkState };
            var stateNames = new[] { StateIdle, StateWalk, StateTalk };
            var usedClips = new List<string>();
            bool clipsMissing = false;
            for (int i = 0; i < states.Length; i++)
            {
                if (resolved[i] != null)
                {
                    states[i].motion = resolved[i];
                    usedClips.Add($"{stateNames[i]} <- {resolved[i].name}");
                }
                else
                {
                    states[i].motion = null;
                    clipsMissing = true;
                    Debug.LogWarning($"[ChildNpcAnim] No Motion clip available for state '{stateNames[i]}' — {FallbackMarker}.");
                }
            }

            // Default state = Idle.
            sm.defaultState = idleState;

            // Walk → Idle (condition: !IsMoving)
            var walkToIdle = walkState.AddTransition(idleState);
            walkToIdle.hasExitTime = false;
            walkToIdle.duration = TransitionDuration;
            walkToIdle.canTransitionToSelf = false;
            walkToIdle.AddCondition(AnimatorConditionMode.IfNot, 0f, ParamIsMoving);

            // Any State → Walk (condition: IsMoving)
            var anyToWalk = sm.AddAnyStateTransition(walkState);
            anyToWalk.hasExitTime = false;
            anyToWalk.duration = TransitionDuration;
            anyToWalk.canTransitionToSelf = false;
            anyToWalk.AddCondition(AnimatorConditionMode.If, 0f, ParamIsMoving);

            // Any State → Talk (condition: IsTalking)
            var anyToTalk = sm.AddAnyStateTransition(talkState);
            anyToTalk.hasExitTime = false;
            anyToTalk.duration = TransitionDuration;
            anyToTalk.canTransitionToSelf = false;
            anyToTalk.AddCondition(AnimatorConditionMode.If, 0f, ParamIsTalking);

            EditorUtility.SetDirty(controller);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            // Verify by reloading.
            var verify = AssetDatabase.LoadAssetAtPath<AnimatorController>(ControllerPath);
            if (verify == null)
            {
                throw new Exception($"Verify load returned null for {ControllerPath}");
            }

            WriteEvidence(verify, allClips.Count, usedClips, clipsMissing);
            Debug.Log($"[ChildNpcAnim] Built controller at {ControllerPath}: states=[{StateIdle},{StateWalk},{StateTalk}], params=[{ParamIsMoving},{ParamIsTalking}], ikPass={verify.layers[0].iKPass}, fallbackRequired={(clipsMissing ? "YES" : "NO")}");
        }

        // ─────────────────────────────────────────────────────────────────
        // Helpers
        // ─────────────────────────────────────────────────────────────────
        private static List<Motion> LoadMotionClipsFromFolder(string folder)
        {
            var result = new List<Motion>();
            var guids = AssetDatabase.FindAssets("t:AnimationClip", new[] { folder });
            if (guids == null) return result;
            foreach (var g in guids)
            {
                var p = AssetDatabase.GUIDToAssetPath(g);
                var clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(p);
                if (clip != null && !string.IsNullOrEmpty(clip.name))
                    result.Add(clip);
            }
            return result;
        }

        private static Motion FindClipByName(List<Motion> clips, string keyword)
        {
            if (clips == null || string.IsNullOrEmpty(keyword)) return null;
            foreach (var c in clips)
            {
                if (c == null) continue;
                if (c.name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                    return c;
            }
            return null;
        }

        private static void EnsureFolder(string assetPath)
        {
            if (AssetDatabase.IsValidFolder(assetPath)) return;
            var parent = Path.GetDirectoryName(assetPath).Replace('\\', '/');
            var leaf = Path.GetFileName(assetPath);
            if (!string.IsNullOrEmpty(parent) && !AssetDatabase.IsValidFolder(parent)) EnsureFolder(parent);
            AssetDatabase.CreateFolder(parent, leaf);
        }

        private static string DescribeTransition(AnimatorStateTransition t)
        {
            string dest;
            if (t.destinationState != null) dest = t.destinationState.name;
            else if (t.destinationStateMachine != null) dest = $"[sm]{t.destinationStateMachine.name}";
            else dest = "(null)";
            var cond = string.Join(", ", t.conditions.Select(c =>
                $"{c.parameter} " + (c.mode == AnimatorConditionMode.If ? "== true" :
                                      c.mode == AnimatorConditionMode.IfNot ? "== false" :
                                      c.mode.ToString())));
            return $"→ {dest} | hasExitTime={t.hasExitTime} duration={t.duration:F2} | [{cond}]";
        }

        // ─────────────────────────────────────────────────────────────────
        // Evidence
        // ─────────────────────────────────────────────────────────────────
        private static void WriteEvidence(AnimatorController c, int clipCount, List<string> usedClips, bool clipsMissing)
        {
            var evDir = Path.GetFullPath(Path.Combine(Application.dataPath, "..", ".omo/evidence/task-2-child-npc-guide"));
            Directory.CreateDirectory(evDir);
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("ChildNpc animator result — Wave 2 / Todo 2");
            sb.AppendLine($"Timestamp (UTC): {DateTime.UtcNow:yyyy-MM-ddTHH:mm:ssZ}");
            sb.AppendLine($"Controller path: {ControllerPath}");
            sb.AppendLine($"FBX source: {FbxPath}");
            sb.AppendLine();

            sb.AppendLine($"Parameters ({c.parameters.Length}):");
            foreach (var p in c.parameters)
                sb.AppendLine($"  - {p.name} : {p.type}");
            sb.AppendLine();

            sb.AppendLine($"Layers ({c.layers.Length}):");
            for (int i = 0; i < c.layers.Length; i++)
            {
                var l = c.layers[i];
                sb.AppendLine($"  [{i}] name='{l.name}'");
                sb.AppendLine($"      ikPass = {l.iKPass}");
                sb.AppendLine($"      blendingMode = {l.blendingMode}");
                sb.AppendLine($"      defaultWeight = {l.defaultWeight}");
                var sm = l.stateMachine;
                sb.AppendLine($"      stateMachine.defaultState = {(sm.defaultState != null ? sm.defaultState.name : "(null)")}");
                sb.AppendLine($"      states ({sm.states.Length}):");
                foreach (var cs in sm.states)
                {
                    var s = cs.state;
                    sb.AppendLine($"        - name={s.name}, motion={(s.motion != null ? s.motion.name : "(null)")}, speed={s.speed:F3}, cycleOffset={s.cycleOffset:F3}");
                }
                sb.AppendLine($"      anyStateTransitions ({sm.anyStateTransitions.Length}):");
                foreach (var t in sm.anyStateTransitions)
                    sb.AppendLine($"        - {DescribeTransition(t)}");
                foreach (var cs in sm.states)
                {
                    var tList = cs.state.transitions;
                    if (tList.Length > 0)
                    {
                        sb.AppendLine($"      {cs.state.name}.transitions ({tList.Length}):");
                        foreach (var t in tList)
                            sb.AppendLine($"        - {DescribeTransition(t)}");
                    }
                }
            }
            sb.AppendLine();

            sb.AppendLine($"AnimationClips discovered in {ClipsDir}: {clipCount}");
            if (usedClips.Count > 0)
            {
                sb.AppendLine("Clip assignments:");
                foreach (var u in usedClips) sb.AppendLine($"  {u}");
            }
            else
            {
                sb.AppendLine($"Clip assignments: NONE — {FallbackMarker}.");
            }
            if (clipsMissing)
            {
                sb.AppendLine($"Procedural fallback required: YES — {FallbackMarker}.");
            }
            sb.AppendLine();

            sb.AppendLine("Verification:");
            bool has3States = c.layers[0].stateMachine.states.Length == 3;
            bool hasIdle = c.layers[0].stateMachine.states.Any(cs => cs.state.name == StateIdle);
            bool hasWalk = c.layers[0].stateMachine.states.Any(cs => cs.state.name == StateWalk);
            bool hasTalk = c.layers[0].stateMachine.states.Any(cs => cs.state.name == StateTalk);
            bool hasIdleTalk = hasIdle && hasWalk && hasTalk;
            bool isIdleDefault = c.layers[0].stateMachine.defaultState != null && c.layers[0].stateMachine.defaultState.name == StateIdle;
            bool hasMoving = c.parameters.Any(p => p.name == ParamIsMoving && p.type == AnimatorControllerParameterType.Bool);
            bool hasTalking = c.parameters.Any(p => p.name == ParamIsTalking && p.type == AnimatorControllerParameterType.Bool);
            bool ikPassOk = c.layers[0].iKPass;
            bool layerActive = c.layers[0].defaultWeight > 0f;
            sb.AppendLine($"  3 states (got {c.layers[0].stateMachine.states.Length}): {(has3States ? "YES" : "NO")}");
            sb.AppendLine($"  States named Idle/Walk/Talk: {(hasIdleTalk ? "YES" : "NO")} (idle={hasIdle}, walk={hasWalk}, talk={hasTalk})");
            sb.AppendLine($"  Idle is defaultState: {(isIdleDefault ? "YES" : "NO")}");
            sb.AppendLine($"  IsMoving Bool param: {(hasMoving ? "YES" : "NO")}");
            sb.AppendLine($"  IsTalking Bool param: {(hasTalking ? "YES" : "NO")}");
            sb.AppendLine($"  Layer 0 IK Pass = true: {(ikPassOk ? "YES" : "NO")}");
            sb.AppendLine($"  Layer 0 defaultWeight > 0 (layer active at runtime): {(layerActive ? "YES" : "NO")} ({c.layers[0].defaultWeight})");
            bool pass = has3States && hasIdleTalk && isIdleDefault && hasMoving && hasTalking && ikPassOk && layerActive;
            sb.AppendLine($"  VERDICT = {(pass ? "PASS" : "FAIL")}");

            var outPath = Path.Combine(evDir, "animator-result.txt");
            File.WriteAllText(outPath, sb.ToString());
            Debug.Log($"[ChildNpcAnim] Evidence written to {outPath}");
        }
    }
}
