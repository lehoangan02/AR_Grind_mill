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
    // Prototype 12 is RicePlant -> EXCLUDED (gameplay object on fields)
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

        Debug.Log("Starting Calibrated Organic Countryside Landscape Generation...");

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

        // 3. Build Exclusion Zones from scene landmarks
        List<ExclusionBox> exclusions = new List<ExclusionBox>();
        GameObject[] roots = scene.GetRootGameObjects();

        foreach (var root in roots)
        {
            string rName = root.name.ToLower();
            if (rName.Contains("terrain") || rName.Contains("terain") || rName.Contains("light") || 
                rName.Contains("eventsystem") || rName.Contains("manager") || rName.Contains("waterplane"))
                continue;

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
            Debug.Log($"Terrain '{t.name}': Successfully placed {newTrees.Count} calibrated organic trees.");
        }

        EditorSceneManager.MarkSceneDirty(scene);
        EditorSceneManager.SaveScene(scene);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("=== CALIBRATED ORGANIC COUNTRYSIDE VEGETATION COMPLETED SUCCESSFULLY ===");
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
        float baseStep = 7.0f;
        int stepsX = Mathf.FloorToInt(tSize.x / baseStep);
        int stepsZ = Mathf.FloorToInt(tSize.z / baseStep);

        for (int ix = 1; ix < stepsX - 1; ix++)
        {
            for (int iz = 1; iz < stepsZ - 1; iz++)
            {
                // Organic Poisson-like position jittering
                float localX = (ix + Random.Range(-0.85f, 0.85f)) * baseStep;
                float localZ = (iz + Random.Range(-0.85f, 0.85f)) * baseStep;

                float normX = localX / tSize.x;
                float normZ = localZ / tSize.z;

                float worldX = tPos.x + localX;
                float worldZ = tPos.z + localZ;
                float worldY = t.SampleHeight(new Vector3(worldX, 0, worldZ)) + tPos.y;
                Vector3 worldPos = new Vector3(worldX, worldY, worldZ);

                // --- 1. WATER & CLIFF CHECK ---
                if (worldY < 99.1f) continue;

                float steepness = td.GetSteepness(normX, normZ);
                if (steepness > 38f) continue;

                // --- 2. EXCLUSION ZONES ---
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
                if (roadWeight > 0.35f) continue;

                // --- 4. ORGANIC NOISE CLUSTERING & NATURAL CLEARINGS ---
                float noiseClump = Mathf.PerlinNoise((worldX + 5000f) * 0.012f, (worldZ + 5000f) * 0.012f);
                float noiseDetail = Mathf.PerlinNoise((worldX + 1234f) * 0.038f, (worldZ + 5678f) * 0.038f);
                float noiseDensity = (noiseClump * 0.65f) + (noiseDetail * 0.35f);

                // Natural open clearings / meadows
                if (noiseDensity < 0.33f && Random.value > 0.15f)
                {
                    continue;
                }

                float speciesNoise = Mathf.PerlinNoise((worldX - 3000f) * 0.010f, (worldZ - 3000f) * 0.010f);
                float palmSparseNoise = Mathf.PerlinNoise((worldX + 8888f) * 0.055f, (worldZ + 9999f) * 0.055f);

                float distToVillage = Vector2.Distance(new Vector2(worldX, worldZ), new Vector2(0f, -20f));

                PlaceCalibratedTree(normX, normZ, worldPos, distToVillage, roadWeight, noiseDensity, speciesNoise, palmSparseNoise, treeList);
            }
        }
    }

    private static void PlaceCalibratedTree(
        float normX, float normZ, Vector3 worldPos,
        float distToVillage, float roadWeight,
        float noiseDensity, float speciesNoise, float palmSparseNoise,
        List<TreeInstance> treeList)
    {
        float roll = Random.value;

        // --- VILLAGE IMMEDIATE VICINITY (distToVillage < 45m) ---
        if (distToVillage < 45f)
        {
            if (roll < 0.35f)
            {
                // Lemon fruit trees (Chanh trĩu quả quanh nhà)
                int proto = PROTO_FRUIT[Random.Range(0, PROTO_FRUIT.Length)];
                AddCalibratedTree(treeList, proto, normX, normZ);
            }
            else if (roll < 0.65f)
            {
                // Banana bushes (Chuối sau nhà)
                int proto = PROTO_BANANA[Random.Range(0, PROTO_BANANA.Length)];
                AddCalibratedTree(treeList, proto, normX, normZ);
            }
            else if (roll < 0.80f)
            {
                // Vegetable patches
                AddCalibratedTree(treeList, PROTO_VEGETABLE, normX, normZ);
            }
            else if (roll < 0.90f)
            {
                // Bamboo near perimeter
                int proto = PROTO_BAMBOO[Random.Range(0, PROTO_BAMBOO.Length)];
                AddCalibratedTree(treeList, proto, normX, normZ);
            }
            else
            {
                // Sparse Betel Nut / Palm in front yard
                int proto = PROTO_PALM_OLD[Random.Range(0, PROTO_PALM_OLD.Length)];
                AddCalibratedTree(treeList, proto, normX, normZ);
            }
            return;
        }

        // --- GENERAL COUNTRYSIDE MAP ---
        // Rare Melaleuca accent (< 1.8%):
        if (roll < 0.018f)
        {
            int proto = PROTO_MELALEUCA[Random.Range(0, PROTO_MELALEUCA.Length)];
            AddCalibratedTree(treeList, proto, normX, normZ);
            return;
        }

        // 1. SPARSE PALM / COCONUT / CAU DISTRIBUTION (Sparse & graceful across the map)
        // Whenever palmSparseNoise is in a sweet range (creating individual sparse trees ~15-30m apart)
        // or in river proximity
        if (palmSparseNoise > 0.68f && roll < 0.55f)
        {
            // Pick a sparse coconut / palm / cau
            if (Random.value < 0.50f)
            {
                int proto = PROTO_COCONUT[Random.Range(0, PROTO_COCONUT.Length)];
                AddCalibratedTree(treeList, proto, normX, normZ);
            }
            else
            {
                int proto = PROTO_PALM_STYLED[Random.Range(0, PROTO_PALM_STYLED.Length)];
                AddCalibratedTree(treeList, proto, normX, normZ);
            }
            return;
        }

        // 2. LEMON & FRUIT TREE ORCHARDS (30% of map)
        if (speciesNoise < 0.34f)
        {
            if (roll < 0.68f)
            {
                int proto = PROTO_FRUIT[Random.Range(0, PROTO_FRUIT.Length)];
                AddCalibratedTree(treeList, proto, normX, normZ);
            }
            else if (roll < 0.85f)
            {
                int proto = PROTO_BANANA[Random.Range(0, PROTO_BANANA.Length)];
                AddCalibratedTree(treeList, proto, normX, normZ);
            }
            else
            {
                int proto = PROTO_BAMBOO[Random.Range(0, PROTO_BAMBOO.Length)];
                AddCalibratedTree(treeList, proto, normX, normZ);
            }
        }
        // 3. BANANA GROVES (30% of map)
        else if (speciesNoise < 0.68f)
        {
            if (roll < 0.68f)
            {
                int proto = PROTO_BANANA[Random.Range(0, PROTO_BANANA.Length)];
                AddCalibratedTree(treeList, proto, normX, normZ);
            }
            else if (roll < 0.85f)
            {
                int proto = PROTO_FRUIT[Random.Range(0, PROTO_FRUIT.Length)];
                AddCalibratedTree(treeList, proto, normX, normZ);
            }
            else
            {
                int proto = PROTO_BAMBOO[Random.Range(0, PROTO_BAMBOO.Length)];
                AddCalibratedTree(treeList, proto, normX, normZ);
            }
        }
        // 4. BAMBOO FORESTS & LUSH GROVES (22% of map)
        else
        {
            if (roll < 0.68f)
            {
                int proto = PROTO_BAMBOO[Random.Range(0, PROTO_BAMBOO.Length)];
                AddCalibratedTree(treeList, proto, normX, normZ);
            }
            else if (roll < 0.84f)
            {
                int proto = PROTO_FRUIT[Random.Range(0, PROTO_FRUIT.Length)];
                AddCalibratedTree(treeList, proto, normX, normZ);
            }
            else
            {
                int proto = PROTO_BANANA[Random.Range(0, PROTO_BANANA.Length)];
                AddCalibratedTree(treeList, proto, normX, normZ);
            }
        }
    }

    private static void AddCalibratedTree(List<TreeInstance> treeList, int protoIndex, float normX, float normZ)
    {
        GetRealisticScale(protoIndex, out float heightScale, out float widthScale);

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

    private static void GetRealisticScale(int protoIndex, out float heightScale, out float widthScale)
    {
        // Standard deviation variance
        float varH = Random.Range(-0.08f, 0.08f);
        float varW = Random.Range(-0.08f, 0.08f);

        switch (protoIndex)
        {
            case PROTO_VEGETABLE: // Raw 0.18m -> calibrated to 0.25m - 0.32m
                heightScale = 1.50f + varH;
                widthScale = 1.50f + varW;
                break;

            case 1: // Melaleuca_A (raw 8.39m -> 9.0m - 11.0m)
            case 2: // Melaleuca_M (raw 6.43m -> 7.0m - 9.0m)
            case 3: // Melaleuca_Y (raw 4.28m -> 4.8m - 6.2m)
                heightScale = 1.15f + varH;
                widthScale = 1.15f + varW;
                break;

            // Bamboo (Tre làng - scaled up to majestic 4.5m - 8.5m real height)
            case 4: // TreeBush1 (raw 1.90m -> 3.2m - 3.8m)
                heightScale = 1.80f + varH;
                widthScale = 1.65f + varW;
                break;
            case 8: // TreeBush2 (raw 2.62m -> 4.8m - 5.8m)
                heightScale = 1.95f + varH;
                widthScale = 1.75f + varW;
                break;
            case 9: // TreeBush3 (raw 3.21m -> 5.8m - 7.0m)
                heightScale = 2.00f + varH;
                widthScale = 1.80f + varW;
                break;
            case 10: // TreeBush4 (raw 3.61m -> 6.8m - 8.2m)
                heightScale = 2.05f + varH;
                widthScale = 1.85f + varW;
                break;
            case 11: // TreeBush5 (raw 4.03m -> 7.8m - 9.2m)
                heightScale = 2.10f + varH;
                widthScale = 1.90f + varW;
                break;

            // Banana trees (raw 2.6m - 3.5m -> calibrated to realistic 2.7m - 3.8m)
            case 5: // BaTree1 (raw 2.63m -> 2.7m - 3.1m)
            case 6: // BaTree2 (raw 3.48m -> 3.4m - 4.0m)
            case 7: // BaTree3 (raw 3.01m -> 3.0m - 3.5m)
                heightScale = 1.05f + varH;
                widthScale = 1.05f + varW;
                break;

            // Coconut Palms AFS (Raw heights 13m - 27m -> calibrated to realistic 8.5m - 14.5m)
            case 13: // Coconut 01 (raw 20.1m -> 10.5m - 12.5m)
            case 14: // Coconut 02 (raw 21.4m -> 11.0m - 13.0m)
            case 15: // Coconut 03 (raw 25.5m -> 12.5m - 15.0m)
            case 18: // Coconut 06 (raw 20.3m -> 10.5m - 12.5m)
            case 20: // Coconut 08 (raw 26.9m -> 13.0m - 15.5m)
            case 21: // Coconut 09 (raw 25.4m -> 12.5m - 15.0m)
            case 22: // Coconut 10 (raw 21.3m -> 11.0m - 13.0m)
            case 23: // Coconut 11 (raw 25.9m -> 12.5m - 15.0m)
                heightScale = 0.52f + varH;
                widthScale = 0.52f + varW;
                break;
            case 16: // Coconut 04 (raw 13.7m -> 8.5m - 10.5m)
            case 17: // Coconut 05 (raw 15.3m -> 9.0m - 11.5m)
            case 19: // Coconut 07 (raw 12.6m -> 8.0m - 9.8m)
            case 24: // Coconut 12 (raw 18.9m -> 10.0m - 12.0m)
                heightScale = 0.60f + varH;
                widthScale = 0.60f + varW;
                break;

            // Lemon & Fruit Trees (Calibrated to realistic 2.5m - 4.2m orchard heights)
            case 25: // Lemon 1 (raw 1.03m -> 2.2m - 2.7m)
            case 30: // Lemon 1 w Fruits
                heightScale = 2.30f + varH;
                widthScale = 2.30f + varW;
                break;
            case 26: // Lemon 2 (raw 1.85m -> 2.7m - 3.3m)
            case 29: // Lemon 2 w Fruits
                heightScale = 1.55f + varH;
                widthScale = 1.55f + varW;
                break;
            case 27: // Lemon 3 (raw 4.96m -> 3.6m - 4.4m)
            case 31: // Lemon 3 w Fruits
                heightScale = 0.80f + varH;
                widthScale = 0.80f + varW;
                break;
            case 28: // Lemon 4 (raw 4.56m -> 3.4m - 4.2m)
            case 32: // Lemon 4 w Fruits
                heightScale = 0.80f + varH;
                widthScale = 0.80f + varW;
                break;

            // Giant Palm 33 (raw 43.7m -> calibrate to 11.5m - 14.5m)
            case 33:
                heightScale = 0.28f + varH;
                widthScale = 0.28f + varW;
                break;

            // Palm 1_2 .. 1_4 & Palm 2_1 .. 2_3 (raw 8m - 22m -> calibrated to 7.5m - 13.5m)
            case 34:
            case 35:
            case 36:
            case 37:
            case 38:
            case 39:
            case 40:
            case 41:
                heightScale = 0.68f + varH;
                widthScale = 0.68f + varW;
                break;

            // Stylized Palms (Dual / Single / Trio) (raw 11m - 16m -> calibrated to 8.5m - 12.5m)
            case 42:
            case 43:
            case 44:
            case 45:
            case 46:
            case 47:
            case 48:
            case 49:
            case 50:
            case 51:
                heightScale = 0.70f + varH;
                widthScale = 0.70f + varW;
                break;

            default:
                heightScale = 1.0f + varH;
                widthScale = 1.0f + varW;
                break;
        }
    }
}
