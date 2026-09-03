// Wave 1 / Todo 1 — ChildNpc FBX import + Humanoid avatar configuration.
// MenuItem: AR_Grind_mill/ChildNpc/Import Model
// Idempotent: re-running with the same source files produces the same import state.
//
// Strategy:
//   1. Ensure folders.
//   2. Copy FBX + textures into place (extract from ~/Downloads/textures.zip if not yet present).
//   3. Configure ModelImporter: Humanoid + CreateFromThisModel, optimizeGameObjects=true,
//      importAnimatedCustomProperties=true, ImportStandard materials (External/Local),
//      animation import + Optimal compression.
//   4. Try Humanoid avatar creation; on failure, fall back to Generic.
//   5. Two-pass scale calibration. We instantiate the model in a fresh scene and read the
//      SkinnedMeshRenderer.bounds.size.y (world). Pass 1 uses a probe scale; pass 2 derives
//      the precise globalScale = probe * target / measured. Target: [1.0, 1.2] m.
//   6. Bind textures to materials by filename heuristics (MTL refs include a 'male char 02\\'
//      prefix that Unity cannot resolve, so we bind explicitly).
//   7. Write evidence to .omo/evidence/task-1-child-npc-guide/import-result.txt.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using ModelImporter = UnityEditor.ModelImporter;
using ModelImporterAnimationType = UnityEditor.ModelImporterAnimationType;
using ModelImporterAvatarSetup = UnityEditor.ModelImporterAvatarSetup;
using ModelImporterMaterialImportMode = UnityEditor.ModelImporterMaterialImportMode;
using ModelImporterMaterialLocation = UnityEditor.ModelImporterMaterialLocation;
using ModelImporterMaterialSearch = UnityEditor.ModelImporterMaterialSearch;
using ModelImporterAnimationCompression = UnityEditor.ModelImporterAnimationCompression;

namespace AR_Grind_mill.Characters.Editor
{
    public static class ImportChildNpcModel
    {
        // ── Source paths ────────────────────────────────────────────────
        private const string SourceFbxName = "young+boy+character+riigged.fbx";
        private const string SourceTexturesZip = "textures.zip";
        private const string DownloadRoot = "/home/dptphat/Downloads";
        private const string TempTexturesDir = "/tmp/child-npc-textures/textures";

        // ── Destination paths ───────────────────────────────────────────
        private const string DestRoot = "Assets/Characters/ChildNpc";
        private const string DestModel = DestRoot + "/Model";
        private const string DestMaterials = DestRoot + "/Materials";
        private const string DestTextures = DestRoot + "/Textures";
        private const string DestAnimations = DestRoot + "/Animations";
        private const string DestFbxPath = DestModel + "/" + SourceFbxName;

        // ── Bounds target (child scale) ─────────────────────────────────
        private const float BoundsMin = 1.0f;
        private const float BoundsMax = 1.2f;
        private const float BoundsTarget = (BoundsMin + BoundsMax) * 0.5f; // 1.1 m

        // Two-pass scale calibration:
        //   pass 1: import with a probe scale to learn the FBX's intrinsic scale factor;
        //   pass 2: derive the correct globalScale.
        private const float ProbeGlobalScale = 0.01f;

        // ── Evidence log path ───────────────────────────────────────────
        private const string EvidenceRel = ".omo/evidence/task-1-child-npc-guide/import-result.txt";

        [MenuItem("AR_Grind_mill/ChildNpc/Import Model")]
        public static void ImportAll()
        {
            Debug.Log("[ChildNpcImport] Starting ChildNpc import...");

            AssetDatabase.StartAssetEditing();
            try
            {
                EnsureFolders();
                CopyFbxIfMissing();
                ExtractAndCopyTextures();
            }
            finally
            {
                AssetDatabase.StopAssetEditing();
                AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
            }

            // Step 1: configure importer (Humanoid first, fall back to Generic).
            var (finalAnim, humanNote, settings, globalScale, scaleAdjusted) = ConfigureAndImportWithFallback();

            // Step 2: bind textures to materials (filename heuristic).
            BindTexturesToMaterials();

            // Step 2b: Unity's External material location creates .mat files in
            // Model/Materials/. The plan expects them at Materials/*.mat; promote them.
            PromoteMaterialsToTopLevel();

            // Step 3: re-measure via scene instantiation (authoritative bounds).
            float finalBoundsY; int finalMatCount;
            using (var probe = new SceneProbe())
            {
                finalBoundsY = probe.MeasureLargestY(DestFbxPath);
                finalMatCount = probe.CountUniqueMaterials(DestFbxPath);
            }

            WriteEvidence(finalAnim, humanNote, settings, finalBoundsY, finalMatCount, globalScale, scaleAdjusted);
            Debug.Log($"[ChildNpcImport] AnimationType={AnimTypeLetter(finalAnim)}; boundsHeight={finalBoundsY:F3}m; materialCount={finalMatCount}");
        }

