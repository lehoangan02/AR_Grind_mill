using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Khoa.Farming.Editor
{
    /// <summary>
    /// Tích hợp tự động Cối xay gạo và Khu bếp nấu cơm miền Tây vào Scene chính.
    /// Có thể chạy từ Unity Editor Menu hoặc qua Unity CLI (-executeMethod).
    /// </summary>
    public static class CookingSceneIntegrator
    {
        public const string MainScenePath = "Assets/Scenes/Grind mill v1.0 Scene.unity";
        public const string SetupRootName = "Khoa_Kitchen_And_Milling_Setup";
        private const string CookingPrefabFolder = "Assets/Khoa/Prefabs/Cooking";
        private const string WhiteRicePrefabPath = CookingPrefabFolder + "/WhiteRiceBatch.prefab";
        private const string RiceBowlPrefabPath = CookingPrefabFolder + "/CookedRiceBowl.prefab";
        private const string PaddyBatchPrefabPath = CookingPrefabFolder + "/PaddyBatch.prefab";

        [MenuItem("Khoa/Cooking/Apply Kitchen & Grind Mill Setup")]
        public static void ApplyCookingAndMillSetup()
        {
            EnsureCookingPrefabs();
            Scene scene = OpenOrUseMainScene();
            RepairKnownPauseCanvasMissingScript(scene);

            GameObject previousSetup = GameObject.Find(SetupRootName);
            if (previousSetup != null)
            {
                UnityEngine.Object.DestroyImmediate(previousSetup);
            }

            GameObject setupRoot = new GameObject(SetupRootName);
            ConfigureThresherPhysicalOutputs();

            // Tìm vị trí sàn nhà hoặc sân cạnh nhà sàn
            Vector3 kitchenBasePos = new Vector3(-8f, 0f, 5f);
            Terrain activeTerrain = Terrain.activeTerrain;
            if (activeTerrain != null)
            {
                float terrainY = activeTerrain.SampleHeight(kitchenBasePos) + activeTerrain.transform.position.y;
                kitchenBasePos.y = terrainY;
            }

            // 1. Tạo Cối Xay Gạo hoàn chỉnh
            GameObject millGO = CreateGrindMill(setupRoot.transform, kitchenBasePos + new Vector3(-3f, 0f, 0f));
            GrindMillStation millStation = millGO.GetComponent<GrindMillStation>();

            // 2. Tạo Chum Nước
            GameObject jarGO = CreateWaterJar(setupRoot.transform, kitchenBasePos + new Vector3(0f, 0f, 2f));

            // 3. Tạo Bàn Bếp Gỗ
            GameObject kitchenTableGO = CreateKitchenTable(setupRoot.transform, kitchenBasePos + new Vector3(0f, 0f, 0f));

            // 4. Tạo Thau Vo Gạo & Gáo Múc Nước
            GameObject washingPotGO = CreateRiceWashingStation(setupRoot.transform, kitchenTableGO.transform.position + new Vector3(-0.5f, 0.85f, 0f));
            RiceWashingPot washPot = washingPotGO.GetComponent<RiceWashingPot>();
            GameObject dipperGO = CreateWaterDipper(setupRoot.transform, jarGO.transform.position + new Vector3(0.3f, 0.9f, 0f));
            CreateRiceWashingTool(setupRoot.transform, washingPotGO.transform.position + new Vector3(0.6f, 0.2f, 0f));
            CreateWashedRiceScoop(setupRoot.transform, washingPotGO.transform.position + new Vector3(-0.6f, 0.2f, 0f));

            // 5. Tạo Bếp Củi
            GameObject stoveGO = CreateWoodStove(setupRoot.transform, kitchenBasePos + new Vector3(2.5f, 0f, 0f));
            WoodStove stove = stoveGO.GetComponent<WoodStove>();

            // 6. Tạo Nồi Gang Nấu Cơm & Nắp Vung
            GameObject potGO = CreateCookingPot(setupRoot.transform, stoveGO.transform.position + new Vector3(0f, 0.45f, 0f));
            CookingPot pot = potGO.GetComponent<CookingPot>();

            // 7. Tạo Củi Khô & Hộp Diêm
            CreateFirewoodPile(setupRoot.transform, stoveGO.transform.position + new Vector3(0.8f, 0f, -0.5f));
            CreateMatchItem(setupRoot.transform, kitchenTableGO.transform.position + new Vector3(0.5f, 0.85f, 0.2f));
            CreateServingLadle(setupRoot.transform, potGO.transform.position + new Vector3(0.65f, 0.25f, 0f));

            // 8. Tạo Bảng Hướng Dẫn Nhiệm Vụ 3D (Quest Guide Billboard)
            CreateQuestGuide(setupRoot.transform, kitchenTableGO.transform.position + new Vector3(0f, 1.8f, 0f), millStation, washPot, stove, pot);

            ValidateSetupOrThrow(setupRoot);
            ValidateMainSceneSetup();

            Debug.Log("<color=green>[CookingSceneIntegrator] ✅ Đã hoàn tất setup Cối Xay Gạo và Khu Bếp Miền Tây vào Scene chính!</color>");

            EditorSceneManager.MarkSceneDirty(scene);
            EditorSceneManager.SaveScene(scene);
        }

        [MenuItem("Khoa/Cooking/Validate Main Scene Setup")]
        public static void ValidateMainSceneSetup()
        {
            Scene scene = OpenOrUseMainScene();
            List<GameObject> matchingRoots = new List<GameObject>();
            foreach (GameObject root in scene.GetRootGameObjects())
            {
                if (root.name == SetupRootName) matchingRoots.Add(root);
            }

            if (matchingRoots.Count != 1)
                throw new InvalidOperationException($"Expected exactly one {SetupRootName} root, found {matchingRoots.Count}.");

            List<string> missingScriptObjects = new List<string>();
            foreach (GameObject sceneRoot in scene.GetRootGameObjects())
            {
                foreach (Transform child in sceneRoot.GetComponentsInChildren<Transform>(true))
                {
                    if (GameObjectUtility.GetMonoBehavioursWithMissingScriptCount(child.gameObject) > 0)
                        missingScriptObjects.Add(GetHierarchyPath(child));
                }
            }
            if (missingScriptObjects.Count > 0)
                throw new InvalidOperationException("Missing MonoBehaviour objects: " + string.Join(", ", missingScriptObjects));

            ValidateSetupOrThrow(matchingRoots[0]);
            RiceThresherBasketReceiver[] receivers = UnityEngine.Object.FindObjectsByType<RiceThresherBasketReceiver>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            if (receivers.Length == 0) throw new InvalidOperationException("Main scene has no rice thresher receiver.");
            foreach (RiceThresherBasketReceiver receiver in receivers)
            {
                if (receiver.paddyBatchPrefab == null || receiver.paddyOutputPoint == null)
                    throw new InvalidOperationException($"Thresher {receiver.name} has no physical paddy output.");
            }
            Debug.Log("[CookingSceneIntegrator] Main scene validation passed.");
        }

        private static string GetHierarchyPath(Transform transform)
        {
            string path = transform.name;
            while (transform.parent != null)
            {
                transform = transform.parent;
                path = transform.name + "/" + path;
            }
            return path;
        }

        private static void RepairKnownPauseCanvasMissingScript(Scene scene)
        {
            foreach (GameObject root in scene.GetRootGameObjects())
            {
                foreach (Transform child in root.GetComponentsInChildren<Transform>(true))
                {
                    if (child.name != "Pause canvas") continue;
                    int missingCount = GameObjectUtility.GetMonoBehavioursWithMissingScriptCount(child.gameObject);
                    if (missingCount == 1)
                    {
                        GameObjectUtility.RemoveMonoBehavioursWithMissingScript(child.gameObject);
                        Debug.Log("[CookingSceneIntegrator] Removed one unrecoverable missing script from Pause canvas; Canvas UI components were preserved.");
                    }
                    else if (missingCount > 1)
                    {
                        throw new InvalidOperationException($"Pause canvas has {missingCount} missing scripts; refusing ambiguous repair.");
                    }
                    return;
                }
            }
        }

        private static GameObject CreateGrindMill(Transform parent, Vector3 position)
        {
            GameObject millGO = new GameObject("Station_GrindMill");
            millGO.transform.SetParent(parent, false);
            millGO.transform.position = position;

            // Thớt cối dưới
            GameObject lowerPlate = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            lowerPlate.name = "LowerPlate";
            lowerPlate.transform.SetParent(millGO.transform, false);
            lowerPlate.transform.localPosition = new Vector3(0f, 0.3f, 0f);
            lowerPlate.transform.localScale = new Vector3(1.2f, 0.3f, 1.2f);

            // Thớt cối trên
            GameObject upperPlate = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            upperPlate.name = "UpperPlate";
            upperPlate.transform.SetParent(millGO.transform, false);
            upperPlate.transform.localPosition = new Vector3(0f, 0.65f, 0f);
            upperPlate.transform.localScale = new Vector3(1.1f, 0.35f, 1.1f);

            // Cần quay
            GameObject handlebar = GameObject.CreatePrimitive(PrimitiveType.Cube);
            handlebar.name = "Handlebar";
            handlebar.transform.SetParent(millGO.transform, false);
            handlebar.transform.localPosition = new Vector3(0.6f, 0.9f, 0f);
            handlebar.transform.localScale = new Vector3(1.8f, 0.08f, 0.08f);

            // Tay nắm cần quay
            GameObject handleGrip = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            handleGrip.name = "HandleGrip";
            handleGrip.transform.SetParent(handlebar.transform, false);
            handleGrip.transform.localPosition = new Vector3(0.8f, -0.3f, 0f);
            handleGrip.transform.localScale = new Vector3(0.06f, 0.3f, 0.06f);

            XRGrabInteractable grab = handleGrip.AddComponent<XRGrabInteractable>();
            grab.trackPosition = false;
            grab.trackRotation = false;

            // Phễu nạp thóc
            GameObject hopper = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            hopper.name = "PaddyHopper";
            hopper.transform.SetParent(millGO.transform, false);
            hopper.transform.localPosition = new Vector3(0f, 0.85f, 0f);
            hopper.transform.localScale = new Vector3(0.5f, 0.15f, 0.5f);

            // Khối lúa trong phễu
            GameObject paddyHeap = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            paddyHeap.name = "PaddyHeap";
            paddyHeap.transform.SetParent(hopper.transform, false);
            paddyHeap.transform.localPosition = new Vector3(0f, 0.3f, 0f);
            paddyHeap.transform.localScale = new Vector3(0.9f, 0.4f, 0.9f);

            // Khay gạo trắng
            GameObject milledRice = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            milledRice.name = "MilledRiceTray";
            milledRice.transform.SetParent(millGO.transform, false);
            milledRice.transform.localPosition = new Vector3(0.7f, 0.15f, 0f);
            milledRice.transform.localScale = new Vector3(0.5f, 0.1f, 0.5f);
            milledRice.SetActive(false);

            // Script GrindMillStation
            GrindMillStation station = millGO.AddComponent<GrindMillStation>();
            station.handlebarTransform = handlebar.transform;
            station.handleGrabInteractable = grab;
            station.hopperPaddyMesh = paddyHeap.transform;
            station.milledRiceVisual = milledRice;

            // Trigger đổ lúa nằm trên object riêng để callback vật lý đi đúng receiver.
            GameObject hopperTriggerGO = new GameObject("PaddyHopperTrigger");
            hopperTriggerGO.transform.SetParent(hopper.transform, false);
            hopperTriggerGO.transform.localPosition = new Vector3(0f, 0.45f, 0f);
            BoxCollider hopperCol = hopperTriggerGO.AddComponent<BoxCollider>();
            hopperCol.size = new Vector3(1.4f, 1.1f, 1.4f);
            hopperCol.isTrigger = true;
            GrindMillHopperReceiver receiver = hopperTriggerGO.AddComponent<GrindMillHopperReceiver>();
            receiver.Configure(station);
            station.hopperTrigger = hopperCol;

            // AudioSource
            station.grindingAudioSource = millGO.AddComponent<AudioSource>();
            station.grindingAudioSource.spatialBlend = 1f;
            station.grindingAudioSource.playOnAwake = false;
            station.grindingAudioSource.clip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/MyFolder/Audio/grind.mp3");
            station.whiteRicePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(WhiteRicePrefabPath);
            GameObject outputPoint = new GameObject("RiceOutputPoint");
            outputPoint.transform.SetParent(millGO.transform, false);
            outputPoint.transform.localPosition = new Vector3(0.8f, 0.45f, 0f);
            station.riceOutputPoint = outputPoint.transform;
            station.chaffParticles = CreateParticleSystem("ChaffParticles", millGO.transform, new Vector3(0.45f, 0.65f, 0f), new Color(0.75f, 0.62f, 0.32f), 0.08f);

            return millGO;
        }

        private static GameObject CreateWaterJar(Transform parent, Vector3 position)
        {
            GameObject jarPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/_Environment/Water Jar/Prefab/WaterJar1.prefab");
            GameObject jarGO;

            if (jarPrefab != null)
            {
                jarGO = (GameObject)PrefabUtility.InstantiatePrefab(jarPrefab, parent);
                jarGO.transform.position = position;
                jarGO.name = "WaterJar_Station";
            }
            else
            {
                jarGO = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                jarGO.name = "WaterJar_Station";
                jarGO.transform.SetParent(parent, false);
                jarGO.transform.position = position;
                jarGO.transform.localScale = new Vector3(0.9f, 0.8f, 0.9f);

                // Mặt nước
                GameObject waterPlane = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                waterPlane.name = "WaterSurface";
                waterPlane.transform.SetParent(jarGO.transform, false);
                waterPlane.transform.localPosition = new Vector3(0f, 0.4f, 0f);
                waterPlane.transform.localScale = new Vector3(0.85f, 0.05f, 0.85f);
            }

            GameObject sourceVolume = new GameObject("CleanWaterSourceVolume");
            sourceVolume.transform.SetParent(jarGO.transform, false);
            sourceVolume.transform.localPosition = new Vector3(0f, 0.45f, 0f);
            BoxCollider sourceCollider = sourceVolume.AddComponent<BoxCollider>();
            sourceCollider.size = new Vector3(0.8f, 0.3f, 0.8f);
            sourceCollider.isTrigger = true;
            sourceVolume.AddComponent<WaterSource>();

            return jarGO;
        }

        private static GameObject CreateKitchenTable(Transform parent, Vector3 position)
        {
            GameObject tablePrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Cabin/Prefabs/Table.prefab");
            GameObject tableGO;

            if (tablePrefab != null)
            {
                tableGO = (GameObject)PrefabUtility.InstantiatePrefab(tablePrefab, parent);
                tableGO.name = "KitchenTable";
                tableGO.transform.position = position;
            }
            else
            {
                tableGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
                tableGO.name = "KitchenTable";
                tableGO.transform.SetParent(parent, false);
                tableGO.transform.position = position + new Vector3(0f, 0.4f, 0f);
                tableGO.transform.localScale = new Vector3(1.6f, 0.8f, 0.8f);
            }

            return tableGO;
        }

        private static GameObject CreateRiceWashingStation(Transform parent, Vector3 position)
        {
            GameObject potGO = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            potGO.name = "RiceWashingBasin";
            potGO.transform.SetParent(parent, false);
            potGO.transform.position = position;
            potGO.transform.localScale = new Vector3(0.45f, 0.2f, 0.45f);

            // Khối gạo
            GameObject riceVisual = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            riceVisual.name = "RiceVisual";
            riceVisual.transform.SetParent(potGO.transform, false);
            riceVisual.transform.localPosition = new Vector3(0f, 0.2f, 0f);
            riceVisual.transform.localScale = new Vector3(0.85f, 0.3f, 0.85f);
            riceVisual.SetActive(false);

            // Mặt nước
            GameObject waterVisual = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            waterVisual.name = "WaterSurface";
            waterVisual.transform.SetParent(potGO.transform, false);
            waterVisual.transform.localPosition = new Vector3(0f, 0.4f, 0f);
            waterVisual.transform.localScale = new Vector3(0.9f, 0.05f, 0.9f);
            waterVisual.SetActive(false);

            RiceWashingPot washPot = potGO.AddComponent<RiceWashingPot>();
            washPot.riceMeshVisual = riceVisual;
            washPot.waterSurfaceRenderer = waterVisual.GetComponent<Renderer>();
            washPot.drainWaterFX = CreateParticleSystem("DrainWaterFX", potGO.transform, new Vector3(0.45f, 0.25f, 0f), new Color(0.82f, 0.88f, 0.9f), 0.05f);

            GameObject washVolume = new GameObject("RiceWashingInteractionVolume");
            washVolume.transform.SetParent(potGO.transform, false);
            washVolume.transform.localPosition = new Vector3(0f, 0.35f, 0f);
            BoxCollider washTrigger = washVolume.AddComponent<BoxCollider>();
            washTrigger.size = new Vector3(1.5f, 0.7f, 1.5f);
            washTrigger.isTrigger = true;

            return potGO;
        }

        private static GameObject CreateWaterDipper(Transform parent, Vector3 position)
        {
            GameObject dipperGO = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            dipperGO.name = "WaterDipper_Item";
            dipperGO.transform.SetParent(parent, false);
            dipperGO.transform.position = position;
            dipperGO.transform.localScale = new Vector3(0.2f, 0.15f, 0.2f);

            // Cán gáo
            GameObject handle = GameObject.CreatePrimitive(PrimitiveType.Cube);
            handle.name = "Handle";
            handle.transform.SetParent(dipperGO.transform, false);
            handle.transform.localPosition = new Vector3(0.3f, 0.2f, 0f);
            handle.transform.localScale = new Vector3(0.5f, 0.1f, 0.1f);

            // Mặt nước trong gáo
            GameObject waterVis = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            waterVis.name = "WaterInDipper";
            waterVis.transform.SetParent(dipperGO.transform, false);
            waterVis.transform.localPosition = new Vector3(0f, 0.3f, 0f);
            waterVis.transform.localScale = new Vector3(0.85f, 0.05f, 0.85f);
            waterVis.SetActive(false);

            WaterDipper dipper = dipperGO.AddComponent<WaterDipper>();
            dipper.waterSurfaceVisual = waterVis;
            GameObject pourOrigin = new GameObject("PourOrigin");
            pourOrigin.transform.SetParent(dipperGO.transform, false);
            pourOrigin.transform.localPosition = new Vector3(-0.2f, 0.3f, 0f);
            dipper.pourOrigin = pourOrigin.transform;
            dipper.pourWaterFX = CreateParticleSystem("PourWaterFX", dipperGO.transform, pourOrigin.transform.localPosition, new Color(0.45f, 0.75f, 1f), 0.04f);

            return dipperGO;
        }

        private static void CreateRiceWashingTool(Transform parent, Vector3 position)
        {
            GameObject tool = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            tool.name = "RiceWashingPaddle";
            tool.transform.SetParent(parent, false);
            tool.transform.position = position;
            tool.transform.localScale = new Vector3(0.04f, 0.28f, 0.04f);
            tool.AddComponent<RiceWashingTool>();
            tool.AddComponent<Rigidbody>();
            tool.AddComponent<XRGrabInteractable>();
        }

        private static void CreateWashedRiceScoop(Transform parent, Vector3 position)
        {
            GameObject scoop = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            scoop.name = "WashedRiceTransferScoop";
            scoop.transform.SetParent(parent, false);
            scoop.transform.position = position;
            scoop.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            scoop.transform.localScale = new Vector3(0.05f, 0.25f, 0.05f);
            scoop.AddComponent<WashedRiceScoop>();
        }

        private static GameObject CreateWoodStove(Transform parent, Vector3 position)
        {
            GameObject stoveGO = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            stoveGO.name = "WoodStove_Station";
            stoveGO.transform.SetParent(parent, false);
            stoveGO.transform.position = position + new Vector3(0f, 0.25f, 0f);
            stoveGO.transform.localScale = new Vector3(0.8f, 0.5f, 0.8f);

            // Kiềng đặt nồi
            GameObject kiengPoint = new GameObject("KiengPlacementPoint");
            kiengPoint.transform.SetParent(stoveGO.transform, false);
            kiengPoint.transform.localPosition = new Vector3(0f, 0.55f, 0f);

            // Ánh lửa PointLight
            GameObject lightGO = new GameObject("StoveLight");
            lightGO.transform.SetParent(stoveGO.transform, false);
            lightGO.transform.localPosition = new Vector3(0f, 0.2f, 0f);
            Light fireLight = lightGO.AddComponent<Light>();
            fireLight.type = LightType.Point;
            fireLight.color = new Color(1f, 0.55f, 0.15f);
            fireLight.range = 3f;
            fireLight.intensity = 2f;
            fireLight.enabled = false;

            WoodStove stove = stoveGO.AddComponent<WoodStove>();
            stove.potPlacementPoint = kiengPoint.transform;
            stove.firePointLight = fireLight;
            stove.fireAudioSource = stoveGO.AddComponent<AudioSource>();
            stove.fireAudioSource.spatialBlend = 1f;
            stove.fireAudioSource.playOnAwake = false;
            stove.fireParticles = CreateParticleSystem("FireFX", stoveGO.transform, new Vector3(0f, 0.35f, 0f), new Color(1f, 0.3f, 0.02f), 0.12f);
            stove.smokeParticles = CreateParticleSystem("SmokeFX", stoveGO.transform, new Vector3(0f, 0.55f, 0f), new Color(0.25f, 0.25f, 0.25f, 0.6f), 0.16f);

            return stoveGO;
        }

        private static GameObject CreateCookingPot(Transform parent, Vector3 position)
        {
            GameObject potGO = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            potGO.name = "CookingPot_CastIron";
            potGO.transform.SetParent(parent, false);
            potGO.transform.position = position;
            potGO.transform.localScale = new Vector3(0.4f, 0.3f, 0.4f);

            // Nắp vung
            GameObject lidGO = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            lidGO.name = "PotLid";
            lidGO.transform.SetParent(potGO.transform, false);
            lidGO.transform.localPosition = new Vector3(0f, 0.52f, 0f);
            lidGO.transform.localScale = new Vector3(1.05f, 0.08f, 1.05f);

            PotLid lid = lidGO.AddComponent<PotLid>();

            GameObject lidSnapGO = new GameObject("LidSnapPoint");
            lidSnapGO.transform.SetParent(potGO.transform, false);
            lidSnapGO.transform.localPosition = lidGO.transform.localPosition;
            lidSnapGO.transform.localRotation = lidGO.transform.localRotation;

            // Khối gạo/cơm trong nồi
            GameObject riceVisual = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            riceVisual.name = "RiceVisual";
            riceVisual.transform.SetParent(potGO.transform, false);
            riceVisual.transform.localPosition = new Vector3(0f, 0.1f, 0f);
            riceVisual.transform.localScale = new Vector3(0.9f, 0.2f, 0.9f);
            riceVisual.SetActive(false);

            CookingPot pot = potGO.AddComponent<CookingPot>();
            pot.riceMeshVisual = riceVisual;
            GameObject potWater = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            potWater.name = "PotWaterSurface";
            potWater.transform.SetParent(potGO.transform, false);
            potWater.transform.localPosition = new Vector3(0f, 0.35f, 0f);
            potWater.transform.localScale = new Vector3(0.85f, 0.03f, 0.85f);
            potWater.SetActive(false);
            pot.waterSurfaceVisual = potWater;
            pot.steamParticleFX = CreateParticleSystem("SteamFX", potGO.transform, new Vector3(0f, 0.65f, 0f), new Color(0.9f, 0.9f, 0.9f, 0.55f), 0.08f);
            pot.cookedRiceBowlPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(RiceBowlPrefabPath);
            pot.lidSnapPoint = lidSnapGO.transform;
            lid.attachedPot = pot;

            return potGO;
        }

        private static void CreateFirewoodPile(Transform parent, Vector3 position)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject woodGO = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                woodGO.name = $"Firewood_Log_{i + 1}";
                woodGO.transform.SetParent(parent, false);
                woodGO.transform.position = position + new Vector3(i * 0.15f, 0.05f, 0f);
                woodGO.transform.rotation = Quaternion.Euler(90f, 0f, i * 20f);
                woodGO.transform.localScale = new Vector3(0.08f, 0.35f, 0.08f);

                woodGO.AddComponent<FirewoodItem>();
            }
        }

        private static void CreateMatchItem(Transform parent, Vector3 position)
        {
            GameObject matchGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
            matchGO.name = "MatchBox_And_Stick";
            matchGO.transform.SetParent(parent, false);
            matchGO.transform.position = position;
            matchGO.transform.localScale = new Vector3(0.1f, 0.04f, 0.06f);

            matchGO.AddComponent<MatchItem>();
            MatchItem match = matchGO.GetComponent<MatchItem>();
            match.flameFX = CreateParticleSystem("MatchFlameFX", matchGO.transform, new Vector3(0.55f, 0f, 0f), new Color(1f, 0.25f, 0.02f), 0.035f);

            GameObject strikerGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
            strikerGO.name = "MatchboxStriker";
            strikerGO.transform.SetParent(parent, false);
            strikerGO.transform.position = position + new Vector3(0.2f, 0f, 0f);
            strikerGO.transform.localScale = new Vector3(0.18f, 0.08f, 0.12f);
            strikerGO.AddComponent<MatchStriker>();
        }

        private static void CreateServingLadle(Transform parent, Vector3 position)
        {
            GameObject ladleGO = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            ladleGO.name = "RiceServingLadle";
            ladleGO.transform.SetParent(parent, false);
            ladleGO.transform.position = position;
            ladleGO.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            ladleGO.transform.localScale = new Vector3(0.06f, 0.35f, 0.06f);
            ladleGO.AddComponent<RiceServingLadle>();
        }

        private static void CreateQuestGuide(Transform parent, Vector3 position, GrindMillStation mill, RiceWashingPot wash, WoodStove stove, CookingPot pot)
        {
            GameObject guideGO = new GameObject("Cooking_Quest_Guide_Billboard");
            guideGO.transform.SetParent(parent, false);
            guideGO.transform.position = position;
            guideGO.transform.rotation = Quaternion.Euler(0f, 180f, 0f); // Quay mặt về phía người chơi

            // Text tiêu đề bước
            GameObject titleGO = new GameObject("StepTitleText");
            titleGO.transform.SetParent(guideGO.transform, false);
            titleGO.transform.localPosition = new Vector3(0f, 0.2f, 0f);
            TextMeshPro stepTmp = titleGO.AddComponent<TextMeshPro>();
            stepTmp.text = "🌾 <b>Bước 1:</b> Đổ giỏ thóc vàng vào phễu cối xay gạo.";
            stepTmp.fontSize = 4.5f;
            stepTmp.alignment = TextAlignmentOptions.Center;
            stepTmp.color = new Color(1f, 0.95f, 0.6f);

            // Text tiến độ phụ
            GameObject subGO = new GameObject("ProgressSubText");
            subGO.transform.SetParent(guideGO.transform, false);
            subGO.transform.localPosition = new Vector3(0f, -0.2f, 0f);
            TextMeshPro subTmp = subGO.AddComponent<TextMeshPro>();
            subTmp.text = "Chờ đổ thóc...";
            subTmp.fontSize = 3.5f;
            subTmp.alignment = TextAlignmentOptions.Center;
            subTmp.color = Color.white;

            CookingQuestGuide guide = guideGO.AddComponent<CookingQuestGuide>();
            guide.stepText = stepTmp;
            guide.progressText = subTmp;
            guide.grindMill = mill;
            guide.washingPot = wash;
            guide.woodStove = stove;
            guide.cookingPot = pot;
        }

        private static Scene OpenOrUseMainScene()
        {
            Scene activeScene = SceneManager.GetActiveScene();
            if (activeScene.path == MainScenePath)
            {
                return activeScene;
            }

            return EditorSceneManager.OpenScene(MainScenePath, OpenSceneMode.Single);
        }

        private static ParticleSystem CreateParticleSystem(string name, Transform parent, Vector3 localPosition, Color color, float size)
        {
            GameObject fx = new GameObject(name);
            fx.transform.SetParent(parent, false);
            fx.transform.localPosition = localPosition;
            ParticleSystem particles = fx.AddComponent<ParticleSystem>();
            ParticleSystem.MainModule main = particles.main;
            main.startLifetime = 0.8f;
            main.startSpeed = 0.35f;
            main.startSize = size;
            main.startColor = color;
            main.loop = true;
            main.playOnAwake = false;
            ParticleSystem.EmissionModule emission = particles.emission;
            emission.rateOverTime = 18f;
            particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            return particles;
        }

        private static void EnsureCookingPrefabs()
        {
            if (!AssetDatabase.IsValidFolder("Assets/Khoa/Prefabs")) AssetDatabase.CreateFolder("Assets/Khoa", "Prefabs");
            if (!AssetDatabase.IsValidFolder(CookingPrefabFolder)) AssetDatabase.CreateFolder("Assets/Khoa/Prefabs", "Cooking");

            if (AssetDatabase.LoadAssetAtPath<GameObject>(WhiteRicePrefabPath) == null)
            {
                GameObject rice = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                rice.name = "WhiteRiceBatch";
                rice.transform.localScale = new Vector3(0.28f, 0.12f, 0.28f);
                rice.AddComponent<WhiteRiceItem>();
                PrefabUtility.SaveAsPrefabAsset(rice, WhiteRicePrefabPath);
                UnityEngine.Object.DestroyImmediate(rice);
            }

            if (AssetDatabase.LoadAssetAtPath<GameObject>(PaddyBatchPrefabPath) == null)
            {
                GameObject paddy = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                paddy.name = "PaddyBatch";
                paddy.transform.localScale = new Vector3(0.3f, 0.16f, 0.3f);
                paddy.AddComponent<PaddyBatchItem>();
                PrefabUtility.SaveAsPrefabAsset(paddy, PaddyBatchPrefabPath);
                UnityEngine.Object.DestroyImmediate(paddy);
            }

            if (AssetDatabase.LoadAssetAtPath<GameObject>(RiceBowlPrefabPath) == null)
            {
                GameObject bowl = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                bowl.name = "CookedRiceBowl";
                bowl.transform.localScale = new Vector3(0.22f, 0.14f, 0.22f);
                bowl.AddComponent<CookedRiceBowl>();
                PrefabUtility.SaveAsPrefabAsset(bowl, RiceBowlPrefabPath);
                UnityEngine.Object.DestroyImmediate(bowl);
            }

            AssetDatabase.SaveAssets();
        }

        private static void ConfigureThresherPhysicalOutputs()
        {
            GameObject paddyPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(PaddyBatchPrefabPath);
            foreach (RiceThresherBasketReceiver receiver in UnityEngine.Object.FindObjectsByType<RiceThresherBasketReceiver>(FindObjectsInactive.Include, FindObjectsSortMode.None))
            {
                receiver.paddyBatchPrefab = paddyPrefab;
                if (receiver.paddyOutputPoint == null)
                {
                    GameObject point = new GameObject("PaddyPhysicalOutputPoint");
                    point.transform.SetParent(receiver.transform, false);
                    point.transform.localPosition = new Vector3(0.8f, 0.6f, 0f);
                    receiver.paddyOutputPoint = point.transform;
                }
                PrefabUtility.RecordPrefabInstancePropertyModifications(receiver);
                EditorUtility.SetDirty(receiver);
            }
        }

        private static void ValidateSetupOrThrow(GameObject setupRoot)
        {
            if (setupRoot == null) throw new InvalidOperationException("Cooking setup root was not created.");
            GrindMillStation mill = setupRoot.GetComponentInChildren<GrindMillStation>(true);
            WaterDipper dipper = setupRoot.GetComponentInChildren<WaterDipper>(true);
            RiceWashingPot wash = setupRoot.GetComponentInChildren<RiceWashingPot>(true);
            WoodStove stove = setupRoot.GetComponentInChildren<WoodStove>(true);
            CookingPot pot = setupRoot.GetComponentInChildren<CookingPot>(true);
            if (mill == null || mill.hopperTrigger == null || mill.whiteRicePrefab == null || mill.riceOutputPoint == null)
                throw new InvalidOperationException("Grind mill has missing required references.");
            if (dipper == null || dipper.pourOrigin == null || dipper.pourWaterFX == null)
                throw new InvalidOperationException("Water dipper has missing required references.");
            if (wash == null || wash.waterSurfaceRenderer == null || wash.drainWaterFX == null)
                throw new InvalidOperationException("Washing station has missing required references.");
            if (stove == null || stove.fireParticles == null || stove.smokeParticles == null || stove.potPlacementPoint == null)
                throw new InvalidOperationException("Wood stove has missing required references.");
            if (pot == null || pot.waterSurfaceVisual == null || pot.steamParticleFX == null || pot.cookedRiceBowlPrefab == null)
                throw new InvalidOperationException("Cooking pot has missing required references.");
            if (setupRoot.GetComponentsInChildren<GrindMillHopperReceiver>(true).Length != 1)
                throw new InvalidOperationException("Cooking setup must contain exactly one hopper receiver.");
        }
    }
}
