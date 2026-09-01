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

            washingPot.StirRice(100f);
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

            bool poured = waterDipper.TryPourInto(washingPot);
            Assert.IsTrue(poured);
            Assert.IsFalse(waterDipper.hasWater);
            Assert.AreEqual(1f, washingPot.currentWater);
        }

        [Test]
        public void WaterDipper_MissedPour_PreservesWater()
        {
            waterDipper.ScoopWater();

            bool poured = waterDipper.TryPourInto(null);

            Assert.IsFalse(poured);
            Assert.IsTrue(waterDipper.hasWater);
        }

        [Test]
        public void AddWater_RejectsNonPositiveAmount_AndCapsCapacity()
        {
            washingPot.maxWaterCapacity = 2f;

            Assert.IsFalse(washingPot.TryAddWater(-1f));
            Assert.IsTrue(washingPot.TryAddWater(3f));
            Assert.AreEqual(2f, washingPot.currentWater);
        }

        [Test]
        public void DrainWater_BelowFullWash_CannotCreateWashedRice()
        {
            GameObject riceGO = new GameObject("Test_WhiteRice");
            WhiteRiceItem riceItem = riceGO.AddComponent<WhiteRiceItem>();
            washingPot.AddRice(riceItem);
            washingPot.AddWater(1f);
            washingPot.StirRice(99f);

            washingPot.DrainWater();

            Assert.AreEqual(RiceWashingState.HasRice, washingPot.currentState);
            Assert.IsNull(washingPot.TakeOutWashedRice());
        }

        [Test]
        public void CircularStir_RequiresMeaningfulAngularTravel()
        {
            GameObject riceGO = new GameObject("Test_WhiteRice");
            WhiteRiceItem riceItem = riceGO.AddComponent<WhiteRiceItem>();
            washingPot.AddRice(riceItem);
            washingPot.AddWater(1f);

            Assert.IsFalse(washingPot.RecordStirPoint(new Vector3(0.2f, 0f, 0f), 0f));
            Assert.IsFalse(washingPot.RecordStirPoint(new Vector3(0.2f, 0f, 0f), 0.1f));
            Assert.IsTrue(washingPot.RecordStirPoint(new Vector3(0f, 0f, 0.2f), 0.2f));
            Assert.Greater(washingPot.washProgress, 0f);
        }

        [Test]
        public void WashedRiceScoop_ExtractsExactlyOneFullyWashedBatch()
        {
            GameObject riceGO = new GameObject("Test_WhiteRice");
            WhiteRiceItem riceItem = riceGO.AddComponent<WhiteRiceItem>();
            riceItem.riceAmount = 7;
            washingPot.AddRice(riceItem);
            washingPot.AddWater(1f);
            washingPot.StirRice(100f);
            washingPot.DrainWater();
            GameObject scoopGO = new GameObject("Test_WashedRiceScoop");
            WashedRiceScoop scoop = scoopGO.AddComponent<WashedRiceScoop>();

            WhiteRiceItem output = scoop.TryExtract(washingPot);

            Assert.IsNotNull(output);
            Assert.IsTrue(output.isWashed);
            Assert.AreEqual(7, output.riceAmount);
            Assert.IsNull(scoop.TryExtract(washingPot));
            Assert.AreEqual(RiceWashingState.Empty, washingPot.currentState);
            if (output != null) Object.DestroyImmediate(output.gameObject);
            Object.DestroyImmediate(scoopGO);
        }
    }
}
