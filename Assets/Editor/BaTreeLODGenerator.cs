using UnityEngine;
using UnityEditor;
using UnityMeshSimplifier;
using System.Collections.Generic;

public class BaTreeLODGenerator
{
    [MenuItem("Tools/Fix BaTrees (Generate LODs)")]
    public static void FixBaTrees()
    {
        for (int i = 1; i <= 3; i++)
        {
            string prefabPath = "Assets/_Environment/Banana/Prefab/BaTree" + i + ".prefab";
            GameObject oldPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            if (oldPrefab == null) continue;

            GameObject oldInstance = (GameObject)PrefabUtility.InstantiatePrefab(oldPrefab);
            PrefabUtility.UnpackPrefabInstance(oldInstance, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);

            // Create a brand new clean root
            GameObject newRoot = new GameObject("BaTree" + i);
            
            // Copy custom components from the OLD ROOT ONLY (e.g. BananaTreeWind, Colliders)
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
            lod0.transform.SetParent(newRoot.transform, false);
            lod0.transform.localPosition = Vector3.zero;
            CleanRoot(lod0);

            // LOD1
            GameObject lod1 = Object.Instantiate(oldInstance);
            lod1.name = "LOD1";
            lod1.transform.SetParent(newRoot.transform, false);
            lod1.transform.localPosition = Vector3.zero;
            CleanRoot(lod1);
            SimplifyAllMeshes(lod1, 0.5f, i, "LOD1");

            // LOD2
            GameObject lod2 = Object.Instantiate(oldInstance);
            lod2.name = "LOD2";
            lod2.transform.SetParent(newRoot.transform, false);
            lod2.transform.localPosition = Vector3.zero;
            CleanRoot(lod2);
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
        Debug.Log("Successfully generated full-hierarchy LODs for BaTree1, 2, and 3!");
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
            string assetPath = "Assets/_Environment/Banana/Prefab/BaTree" + treeIndex + "_" + assetName;
            
            AssetDatabase.CreateAsset(newMesh, assetPath);
            mf.sharedMesh = newMesh;
        }
    }
}
