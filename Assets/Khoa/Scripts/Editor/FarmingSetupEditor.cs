using UnityEngine;
using UnityEditor;
using UnityEngine.XR.Interaction.Toolkit;

namespace Khoa.Farming.Editor
{
    public class FarmingSetupEditor : EditorWindow
    {
        public GameObject sourceRiceModel;

        [MenuItem("Khoa/Farming/Setup Farming Prefabs")]
        public static void CreatePrefabsWindow()
        {
            GetWindow<FarmingSetupEditor>("Setup Farming Prefabs");
        }

        private void OnGUI()
        {
            GUILayout.Label("Tạo Prefab Tự Động", EditorStyles.boldLabel);
            
            EditorGUILayout.HelpBox("Kéo thả Model 3D cây lúa của bạn vào đây (nếu có). Nếu để trống, sẽ dùng trụ tròn tạm thời.", MessageType.Info);
            sourceRiceModel = (GameObject)EditorGUILayout.ObjectField("Rice 3D Model (Tuỳ chọn)", sourceRiceModel, typeof(GameObject), false);

            if (GUILayout.Button("Tạo/Cập nhật Prefabs"))
            {
                CreatePrefabs();
            }
        }

        private void CreatePrefabs()
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
            GameObject riceGO;
            
            if (sourceRiceModel != null)
            {
                // Dùng model thật của user
                riceGO = (GameObject)PrefabUtility.InstantiatePrefab(sourceRiceModel);
                riceGO.name = "Rice_Prefab";
            }
            else
            {
                // Dùng trụ tròn tạm thời
                riceGO = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                riceGO.name = "Rice_Prefab";
                riceGO.transform.localScale = new Vector3(0.2f, 0.5f, 0.2f);
            }
            
            RicePlant ricePlant = riceGO.GetComponent<RicePlant>();
            if (ricePlant == null) ricePlant = riceGO.AddComponent<RicePlant>();
            
            ricePlant.cropData = data;
            
            // Tìm Renderer trên model để đổi màu (nếu có)
            ricePlant.cropRenderer = riceGO.GetComponentInChildren<MeshRenderer>();
            
            // Giữ lại Collider để VR có thể chém trúng thân cây, nhưng set là Trigger
            Collider col = riceGO.GetComponent<Collider>();
            if (col == null) col = riceGO.AddComponent<BoxCollider>();
            col.isTrigger = true;

            PrefabUtility.SaveAsPrefabAsset(riceGO, ricePrefabPath);
            DestroyImmediate(riceGO);

            // 3. Tạo Plot Prefab (Ô Đất)
            string plotPrefabPath = folderPath + "/Plot_Prefab.prefab";
            
            // Luôn tạo mới ô đất để đảm bảo nó tàng hình
            GameObject plotGO = new GameObject("Plot_Prefab");
            
            // Thêm BoxCollider dẹt
            BoxCollider boxCol = plotGO.AddComponent<BoxCollider>();
            boxCol.size = new Vector3(1f, 0.1f, 1f);
            boxCol.isTrigger = false; 
            
            // Add XR và Plot script
            CropPlot cropPlot = plotGO.AddComponent<CropPlot>();
            cropPlot.plotRenderer = null; // Cố tình để null vì ô đất tàng hình
            cropPlot.ricePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(ricePrefabPath);
            
            // Setup Interaction (để raycast trúng)
            UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactable = plotGO.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
            if (interactable != null)
            {
                interactable.interactionLayers = InteractionLayerMask.GetMask("Default");
            }

            // Tạo Spawn Point
            GameObject spawnPoint = new GameObject("SpawnPoint");
            spawnPoint.transform.SetParent(plotGO.transform);
            spawnPoint.transform.localPosition = new Vector3(0, 0f, 0); // Đặt sát mặt đất
            cropPlot.cropSpawnPoint = spawnPoint.transform;

            PrefabUtility.SaveAsPrefabAsset(plotGO, plotPrefabPath);
            DestroyImmediate(plotGO);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            
            Debug.Log("<color=green>Đã tạo thành công Prefab và Data cho hệ thống Farming tại Assets/Khoa!</color>");
        }
    }
}
