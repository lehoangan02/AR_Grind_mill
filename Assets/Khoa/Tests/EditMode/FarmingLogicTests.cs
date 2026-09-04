using NUnit.Framework;
using UnityEngine;
using Khoa.Farming;

namespace Khoa.Farming.Tests
{
    public class FarmingLogicTests
    {
        private GameObject testGO;
        private CropData testCropData;

        [SetUp]
        public void Setup()
        {
            testGO = new GameObject("TestPlot");
            testCropData = ScriptableObject.CreateInstance<CropData>();
            testCropData.plantName = "Rice Test";
            testCropData.timeToHarvest = 10f;
            testCropData.maxWater = 100f;
            testCropData.minWaterToGrow = 20f;
            testCropData.waterDepletionRate = 2f;
            testCropData.timeToDieWithoutWater = 5f;
            testCropData.fertilizerGrowthMultiplier = 2f;
        }

        [TearDown]
        public void Teardown()
        {
            if (testGO != null)
            {
                Object.DestroyImmediate(testGO);
            }
            if (testCropData != null)
            {
                Object.DestroyImmediate(testCropData);
            }
        }

        [Test]
        public void Test_CropPlot_InitialState_IsEmpty()
        {
            CropPlot plot = testGO.AddComponent<CropPlot>();
            Assert.AreEqual(PlotState.Empty, plot.currentState, "Trạng thái ban đầu của ô đất phải là Empty");
        }

        [Test]
        public void Test_CropPlot_Plow_TransitionsToTilled()
        {
            CropPlot plot = testGO.AddComponent<CropPlot>();
            plot.PlowPlot();
            Assert.AreEqual(PlotState.Tilled, plot.currentState, "Sau khi cày đất (Plow), trạng thái phải là Tilled");
        }

        [Test]
        public void Test_RiceBundleItem_AddDryness_CalculatesCorrectly()
        {
            GameObject bundleGO = new GameObject("TestBundle");
            bundleGO.AddComponent<CapsuleCollider>();
            RiceBundleItem bundle = bundleGO.AddComponent<RiceBundleItem>();
            bundle.cropData = testCropData;
            bundle.grainAmount = 15;

            Assert.IsFalse(bundle.isDry, "Bó lúa mới gặt chưa được khô");
            Assert.AreEqual(0f, bundle.drynessProgress);

            bundle.AddDryness(40f);
            Assert.AreEqual(40f, bundle.drynessProgress);
            Assert.IsFalse(bundle.isDry);

            bundle.AddDryness(70f);
            Assert.AreEqual(100f, bundle.drynessProgress, "Độ khô tối đa là 100%");
            Assert.IsTrue(bundle.isDry, "Độ khô đạt 100% thì isDry phải là True");

            Object.DestroyImmediate(bundleGO);
        }

        [Test]
        public void Test_RicePlant_Water_ClampsAtMaxWater()
        {
            GameObject riceGO = new GameObject("TestRice");
            RicePlant plant = riceGO.AddComponent<RicePlant>();
            plant.cropData = testCropData;
            plant.currentWater = 50f;

            plant.WaterPlant(30f);
            Assert.AreEqual(80f, plant.currentWater);

            plant.WaterPlant(50f);
            Assert.AreEqual(testCropData.maxWater, plant.currentWater, "Nước không được vượt quá maxWater");

            Object.DestroyImmediate(riceGO);
        }

        [Test]
        public void Test_RicePlant_Fertilize_SetsFlag()
        {
            GameObject riceGO = new GameObject("TestRice");
            RicePlant plant = riceGO.AddComponent<RicePlant>();
            plant.cropData = testCropData;

            Assert.IsFalse(plant.hasFertilizer);
            plant.Fertilize();
            Assert.IsTrue(plant.hasFertilizer, "Bón phân xong hasFertilizer phải là True");

            Object.DestroyImmediate(riceGO);
        }
    }
}
