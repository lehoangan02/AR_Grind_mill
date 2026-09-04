using System.Collections;
using Khoa.Farming;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Khoa.Farming.PlayModeTests
{
    public class CookingRuntimePlayModeTests
    {
        [UnityTest]
        public IEnumerator GrindMill_CompleteProcess_SpawnsWhiteRiceItem()
        {
            GameObject millGO = new GameObject("Runtime_GrindMill");
            GrindMillStation station = millGO.AddComponent<GrindMillStation>();

            yield return null;

            bool poured = station.PourPaddyIntoMill();
            Assert.IsTrue(poured);
            Assert.AreEqual(GrindMillState.ReadyToGrind, station.currentState);

            WhiteRiceItem receivedRice = null;
            station.OnMillingCompleted += rice => receivedRice = rice;

            for (int i = 0; i < 32; i++) station.ProcessRotation(45f);
            yield return null;

            Assert.AreEqual(GrindMillState.Completed, station.currentState);
            Assert.IsNotNull(receivedRice);

            if (receivedRice != null) Object.Destroy(receivedRice.gameObject);
            Object.Destroy(millGO);
        }

        [UnityTest]
        public IEnumerator RiceWashing_FullCycle_ProducesWashedRice()
        {
            GameObject potGO = new GameObject("Runtime_WashingPot");
            potGO.AddComponent<BoxCollider>();
            potGO.AddComponent<Rigidbody>();
            RiceWashingPot washPot = potGO.AddComponent<RiceWashingPot>();

            GameObject riceGO = new GameObject("Runtime_WhiteRice");
            riceGO.AddComponent<BoxCollider>();
            riceGO.AddComponent<Rigidbody>();
            WhiteRiceItem whiteRice = riceGO.AddComponent<WhiteRiceItem>();
            whiteRice.riceAmount = 8;

            yield return null;

            washPot.AddRice(whiteRice);
            Assert.AreEqual(RiceWashingState.HasRice, washPot.currentState);

            washPot.AddWater(1.0f);
            Assert.AreEqual(RiceWashingState.HasRiceAndWater, washPot.currentState);

            washPot.StirRice(100f);
            Assert.AreEqual(RiceWashingState.Washing, washPot.currentState);
            Assert.GreaterOrEqual(washPot.washProgress, 80f);

            washPot.DrainWater();
            Assert.AreEqual(RiceWashingState.WashedRiceReady, washPot.currentState);

            WhiteRiceItem washedRice = washPot.TakeOutWashedRice();
            Assert.IsNotNull(washedRice);
            Assert.IsTrue(washedRice.isWashed);

            if (washedRice != null) Object.Destroy(washedRice.gameObject);
            Object.Destroy(potGO);
        }

        [UnityTest]
        public IEnumerator WoodStoveAndCookingPot_CooksRice_ServesRiceBowl()
        {
            GameObject stoveGO = new GameObject("Runtime_WoodStove");
            stoveGO.AddComponent<BoxCollider>();
            WoodStove stove = stoveGO.AddComponent<WoodStove>();

            GameObject woodGO = new GameObject("Runtime_Firewood");
            woodGO.AddComponent<BoxCollider>();
            woodGO.AddComponent<Rigidbody>();
            FirewoodItem firewood = woodGO.AddComponent<FirewoodItem>();
            stove.AddFirewood(firewood);

            GameObject matchGO = new GameObject("Runtime_Match");
            matchGO.AddComponent<BoxCollider>();
            matchGO.AddComponent<Rigidbody>();
            MatchItem match = matchGO.AddComponent<MatchItem>();
            match.isLit = true;
            stove.Ignite(match);

            Assert.IsTrue(stove.isBurning);

            GameObject potGO = new GameObject("Runtime_CookingPot");
            potGO.AddComponent<BoxCollider>();
            potGO.AddComponent<Rigidbody>();
            CookingPot pot = potGO.AddComponent<CookingPot>();
            pot.timeToCook = 0.2f;

            GameObject riceGO = new GameObject("Runtime_WashedRice");
            riceGO.AddComponent<BoxCollider>();
            riceGO.AddComponent<Rigidbody>();
            WhiteRiceItem rice = riceGO.AddComponent<WhiteRiceItem>();
            rice.riceAmount = 10;
            rice.isWashed = true;

            pot.AddRice(rice);
            pot.AddWater(1.0f);
            Assert.AreEqual(CookingState.ReadyToCook, pot.currentState);

            potGO.GetComponent<Rigidbody>().isKinematic = true;
            potGO.transform.position = stoveGO.transform.position;

            yield return new WaitForSeconds(0.35f);

            Assert.AreEqual(CookingState.Cooked, pot.currentState);

            pot.isLidClosed = false;
            CookedRiceBowl bowl = pot.ServeRiceBowl();
            Assert.IsNotNull(bowl);

            if (bowl != null) Object.Destroy(bowl.gameObject);
            Object.Destroy(matchGO);
            Object.Destroy(potGO);
            Object.Destroy(stoveGO);
        }

        [UnityTest]
        public IEnumerator CookingPot_OpenLid_PausesCookingProgress()
        {
            GameObject potGO = new GameObject("Runtime_OpenLidPot");
            potGO.AddComponent<BoxCollider>();
            potGO.AddComponent<Rigidbody>();
            CookingPot pot = potGO.AddComponent<CookingPot>();
            pot.timeToCook = 0.05f;
            pot.isLidClosed = false;

            GameObject riceGO = new GameObject("Runtime_WashedRice");
            riceGO.AddComponent<BoxCollider>();
            riceGO.AddComponent<Rigidbody>();
            WhiteRiceItem rice = riceGO.AddComponent<WhiteRiceItem>();
            rice.isWashed = true;

            pot.AddRice(rice);
            pot.AddWater(1f);
            pot.SetHeatSource(true);

            yield return new WaitForSeconds(0.12f);

            Assert.AreEqual(CookingState.ReadyToCook, pot.currentState);
            Assert.AreEqual(0f, pot.cookingTimer, 0.001f);

            Object.Destroy(potGO);
        }

        [UnityTest]
        public IEnumerator CookingPot_ContinuedHeatAfterCooking_BurnsRice()
        {
            GameObject potGO = new GameObject("Runtime_BurningPot");
            potGO.AddComponent<BoxCollider>();
            potGO.AddComponent<Rigidbody>();
            CookingPot pot = potGO.AddComponent<CookingPot>();
            pot.timeToCook = 0.05f;
            pot.timeToBurn = 0.12f;
            pot.isLidClosed = true;

            GameObject riceGO = new GameObject("Runtime_WashedRice");
            riceGO.AddComponent<BoxCollider>();
            riceGO.AddComponent<Rigidbody>();
            WhiteRiceItem rice = riceGO.AddComponent<WhiteRiceItem>();
            rice.isWashed = true;

            pot.AddRice(rice);
            pot.AddWater(1f);
            pot.SetHeatSource(true);

            yield return new WaitForSeconds(0.2f);

            Assert.AreEqual(CookingState.Burnt, pot.currentState);

            Object.Destroy(potGO);
        }
    }
}
