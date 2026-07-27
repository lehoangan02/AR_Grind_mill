using UnityEngine;
using UnityEditor;
using System.IO;

public class UpgradeRau2MaterialsURP
{
    [MenuItem("Tools/Upgrade Rau2 Materials to URP")]
    public static void UpgradeMaterials()
    {
        string mapsPath = "Assets/MyFolder/Prefabs/Rau2/Scene/Maps/";
        string texPath = mapsPath + "Textures/";
        string[] matNames = { "Leaves01", "Leaves02", "Bark01", "Flowers01" };
        
        Shader urpLit = Shader.Find("Universal Render Pipeline/Lit");
        if (urpLit == null)
        {
            Debug.LogError("URP Lit shader not found!");
            return;
        }

        foreach (string matName in matNames)
        {
            string matPath = mapsPath + "Mat/" + matName + ".mat";
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(matPath);
            if (mat == null) continue;

            mat.shader = urpLit;
            
            // Determine texture prefix based on material name
            string texPrefix = "T_MelaleucaAlternifolia";
            if (matName.StartsWith("Leaves"))
            {
                string variant = matName.Replace("Leaves", "");
                texPrefix += "SummerLeaves" + variant;
                
                // Leaves need alpha clipping
                mat.SetFloat("_AlphaClip", 1);
                mat.EnableKeyword("_ALPHATEST_ON");
                mat.SetFloat("_Cutoff", 0.33f);
                
                // Double sided
                mat.doubleSidedGI = true;
                mat.SetFloat("_Cull", 0); // Off
            }
            else if (matName.StartsWith("Bark"))
            {
                string variant = matName.Replace("Bark", "");
                texPrefix += "Bark" + variant;
                mat.SetFloat("_Cull", 2); // Back
            }
            else if (matName.StartsWith("Flowers"))
            {
                string variant = matName.Replace("Flowers", "");
                texPrefix += "Flowers" + variant;
                mat.SetFloat("_AlphaClip", 1);
                mat.EnableKeyword("_ALPHATEST_ON");
                mat.SetFloat("_Cutoff", 0.5f);
                mat.doubleSidedGI = true;
                mat.SetFloat("_Cull", 0);
            }

            // Find and assign textures
            Texture2D bcTex = AssetDatabase.LoadAssetAtPath<Texture2D>(texPath + texPrefix + "_BC.png");
            Texture2D nTex = AssetDatabase.LoadAssetAtPath<Texture2D>(texPath + texPrefix + "_N.png");
            Texture2D mTex = AssetDatabase.LoadAssetAtPath<Texture2D>(texPath + texPrefix + "_M.png");
            
            if (bcTex != null) mat.SetTexture("_BaseMap", bcTex);
            if (nTex != null)
            {
                mat.SetTexture("_BumpMap", nTex);
                mat.EnableKeyword("_NORMALMAP");
            }
            if (mTex != null)
            {
                mat.SetTexture("_MetallicGlossMap", mTex);
                mat.EnableKeyword("_METALLICSPECGLOSSMAP");
            }
            
            // Set base color white so textures show properly
            mat.SetColor("_BaseColor", Color.white);
            
            EditorUtility.SetDirty(mat);
            Debug.Log("Upgraded " + matName + " to URP Lit.");
        }
        
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("All Rau2 materials upgraded to URP!");
    }
}