        // Public entrypoint for batch-mode `-executeMethod`
        public static void ImportAllBatch()
        {
            try
            {
                ImportAll();
            }
            catch (Exception ex)
            {
                Debug.LogError($"[ChildNpcImport] BATCH FAILED: {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}");
                EditorApplication.Exit(1);
                return;
            }
            EditorApplication.Exit(0);
        }

        // ─────────────────────────────────────────────────────────────────
        // Folders
        // ─────────────────────────────────────────────────────────────────
        private static void EnsureFolders()
        {
            EnsureFolder("Assets/Characters");
            EnsureFolder(DestRoot);
            EnsureFolder(DestModel);
            EnsureFolder(DestMaterials);
            EnsureFolder(DestTextures);
            EnsureFolder(DestAnimations);
        }

        private static void EnsureFolder(string assetPath)
        {
            if (AssetDatabase.IsValidFolder(assetPath)) return;
            var parent = Path.GetDirectoryName(assetPath).Replace('\\', '/');
            var leaf = Path.GetFileName(assetPath);
            if (!string.IsNullOrEmpty(parent) && !AssetDatabase.IsValidFolder(parent)) EnsureFolder(parent);
            AssetDatabase.CreateFolder(parent, leaf);
        }

        // ─────────────────────────────────────────────────────────────────
        // Source copies
        // ─────────────────────────────────────────────────────────────────
        private static void CopyFbxIfMissing()
        {
            var src = Path.Combine(DownloadRoot, SourceFbxName);
            if (!File.Exists(src))
                throw new FileNotFoundException($"Source FBX not found at {src}");

            Directory.CreateDirectory(Path.Combine(Application.dataPath, "..", DestModel));
            var dst = Path.GetFullPath(Path.Combine(Application.dataPath, "..", DestFbxPath));
            if (!File.Exists(dst))
            {
                File.Copy(src, dst, overwrite: false);
                Debug.Log($"[ChildNpcImport] Copied FBX: {src} -> {dst}");
            }
        }

        private static void ExtractAndCopyTextures()
        {
            if (!Directory.Exists(TempTexturesDir))
            {
                var zip = Path.Combine(DownloadRoot, SourceTexturesZip);
                if (!File.Exists(zip))
                    throw new FileNotFoundException($"Textures zip not found at {zip}");
                Directory.CreateDirectory("/tmp/child-npc-textures");
                var psi = new System.Diagnostics.ProcessStartInfo("unzip",
                    $"-o {zip} -d /tmp/child-npc-textures")
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                };
                using var p = System.Diagnostics.Process.Start(psi);
                p.WaitForExit();
                if (p.ExitCode != 0)
                    throw new Exception("unzip failed: " + p.StandardError.ReadToEnd());
            }

            var destDir = Path.GetFullPath(Path.Combine(Application.dataPath, "..", DestTextures));
            Directory.CreateDirectory(destDir);

            int copied = 0;
            foreach (var srcPath in Directory.GetFiles(TempTexturesDir))
            {
                var fname = Path.GetFileName(srcPath);
                var dst = Path.Combine(destDir, fname);
                if (!File.Exists(dst))
                {
                    File.Copy(srcPath, dst, overwrite: false);
                    copied++;
                }
            }
            Debug.Log($"[ChildNpcImport] Copied {copied} new texture files into {DestTextures}");
        }

        // ─────────────────────────────────────────────────────────────────
        // Importer configuration
        // ─────────────────────────────────────────────────────────────────
        private class ImportSettings
        {
            public ModelImporterAnimationType AnimationType;
            public ModelImporterAvatarSetup AvatarSetup;
            public bool OptimizeGameObjects = true;
            public bool ImportAnimatedCustomProperties = true;
            public ModelImporterMaterialImportMode MaterialImportMode = ModelImporterMaterialImportMode.ImportStandard;
            public ModelImporterMaterialLocation MaterialLocation = ModelImporterMaterialLocation.External;
            public ModelImporterMaterialSearch MaterialSearch = ModelImporterMaterialSearch.Local;
            public bool ImportAnimation = true;
            public ModelImporterAnimationCompression AnimationCompression = ModelImporterAnimationCompression.Optimal;
            public float GlobalScale = 1.0f;
            public bool UseFileScale = true;
        }

