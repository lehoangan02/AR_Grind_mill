using UnityEngine;
using UnityEditor;
using UnityMeshSimplifier;
using System.Collections.Generic;

public class BambooLODGenerator
{
    [MenuItem("Tools/Fix Bamboo (Generate LODs & Fix Rotation)")]
    public static void FixBamboo()
    {
        for (int i = 1; i <= 5; i++)
        {
            string prefabPath = "Assets/_Environment/Bamboo/Prefab/TreeBush" + i + ".prefab";
            GameObject oldPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            if (oldPrefab == null) continue;

            GameObject oldInstance = (GameObject)PrefabUtility.InstantiatePrefab(oldPrefab);
            PrefabUtility.UnpackPrefabInstance(oldInstance, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);

            // Create a brand new clean root with absolute zero rotation and position.
            // This is critical because Unity Terrain paints objects using the ROOT transform,
            // completely ignoring any rotation on it. We must put the rotation on the child!
            GameObject newRoot = new GameObject("TreeBush" + i);
            newRoot.transform.position = Vector3.zero;
            newRoot.transform.rotation = Quaternion.identity;
            
            // Copy custom components from the OLD ROOT ONLY (e.g. TreeSimulation, Colliders)
            foreach (Component comp in oldInstance.GetComponents<Component>())
            {
                if (comp is Transform || comp is MeshFilter || comp is MeshRenderer || comp is LODGroup)
                    continue;

                UnityEditorInternal.ComponentUtility.CopyComponent(comp);
                UnityEditorInternal.ComponentUtility.PasteComponentAsNew(newRoot);
            }

            // LOD0
            GameObject lod0 = Object.Instantiate(oldInstance);
            lod0.name = "LOD0";
            // 'false' keeps the local position and rotation from oldInstance, which fixes the upside-down issue!
            lod0.transform.SetParent(newRoot.transform, false); 
            CleanRoot(lod0);
            
            // Calculate the actual visual offset of the geometry to ensure it spawns directly under the brush
            Vector3 visualOffset = GetVisualCenterXZ(lod0);
            
            // Adjust the local position to perfectly center the bamboo horizontally, while preserving its height and rotation
            lod0.transform.localPosition = lod0.transform.localPosition - visualOffset;

            // LOD1
            GameObject lod1 = Object.Instantiate(oldInstance);
            lod1.name = "LOD1";
            lod1.transform.SetParent(newRoot.transform, false);
            CleanRoot(lod1);
            lod1.transform.localPosition = lod1.transform.localPosition - visualOffset;
            SimplifyAllMeshes(lod1, 0.5f, i, "LOD1");

            // LOD2
            GameObject lod2 = Object.Instantiate(oldInstance);
            lod2.name = "LOD2";
            lod2.transform.SetParent(newRoot.transform, false);
            CleanRoot(lod2);
            lod2.transform.localPosition = lod2.transform.localPosition - visualOffset;
            SimplifyAllMeshes(lod2, 0.2f, i, "LOD2");

            // Setup LODGroup
            LODGroup lodGroup = newRoot.AddComponent<LODGroup>();
            LOD[] lods = new LOD[3];
            lods[0] = new LOD(0.6f, lod0.GetComponentsInChildren<Renderer>());
            lods[1] = new LOD(0.3f, lod1.GetComponentsInChildren<Renderer>());
            lods[2] = new LOD(0.005f, lod2.GetComponentsInChildren<Renderer>());
            lodGroup.SetLODs(lods);
            lodGroup.RecalculateBounds();

            // Save and clean up
            PrefabUtility.SaveAsPrefabAsset(newRoot, prefabPath);
            Object.DestroyImmediate(oldInstance);
            Object.DestroyImmediate(newRoot);
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("Successfully generated centered and correctly rotated LODs for all TreeBush (Bamboo) prefabs!");
    }

    private static Vector3 GetVisualCenterXZ(GameObject obj)
    {
        Bounds totalBounds = new Bounds();
        bool hasBounds = false;
        
        foreach (Renderer r in obj.GetComponentsInChildren<Renderer>())
        {
            if (!hasBounds)
            {
                totalBounds = r.bounds;
                hasBounds = true;
            }
            else
            {
                totalBounds.Encapsulate(r.bounds);
            }
        }
        
        if (hasBounds)
        {
            // We only want to correct the X and Z shift. 
            // The Y (height) should remain grounded at 0, so we return 0 for Y.
            return new Vector3(totalBounds.center.x, 0, totalBounds.center.z);
        }
        return Vector3.zero;
    }

    private static void CleanRoot(GameObject obj)
    {
        // Remove components from the root of the LOD instance that we already copied to the super-root
        foreach (Component c in obj.GetComponents<Component>())
        {
            if (!(c is Transform || c is MeshFilter || c is MeshRenderer)) 
            {
                Object.DestroyImmediate(c);
            }
        }
    }

    private static void SimplifyAllMeshes(GameObject rootObj, float quality, int treeIndex, string lodName)
    {
        MeshFilter[] mfs = rootObj.GetComponentsInChildren<MeshFilter>();
        foreach (MeshFilter mf in mfs)
        {
            if (mf.sharedMesh == null) continue;
            
            var simplifier = new MeshSimplifier();
            simplifier.Initialize(mf.sharedMesh);
            simplifier.SimplifyMesh(quality);
            Mesh newMesh = simplifier.ToMesh();
            
            string assetName = mf.sharedMesh.name.Replace(":", "_") + "_" + lodName + ".asset";
            string assetPath = "Assets/_Environment/Bamboo/Prefab/TreeBush" + treeIndex + "_" + assetName;
            
            AssetDatabase.CreateAsset(newMesh, assetPath);
            mf.sharedMesh = newMesh;
        }
    }
}
