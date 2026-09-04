using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class MapSpatialAnalyzer
{
    public static void AnalyzeMap()
    {
        string scenePath = "Assets/Scenes/Grind mill v1.0 Scene.unity";
        EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);

        string outPath = Path.Combine(Application.dataPath, "../MapSpatialAnalysis.txt");
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("=== VIETNAMESE COUNTRYSIDE SPATIAL MAP ANALYSIS ===");

        // Collect all colliders / renderers of non-terrain objects to identify forbidden zones (buildings, paths, farm plots, animals, player)
        GameObject[] roots = EditorSceneManager.GetActiveScene().GetRootGameObjects();
        sb.AppendLine("\n[FORBIDDEN / INTERACTIVE ZONES & BOUNDS]");
        foreach (var root in roots)
        {
            if (root.name.Contains("Terrain") || root.name.Contains("Light") || root.name == "EventSystem") continue;
            
            Bounds b = new Bounds(root.transform.position, Vector3.zero);
            bool hasBounds = false;
            foreach (var r in root.GetComponentsInChildren<Renderer>())
            {
                if (!hasBounds) { b = r.bounds; hasBounds = true; }
                else b.Encapsulate(r.bounds);
            }
            foreach (var c in root.GetComponentsInChildren<Collider>())
            {
                if (!hasBounds) { b = c.bounds; hasBounds = true; }
                else b.Encapsulate(c.bounds);
            }

            if (hasBounds)
            {
                sb.AppendLine($"Landmark: '{root.name}' | Center: ({b.center.x:F1}, {b.center.y:F1}, {b.center.z:F1}) | Size: ({b.size.x:F1}, {b.size.y:F1}, {b.size.z:F1}) | Min: ({b.min.x:F1}, {b.min.z:F1}) Max: ({b.max.x:F1}, {b.max.z:F1})");
            }
        }

        // Terrain analysis
        Terrain[] terrains = Object.FindObjectsByType<Terrain>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        sb.AppendLine("\n[TERRAIN ELEVATION, WATER & SPLATMAP SUMMARY]");
        foreach (var t in terrains)
        {
            var td = t.terrainData;
            float minH = float.MaxValue;
            float maxH = float.MinValue;
            float[,] heights = td.GetHeights(0, 0, td.heightmapResolution, td.heightmapResolution);
            for (int y = 0; y < td.heightmapResolution; y += 10)
            {
                for (int x = 0; x < td.heightmapResolution; x += 10)
                {
                    float h = heights[y, x] * td.size.y + t.transform.position.y;
                    if (h < minH) minH = h;
                    if (h > maxH) maxH = h;
                }
            }

            sb.AppendLine($"\nTerrain: '{t.name}' Pos: {t.transform.position}, World Bounds: X=[{t.transform.position.x:F0}, {t.transform.position.x + td.size.x:F0}], Z=[{t.transform.position.z:F0}, {t.transform.position.z + td.size.z:F0}]");
            sb.AppendLine($"  Height Range: [{minH:F1}m to {maxH:F1}m]");
            sb.AppendLine($"  Alphamap Res: {td.alphamapResolution}, Layers count: {td.terrainLayers.Length}");
        }

        // Tree palette categorization
        Terrain mainTerrain = null;
        foreach (var t in terrains) if (t.name == "Terrain") mainTerrain = t;
        if (mainTerrain != null)
        {
            sb.AppendLine("\n[ALL TREE PROTOTYPES ON MAIN TERRAIN]");
            for (int i = 0; i < mainTerrain.terrainData.treePrototypes.Length; i++)
            {
                var p = mainTerrain.terrainData.treePrototypes[i];
                string name = p.prefab != null ? p.prefab.name : "null";
                sb.AppendLine($"Index {i,2}: {name}");
            }
        }

        File.WriteAllText(outPath, sb.ToString());
        Debug.Log("Spatial analysis written to " + outPath);
    }
}
