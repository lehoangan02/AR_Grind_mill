using NUnit.Framework;
using UnityEngine;
using Khoa.Farming;

namespace Khoa.Farming.Tests
{
    [TestFixture]
    public class RiceWashingTests
    {
        private GameObject potGO;
        private RiceWashingPot washingPot;
        private GameObject dipperGO;
        private WaterDipper waterDipper;

        [SetUp]
        public void SetUp()
        {
            potGO = new GameObject("Test_RiceWashingPot");
            potGO.AddComponent<BoxCollider>();
            potGO.AddComponent<Rigidbody>();
            washingPot = potGO.AddComponent<RiceWashingPot>();

            dipperGO = new GameObject("Test_WaterDipper");
            dipperGO.AddComponent<BoxCollider>();
            dipperGO.AddComponent<Rigidbody>();
            waterDipper = dipperGO.AddComponent<WaterDipper>();
        }

        [TearDown]
        public void TearDown()
        {
            if (potGO != null) Object.DestroyImmediate(potGO);
            if (dipperGO != null) Object.DestroyImmediate(dipperGO);
        }

        [Test]
        public void InitialState_IsEmpty()
        {
            Assert.AreEqual(RiceWashingState.Empty, washingPot.currentState);
            Assert.AreEqual(0f, washingPot.washProgress);
            Assert.AreEqual(0f, washingPot.currentWater);
        }

        [Test]
        public void AddRice_TransitionsToHasRice()
        {
            GameObject riceGO = new GameObject("Test_WhiteRice");
            riceGO.AddComponent<BoxCollider>();
            riceGO.AddComponent<Rigidbody>();
            WhiteRiceItem riceItem = riceGO.AddComponent<WhiteRiceItem>();
            riceItem.riceAmount = 10;

            bool added = washingPot.AddRice(riceItem);

            Assert.IsTrue(added);
            Assert.AreEqual(RiceWashingState.HasRice, washingPot.currentState);
            Assert.AreEqual(10, washingPot.currentRiceAmount);
        }

        [Test]
        public void AddWater_TransitionsToHasRiceAndWater()
        {
            GameObject riceGO = new GameObject("Test_WhiteRice");
            riceGO.AddComponent<BoxCollider>();
            riceGO.AddComponent<Rigidbody>();
            WhiteRiceItem riceItem = riceGO.AddComponent<WhiteRiceItem>();
            washingPot.AddRice(riceItem);

            washingPot.AddWater(1.0f);

            Assert.AreEqual(RiceWashingState.HasRiceAndWater, washingPot.currentState);
            Assert.AreEqual(1.0f, washingPot.currentWater);
        }

        [Test]
        public void StirRice_IncreasesWashProgress()
        {
            GameObject riceGO = new GameObject("Test_WhiteRice");
            riceGO.AddComponent<BoxCollider>();
            riceGO.AddComponent<Rigidbody>();
            WhiteRiceItem riceItem = riceGO.AddComponent<WhiteRiceItem>();
            washingPot.AddRice(riceItem);
            washingPot.AddWater(1.0f);

            washingPot.StirRice(30f);

            Assert.AreEqual(RiceWashingState.Washing, washingPot.currentState);
            Assert.AreEqual(30f, washingPot.washProgress);
        }

        [Test]
        public void DrainWater_WhenWashProgressHigh_TransitionsToWashedRiceReady()
        {
            GameObject riceGO = new GameObject("Test_WhiteRice");
            riceGO.AddComponent<BoxCollider>();
            riceGO.AddComponent<Rigidbody>();
            WhiteRiceItem riceItem = riceGO.AddComponent<WhiteRiceItem>();
            washingPot.AddRice(riceItem);
            washingPot.AddWater(1.0f);

            washingPot.StirRice(80f);
            washingPot.DrainWater();

            Assert.AreEqual(RiceWashingState.WashedRiceReady, washingPot.currentState);
            Assert.AreEqual(0f, washingPot.currentWater);

            WhiteRiceItem washedRice = washingPot.TakeOutWashedRice();
            Assert.IsNotNull(washedRice);
            Assert.IsTrue(washedRice.isWashed);

            if (washedRice != null) Object.DestroyImmediate(washedRice.gameObject);
        }

        [Test]
        public void WaterDipper_ScoopAndPour_WorksCorrectly()
        {
            Assert.IsFalse(waterDipper.hasWater);

            waterDipper.ScoopWater();
            Assert.IsTrue(waterDipper.hasWater);

            waterDipper.PourWater();
            Assert.IsFalse(waterDipper.hasWater);
        }
    }
}
