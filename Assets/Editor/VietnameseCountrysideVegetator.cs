using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;
using System.Collections.Generic;

public class VietnameseCountrysideVegetator
{
    // Prototype Indices matching the unified 52-tree palette
    private const int PROTO_VEGETABLE = 0;
    private static readonly int[] PROTO_MELALEUCA = { 1, 2, 3 }; // MelaleucaAlternifolia_A, M, Y (Tràm - Rất hiếm)
    private static readonly int[] PROTO_BAMBOO = { 4, 8, 9, 10, 11 }; // TreeBush1..5 (Tre làng)
    private static readonly int[] PROTO_BANANA = { 5, 6, 7 }; // BaTree1, 2, 3 (Chuối)
    // Prototype 12 is RicePlant -> EXCLUDED
    private static readonly int[] PROTO_COCONUT = { 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 }; // Coconut_Palm_Tree01..12_AFS
    private static readonly int[] PROTO_FRUIT = { 25, 26, 27, 28, 29, 30, 31, 32 }; // Lemon Tree 1..4 & w Fruits (Cây ăn trái / chanh)
    private static readonly int[] PROTO_PALM_OLD = { 33, 34, 35, 36, 37, 38, 39, 40, 41 }; // Palm_1_1..2_3
    private static readonly int[] PROTO_PALM_STYLED = { 42, 43, 44, 45, 46, 47, 48, 49, 50, 51 }; // Dual/Single/Trio Palm

    private struct ExclusionBox
    {
        public Bounds bounds;
        public string name;
        public float margin;

        public bool Contains(Vector3 pos)
        {
            Bounds expanded = bounds;
            expanded.Expand(new Vector3(margin * 2f, 20f, margin * 2f));
            return expanded.Contains(pos);
        }
    }

    [MenuItem("Tools/Generate Vietnamese Countryside Landscape")]
    public static void GenerateCountrysideLandscape()
    {
        string scenePath = "Assets/Scenes/Grind mill v1.0 Scene.unity";
        var scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);

        Debug.Log("Starting Organic Vietnamese Countryside Landscape Generation...");

        // 1. Tint Melaleuca Materials to green-tinted shades
        TintMelaleucaMaterials();

        // 2. Find all 4 Terrains
        Terrain[] terrains = Object.FindObjectsByType<Terrain>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        Terrain mainTerrain = null;
        foreach (var t in terrains)
        {
            if (t.name == "Terrain") mainTerrain = t;
        }

        if (mainTerrain == null || mainTerrain.terrainData.treePrototypes.Length < 52)
        {
            Debug.LogError("Main Terrain with 52 prototypes not found!");
            return;
        }

        TreePrototype[] masterPrototypes = mainTerrain.terrainData.treePrototypes;

        // 3. Build Exclusion Zones from scene landmarks (Only real buildings, player spawn, farm grid, animals)
        List<ExclusionBox> exclusions = new List<ExclusionBox>();
        GameObject[] roots = scene.GetRootGameObjects();

        foreach (var root in roots)
        {
            string rName = root.name.ToLower();
            if (rName.Contains("terrain") || rName.Contains("terain") || rName.Contains("light") || 
                rName.Contains("eventsystem") || rName.Contains("manager") || rName.Contains("waterplane"))
                continue; // Do NOT add WaterPlane bounding box as exclusion box!

            Bounds b = new Bounds(root.transform.position, Vector3.zero);
            bool hasBounds = false;

            foreach (var r in root.GetComponentsInChildren<Renderer>())
            {
                if (!r.enabled || r.gameObject.name.ToLower().Contains("water")) continue;
                if (!hasBounds) { b = r.bounds; hasBounds = true; }
                else b.Encapsulate(r.bounds);
            }
            foreach (var c in root.GetComponentsInChildren<Collider>())
            {
                if (!c.enabled) continue;
                if (!hasBounds) { b = c.bounds; hasBounds = true; }
                else b.Encapsulate(c.bounds);
            }

            if (hasBounds)
            {
                float margin = 3.5f;
                if (rName.Contains("xr") || rName.Contains("player")) margin = 6.0f;
                else if (rName.Contains("farm_grid") || rName.Contains("fieldwater")) margin = 6.0f;
                else if (rName.Contains("stilthouse") || rName.Contains("house")) margin = 4.5f;
                else if (rName.Contains("pigsty") || rName.Contains("cow") || rName.Contains("buffalo")) margin = 2.5f;
                else if (rName.Contains("bridge") || rName.Contains("market")) margin = 4.0f;
                else if (rName.Contains("table") || rName.Contains("kit") || rName.Contains("bo_ma")) margin = 3.0f;

                exclusions.Add(new ExclusionBox { bounds = b, name = root.name, margin = margin });
            }
        }

