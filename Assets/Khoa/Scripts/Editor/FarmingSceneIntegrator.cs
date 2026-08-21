using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Khoa.Farming.Editor
{
    /// <summary>
    /// Idempotent setup for the playable farming slice in the main scene.
    /// Run from the menu or through Unity CLI executeMethod.
    /// </summary>
    public static class FarmingSceneIntegrator
    {
        private const string MainScenePath = "Assets/Scenes/Grind mill v1.0 Scene.unity";
        private const string SetupRootName = "Khoa_Farming_Runtime_Setup";

        [MenuItem("Khoa/Farming/Apply Main Scene Integration")]
        public static void ApplyMainSceneSetup()
        {
            Scene scene = EditorSceneManager.OpenScene(MainScenePath, OpenSceneMode.Single);
            CropPlot[] allPlots = UnityEngine.Object.FindObjectsByType<CropPlot>(
                FindObjectsInactive.Include,
                FindObjectsSortMode.None);

            if (allPlots.Length == 0)
            {
                throw new InvalidOperationException("Main scene does not contain a CropPlot grid.");
            }

            Transform fieldRoot = FindFieldRoot(allPlots);
            List<CropPlot> playablePlots = PreparePlotsForIntegration(
                allPlots.Where(plot => plot != null && plot.transform.parent == fieldRoot));

            GameObject previousSetup = GameObject.Find(SetupRootName);
            if (previousSetup != null)
            {
                UnityEngine.Object.DestroyImmediate(previousSetup);
            }

            GameObject setupRoot = new GameObject(SetupRootName);
            Bounds fieldBounds = CalculatePlotBounds(playablePlots);
            float waterHeight = FindPaddyWaterHeight(playablePlots);

            SluiceGate gate = CreateGate(setupRoot.transform, fieldBounds, waterHeight, playablePlots);
            RiceDryingYard yard = CreateDryingYard(setupRoot.transform, fieldBounds, waterHeight);
            RiceThresher thresher = CreateThresher(setupRoot.transform, fieldBounds, waterHeight);
            CreatePhysicalBasket(setupRoot.transform, thresher.transform, waterHeight);
            CreateWeatherSystem(setupRoot.transform);
            CreateShelterZone(setupRoot.transform);
            AttachPlowToBuffalo();

            EditorUtility.SetDirty(gate);
            EditorUtility.SetDirty(yard);
            EditorUtility.SetDirty(thresher);
            EditorSceneManager.MarkSceneDirty(scene);
            EditorSceneManager.SaveScene(scene);
            AssetDatabase.SaveAssets();

            Debug.Log($"[Khoa Farming] Main scene integrated with {playablePlots.Count} plots and all runtime stations.");
        }

        private static Transform FindFieldRoot(IEnumerable<CropPlot> plots)
        {
            return plots
                .GroupBy(plot => plot.transform.parent)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key)
                .First(parent => parent != null);
        }

        internal static List<CropPlot> PreparePlotsForIntegration(IEnumerable<CropPlot> plots)
        {
            List<CropPlot> preparedPlots = plots.Where(plot => plot != null).ToList();
            foreach (CropPlot plot in preparedPlots)
            {
                XRSimpleInteractable interactable = plot.GetComponent<XRSimpleInteractable>();
                if (interactable != null)
                {
                    interactable.enabled = false;
                }
            }

            return preparedPlots;
        }

        private static float FindPaddyWaterHeight(IEnumerable<CropPlot> plots)
        {
            GameObject waterPlane = GameObject.Find("FieldWaterPlane");
            return waterPlane != null
                ? waterPlane.transform.position.y
                : plots.Average(plot => plot.transform.position.y) + 0.08f;
        }

        private static Bounds CalculatePlotBounds(IReadOnlyList<CropPlot> plots)
        {
            Bounds bounds = new Bounds(plots[0].transform.position, Vector3.zero);
            for (int i = 1; i < plots.Count; i++)
            {
                bounds.Encapsulate(plots[i].transform.position);
            }

            return bounds;
        }

        private static SluiceGate CreateGate(
            Transform parent,
            Bounds fieldBounds,
            float waterHeight,
            IReadOnlyCollection<CropPlot> plots)
        {
            GameObject gateObject = InstantiatePrefab("Assets/Khoa/Prefabs/Sluice_Gate_Prefab.prefab", parent);
            gateObject.name = "Khoa_Sluice_Gate";
            gateObject.transform.position = new Vector3(fieldBounds.min.x - 2f, waterHeight + 1f, fieldBounds.center.z);

            SluiceGate gate = gateObject.GetComponent<SluiceGate>();
            gate.connectedPlots.Clear();
            gate.connectedPlots.AddRange(plots);
            gate.autoFindNearbyPlotsOnStart = false;
            ParticleSystem waterFx = FarmingParticleFactory.CreateWaterFlowFX(gate.transform);
            waterFx.transform.localPosition = new Vector3(0f, -0.75f, 0.3f);
            gate.waterFlowParticles = waterFx.gameObject;
            gate.waterFlowParticles.SetActive(false);
            return gate;
        }

        private static RiceDryingYard CreateDryingYard(Transform parent, Bounds fieldBounds, float waterHeight)
        {
            GameObject yardObject = InstantiatePrefab("Assets/Khoa/Prefabs/Rice_Drying_Yard_Prefab.prefab", parent);
            yardObject.name = "Khoa_Rice_Drying_Yard";
            yardObject.transform.position = new Vector3(fieldBounds.max.x + 6f, waterHeight + 0.05f, fieldBounds.center.z + 4f);

            RiceDryingYard yard = yardObject.GetComponent<RiceDryingYard>();
            ParticleSystem steamFx = FarmingParticleFactory.CreateSteamFX(yard.transform);
            steamFx.transform.localPosition = Vector3.up * 0.1f;
            yard.steamParticleFX = steamFx;
            return yard;
        }

        private static RiceThresher CreateThresher(Transform parent, Bounds fieldBounds, float waterHeight)
        {
            GameObject thresherObject = InstantiatePrefab("Assets/Khoa/Prefabs/Rice_Thresher_Prefab.prefab", parent);
            thresherObject.name = "Khoa_Rice_Thresher";
            thresherObject.transform.position = new Vector3(fieldBounds.max.x + 11f, waterHeight + 0.5f, fieldBounds.center.z + 4f);

            RiceThresher thresher = thresherObject.GetComponent<RiceThresher>();
            thresher.basketReceiver = thresherObject.GetComponent<RiceThresherBasketReceiver>();
            ParticleSystem grainFx = FarmingParticleFactory.CreateGrainBurstFX(thresher.transform);
            grainFx.transform.localPosition = Vector3.up * 0.5f;
            thresher.grainParticleFX = grainFx;
            return thresher;
        }

        private static void CreatePhysicalBasket(Transform parent, Transform thresher, float waterHeight)
        {
            MonoBehaviour existingController = UnityEngine.Object.FindObjectsByType<MonoBehaviour>(
                    FindObjectsInactive.Include,
                    FindObjectsSortMode.None)
                .FirstOrDefault(component => component != null && component.GetType().Name == "RiceBasketController");

            GameObject basket = existingController != null
                ? existingController.gameObject
                : InstantiatePrefab("Assets/MyFolder/Prefabs/Basket.prefab", parent);

            basket.transform.SetParent(parent, true);
            basket.name = "Khoa_Thresher_Rice_Basket";
            basket.transform.position = new Vector3(
                thresher.position.x + 1.5f,
                waterHeight + 0.25f,
                thresher.position.z);
        }

        private static void CreateWeatherSystem(Transform parent)
        {
            GameObject weatherObject = new GameObject("Khoa_Farming_Weather_System");
            weatherObject.transform.SetParent(parent);
            FarmingWeatherSystem weather = weatherObject.AddComponent<FarmingWeatherSystem>();
            weather.autoCycleWeather = true;
            weather.weatherChangeInterval = 120f;
        }

        private static void CreateShelterZone(Transform parent)
        {
            GameObject house = GameObject.Find("StiltHouse");
            Bounds shelterBounds = house != null
                ? CalculateObjectBounds(house)
                : new Bounds(new Vector3(-14f, 103f, -22f), new Vector3(12f, 5f, 10f));

            GameObject shelterObject = new GameObject("Khoa_Rice_Shelter_Zone");
            shelterObject.transform.SetParent(parent);
            shelterObject.transform.position = shelterBounds.center;
            BoxCollider collider = shelterObject.AddComponent<BoxCollider>();
            collider.isTrigger = true;
            collider.size = new Vector3(
                Mathf.Max(2f, shelterBounds.size.x),
                Mathf.Max(2f, shelterBounds.size.y),
                Mathf.Max(2f, shelterBounds.size.z));
            shelterObject.AddComponent<RiceShelterZone>();
        }

        private static Bounds CalculateObjectBounds(GameObject root)
        {
            Renderer[] renderers = root.GetComponentsInChildren<Renderer>(true);
            if (renderers.Length == 0)
            {
                return new Bounds(root.transform.position, new Vector3(4f, 3f, 4f));
            }

            Bounds bounds = renderers[0].bounds;
            for (int i = 1; i < renderers.Length; i++)
            {
                bounds.Encapsulate(renderers[i].bounds);
            }

            return bounds;
        }

        private static void AttachPlowToBuffalo()
        {
            MonoBehaviour buffaloRider = UnityEngine.Object.FindObjectsByType<MonoBehaviour>(
                    FindObjectsInactive.Include,
                    FindObjectsSortMode.None)
                .FirstOrDefault(component => component != null && component.GetType().Name == "BuffaloRider");

            if (buffaloRider == null || buffaloRider.GetComponentInChildren<BuffaloPlowAttachment>(true) != null)
            {
                return;
            }

            GameObject plowObject = new GameObject("Khoa_Buffalo_Plow_Blade");
            plowObject.transform.SetParent(buffaloRider.transform);
            plowObject.transform.localPosition = new Vector3(0f, 0.2f, -1.2f);
            plowObject.transform.localRotation = Quaternion.identity;
            BuffaloPlowAttachment plow = plowObject.AddComponent<BuffaloPlowAttachment>();
            ParticleSystem mudFx = FarmingParticleFactory.CreateMudDustFX(plow.transform);
            mudFx.transform.localPosition = Vector3.zero;
            plow.plowDustParticles = mudFx;
        }

        private static GameObject InstantiatePrefab(string assetPath, Transform parent)
        {
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
            if (prefab == null)
            {
                throw new InvalidOperationException($"Missing prefab: {assetPath}");
            }

            return (GameObject)PrefabUtility.InstantiatePrefab(prefab, parent);
        }
    }
}
