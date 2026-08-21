using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;
using System.Text;

public class TreeDimensionsAnalyzer
{
    public static void MeasureDimensions()
    {
        string scenePath = "Assets/Scenes/Grind mill v1.0 Scene.unity";
        EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);

        string outPath = Path.Combine(Application.dataPath, "../TreeDimensionsReport.txt");
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("=== REAL-WORLD REFERENCE & TREE PREFAB SIZE ANALYSIS ===");

        // 1. Measure Reference Scene Objects
        sb.AppendLine("\n[1. REFERENCE SCENE OBJECTS SIZES]");
        string[] referenceNames = { "StiltHouse", "House", "Brick2", "Pigsty", "Cow", "WaterBuffalo", "Dog_001", "Chicken_001", "Cock", "table", "TestTable", "WaterJar1" };
        foreach (var name in referenceNames)
        {
            GameObject go = GameObject.Find(name);
            if (go != null)
            {
                Bounds b = GetObjectBounds(go);
                sb.AppendLine($"  Reference '{name}': Width(X)={b.size.x:F2}m, Height(Y)={b.size.y:F2}m, Length(Z)={b.size.z:F2}m");
            }
            else
            {
                sb.AppendLine($"  Reference '{name}': NOT FOUND");
            }
        }

        // 2. Measure All Tree Prototypes in Main Terrain
        sb.AppendLine("\n[2. RAW TREE PREFAB BOUNDS (AT SCALE 1.0)]");
        Terrain mainTerrain = null;
        foreach (var t in Object.FindObjectsByType<Terrain>(FindObjectsInactive.Include, FindObjectsSortMode.None))
        {
            if (t.name == "Terrain") mainTerrain = t;
        }

        if (mainTerrain != null)
        {
            for (int i = 0; i < mainTerrain.terrainData.treePrototypes.Length; i++)
            {
                var proto = mainTerrain.terrainData.treePrototypes[i];
                if (proto.prefab != null)
                {
                    GameObject temp = (GameObject)PrefabUtility.InstantiatePrefab(proto.prefab);
                    temp.transform.position = Vector3.zero;
                    temp.transform.rotation = Quaternion.identity;
                    temp.transform.localScale = Vector3.one;

                    Bounds b = GetObjectBounds(temp);
                    sb.AppendLine($"  Prototype [{i,2}] '{proto.prefab.name}': Width(X)={b.size.x:F2}m, Height(Y)={b.size.y:F2}m, Depth(Z)={b.size.z:F2}m");

                    Object.DestroyImmediate(temp);
                }
            }
        }

        File.WriteAllText(outPath, sb.ToString());
        Debug.Log("Tree dimensions analysis written to " + outPath);
    }

    private static Bounds GetObjectBounds(GameObject go)
    {
        Bounds b = new Bounds(go.transform.position, Vector3.zero);
        bool hasBounds = false;

        foreach (var r in go.GetComponentsInChildren<Renderer>())
        {
            if (!r.enabled || r.gameObject.name.ToLower().Contains("water")) continue;
            if (!hasBounds) { b = r.bounds; hasBounds = true; }
            else b.Encapsulate(r.bounds);
        }
        foreach (var c in go.GetComponentsInChildren<Collider>())
        {
            if (!c.enabled) continue;
            if (!hasBounds) { b = c.bounds; hasBounds = true; }
            else b.Encapsulate(c.bounds);
        }

        return b;
    }
}
