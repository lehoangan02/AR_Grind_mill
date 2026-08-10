using UnityEngine;
using UnityEditor;
using UnityEngine.XR.Interaction.Toolkit;

namespace Khoa.Farming.Editor
{
    public class FarmingSetupEditor : EditorWindow
    {
        [MenuItem("Khoa/Farming/Setup Farming Prefabs")]
        public static void CreatePrefabs()
        {
            string folderPath = "Assets/Khoa/Prefabs";
            if (!AssetDatabase.IsValidFolder("Assets/Khoa"))
                AssetDatabase.CreateFolder("Assets", "Khoa");
            if (!AssetDatabase.IsValidFolder(folderPath))
                AssetDatabase.CreateFolder("Assets/Khoa", "Prefabs");
            
            string soFolderPath = "Assets/Khoa/ScriptableObjects";
            if (!AssetDatabase.IsValidFolder(soFolderPath))
                AssetDatabase.CreateFolder("Assets/Khoa", "ScriptableObjects");

            // 1. Tạo CropData ScriptableObject
            CropData data = ScriptableObject.CreateInstance<CropData>();
            string dataPath = soFolderPath + "/Rice_Data.asset";
            if (AssetDatabase.LoadAssetAtPath<CropData>(dataPath) == null)
            {
                AssetDatabase.CreateAsset(data, dataPath);
            }
            else
            {
                data = AssetDatabase.LoadAssetAtPath<CropData>(dataPath);
            }

            // 2. Tạo Rice Prefab
            string ricePrefabPath = folderPath + "/Rice_Prefab.prefab";
            if (AssetDatabase.LoadAssetAtPath<GameObject>(ricePrefabPath) == null)
            {
                GameObject riceGO = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                riceGO.name = "Rice_Prefab";
                
                // Chỉnh kích thước cho giống cây mạ
                riceGO.transform.localScale = new Vector3(0.2f, 0.5f, 0.2f);
                
                RicePlant ricePlant = riceGO.AddComponent<RicePlant>();
                ricePlant.cropData = data;
                ricePlant.cropRenderer = riceGO.GetComponent<MeshRenderer>();
                
                // Giữ lại Collider để VR có thể chém trúng thân cây, nhưng set là Trigger để không cản đường đi
                CapsuleCollider col = riceGO.GetComponent<CapsuleCollider>();
                if (col != null) col.isTrigger = true;

                PrefabUtility.SaveAsPrefabAsset(riceGO, ricePrefabPath);
                DestroyImmediate(riceGO);
            }

            // 3. Tạo Plot Prefab
            string plotPrefabPath = folderPath + "/Plot_Prefab.prefab";
            if (AssetDatabase.LoadAssetAtPath<GameObject>(plotPrefabPath) == null)
            {
                GameObject plotGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
                plotGO.name = "Plot_Prefab";
                
                // Làm dẹp xuống thành cái ô vuông
                plotGO.transform.localScale = new Vector3(1f, 0.1f, 1f);
                
                // Box collider tự động add khi create primitive
                plotGO.GetComponent<BoxCollider>().isTrigger = false; 
                
                // Add XR và Plot script
                CropPlot cropPlot = plotGO.AddComponent<CropPlot>();
                cropPlot.plotRenderer = plotGO.GetComponent<MeshRenderer>();
                cropPlot.ricePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(ricePrefabPath);
                
                // Setup Interaction (để raycast trúng)
                XRSimpleInteractable interactable = plotGO.GetComponent<XRSimpleInteractable>();
                interactable.interactionLayers = InteractionLayerMask.GetMask("Default"); // Tùy chỉnh layer

                // Tạo Spawn Point
                GameObject spawnPoint = new GameObject("SpawnPoint");
                spawnPoint.transform.SetParent(plotGO.transform);
                spawnPoint.transform.localPosition = new Vector3(0, 0.5f, 0); // Nhô lên mặt đất 1 xíu
                cropPlot.cropSpawnPoint = spawnPoint.transform;

                PrefabUtility.SaveAsPrefabAsset(plotGO, plotPrefabPath);
                DestroyImmediate(plotGO);
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            
            Debug.Log("<color=green>Đã tạo thành công Prefab và Data cho hệ thống Farming tại Assets/Khoa!</color>");
        }
    }
}