        private static ModelImporter GetImporter()
        {
            var imp = AssetImporter.GetAtPath(DestFbxPath) as ModelImporter;
            if (imp == null) throw new Exception($"No ModelImporter at {DestFbxPath}");
            return imp;
        }

        private static void ApplySettings(ModelImporter imp, ImportSettings s)
        {
            imp.animationType = s.AnimationType;
            imp.avatarSetup = s.AvatarSetup;
            imp.optimizeGameObjects = s.OptimizeGameObjects;
            imp.importAnimatedCustomProperties = s.ImportAnimatedCustomProperties;
            imp.materialImportMode = s.MaterialImportMode;
            imp.materialLocation = s.MaterialLocation;
            imp.materialSearch = s.MaterialSearch;
            imp.importAnimation = s.ImportAnimation;
            imp.animationCompression = s.AnimationCompression;
            imp.globalScale = s.GlobalScale;
            imp.useFileScale = s.UseFileScale;
            imp.useFileUnits = true;
            imp.importBlendShapes = true;
            imp.importVisibility = true;
        }

        private static (ModelImporterAnimationType finalAnim, string humanNote, ImportSettings settings, float globalScale, bool scaleAdjusted)
            ConfigureAndImportWithFallback()
        {
            var settings = new ImportSettings();
            string humanNote = "Humanoid configured";

            // 1st attempt: Humanoid
            settings.AnimationType = ModelImporterAnimationType.Human;
            settings.AvatarSetup = ModelImporterAvatarSetup.CreateFromThisModel;
            try
            {
                ApplyAndReimport(settings);
            }
            catch (Exception ex)
            {
                humanNote = $"Humanoid avatar failed: {ex.GetType().Name}: {ex.Message}";
                Debug.LogWarning($"[ModelImport] {humanNote}; falling back to Generic");
                settings.AnimationType = ModelImporterAnimationType.Generic;
                settings.AvatarSetup = ModelImporterAvatarSetup.NoAvatar;
                ApplyAndReimport(settings);
            }

            // If Humanoid was requested but avatar didn't stick, drop to Generic.
            var imp = GetImporter();
            if (settings.AnimationType == ModelImporterAnimationType.Human && imp.avatarSetup == ModelImporterAvatarSetup.NoAvatar)
            {
                humanNote = "Humanoid avatar setup did not stick after reimport; falling back to Generic";
                Debug.LogWarning($"[ModelImport] {humanNote}");
                settings.AnimationType = ModelImporterAnimationType.Generic;
                settings.AvatarSetup = ModelImporterAvatarSetup.NoAvatar;
                ApplyAndReimport(settings);
            }

            // Two-pass scale calibration using scene-instantiated bounds.
            bool scaleAdjusted = false;
            float finalGlobalScale = 1.0f;
            using (var probe = new SceneProbe())
            {
                // Pass 1: import with probe scale; measure.
                settings.GlobalScale = ProbeGlobalScale;
                settings.UseFileScale = false;
                ApplyAndReimport(settings);
                float probeBoundsY = probe.MeasureLargestY(DestFbxPath);
                Debug.Log($"[ModelImport] probe globalScale={ProbeGlobalScale:F4} -> boundsY={probeBoundsY:F3}m");

                if (probeBoundsY < BoundsMin || probeBoundsY > BoundsMax)
                {
                    var ratio = BoundsTarget / Mathf.Max(probeBoundsY, 0.0001f);
                    finalGlobalScale = ProbeGlobalScale * ratio;
                    settings.GlobalScale = finalGlobalScale;
                    ApplyAndReimport(settings);
                    scaleAdjusted = true;
                    float finalBounds = probe.MeasureLargestY(DestFbxPath);
                    Debug.Log($"[ModelImport] corrected globalScale={finalGlobalScale:F5} -> boundsY={finalBounds:F3}m");
                }
                else
                {
                    finalGlobalScale = ProbeGlobalScale;
                }
            }

            return (GetImporter().animationType, humanNote, settings, finalGlobalScale, scaleAdjusted);
        }

        private static void ApplyAndReimport(ImportSettings settings)
        {
            var imp = GetImporter();
            ApplySettings(imp, settings);
            imp.SaveAndReimport();
            // Force a second import to ensure the AssetDatabase sees the new state.
            AssetDatabase.ImportAsset(DestFbxPath, ImportAssetOptions.ForceUpdate | ImportAssetOptions.ImportRecursive);
        }

