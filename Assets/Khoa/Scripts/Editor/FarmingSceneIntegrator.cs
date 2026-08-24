using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;
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
        private const string XriInputActionsPath =
            "Assets/Samples/XR Interaction Toolkit/3.3.2/Starter Assets/XRI Default Input Actions.inputactions";

        [MenuItem("Khoa/Farming/Apply Main Scene Integration")]
        public static void ApplyMainSceneSetup()
        {
            Scene scene = OpenOrUseMainScene();
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

            GameObject previousSetup = FindSceneObjectByName(SetupRootName);
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

        internal static Scene OpenOrUseMainScene()
        {
            Scene activeScene = SceneManager.GetActiveScene();
            if (activeScene.IsValid() &&
                string.Equals(activeScene.path, MainScenePath, StringComparison.OrdinalIgnoreCase))
            {
                return activeScene;
            }

            if (activeScene.IsValid() && activeScene.isDirty)
            {
                if (Application.isBatchMode)
                {
                    throw new InvalidOperationException(
                        "Cannot open the farming scene in batch mode while another scene has unsaved changes.");
                }

                if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                {
                    throw new OperationCanceledException(
                        "Main scene integration was cancelled so unsaved scene changes remain intact.");
                }
            }

            return EditorSceneManager.OpenScene(MainScenePath, OpenSceneMode.Single);
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
            GameObject waterPlane = FindSceneObjectByName("FieldWaterPlane");
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
            PlaceObjectOnTerrain(
                gateObject,
                new Vector3(fieldBounds.min.x - 2f, 0f, fieldBounds.center.z),
                waterHeight + 1f,
                0.02f);

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
            PlaceObjectOnTerrain(
                yardObject,
                new Vector3(fieldBounds.max.x + 6f, 0f, fieldBounds.center.z + 4f),
                waterHeight + 0.05f,
                0.02f);

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
            PlaceObjectOnTerrain(
                thresherObject,
                new Vector3(fieldBounds.max.x + 11f, 0f, fieldBounds.center.z + 4f),
                waterHeight + 0.5f,
                0.02f);

            RiceThresher thresher = thresherObject.GetComponent<RiceThresher>();
            thresher.basketReceiver = thresherObject.GetComponent<RiceThresherBasketReceiver>();
            ParticleSystem grainFx = FarmingParticleFactory.CreateGrainBurstFX(thresher.transform);
            grainFx.transform.localPosition = Vector3.up * 0.5f;
            thresher.grainParticleFX = grainFx;
            return thresher;
        }

        private static void CreatePhysicalBasket(Transform parent, Transform thresher, float waterHeight)
        {
            GameObject basket = InstantiatePrefab("Assets/MyFolder/Prefabs/Basket.prefab", parent);
            basket.name = "Khoa_Thresher_Rice_Basket";
            PlaceObjectOnTerrain(
                basket,
                new Vector3(thresher.position.x + 1.5f, 0f, thresher.position.z),
                waterHeight + 0.25f,
                0.02f);
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
            GameObject house = FindSceneObjectByName("StiltHouse");
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

        internal static void PlaceObjectOnTerrain(
            GameObject target,
            Vector3 horizontalPosition,
            float fallbackY,
            float bottomClearance)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            target.transform.position = new Vector3(horizontalPosition.x, fallbackY, horizontalPosition.z);
            Terrain terrain = FindTerrainAt(horizontalPosition);
            if (terrain == null)
            {
                return;
            }

            TerrainData data = terrain.terrainData;
            Vector3 terrainLocalPoint = horizontalPosition - terrain.transform.position;
            float normalizedX = Mathf.Clamp01(terrainLocalPoint.x / data.size.x);
            float normalizedZ = Mathf.Clamp01(terrainLocalPoint.z / data.size.z);
            float groundY = terrain.transform.position.y + data.GetInterpolatedHeight(normalizedX, normalizedZ);

            Physics.SyncTransforms();
            Collider[] colliders = target.GetComponentsInChildren<Collider>(true);
            Collider[] enabledColliders = colliders
                .Where(collider => collider != null && collider.enabled)
                .ToArray();
            float currentBottom = enabledColliders.Length > 0
                ? enabledColliders.Min(collider => collider.bounds.min.y)
                : target.transform.position.y;
            float bottomOffset = currentBottom - target.transform.position.y;
            target.transform.position = new Vector3(
                horizontalPosition.x,
                groundY + Mathf.Max(0f, bottomClearance) - bottomOffset,
                horizontalPosition.z);
            Physics.SyncTransforms();
        }

        private static Terrain FindTerrainAt(Vector3 worldPosition)
        {
            Scene activeScene = SceneManager.GetActiveScene();
            return UnityEngine.Object.FindObjectsByType<Terrain>(
                    FindObjectsInactive.Include,
                    FindObjectsSortMode.None)
                .FirstOrDefault(terrain =>
                {
                    if (terrain == null || terrain.terrainData == null || terrain.gameObject.scene != activeScene)
                    {
                        return false;
                    }

                    Vector3 origin = terrain.transform.position;
                    Vector3 size = terrain.terrainData.size;
                    return worldPosition.x >= origin.x && worldPosition.x <= origin.x + size.x &&
                           worldPosition.z >= origin.z && worldPosition.z <= origin.z + size.z;
                });
        }

        private static void AttachPlowToBuffalo()
        {
            MonoBehaviour buffaloRider = UnityEngine.Object.FindObjectsByType<MonoBehaviour>(
                    FindObjectsInactive.Include,
                    FindObjectsSortMode.None)
                .FirstOrDefault(component => component != null && component.GetType().Name == "BuffaloRider");

            if (buffaloRider == null)
            {
                return;
            }

            WireBuffaloInputActions(buffaloRider);

            BuffaloPlowAttachment existingPlow =
                buffaloRider.GetComponentInChildren<BuffaloPlowAttachment>(true);
            if (existingPlow != null)
            {
                existingPlow.EnsurePhysicsSetup();
                EditorUtility.SetDirty(existingPlow.gameObject);
                return;
            }

            GameObject plowObject = new GameObject("Khoa_Buffalo_Plow_Blade");
            plowObject.transform.SetParent(buffaloRider.transform);
            plowObject.transform.localPosition = new Vector3(0f, 0.2f, -1.2f);
            plowObject.transform.localRotation = Quaternion.identity;
            BuffaloPlowAttachment plow = plowObject.AddComponent<BuffaloPlowAttachment>();
            plow.EnsurePhysicsSetup();
            ParticleSystem mudFx = FarmingParticleFactory.CreateMudDustFX(plow.transform);
            mudFx.transform.localPosition = Vector3.zero;
            plow.plowDustParticles = mudFx;
        }

        internal static void WireBuffaloInputActions(MonoBehaviour buffaloRider)
        {
            if (buffaloRider == null)
            {
                throw new ArgumentNullException(nameof(buffaloRider));
            }

            InputActionReference[] actionReferences = AssetDatabase.LoadAllAssetsAtPath(XriInputActionsPath)
                .OfType<InputActionReference>()
                .ToArray();

            if (actionReferences.Length == 0)
            {
                throw new InvalidOperationException($"Missing XRI input action references: {XriInputActionsPath}");
            }

            SerializedObject serializedRider = new SerializedObject(buffaloRider);
            AssignInputAction(serializedRider, "leftTriggerAction", actionReferences,
                "XRI Left Interaction", "Select");
            AssignInputAction(serializedRider, "rightTriggerAction", actionReferences,
                "XRI Right Interaction", "Select");
            AssignInputAction(serializedRider, "moveAction", actionReferences,
                "XRI Left Locomotion", "Move");
            serializedRider.ApplyModifiedPropertiesWithoutUndo();
            EditorUtility.SetDirty(buffaloRider);
        }

        private static void AssignInputAction(
            SerializedObject target,
            string propertyName,
            IEnumerable<InputActionReference> references,
            string mapName,
            string actionName)
        {
            SerializedProperty property = target.FindProperty(propertyName);
            if (property == null)
            {
                throw new InvalidOperationException(
                    $"{target.targetObject.GetType().Name} is missing input property '{propertyName}'.");
            }

            InputActionReference matchingReference = references.FirstOrDefault(reference =>
                reference != null &&
                reference.action != null &&
                reference.action.actionMap != null &&
                reference.action.actionMap.name == mapName &&
                reference.action.name == actionName);

            if (matchingReference == null)
            {
                throw new InvalidOperationException(
                    $"Cannot find input action '{mapName}/{actionName}' in {XriInputActionsPath}.");
            }

            property.objectReferenceValue = matchingReference;
        }

        private static GameObject FindSceneObjectByName(string objectName)
        {
            Scene activeScene = SceneManager.GetActiveScene();
            return UnityEngine.Object.FindObjectsByType<Transform>(
                    FindObjectsInactive.Include,
                    FindObjectsSortMode.None)
                .Where(transform => transform != null && transform.name == objectName)
                .Select(transform => transform.gameObject)
                .FirstOrDefault(gameObject => gameObject.scene == activeScene);
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
