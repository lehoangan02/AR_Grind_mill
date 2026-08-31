using NUnit.Framework;
using UnityEngine;
using Khoa.Farming;

namespace Khoa.Farming.Tests
{
    [TestFixture]
    public class CookingSystemTests
    {
        private GameObject stoveGO;
        private WoodStove woodStove;

        private GameObject potGO;
        private CookingPot cookingPot;

        [SetUp]
        public void SetUp()
        {
            stoveGO = new GameObject("Test_WoodStove");
            stoveGO.AddComponent<BoxCollider>();
            woodStove = stoveGO.AddComponent<WoodStove>();

            potGO = new GameObject("Test_CookingPot");
            potGO.AddComponent<BoxCollider>();
            potGO.AddComponent<Rigidbody>();
            cookingPot = potGO.AddComponent<CookingPot>();
            cookingPot.timeToCook = 1.0f;
            cookingPot.timeToBurn = 5.0f;
        }

        [TearDown]
        public void TearDown()
        {
            if (stoveGO != null) Object.DestroyImmediate(stoveGO);
            if (potGO != null) Object.DestroyImmediate(potGO);
        }

        [Test]
        public void WoodStove_AddFirewood_IncreasesCountAndFuel()
        {
            GameObject woodGO = new GameObject("Test_Firewood");
            woodGO.AddComponent<BoxCollider>();
            woodGO.AddComponent<Rigidbody>();
            FirewoodItem wood = woodGO.AddComponent<FirewoodItem>();
            wood.fuelValue = 20f;

            bool added = woodStove.AddFirewood(wood);
            Assert.IsTrue(added);
            Assert.AreEqual(1, woodStove.currentFirewoodCount);
            Assert.AreEqual(20f, woodStove.remainingFuelTime);
        }

        [Test]
        public void WoodStove_Ignite_WithoutWood_ReturnsFalse()
        {
            GameObject matchGO = new GameObject("Test_Match");
            matchGO.AddComponent<BoxCollider>();
            matchGO.AddComponent<Rigidbody>();
            MatchItem match = matchGO.AddComponent<MatchItem>();
            match.isLit = true;

            bool ignited = woodStove.Ignite(match);
            Assert.IsFalse(ignited);
            Assert.IsFalse(woodStove.isBurning);

            Object.DestroyImmediate(matchGO);
        }

        [Test]
        public void WoodStove_Ignite_WithWood_StartsBurning()
        {
            GameObject woodGO = new GameObject("Test_Firewood");
            woodGO.AddComponent<BoxCollider>();
            woodGO.AddComponent<Rigidbody>();
            FirewoodItem wood = woodGO.AddComponent<FirewoodItem>();
            woodStove.AddFirewood(wood);

            GameObject matchGO = new GameObject("Test_Match");
            matchGO.AddComponent<BoxCollider>();
            matchGO.AddComponent<Rigidbody>();
            MatchItem match = matchGO.AddComponent<MatchItem>();
            match.isLit = true;

            bool ignited = woodStove.Ignite(match);
            Assert.IsTrue(ignited);
            Assert.IsTrue(woodStove.isBurning);

            Object.DestroyImmediate(matchGO);
        }

        [Test]
        public void CookingPot_AddWashedRiceAndWater_BecomesReadyToCook()
        {
            GameObject riceGO = new GameObject("Test_WhiteRice");
            riceGO.AddComponent<BoxCollider>();
            riceGO.AddComponent<Rigidbody>();
            WhiteRiceItem rice = riceGO.AddComponent<WhiteRiceItem>();
            rice.riceAmount = 5;
            rice.isWashed = true;

            cookingPot.AddRice(rice);
            Assert.AreEqual(CookingState.HasRice, cookingPot.currentState);

            cookingPot.AddWater(1.0f);
            Assert.AreEqual(CookingState.ReadyToCook, cookingPot.currentState);
        }

        [Test]
        public void CookingPot_CompleteCooking_TransitionsToCooked_AndServesBowl()
        {
            GameObject riceGO = new GameObject("Test_WhiteRice");
            riceGO.AddComponent<BoxCollider>();
            riceGO.AddComponent<Rigidbody>();
            WhiteRiceItem rice = riceGO.AddComponent<WhiteRiceItem>();
            rice.riceAmount = 5;
            rice.isWashed = true;

            cookingPot.AddRice(rice);
            cookingPot.AddWater(1.0f);

            cookingPot.CompleteCooking();
            Assert.AreEqual(CookingState.Cooked, cookingPot.currentState);

            CookedRiceBowl bowl = cookingPot.ServeRiceBowl();
            Assert.IsNotNull(bowl);
            Assert.IsFalse(bowl.isBurnt);

            if (bowl != null) Object.DestroyImmediate(bowl.gameObject);
        }
    }
}