        // ─────────────────────────────────────────────────────────────────
        // Scene-instantiated measurement
        // ─────────────────────────────────────────────────────────────────
        // SkinnedMeshRenderer.bounds for an asset (not in scene) is computed using the
        // renderer's local transform hierarchy. The rig bone has scale 100, so the asset
        // "preview" bounds can read ~100x larger than the actual world bounds. To get the
        // authoritative world bounds, we instantiate the model in a temporary scene.
        private sealed class SceneProbe : IDisposable
        {
            private Scene _scene;
            private GameObject _root;
            private bool _initialized;

            public SceneProbe()
            {
                _scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
                _initialized = true;
            }

            public void Dispose()
            {
                if (!_initialized) return;
                if (_root != null) UnityEngine.Object.DestroyImmediate(_root);
                if (_scene.IsValid()) EditorSceneManager.CloseScene(_scene, removeScene: true);
                _initialized = false;
            }

            private GameObject Instantiate(string assetPath)
            {
                var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
                if (prefab == null) throw new Exception($"Failed to load {assetPath}");
                _root = UnityEngine.Object.Instantiate(prefab);
                _root.transform.position = Vector3.zero;
                _root.transform.rotation = Quaternion.identity;
                _root.transform.localScale = Vector3.one;
                SceneManager.MoveGameObjectToScene(_root, _scene);
                return _root;
            }

            public float MeasureLargestY(string assetPath)
            {
                Dispose(); // ensure clean state
                _initialized = true;
                _scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
                var go = Instantiate(assetPath);

                var smr = go.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
                if (smr == null || smr.Length == 0)
                    throw new Exception("No SkinnedMeshRenderer found in FBX hierarchy");

                float bestY = 0f;
                foreach (var r in smr)
                {
                    var sz = r.bounds.size;
                    if (sz.y > bestY) bestY = sz.y;
                }
                return bestY;
            }

            public int CountUniqueMaterials(string assetPath)
            {
                Dispose();
                _initialized = true;
                _scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
                var go = Instantiate(assetPath);
                var smr = go.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
                var seen = new HashSet<Material>();
                foreach (var r in smr)
                {
                    if (r.sharedMaterials == null) continue;
                    foreach (var m in r.sharedMaterials) if (m != null) seen.Add(m);
                }
                return seen.Count;
            }
        }

        // ─────────────────────────────────────────────────────────────────
        // Material → texture binding
        // ─────────────────────────────────────────────────────────────────
        // ImportStandard + InPlace creates .mat files in the FBX folder named after the
        // diffuse texture that Unity auto-resolved (e.g. 'Ga_Eyelash_diffuse.mat'). The
        // material slot names from the MTL (e.g. 'Ga_Eyelash') are kept inside the .mat.
        // We re-bind normal/roughness/etc. textures by matching the diffuse texture's stem.
        private static void BindTexturesToMaterials()
        {
            var texDir = Path.GetFullPath(Path.Combine(Application.dataPath, "..", DestTextures));
            if (!Directory.Exists(texDir)) return;

            var textures = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var tp in Directory.GetFiles(texDir))
            {
                var ext = Path.GetExtension(tp).ToLowerInvariant();
                if (ext != ".png" && ext != ".jpg" && ext != ".jpeg") continue;
                var fname = Path.GetFileName(tp);
                var assetPath = DestTextures + "/" + fname;
                textures[fname] = assetPath;
            }

