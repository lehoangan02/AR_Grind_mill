using UnityEngine;
using UnityEditor;

public class HousePrefabBuilder
{
    [MenuItem("Tools/Build House Prefab")]
    public static void BuildPrefab()
    {
        string folderPath = "Assets/MyFolder/Prefabs/houses/stilt-house-in-denhung-cantho-vietnam";
        string objPath = folderPath + "/source/Md_WoodHouse.obj";
        
        // Load the OBJ
        GameObject objModel = AssetDatabase.LoadAssetAtPath<GameObject>(objPath);
        if (objModel == null)
        {
            Debug.LogError("Could not find OBJ at " + objPath);
            return;
        }

        // Create the Material
        Material mat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        
        Texture2D baseColor = AssetDatabase.LoadAssetAtPath<Texture2D>(folderPath + "/textures/House_fbx_lambert1_BaseColor.png");
        Texture2D normalMap = AssetDatabase.LoadAssetAtPath<Texture2D>(folderPath + "/textures/House_fbx_lambert1_Normal.png");

        if (baseColor != null) 
        {
            mat.SetTexture("_BaseMap", baseColor);
        }
        
        if (normalMap != null) 
        {
            mat.SetTexture("_BumpMap", normalMap);
            mat.EnableKeyword("_NORMALMAP");
        }

        // Setup some basic defaults for wood/house materials
        mat.SetFloat("_Smoothness", 0.1f); // Wood/Thatch is generally rough
        mat.SetFloat("_Metallic", 0.0f);

        // Save Material
        string matPath = folderPath + "/WoodHouse_Material.mat";
        AssetDatabase.CreateAsset(mat, matPath);

        // Instantiate object to build prefab
        GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(objModel);
        PrefabUtility.UnpackPrefabInstance(instance, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
        
        // Name the root properly
        instance.name = "StiltHouse";

        // Add colliders and set material
        MeshRenderer[] renderers = instance.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer r in renderers)
        {
            r.sharedMaterial = mat;
            
            MeshFilter mf = r.GetComponent<MeshFilter>();
            if (mf != null)
            {
                MeshCollider mc = r.gameObject.AddComponent<MeshCollider>();
                mc.sharedMesh = mf.sharedMesh;
            }
        }

        // Fix potential normal map import settings
        TextureImporter importer = (TextureImporter)AssetImporter.GetAtPath(folderPath + "/textures/House_fbx_lambert1_Normal.png");
        if (importer != null && importer.textureType != TextureImporterType.NormalMap)
        {
            importer.textureType = TextureImporterType.NormalMap;
            importer.SaveAndReimport();
        }

        // Save as Prefab
        string prefabSavePath = folderPath + "/StiltHouse.prefab";
        PrefabUtility.SaveAsPrefabAsset(instance, prefabSavePath);
        
        // Cleanup
        Object.DestroyImmediate(instance);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        
        Debug.Log("House Prefab built successfully at " + prefabSavePath);
    }
}
