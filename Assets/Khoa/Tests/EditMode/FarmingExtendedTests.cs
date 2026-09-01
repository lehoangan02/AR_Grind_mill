using NUnit.Framework;
using UnityEngine;
using Khoa.Farming;
using System.Collections.Generic;

namespace Khoa.Farming.Tests
{
    public class FarmingExtendedTests
    {
        private GameObject testRoot;
        private CropData testCropData;

        [SetUp]
        public void Setup()
        {
            testRoot = new GameObject("TestRoot");
            testCropData = ScriptableObject.CreateInstance<CropData>();
            testCropData.plantName = "Lúa Thử Nghiệm";
            testCropData.timeToHarvest = 10f;
            testCropData.maxWater = 100f;
            testCropData.minWaterToGrow = 20f;
            testCropData.waterDepletionRate = 2f;
        }

        [TearDown]
        public void Teardown()
        {
            if (testRoot != null)
            {
                Object.DestroyImmediate(testRoot);
            }
            if (testCropData != null)
            {
                Object.DestroyImmediate(testCropData);
            }
        }

        [Test]
        public void Test_CropPlot_WaterPlot_IncreasesMoisture()
        {
            GameObject plotGO = new GameObject("TestPlot");
            plotGO.transform.SetParent(testRoot.transform);
            CropPlot plot = plotGO.AddComponent<CropPlot>();

            Assert.AreEqual(0f, plot.currentMoisture, "Độ ẩm ban đầu của đất phải là 0");

            plot.WaterPlot(40f);
            Assert.AreEqual(0.4f, plot.currentMoisture, 0.01f, "Sau khi tưới 40 water, độ ẩm đất phải là 0.4");

            plot.WaterPlot(80f);
            Assert.AreEqual(1.0f, plot.currentMoisture, 0.01f, "Độ ẩm tối đa được giới hạn ở 1.0 (100%)");
        }

        [Test]
        public void Test_SluiceGate_OpenClose_And_IrrigatesPlots()
        {
            GameObject gateGO = new GameObject("SluiceGate");
            gateGO.transform.SetParent(testRoot.transform);
            SluiceGate gate = gateGO.AddComponent<SluiceGate>();

            GameObject plot1GO = new GameObject("Plot1");
            plot1GO.transform.SetParent(testRoot.transform);
            CropPlot plot1 = plot1GO.AddComponent<CropPlot>();

            GameObject plot2GO = new GameObject("Plot2");
            plot2GO.transform.SetParent(testRoot.transform);
            CropPlot plot2 = plot2GO.AddComponent<CropPlot>();

            gate.AddConnectedPlot(plot1);
            gate.AddConnectedPlot(plot2);

            Assert.IsFalse(gate.isOpen, "Van nước ban đầu phải đóng");
            gate.OpenGate();
            Assert.IsTrue(gate.isOpen, "Sau khi OpenGate van phải mở");

            // Cấp nước qua van
            plot1.WaterPlot(50f);
            plot2.WaterPlot(50f);
            Assert.AreEqual(0.5f, plot1.currentMoisture, 0.01f);
            Assert.AreEqual(0.5f, plot2.currentMoisture, 0.01f);

            gate.CloseGate();
            Assert.IsFalse(gate.isOpen);
        }

        [Test]
        public void Test_BuffaloPlowAttachment_PlowsEmptyPlot()
        {
            GameObject buffaloGO = new GameObject("Buffalo");
            buffaloGO.transform.SetParent(testRoot.transform);
            BuffaloPlowAttachment plow = buffaloGO.AddComponent<BuffaloPlowAttachment>();

            GameObject plotGO = new GameObject("Plot");
            plotGO.transform.SetParent(testRoot.transform);
            CropPlot plot = plotGO.AddComponent<CropPlot>();

            Assert.AreEqual(PlotState.Empty, plot.currentState);

            bool plowedEventFired = false;
            plow.OnPlotPlowedByBuffalo += (p) => { plowedEventFired = true; };

            plow.PlowTargetPlot(plot);

            Assert.AreEqual(PlotState.Tilled, plot.currentState, "Sau khi trâu bừa, ô đất phải chuyển sang Tilled");
            Assert.IsTrue(plowedEventFired, "Sự kiện OnPlotPlowedByBuffalo phải được kích hoạt");
        }

