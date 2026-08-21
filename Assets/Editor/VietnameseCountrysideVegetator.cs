using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;
using System.Collections.Generic;

public class VietnameseCountrysideVegetator
{
    // Prototype Indices matching the unified 52-tree palette
    private const int PROTO_VEGETABLE = 0;
    private static readonly int[] PROTO_MELALEUCA = { 1, 2, 3 }; // MelaleucaAlternifolia_A, M, Y (tràm trà hoa trắng)
    private static readonly int[] PROTO_BAMBOO = { 4, 8, 9, 10, 11 }; // TreeBush1..5 (tre làng)
    private static readonly int[] PROTO_BANANA = { 5, 6, 7 }; // BaTree1, 2, 3 (chuối)
    // Prototype 12 is RicePlant -> EXCLUDED (gameplay object on fields)
    private static readonly int[] PROTO_COCONUT = { 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 }; // Coconut_Palm_Tree01..12_AFS
    private static readonly int[] PROTO_FRUIT = { 25, 26, 27, 28, 29, 30, 31, 32 }; // Lemon Tree 1..4 & w Fruits
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

        Debug.Log("Starting Vietnamese Countryside Landscape Generation...");

        // 1. Tint Melaleuca Materials to be slightly greener (preserving white blossom character while blending naturally)
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
            if (rName.Contains("terrain") || rName.Contains("terain") || rName.Contains("light") || rName.Contains("eventsystem") || rName.Contains("manager"))
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

        // 4. Define water plane zones for river proximity calculation
        List<Bounds> waterZones = new List<Bounds>();
        foreach (var root in roots)
        {
            if (root.name.ToLower().Contains("waterplane") && !root.name.ToLower().Contains("field"))
            {
                var r = root.GetComponent<Renderer>();
                if (r != null) waterZones.Add(r.bounds);
            }
        }

        // 5. Populate each terrain
        Random.InitState(19930821);

        foreach (var t in terrains)
        {
            TerrainData td = t.terrainData;
            Undo.RegisterCompleteObjectUndo(td, "Vietnamese Countryside Trees");

            // Synchronize prototypes
            td.treePrototypes = masterPrototypes;

            List<TreeInstance> newTrees = new List<TreeInstance>();
            Vector3 tPos = t.transform.position;
            Vector3 tSize = td.size;

            float[,,] alphamaps = td.GetAlphamaps(0, 0, td.alphamapResolution, td.alphamapResolution);
            int alphaRes = td.alphamapResolution;

            GenerateTreesForTerrain(t, td, tPos, tSize, alphamaps, alphaRes, exclusions, waterZones, newTrees);

            td.SetTreeInstances(newTrees.ToArray(), true);
            t.treeDistance = 850f;
            t.treeBillboardDistance = 65f;
            t.treeCrossFadeLength = 15f;
            t.treeMaximumFullLODCount = 200;

            EditorUtility.SetDirty(td);
            Debug.Log($"Terrain '{t.name}': Successfully placed {newTrees.Count} countryside trees.");
        }

