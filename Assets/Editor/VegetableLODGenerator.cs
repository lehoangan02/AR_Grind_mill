using UnityEngine;
using UnityEditor;
using System.IO;
using UnityMeshSimplifier;

public class VegetableLODGenerator
{
    [MenuItem("Tools/Apply LOD to Vegetable")]
    public static void ApplyLOD()
    {
        string prefabPath = "Assets/MyFolder/Prefabs/Rau1/Vegetable.prefab";
        GameObject oldPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        if (oldPrefab == null)
        {
            Debug.LogError("Prefab not found at " + prefabPath);
            return;
        }

        GameObject oldInstance = (GameObject)PrefabUtility.InstantiatePrefab(oldPrefab);
        
        // Find the mesh and material from the old instance
        MeshFilter oldMf = oldInstance.GetComponentInChildren<MeshFilter>();
        MeshRenderer oldMr = oldInstance.GetComponentInChildren<MeshRenderer>();
        
        if (oldMf == null || oldMr == null)
        {
            Debug.LogError("No mesh found in the prefab!");
            Object.DestroyImmediate(oldInstance);
            return;
        }

        Mesh originalMesh = oldMf.sharedMesh;
        Material[] materials = oldMr.sharedMaterials;
        
        // Grab the rotation/position of the object that has the mesh
        Vector3 pos = oldMf.transform.localPosition;
        Quaternion rot = oldMf.transform.localRotation;
        Vector3 scale = oldMf.transform.localScale;

        // Simplify Mesh - LOD1 (50% quality)
        var simplifierLOD1 = new MeshSimplifier();
        simplifierLOD1.Initialize(originalMesh);
        simplifierLOD1.SimplifyMesh(0.5f);
        Mesh meshLOD1 = simplifierLOD1.ToMesh();
        meshLOD1.name = originalMesh.name + "_LOD1";
        AssetDatabase.CreateAsset(meshLOD1, "Assets/MyFolder/Prefabs/Rau1/Vegetable_LOD1.asset");

        // Simplify Mesh - LOD2 (20% quality)
        var simplifierLOD2 = new MeshSimplifier();
        simplifierLOD2.Initialize(originalMesh);
        simplifierLOD2.SimplifyMesh(0.2f);
        Mesh meshLOD2 = simplifierLOD2.ToMesh();
        meshLOD2.name = originalMesh.name + "_LOD2";
        AssetDatabase.CreateAsset(meshLOD2, "Assets/MyFolder/Prefabs/Rau1/Vegetable_LOD2.asset");

        // Create a BRAND NEW empty root GameObject
        // Terrain engine places the root object and ignores its rotation.
        // We put the -90 rotation on the children instead!
        GameObject newRoot = new GameObject("Vegetable");

        GameObject lod0 = new GameObject("Vegetable_LOD0");
        lod0.transform.SetParent(newRoot.transform, false);
        lod0.transform.localPosition = pos;
        lod0.transform.localRotation = rot; // Keeps the mesh upright relative to root!
        lod0.transform.localScale = scale;
        MeshFilter mf0 = lod0.AddComponent<MeshFilter>();
        mf0.sharedMesh = originalMesh;
        MeshRenderer mr0 = lod0.AddComponent<MeshRenderer>();
        mr0.sharedMaterials = materials;

        GameObject lod1 = new GameObject("Vegetable_LOD1");
        lod1.transform.SetParent(newRoot.transform, false);
        lod1.transform.localPosition = pos;
        lod1.transform.localRotation = rot;
        lod1.transform.localScale = scale;
        MeshFilter mf1 = lod1.AddComponent<MeshFilter>();
        mf1.sharedMesh = meshLOD1;
        MeshRenderer mr1 = lod1.AddComponent<MeshRenderer>();
        mr1.sharedMaterials = materials;

        GameObject lod2 = new GameObject("Vegetable_LOD2");
        lod2.transform.SetParent(newRoot.transform, false);
        lod2.transform.localPosition = pos;
        lod2.transform.localRotation = rot;
        lod2.transform.localScale = scale;
        MeshFilter mf2 = lod2.AddComponent<MeshFilter>();
        mf2.sharedMesh = meshLOD2;
        MeshRenderer mr2 = lod2.AddComponent<MeshRenderer>();
        mr2.sharedMaterials = materials;

        // Add LODGroup to the new root
        LODGroup lodGroup = newRoot.AddComponent<LODGroup>();

        LOD[] lods = new LOD[3];
        lods[0] = new LOD(0.6f, new Renderer[] { mr0 });
        lods[1] = new LOD(0.3f, new Renderer[] { mr1 });
        // Set cutoff to 0.005f (0.5% screen height) so it stays visible extremely far away!
        lods[2] = new LOD(0.005f, new Renderer[] { mr2 });
        lodGroup.SetLODs(lods);
        lodGroup.RecalculateBounds();

        // Save the completely rebuilt prefab
        PrefabUtility.SaveAsPrefabAsset(newRoot, prefabPath);
        
        Object.DestroyImmediate(oldInstance);
        Object.DestroyImmediate(newRoot);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("Successfully fixed sideways rotation and LOD culling distance!");
    }
}