        [Test]
        public void Test_RiceDryingYard_DriesBundleToCompletion()
        {
            GameObject yardGO = new GameObject("DryingYard");
            yardGO.transform.SetParent(testRoot.transform);
            RiceDryingYard yard = yardGO.AddComponent<RiceDryingYard>();
            yard.dryingSpeedPerSecond = 50f;

            GameObject bundleGO = new GameObject("Bundle");
            bundleGO.transform.SetParent(testRoot.transform);
            bundleGO.AddComponent<CapsuleCollider>();
            RiceBundleItem bundle = bundleGO.AddComponent<RiceBundleItem>();
            bundle.cropData = testCropData;
            bundle.grainAmount = 20;

            yard.bundlesOnYard.Add(bundle);
            Assert.IsFalse(bundle.isDry);

            // Mô phỏng phơi 1 giây (50% khô)
            bundle.AddDryness(50f);
            Assert.AreEqual(50f, bundle.drynessProgress, 0.01f);
            Assert.IsFalse(bundle.isDry);

            // Phơi thêm 60% (vượt 100% -> khô hoàn tất)
            bundle.AddDryness(60f);
            Assert.AreEqual(100f, bundle.drynessProgress, 0.01f);
            Assert.IsTrue(bundle.isDry, "Bó lúa phải khô hoàn toàn");
        }

        [Test]
        public void Test_RiceThresher_RejectsWet_AndPreservesDryBundleWithoutReceiver()
        {
            GameObject thresherGO = new GameObject("Thresher");
            thresherGO.transform.SetParent(testRoot.transform);
            RiceThresher thresher = thresherGO.AddComponent<RiceThresher>();
            thresher.grainYieldMultiplier = 2f; // Mỗi bó 10 hạt nhân đôi thành 20 hạt

            // 1. Thử với bó lúa còn ướt
            GameObject wetBundleGO = new GameObject("WetBundle");
            wetBundleGO.transform.SetParent(testRoot.transform);
            wetBundleGO.AddComponent<CapsuleCollider>();
            RiceBundleItem wetBundle = wetBundleGO.AddComponent<RiceBundleItem>();
            wetBundle.cropData = testCropData;
            wetBundle.grainAmount = 10;

            bool wetResult = thresher.ThreshRiceBundle(wetBundle);
            Assert.IsFalse(wetResult, "Cối tuốt phải từ chối bó lúa chưa khô");

            // 2. Thử với bó lúa đã khô
            wetBundle.AddDryness(100f);
            Assert.IsTrue(wetBundle.isDry);

            int grainsReceived = 0;
            thresher.OnRiceThreshed += (grains) => { grainsReceived = grains; };

            bool dryResult = thresher.ThreshRiceBundle(wetBundle);
            Assert.IsFalse(dryResult, "Cối tuốt không được tiêu thụ bó lúa khi không có giỏ nhận thóc");
            Assert.AreEqual(0, grainsReceived, "Không được phát sự kiện thành công khi đầu ra chưa nhận thóc");
            Assert.IsNotNull(wetBundle, "Bó lúa khô phải được giữ lại để người chơi đặt giỏ rồi thử lại");
        }

        [Test]
        public void Test_FarmingWeatherSystem_StateTransition()
        {
            GameObject weatherGO = new GameObject("WeatherSystem");
            weatherGO.transform.SetParent(testRoot.transform);
            FarmingWeatherSystem weather = weatherGO.AddComponent<FarmingWeatherSystem>();

            Assert.IsTrue(weather.IsSunny, "Thời tiết mặc định phải là Nắng");
            Assert.IsFalse(weather.IsRaining);

            WeatherType notifiedWeather = WeatherType.Sunny;
            weather.OnWeatherChanged += (w) => { notifiedWeather = w; };

            weather.SetWeather(WeatherType.Rainy);
            Assert.AreEqual(WeatherType.Rainy, weather.CurrentWeather);
            Assert.IsTrue(weather.IsRaining);
            Assert.IsFalse(weather.IsSunny);
            Assert.AreEqual(WeatherType.Rainy, notifiedWeather, "Event OnWeatherChanged phải được kích hoạt");

            weather.ToggleNextWeather();
            Assert.AreEqual(WeatherType.Sunny, weather.CurrentWeather, "Sau Rainy phải quay về Sunny");
        }

