// SceneIntegrator_ChildNpc.cs
//
// Editor menu utility that drops a single instance of
// `Assets/Prefabs/NPCs/ChildNpc.prefab` into the main scene
// (`Assets/Scenes/Grind mill v1.0 Scene.unity`) 2 metres east of the
// existing `GrindMillStation` (namespace `Khoa.Farming`).
//
// The script is idempotent and explicit — NOT auto-run. Invoke from the
// editor menu:
//
//     AR_Grind_mill > ChildNpc > Integrate Into Main Scene
//
// …or from the Unity CLI:
//
//     unity run . -- \
//         -executeMethod AR_Grind_mill.Dialogue.EditorTools.SceneIntegrator_ChildNpc.RunIntegration
//
// It guarantees:
//   • The scene is opened (EditorSceneManager.OpenScene, Single mode).
//   • The prefab link is preserved (PrefabUtility.InstantiatePrefab — the
//     result is a real PrefabInstance, not a copy).
//   • The new GameObject is named `ChildNpc` and parented to the scene
//     root (no other NPC container is created or modified).
//   • MrSix / MrsFour instances, if present, are NOT touched.
//   • No other scene asset is opened, modified or saved.
//   • The local position is `grindMillStation.position + Vector3(2,0,0)`.
//     `GroundProbe.Awake` will snap Y to the terrain at runtime — this is
//     intentional per spec.
//   • A re-load + Find("ChildNpc") confirms persistence.

#if UNITY_EDITOR
using System;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using Khoa.Farming;

namespace AR_Grind_mill.Dialogue.EditorTools
{
    public static class SceneIntegrator_ChildNpc
    {
        // ─── Asset paths (single source of truth) ─────────────────────────
        public const string MainScenePath  = "Assets/Scenes/Grind mill v1.0 Scene.unity";
        public const string ChildNpcPrefab = "Assets/Prefabs/NPCs/ChildNpc.prefab";

        public const string InstanceName   = "ChildNpc";

        // 2 metres east of the grind mill.
        private static readonly Vector3 OffsetEast = new Vector3(2f, 0f, 0f);

        // ─── Menu entry point (idempotent, explicit) ──────────────────────
        [MenuItem("AR_Grind_mill/ChildNpc/Integrate Into Main Scene")]
        public static void IntegrateFromMenu()
        {
            IntegrationResult result = RunIntegration();
            if (result.Success)
            {
                Debug.Log(
                    $"[SceneIntegrator_ChildNpc] OK — instantiated '{InstanceName}' at " +
                    $"world position {result.WorldPosition} in '{MainScenePath}'. " +
                    $"PrefabInstance = {result.IsPrefabInstance}.");
            }
            else
            {
                Debug.LogError(
                    $"[SceneIntegrator_ChildNpc] FAILED — {result.Error}");
            }
        }