            var matGuids = AssetDatabase.FindAssets("t:Material", new[] { DestRoot });
            int bound = 0;
            foreach (var g in matGuids)
            {
                var matPath = AssetDatabase.GUIDToAssetPath(g);
                var mat = AssetDatabase.LoadAssetAtPath<Material>(matPath);
                if (mat == null) continue;

                var matFileStem = Path.GetFileNameWithoutExtension(matPath);
                string stem = matFileStem;
                foreach (var suf in new[] { "_diffuse", "_basecolor", "_albedo", "_normal", "_bump",
                                            "_roughness", "_metallic", "_specular", "_ao", "_opacity",
                                            "_height", "_emission", "_emissive" })
                {
                    if (stem.EndsWith(suf, StringComparison.OrdinalIgnoreCase))
                    {
                        stem = stem.Substring(0, stem.Length - suf.Length);
                        break;
                    }
                }

                var matches = textures.Keys
                    .Where(k => k.StartsWith(stem + "_", StringComparison.OrdinalIgnoreCase)
                                || k.StartsWith(stem + ".", StringComparison.OrdinalIgnoreCase))
                    .ToList();

                bool changed = false;
                foreach (var tex in matches)
                {
                    var assetPath = textures[tex];
                    var texObj = AssetDatabase.LoadAssetAtPath<Texture2D>(assetPath);
                    if (texObj == null) continue;
                    var lower = tex.ToLowerInvariant();

                    if (lower.Contains("normal") || lower.EndsWith("_bump.jpg") || lower.EndsWith("_bump.png"))
                    {
                        if (mat.HasProperty("_BumpMap")) { mat.SetTexture("_BumpMap", texObj); changed = true; }
                    }
                    else if (lower.Contains("diffuse") || lower.Contains("basecolor") || lower.Contains("albedo"))
                    {
                        if (mat.HasProperty("_BaseMap") && mat.GetTexture("_BaseMap") == null)
                        { mat.SetTexture("_BaseMap", texObj); changed = true; }
                    }
                    else if (lower.Contains("metallic"))
                    {
                        if (mat.HasProperty("_MetallicGlossMap")) { mat.SetTexture("_MetallicGlossMap", texObj); mat.SetFloat("_Metallic", 1f); changed = true; }
                    }
                    else if (lower.Contains("roughness") || lower.Contains("smoothness"))
                    {
                        if (mat.HasProperty("_SpecGlossMap")) { mat.SetTexture("_SpecGlossMap", texObj); changed = true; }
                    }
                    else if (lower.Contains("specular"))
                    {
                        if (mat.HasProperty("_SpecGlossMap")) { mat.SetTexture("_SpecGlossMap", texObj); changed = true; }
                    }
                    else if (lower.Contains("_ao") || lower.Contains("occlusion"))
                    {
                        if (mat.HasProperty("_OcclusionMap")) { mat.SetTexture("_OcclusionMap", texObj); changed = true; }
                    }
                    else if (lower.Contains("height") || lower.Contains("parallax"))
                    {
                        if (mat.HasProperty("_ParallaxMap")) { mat.SetTexture("_ParallaxMap", texObj); changed = true; }
                    }
                    else if (lower.Contains("emission") || lower.Contains("emissive"))
                    {
                        if (mat.HasProperty("_EmissionMap")) { mat.SetTexture("_EmissionMap", texObj); mat.EnableKeyword("_EMISSION"); changed = true; }
                    }
                }

                if (changed)
                {
                    EditorUtility.SetDirty(mat);
                    bound++;
                }
            }