        [Test]
        public void Test_RiceDryingYard_RainDecay_WhenNotSheltered()
        {
            GameObject bundleGO = new GameObject("BundleForRain");
            bundleGO.transform.SetParent(testRoot.transform);
            bundleGO.AddComponent<CapsuleCollider>();
            RiceBundleItem bundle = bundleGO.AddComponent<RiceBundleItem>();
            bundle.cropData = testCropData;
            bundle.AddDryness(80f);

            Assert.AreEqual(80f, bundle.drynessProgress, 0.01f);
            Assert.IsFalse(bundle.isSheltered);

            // Giả lập mưa làm ướt lúa (giảm 25%)
            bundle.AddDryness(-25f);
            Assert.AreEqual(55f, bundle.drynessProgress, 0.01f, "Độ khô phải bị giảm xuống 55%");
            Assert.IsFalse(bundle.isDry);

            // Giả lập lúa đã khô 100% gặp mưa
            bundle.AddDryness(50f);
            Assert.IsTrue(bundle.isDry, "Lúa đạt 100% thì isDry = true");

            bundle.AddDryness(-10f);
            Assert.IsFalse(bundle.isDry, "Khi dính mưa bị tụt dưới 100%, isDry phải trở về false");
        }

        [Test]
        public void Test_RiceShelterZone_ProtectsBundleFromRain()
        {
            GameObject shelterGO = new GameObject("ShelterZone");
            shelterGO.transform.SetParent(testRoot.transform);
            RiceShelterZone shelter = shelterGO.AddComponent<RiceShelterZone>();

            GameObject bundleGO = new GameObject("ShelteredBundle");
            bundleGO.transform.SetParent(testRoot.transform);
            bundleGO.AddComponent<CapsuleCollider>();
            RiceBundleItem bundle = bundleGO.AddComponent<RiceBundleItem>();

            Assert.IsFalse(bundle.isSheltered, "Ban đầu bó lúa chưa được che chắn");

            bundle.isSheltered = true;
            shelter.shelteredBundles.Add(bundle);

            Assert.IsTrue(bundle.isSheltered, "Bó lúa trong nhà kho phải có isSheltered = true");
        }

        [Test]
        public void Test_RiceThresherBasketReceiver_ComponentSetup()
        {
            GameObject thresherGO = new GameObject("ThresherWithReceiver");
            thresherGO.transform.SetParent(testRoot.transform);
            RiceThresher thresher = thresherGO.AddComponent<RiceThresher>();
            RiceThresherBasketReceiver receiver = thresherGO.AddComponent<RiceThresherBasketReceiver>();

            Assert.IsNotNull(receiver);
            Assert.IsTrue(receiver.autoFillInventoryBasket);
            Assert.AreEqual(2.5f, receiver.basketSearchRadius, 0.01f);
        }

        [Test]
        public void RiceThresherReceiver_WithPhysicalOutput_SpawnsTypedPaddyBatch()
        {
            GameObject thresherGO = new GameObject("ThresherWithPhysicalOutput");
            thresherGO.transform.SetParent(testRoot.transform);
            RiceThresherBasketReceiver receiver = thresherGO.AddComponent<RiceThresherBasketReceiver>();
            receiver.autoFillInventoryBasket = false;
            GameObject template = new GameObject("PaddyTemplate");
            template.transform.SetParent(testRoot.transform);
            template.AddComponent<PaddyBatchItem>();
            receiver.paddyBatchPrefab = template;
            PaddyBatchItem spawned = null;
            receiver.OnPaddyBatchCreated += item => spawned = item;

            bool accepted = receiver.TryReceiveGrain(10);

            Assert.IsTrue(accepted);
            Assert.IsNotNull(spawned);
            Assert.IsTrue(spawned.HasPaddy);
            Object.DestroyImmediate(spawned.gameObject);
        }