        // 4. Populate each terrain organically
        Random.InitState(19930821);

        foreach (var t in terrains)
        {
            TerrainData td = t.terrainData;
            Undo.RegisterCompleteObjectUndo(td, "Vietnamese Countryside Trees");

            td.treePrototypes = masterPrototypes;

            List<TreeInstance> newTrees = new List<TreeInstance>();
            Vector3 tPos = t.transform.position;
            Vector3 tSize = td.size;

            float[,,] alphamaps = td.GetAlphamaps(0, 0, td.alphamapResolution, td.alphamapResolution);
            int alphaRes = td.alphamapResolution;

            GenerateOrganicTreesForTerrain(t, td, tPos, tSize, alphamaps, alphaRes, exclusions, newTrees);

            td.SetTreeInstances(newTrees.ToArray(), true);
            t.treeDistance = 850f;
            t.treeBillboardDistance = 65f;
            t.treeCrossFadeLength = 15f;
            t.treeMaximumFullLODCount = 200;

            EditorUtility.SetDirty(td);
            Debug.Log($"Terrain '{t.name}': Successfully placed {newTrees.Count} organic countryside trees.");
        }

        EditorSceneManager.MarkSceneDirty(scene);
        EditorSceneManager.SaveScene(scene);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("=== ORGANIC VIETNAMESE COUNTRYSIDE VEGETATION COMPLETED SUCCESSFULLY ===");
    }

    public static void TintMelaleucaMaterials()
    {
        string mapsPath = "Assets/MyFolder/Prefabs/Rau2/Scene/Maps/Mat/";
        
        Color leafColor = new Color(0.70f, 0.92f, 0.68f, 1.0f);
        Material leaves01 = AssetDatabase.LoadAssetAtPath<Material>(mapsPath + "Leaves01.mat");
        if (leaves01 != null)
        {
            leaves01.SetColor("_BaseColor", leafColor);
            EditorUtility.SetDirty(leaves01);
        }

        Material leaves02 = AssetDatabase.LoadAssetAtPath<Material>(mapsPath + "Leaves02.mat");
        if (leaves02 != null)
        {
            leaves02.SetColor("_BaseColor", leafColor);
            EditorUtility.SetDirty(leaves02);
        }

        Color flowerColor = new Color(0.86f, 0.97f, 0.85f, 1.0f);
        Material flowers01 = AssetDatabase.LoadAssetAtPath<Material>(mapsPath + "Flowers01.mat");
        if (flowers01 != null)
        {
            flowers01.SetColor("_BaseColor", flowerColor);
            EditorUtility.SetDirty(flowers01);
        }
    }

    private static void GenerateOrganicTreesForTerrain(
        Terrain t, TerrainData td, Vector3 tPos, Vector3 tSize,
        float[,,] alphamaps, int alphaRes,
        List<ExclusionBox> exclusions,
        List<TreeInstance> treeList)
    {
        // Use irregular sampling step
        float baseStep = 6.5f;
        int stepsX = Mathf.FloorToInt(tSize.x / baseStep);
        int stepsZ = Mathf.FloorToInt(tSize.z / baseStep);

        for (int ix = 1; ix < stepsX - 1; ix++)
        {
            for (int iz = 1; iz < stepsZ - 1; iz++)
            {
                // High organic jittering so there are NO straight lines or visible grids
                float localX = (ix + Random.Range(-0.80f, 0.80f)) * baseStep;
                float localZ = (iz + Random.Range(-0.80f, 0.80f)) * baseStep;

                float normX = localX / tSize.x;
                float normZ = localZ / tSize.z;

                float worldX = tPos.x + localX;
                float worldZ = tPos.z + localZ;
                float worldY = t.SampleHeight(new Vector3(worldX, 0, worldZ)) + tPos.y;
                Vector3 worldPos = new Vector3(worldX, worldY, worldZ);

                // --- 1. WATER & CLIFF CHECK ---
                // River water surface is 98.9m. Dry ground is >= 99.1m
                if (worldY < 99.1f) continue;

                float steepness = td.GetSteepness(normX, normZ);
                if (steepness > 38f) continue;

                // --- 2. EXCLUSION ZONES (Buildings, Farming Grid, Animals, Player) ---
                bool inExclusion = false;
                foreach (var ex in exclusions)
                {
                    if (ex.Contains(worldPos))
                    {
                        inExclusion = true;
                        break;
                    }
                }
                if (inExclusion) continue;

                // --- 3. ROAD PATH CHECK VIA ALPHAMAP ---
                int aX = Mathf.Clamp(Mathf.FloorToInt(normX * (alphaRes - 1)), 0, alphaRes - 1);
                int aZ = Mathf.Clamp(Mathf.FloorToInt(normZ * (alphaRes - 1)), 0, alphaRes - 1);
                float roadWeight = alphamaps[aZ, aX, 1];
                if (roadWeight > 0.35f) continue; // In the middle of the road

                // --- 4. ORGANIC PERLIN NOISE CLUSTERING ---
                // Multi-frequency Perlin noise for natural clumpiness ("từa lưa tùm lum")
                float noiseClump = Mathf.PerlinNoise((worldX + 5000f) * 0.015f, (worldZ + 5000f) * 0.015f);
                float noiseDetail = Mathf.PerlinNoise((worldX + 1234f) * 0.045f, (worldZ + 5678f) * 0.045f);
                float noiseDensity = (noiseClump * 0.65f) + (noiseDetail * 0.35f);

                // Create natural clearings, open meadow patches, and dense groves
                // If noise is low, this area is an open grassy clearing (skip or rare tree)
                if (noiseDensity < 0.35f && Random.value > 0.12f)
                {
                    continue; // Natural open meadow/clearing
                }

                // Species biome selector noise (0 to 1) creates natural species colonies
                float speciesNoise = Mathf.PerlinNoise((worldX - 3000f) * 0.012f, (worldZ - 3000f) * 0.012f);

                float distToVillage = Vector2.Distance(new Vector2(worldX, worldZ), new Vector2(0f, -20f));

                PlaceOrganicTree(normX, normZ, worldPos, distToVillage, roadWeight, noiseDensity, speciesNoise, treeList);
            }
        }
    }

    private static void PlaceOrganicTree(
        float normX, float normZ, Vector3 worldPos,
        float distToVillage, float roadWeight,
        float noiseDensity, float speciesNoise,
        List<TreeInstance> treeList)
    {
        float roll = Random.value;

        // --- VILLAGE IMMEDIATE VICINITY (distToVillage < 45m) ---
        if (distToVillage < 45f)
        {
            // Homestead garden mix: Lemon fruit trees (40%), Banana bushes (30%), Vegetables (15%), Palms/Bamboo (15%)
            if (roll < 0.40f)
            {
                int proto = PROTO_FRUIT[Random.Range(0, PROTO_FRUIT.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.15f), Random.Range(0.85f, 1.15f));
            }
            else if (roll < 0.70f)
            {
                int proto = PROTO_BANANA[Random.Range(0, PROTO_BANANA.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.20f), Random.Range(0.85f, 1.20f));
            }
            else if (roll < 0.85f)
            {
                AddTree(treeList, PROTO_VEGETABLE, normX, normZ, Random.Range(0.8f, 1.05f), Random.Range(0.8f, 1.05f));
            }
            else if (roll < 0.95f)
            {
                int proto = PROTO_BAMBOO[Random.Range(0, PROTO_BAMBOO.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.15f), Random.Range(0.85f, 1.15f));
            }
            else
            {
                int proto = PROTO_PALM_OLD[Random.Range(0, PROTO_PALM_OLD.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.9f, 1.25f), Random.Range(0.9f, 1.25f));
            }
            return;
        }

        // --- GENERAL COUNTRYSIDE MAP (Organic Noise Clumping) ---
        // We use speciesNoise to naturally group trees into organic groves:
        // - Colony A (speciesNoise < 0.35): Lemon Orchards & Fruit Tree Groves (35%)
        // - Colony B (0.35 <= speciesNoise < 0.60): Banana Bush Colonies & Mixed Greenery (25%)
        // - Colony C (0.60 <= speciesNoise < 0.85): Bamboo Forests & Village Bamboo Groves (25%)
        // - Colony D (speciesNoise >= 0.85): Coconut, Palm & Cau groves (13%)
        // - Melaleuca: ONLY 2% rare random accent throughout!

        // Rare Melaleuca (Tràm) accent (< 2.5%):
        if (roll < 0.025f)
        {
            int proto = PROTO_MELALEUCA[Random.Range(0, PROTO_MELALEUCA.Length)];
            AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.30f), Random.Range(0.85f, 1.25f));
            return;
        }

        // 1. LEMON & FRUIT TREE GROVES (Gorgeous, green, loaded with fruit)
        if (speciesNoise < 0.35f)
        {
            if (roll < 0.70f)
            {
                // Lemon tree (with or without fruit)
                int proto = PROTO_FRUIT[Random.Range(0, PROTO_FRUIT.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.25f), Random.Range(0.85f, 1.25f));
            }
            else if (roll < 0.88f)
            {
                // Banana bush mixed inside orchard
                int proto = PROTO_BANANA[Random.Range(0, PROTO_BANANA.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.20f), Random.Range(0.85f, 1.20f));
            }
            else
            {
                // Bamboo clump at edge of orchard
                int proto = PROTO_BAMBOO[Random.Range(0, PROTO_BAMBOO.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.90f, 1.25f), Random.Range(0.90f, 1.20f));
            }
        }
        // 2. BANANA GROVES (Lush broad green leaves)
        else if (speciesNoise < 0.60f)
        {
            if (roll < 0.65f)
            {
                int proto = PROTO_BANANA[Random.Range(0, PROTO_BANANA.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.25f), Random.Range(0.85f, 1.25f));
            }
            else if (roll < 0.85f)
            {
                int proto = PROTO_FRUIT[Random.Range(0, PROTO_FRUIT.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.20f), Random.Range(0.85f, 1.20f));
            }
            else
            {
                int proto = PROTO_PALM_STYLED[Random.Range(0, PROTO_PALM_STYLED.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.90f, 1.30f), Random.Range(0.90f, 1.25f));
            }
        }
        // 3. BAMBOO FORESTS (Rừng tre, lũy tre uốn lượn tự nhiên)
        else if (speciesNoise < 0.85f)
        {
            if (roll < 0.65f)
            {
                int proto = PROTO_BAMBOO[Random.Range(0, PROTO_BAMBOO.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.90f, 1.35f), Random.Range(0.90f, 1.30f));
            }
            else if (roll < 0.82f)
            {
                int proto = PROTO_FRUIT[Random.Range(0, PROTO_FRUIT.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.20f), Random.Range(0.85f, 1.20f));
            }
            else
            {
                int proto = PROTO_BANANA[Random.Range(0, PROTO_BANANA.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.20f), Random.Range(0.85f, 1.20f));
            }
        }
        // 4. COCONUT & PALM GROVES (Dừa, Cau, Cọ tự nhiên)
        else
        {
            if (roll < 0.45f)
            {
                int proto = PROTO_COCONUT[Random.Range(0, PROTO_COCONUT.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.35f), Random.Range(0.85f, 1.30f));
            }
            else if (roll < 0.70f)
            {
                int proto = PROTO_PALM_STYLED[Random.Range(0, PROTO_PALM_STYLED.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.90f, 1.30f), Random.Range(0.90f, 1.25f));
            }
            else if (roll < 0.85f)
            {
                int proto = PROTO_BAMBOO[Random.Range(0, PROTO_BAMBOO.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.90f, 1.25f), Random.Range(0.90f, 1.20f));
            }
            else
            {
                int proto = PROTO_FRUIT[Random.Range(0, PROTO_FRUIT.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.20f), Random.Range(0.85f, 1.20f));
            }
        }
    }

    private static void AddTree(List<TreeInstance> treeList, int protoIndex, float normX, float normZ, float heightScale, float widthScale)
    {
        TreeInstance ti = new TreeInstance();
        ti.position = new Vector3(normX, 0f, normZ);
        ti.prototypeIndex = protoIndex;
        ti.widthScale = widthScale;
        ti.heightScale = heightScale;
        ti.rotation = Random.Range(0f, Mathf.PI * 2f);
        ti.color = Color.white;
        ti.lightmapColor = Color.white;
        treeList.Add(ti);
    }
}
