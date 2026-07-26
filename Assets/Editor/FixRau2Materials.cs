using UnityEngine;
using UnityEditor;

public class FixRau2Materials
{
    [MenuItem("Tools/Fix Rau2 Materials")]
    public static void FixMaterials()
    {
        string basePath = "Assets/MyFolder/Prefabs/Rau2/Scene/Maps/";
        string[] matNames = { "Leaves01", "Leaves02", "Bark01", "Flowers01" };
        
        foreach (string matName in matNames)
        {
            string matPath = basePath + "Mat/" + matName + ".mat";
            string shaderPath = basePath + "Shaders/" + matName + ".shadergraph";
            
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(matPath);
            Shader shader = AssetDatabase.LoadAssetAtPath<Shader>(shaderPath);
            
            if (mat != null && shader != null)
            {
                mat.shader = shader;
                EditorUtility.SetDirty(mat);
                Debug.Log("Fixed shader for " + matName);
            }
            else
            {
                Debug.LogWarning("Could not find material or shader for " + matName);
            }
        }
        
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("All Rau2 materials have been fixed!");
    }
}
