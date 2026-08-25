using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Khoa.Vegetation;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Khoa.Farming.Editor
{
    /// <summary>
    /// Builds deterministic Terrain tree plans from semantic scene zones.
    /// Decorative vegetation stays separate from the RicePlant gameplay loop.
    /// </summary>
    public static class VietnameseCountrysideVegetatorV2
    {
        private const string MainScenePath = "Assets/Scenes/Grind mill v1.0 Scene.unity";
        private const string PreviewReportPath = "Library/KhoaReports/VietnameseVegetationPreview.txt";
        private const int Seed = 19930821;
        private const float BaseSamplingDistance = 6f;
        private const float MaximumSpacingRadius = 12f;
        private const float MaximumSlope = 32f;
        private const float RoadWeightThreshold = 0.72f;

        private static readonly string[] GardenTokens =
        {
            "house", "stilthouse", "pigsty", "home"
        };

        private static readonly string[] StructuralTokens =
        {
            "house", "stilthouse", "pigsty", "bridge", "market", "brick",
            "farm_grid", "fieldwater", "farming_runtime", "sluice", "thresher",
            "drying", "shelter", "xr origin"
        };

        [MenuItem("Khoa/Vegetation/Preview Vietnamese Countryside Plan")]
        public static void PreviewInteractive()
        {
            string report = CreatePreviewReportForMainScene();
            Debug.Log(report);
            EditorUtility.DisplayDialog(
                "Vietnamese countryside vegetation",
                "Preview completed without changing TerrainData.\n\n" + GetShortSummary(report),
                "OK");
        }

        [MenuItem("Khoa/Vegetation/Apply Vietnamese Countryside Plan")]
        public static void ApplyInteractive()
        {
            VegetationPlan plan = BuildPlanForMainScene();
            if (!EditorUtility.DisplayDialog(
                    "Replace decorative Terrain trees?",
                    GetShortSummary(plan.Report) +
                    "\n\nThis replaces the current decorative TreeInstances on all four Terrains. " +
                    "RicePlant is never placed. Continue?",
                    "Apply plan",
                    "Cancel"))
            {
                return;
            }

            ApplyPlan(plan);
        }

        /// <summary>
        /// Batch entry point used by Unity CLI after a preview has been reviewed.
        /// </summary>
        public static void ApplyBatch()
        {
            VegetationPlan plan = BuildPlanForMainScene();
            ApplyPlan(plan);
        }

        /// <summary>
        /// Creates a report only. This method never writes TerrainData or saves the scene.
        /// </summary>
        public static string CreatePreviewReportForMainScene()
        {
            VegetationPlan plan = BuildPlanForMainScene();
            WritePreviewReport(plan.Report);
            return plan.Report;
        }

        private static VegetationPlan BuildPlanForMainScene()
        {
            Scene scene = OpenMainSceneSafely();
            Terrain[] terrains = FindTerrains(scene);
            if (terrains.Length == 0)
            {
                throw new InvalidOperationException("The main scene does not contain any Terrain objects.");
            }

            Array.Sort(terrains, CompareTerrains);
            Terrain mainTerrain = FindMasterTerrain(terrains);
            TreePrototype[] masterPrototypes = mainTerrain.terrainData.treePrototypes;
            PrototypePalette palette = PrototypePalette.Create(masterPrototypes);
            palette.ValidateRequiredFamilies();

            SceneSpatialContext spatialContext = SceneSpatialContext.Build(scene);
            PrototypeDimensions[] dimensions = MeasurePrototypeDimensions(masterPrototypes);
            var spacingIndex = new VegetationSpacingIndex(MaximumSpacingRadius);
            var terrainPlans = new List<TerrainPlan>(terrains.Length);
            var zoneCounts = CreateCounter<VegetationZone>();
            var speciesCounts = CreateCounter<VegetationSpecies>();
            int rejectedByWater = 0;
            int rejectedByStructure = 0;
            int rejectedByRoad = 0;
            int rejectedBySlope = 0;
            int rejectedBySpacing = 0;

            for (int terrainIndex = 0; terrainIndex < terrains.Length; terrainIndex++)
            {
                Terrain terrain = terrains[terrainIndex];
                TerrainData data = terrain.terrainData;
                Vector3 terrainPosition = terrain.transform.position;
                Vector3 terrainSize = data.size;
                var worldArea = new Rect(
                    terrainPosition.x,
                    terrainPosition.z,
                    terrainSize.x,
                    terrainSize.z);
                int terrainSeed = Seed ^ Mathf.RoundToInt(terrainPosition.x * 17f) ^
                                  Mathf.RoundToInt(terrainPosition.z * 31f);
                IReadOnlyList<Vector2> candidates = VegetationSpatialPlanner.GeneratePoissonPoints(
                    worldArea,
                    BaseSamplingDistance,
                    terrainSeed,
                    20);
                var random = new System.Random(terrainSeed);
                var instances = new List<TreeInstance>(candidates.Count / 2);
                int roadLayerIndex = FindRoadLayerIndex(data);
                float[,,] alphamaps = roadLayerIndex >= 0
                    ? data.GetAlphamaps(0, 0, data.alphamapResolution, data.alphamapResolution)
                    : null;

                for (int candidateIndex = 0; candidateIndex < candidates.Count; candidateIndex++)
                {
                    Vector2 point = candidates[candidateIndex];
                    float normalizedX = (point.x - terrainPosition.x) / terrainSize.x;
                    float normalizedZ = (point.y - terrainPosition.z) / terrainSize.z;
                    float worldY = terrain.SampleHeight(new Vector3(point.x, 0f, point.y)) + terrainPosition.y;

                    if (spatialContext.IsSubmerged(point, worldY))
                    {
                        rejectedByWater++;
                        continue;
                    }

                    if (data.GetSteepness(normalizedX, normalizedZ) > MaximumSlope)
                    {
                        rejectedBySlope++;
                        continue;
                    }

                    if (spatialContext.HardExclusions.Contains(point))
                    {
                        rejectedByStructure++;
                        continue;
                    }

                    if (IsRoad(alphamaps, data.alphamapResolution, roadLayerIndex, normalizedX, normalizedZ))
                    {
                        rejectedByRoad++;
                        continue;
                    }

                    VegetationZone zone = VegetationSpatialPlanner.ClassifyZone(
                        point,
                        spatialContext.GardenAreas,
                        spatialContext.WaterRects,
                        spatialContext.FieldAreas);
                    float densityNoise = Mathf.PerlinNoise(
                        (point.x + 4127f) * 0.0065f,
                        (point.y + 7819f) * 0.0065f);
                    float retentionProbability = VegetationSpatialPlanner.GetRetentionProbability(zone, densityNoise);
                    if (NextFloat(random) > retentionProbability)
                    {
                        continue;
                    }

                    float speciesSample = GetPatchSpeciesSample(point, random);
                    VegetationSpecies species = VegetationSpatialPlanner.SelectSpecies(zone, speciesSample);
                    if (!palette.TryChoosePrototype(species, random, out int prototypeIndex))
                    {
                        species = palette.ResolveFallback(species);
                        if (!palette.TryChoosePrototype(species, random, out prototypeIndex))
                        {
                            continue;
                        }
                    }

                    float spacing = VegetationSpatialPlanner.GetMinimumSpacing(species);
                    if (!spacingIndex.TryAdd(point, spacing))
                    {
                        rejectedBySpacing++;
                        continue;
                    }

                    Vector2 targetDimensions = VegetationSpatialPlanner.GetTargetDimensions(
                        species,
                        NextFloat(random));
                    PrototypeDimensions rawDimensions = dimensions[prototypeIndex];
                    float widthScale = Mathf.Clamp(
                        targetDimensions.x / rawDimensions.Width,
                        0.08f,
                        5f);
                    float heightScale = Mathf.Clamp(
                        targetDimensions.y / rawDimensions.Height,
                        0.08f,
                        5f);

                    instances.Add(new TreeInstance
                    {
                        position = new Vector3(normalizedX, 0f, normalizedZ),
                        prototypeIndex = prototypeIndex,
                        widthScale = widthScale,
                        heightScale = heightScale,
                        rotation = NextFloat(random) * Mathf.PI * 2f,
                        color = Color.white,
                        lightmapColor = Color.white
                    });
                    zoneCounts[zone]++;
                    speciesCounts[species]++;
                }

                terrainPlans.Add(new TerrainPlan(terrain, instances));
            }

            string report = BuildReport(
                terrainPlans,
                palette,
                zoneCounts,
                speciesCounts,
                rejectedByWater,
                rejectedByStructure,
                rejectedByRoad,
                rejectedBySlope,
                rejectedBySpacing);
            return new VegetationPlan(scene, masterPrototypes, terrainPlans, report);
        }

        private static void ApplyPlan(VegetationPlan plan)
        {
            foreach (TerrainPlan terrainPlan in plan.TerrainPlans)
            {
                Terrain terrain = terrainPlan.Terrain;
                TerrainData data = terrain.terrainData;
                Undo.RegisterCompleteObjectUndo(data, "Apply Vietnamese countryside vegetation");
                data.treePrototypes = plan.MasterPrototypes;
                data.SetTreeInstances(terrainPlan.Instances.ToArray(), snapToHeightmap: true);
                terrain.treeDistance = 650f;
                terrain.treeBillboardDistance = 55f;
                terrain.treeCrossFadeLength = 12f;
                terrain.treeMaximumFullLODCount = 150;
                terrain.Flush();
                EditorUtility.SetDirty(data);
                EditorUtility.SetDirty(terrain);
            }

            EditorSceneManager.MarkSceneDirty(plan.Scene);
            if (!EditorSceneManager.SaveScene(plan.Scene))
            {
                throw new InvalidOperationException("Unity could not save the vegetation changes to the main scene.");
            }

            AssetDatabase.SaveAssets();
            WritePreviewReport(plan.Report);
            Debug.Log(plan.Report + "\nVegetation plan applied successfully.");
        }

        private static Scene OpenMainSceneSafely()
        {
            Scene activeScene = SceneManager.GetActiveScene();
            if (activeScene.IsValid() && activeScene.path == MainScenePath)
            {
                return activeScene;
            }

            if (activeScene.IsValid() && activeScene.isDirty)
            {
                if (Application.isBatchMode)
                {
                    throw new InvalidOperationException(
                        $"Refusing to replace dirty scene '{activeScene.path}' in batch mode.");
                }

                if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                {
                    throw new OperationCanceledException("Vegetation generation was cancelled.");
                }
            }

            return EditorSceneManager.OpenScene(MainScenePath, OpenSceneMode.Single);
        }

        private static Terrain[] FindTerrains(Scene scene)
        {
            var terrains = new List<Terrain>();
            foreach (GameObject root in scene.GetRootGameObjects())
            {
                terrains.AddRange(root.GetComponentsInChildren<Terrain>(includeInactive: true));
            }

            return terrains.ToArray();
        }

        private static Terrain FindMasterTerrain(IReadOnlyList<Terrain> terrains)
        {
            for (int i = 0; i < terrains.Count; i++)
            {
                if (terrains[i].name == "Terrain")
                {
                    return terrains[i];
                }
            }

            return terrains[0];
        }

        private static int CompareTerrains(Terrain left, Terrain right)
        {
            int x = left.transform.position.x.CompareTo(right.transform.position.x);
            return x != 0 ? x : left.transform.position.z.CompareTo(right.transform.position.z);
        }

        private static int FindRoadLayerIndex(TerrainData data)
        {
            for (int i = 0; i < data.terrainLayers.Length; i++)
            {
                TerrainLayer layer = data.terrainLayers[i];
                if (layer == null)
                {
                    continue;
                }

                string descriptor = (layer.name + " " +
                    (layer.diffuseTexture != null ? layer.diffuseTexture.name : string.Empty)).ToLowerInvariant();
                if (descriptor.Contains("road") || descriptor.Contains("path") || descriptor.Contains("pebble"))
                {
                    return i;
                }
            }

            return -1;
        }

        private static bool IsRoad(
            float[,,] alphamaps,
            int resolution,
            int roadLayerIndex,
            float normalizedX,
            float normalizedZ)
        {
            if (alphamaps == null || roadLayerIndex < 0 || roadLayerIndex >= alphamaps.GetLength(2))
            {
                return false;
            }

            int x = Mathf.Clamp(Mathf.FloorToInt(normalizedX * (resolution - 1)), 0, resolution - 1);
            int z = Mathf.Clamp(Mathf.FloorToInt(normalizedZ * (resolution - 1)), 0, resolution - 1);
            return alphamaps[z, x, roadLayerIndex] >= RoadWeightThreshold;
        }

        private static PrototypeDimensions[] MeasurePrototypeDimensions(TreePrototype[] prototypes)
        {
            var dimensions = new PrototypeDimensions[prototypes.Length];
            Scene previewScene = EditorSceneManager.NewPreviewScene();
            try
            {
                for (int i = 0; i < prototypes.Length; i++)
                {
                    GameObject prefab = prototypes[i].prefab;
                    if (prefab == null)
                    {
                        dimensions[i] = PrototypeDimensions.Fallback;
                        continue;
                    }

                    var instance = PrefabUtility.InstantiatePrefab(prefab, previewScene) as GameObject;
                    if (instance == null)
                    {
                        dimensions[i] = PrototypeDimensions.Fallback;
                        continue;
                    }

                    dimensions[i] = MeasureRendererBounds(instance);
                    Object.DestroyImmediate(instance);
                }
            }
            finally
            {
                EditorSceneManager.ClosePreviewScene(previewScene);
            }

            return dimensions;
        }

        private static PrototypeDimensions MeasureRendererBounds(GameObject instance)
        {
            bool hasBounds = false;
            Bounds bounds = default;
            foreach (Renderer renderer in instance.GetComponentsInChildren<Renderer>(includeInactive: true))
            {
                if (!renderer.enabled)
                {
                    continue;
                }

                if (!hasBounds)
                {
                    bounds = renderer.bounds;
                    hasBounds = true;
                }
                else
                {
                    bounds.Encapsulate(renderer.bounds);
                }
            }

            if (!hasBounds)
            {
                return PrototypeDimensions.Fallback;
            }

            float width = Mathf.Max(bounds.size.x, bounds.size.z);
            float height = bounds.size.y;
            if (width < 0.05f || height < 0.05f)
            {
                return PrototypeDimensions.Fallback;
            }

            return new PrototypeDimensions(width, height);
        }

        private static Dictionary<T, int> CreateCounter<T>() where T : Enum
        {
            var result = new Dictionary<T, int>();
            foreach (T value in Enum.GetValues(typeof(T)))
            {
                result.Add(value, 0);
            }

            return result;
        }

        private static string BuildReport(
            IReadOnlyList<TerrainPlan> terrainPlans,
            PrototypePalette palette,
            IReadOnlyDictionary<VegetationZone, int> zoneCounts,
            IReadOnlyDictionary<VegetationSpecies, int> speciesCounts,
            int rejectedByWater,
            int rejectedByStructure,
            int rejectedByRoad,
            int rejectedBySlope,
            int rejectedBySpacing)
        {
            var builder = new StringBuilder();
            builder.AppendLine("=== Vietnamese Countryside Vegetation Preview ===");
            int total = 0;
            foreach (TerrainPlan terrainPlan in terrainPlans)
            {
                builder.AppendLine($"Terrain '{terrainPlan.Terrain.name}': {terrainPlan.Instances.Count} placements");
                total += terrainPlan.Instances.Count;
            }

            builder.AppendLine($"Total placements: {total}");
            builder.AppendLine("Rice/Vegetable terrain instances: 0");
            builder.AppendLine($"Prototype palette: {palette.Describe()}");
            builder.AppendLine("Zones:");
            foreach (KeyValuePair<VegetationZone, int> pair in zoneCounts)
            {
                builder.AppendLine($"  {pair.Key}: {pair.Value}");
            }

            builder.AppendLine("Species:");
            foreach (KeyValuePair<VegetationSpecies, int> pair in speciesCounts)
            {
                builder.AppendLine($"  {pair.Key}: {pair.Value}");
            }

            builder.AppendLine("Rejected candidates:");
            builder.AppendLine($"  submerged={rejectedByWater}, structure={rejectedByStructure}, road={rejectedByRoad}, slope={rejectedBySlope}, spacing={rejectedBySpacing}");
            builder.AppendLine("Sampling: deterministic Poisson-disc anchors, semantic zones and variable canopy spacing.");
            return builder.ToString();
        }

        private static string GetShortSummary(string report)
        {
            string[] lines = report.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var builder = new StringBuilder();
            for (int i = 0; i < lines.Length && i < 7; i++)
            {
                builder.AppendLine(lines[i]);
            }

            return builder.ToString().TrimEnd();
        }

        private static void WritePreviewReport(string report)
        {
            string absolutePath = Path.GetFullPath(Path.Combine(Application.dataPath, "..", PreviewReportPath));
            Directory.CreateDirectory(Path.GetDirectoryName(absolutePath));
            File.WriteAllText(absolutePath, report);
        }

        private static float NextFloat(System.Random random)
        {
            return (float)random.NextDouble();
        }

        private static float GetPatchSpeciesSample(Vector2 point, System.Random random)
        {
            // A shared value per 55 m patch creates recognizable groves. Mixing in
            // uniform samples keeps the whole map diverse and avoids Perlin's centre bias.
            const float patchSize = 55f;
            int patchX = Mathf.FloorToInt(point.x / patchSize);
            int patchZ = Mathf.FloorToInt(point.y / patchSize);
            float patchSample = Hash01(patchX, patchZ, Seed);
            if (NextFloat(random) < 0.60f)
            {
                return Mathf.Repeat(patchSample + (NextFloat(random) - 0.5f) * 0.12f, 1f);
            }

            return NextFloat(random);
        }

        private static float Hash01(int x, int y, int seed)
        {
            unchecked
            {
                uint hash = (uint)(x * 374761393) ^ (uint)(y * 668265263) ^ (uint)seed;
                hash = (hash ^ (hash >> 13)) * 1274126177u;
                hash ^= hash >> 16;
                return (hash & 0x00FFFFFFu) / 16777216f;
            }
        }

        private sealed class PrototypePalette
        {
            private readonly Dictionary<VegetationSpecies, List<int>> indicesBySpecies;

            private PrototypePalette(Dictionary<VegetationSpecies, List<int>> indicesBySpecies)
            {
                this.indicesBySpecies = indicesBySpecies;
            }

            public static PrototypePalette Create(IReadOnlyList<TreePrototype> prototypes)
            {
                var map = new Dictionary<VegetationSpecies, List<int>>();
                foreach (VegetationSpecies species in Enum.GetValues(typeof(VegetationSpecies)))
                {
                    map.Add(species, new List<int>());
                }

                for (int i = 0; i < prototypes.Count; i++)
                {
                    GameObject prefab = prototypes[i].prefab;
                    if (prefab != null &&
                        VegetationSpatialPlanner.TryClassifyPrototypeName(prefab.name, out VegetationSpecies species))
                    {
                        map[species].Add(i);
                    }
                }

                return new PrototypePalette(map);
            }

            public void ValidateRequiredFamilies()
            {
                foreach (VegetationSpecies species in Enum.GetValues(typeof(VegetationSpecies)))
                {
                    if (indicesBySpecies[species].Count == 0)
                    {
                        Debug.LogWarning($"No prototype is available for vegetation family '{species}'. A fallback will be used.");
                    }
                }

                if (indicesBySpecies[VegetationSpecies.Banana].Count == 0 ||
                    indicesBySpecies[VegetationSpecies.Bamboo].Count == 0 ||
                    indicesBySpecies[VegetationSpecies.Coconut].Count == 0)
                {
                    throw new InvalidOperationException(
                        "The main Terrain palette must contain banana, bamboo and coconut prototypes.");
                }
            }

            public bool TryChoosePrototype(VegetationSpecies species, System.Random random, out int prototypeIndex)
            {
                List<int> indices = indicesBySpecies[species];
                if (indices.Count == 0)
                {
                    prototypeIndex = -1;
                    return false;
                }

                prototypeIndex = indices[random.Next(indices.Count)];
                return true;
            }

            public VegetationSpecies ResolveFallback(VegetationSpecies preferred)
            {
                VegetationSpecies[] fallbackOrder = preferred switch
                {
                    VegetationSpecies.ArecaPalm => new[] { VegetationSpecies.Coconut, VegetationSpecies.PalmCluster, VegetationSpecies.Banana },
                    VegetationSpecies.PalmCluster => new[] { VegetationSpecies.Coconut, VegetationSpecies.ArecaPalm, VegetationSpecies.Melaleuca },
                    VegetationSpecies.Lemon => new[] { VegetationSpecies.Banana, VegetationSpecies.Melaleuca, VegetationSpecies.Bamboo },
                    _ => new[] { VegetationSpecies.Bamboo, VegetationSpecies.Banana, VegetationSpecies.Melaleuca }
                };

                for (int i = 0; i < fallbackOrder.Length; i++)
                {
                    if (indicesBySpecies[fallbackOrder[i]].Count > 0)
                    {
                        return fallbackOrder[i];
                    }
                }

                return preferred;
            }

            public string Describe()
            {
                var parts = new List<string>();
                foreach (KeyValuePair<VegetationSpecies, List<int>> pair in indicesBySpecies)
                {
                    parts.Add($"{pair.Key}={pair.Value.Count}");
                }

                return string.Join(", ", parts);
            }
        }

        private sealed class SceneSpatialContext
        {
            private SceneSpatialContext(
                SpatialRectIndex hardExclusions,
                Rect[] gardenAreas,
                Rect[] fieldAreas,
                WaterArea[] waters)
            {
                HardExclusions = hardExclusions;
                GardenAreas = gardenAreas;
                FieldAreas = fieldAreas;
                Waters = waters;
                WaterRects = new Rect[waters.Length];
                for (int i = 0; i < waters.Length; i++)
                {
                    WaterRects[i] = waters[i].Rect;
                }
            }

            public SpatialRectIndex HardExclusions { get; }
            public Rect[] GardenAreas { get; }
            public Rect[] FieldAreas { get; }
            public Rect[] WaterRects { get; }
            private WaterArea[] Waters { get; }

            public static SceneSpatialContext Build(Scene scene)
            {
                var exclusions = new SpatialRectIndex(32f);
                var gardens = new List<Rect>();
                var fields = new List<Rect>();
                var waters = new List<WaterArea>();

                foreach (GameObject root in scene.GetRootGameObjects())
                {
                    string rootName = root.name.ToLowerInvariant();
                    if (root.GetComponentInChildren<Terrain>(includeInactive: true) != null ||
                        rootName.Contains("light") || rootName.Contains("eventsystem"))
                    {
                        continue;
                    }

                    if (rootName.Contains("farm_grid"))
                    {
                        if (TryGetCombinedBounds(root, out Bounds farmBounds))
                        {
                            Rect fieldRect = ToRect(farmBounds);
                            fields.Add(fieldRect);
                            exclusions.Add(fieldRect, 3f);
                        }

                        continue;
                    }

                    foreach (Renderer renderer in root.GetComponentsInChildren<Renderer>(includeInactive: true))
                    {
                        if (!renderer.enabled)
                        {
                            continue;
                        }

                        string hierarchy = GetHierarchyDescriptor(renderer.transform);
                        if (hierarchy.Contains("fieldwater"))
                        {
                            fields.Add(ToRect(renderer.bounds));
                            continue;
                        }

                        if (hierarchy.Contains("waterplane"))
                        {
                            waters.Add(new WaterArea(ToRect(renderer.bounds), renderer.bounds.center.y));
                            continue;
                        }

                        AddSemanticBounds(hierarchy, renderer.bounds, gardens, exclusions);
                    }

                    foreach (Collider collider in root.GetComponentsInChildren<Collider>(includeInactive: true))
                    {
                        if (!collider.enabled)
                        {
                            continue;
                        }

                        string hierarchy = GetHierarchyDescriptor(collider.transform);
                        if (hierarchy.Contains("waterplane") || hierarchy.Contains("fieldwater"))
                        {
                            continue;
                        }

                        AddSemanticBounds(hierarchy, collider.bounds, gardens, exclusions);
                    }
                }

                return new SceneSpatialContext(
                    exclusions,
                    gardens.ToArray(),
                    fields.ToArray(),
                    waters.ToArray());
            }

            public bool IsSubmerged(Vector2 point, float terrainHeight)
            {
                for (int i = 0; i < Waters.Length; i++)
                {
                    WaterArea water = Waters[i];
                    if (water.Rect.Contains(point) && terrainHeight <= water.SurfaceY + 0.25f)
                    {
                        return true;
                    }
                }

                return false;
            }

            private static void AddSemanticBounds(
                string hierarchy,
                Bounds bounds,
                ICollection<Rect> gardens,
                SpatialRectIndex exclusions)
            {
                bool isGarden = ContainsAny(hierarchy, GardenTokens);
                bool isStructure = isGarden || ContainsAny(hierarchy, StructuralTokens);
                if (!isStructure)
                {
                    return;
                }

                Rect rect = ToRect(bounds);
                if (rect.width <= 0.01f || rect.height <= 0.01f)
                {
                    return;
                }

                if (isGarden)
                {
                    gardens.Add(rect);
                }

                float margin = hierarchy.Contains("xr origin") ? 5f : isGarden ? 2.5f : 2f;
                exclusions.Add(rect, margin);
            }

            private static string GetHierarchyDescriptor(Transform transform)
            {
                var builder = new StringBuilder();
                Transform current = transform;
                while (current != null)
                {
                    builder.Append(current.name.ToLowerInvariant()).Append('/');
                    current = current.parent;
                }

                return builder.ToString();
            }

            private static bool ContainsAny(string value, IReadOnlyList<string> tokens)
            {
                for (int i = 0; i < tokens.Count; i++)
                {
                    if (value.Contains(tokens[i]))
                    {
                        return true;
                    }
                }

                return false;
            }

            private static bool TryGetCombinedBounds(GameObject root, out Bounds bounds)
            {
                bool found = false;
                bounds = default;
                foreach (Renderer renderer in root.GetComponentsInChildren<Renderer>(includeInactive: true))
                {
                    if (!renderer.enabled)
                    {
                        continue;
                    }

                    if (!found)
                    {
                        bounds = renderer.bounds;
                        found = true;
                    }
                    else
                    {
                        bounds.Encapsulate(renderer.bounds);
                    }
                }

                foreach (Collider collider in root.GetComponentsInChildren<Collider>(includeInactive: true))
                {
                    if (!collider.enabled)
                    {
                        continue;
                    }

                    if (!found)
                    {
                        bounds = collider.bounds;
                        found = true;
                    }
                    else
                    {
                        bounds.Encapsulate(collider.bounds);
                    }
                }

                return found;
            }

            private static Rect ToRect(Bounds bounds)
            {
                return Rect.MinMaxRect(bounds.min.x, bounds.min.z, bounds.max.x, bounds.max.z);
            }
        }

        private sealed class SpatialRectIndex
        {
            private readonly float cellSize;
            private readonly Dictionary<Vector2Int, List<Rect>> cells = new();

            public SpatialRectIndex(float cellSize)
            {
                this.cellSize = cellSize;
            }

            public void Add(Rect rect, float margin)
            {
                Rect expanded = Rect.MinMaxRect(
                    rect.xMin - margin,
                    rect.yMin - margin,
                    rect.xMax + margin,
                    rect.yMax + margin);
                Vector2Int min = GetCell(new Vector2(expanded.xMin, expanded.yMin));
                Vector2Int max = GetCell(new Vector2(expanded.xMax, expanded.yMax));

                for (int y = min.y; y <= max.y; y++)
                {
                    for (int x = min.x; x <= max.x; x++)
                    {
                        var key = new Vector2Int(x, y);
                        if (!cells.TryGetValue(key, out List<Rect> rects))
                        {
                            rects = new List<Rect>();
                            cells.Add(key, rects);
                        }

                        rects.Add(expanded);
                    }
                }
            }

            public bool Contains(Vector2 point)
            {
                if (!cells.TryGetValue(GetCell(point), out List<Rect> rects))
                {
                    return false;
                }

                for (int i = 0; i < rects.Count; i++)
                {
                    if (rects[i].Contains(point))
                    {
                        return true;
                    }
                }

                return false;
            }

            private Vector2Int GetCell(Vector2 point)
            {
                return new Vector2Int(
                    Mathf.FloorToInt(point.x / cellSize),
                    Mathf.FloorToInt(point.y / cellSize));
            }
        }

        private readonly struct WaterArea
        {
            public WaterArea(Rect rect, float surfaceY)
            {
                Rect = rect;
                SurfaceY = surfaceY;
            }

            public Rect Rect { get; }
            public float SurfaceY { get; }
        }

        private readonly struct PrototypeDimensions
        {
            public static readonly PrototypeDimensions Fallback = new(4f, 6f);

            public PrototypeDimensions(float width, float height)
            {
                Width = width;
                Height = height;
            }

            public float Width { get; }
            public float Height { get; }
        }

        private sealed class TerrainPlan
        {
            public TerrainPlan(Terrain terrain, List<TreeInstance> instances)
            {
                Terrain = terrain;
                Instances = instances;
            }

            public Terrain Terrain { get; }
            public List<TreeInstance> Instances { get; }
        }

        private sealed class VegetationPlan
        {
            public VegetationPlan(
                Scene scene,
                TreePrototype[] masterPrototypes,
                List<TerrainPlan> terrainPlans,
                string report)
            {
                Scene = scene;
                MasterPrototypes = masterPrototypes;
                TerrainPlans = terrainPlans;
                Report = report;
            }

            public Scene Scene { get; }
            public TreePrototype[] MasterPrototypes { get; }
            public List<TerrainPlan> TerrainPlans { get; }
            public string Report { get; }
        }
    }
}
