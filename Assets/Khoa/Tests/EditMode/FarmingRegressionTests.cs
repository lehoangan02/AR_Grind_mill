using System.Reflection;
using System.Linq;
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
        public void MainScene_HasBoundedPlayableFarmingSetup()
        {
            EditorSceneManager.OpenScene(MainScenePath, OpenSceneMode.Single);

            CropPlot[] plots = Object.FindObjectsByType<CropPlot>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            SluiceGate[] gates = Object.FindObjectsByType<SluiceGate>(FindObjectsInactive.Include, FindObjectsSortMode.None);

            Assert.AreEqual(10000, plots.Length, "The designed farming field must remain a 100 x 100 grid.");
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
    }
}