        [Test]
        public void Test_GleanedRiceStalk_Collection_CountsAndSpawnsBundle()
        {
            GleanedRiceStalk.currentGleanedCount = 0;

            // Tạo template bundle
            GameObject bundleTemplate = new GameObject("BundleTemplate");
            bundleTemplate.transform.SetParent(testRoot.transform);
            bundleTemplate.AddComponent<CapsuleCollider>();
            RiceBundleItem bundleItem = bundleTemplate.AddComponent<RiceBundleItem>();
            bundleItem.cropData = testCropData;

            // Tạo 3 bông lúa mót
            GameObject s1GO = new GameObject("Stalk1");
            s1GO.transform.SetParent(testRoot.transform);
            s1GO.AddComponent<CapsuleCollider>();
            GleanedRiceStalk s1 = s1GO.AddComponent<GleanedRiceStalk>();
            s1.stalksRequiredForBundle = 3;
            s1.bundlePrefabToSpawn = bundleTemplate;

            GameObject s2GO = new GameObject("Stalk2");
            s2GO.transform.SetParent(testRoot.transform);
            s2GO.AddComponent<CapsuleCollider>();
            GleanedRiceStalk s2 = s2GO.AddComponent<GleanedRiceStalk>();
            s2.stalksRequiredForBundle = 3;
            s2.bundlePrefabToSpawn = bundleTemplate;

            GameObject s3GO = new GameObject("Stalk3");
            s3GO.transform.SetParent(testRoot.transform);
            s3GO.AddComponent<CapsuleCollider>();
            GleanedRiceStalk s3 = s3GO.AddComponent<GleanedRiceStalk>();
            s3.stalksRequiredForBundle = 3;
            s3.bundlePrefabToSpawn = bundleTemplate;

            bool craftedEventFired = false;
            GleanedRiceStalk.OnBundleCraftedFromGleaning += (b) => { craftedEventFired = true; };

            s1.CollectStalk();
            Assert.AreEqual(1, GleanedRiceStalk.currentGleanedCount);

            s2.CollectStalk();
            Assert.AreEqual(2, GleanedRiceStalk.currentGleanedCount);

            s3.CollectStalk();
            Assert.AreEqual(0, GleanedRiceStalk.currentGleanedCount, "Khi gom đủ 3 bông, bộ đếm phải reset về 0");
            Assert.IsTrue(craftedEventFired, "Sự kiện tạo bó lúa từ mót lúa phải được kích hoạt");
        }

        [Test]
        public void Test_CropPlot_Harvest_SpawnsGleanStalks()
        {
            GameObject plotGO = new GameObject("GleanTestPlot");
            plotGO.transform.SetParent(testRoot.transform);
            CropPlot plot = plotGO.AddComponent<CropPlot>();

            GameObject riceTemplate = new GameObject("RiceTemplate");
            riceTemplate.transform.SetParent(testRoot.transform);
            RicePlant riceComp = riceTemplate.AddComponent<RicePlant>();
            riceComp.cropData = testCropData;
            plot.ricePrefab = riceTemplate;

            GameObject stalkTemplate = new GameObject("StalkTemplate");
            stalkTemplate.transform.SetParent(testRoot.transform);
            stalkTemplate.AddComponent<CapsuleCollider>();
            stalkTemplate.AddComponent<GleanedRiceStalk>();

            plot.gleanStalkPrefab = stalkTemplate;
            plot.gleanSpawnChance = 1.0f; // 100% tỉ lệ rơi vãi
            plot.minGleanStalks = 2;
            plot.maxGleanStalks = 2;

            plot.PlowPlot();
            plot.PlantCrop();

            foreach (var p in testRoot.GetComponentsInChildren<RicePlant>())
            {
                p.currentState = CropState.ReadyToHarvest;
            }

            int stalkCountBefore = Object.FindObjectsByType<GleanedRiceStalk>(FindObjectsSortMode.None).Length;

            plot.HarvestCrop();

            int stalkCountAfter = Object.FindObjectsByType<GleanedRiceStalk>(FindObjectsSortMode.None).Length;
            Assert.IsTrue(stalkCountAfter > stalkCountBefore, "Sau khi gặt lúa phải sinh ra các bông lúa mót rơi vãi trên ruộng");
        }

        [Test]
        public void Test_FarmingParticleFactory_CreatesValidParticleSystems()
        {
            ParticleSystem waterFX = FarmingParticleFactory.CreateWaterFlowFX(testRoot.transform);
            Assert.IsNotNull(waterFX);
            Assert.AreEqual("WaterFlow_ParticleFX", waterFX.gameObject.name);

            ParticleSystem steamFX = FarmingParticleFactory.CreateSteamFX(testRoot.transform);
            Assert.IsNotNull(steamFX);

            ParticleSystem grainFX = FarmingParticleFactory.CreateGrainBurstFX(testRoot.transform);
            Assert.IsNotNull(grainFX);

            ParticleSystem mudFX = FarmingParticleFactory.CreateMudDustFX(testRoot.transform);
            Assert.IsNotNull(mudFX);

            ParticleSystem sparkleFX = FarmingParticleFactory.CreateSparkleFX(testRoot.transform);
            Assert.IsNotNull(sparkleFX);
        }
    }
}
