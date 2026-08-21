using System.Reflection;
using System.Linq;
using System.Collections;
using Khoa.Farming;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Khoa.Farming.Tests
{
    public class FarmingRegressionTests
    {
        private const string ThresherPrefabPath = "Assets/Khoa/Prefabs/Rice_Thresher_Prefab.prefab";
        private const string MainScenePath = "Assets/Scenes/Grind mill v1.0 Scene.unity";

        [Test]
        public void ThresherPrefab_HasValidBasketReceiverScript()
        {
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(ThresherPrefabPath);

            Assert.IsNotNull(prefab);
            Assert.Zero(GameObjectUtility.GetMonoBehavioursWithMissingScriptCount(prefab));
            Assert.IsNotNull(prefab.GetComponent<RiceThresherBasketReceiver>());
        }

        [Test]
        public void CropPlot_GenericSelect_DoesNotAdvanceFarmingState()
        {
            GameObject plotObject = new GameObject("SelectSafetyPlot");
            CropPlot plot = plotObject.AddComponent<CropPlot>();
            MethodInfo interactMethod = typeof(CropPlot).GetMethod(
                "InteractWithPlot",
                BindingFlags.Instance | BindingFlags.NonPublic);

            Assert.IsNotNull(interactMethod);
            interactMethod.Invoke(plot, null);

            Assert.AreEqual(PlotState.Empty, plot.currentState,
                "Selecting bare soil must not replace the Plow tool interaction.");
            Object.DestroyImmediate(plotObject);
        }

        [TestCase(25f, CropState.Growing)]
        [TestCase(60f, CropState.Maturing)]
        [TestCase(90f, CropState.ReadyToHarvest)]
        public void RicePlant_UsesDocumentedGrowthThresholds(float progress, CropState expectedState)
        {
            GameObject riceObject = new GameObject("ThresholdRice");
            RicePlant plant = riceObject.AddComponent<RicePlant>();
            MethodInfo updateStateMethod = typeof(RicePlant).GetMethod(
                "UpdateStateBasedOnProgress",
                BindingFlags.Instance | BindingFlags.NonPublic);

            plant.growthProgress = progress;
            updateStateMethod.Invoke(plant, null);

            Assert.AreEqual(expectedState, plant.currentState);
            Object.DestroyImmediate(riceObject);
        }

        [Test]
        public void CropPlot_EmptyFloodedSoil_ShowsWaterSurfaceAtSeventyPercent()
        {
            GameObject plotObject = new GameObject("FloodedEmptyPlot");
            CropPlot plot = plotObject.AddComponent<CropPlot>();
            GameObject waterSurface = new GameObject("WaterSurface");
            waterSurface.transform.SetParent(plotObject.transform);
            waterSurface.SetActive(false);
            plot.waterSurfaceMesh = waterSurface;

            plot.UpdateSoilMoistureVisuals(0.7f);

            Assert.IsTrue(waterSurface.activeSelf);
            Object.DestroyImmediate(plotObject);
        }

        [Test]
        public void RiceThresher_WithoutGrainReceiver_DoesNotConsumeBundle()
        {
            GameObject thresherObject = new GameObject("ReceiverlessThresher");
            RiceThresher thresher = thresherObject.AddComponent<RiceThresher>();
            GameObject bundleObject = new GameObject("DryBundle");
            bundleObject.AddComponent<CapsuleCollider>();
            RiceBundleItem bundle = bundleObject.AddComponent<RiceBundleItem>();
            bundle.AddDryness(100f);

            bool result = thresher.ThreshRiceBundle(bundle);

            Assert.IsFalse(result);
            Assert.IsNotNull(bundle, "The dry bundle must remain when no output can accept its grain.");
            Object.DestroyImmediate(bundleObject);
            Object.DestroyImmediate(thresherObject);
        }

        [Test]
        public void BasketReceiver_WithNearbyPhysicalBasket_AcceptsGrainTransaction()
        {
            System.Type basketType = System.Type.GetType("RiceBasketController, Assembly-CSharp");
            Assert.IsNotNull(basketType);

            GameObject basketObject = new GameObject("PhysicalRiceBasket");
            new GameObject("Basket_rice_bunch").transform.SetParent(basketObject.transform);
            basketObject.AddComponent<BoxCollider>();
            MonoBehaviour basket = basketObject.AddComponent(basketType) as MonoBehaviour;
            basketType.GetMethod("Awake", BindingFlags.Instance | BindingFlags.NonPublic)
                .Invoke(basket, null);

            GameObject receiverObject = new GameObject("TransactionalReceiver");
            receiverObject.AddComponent<BoxCollider>();
            receiverObject.AddComponent<RiceThresher>();
            RiceThresherBasketReceiver receiver = receiverObject.AddComponent<RiceThresherBasketReceiver>();
            MethodInfo receiveMethod = typeof(RiceThresherBasketReceiver).GetMethod("TryReceiveGrain");

            Assert.IsNotNull(receiveMethod, "The receiver needs a success/failure transaction API.");
            bool accepted = (bool)receiveMethod.Invoke(receiver, new object[] { 10 });
            bool isFull = (bool)basketType.GetMethod("IsFull").Invoke(basket, null);

            Assert.IsTrue(accepted);
            Assert.IsTrue(isFull);
            Object.DestroyImmediate(receiverObject);
            Object.DestroyImmediate(basketObject);
        }

        [Test]
        public void GleaningProgress_NewSession_ResetsStaticCounter()
        {
            GleanedRiceStalk.currentGleanedCount = 2;
            MethodInfo resetMethod = typeof(GleanedRiceStalk).GetMethod(
                "ResetGleaningProgress",
                BindingFlags.Static | BindingFlags.NonPublic);

            Assert.IsNotNull(resetMethod);
            resetMethod.Invoke(null, null);
            Assert.Zero(GleanedRiceStalk.currentGleanedCount);
        }

        [Test]
        public void FarmingSceneIntegrator_PreparationPreservesEveryPlotTransform()
        {
            GameObject root = new GameObject("TerrainMappedGrid");
            CropPlot first = CreateMappedPlot(root.transform, new Vector3(2f, 4f, 6f), Quaternion.Euler(8f, 0f, 3f));
            CropPlot second = CreateMappedPlot(root.transform, new Vector3(-3f, 7f, 9f), Quaternion.Euler(-5f, 4f, 11f));
            Vector3[] positions = { first.transform.position, second.transform.position };
            Quaternion[] rotations = { first.transform.rotation, second.transform.rotation };

            System.Type integratorType = FindEditorType("Khoa.Farming.Editor.FarmingSceneIntegrator");
            MethodInfo prepareMethod = integratorType?.GetMethod(
                "PreparePlotsForIntegration",
                BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            Assert.IsNotNull(prepareMethod, "Integration needs a transform-preserving plot preparation API.");
            IEnumerable prepared = prepareMethod.Invoke(null, new object[] { new[] { first, second } }) as IEnumerable;
            Assert.IsNotNull(prepared);
            Assert.AreEqual(2, prepared.Cast<object>().Count());
            Assert.AreEqual(positions[0], first.transform.position);
            Assert.AreEqual(positions[1], second.transform.position);
            Assert.AreEqual(rotations[0], first.transform.rotation);
            Assert.AreEqual(rotations[1], second.transform.rotation);

            Object.DestroyImmediate(root);
        }

        [Test]
        public void TerrainPlacement_MultiSampleKeepsWholePlotAboveUnevenGround()
        {
            TerrainData terrainData = new TerrainData
            {
                heightmapResolution = 33,
                size = new Vector3(10f, 2f, 10f)
            };
            float[,] heights = new float[33, 33];
            for (int z = 0; z < 33; z++)
            {
                for (int x = 0; x < 33; x++)
                {
                    float slope = x / 32f * 0.12f;
                    float dx = (x - 21f) / 4f;
                    float dz = (z - 21f) / 4f;
                    heights[z, x] = slope + 0.18f * Mathf.Exp(-(dx * dx + dz * dz));
                }
            }
            terrainData.SetHeights(0, 0, heights);

            GameObject terrainObject = Terrain.CreateTerrainGameObject(terrainData);
            Terrain terrain = terrainObject.GetComponent<Terrain>();
            GameObject plot = GameObject.CreatePrimitive(PrimitiveType.Cube);
            plot.transform.localScale = new Vector3(3f, 0.1f, 3f);

            System.Type placementType = FindEditorType("Khoa.Farming.Editor.TerrainPlotPlacement");
            MethodInfo placeMethod = placementType?.GetMethod(
                "TryPlaceOnTerrain",
                BindingFlags.Static | BindingFlags.Public);

            Assert.IsNotNull(placeMethod, "Grid generation needs a reusable multi-sample terrain placement utility.");
            const float clearance = 0.05f;
            bool placed = (bool)placeMethod.Invoke(null, new object[]
            {
                plot,
                terrain,
                new Vector3(5f, 0f, 5f),
                clearance,
                3
            });

            Assert.IsTrue(placed);
            BoxCollider collider = plot.GetComponent<BoxCollider>();
            for (int z = 0; z < 3; z++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Vector3 localPoint = collider.center + new Vector3(
                        Mathf.Lerp(-collider.size.x * 0.5f, collider.size.x * 0.5f, x / 2f),
                        -collider.size.y * 0.5f,
                        Mathf.Lerp(-collider.size.z * 0.5f, collider.size.z * 0.5f, z / 2f));
                    Vector3 worldPoint = plot.transform.TransformPoint(localPoint);
                    float terrainHeight = SampleTerrainHeight(terrain, worldPoint);
                    Assert.GreaterOrEqual(worldPoint.y + 0.002f, terrainHeight + clearance,
                        $"Plot penetrated terrain at sample ({x}, {z}).");
                }
            }

            Object.DestroyImmediate(plot);
            Object.DestroyImmediate(terrainObject);
            Object.DestroyImmediate(terrainData);
        }

        [Test]
        public void TerrainPlacement_FootprintCanCrossAdjacentTerrainTiles()
        {
            TerrainData leftData = CreateFlatTerrainData();
            TerrainData rightData = CreateFlatTerrainData();
            GameObject leftObject = Terrain.CreateTerrainGameObject(leftData);
            GameObject rightObject = Terrain.CreateTerrainGameObject(rightData);
            rightObject.transform.position = new Vector3(10f, 0f, 0f);
            Terrain leftTerrain = leftObject.GetComponent<Terrain>();

            GameObject plot = GameObject.CreatePrimitive(PrimitiveType.Cube);
            plot.transform.localScale = new Vector3(3f, 0.1f, 3f);
            System.Type placementType = FindEditorType("Khoa.Farming.Editor.TerrainPlotPlacement");
            MethodInfo placeMethod = placementType?.GetMethod(
                "TryPlaceOnTerrain",
                BindingFlags.Static | BindingFlags.Public);

            Assert.IsNotNull(placeMethod);
            bool placed = (bool)placeMethod.Invoke(null, new object[]
            {
                plot,
                leftTerrain,
                new Vector3(10f, 0f, 5f),
                0.05f,
                5
            });

            Assert.IsTrue(placed, "A plot spanning two adjacent Terrain tiles must not be dropped at their seam.");

            Object.DestroyImmediate(plot);
            Object.DestroyImmediate(leftObject);
            Object.DestroyImmediate(rightObject);
            Object.DestroyImmediate(leftData);
            Object.DestroyImmediate(rightData);
        }

        [Test]
        public void MainScene_HasBoundedPlayableFarmingSetup()
        {
            EditorSceneManager.OpenScene(MainScenePath, OpenSceneMode.Single);

            CropPlot[] plots = Object.FindObjectsByType<CropPlot>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            SluiceGate[] gates = Object.FindObjectsByType<SluiceGate>(FindObjectsInactive.Include, FindObjectsSortMode.None);

            Assert.Greater(plots.Length, 0, "The integration must support the grid size selected by the designer.");
            Assert.AreEqual(1, gates.Length);
            Assert.AreEqual(plots.Length, gates[0].connectedPlots.Count);
            Assert.AreEqual(1, Object.FindObjectsByType<RiceDryingYard>(FindObjectsInactive.Include, FindObjectsSortMode.None).Length);
            Assert.AreEqual(1, Object.FindObjectsByType<RiceThresher>(FindObjectsInactive.Include, FindObjectsSortMode.None).Length);
            Assert.AreEqual(1, Object.FindObjectsByType<FarmingWeatherSystem>(FindObjectsInactive.Include, FindObjectsSortMode.None).Length);
            Assert.AreEqual(1, Object.FindObjectsByType<RiceShelterZone>(FindObjectsInactive.Include, FindObjectsSortMode.None).Length);
            Assert.AreEqual(1, Object.FindObjectsByType<BuffaloPlowAttachment>(FindObjectsInactive.Include, FindObjectsSortMode.None).Length);
            Assert.AreEqual(1, Object.FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include, FindObjectsSortMode.None)
                .Count(component => component != null && component.GetType().Name == "RiceBasketController"));
        }

        private static CropPlot CreateMappedPlot(Transform parent, Vector3 position, Quaternion rotation)
        {
            GameObject plotObject = new GameObject("MappedPlot");
            plotObject.transform.SetParent(parent);
            plotObject.transform.SetPositionAndRotation(position, rotation);
            return plotObject.AddComponent<CropPlot>();
        }

        private static System.Type FindEditorType(string fullName)
        {
            return System.AppDomain.CurrentDomain.GetAssemblies()
                .Select(assembly => assembly.GetType(fullName, false))
                .FirstOrDefault(type => type != null);
        }

        private static float SampleTerrainHeight(Terrain terrain, Vector3 worldPoint)
        {
            TerrainData data = terrain.terrainData;
            Vector3 local = worldPoint - terrain.transform.position;
            float normalizedX = Mathf.Clamp01(local.x / data.size.x);
            float normalizedZ = Mathf.Clamp01(local.z / data.size.z);
            return terrain.transform.position.y + data.GetInterpolatedHeight(normalizedX, normalizedZ);
        }

        private static TerrainData CreateFlatTerrainData()
        {
            return new TerrainData
            {
                heightmapResolution = 33,
                size = new Vector3(10f, 2f, 10f)
            };
        }
    }
}
