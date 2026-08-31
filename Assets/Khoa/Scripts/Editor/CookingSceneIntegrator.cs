using System;
using System.Collections.Generic;
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

        [MenuItem("Khoa/Cooking/Apply Kitchen & Grind Mill Setup")]
        public static void ApplyCookingAndMillSetup()
        {
            Scene scene = OpenOrUseMainScene();

            GameObject previousSetup = GameObject.Find(SetupRootName);
            if (previousSetup != null)
            {
                UnityEngine.Object.DestroyImmediate(previousSetup);
            }

            GameObject setupRoot = new GameObject(SetupRootName);

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

            // 2. Tạo Chum Nước
            GameObject jarGO = CreateWaterJar(setupRoot.transform, kitchenBasePos + new Vector3(0f, 0f, 2f));

            // 3. Tạo Bàn Bếp Gỗ
            GameObject kitchenTableGO = CreateKitchenTable(setupRoot.transform, kitchenBasePos + new Vector3(0f, 0f, 0f));

            // 4. Tạo Thau Vo Gạo & Gáo Múc Nước
            GameObject washingPotGO = CreateRiceWashingStation(setupRoot.transform, kitchenTableGO.transform.position + new Vector3(-0.5f, 0.85f, 0f));
            GameObject dipperGO = CreateWaterDipper(setupRoot.transform, jarGO.transform.position + new Vector3(0.3f, 0.9f, 0f));

            // 5. Tạo Bếp Củi
            GameObject stoveGO = CreateWoodStove(setupRoot.transform, kitchenBasePos + new Vector3(2.5f, 0f, 0f));

            // 6. Tạo Nồi Gang Nấu Cơm & Nắp Vung
            GameObject potGO = CreateCookingPot(setupRoot.transform, stoveGO.transform.position + new Vector3(0f, 0.45f, 0f));

            // 7. Tạo Củi Khô & Hộp Diêm
            CreateFirewoodPile(setupRoot.transform, stoveGO.transform.position + new Vector3(0.8f, 0f, -0.5f));
            CreateMatchItem(setupRoot.transform, kitchenTableGO.transform.position + new Vector3(0.5f, 0.85f, 0.2f));

            Debug.Log("<color=green>[CookingSceneIntegrator] ✅ Đã hoàn tất setup Cối Xay Gạo và Khu Bếp Miền Tây vào Scene chính!</color>");

            EditorSceneManager.MarkSceneDirty(scene);
            EditorSceneManager.SaveScene(scene);
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

            // Trigger đổ lúa
            BoxCollider hopperCol = hopper.GetComponent<BoxCollider>();
            if (hopperCol != null) hopperCol.isTrigger = true;
            station.hopperTrigger = hopperCol;

            // AudioSource
            station.grindingAudioSource = millGO.AddComponent<AudioSource>();
            station.grindingAudioSource.spatialBlend = 1f;

            return millGO;
        }

        private static GameObject CreateWaterJar(Transform parent, Vector3 position)
        {
            GameObject jarGO = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            jarGO.name = "WaterJar_Station";
            jarGO.tag = "Water";
            jarGO.transform.SetParent(parent, false);
            jarGO.transform.position = position;
            jarGO.transform.localScale = new Vector3(0.9f, 0.8f, 0.9f);

            // Mặt nước
            GameObject waterPlane = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            waterPlane.name = "WaterSurface";
            waterPlane.tag = "Water";
            waterPlane.transform.SetParent(jarGO.transform, false);
            waterPlane.transform.localPosition = new Vector3(0f, 0.4f, 0f);
            waterPlane.transform.localScale = new Vector3(0.85f, 0.05f, 0.85f);

            return jarGO;
        }

        private static GameObject CreateKitchenTable(Transform parent, Vector3 position)
        {
            GameObject tableGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
            tableGO.name = "KitchenTable";
            tableGO.transform.SetParent(parent, false);
            tableGO.transform.position = position + new Vector3(0f, 0.4f, 0f);
            tableGO.transform.localScale = new Vector3(1.6f, 0.8f, 0.8f);
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

            return dipperGO;
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

            // Khối gạo/cơm trong nồi
            GameObject riceVisual = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            riceVisual.name = "RiceVisual";
            riceVisual.transform.SetParent(potGO.transform, false);
            riceVisual.transform.localPosition = new Vector3(0f, 0.1f, 0f);
            riceVisual.transform.localScale = new Vector3(0.9f, 0.2f, 0.9f);
            riceVisual.SetActive(false);

            CookingPot pot = potGO.AddComponent<CookingPot>();
            pot.riceMeshVisual = riceVisual;
            pot.lidSnapPoint = lidGO.transform;
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
    }
}
