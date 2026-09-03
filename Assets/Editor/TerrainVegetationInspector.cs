using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System;

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

        Terrain[] terrains = UnityEngine.Object.FindObjectsByType<Terrain>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        sb.AppendLine($"\nTotal Terrains in Scene: {terrains.Length}");

        foreach (var t in terrains)
        {
            sb.AppendLine("\n========================================================");
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
            boundsStr = $@" [Renderer Bounds center: {r.bounds.center:F1}, size: {r.bounds.size:F1}]";
        }
        else if (c != null)
        {
            boundsStr = $@" [Collider Bounds: center {c.bounds.center:F1}, size {c.bounds.size:F1}]";
        }

        sb.AppendLine($@"{indent}- '{go.name}' (Pos: {go.transform.position:F1}, Active: {go.activeSelf}){boundsStr}");

        for (int i = 0; i < go.transform.childCount; i++)
        {
            InspectGameObjectRecursive(go.transform.GetChild(i).gameObject, sb, depth + 1);
        }
    }

    /// <summary>
    /// Restructures TreeInstances on the 4 terrains of the main scene:
    ///   - "Terrain" and "Terrain_(-1000.00, 0.00, 0.00)": remove ALL trees.
    ///   - The remaining two terrains: keep only every 3rd tree (reduce density).
    /// Run from Unity CLI: -executeMethod TerrainVegetationInspector.RunTreePolicy
    /// </summary>
    [MenuItem("Tools/Terrain/Apply Tree Policy (clear 2, reduce 2)")]
    public static void RunTreePolicy()
    {
        string scenePath = "Assets/Scenes/Grind mill v1.0 Scene.unity";
        EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);

        string[] clearNames =
        {
            "Terrain",
            "Terrain_(-1000.00, 0.00, 0.00)"
        };

        var builder = new StringBuilder();
        builder.AppendLine("=== TREE POLICY APPLY ===");

        Terrain[] terrains = UnityEngine.Object.FindObjectsByType<Terrain>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (Terrain terrain in terrains)
        {
            TerrainData data = terrain.terrainData;
            if (data == null)
            {
                builder.AppendLine($"- '{terrain.name}': terrainData is NULL, skipped.");
                continue;
            }

            int before = data.treeInstanceCount;
            string action;
            bool isClearTarget = false;
            for (int i = 0; i < clearNames.Length; i++)
            {
                if (terrain.name == clearNames[i])
                {
                    isClearTarget = true;
                    break;
                }
            }

            Undo.RegisterCompleteObjectUndo(data, "Terrain Tree Policy");

            if (isClearTarget)
            {
                // Remove every tree on this terrain.
                data.SetTreeInstances(Array.Empty<TreeInstance>(), snapToHeightmap: false);
                action = "CLEAR (remove all trees)";
            }
            else
            {
                // Reduce density: keep every 3rd tree.
                TreeInstance[] current = data.treeInstances;
                var kept = new List<TreeInstance>((current.Length + 2) / 3);
                for (int idx = 0; idx < current.Length; idx++)
                {
                    if (idx % 3 == 0)
                    {
                        kept.Add(current[idx]);
                    }
                }

                data.SetTreeInstances(kept.ToArray(), snapToHeightmap: false);
                action = "REDUCE (keep every 3rd tree)";
            }

            EditorUtility.SetDirty(data);
            EditorUtility.SetDirty(terrain);
            builder.AppendLine($"- '{terrain.name}': {action}  trees {before} -> {data.treeInstanceCount}");
        }

        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        if (!EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene()))
        {
            Debug.LogError("Tree policy: failed to save the scene.");
        }
        AssetDatabase.SaveAssets();

        string summary = builder.ToString();
        Debug.Log(summary);
        if (!Application.isBatchMode)
        {
            EditorUtility.DisplayDialog("Terrain Tree Policy", summary, "OK");
        }
    }
}