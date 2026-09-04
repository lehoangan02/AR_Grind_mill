using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace Khoa.Farming.Tests
{
    public class FarmingLeverAndGridTests
    {
        private const BindingFlags InstanceFlags =
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        [Test]
        public void SluiceGate_SetOpenAmount_UpdatesFlowStateAndLeverRotation()
        {
            GameObject gateObject = new GameObject("ContinuousGate");
            GameObject pivotObject = new GameObject("LeverPivot");
            pivotObject.transform.SetParent(gateObject.transform);
            SluiceGate gate = gateObject.AddComponent<SluiceGate>();
            gate.leverTransform = pivotObject.transform;
            gate.leverClosedRotation = new Vector3(90f, 0f, 0f);
            gate.leverOpenRotation = new Vector3(45f, 0f, 0f);
            gate.waterFlowRate = 20f;
            MethodInfo setOpenAmount = typeof(SluiceGate).GetMethod("SetOpenAmount", InstanceFlags);
            PropertyInfo openAmount = typeof(SluiceGate).GetProperty("OpenAmount", InstanceFlags);
            PropertyInfo currentFlow = typeof(SluiceGate).GetProperty("CurrentWaterFlowRate", InstanceFlags);

            try
            {
                Assert.IsNotNull(setOpenAmount, "SluiceGate needs a continuous open-amount API.");
                Assert.IsNotNull(openAmount);
                Assert.IsNotNull(currentFlow);
                setOpenAmount.Invoke(gate, new object[] { 0.5f });

                Assert.AreEqual(0.5f, (float)openAmount.GetValue(gate), 0.0001f);
                Assert.AreEqual(10f, (float)currentFlow.GetValue(gate), 0.0001f);
                Assert.IsTrue(gate.isOpen);
                Assert.AreEqual(67.5f, pivotObject.transform.localEulerAngles.x, 0.05f);
            }
            finally
            {
                UnityEngine.Object.DestroyImmediate(gateObject);
            }
        }

        [Test]
        public void SluiceGateLever_MapsGrabPositionOntoConstrainedLeverArc()
        {
            Type leverType = Type.GetType("Khoa.Farming.SluiceGateLever, Khoa.Farming");
            Assert.IsNotNull(leverType, "A dedicated physical lever component is required.");

            GameObject gateObject = new GameObject("PhysicalGate");
            GameObject pivotObject = new GameObject("LeverPivot");
            pivotObject.transform.SetParent(gateObject.transform);
            pivotObject.transform.localPosition = new Vector3(0f, 0.5f, -0.2f);
            SluiceGate gate = gateObject.AddComponent<SluiceGate>();
            gate.leverTransform = pivotObject.transform;
            gate.leverClosedRotation = new Vector3(90f, 0f, 0f);
            gate.leverOpenRotation = new Vector3(45f, 0f, 0f);
            Component lever = pivotObject.AddComponent(leverType);
            leverType.GetField("sluiceGate", InstanceFlags)?.SetValue(lever, gate);
            MethodInfo applyPosition = leverType.GetMethod("ApplyInteractorWorldPosition", InstanceFlags);
            PropertyInfo openAmount = typeof(SluiceGate).GetProperty("OpenAmount", InstanceFlags);

            try
            {
                Assert.IsNotNull(applyPosition);
                Vector3 openDirection = new Vector3(
                    0f,
                    Mathf.Cos(45f * Mathf.Deg2Rad),
                    Mathf.Sin(45f * Mathf.Deg2Rad));
                Vector3 openHandPosition = gateObject.transform.TransformPoint(
                    pivotObject.transform.localPosition + openDirection);
                applyPosition.Invoke(lever, new object[] { openHandPosition });
                Assert.AreEqual(1f, (float)openAmount.GetValue(gate), 0.001f);

                Vector3 closedDirection = new Vector3(0f, 0f, 1f);
                Vector3 closedHandPosition = gateObject.transform.TransformPoint(
                    pivotObject.transform.localPosition + closedDirection);
                applyPosition.Invoke(lever, new object[] { closedHandPosition });
                Assert.AreEqual(0f, (float)openAmount.GetValue(gate), 0.001f);
            }
            finally
            {
                UnityEngine.Object.DestroyImmediate(gateObject);
            }
        }

        [Test]
        public void SluiceGatePrefab_HasIndependentPhysicalGrabHandle()
        {
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(
                "Assets/Khoa/Prefabs/Sluice_Gate_Prefab.prefab");
            Type leverType = Type.GetType("Khoa.Farming.SluiceGateLever, Khoa.Farming");
            Type grabType = Type.GetType(
                "UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable, Unity.XR.Interaction.Toolkit");

            Assert.IsNotNull(prefab);
            Assert.IsNotNull(leverType);
            Assert.IsNotNull(grabType);
            Assert.AreEqual(1, prefab.GetComponentsInChildren(leverType, true).Length);
            Component grab = prefab.GetComponentsInChildren(grabType, true).Single();
            Assert.IsFalse((bool)grabType.GetProperty("trackPosition").GetValue(grab));
            Assert.IsFalse((bool)grabType.GetProperty("trackRotation").GetValue(grab));
            Assert.IsFalse((bool)grabType.GetProperty("throwOnDetach").GetValue(grab));
            Rigidbody body = grab.GetComponent<Rigidbody>();
            Assert.IsNotNull(body);
            Assert.IsTrue(body.isKinematic);
        }

        [Test]
        public void PlotGridGenerator_ExposesLockedProductionConfiguration()
        {
            Type generatorType = AppDomain.CurrentDomain.GetAssemblies()
                .Select(assembly => assembly.GetType("Khoa.Farming.Editor.PlotGridGenerator", false))
                .FirstOrDefault(type => type != null);

            Assert.IsNotNull(generatorType);
            Assert.AreEqual(100, ReadConstant<int>(generatorType, "ProductionRows"));
            Assert.AreEqual(100, ReadConstant<int>(generatorType, "ProductionColumns"));
            Assert.AreEqual(0.08f, ReadConstant<float>(generatorType, "ProductionSpacing"), 0.0001f);
            Assert.AreEqual(5, ReadConstant<int>(generatorType, "ProductionTerrainSamplesPerAxis"));
            Assert.IsNotNull(generatorType.GetMethod(
                "GenerateProductionGridInMainScene",
                BindingFlags.Static | BindingFlags.Public));
        }

        private static T ReadConstant<T>(Type type, string name)
        {
            FieldInfo field = type.GetField(name, BindingFlags.Static | BindingFlags.Public);
            Assert.IsNotNull(field, $"Missing production grid constant: {name}");
            return (T)field.GetRawConstantValue();
        }
    }
}
