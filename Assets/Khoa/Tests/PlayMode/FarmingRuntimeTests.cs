using System.Collections;
using Khoa.Farming;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

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
    }
}
