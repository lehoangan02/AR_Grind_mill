using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
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

        [Test]
        public void DevInputMap_UsesDocumentedNonConflictingCookingKeys()
        {
            Assert.AreEqual(Key.Q, CookingDevInputMap.ExtractWashedRice);
            Assert.AreEqual(Key.E, CookingDevInputMap.ServeCookedRice);
            Assert.AreEqual(Key.A, CookingDevInputMap.MillCounterClockwisePrimary);
            Assert.AreEqual(Key.LeftArrow, CookingDevInputMap.MillCounterClockwiseAlternate);
            Assert.AreEqual(Key.D, CookingDevInputMap.MillClockwisePrimary);
            Assert.AreEqual(Key.RightArrow, CookingDevInputMap.MillClockwiseAlternate);
            Assert.AreEqual(Key.Z, CookingDevInputMap.MillClockwiseLegacy);
            Assert.AreEqual(Key.UpArrow, CookingDevInputMap.MillClockwiseAccessibility);
            Assert.AreNotEqual(CookingDevInputMap.ExtractWashedRice, CookingDevInputMap.ServeCookedRice);
        }

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
        public void WoodStove_Ignite_WithUnlitMatch_IsRejected()
        {
            GameObject woodGO = new GameObject("Test_Firewood");
            FirewoodItem wood = woodGO.AddComponent<FirewoodItem>();
            woodStove.AddFirewood(wood);
            GameObject matchGO = new GameObject("Test_Match");
            MatchItem match = matchGO.AddComponent<MatchItem>();

            bool ignited = woodStove.Ignite(match);

            Assert.IsFalse(ignited);
            Assert.IsFalse(woodStove.isBurning);
            Object.DestroyImmediate(matchGO);
        }

        [Test]
        public void Match_OnlyLightsOnStrikerAtRequiredSpeed()
        {
            GameObject matchGO = new GameObject("Test_Match");
            MatchItem match = matchGO.AddComponent<MatchItem>();
            GameObject strikerGO = new GameObject("Test_Striker");
            MatchStriker striker = strikerGO.AddComponent<MatchStriker>();

            Assert.IsFalse(match.TryStrike(striker, match.minimumStrikeSpeed - 0.01f));
            Assert.IsFalse(match.isLit);
            Assert.IsTrue(match.TryStrike(striker, match.minimumStrikeSpeed));
            Assert.IsTrue(match.isLit);

            Object.DestroyImmediate(matchGO);
            Object.DestroyImmediate(strikerGO);
        }

        [Test]
        public void WoodStove_MultiplePotColliders_DoNotDropHeatOnFirstExit()
        {
            woodStove.RegisterPotContact(cookingPot, 101);
            woodStove.RegisterPotContact(cookingPot, 202);

            Assert.AreEqual(cookingPot, woodStove.placedPot);
            woodStove.UnregisterPotContact(cookingPot, 101);
            Assert.AreEqual(cookingPot, woodStove.placedPot);
            woodStove.UnregisterPotContact(cookingPot, 202);
            Assert.IsNull(woodStove.placedPot);
        }

        [Test]
        public void PotLid_SnapRequiresCorrectDistanceAndOrientation()
        {
            GameObject snapGO = new GameObject("LidSnapPoint");
            snapGO.transform.SetParent(potGO.transform, false);
            cookingPot.lidSnapPoint = snapGO.transform;
            GameObject lidGO = new GameObject("Test_Lid");
            PotLid lid = lidGO.AddComponent<PotLid>();
            lidGO.transform.position = snapGO.transform.position;
            lidGO.transform.rotation = Quaternion.Euler(90f, 0f, 0f);

            Assert.IsFalse(lid.CanSnapTo(cookingPot));
            lidGO.transform.rotation = snapGO.transform.rotation;
            Assert.IsTrue(lid.CanSnapTo(cookingPot));
            lidGO.transform.position += Vector3.right * (lid.maxSnapDistance + 0.01f);
            Assert.IsFalse(lid.CanSnapTo(cookingPot));

            Object.DestroyImmediate(lidGO);
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
        public void CookingPot_AddUnwashedRice_IsRejectedAndPreservesRiceItem()
        {
            GameObject riceGO = new GameObject("Test_UnwashedRice");
            riceGO.AddComponent<BoxCollider>();
            riceGO.AddComponent<Rigidbody>();
            WhiteRiceItem rice = riceGO.AddComponent<WhiteRiceItem>();
            rice.isWashed = false;

            bool added = cookingPot.AddRice(rice);

            Assert.IsFalse(added);
            Assert.AreEqual(CookingState.Empty, cookingPot.currentState);
            Assert.AreEqual(0, cookingPot.currentRiceAmount);
            Assert.IsNotNull(rice);

            Object.DestroyImmediate(riceGO);
        }

        [Test]
        public void CookingPot_WaterBelowRequiredAmount_DoesNotBecomeReadyToCook()
        {
            GameObject riceGO = new GameObject("Test_WashedRice");
            riceGO.AddComponent<BoxCollider>();
            riceGO.AddComponent<Rigidbody>();
            WhiteRiceItem rice = riceGO.AddComponent<WhiteRiceItem>();
            rice.isWashed = true;

            cookingPot.AddRice(rice);
            cookingPot.AddWater(0.8f);

            Assert.AreEqual(CookingState.HasRice, cookingPot.currentState);
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

            cookingPot.isLidClosed = false;
            CookedRiceBowl bowl = cookingPot.ServeRiceBowl();
            Assert.IsNotNull(bowl);
            Assert.IsFalse(bowl.isBurnt);

            if (bowl != null) Object.DestroyImmediate(bowl.gameObject);
        }

        [Test]
        public void CookingPot_ServeRiceBowl_RequiresOpenLidAndOnlyServesOnce()
        {
            GameObject riceGO = new GameObject("Test_WashedRice");
            riceGO.AddComponent<BoxCollider>();
            riceGO.AddComponent<Rigidbody>();
            WhiteRiceItem rice = riceGO.AddComponent<WhiteRiceItem>();
            rice.isWashed = true;

            cookingPot.AddRice(rice);
            cookingPot.AddWater(1f);
            cookingPot.CompleteCooking();

            CookedRiceBowl closedLidResult = cookingPot.ServeRiceBowl();
            if (closedLidResult != null) Object.DestroyImmediate(closedLidResult.gameObject);
            Assert.IsNull(closedLidResult);

            cookingPot.isLidClosed = false;
            CookedRiceBowl firstBowl = cookingPot.ServeRiceBowl();
            CookedRiceBowl secondBowl = cookingPot.ServeRiceBowl();

            Assert.IsNotNull(firstBowl);
            Assert.IsNull(secondBowl);

            if (firstBowl != null) Object.DestroyImmediate(firstBowl.gameObject);
        }

        [Test]
        public void ServingLadle_ProducesBowlOnlyFromValidOpenPot()
        {
            GameObject ladleGO = new GameObject("Test_ServingLadle");
            RiceServingLadle ladle = ladleGO.AddComponent<RiceServingLadle>();

            Assert.IsNull(ladle.TryServe(cookingPot));

            GameObject riceGO = new GameObject("Test_WashedRice");
            WhiteRiceItem rice = riceGO.AddComponent<WhiteRiceItem>();
            rice.isWashed = true;
            cookingPot.AddRice(rice);
            cookingPot.AddWater(1f);
            cookingPot.CompleteCooking();
            cookingPot.isLidClosed = false;

            CookedRiceBowl bowl = ladle.TryServe(cookingPot);
            Assert.IsNotNull(bowl);
            Assert.IsNull(ladle.TryServe(cookingPot));

            if (bowl != null) Object.DestroyImmediate(bowl.gameObject);
            Object.DestroyImmediate(ladleGO);
        }
    }
}
