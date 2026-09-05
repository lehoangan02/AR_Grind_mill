using System.Collections;
using Khoa.Farming;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Reflection;

namespace Khoa.Farming.PlayModeTests
{
    public class FarmingRuntimeTests
    {
        [UnityTest]
        public IEnumerator SluiceGate_Start_AutoConnectsAndIrrigatesNearbyPlot()
        {
            GameObject plotObject = new GameObject("NearbyPlot");
            CropPlot plot = plotObject.AddComponent<CropPlot>();
            plotObject.transform.position = Vector3.right;

            GameObject gateObject = new GameObject("AutoGate");
            SluiceGate gate = gateObject.AddComponent<SluiceGate>();
            gate.waterFlowRate = 100f;

            yield return null;
            gate.OpenGate();
            float moistureBefore = plot.currentMoisture;
            yield return new WaitForSeconds(gate.irrigationTickInterval + 0.02f);

            Assert.Contains(plot, gate.connectedPlots);
            Assert.Greater(plot.currentMoisture, moistureBefore);

            Object.Destroy(gateObject);
            Object.Destroy(plotObject);
        }

        [UnityTest]
        public IEnumerator DryingYard_TriggerAndUpdate_DriesPhysicalBundle()
        {
            GameObject weatherObject = new GameObject("SunnyWeather");
            FarmingWeatherSystem weather = weatherObject.AddComponent<FarmingWeatherSystem>();
            weather.SetWeather(WeatherType.Overcast);
            weather.SetWeather(WeatherType.Sunny);

            GameObject yardObject = new GameObject("RuntimeYard");
            RiceDryingYard yard = yardObject.AddComponent<RiceDryingYard>();
            yard.dryingSpeedPerSecond = 100f;

            GameObject bundleObject = new GameObject("RuntimeBundle");
            bundleObject.AddComponent<CapsuleCollider>();
            Rigidbody body = bundleObject.AddComponent<Rigidbody>();
            body.useGravity = false;
            RiceBundleItem bundle = bundleObject.AddComponent<RiceBundleItem>();
            bundleObject.transform.position = yardObject.transform.position;

            Physics.SyncTransforms();
            yield return new WaitForFixedUpdate();
            yield return null;

            Assert.Contains(bundle, yard.bundlesOnYard);
            Assert.Greater(bundle.drynessProgress, 0f);

            Object.Destroy(bundleObject);
            Object.Destroy(yardObject);
            Object.Destroy(weatherObject);
        }

        [UnityTest]
        public IEnumerator BuffaloPlow_PhysicsTrigger_PlowsPlot()
        {
            GameObject plotObject = new GameObject("PhysicsPlot");
            CropPlot plot = plotObject.AddComponent<CropPlot>();
            plotObject.transform.position = Vector3.zero;

            GameObject plowObject = new GameObject("PhysicsPlow");
            plowObject.transform.position = Vector3.right * 5f;
            plowObject.AddComponent<BuffaloPlowAttachment>();
            yield return null;

            plowObject.transform.position = Vector3.zero;
            Physics.SyncTransforms();
            yield return new WaitForFixedUpdate();

            Assert.AreEqual(PlotState.Tilled, plot.currentState,
                "The real physics trigger path must plow the plot.");
            Object.Destroy(plowObject);
            Object.Destroy(plotObject);
        }

        [UnityTest]
        public IEnumerator SluiceGate_BatchesIrrigationInsteadOfUpdatingEveryFrame()
        {
            GameObject plotObject = new GameObject("BatchedPlot");
            CropPlot plot = plotObject.AddComponent<CropPlot>();
            GameObject gateObject = new GameObject("BatchedGate");
            SluiceGate gate = gateObject.AddComponent<SluiceGate>();
            gate.autoFindNearbyPlotsOnStart = false;
            gate.connectedPlots.Add(plot);
            gate.waterFlowRate = 100f;
            System.Reflection.FieldInfo intervalField = typeof(SluiceGate).GetField("irrigationTickInterval");

            Assert.IsNotNull(intervalField, "Large fields need a batched irrigation interval.");
            intervalField.SetValue(gate, 0.5f);
            yield return null;
            gate.OpenGate();
            yield return null;

            Assert.AreEqual(0f, plot.currentMoisture, 0.0001f,
                "Opening the gate must not rewrite every plot on every rendered frame.");
            yield return new WaitForSeconds(0.55f);
            Assert.Greater(plot.currentMoisture, 0f);

            Object.Destroy(gateObject);
            Object.Destroy(plotObject);
        }

        [UnityTest]
        public IEnumerator SluiceGate_PartialOpeningScalesRealIrrigationFlow()
        {
            GameObject partialPlotObject = new GameObject("PartialFlowPlot");
            CropPlot partialPlot = partialPlotObject.AddComponent<CropPlot>();
            GameObject fullPlotObject = new GameObject("FullFlowPlot");
            CropPlot fullPlot = fullPlotObject.AddComponent<CropPlot>();
            GameObject partialGateObject = new GameObject("PartialFlowGate");
            SluiceGate partialGate = partialGateObject.AddComponent<SluiceGate>();
            GameObject fullGateObject = new GameObject("FullFlowGate");
            SluiceGate fullGate = fullGateObject.AddComponent<SluiceGate>();
            MethodInfo setOpenAmount = typeof(SluiceGate).GetMethod("SetOpenAmount");

            partialGate.autoFindNearbyPlotsOnStart = false;
            fullGate.autoFindNearbyPlotsOnStart = false;
            partialGate.connectedPlots.Add(partialPlot);
            fullGate.connectedPlots.Add(fullPlot);
            partialGate.waterFlowRate = fullGate.waterFlowRate = 100f;
            partialGate.irrigationTickInterval = fullGate.irrigationTickInterval = 0.05f;

            Assert.IsNotNull(setOpenAmount);
            yield return null;
            setOpenAmount.Invoke(partialGate, new object[] { 0.25f });
            setOpenAmount.Invoke(fullGate, new object[] { 1f });
            yield return new WaitForSeconds(0.12f);

            Assert.Greater(fullPlot.currentMoisture, 0f);
            Assert.AreEqual(0.25f, partialPlot.currentMoisture / fullPlot.currentMoisture, 0.04f,
                "A quarter-open gate should deliver one quarter of the real irrigation flow.");

            Object.Destroy(partialGateObject);
            Object.Destroy(fullGateObject);
            Object.Destroy(partialPlotObject);
            Object.Destroy(fullPlotObject);
        }

