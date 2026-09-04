using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>
/// Removes the scattered trees on the two terrains that still carry trees and
/// re-plants them in dense clusters around village structures / barns / cattle
/// located on that terrain. Already-cleared terrains are left untouched. Run:
///   -executeMethod TerrainTreeConcentrator.RunTreeConcentration
/// </summary>
public static class TerrainTreeConcentrator
{
    [MenuItem("Tools/Terrain/Concentrate Trees Near Structures")]
    public static void RunTreeConcentration()
    {
        const string scenePath = "Assets/Scenes/Grind mill v1.0 Scene.unity";
        EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);

        // Per-anchor cluster tuning (dense near buildings).
        const float maxRadius = 38f;
        const int treesPerAnchor = 34;

        // Scattered (natural) tree tuning across the whole terrain.
        const float scatterMinSeparation = 16f;
        const float scatterAreaPerTree = 2500f; // one tree per ~50x50m on open land

        const float clusterMinSeparation = 6f; // tight near buildings
        const float maxSlopeDeg = 30f;
        const float blockerClearMargin = 3f; // keep trees just outside structure walls

        string reportPath = Path.Combine(Application.dataPath, "../TerrainTreeConcentrationReport.txt");
        var report = new StringBuilder();
        report.AppendLine("=== TREE CONCENTRATION (dense near houses, sparse across terrain) ===");

