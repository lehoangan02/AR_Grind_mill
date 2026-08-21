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
            yield return null;

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
    }
}
