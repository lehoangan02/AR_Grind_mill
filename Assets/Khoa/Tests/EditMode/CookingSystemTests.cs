using NUnit.Framework;
using System.Reflection;
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
        public void Firewood_CanOnlyBeConsumedByStoveOnceAcrossMultipleColliders()
        {
            GameObject woodGO = new GameObject("Test_MultiColliderFirewood");
            FirewoodItem wood = woodGO.AddComponent<FirewoodItem>();

            Assert.IsTrue(wood.TryConsumeForStove());
            Assert.IsFalse(wood.TryConsumeForStove());
            Object.DestroyImmediate(woodGO);
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
            rice.riceAmount = CookingPot.RequiredRiceAmount;
            rice.isWashed = true;

            cookingPot.AddRice(rice);
            Assert.AreEqual(CookingState.HasRice, cookingPot.currentState);

            cookingPot.AddWater(1.0f);
            Assert.AreEqual(CookingState.ReadyToCook, cookingPot.currentState);
        }

        [Test]
        public void CookingPot_RejectsWrongSizedOrDuplicateRiceBatchWithoutDestroyingInput()
        {
            GameObject wrongGO = new GameObject("Test_WrongRiceBatch");
            WhiteRiceItem wrong = wrongGO.AddComponent<WhiteRiceItem>();
            wrong.isWashed = true;
            wrong.riceAmount = CookingPot.RequiredRiceAmount - 1;

            Assert.IsFalse(cookingPot.AddRice(wrong));
            Assert.IsNotNull(wrong);

            GameObject firstGO = new GameObject("Test_FirstRiceBatch");
            WhiteRiceItem first = firstGO.AddComponent<WhiteRiceItem>();
            first.isWashed = true;
            first.riceAmount = CookingPot.RequiredRiceAmount;
            Assert.IsTrue(cookingPot.AddRice(first));

            GameObject duplicateGO = new GameObject("Test_DuplicateRiceBatch");
            WhiteRiceItem duplicate = duplicateGO.AddComponent<WhiteRiceItem>();
            duplicate.isWashed = true;
            duplicate.riceAmount = CookingPot.RequiredRiceAmount;
            Assert.IsFalse(cookingPot.AddRice(duplicate));
            Assert.IsNotNull(duplicate);
            Assert.AreEqual(CookingPot.RequiredRiceAmount, cookingPot.currentRiceAmount);

            Object.DestroyImmediate(wrongGO);
            Object.DestroyImmediate(duplicateGO);
        }

        [Test]
        public void CookingPot_RejectsExcessRecipeWaterWithoutChangingThePot()
        {
            GameObject riceGO = new GameObject("Test_WashedRice");
            WhiteRiceItem rice = riceGO.AddComponent<WhiteRiceItem>();
            rice.isWashed = true;
            rice.riceAmount = CookingPot.RequiredRiceAmount;
            Assert.IsTrue(cookingPot.AddRice(rice));

            Assert.IsFalse(cookingPot.TryAddWater(CookingPot.RequiredWaterAmount + 0.1f));
            Assert.AreEqual(0f, cookingPot.currentWaterAmount);
            Assert.AreEqual(CookingState.HasRice, cookingPot.currentState);
            Assert.IsTrue(cookingPot.TryAddWater(CookingPot.RequiredWaterAmount));
            Assert.AreEqual(CookingState.ReadyToCook, cookingPot.currentState);
        }

        [Test]
        public void CookingPot_CompleteCookingRequiresHeatClosedLidAndElapsedTime()
        {
            GameObject riceGO = new GameObject("Test_WashedRice");
            WhiteRiceItem rice = riceGO.AddComponent<WhiteRiceItem>();
            rice.isWashed = true;
            rice.riceAmount = CookingPot.RequiredRiceAmount;
            cookingPot.AddRice(rice);
            cookingPot.AddWater(CookingPot.RequiredWaterAmount);
            cookingPot.cookingTimer = cookingPot.timeToCook;

            cookingPot.CompleteCooking();
            Assert.AreEqual(CookingState.ReadyToCook, cookingPot.currentState);

            cookingPot.SetHeatSource(true);
            cookingPot.isLidClosed = false;
            cookingPot.CompleteCooking();
            Assert.AreEqual(CookingState.ReadyToCook, cookingPot.currentState);

            cookingPot.isLidClosed = true;
            cookingPot.CompleteCooking();
            Assert.AreEqual(CookingState.Cooked, cookingPot.currentState);
        }

        [Test]
        public void CookingPot_RepeatedHeatContactReportsMissingWaterOnlyOnce()
        {
            GameObject riceGO = new GameObject("Test_WashedRice");
            WhiteRiceItem rice = riceGO.AddComponent<WhiteRiceItem>();
            rice.isWashed = true;
            rice.riceAmount = CookingPot.RequiredRiceAmount;
            cookingPot.AddRice(rice);
            int feedbackCount = 0;
            string feedback = null;
            cookingPot.OnFeedback += message =>
            {
                feedbackCount++;
                feedback = message;
            };

            cookingPot.SetHeatSource(true);
            cookingPot.SetHeatSource(true);

            Assert.AreEqual(1, feedbackCount);
            StringAssert.Contains("thiếu nước", feedback);
        }

        [Test]
        public void QuestGuide_RejectsSkippedAndBackwardSteps()
        {
            GameObject guideGO = new GameObject("Test_QuestGuide");
            CookingQuestGuide guide = guideGO.AddComponent<CookingQuestGuide>();

            guide.SetStep(CookingQuestStep.Step9_ServeCookedRice);
            Assert.AreEqual(CookingQuestStep.Step1_PourPaddy, guide.currentStep);
            guide.SetStep(CookingQuestStep.Step2_GrindMill);
            Assert.AreEqual(CookingQuestStep.Step2_GrindMill, guide.currentStep);
            guide.SetStep(CookingQuestStep.Step1_PourPaddy);
            Assert.AreEqual(CookingQuestStep.Step2_GrindMill, guide.currentStep);

            Object.DestroyImmediate(guideGO);
        }

        [Test]
        public void ServingLadle_KeepsPotTrackedUntilAllPotCollidersExit()
        {
            GameObject ladleGO = new GameObject("Test_ServingLadle");
            RiceServingLadle ladle = ladleGO.AddComponent<RiceServingLadle>();
            GameObject childGO = new GameObject("PotChildCollider");
            childGO.transform.SetParent(potGO.transform, false);
            BoxCollider childCollider = childGO.AddComponent<BoxCollider>();
            Collider rootCollider = potGO.GetComponent<Collider>();
            MethodInfo track = typeof(RiceServingLadle).GetMethod("TrackPot", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo clear = typeof(RiceServingLadle).GetMethod("ClearPot", BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo overlapping = typeof(RiceServingLadle).GetField("overlappingPot", BindingFlags.Instance | BindingFlags.NonPublic);

            track.Invoke(ladle, new object[] { rootCollider });
            track.Invoke(ladle, new object[] { childCollider });
            clear.Invoke(ladle, new object[] { rootCollider });

            Assert.AreEqual(cookingPot, overlapping.GetValue(ladle));
            clear.Invoke(ladle, new object[] { childCollider });
            Assert.IsNull(overlapping.GetValue(ladle));
            Object.DestroyImmediate(ladleGO);
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
        public void CookingPot_InvalidIngredientRaisesPlayerFacingFeedback()
        {
            string feedback = null;
            cookingPot.OnFeedback += message => feedback = message;
            GameObject riceGO = new GameObject("Test_UnwashedRice");
            WhiteRiceItem rice = riceGO.AddComponent<WhiteRiceItem>();

            Assert.IsFalse(cookingPot.AddRice(rice));
            Assert.IsNotNull(feedback);
            StringAssert.Contains("chưa vo sạch", feedback);
            Object.DestroyImmediate(riceGO);
        }

        [Test]
        public void CookedRiceBowl_BurntStateUpdatesVisibleColor()
        {
            GameObject bowlGO = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            CookedRiceBowl bowl = bowlGO.AddComponent<CookedRiceBowl>();

            bowl.SetBurnt(true);

            MaterialPropertyBlock block = new MaterialPropertyBlock();
            bowl.riceRenderer.GetPropertyBlock(block);
            Assert.IsTrue(bowl.isBurnt);
            Color actualColor = block.GetColor(Shader.PropertyToID("_BaseColor"));
            Assert.Less(Vector4.Distance(bowl.burntRiceColor, actualColor), 0.001f);
            Object.DestroyImmediate(bowlGO);
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
            rice.riceAmount = CookingPot.RequiredRiceAmount;
            rice.isWashed = true;

            cookingPot.AddRice(rice);
            cookingPot.AddWater(1.0f);

            cookingPot.SetHeatSource(true);
            cookingPot.cookingTimer = cookingPot.timeToCook;
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
            cookingPot.SetHeatSource(true);
            cookingPot.cookingTimer = cookingPot.timeToCook;
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
            cookingPot.SetHeatSource(true);
            cookingPot.cookingTimer = cookingPot.timeToCook;
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
