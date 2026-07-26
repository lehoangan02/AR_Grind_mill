using UnityEngine;
using UnityEditor;

public class FixTerrainTrees : EditorWindow
{
    [MenuItem("Tools/Fix Terrain Missing Trees")]
    public static void FixMissingTrees()
    {
        Terrain[] terrains = Object.FindObjectsOfType<Terrain>();
        int fixedCount = 0;

        foreach (Terrain t in terrains)
        {
            if (t.terrainData != null)
            {
                // Create a new list of valid prototypes
                var oldProtos = t.terrainData.treePrototypes;
                var newProtos = new System.Collections.Generic.List<TreePrototype>();

                bool changed = false;
                foreach (var proto in oldProtos)
                {
                    if (proto.prefab == null)
                    {
                        changed = true; // Found a missing one!
                    }
                    else
                    {
                        newProtos.Add(proto);
                    }
                }

                if (changed)
                {
                    t.terrainData.treePrototypes = newProtos.ToArray();
                    t.Flush(); // Apply changes
                    EditorUtility.SetDirty(t.terrainData);
                    fixedCount++;
                }
            }
        }

        if (fixedCount > 0)
        {
            Debug.Log($"Successfully removed missing tree prototypes from {fixedCount} terrain(s)!");
        }
        else
        {
            Debug.Log("No missing trees found. If the error still happens, make sure you are painting a real Unity .prefab file, not just an .fbx!");
        }
    }
}