        // ---------- FISHING: mô phỏng gameplay thực (physics trigger, coroutine) ----------

        /// Helper: tạo cần câu sẵn sàng với Phao + Dây trong runtime
        private VRFishingController CreateFishingRodRuntime()
        {
            GameObject rodGO = new GameObject("RuntimeFishingRod");
            Rigidbody rodBody = rodGO.AddComponent<Rigidbody>();
            rodBody.isKinematic = true;
            rodBody.useGravity = false;

            VRFishingController rod = rodGO.AddComponent<VRFishingController>();

            GameObject lineGO = new GameObject("HookWithLine");
            lineGO.transform.SetParent(rodGO.transform, false);
            Transform line = lineGO.transform;

            GameObject meshGO = new GameObject("HookMesh");
            meshGO.transform.SetParent(line, false);
            Transform mesh = meshGO.transform;

            rod.hookWithLine = line;
            rod.hookMesh = mesh;
            rod.idleScaleY = 0.1f;
            rod.waterScaleY = 2.0f;
            rod.pullThreshold = 1.0f;

            GameObject dummyFish = new GameObject("DummyFish");
            dummyFish.transform.SetParent(rodGO.transform);
            rod.fishPrefab = dummyFish;

            return rod;
        }

        /// Helper: tạo vùng nước/câu thật sự có physics (trigger + kinematic Rigidbody)
        private FishingZone CreateWaterFishingZoneRuntime(Vector3 position, float size)
        {
            GameObject zoneGO = new GameObject("RuntimeFishingZone");
            zoneGO.transform.position = position;
            Rigidbody zoneBody = zoneGO.AddComponent<Rigidbody>();
            zoneBody.isKinematic = true;
            zoneBody.useGravity = false;

            BoxCollider box = zoneGO.AddComponent<BoxCollider>();
            box.isTrigger = true;
            box.size = new Vector3(size, size, size);

            FishingZone zone = zoneGO.AddComponent<FishingZone>();
            zone.minBiteDelay = 2.0f;
            zone.maxBiteDelay = 2.0f;   // cố định để dự đoán thời điểm cắn câu
            return zone;
        }

        [UnityTest]
        public IEnumerator Fishing_BobberPhysicsTrigger_StartsCasting()
        {
            VRFishingController rod = CreateFishingRodRuntime();
            rod.transform.position = Vector3.zero;
            FishingZone zone = CreateWaterFishingZoneRuntime(new Vector3(0f, -1.5f, 0f), 4f);

            rod.EquipRod();

            // Đưa PHAO (HookMesh) vào trong vùng nước để kích hoạt trigger thật
            rod.hookMesh.position = new Vector3(0f, -1f, 0f);
            Physics.SyncTransforms();
            yield return new WaitForFixedUpdate();
            yield return null;

            Assert.AreEqual(VRFishingController.FishingState.DroppingLine, rod.currentState,
                "Phao chạm mặt nước qua physics trigger thật phải bắt đầu thả dây (DroppingLine).");

            Assert.AreEqual(zone, rod.currentZone, "Cần câu phải nhớ vùng nước đang thả.");

            Object.Destroy(rod.gameObject);
            Object.Destroy(zone.gameObject);
        }

        [UnityTest]
        public IEnumerator Fishing_BoardCasts_ThenRodClickAfterBiteShowsFish()
        {
            VRFishingController rod = CreateFishingRodRuntime();
            rod.simpleDropDuration = 0.01f;
            rod.simpleBiteDelay = 0.01f;
            GameObject boardGO = new GameObject("RuntimeFishingBoard");
            boardGO.AddComponent<BoxCollider>();
            FishingStationBoard board = boardGO.AddComponent<FishingStationBoard>();
            board.fishingRod = rod;

            board.ToggleFishingRod();
            yield return null;

            Assert.IsTrue(rod.isEquipped, "Click bảng phải kích hoạt cần tại điểm cố định.");
            Assert.AreEqual(VRFishingController.FishingState.DroppingLine, rod.currentState);

            yield return new WaitForSeconds(0.1f);
            Assert.AreEqual(VRFishingController.FishingState.FishBiting, rod.currentState,
                "Phải hiện trạng thái cá cắn trước khi cho phép kéo cá.");

            rod.HandlePrimaryClick(); // mô phỏng bấm trực tiếp vào cần câu
            yield return null;

            Assert.AreEqual(VRFishingController.FishingState.FishCaught, rod.currentState,
                "Bấm cần sau khi cá cắn phải kéo cá lên, không cần vung tay.");
            Assert.IsNotNull(rod.currentFishInstance, "Cá phải xuất hiện trên cần.");

            Object.Destroy(boardGO);
            Object.Destroy(rod.gameObject);
        }
    }
}
