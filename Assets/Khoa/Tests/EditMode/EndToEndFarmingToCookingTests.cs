using NUnit.Framework;
using UnityEngine;
using Khoa.Farming;

namespace Khoa.Farming.Tests
{
    [TestFixture]
    public class EndToEndFarmingToCookingTests
    {
        [Test]
        public void FullCycle_FromHarvestToCookedRice_SucceedsSeamlessly()
        {
            // 1. Phơi lúa trên sân phơi
            GameObject bundleGO = new GameObject("Test_RiceBundle");
            bundleGO.AddComponent<BoxCollider>();
            bundleGO.AddComponent<Rigidbody>();
            RiceBundleItem bundle = bundleGO.AddComponent<RiceBundleItem>();
            bundle.drynessProgress = 0f;

            GameObject yardGO = new GameObject("Test_DryingYard");
            RiceDryingYard yard = yardGO.AddComponent<RiceDryingYard>();
            yard.dryingSpeedPerSecond = 1000f;

            // Mô phỏng phơi khô lúa 100%
            bundle.AddDryness(100f);
            Assert.IsTrue(bundle.isDry);

            // 2. Tuốt lúa
            GameObject thresherGO = new GameObject("Test_Thresher");
            RiceThresher thresher = thresherGO.AddComponent<RiceThresher>();

            // 3. Đổ lúa vào cối xay gạo
            GameObject millGO = new GameObject("Test_GrindMill");
            GrindMillStation mill = millGO.AddComponent<GrindMillStation>();

            bool poured = mill.PourPaddyIntoMill();
            Assert.IsTrue(poured);
            Assert.AreEqual(GrindMillState.ReadyToGrind, mill.currentState);

            WhiteRiceItem milledRice = null;
            mill.OnMillingCompleted += rice => milledRice = rice;

            mill.CompleteMilling();
            Assert.AreEqual(GrindMillState.Completed, mill.currentState);
            Assert.IsNotNull(milledRice);

            // 4. Vo gạo trong thau vo gạo
            GameObject washPotGO = new GameObject("Test_WashingPot");
            washPotGO.AddComponent<BoxCollider>();
            washPotGO.AddComponent<Rigidbody>();
            RiceWashingPot washPot = washPotGO.AddComponent<RiceWashingPot>();

            washPot.AddRice(milledRice);
            washPot.AddWater(1.0f);
            Assert.AreEqual(RiceWashingState.HasRiceAndWater, washPot.currentState);

            washPot.StirRice(80f);
            washPot.DrainWater();
            Assert.AreEqual(RiceWashingState.WashedRiceReady, washPot.currentState);

            WhiteRiceItem washedRice = washPot.TakeOutWashedRice();
            Assert.IsNotNull(washedRice);
            Assert.IsTrue(washedRice.isWashed);

            // 5. Nhóm bếp củi
            GameObject stoveGO = new GameObject("Test_WoodStove");
            stoveGO.AddComponent<BoxCollider>();
            WoodStove stove = stoveGO.AddComponent<WoodStove>();

            GameObject woodGO = new GameObject("Test_Firewood");
            woodGO.AddComponent<BoxCollider>();
            woodGO.AddComponent<Rigidbody>();
            FirewoodItem wood = woodGO.AddComponent<FirewoodItem>();
            stove.AddFirewood(wood);

            GameObject matchGO = new GameObject("Test_Match");
            matchGO.AddComponent<BoxCollider>();
            matchGO.AddComponent<Rigidbody>();
            MatchItem match = matchGO.AddComponent<MatchItem>();
            match.isLit = true;
            stove.Ignite(match);
            Assert.IsTrue(stove.isBurning);

            // 6. Nấu cơm trong nồi gang
            GameObject potGO = new GameObject("Test_CookingPot");
            potGO.AddComponent<BoxCollider>();
            potGO.AddComponent<Rigidbody>();
            CookingPot pot = potGO.AddComponent<CookingPot>();

            pot.AddRice(washedRice);
            pot.AddWater(1.0f);
            Assert.AreEqual(CookingState.ReadyToCook, pot.currentState);

            pot.SetHeatSource(true);
            pot.CompleteCooking();
            Assert.AreEqual(CookingState.Cooked, pot.currentState);

            // 7. Xới cơm ra bát
            CookedRiceBowl bowl = pot.ServeRiceBowl();
            Assert.IsNotNull(bowl);
            Assert.IsFalse(bowl.isBurnt);

            // Clean up
            if (bowl != null) Object.DestroyImmediate(bowl.gameObject);
            Object.DestroyImmediate(potGO);
            Object.DestroyImmediate(matchGO);
            Object.DestroyImmediate(stoveGO);
            Object.DestroyImmediate(washPotGO);
            Object.DestroyImmediate(millGO);
            Object.DestroyImmediate(thresherGO);
            Object.DestroyImmediate(yardGO);
            Object.DestroyImmediate(bundleGO);
        }
    }
}
