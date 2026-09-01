using NUnit.Framework;
using System.Reflection;
using UnityEngine;
using Khoa.Farming;

namespace Khoa.Farming.Tests
{
    [TestFixture]
    public class GrindMillTests
    {
        private GameObject millGO;
        private GrindMillStation millStation;

        [SetUp]
        public void SetUp()
        {
            millGO = new GameObject("Test_GrindMillStation");
            millStation = millGO.AddComponent<GrindMillStation>();
            millStation.millingSpeedMultiplier = 50f;
        }

        [TearDown]
        public void TearDown()
        {
            if (millGO != null)
            {
                Object.DestroyImmediate(millGO);
            }
        }

        [Test]
        public void InitialState_IsEmpty()
        {
            Assert.AreEqual(GrindMillState.Empty, millStation.currentState);
            Assert.AreEqual(0f, millStation.progress);
        }

        [Test]
        public void PourPaddy_TransitionsToReadyToGrind()
        {
            bool poured = millStation.PourPaddyIntoMill();
            Assert.IsTrue(poured);
            Assert.AreEqual(GrindMillState.ReadyToGrind, millStation.currentState);
            Assert.AreEqual(0f, millStation.progress);
        }

        [Test]
        public void PourPaddy_WhenAlreadyReady_ReturnsFalse()
        {
            millStation.PourPaddyIntoMill();
            bool pouredAgain = millStation.PourPaddyIntoMill();
            Assert.IsFalse(pouredAgain);
        }

        [Test]
        public void CompleteMilling_SetsCompletedState_AndSpawnsWhiteRice()
        {
            millStation.PourPaddyIntoMill();
            bool eventFired = false;
            WhiteRiceItem spawnedRice = null;

            millStation.OnMillingCompleted += rice =>
            {
                eventFired = true;
                spawnedRice = rice;
            };

            for (int i = 0; i < 16; i++)
            {
                millStation.ProcessRotation(45f);
            }

            Assert.AreEqual(GrindMillState.Completed, millStation.currentState);
            Assert.AreEqual(100f, millStation.progress);
            Assert.IsTrue(eventFired);
            Assert.IsNotNull(spawnedRice);

            // Clean up spawned item
            if (spawnedRice != null)
            {
                Object.DestroyImmediate(spawnedRice.gameObject);
            }
        }

        [Test]
        public void TryLoadPaddy_ConsumesValidSourceExactlyOnce()
        {
            GameObject sourceGO = new GameObject("SourceWithMultipleColliders");
            PaddyBatchItem source = sourceGO.AddComponent<PaddyBatchItem>();

            Assert.IsTrue(millStation.TryLoadPaddy(source));
            Assert.IsFalse(source.HasPaddy);
            Assert.IsFalse(millStation.TryLoadPaddy(source));
            Assert.AreEqual(GrindMillState.ReadyToGrind, millStation.currentState);

            Object.DestroyImmediate(sourceGO);
        }

        [Test]
        public void TryLoadPaddy_RejectsEmptyAndUnrelatedObjects()
        {
            GameObject emptyGO = new GameObject("Paddy Rice Basket By Name Only");
            PaddyBatchItem emptySource = emptyGO.AddComponent<PaddyBatchItem>();
            emptySource.SetHasPaddy(false);

            Assert.IsFalse(millStation.TryLoadPaddy(emptySource));
            Assert.IsFalse(millStation.TryLoadPaddy(null));
            Assert.AreEqual(GrindMillState.Empty, millStation.currentState);

            Object.DestroyImmediate(emptyGO);
        }

        [Test]
        public void CompleteMilling_CannotSpawnDuplicateOutput()
        {
            millStation.PourPaddyIntoMill();
            int outputs = 0;
            WhiteRiceItem output = null;
            millStation.OnMillingCompleted += rice => { outputs++; output = rice; };
            for (int i = 0; i < 16; i++) millStation.ProcessRotation(45f);

            bool repeated = millStation.CompleteMilling();

            Assert.IsFalse(repeated);
            Assert.AreEqual(1, outputs);
            if (output != null) Object.DestroyImmediate(output.gameObject);
        }

        [Test]
        public void RegrabbingCollectedOutputCannotResetANewerCompletedBatch()
        {
            WhiteRiceItem first = CompleteCurrentBatch();
            InvokeGrab(first);
            Assert.AreEqual(GrindMillState.Empty, millStation.currentState);

            Assert.IsTrue(millStation.PourPaddyIntoMill());
            WhiteRiceItem second = CompleteCurrentBatch();
            Assert.AreEqual(GrindMillState.Completed, millStation.currentState);

            InvokeGrab(first);

            Assert.AreEqual(GrindMillState.Completed, millStation.currentState);
            Assert.IsFalse(millStation.PourPaddyIntoMill());
            Object.DestroyImmediate(first.gameObject);
            Object.DestroyImmediate(second.gameObject);
        }

        private WhiteRiceItem CompleteCurrentBatch()
        {
            if (millStation.currentState == GrindMillState.Empty)
            {
                Assert.IsTrue(millStation.PourPaddyIntoMill());
            }

            WhiteRiceItem output = null;
            void Capture(WhiteRiceItem rice) => output = rice;
            millStation.OnMillingCompleted += Capture;
            for (int i = 0; i < 16; i++) millStation.ProcessRotation(45f);
            millStation.OnMillingCompleted -= Capture;
            Assert.IsNotNull(output);
            return output;
        }

        private static void InvokeGrab(WhiteRiceItem rice)
        {
            MethodInfo onGrab = typeof(WhiteRiceItem).GetMethod("OnGrab", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsNotNull(onGrab);
            onGrab.Invoke(rice, new object[] { null });
        }
    }
}
