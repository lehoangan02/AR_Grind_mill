using UnityEngine;
using UnityEditor;
using System.IO;

public class Rau2PrefabBuilder
{
    [MenuItem("Tools/Build Rau2 Prefabs")]
    public static void BuildPrefabs()
    {
        string mapsPath = "Assets/MyFolder/Prefabs/Rau2/Scene/Maps/";
        string[] matNames = { "Leaves01", "Leaves02", "Bark01", "Flowers01" };
        
        // 2. Build Prefabs
        string[] variants = { "A", "M", "Y" };
        string basePath = "Assets/MyFolder/Prefabs/Rau2/Scene/Models/";
        string prefabOutPath = "Assets/MyFolder/Prefabs/Rau2/";

        foreach (string variant in variants)
        {
            string prefabName = "MelaleucaAlternifolia_" + variant + ".prefab";
            GameObject root = new GameObject("MelaleucaAlternifolia_" + variant);

            LODGroup lodGroup = root.AddComponent<LODGroup>();
            LOD[] lods = new LOD[3];
            float[] transitions = { 0.6f, 0.3f, 0.005f };

            for (int i = 0; i < 3; i++)
            {
                string fbxPath = basePath + "MESH_OC56_MelaleucaAlternifolia_" + variant + "_LOD" + i + ".fbx";
                GameObject fbxAsset = AssetDatabase.LoadAssetAtPath<GameObject>(fbxPath);
                
                if (fbxAsset == null) continue;

                GameObject lodInst = (GameObject)PrefabUtility.InstantiatePrefab(fbxAsset);
                lodInst.name = "LOD" + i;
                lodInst.transform.SetParent(root.transform, false);
                
                // Push the mesh downwards so the roots are underground when painted on terrain!
                float sinkDepth = -0.8f; 
                lodInst.transform.localPosition = new Vector3(0, sinkDepth, 0);

                // Fix Materials on Renderers
                Renderer[] renderers = lodInst.GetComponentsInChildren<Renderer>();
                foreach (Renderer r in renderers)
                {
                    Material[] sharedMats = r.sharedMaterials;
                    for (int m = 0; m < sharedMats.Length; m++)
                    {
                        string slotName = sharedMats[m] != null ? sharedMats[m].name : "";
                        // If it has MI_ prefix (like MI_Bark01), strip it
                        if (slotName.StartsWith("MI_")) slotName = slotName.Substring(3);
                        // In case it's completely missing, we might have to rely on the mesh's submesh name,
                        // but Unity usually creates a dummy material with the slot name.
                        
                        // Load the correct material
                        string matPath = mapsPath + "Mat/" + slotName + ".mat";
                        Material correctMat = AssetDatabase.LoadAssetAtPath<Material>(matPath);
                        if (correctMat != null)
                        {
                            sharedMats[m] = correctMat;
                        }
                    }
                    r.sharedMaterials = sharedMats;
                }
                
                lods[i] = new LOD(transitions[i], renderers);
            }

            lodGroup.SetLODs(lods);
            lodGroup.RecalculateBounds();

            PrefabUtility.SaveAsPrefabAsset(root, prefabOutPath + prefabName);
            Object.DestroyImmediate(root);
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("Successfully built Rau2 prefabs and fixed materials!");
    }
}
