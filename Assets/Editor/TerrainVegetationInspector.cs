using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class TerrainVegetationInspector
{
    public static void RunInspection()
    {
        string scenePath = "Assets/Scenes/Grind mill v1.0 Scene.unity";
        EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);

        string logPath = Path.Combine(Application.dataPath, "../TerrainInspectionReport.txt");
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("=== TERRAIN & ENVIRONMENT DETAILED INSPECTION REPORT ===");
        sb.AppendLine($"Scene: {EditorSceneManager.GetActiveScene().name} ({scenePath})");

        // Find TerainParent or all Terrains
        Terrain[] terrains = Object.FindObjectsByType<Terrain>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        sb.AppendLine($"\nTotal Terrains in Scene: {terrains.Length}");

        foreach (var t in terrains)
        {
            sb.AppendLine($"\n========================================================");
            sb.AppendLine($"Terrain GameObject: '{t.gameObject.name}' (Active: {t.gameObject.activeInHierarchy})");
            sb.AppendLine($"Transform Position: {t.transform.position}, Rotation: {t.transform.eulerAngles}, LocalScale: {t.transform.localScale}");
            var td = t.terrainData;
            if (td == null)
            {
                sb.AppendLine("  terrainData is NULL!");
                continue;
            }
            sb.AppendLine($"TerrainData Asset: {AssetDatabase.GetAssetPath(td)} (GUID: {AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(td))})");
            sb.AppendLine($"Size: X={td.size.x}, Y={td.size.y}, Z={td.size.z}");
            sb.AppendLine($"Heightmap Res: {td.heightmapResolution}, Alphamap Res: {td.alphamapResolution}, Detail Res: {td.detailResolution}");
            sb.AppendLine($"Tree Instances Count: {td.treeInstanceCount}");

            sb.AppendLine($"\nTerrain Layers ({td.terrainLayers.Length}):");
            for (int i = 0; i < td.terrainLayers.Length; i++)
            {
                var layer = td.terrainLayers[i];
                if (layer != null)
                {
                    sb.AppendLine($"  Layer [{i}]: '{layer.name}', Diffuse: {(layer.diffuseTexture != null ? layer.diffuseTexture.name : "null")}, TileSize: {layer.tileSize}");
                }
                else
                {
                    sb.AppendLine($"  Layer [{i}]: NULL");
                }
            }

            sb.AppendLine($"\nTree Prototypes ({td.treePrototypes.Length}):");
            for (int i = 0; i < td.treePrototypes.Length; i++)
            {
                var proto = td.treePrototypes[i];
                if (proto.prefab != null)
                {
                    sb.AppendLine($"  Prototype [{i}]: Prefab='{proto.prefab.name}' (Path: {AssetDatabase.GetAssetPath(proto.prefab)}), BendFactor={proto.bendFactor}");
                }
                else
                {
                    sb.AppendLine($"  Prototype [{i}]: Prefab=NULL");
                }
            }

            // Summary of existing tree instances by prototype
            Dictionary<int, int> countByProto = new Dictionary<int, int>();
            foreach (var inst in td.treeInstances)
            {
                if (!countByProto.ContainsKey(inst.prototypeIndex)) countByProto[inst.prototypeIndex] = 0;
                countByProto[inst.prototypeIndex]++;
            }
            sb.AppendLine($"\nExisting Tree Distribution on '{t.gameObject.name}':");
            foreach (var kvp in countByProto)
            {
                string protoName = (kvp.Key >= 0 && kvp.Key < td.treePrototypes.Length && td.treePrototypes[kvp.Key].prefab != null) ? td.treePrototypes[kvp.Key].prefab.name : "Unknown";
                sb.AppendLine($"  Prototype [{kvp.Key}] ({protoName}): {kvp.Value} instances");
            }
        }

        sb.AppendLine("\n========================================================");
        sb.AppendLine("=== SCENE OBJECTS & KEY LANDMARKS ===");
        GameObject[] rootObjects = EditorSceneManager.GetActiveScene().GetRootGameObjects();
        foreach (var root in rootObjects)
        {
            InspectGameObjectRecursive(root, sb, 0);
        }

        File.WriteAllText(logPath, sb.ToString());
        Debug.Log($"Terrain detailed inspection report written to: {logPath}");
    }

    private static void InspectGameObjectRecursive(GameObject go, StringBuilder sb, int depth)
    {
        string indent = new string(' ', depth * 2);
        Renderer r = go.GetComponent<Renderer>();
        Collider c = go.GetComponent<Collider>();
        string boundsStr = "";
        if (r != null)
        {
            boundsStr = $" [Renderer Bounds center: {r.bounds.center:F1}, size: {r.bounds.size:F1}]";
        }
        else if (c != null)
        {
            boundsStr = $" [Collider Bounds center: {c.bounds.center:F1}, size: {c.bounds.size:F1}]";
        }

        sb.AppendLine($"{indent}- '{go.name}' (Pos: {go.transform.position:F1}, Active: {go.activeSelf}){boundsStr}");

        for (int i = 0; i < go.transform.childCount; i++)
        {
            InspectGameObjectRecursive(go.transform.GetChild(i).gameObject, sb, depth + 1);
        }
    }
}