        Terrain[] terrains = UnityEngine.Object.FindObjectsByType<Terrain>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (Terrain terrain in terrains)
        {
            TerrainData data = terrain.terrainData;
            if (data == null)
            {
                continue;
            }

            // Only reshape terrains that still carry trees.
            if (data.treeInstanceCount <= 0)
            {
                report.AppendLine($"- '{terrain.name}': no trees, left unchanged.");
                continue;
            }

            Vector3 tPos = terrain.transform.position;
            Vector3 tSize = data.size;

            List<Rect> blockRects = CollectAnchorBlocks(tPos, tSize, blockerClearMargin);
            List<int> allowedPrototypes = AllowedTreePrototypes(data);
            var random = new System.Random(TerrainSeed(terrain));

            var placed = new List<Vector2>();
            var instances = new List<TreeInstance>();

            // (1) Dense clusters around houses / barns / cattle.
            if (blockRects.Count > 0)
            {
                int clusterTarget = blockRects.Count * treesPerAnchor;
                int safety = 0;
                int maxAttempts = Mathf.Min(clusterTarget * 15 + 128, 30000);
                while (placed.Count < clusterTarget && safety < maxAttempts)
                {
                    safety++;
                    Rect block = blockRects[random.Next(blockRects.Count)];
                    Vector2 anchor = block.center;
                    float angle = (float)(random.NextDouble() * System.Math.PI * 2.0);
                    float radius = 8f + (float)random.NextDouble() * (maxRadius - 8f);
                    float tx = anchor.x + Mathf.Cos(angle) * radius;
                    float tz = anchor.y + Mathf.Sin(angle) * radius;

                    float normX = (tx - tPos.x) / tSize.x;
                    float normZ = (tz - tPos.z) / tSize.z;
                    if (normX < 0f || normX >= 1f || normZ < 0f || normZ >= 1f)
                    {
                        continue;
                    }

                    if (InsideAnyRect(blockRects, tx, tz))
                    {
                        continue;
                    }

                    if (IsTooClose(placed, tx, tz, clusterMinSeparation))
                    {
                        continue;
                    }

                    if (data.GetSteepness(normX, normZ) > maxSlopeDeg)
                    {
                        continue;
                    }

                    instances.Add(MakeInstance(random, allowedPrototypes, normX, normZ));
                    placed.Add(new Vector2(tx, tz));
                }
            }

            // (2) Sparse scattering across the whole terrain for a natural look.
            int scatterTarget = Mathf.Max(60, (int)((tSize.x * tSize.z) / scatterAreaPerTree));
            int scSafety = 0;
            int scMax = Mathf.Min(scatterTarget * 8 + 256, 60000);
            while (placed.Count < scatterTarget && scSafety < scMax)
            {
                scSafety++;
                float tx = tPos.x + (float)random.NextDouble() * tSize.x;
                float tz = tPos.z + (float)random.NextDouble() * tSize.z;
                float normX = (tx - tPos.x) / tSize.x;
                float normZ = (tz - tPos.z) / tSize.z;

                if (InsideAnyRect(blockRects, tx, tz))
                {
                    continue;
                }
                if (IsTooClose(placed, tx, tz, scatterMinSeparation))
                {
                    continue;
                }
                if (data.GetSteepness(normX, normZ) > maxSlopeDeg)
                {
                    continue;
                }

                instances.Add(MakeInstance(random, allowedPrototypes, normX, normZ));
                placed.Add(new Vector2(tx, tz));
            }

            int before = data.treeInstanceCount;
            Undo.RegisterCompleteObjectUndo(data, "Concentrate trees near structures");
            data.SetTreeInstances(instances.ToArray(), snapToHeightmap: true);
            EditorUtility.SetDirty(data);
            EditorUtility.SetDirty(terrain);

            report.AppendLine($"- '{terrain.name}': blocks={blockRects.Count}, trees {before} -> {data.treeInstanceCount}");
        }

        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        if (!EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene()))
        {
            Debug.LogError("Concentration failed to save the scene.");
        }
        AssetDatabase.SaveAssets();
        File.WriteAllText(reportPath, report.ToString());
        Debug.Log(report.ToString());
        if (!Application.isBatchMode)
        {
            EditorUtility.DisplayDialog("Concentrate Trees", report.ToString(), "OK");
        }
    }

    private static int TerrainSeed(Terrain t)
    {
        Vector3 p = t.transform.position;
        return 99113 ^ (int)(p.x * 17f) ^ (int)(p.z * 31f);
    }

    private static bool IsTooClose(List<Vector2> placed, float tx, float tz, float minSep)
    {
        for (int i = 0; i < placed.Count; i++)
        {
            float dx = placed[i].x - tx;
            float dz = placed[i].y - tz;
            if (dx * dx + dz * dz < minSep * minSep)
            {
                return true;
            }
        }
        return false;
    }

    private static TreeInstance MakeInstance(System.Random random, List<int> allowed, float normX, float normZ)
    {
        return new TreeInstance
        {
            prototypeIndex = allowed[random.Next(allowed.Count)],
            position = new Vector3(normX, 0f, normZ),
            widthScale = 0.8f + (float)random.NextDouble() * 0.5f,
            heightScale = 0.8f + (float)random.NextDouble() * 0.5f,
            rotation = (float)(random.NextDouble() * 360.0),
            color = Color.white,
            lightmapColor = Color.white
        };
    }

    private static bool IsAnchorName(string name)
    {
        string n = name.ToLowerInvariant();
        string[] tokens =
        {
            "stilt", "house", "pig", "barn", "cow", "buffalo", "buff",
            "granary", "shelter", "mill", "kitchen", "market", "cabin", "village"
        };
        for (int i = 0; i < tokens.Length; i++)
        {
            if (n.Contains(tokens[i]))
            {
                return true;
            }
        }
        return false;
    }

    private static void WalkAnchorBlocks(GameObject go, float minX, float maxX, float minZ, float maxZ, float margin, List<Rect> list)
    {
        if (IsAnchorName(go.name))
        {
            Vector3 p = go.transform.position;
            Vector3 center = p;
            Vector3 size = Vector3.zero;
            Collider col = go.GetComponent<Collider>();
            Renderer rend = go.GetComponent<Renderer>();
            if (rend != null && rend.bounds.size.x > 0.01f)
            {
                center = rend.bounds.center;
                size = rend.bounds.size;
            }
            else if (col != null)
            {
                center = col.bounds.center;
                size = col.bounds.size;
            }

            if (p.x >= minX && p.x < maxX && p.z >= minZ && p.z < maxZ)
            {
                float hw, hz;
                if (size.x > 0.01f && size.z > 0.01f)
                {
                    hw = size.x * 0.5f + margin;
                    hz = size.z * 0.5f + margin;
                }
                else
                {
                    // No renderer/collider bound available -> small clear rect.
                    hw = 3f + margin;
                    hz = 3f + margin;
                }
                list.Add(new Rect(center.x - hw, center.z - hz, hw * 2f, hz * 2f));
            }
        }

        for (int i = 0; i < go.transform.childCount; i++)
        {
            WalkAnchorBlocks(go.transform.GetChild(i).gameObject, minX, maxX, minZ, maxZ, margin, list);
        }
    }

    /// <summary>
    /// Collects world-space xz rectangles (structures bounds + margin) that must
    /// stay tree-free so trees never overlap houses / barns / cattle.
    /// </summary>
    private static List<Rect> CollectAnchorBlocks(Vector3 tPos, Vector3 tSize, float margin)
    {
        var raw = new List<Rect>();
        float minX = tPos.x, maxX = tPos.x + tSize.x;
        float minZ = tPos.z, maxZ = tPos.z + tSize.z;

        foreach (GameObject root in EditorSceneManager.GetActiveScene().GetRootGameObjects())
        {
            WalkAnchorBlocks(root, minX, maxX, minZ, maxZ, margin, raw);
        }

        // Merge only overlapping blocks so nested / duplicated child objects
        // (pigs, cows, LOD parts, ...) collapse into the parent structure zone
        // without gluing separate nearby buildings into one giant block.
        return MergeRects(raw, 0f);
    }

    /// <summary>
    /// Unions rectangles that overlap or are within <paramref name="joinGap"/>
    /// of each other, reducing many small duplicated structure bounds into a
    /// handful of real clearance zones.
    /// </summary>
    private static List<Rect> MergeRects(List<Rect> input, float joinGap)
    {
        var list = new List<Rect>(input);
        bool changed = true;
        while (changed)
        {
            changed = false;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    Rect a = list[i];
                    Rect b = list[j];
                    float gx = (a.width > b.width ? a.width : b.width);
                    float gz = (a.height > b.height ? a.height : b.height);
                    if (a.Overlaps(b) || GappedDist(a, b) < joinGap)
                    {
                        Rect merged = Union(a, b);
                        list[i] = merged;
                        list.RemoveAt(j);
                        changed = true;
                        break;
                    }
                }
                if (changed)
                {
                    break;
                }
            }
        }
        return list;
    }

    private static Rect Union(Rect a, Rect b)
    {
        float xMin = Mathf.Min(a.xMin, b.xMin);
        float zMin = Mathf.Min(a.yMin, b.yMin);
        float xMax = Mathf.Max(a.xMax, b.xMax);
        float zMax = Mathf.Max(a.yMax, b.yMax);
        return new Rect(xMin, zMin, xMax - xMin, zMax - zMin);
    }

    private static float GappedDist(Rect a, Rect b)
    {
        float dx = Mathf.Max(0f, Mathf.Max(a.xMin - b.xMax, b.xMin - a.xMax));
        float dz = Mathf.Max(0f, Mathf.Max(a.yMin - b.yMax, b.yMin - a.yMax));
        return Mathf.Sqrt(dx * dx + dz * dz);
    }

    private static bool InsideAnyRect(List<Rect> rects, float tx, float tz)
    {
        for (int i = 0; i < rects.Count; i++)
        {
            if (rects[i].Contains(new Vector2(tx, tz)))
            {
                return true;
            }
        }
        return false;
    }

    private static List<int> AllowedTreePrototypes(TerrainData data)
    {
        var allowed = new List<int>();
        for (int i = 0; i < data.treePrototypes.Length; i++)
        {
            var proto = data.treePrototypes[i];
            if (proto.prefab == null)
            {
                continue;
            }
            string n = proto.prefab.name.ToLowerInvariant();
            if (n.Contains("riceplant") || n.Contains("vegetable"))
            {
                continue;
            }
            allowed.Add(i);
        }
        if (allowed.Count == 0)
        {
            allowed.Add(0);
        }
        return allowed;
    }
}