            if (bound > 0) AssetDatabase.SaveAssets();
            Debug.Log($"[ChildNpcImport] Texture binding: {bound} materials updated");
        }

        // Copy .mat files from Model/Materials/ to top-level Materials/, regenerating
        // GUIDs so we don't collide with the FBX's sub-assets. Idempotent.
        private static void PromoteMaterialsToTopLevel()
        {
            var srcDir = Path.GetFullPath(Path.Combine(Application.dataPath, "..", DestModel + "/Materials"));
            var dstDir = Path.GetFullPath(Path.Combine(Application.dataPath, "..", DestMaterials));
            if (!Directory.Exists(srcDir)) return;
            Directory.CreateDirectory(dstDir);

            int promoted = 0;
            foreach (var srcMat in Directory.GetFiles(srcDir, "*.mat"))
            {
                var fname = Path.GetFileName(srcMat);
                var dstMat = Path.Combine(dstDir, fname);
                if (File.Exists(dstMat)) continue; // already promoted
                var srcMeta = srcMat + ".meta";
                var dstMeta = dstMat + ".meta";

                // Regenerate GUID: read source meta, write fresh meta with new GUID.
                string srcGuid = null;
                if (File.Exists(srcMeta))
                {
                    foreach (var line in File.ReadAllLines(srcMeta))
                    {
                        var m = System.Text.RegularExpressions.Regex.Match(line, @"^guid:\s*([0-9a-fA-F]{32})");
                        if (m.Success) { srcGuid = m.Groups[1].Value; break; }
                    }
                }
                File.Copy(srcMat, dstMat, overwrite: false);

                // Write fresh meta with a new GUID so both files can coexist.
                var newGuid = Guid.NewGuid().ToString("N");
                var meta = "fileFormatVersion: 2\n" +
                           $"guid: {newGuid}\n" +
                           "NativeFormatImporter:\n" +
                           "  externalObjects: {}\n" +
                           "  mainObjectFileID: 0\n" +
                           "  userData: \n" +
                           "  assetBundleName: \n" +
                           "  assetBundleVariant: \n";
                File.WriteAllText(dstMeta, meta);
                promoted++;
            }
            if (promoted > 0)
            {
                AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
                Debug.Log($"[ChildNpcImport] Promoted {promoted} materials to {DestMaterials}");
            }
        }

        // ─────────────────────────────────────────────────────────────────
        // Evidence
        // ─────────────────────────────────────────────────────────────────
        private static void WriteEvidence(
            ModelImporterAnimationType finalAnim,
            string humanAttemptNote,
            ImportSettings s,
            float boundsY,
            int matCount,
            float globalScale,
            bool scaleAdjusted)
        {
            var evDir = Path.GetFullPath(Path.Combine(Application.dataPath, "..", ".omo/evidence/task-1-child-npc-guide"));
            Directory.CreateDirectory(evDir);
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("ChildNpc import result — Wave 1 / Todo 1");
            sb.AppendLine($"Timestamp (UTC): {DateTime.UtcNow:yyyy-MM-ddTHH:mm:ssZ}");
            sb.AppendLine($"Source FBX: {DownloadRoot}/{SourceFbxName}");
            sb.AppendLine($"Dest FBX: {DestFbxPath}");
            sb.AppendLine();
            sb.AppendLine("ModelImporter settings:");
            sb.AppendLine($"  animationType = {finalAnim} ({(finalAnim == ModelImporterAnimationType.Human ? "Humanoid" : finalAnim == ModelImporterAnimationType.Generic ? "Generic" : finalAnim.ToString())})");
            sb.AppendLine($"  avatarSetup = {s.AvatarSetup}");
            sb.AppendLine($"  optimizeGameObjects = {s.OptimizeGameObjects}");
            sb.AppendLine($"  importAnimatedCustomProperties = {s.ImportAnimatedCustomProperties}");
            sb.AppendLine($"  materialImportMode = {s.MaterialImportMode}");
            sb.AppendLine($"  materialLocation = {s.MaterialLocation}");
            sb.AppendLine($"  materialSearch = {s.MaterialSearch}");
            sb.AppendLine($"  importAnimation = {s.ImportAnimation}");
            sb.AppendLine($"  animationCompression = {s.AnimationCompression}");
            sb.AppendLine($"  useFileScale = {s.UseFileScale}");
            sb.AppendLine($"  globalScale = {globalScale:F6}{(scaleAdjusted ? "  (calibrated from probe pass to fit bounds)" : "")}");
            sb.AppendLine();
            sb.AppendLine("Humanoid attempt:");
            sb.AppendLine($"  {humanAttemptNote}");
            sb.AppendLine();
            sb.AppendLine("Verification (scene-instantiated):");
            sb.AppendLine($"  SkinnedMeshRenderer.bounds.size.y = {boundsY:F4}m  (target [{BoundsMin:F2}, {BoundsMax:F2}])");
            sb.AppendLine($"  bounds.size.y in range = {(boundsY >= BoundsMin && boundsY <= BoundsMax ? "YES" : "NO")}");
            sb.AppendLine($"  materialCount = {matCount}  (expected 14 from MTL)");
            sb.AppendLine($"  scaleAdjusted = {scaleAdjusted}");
            sb.AppendLine();
            sb.AppendLine("Final status:");
            sb.AppendLine($"  AnimationType = {AnimTypeLetter(finalAnim)}");
            sb.AppendLine($"  boundsHeight = {boundsY:F4}m");
            sb.AppendLine($"  materialCount = {matCount}");
            var pass = (finalAnim == ModelImporterAnimationType.Human || finalAnim == ModelImporterAnimationType.Generic)
                       && boundsY >= BoundsMin && boundsY <= BoundsMax
                       && matCount >= 14;
            sb.AppendLine($"  VERDICT = {(pass ? "PASS" : "FAIL")}");

            var path = Path.Combine(evDir, "import-result.txt");
            File.WriteAllText(path, sb.ToString());
            Debug.Log($"[ChildNpcImport] Evidence written to {path}");
        }

        private static char AnimTypeLetter(ModelImporterAnimationType t)
        {
            if (t == ModelImporterAnimationType.Human) return 'H';
            if (t == ModelImporterAnimationType.Generic) return 'G';
            return '?';
        }
    }
}
