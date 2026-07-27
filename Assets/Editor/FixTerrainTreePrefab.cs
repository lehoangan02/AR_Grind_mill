using UnityEngine;
using UnityEditor;
using System.Linq;

public class FixTerrainTreePrefab
{
    [MenuItem("Tools/Fix Terrain Tree Prefab")]
    public static void FixSelectedPrefab()
    {
        // Get the currently selected object
        GameObject obj = Selection.activeGameObject;
        if (obj == null)
        {
            Debug.LogWarning("Please select a tree prefab in the Project window first.");
            return;
        }

        string assetPath = AssetDatabase.GetAssetPath(obj);
        if (string.IsNullOrEmpty(assetPath) || !assetPath.EndsWith(".prefab"))
        {
            Debug.LogWarning("Please select a valid Prefab in the Project Window.");
            return;
        }

        // Open the prefab for editing
        using (var editingScope = new PrefabUtility.EditPrefabContentsScope(assetPath))
        {
            GameObject prefabRoot = editingScope.prefabContentsRoot;

            // Add LODGroup if it doesn't exist
            LODGroup lodGroup = prefabRoot.GetComponent<LODGroup>();
            if (lodGroup == null)
            {
                lodGroup = prefabRoot.AddComponent<LODGroup>();
            }

            // Get all mesh renderers in the prefab and its children
            MeshRenderer[] renderers = prefabRoot.GetComponentsInChildren<MeshRenderer>();
            
            if (renderers.Length == 0)
            {
                Debug.LogWarning("No MeshRenderers found in the selected prefab or its children.");
                return;
            }

            // Create a single LOD level (LOD 0) that includes all renderers
            // The value 0.01f means it will only be culled when it's very far away
            LOD[] lods = new LOD[1];
            lods[0] = new LOD(0.01f, renderers);
            
            // Assign the LODs to the group and recalculate its bounds
            lodGroup.SetLODs(lods);
            lodGroup.RecalculateBounds();

            Debug.Log($"Successfully fixed Terrain Tree Prefab: {obj.name}. Added {renderers.Length} renderers to LOD 0.");
        }
    }
}
