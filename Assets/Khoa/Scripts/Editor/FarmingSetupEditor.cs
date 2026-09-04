using UnityEngine;
using UnityEditor;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System;
using System.Collections.Generic;

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
            
            EditorGUILayout.HelpBox("1. Bộ cơ bản: Prefab Bó lúa (Rice Bundle), Ô ruộng (CropPlot), Cây lúa (Rice Plant).\n" +
                                   "2. Bộ mở rộng: Van nước (Sluice Gate), Sân phơi (Drying Yard), Cối tuốt lúa (Thresher), Bừa trâu (Buffalo Plow).", MessageType.Info);
            
            GUILayout.Space(10);
            GUILayout.Label("🌾 1. Cụm Trồng & Thu Hoạch Lúa", EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Tạo/Cập nhật Prefab Bó Lúa (Rice Bundle)", GUILayout.Height(30)))
            {
                CreateRiceBundlePrefab();
            }
            if (GUILayout.Button("Tạo Bông Lúa Mót (Gleaned Stalk)", GUILayout.Height(30)))
            {
                CreateGleanedRiceStalkPrefab();
            }
            EditorGUILayout.EndHorizontal();

            GUILayout.Space(5);
            sourceRiceModel = (GameObject)EditorGUILayout.ObjectField("Rice 3D Model (Tuỳ chọn)", sourceRiceModel, typeof(GameObject), false);

            if (GUILayout.Button("Tạo/Cập nhật Prefabs Ruộng & Cây Lúa (Plot & Rice)", GUILayout.Height(30)))
            {
                if (EditorUtility.DisplayDialog("Xác nhận", "Cập nhật Prefab Ruộng và Cây Lúa?", "Đồng ý", "Hủy"))
                {
                    CreatePrefabs();
                }
            }

            GUILayout.Space(15);
            GUILayout.Label("🌊 2. Cụm Thủy Lợi & Tưới Tiêu", EditorStyles.boldLabel);
            if (GUILayout.Button("Tạo Prefab Van Nước Kênh Mương (Sluice Gate)", GUILayout.Height(30)))
            {
                CreateSluiceGatePrefab();
            }

            GUILayout.Space(15);
            GUILayout.Label("☀️ 3. Cụm Sân Phơi & Cối Tuốt Lúa", EditorStyles.boldLabel);
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Tạo Sân Phơi Lúa (Drying Yard)", GUILayout.Height(30)))
            {
                CreateRiceDryingYardPrefab();
            }
            if (GUILayout.Button("Tạo Cối Tuốt Lúa (Thresher)", GUILayout.Height(30)))
            {
                CreateRiceThresherPrefab();
            }
            EditorGUILayout.EndHorizontal();

            GUILayout.Space(15);
            GUILayout.Label("🐃 4. Cụm Trâu Cày Ruộng", EditorStyles.boldLabel);
            if (GUILayout.Button("Gắn Lưỡi Bừa Tự Động Vào Trâu Trong Scene", GUILayout.Height(30)))
            {
                AttachPlowToBuffaloInScene();
            }
        }

        public static GameObject CreateRiceBundlePrefab()
        {
            string folderPath = "Assets/Khoa/Prefabs";
            EnsureFolder(folderPath);

            string bundlePrefabPath = folderPath + "/Rice_Bundle_Prefab.prefab";

            GameObject bundleGO = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            bundleGO.name = "Rice_Bundle_Prefab";
            bundleGO.transform.localScale = new Vector3(0.25f, 0.4f, 0.25f);

            MeshRenderer renderer = bundleGO.GetComponent<MeshRenderer>();
            Shader shader = Shader.Find("Universal Render Pipeline/Lit") ?? Shader.Find("Standard");

            Material strawMat = new Material(shader) { color = new Color(0.9f, 0.75f, 0.2f) };
            renderer.material = strawMat;

            Rigidbody rb = bundleGO.GetComponent<Rigidbody>() ?? bundleGO.AddComponent<Rigidbody>();
            rb.mass = 0.8f;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

            XRGrabInteractable grab = bundleGO.GetComponent<XRGrabInteractable>() ?? bundleGO.AddComponent<XRGrabInteractable>();
            grab.interactionLayers = InteractionLayerMask.GetMask("Default");
            grab.throwOnDetach = true;

            RiceBundleItem item = bundleGO.GetComponent<RiceBundleItem>() ?? bundleGO.AddComponent<RiceBundleItem>();
            item.cropData = AssetDatabase.LoadAssetAtPath<CropData>("Assets/Khoa/ScriptableObjects/Rice_Data.asset");
            item.grainAmount = 10;
            item.isDry = false;

            GameObject savedPrefab = PrefabUtility.SaveAsPrefabAsset(bundleGO, bundlePrefabPath);
            DestroyImmediate(bundleGO);

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

        public static GameObject CreateGleanedRiceStalkPrefab()
        {
            string folderPath = "Assets/Khoa/Prefabs";
            EnsureFolder(folderPath);

            string stalkPrefabPath = folderPath + "/Gleaned_Rice_Stalk_Prefab.prefab";

            GameObject stalkGO = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            stalkGO.name = "Gleaned_Rice_Stalk_Prefab";
            stalkGO.transform.localScale = new Vector3(0.12f, 0.2f, 0.12f);

            MeshRenderer renderer = stalkGO.GetComponent<MeshRenderer>();
            Shader shader = Shader.Find("Universal Render Pipeline/Lit") ?? Shader.Find("Standard");
            Material strawMat = new Material(shader) { color = new Color(0.95f, 0.8f, 0.2f) };
            renderer.material = strawMat;

            Rigidbody rb = stalkGO.GetComponent<Rigidbody>() ?? stalkGO.AddComponent<Rigidbody>();
            rb.mass = 0.2f;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

            XRGrabInteractable grab = stalkGO.GetComponent<XRGrabInteractable>() ?? stalkGO.AddComponent<XRGrabInteractable>();
            grab.interactionLayers = InteractionLayerMask.GetMask("Default");
            grab.throwOnDetach = true;

            GleanedRiceStalk stalk = stalkGO.GetComponent<GleanedRiceStalk>() ?? stalkGO.AddComponent<GleanedRiceStalk>();
            stalk.bundlePrefabToSpawn = AssetDatabase.LoadAssetAtPath<GameObject>(folderPath + "/Rice_Bundle_Prefab.prefab");
            stalk.stalksRequiredForBundle = 3;
            stalk.grainYieldPerBundle = 10;

            GameObject savedPrefab = PrefabUtility.SaveAsPrefabAsset(stalkGO, stalkPrefabPath);
            DestroyImmediate(stalkGO);

            string plotPrefabPath = folderPath + "/Plot_Prefab.prefab";
            GameObject plotPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(plotPrefabPath);
            if (plotPrefab != null)
            {
                CropPlot plotComponent = plotPrefab.GetComponent<CropPlot>();
                if (plotComponent != null)
                {
                    plotComponent.gleanStalkPrefab = savedPrefab;
                    EditorUtility.SetDirty(plotPrefab);
                }
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log("<color=green>Đã tạo thành công Prefab Bông Lúa Mót tại: " + stalkPrefabPath + "</color>");
            return savedPrefab;
        }

        public static GameObject CreateSluiceGatePrefab()
        {
            string folderPath = "Assets/Khoa/Prefabs";
            EnsureFolder(folderPath);
            string gatePath = folderPath + "/Sluice_Gate_Prefab.prefab";

            GameObject gateGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gateGO.name = "Sluice_Gate_Prefab";
            gateGO.transform.localScale = new Vector3(1.2f, 2.0f, 0.3f);

            MeshRenderer frameRenderer = gateGO.GetComponent<MeshRenderer>();
            frameRenderer.sharedMaterial = AssetDatabase.LoadAssetAtPath<Material>(
                "Assets/ALP_Assets/NikolayFedorov/PBR_Tiled/MaterialsPBR/Wood_planks_02.mat");

            // The pivot owns rotation. The visible handle stays offset from it so the motion
            // reads as a real hinged lever instead of a cylinder spinning around its center.
            GameObject pivotGO = new GameObject("Lever_Pivot");
            pivotGO.transform.SetParent(gateGO.transform, false);
            pivotGO.transform.localPosition = new Vector3(0f, 0.1f, -0.65f);
            pivotGO.transform.localEulerAngles = new Vector3(90f, 0f, 0f);

            GameObject handleGO = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            handleGO.name = "Lever_Handle";
            handleGO.transform.SetParent(pivotGO.transform, false);
            handleGO.transform.localPosition = new Vector3(0f, 0.3f, 0f);
            handleGO.transform.localScale = new Vector3(0.12f, 0.3f, 0.12f);
            handleGO.GetComponent<MeshRenderer>().sharedMaterial = GetOrCreateLeverMaterial();

            Rigidbody handleBody = handleGO.AddComponent<Rigidbody>();
            handleBody.isKinematic = true;
            handleBody.useGravity = false;
            handleBody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;

            XRGrabInteractable handleGrab = handleGO.AddComponent<XRGrabInteractable>();
            handleGrab.interactionLayers = InteractionLayerMask.GetMask("Default");
            handleGrab.trackPosition = false;
            handleGrab.trackRotation = false;
            handleGrab.trackScale = false;
            handleGrab.throwOnDetach = false;

            SluiceGate sluice = gateGO.AddComponent<SluiceGate>();
            sluice.leverTransform = pivotGO.transform;
            sluice.leverClosedRotation = new Vector3(90f, 0f, 0f);
            sluice.leverOpenRotation = new Vector3(45f, 0f, 0f);
            sluice.waterFlowRate = 25f;

            SluiceGateLever physicalLever = pivotGO.AddComponent<SluiceGateLever>();
            physicalLever.sluiceGate = sluice;
            physicalLever.grabInteractable = handleGrab;

            // Selecting the wooden frame remains a desktop/test fallback. Restricting its
            // collider prevents it from competing with the physical handle for the same grab.
            XRSimpleInteractable fallbackInteractable = gateGO.AddComponent<XRSimpleInteractable>();
            fallbackInteractable.colliders.Clear();
            fallbackInteractable.colliders.Add(gateGO.GetComponent<BoxCollider>());
            sluice.xrInteractable = fallbackInteractable;

            GameObject savedPrefab = PrefabUtility.SaveAsPrefabAsset(gateGO, gatePath);
            DestroyImmediate(gateGO);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log("<color=green>Đã tạo thành công Prefab Van Nước Kênh Mương tại: " + gatePath + "</color>");
            return savedPrefab;
        }

        private static Material GetOrCreateLeverMaterial()
        {
            const string materialFolder = "Assets/Khoa/Materials";
            const string materialPath = materialFolder + "/Sluice_Gate_Lever.mat";
            EnsureFolder(materialFolder);

            Material material = AssetDatabase.LoadAssetAtPath<Material>(materialPath);
            if (material == null)
            {
                Shader shader = Shader.Find("Universal Render Pipeline/Lit") ?? Shader.Find("Standard");
                if (shader == null)
                {
                    throw new InvalidOperationException("No supported shader is available for the sluice lever.");
                }

                material = new Material(shader)
                {
                    name = "Sluice_Gate_Lever",
                    color = new Color(0.7f, 0.08f, 0.04f)
                };
                AssetDatabase.CreateAsset(material, materialPath);
            }
            else
            {
                material.color = new Color(0.7f, 0.08f, 0.04f);
                EditorUtility.SetDirty(material);
            }

            return material;
        }

        public static GameObject CreateRiceDryingYardPrefab()
        {
            string folderPath = "Assets/Khoa/Prefabs";
            EnsureFolder(folderPath);
            string yardPath = folderPath + "/Rice_Drying_Yard_Prefab.prefab";

            GameObject yardGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
            yardGO.name = "Rice_Drying_Yard_Prefab";
            yardGO.transform.localScale = new Vector3(6f, 0.05f, 6f);

            MeshRenderer renderer = yardGO.GetComponent<MeshRenderer>();
            Shader shader = Shader.Find("Universal Render Pipeline/Lit") ?? Shader.Find("Standard");
            Material brickMat = new Material(shader) { color = new Color(0.75f, 0.45f, 0.35f) }; // Màu gạch sân phơi
            renderer.material = brickMat;

            BoxCollider col = yardGO.GetComponent<BoxCollider>();
            col.isTrigger = true;
            col.size = new Vector3(1f, 10f, 1f); // Chiều cao vùng Trigger để nhận diện bó lúa

            RiceDryingYard yard = yardGO.AddComponent<RiceDryingYard>();
            yard.dryingSpeedPerSecond = 5f; // 20s khô
            yard.isSunny = true;

            GameObject savedPrefab = PrefabUtility.SaveAsPrefabAsset(yardGO, yardPath);
            DestroyImmediate(yardGO);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log("<color=green>Đã tạo thành công Prefab Sân Phơi Lúa tại: " + yardPath + "</color>");
            return savedPrefab;
        }

        public static GameObject CreateRiceThresherPrefab()
        {
            string folderPath = "Assets/Khoa/Prefabs";
            EnsureFolder(folderPath);
            string thresherPath = folderPath + "/Rice_Thresher_Prefab.prefab";

            GameObject thresherGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
            thresherGO.name = "Rice_Thresher_Prefab";
            thresherGO.transform.localScale = new Vector3(1.2f, 1.0f, 1.5f);

            MeshRenderer renderer = thresherGO.GetComponent<MeshRenderer>();
            Shader shader = Shader.Find("Universal Render Pipeline/Lit") ?? Shader.Find("Standard");
            Material woodMat = new Material(shader) { color = new Color(0.5f, 0.35f, 0.2f) };
            renderer.material = woodMat;

            // Trigger zone để đưa bó lúa vào
            BoxCollider col = thresherGO.GetComponent<BoxCollider>();
            col.isTrigger = true;
            col.size = new Vector3(1.2f, 1.5f, 1.2f);

            RiceThresher thresher = thresherGO.AddComponent<RiceThresher>();
            thresher.grainYieldMultiplier = 1f;

            RiceThresherBasketReceiver receiver = thresherGO.AddComponent<RiceThresherBasketReceiver>();
            receiver.autoFillInventoryBasket = true;

            GameObject savedPrefab = PrefabUtility.SaveAsPrefabAsset(thresherGO, thresherPath);
            DestroyImmediate(thresherGO);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log("<color=green>Đã tạo thành công Prefab Cối Tuốt Lúa tại: " + thresherPath + "</color>");
            return savedPrefab;
        }

        public static void AttachPlowToBuffaloInScene()
        {
            // BuffaloRider nằm ngoài assembly Khoa.Farming, nên tìm theo tên component
            MonoBehaviour[] allMono = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
            GameObject buffaloGO = null;
            foreach (var mono in allMono)
            {
                if (mono.GetType().Name == "BuffaloRider")
                {
                    buffaloGO = mono.gameObject;
                    break;
                }
            }

            if (buffaloGO == null)
            {
                EditorUtility.DisplayDialog("Thông báo", "Không tìm thấy con trâu (BuffaloRider) nào trong Scene hiện tại!", "OK");
                return;
            }

            BuffaloPlowAttachment existingPlow = buffaloGO.GetComponentInChildren<BuffaloPlowAttachment>();
            if (existingPlow != null)
            {
                EditorUtility.DisplayDialog("Thông báo", "Con trâu này đã được gắn Lưỡi bừa cày ruộng rồi!", "OK");
                return;
            }

            GameObject plowGO = new GameObject("Buffalo_Plow_Blade");
            plowGO.transform.SetParent(buffaloGO.transform);
            plowGO.transform.localPosition = new Vector3(0f, 0.2f, -1.2f);
            plowGO.transform.localRotation = Quaternion.identity;

            BuffaloPlowAttachment plow = plowGO.AddComponent<BuffaloPlowAttachment>();
            plow.isPlowingActive = true;
            plow.EnsurePhysicsSetup();

            EditorUtility.SetDirty(buffaloGO);
            Debug.Log("<color=green>Đã gắn thành công Lưỡi bừa tự động vào sau đuôi con trâu trong Scene!</color>");
            EditorUtility.DisplayDialog("Thành công", "Đã gắn thành công Lưỡi bừa cày ruộng vào sau đuôi con trâu!\nKhi cưỡi trâu đi qua ruộng, đất sẽ tự động được xới tơi xốp.", "Tuyệt vời");
        }

        private void CreatePrefabs()
        {
            string folderPath = "Assets/Khoa/Prefabs";
            EnsureFolder(folderPath);
            
            string soFolderPath = "Assets/Khoa/ScriptableObjects";
            EnsureFolder(soFolderPath);

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
            
            RicePlant ricePlant = riceGO.GetComponent<RicePlant>() ?? riceGO.AddComponent<RicePlant>();
            ricePlant.cropData = data;
            ricePlant.cropRenderer = riceGO.GetComponentInChildren<MeshRenderer>();
            
            Collider col = riceGO.GetComponent<Collider>() ?? riceGO.AddComponent<BoxCollider>();
            col.isTrigger = true;

            PrefabUtility.SaveAsPrefabAsset(riceGO, ricePrefabPath);
            DestroyImmediate(riceGO);

            // 3. Tạo Bó Lúa Prefab
            GameObject bundlePrefab = CreateRiceBundlePrefab();

            // 4. Tạo Plot Prefab (Ô Đất)
            string plotPrefabPath = folderPath + "/Plot_Prefab.prefab";
            GameObject plotGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
            plotGO.name = "Plot_Prefab";
            plotGO.transform.localScale = new Vector3(1.5f, 0.1f, 1.5f);
            
            BoxCollider boxCol = plotGO.GetComponent<BoxCollider>();
            boxCol.isTrigger = false; 
            
            CropPlot cropPlot = plotGO.AddComponent<CropPlot>();
            cropPlot.plotRenderer = plotGO.GetComponent<MeshRenderer>();
            
            // Gán PBR Soil Material nếu có
            Material soilMat = AssetDatabase.LoadAssetAtPath<Material>("Assets/ALP_Assets/NikolayFedorov/PBR_Tiled/OtherMaterials/Soil.mat");
            if (soilMat != null)
            {
                cropPlot.plotRenderer.material = soilMat;
            }

            cropPlot.ricePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(ricePrefabPath);
            cropPlot.harvestItemPrefab = bundlePrefab;
            
            XRSimpleInteractable interactable = plotGO.GetComponent<XRSimpleInteractable>();
            if (interactable != null)
            {
                interactable.interactionLayers = InteractionLayerMask.GetMask("Default");
            }

            // Tạo SpawnPoint
            GameObject spawnPoint = new GameObject("SpawnPoint");
            spawnPoint.transform.SetParent(plotGO.transform);
            spawnPoint.transform.localPosition = new Vector3(
                boxCol.center.x,
                boxCol.center.y + boxCol.size.y * 0.5f,
                boxCol.center.z);
            spawnPoint.transform.localScale = new Vector3(1f, 10f, 1f);
            cropPlot.cropSpawnPoint = spawnPoint.transform;

            // Tạo WaterSurface
            GameObject waterSurface = GameObject.CreatePrimitive(PrimitiveType.Quad);
            waterSurface.name = "WaterSurface";
            waterSurface.transform.SetParent(plotGO.transform);
            waterSurface.transform.localPosition = new Vector3(0f, 0.52f, 0f);
            waterSurface.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
            waterSurface.transform.localScale = new Vector3(0.98f, 0.98f, 1f);
            DestroyImmediate(waterSurface.GetComponent<Collider>());
            waterSurface.SetActive(false);
            cropPlot.waterSurfaceMesh = waterSurface;

            PrefabUtility.SaveAsPrefabAsset(plotGO, plotPrefabPath);
            DestroyImmediate(plotGO);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            
            Debug.Log("<color=green>Đã cập nhật thành công toàn bộ Prefabs Nông Nghiệp tại Assets/Khoa/Prefabs!</color>");
        }

        private static void EnsureFolder(string path)
        {
            string[] parts = path.Split('/');
            string current = parts[0];
            for (int i = 1; i < parts.Length; i++)
            {
                string next = current + "/" + parts[i];
                if (!AssetDatabase.IsValidFolder(next))
                {
                    AssetDatabase.CreateFolder(current, parts[i]);
                }
                current = next;
            }
        }
    }
}
