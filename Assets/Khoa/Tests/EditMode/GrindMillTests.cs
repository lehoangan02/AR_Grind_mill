using NUnit.Framework;
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

            millStation.CompleteMilling();

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
    }
}
