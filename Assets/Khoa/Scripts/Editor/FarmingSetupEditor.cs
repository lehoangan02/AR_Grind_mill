using UnityEngine;
using UnityEditor;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

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
            GUILayout.Label("Cấu hình & Tạo Prefab Nông Nghiệp", EditorStyles.boldLabel);
            
            EditorGUILayout.HelpBox("1. Tạo Bó Lúa Prefab: Dùng để làm vật phẩm rơi ra khi gặt lúa bằng liềm (có sẵn XR Grab để cầm nhặt trong VR).\n2. Tạo/Cập nhật Prefabs Hệ Thống: Tạo ô đất (Plot) và cây lúa (Rice Plant).", MessageType.Info);
            
            GUILayout.Space(10);
            if (GUILayout.Button("🌾 Tạo/Cập nhật Prefab Bó Lúa (Rice Bundle)", GUILayout.Height(35)))
            {
                CreateRiceBundlePrefab();
            }

            GUILayout.Space(15);
            GUILayout.Label("Model 3D Cây Lúa Tùy Chọn", EditorStyles.boldLabel);
            sourceRiceModel = (GameObject)EditorGUILayout.ObjectField("Rice 3D Model", sourceRiceModel, typeof(GameObject), false);

            GUILayout.Space(5);
            if (GUILayout.Button("🛠️ Tạo/Cập nhật Prefabs Ruộng & Cây Lúa", GUILayout.Height(35)))
            {
                if (EditorUtility.DisplayDialog("Xác nhận", "Bạn có chắc chắn muốn tạo/cập nhật lại Prefab Ruộng và Cây Lúa không?\n(Dữ liệu cũ nếu có sẽ được bảo lưu an toàn)", "Đồng ý", "Hủy"))
                {
                    CreatePrefabs();
                }
            }
        }

        public static GameObject CreateRiceBundlePrefab()
        {
            string folderPath = "Assets/Khoa/Prefabs";
            if (!AssetDatabase.IsValidFolder("Assets/Khoa"))
                AssetDatabase.CreateFolder("Assets", "Khoa");
            if (!AssetDatabase.IsValidFolder(folderPath))
                AssetDatabase.CreateFolder("Assets/Khoa", "Prefabs");

            string bundlePrefabPath = folderPath + "/Rice_Bundle_Prefab.prefab";

            // Tạo model bó lúa mẫu hình con thoi / capsule dẹp
            GameObject bundleGO = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            bundleGO.name = "Rice_Bundle_Prefab";
            bundleGO.tag = "Untagged";
            bundleGO.transform.localScale = new Vector3(0.25f, 0.4f, 0.25f);

            // Vật liệu màu vàng rơm
            MeshRenderer renderer = bundleGO.GetComponent<MeshRenderer>();
            Shader shader = Shader.Find("Universal Render Pipeline/Lit");
            if (shader == null) shader = Shader.Find("Standard");

            Material strawMat = new Material(shader);
            strawMat.color = new Color(0.9f, 0.75f, 0.2f); // Vàng rơm
            renderer.material = strawMat;

            // Rigidbody
            Rigidbody rb = bundleGO.GetComponent<Rigidbody>();
            if (rb == null) rb = bundleGO.AddComponent<Rigidbody>();
            rb.mass = 0.8f;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

            // XR Grab Interactable
            XRGrabInteractable grab = bundleGO.GetComponent<XRGrabInteractable>();
            if (grab == null) grab = bundleGO.AddComponent<XRGrabInteractable>();
            grab.interactionLayers = InteractionLayerMask.GetMask("Default");
            grab.throwOnDetach = true;

            // RiceBundleItem component
            RiceBundleItem item = bundleGO.GetComponent<RiceBundleItem>();
            if (item == null) item = bundleGO.AddComponent<RiceBundleItem>();
            item.cropData = AssetDatabase.LoadAssetAtPath<CropData>("Assets/Khoa/ScriptableObjects/Rice_Data.asset");
            item.grainAmount = 10;
            item.isDry = false;

            GameObject savedPrefab = PrefabUtility.SaveAsPrefabAsset(bundleGO, bundlePrefabPath);
            DestroyImmediate(bundleGO);

            // Cập nhật liên kết vào Plot_Prefab nếu có
            string plotPrefabPath = folderPath + "/Plot_Prefab.prefab";
            GameObject plotPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(plotPrefabPath);
            if (plotPrefab != null)
            {
                CropPlot plotComponent = plotPrefab.GetComponent<CropPlot>();
                if (plotComponent != null && plotComponent.harvestItemPrefab == null)
                {
                    plotComponent.harvestItemPrefab = savedPrefab;
                    EditorUtility.SetDirty(plotPrefab);
                }
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log("<color=green>Đã tạo thành công Prefab Bó Lúa tại: " + bundlePrefabPath + "</color>");
            return savedPrefab;
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
                riceGO = (GameObject)PrefabUtility.InstantiatePrefab(sourceRiceModel);
                riceGO.name = "Rice_Prefab";
            }
            else
            {
                riceGO = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                riceGO.name = "Rice_Prefab";
                riceGO.transform.localScale = new Vector3(0.2f, 0.5f, 0.2f);
            }
            
            RicePlant ricePlant = riceGO.GetComponent<RicePlant>();
            if (ricePlant == null) ricePlant = riceGO.AddComponent<RicePlant>();
            ricePlant.cropData = data;
            ricePlant.cropRenderer = riceGO.GetComponentInChildren<MeshRenderer>();
            
            Collider col = riceGO.GetComponent<Collider>();
            if (col == null) col = riceGO.AddComponent<BoxCollider>();
            col.isTrigger = true;

            PrefabUtility.SaveAsPrefabAsset(riceGO, ricePrefabPath);
            DestroyImmediate(riceGO);

            // 3. Tạo Bó Lúa Prefab
            GameObject bundlePrefab = CreateRiceBundlePrefab();

            // 4. Tạo Plot Prefab (Ô Đất)
            string plotPrefabPath = folderPath + "/Plot_Prefab.prefab";
            GameObject plotGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
            plotGO.name = "Plot_Prefab";
            plotGO.transform.localScale = new Vector3(1f, 0.1f, 1f);
            
            BoxCollider boxCol = plotGO.GetComponent<BoxCollider>();
            boxCol.isTrigger = false; 
            
            CropPlot cropPlot = plotGO.AddComponent<CropPlot>();
            cropPlot.plotRenderer = plotGO.GetComponent<MeshRenderer>();
            cropPlot.ricePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(ricePrefabPath);
            cropPlot.harvestItemPrefab = bundlePrefab;
            
            XRSimpleInteractable interactable = plotGO.GetComponent<XRSimpleInteractable>();
            if (interactable != null)
            {
                interactable.interactionLayers = InteractionLayerMask.GetMask("Default");
            }

            GameObject spawnPoint = new GameObject("SpawnPoint");
            spawnPoint.transform.SetParent(plotGO.transform);
            spawnPoint.transform.localPosition = Vector3.zero;
            cropPlot.cropSpawnPoint = spawnPoint.transform;

            PrefabUtility.SaveAsPrefabAsset(plotGO, plotPrefabPath);
            DestroyImmediate(plotGO);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            
            Debug.Log("<color=green>Đã cập nhật thành công Prefab và Data cho hệ thống Farming tại Assets/Khoa!</color>");
        }
    }
}