        EditorSceneManager.MarkSceneDirty(scene);
        EditorSceneManager.SaveScene(scene);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("=== VIETNAMESE COUNTRYSIDE VEGETATION UPDATED SUCCESSFULLY ===");
    }

    public static void TintMelaleucaMaterials()
    {
        string mapsPath = "Assets/MyFolder/Prefabs/Rau2/Scene/Maps/Mat/";
        
        // Leaves: tint towards a lush, vibrant green
        Color leafColor = new Color(0.72f, 0.92f, 0.70f, 1.0f);
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

        // Flowers: slightly greener tint while remaining bright white/ivory blossom
        Color flowerColor = new Color(0.88f, 0.98f, 0.86f, 1.0f);
        Material flowers01 = AssetDatabase.LoadAssetAtPath<Material>(mapsPath + "Flowers01.mat");
        if (flowers01 != null)
        {
            flowers01.SetColor("_BaseColor", flowerColor);
            EditorUtility.SetDirty(flowers01);
        }

        Debug.Log("Melaleuca materials tinted to greener shades successfully.");
    }

    private static void GenerateTreesForTerrain(
        Terrain t, TerrainData td, Vector3 tPos, Vector3 tSize,
        float[,,] alphamaps, int alphaRes,
        List<ExclusionBox> exclusions, List<Bounds> waterZones,
        List<TreeInstance> treeList)
    {
        float step = 7.0f; // sampling interval in world meters
        int stepsX = Mathf.FloorToInt(tSize.x / step);
        int stepsZ = Mathf.FloorToInt(tSize.z / step);

        for (int ix = 1; ix < stepsX - 1; ix++)
        {
            for (int iz = 1; iz < stepsZ - 1; iz++)
            {
                float localX = (ix + Random.Range(-0.35f, 0.35f)) * step;
                float localZ = (iz + Random.Range(-0.35f, 0.35f)) * step;

                float normX = localX / tSize.x;
                float normZ = localZ / tSize.z;

                float worldX = tPos.x + localX;
                float worldZ = tPos.z + localZ;
                float worldY = t.SampleHeight(new Vector3(worldX, 0, worldZ)) + tPos.y;
                Vector3 worldPos = new Vector3(worldX, worldY, worldZ);

                // --- CHECK 1: WATER DEPTH & ELEVATION ---
                if (worldY < 99.1f) continue; // Don't spawn submerged under river water

                float normHeightX = normX;
                float normHeightZ = normZ;
                float steepness = td.GetSteepness(normHeightX, normHeightZ);
                if (steepness > 40f) continue;

                // --- CHECK 2: EXCLUSION ZONES (Buildings, Farming Grid, Animals, Player) ---
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

                // --- CHECK 3: ROAD / PATH CHECK VIA ALPHAMAP ---
                int aX = Mathf.Clamp(Mathf.FloorToInt(normX * (alphaRes - 1)), 0, alphaRes - 1);
                int aZ = Mathf.Clamp(Mathf.FloorToInt(normZ * (alphaRes - 1)), 0, alphaRes - 1);
                float roadWeight = alphamaps[aZ, aX, 1];
                if (roadWeight > 0.3f) continue; // In the middle of the road -> forbidden

                // Calculate distance to nearest water plane
                float distToWater = GetDistanceToWater(worldPos, waterZones);

                // Distance to village center (approx 0, 100, -20)
                float distToVillage = Vector2.Distance(new Vector2(worldX, worldZ), new Vector2(0f, -20f));

                PlaceBiomeTree(normX, normZ, worldPos, distToVillage, distToWater, roadWeight, steepness, treeList);
            }
        }
    }

    private static float GetDistanceToWater(Vector3 worldPos, List<Bounds> waterZones)
    {
        float minDist = float.MaxValue;
        foreach (var wb in waterZones)
        {
            Vector2 p = new Vector2(worldPos.x, worldPos.z);
            Vector2 closest = new Vector2(
                Mathf.Clamp(p.x, wb.min.x, wb.max.x),
                Mathf.Clamp(p.y, wb.min.z, wb.max.z)
            );
            float d = Vector2.Distance(p, closest);
            if (d < minDist) minDist = d;
        }
        return minDist;
    }

    private static void PlaceBiomeTree(
        float normX, float normZ, Vector3 worldPos,
        float distToVillage, float distToWater, float roadWeight, float steepness,
        List<TreeInstance> treeList)
    {
        float roll = Random.value;

        // =========================================================================
        // ZONE 1: VILLAGE SURROUNDINGS & HOMESTEAD GARDENS (distToVillage < 75m)
        // =========================================================================
        if (distToVillage < 75f)
        {
            if (distToVillage < 35f)
            {
                if (roll < 0.25f)
                {
                    // Banana tree cluster (Chuối sau nhà/chuồng trại)
                    int proto = PROTO_BANANA[Random.Range(0, PROTO_BANANA.Length)];
                    AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.15f), Random.Range(0.85f, 1.15f));
                }
                else if (roll < 0.50f)
                {
                    // Fruit trees (Chanh có quả / cây ăn trái)
                    int proto = PROTO_FRUIT[Random.Range(0, PROTO_FRUIT.Length)];
                    AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.1f), Random.Range(0.85f, 1.1f));
                }
                else if (roll < 0.65f)
                {
                    // Vegetable patch (Luống rau)
                    AddTree(treeList, PROTO_VEGETABLE, normX, normZ, Random.Range(0.8f, 1.05f), Random.Range(0.8f, 1.05f));
                }
                else if (roll < 0.80f)
                {
                    // Palm/Betel nut tree (Cau/dừa trước sân)
                    int proto = PROTO_PALM_OLD[Random.Range(0, PROTO_PALM_OLD.Length)];
                    AddTree(treeList, proto, normX, normZ, Random.Range(0.9f, 1.25f), Random.Range(0.9f, 1.25f));
                }
                else if (roll < 0.95f)
                {
                    // Small bamboo cluster near fence
                    int proto = PROTO_BAMBOO[Random.Range(0, PROTO_BAMBOO.Length)];
                    AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.15f), Random.Range(0.85f, 1.15f));
                }
            }
            else // 35m - 75m: Transition village to fields
            {
                if (roll < 0.35f)
                {
                    // Fruit orchards
                    int proto = PROTO_FRUIT[Random.Range(0, PROTO_FRUIT.Length)];
                    AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.2f), Random.Range(0.85f, 1.2f));
                }
                else if (roll < 0.65f)
                {
                    // Bamboo village border (Lũy tre làng)
                    int proto = PROTO_BAMBOO[Random.Range(0, PROTO_BAMBOO.Length)];
                    AddTree(treeList, proto, normX, normZ, Random.Range(0.9f, 1.25f), Random.Range(0.9f, 1.25f));
                }
                else if (roll < 0.85f)
                {
                    // Banana groves
                    int proto = PROTO_BANANA[Random.Range(0, PROTO_BANANA.Length)];
                    AddTree(treeList, proto, normX, normZ, Random.Range(0.9f, 1.2f), Random.Range(0.9f, 1.2f));
                }
                else if (roll < 0.95f)
                {
                    // Occasional shaded palm/cau
                    int proto = PROTO_PALM_STYLED[Random.Range(0, PROTO_PALM_STYLED.Length)];
                    AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.2f), Random.Range(0.85f, 1.2f));
                }
            }
            return;
        }

        // =========================================================================
        // ZONE 2: RIVERSIDE & CANAL BANKS (distToWater < 50m)
        // =========================================================================
        if (distToWater < 50f)
        {
            if (distToWater < 22f)
            {
                if (roll < 0.50f)
                {
                    // AFS Coconut Palm (Dừa nước / Dừa xiêm nghiêng bóng)
                    int proto = PROTO_COCONUT[Random.Range(0, PROTO_COCONUT.Length)];
                    AddTree(treeList, proto, normX, normZ, Random.Range(0.9f, 1.35f), Random.Range(0.9f, 1.3f));
                }
                else if (roll < 0.80f)
                {
                    // Bamboo along river (Tre giữ bờ)
                    int proto = PROTO_BAMBOO[Random.Range(0, PROTO_BAMBOO.Length)];
                    AddTree(treeList, proto, normX, normZ, Random.Range(0.95f, 1.3f), Random.Range(0.95f, 1.25f));
                }
                else if (roll < 0.95f)
                {
                    // Stylized Palm clusters (Dual/Trio)
                    int proto = PROTO_PALM_STYLED[Random.Range(0, PROTO_PALM_STYLED.Length)];
                    AddTree(treeList, proto, normX, normZ, Random.Range(0.9f, 1.25f), Random.Range(0.9f, 1.25f));
                }
            }
            else // 22m - 50m from water
            {
                if (roll < 0.40f)
                {
                    int proto = PROTO_COCONUT[Random.Range(0, PROTO_COCONUT.Length)];
                    AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.25f), Random.Range(0.85f, 1.2f));
                }
                else if (roll < 0.72f)
                {
                    int proto = PROTO_BAMBOO[Random.Range(0, PROTO_BAMBOO.Length)];
                    AddTree(treeList, proto, normX, normZ, Random.Range(0.9f, 1.25f), Random.Range(0.9f, 1.2f));
                }
                else if (roll < 0.90f)
                {
                    int proto = PROTO_BANANA[Random.Range(0, PROTO_BANANA.Length)];
                    AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.15f), Random.Range(0.85f, 1.15f));
                }
            }
            return;
        }

        // =========================================================================
        // ZONE 3: ROADSIDE TREES (roadWeight > 0.08f & <= 0.3f)
        // =========================================================================
        if (roadWeight > 0.08f)
        {
            if (roll < 0.35f)
            {
                // Bamboo clusters along the road
                int proto = PROTO_BAMBOO[Random.Range(0, PROTO_BAMBOO.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.9f, 1.2f), Random.Range(0.9f, 1.2f));
            }
            else if (roll < 0.65f)
            {
                // Straight Palms / Cọ cau ven đường
                int proto = PROTO_PALM_OLD[Random.Range(0, PROTO_PALM_OLD.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.9f, 1.3f), Random.Range(0.9f, 1.25f));
            }
            else if (roll < 0.85f)
            {
                // Banana bush on roadside
                int proto = PROTO_BANANA[Random.Range(0, PROTO_BANANA.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.15f), Random.Range(0.85f, 1.15f));
            }
            return;
        }

        // =========================================================================
        // ZONE 4: HILLS & DISTANT COUNTRYSIDE FORESTS (Elevated slopes & background)
        // =========================================================================
        if (worldPos.y > 102.5f || steepness > 10f)
        {
            // Forested hills: Melaleuca reduced by ~35%, heavily replaced by Bamboo & Palms
            if (roll < 0.28f)
            {
                // Melaleuca (Tràm hoa trắng đã tinh chỉnh màu xanh dịu)
                int proto = PROTO_MELALEUCA[Random.Range(0, PROTO_MELALEUCA.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.35f), Random.Range(0.85f, 1.3f));
            }
            else if (roll < 0.68f)
            {
                // Rừng tre xanh làng quê
                int proto = PROTO_BAMBOO[Random.Range(0, PROTO_BAMBOO.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.9f, 1.3f), Random.Range(0.9f, 1.25f));
            }
            else if (roll < 0.90f)
            {
                // Cọ cau / Palm xanh tươi
                int proto = PROTO_PALM_STYLED[Random.Range(0, PROTO_PALM_STYLED.Length)];
                AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.25f), Random.Range(0.85f, 1.2f));
            }
            return;
        }

        // =========================================================================
        // ZONE 5: OPEN PLAINS & MEADOWS (Lowland green outskirts)
        // =========================================================================
        if (roll < 0.16f)
        {
            // Solitary palm tree on field mound (Cây thốt nốt / dừa đơn độc giữa đồng)
            int proto = PROTO_PALM_STYLED[Random.Range(0, PROTO_PALM_STYLED.Length)];
            AddTree(treeList, proto, normX, normZ, Random.Range(1.0f, 1.4f), Random.Range(1.0f, 1.35f));
        }
        else if (roll < 0.32f)
        {
            // Bamboo clump
            int proto = PROTO_BAMBOO[Random.Range(0, PROTO_BAMBOO.Length)];
            AddTree(treeList, proto, normX, normZ, Random.Range(0.9f, 1.25f), Random.Range(0.9f, 1.2f));
        }
        else if (roll < 0.42f)
        {
            // Wild banana bush
            int proto = PROTO_BANANA[Random.Range(0, PROTO_BANANA.Length)];
            AddTree(treeList, proto, normX, normZ, Random.Range(0.85f, 1.15f), Random.Range(0.85f, 1.15f));
        }
        else if (roll < 0.47f)
        {
            // Occasional Melaleuca shade tree
            int proto = PROTO_MELALEUCA[Random.Range(0, PROTO_MELALEUCA.Length)];
            AddTree(treeList, proto, normX, normZ, Random.Range(0.9f, 1.3f), Random.Range(0.9f, 1.25f));
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