        // ─── CLI entry point ──────────────────────────────────────────────
        public static IntegrationResult RunIntegration()
        {
            var result = new IntegrationResult();
            var sb = new StringBuilder();

            try
            {
                // 1. Open the main scene in Single mode. Save & warn if the
                //    active scene has unsaved changes — do not silently drop
                //    designer work.
                if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                {
                    result.Error = "Aborted: user declined to save current scene.";
                    sb.AppendLine($"[ERROR] {result.Error}");
                    result.Log = sb.ToString();
                    return result;
                }

                Scene scene = EditorSceneManager.OpenScene(MainScenePath, OpenSceneMode.Single);
                result.ScenePath = scene.path;
                sb.AppendLine($"[SCENE] Opened: {scene.path} (name='{scene.name}', isLoaded={scene.isLoaded})");

                // 2. Locate the grind mill via FindObjectOfType. If null,
                //    log error and abort — no scene changes are written.
                GrindMillStation mill = UnityEngine.Object.FindObjectOfType<GrindMillStation>();
                if (mill == null)
                {
                    result.Error = "GrindMillStation not found in main scene — aborting.";
                    sb.AppendLine($"[ERROR] {result.Error}");
                    result.Log = sb.ToString();
                    return result;
                }
                Vector3 millPos = mill.transform.position;
                result.GrindMillPosition = millPos;
                sb.AppendLine($"[MILL] GrindMillStation found at {millPos} on '{mill.gameObject.name}'.");

                // 3. Idempotency guard: if a ChildNpc is already in the scene
                //    (sibling of MrSix / MrsFour if those exist), log and abort.
                GameObject existing = GameObject.Find(InstanceName);
                if (existing != null)
                {
                    result.Error =
                        $"A GameObject named '{InstanceName}' already exists at " +
                        $"{existing.transform.position} — not adding a duplicate.";
                    sb.AppendLine($"[ERROR] {result.Error}");
                    result.Log = sb.ToString();
                    return result;
                }

                // 4. Load the prefab from disk. Using PrefabUtility.InstantiatePrefab
                //    (not Object.Instantiate) preserves the prefab link → the result
                //    is a PrefabInstance, not a plain copy.
                GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(ChildNpcPrefab);
                if (prefab == null)
                {
                    result.Error = $"Prefab not found at {ChildNpcPrefab}.";
                    sb.AppendLine($"[ERROR] {result.Error}");
                    result.Log = sb.ToString();
                    return result;
                }
                sb.AppendLine($"[PREFAB] Loaded: {ChildNpcPrefab} (name='{prefab.name}').");

                GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                if (instance == null)
                {
                    result.Error = "PrefabUtility.InstantiatePrefab returned null.";
                    sb.AppendLine($"[ERROR] {result.Error}");
                    result.Log = sb.ToString();
                    return result;
                }

                // 5. Rename, un-parent to scene root, place east of mill.
                instance.name = InstanceName;
                instance.transform.SetParent(null, worldPositionStays: false);
                Vector3 targetWorld = millPos + OffsetEast;
                instance.transform.position = targetWorld;

                // 6. Confirm the instance is a real PrefabInstance (link to
                //    Assets/Prefabs/NPCs/ChildNpc.prefab preserved).
                bool isInstance = PrefabUtility.IsPartOfPrefabInstance(instance);
                PrefabInstanceStatus status = PrefabUtility.GetPrefabInstanceStatus(instance);
                result.IsPrefabInstance = isInstance;
                result.PrefabInstanceStatus = status.ToString();
                result.InstanceName = instance.name;
                result.WorldPosition = instance.transform.position;
                result.ParentName = instance.transform.parent != null
                    ? instance.transform.parent.name
                    : "<scene root>";
                sb.AppendLine(
                    $"[INSTANCE] name='{instance.name}' parent='{result.ParentName}' " +
                    $"worldPos={instance.transform.position} " +
                    $"isPrefabInstance={isInstance} status={status}.");

                // 7. Mark the scene dirty and save. SaveScene writes the
                //    whole scene file, including the new GameObject.
                EditorSceneManager.MarkSceneDirty(scene);
                bool saved = EditorSceneManager.SaveScene(scene);
                result.SaveSucceeded = saved;
                sb.AppendLine($"[SAVE] MarkSceneDirty → SaveScene(success={saved}).");
                if (!saved)
                {
                    result.Error = "EditorSceneManager.SaveScene returned false.";
                    sb.AppendLine($"[ERROR] {result.Error}");
                    result.Log = sb.ToString();
                    return result;
                }

                // 8. Verify by re-loading the scene from disk and looking up
                //    the GameObject by name. This is the persistence gate.
                Scene reload = EditorSceneManager.OpenScene(MainScenePath, OpenSceneMode.Single);
                GameObject verify = GameObject.Find(InstanceName);
                bool found = verify != null;
                result.ReloadConfirmed = found;
                sb.AppendLine(
                    $"[VERIFY] Re-loaded '{reload.path}'; " +
                    $"GameObject.Find(\"{InstanceName}\") → {(found ? "FOUND" : "MISSING")}.");
                if (!found)
                {
                    result.Error = "Re-load verification FAILED — ChildNpc not found after save.";
                    sb.AppendLine($"[ERROR] {result.Error}");
                    result.Log = sb.ToString();
                    return result;
                }

                // 9. Snapshot the on-disk file for the evidence report.
                result.FileModifiedUtc = File.GetLastWriteTimeUtc(MainScenePath).ToString("o");
                sb.AppendLine($"[FILE] LastWriteTimeUtc = {result.FileModifiedUtc}");

                result.Success = true;
                sb.AppendLine("[DONE] Integration succeeded.");
            }
            catch (Exception ex)
            {
                result.Error = $"Unhandled exception: {ex.GetType().Name}: {ex.Message}";
                sb.AppendLine($"[EXCEPTION] {ex}");
            }

            result.Log = sb.ToString();
            return result;
        }

        // ─── Result container ─────────────────────────────────────────────
        public class IntegrationResult
        {
            public bool   Success;
            public string Error;
            public string ScenePath;
            public string InstanceName;
            public Vector3 WorldPosition;
            public string ParentName;
            public Vector3 GrindMillPosition;
            public bool   IsPrefabInstance;
            public string PrefabInstanceStatus;
            public bool   SaveSucceeded;
            public bool   ReloadConfirmed;
            public string FileModifiedUtc;
            public string Log;
        }
    }
}
#endif