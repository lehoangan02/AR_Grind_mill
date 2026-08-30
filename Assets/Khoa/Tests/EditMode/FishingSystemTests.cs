using NUnit.Framework;
using UnityEngine;

namespace Khoa.Farming.Tests
{
    public class FishingSystemTests
    {
        private GameObject testRoot;
        private VRFishingController rod;
        private Transform hookWithLine;
        private Transform hookMesh;
        private GameObject dummyFishPrefab;

        [SetUp]
        public void Setup()
        {
            testRoot = new GameObject("TestRoot_Fishing");

            GameObject rodGO = new GameObject("TestFishingRod");
            rodGO.transform.SetParent(testRoot.transform);
            rod = rodGO.AddComponent<VRFishingController>();

            GameObject lineGO = new GameObject("HookWithLine");
            lineGO.transform.SetParent(rodGO.transform, false);
            hookWithLine = lineGO.transform;

            GameObject hookMeshGO = new GameObject("HookMesh");
            hookMeshGO.transform.SetParent(lineGO.transform, false);
            hookMesh = hookMeshGO.transform;

            dummyFishPrefab = new GameObject("DummyFishPrefab");
            dummyFishPrefab.transform.SetParent(testRoot.transform);
            dummyFishPrefab.AddComponent<BoxCollider>();
            dummyFishPrefab.AddComponent<Rigidbody>();

            rod.hookWithLine = hookWithLine;
            rod.hookMesh = hookMesh;
            rod.fishPrefab = dummyFishPrefab;
            rod.idleScaleY = 0.1f;
            rod.waterScaleY = 2.5f;
            rod.pullThreshold = 1.0f;
        }

        [TearDown]
        public void Teardown()
        {
            if (testRoot != null)
            {
                Object.DestroyImmediate(testRoot);
            }
        }

        [Test]
        public void Test_VRFishingController_InitialState_IsIdle()
        {
            Assert.IsFalse(rod.isEquipped, "Cần câu ban đầu chưa trang bị (isEquipped = false)");
            Assert.AreEqual(VRFishingController.FishingState.Idle, rod.currentState, "Trạng thái ban đầu phải là Idle");
        }

        [Test]
        public void Test_VRFishingController_EquipRod_SetsEquippedTrue()
        {
            rod.EquipRod();
            Assert.IsTrue(rod.isEquipped, "Sau khi EquipRod(), isEquipped phải là true");
        }

        [Test]
        public void Test_FishingHookTrigger_DetectsWaterCollider()
        {
            GameObject triggerGO = new GameObject("HookTriggerGO");
            triggerGO.transform.SetParent(testRoot.transform);
            BoxCollider col = triggerGO.AddComponent<BoxCollider>();
            col.isTrigger = true;
            FishingHookTrigger trigger = triggerGO.AddComponent<FishingHookTrigger>();
            trigger.fishingController = rod;

            // 1. Tạo water collider giả lập với Tag "Water"
            GameObject waterGO = new GameObject("WaterObject");
            waterGO.transform.SetParent(testRoot.transform);
            waterGO.tag = "Water";
            BoxCollider waterCol = waterGO.AddComponent<BoxCollider>();

            Assert.IsTrue(trigger.IsWaterCollider(waterCol), "HookTrigger phải nhận diện được Collider với Tag 'Water'");

            // 2. Tạo FishingZone object
            GameObject zoneGO = new GameObject("FishingZoneObject");
            zoneGO.transform.SetParent(testRoot.transform);
            BoxCollider zoneCol = zoneGO.AddComponent<BoxCollider>();
            zoneGO.AddComponent<FishingZone>();

            Assert.IsTrue(trigger.IsWaterCollider(zoneCol), "HookTrigger phải nhận diện được Collider có FishingZone component");
        }

        [Test]
        public void Test_VRFishingController_StartFishingInWater_TransitionsState()
        {
            rod.EquipRod();
            Assert.AreEqual(VRFishingController.FishingState.Idle, rod.currentState);

            bool stateChanged = false;
            VRFishingController.FishingState lastState = VRFishingController.FishingState.Idle;
            rod.OnStateChanged += (newState) =>
            {
                stateChanged = true;
                lastState = newState;
            };

            rod.StartFishingInWater();

            Assert.IsTrue(stateChanged, "Sự kiện OnStateChanged phải được kích hoạt khi thả câu");
            Assert.AreEqual(VRFishingController.FishingState.DroppingLine, lastState, "Trạng thái tiếp theo phải chuyển sang DroppingLine");
        }

        [Test]
        public void Test_VRFishingController_ReelIn_ResetsToIdle()
        {
            rod.EquipRod();
            rod.StartFishingInWater();
            Assert.AreNotEqual(VRFishingController.FishingState.Idle, rod.currentState);

            rod.ReelIn();
            Assert.AreEqual(VRFishingController.FishingState.Idle, rod.currentState, "Sau khi ReelIn(), trạng thái phải quay về Idle");
        }

        [Test]
        public void Test_FishingZone_SetsCustomFishTypeAndParameters()
        {
            GameObject zoneGO = new GameObject("CatfishZone");
            zoneGO.transform.SetParent(testRoot.transform);
            FishingZone zone = zoneGO.AddComponent<FishingZone>();
            zone.zoneName = "Cầu Cá Tra";
            zone.fishType = FishType.Catfish;
            zone.customFishPrefab = dummyFishPrefab;
            zone.pullThresholdMultiplier = 1.5f;

            rod.EquipRod();
            rod.StartFishingInWater(zone);

            Assert.IsNotNull(rod.currentZone);
            Assert.AreEqual("Cầu Cá Tra", rod.currentZone.zoneName);
            Assert.AreEqual(FishType.Catfish, rod.currentZone.fishType);
        }

        [Test]
        public void Test_CaughtFishItem_Grab_DetachesFromHookAndResetsRod()
        {
            rod.EquipRod();

            // Giả lập cá đã mắc vào lưỡi câu
            GameObject fishInst = Object.Instantiate(dummyFishPrefab, hookMesh.position, hookMesh.rotation, hookMesh);
            CaughtFishItem fishItem = fishInst.AddComponent<CaughtFishItem>();
            fishItem.ownerRod = rod;
            fishItem.fishName = "Cá Tra";

            Assert.AreEqual(hookMesh, fishInst.transform.parent, "Con cá ban đầu phải là con của hookMesh");

            bool eventFired = false;
            fishItem.OnFishCollected += (f) => { eventFired = true; };

            fishItem.CollectFish();

            Assert.IsNull(fishInst.transform.parent, "Sau khi gỡ cá khỏi lưỡi, parent phải là null");
            Assert.IsTrue(fishItem.isGrabbedFromHook, "isGrabbedFromHook phải được đặt thành true");
            Assert.IsTrue(eventFired, "Sự kiện OnFishCollected phải được phát");
            Assert.AreEqual(VRFishingController.FishingState.Idle, rod.currentState, "Cần câu phải reset về Idle sau khi thu thập cá");
        }

        [Test]
        public void Test_FishingStationBoard_ToggleEquipAndUnequip()
        {
            GameObject boardGO = new GameObject("TestBoard");
            boardGO.transform.SetParent(testRoot.transform);
            boardGO.AddComponent<BoxCollider>();
            FishingStationBoard board = boardGO.AddComponent<FishingStationBoard>();
            board.fishingRod = rod;

            Assert.IsFalse(rod.isEquipped);

            // Click 1: Lấy cần câu
            board.ToggleFishingRod();
            Assert.IsTrue(rod.isEquipped, "Bấm bảng lần 1 phải gắn cần câu vào tay người chơi");

            // Click 2: Cất cần câu
            board.ToggleFishingRod();
            Assert.IsFalse(rod.isEquipped, "Bấm bảng lần 2 phải cất cần câu khỏi tay người chơi");
        }

        [Test]
        public void Test_FishingController_EnsureHookMeshTriggerSetup_ConfiguresBobberTrigger()
        {
            // Chuẩn bị phao (hookMesh) vẫn là con của hookWithLine
            hookMesh.SetParent(hookWithLine, false);

            rod.EnsureHookMeshTriggerSetup();

            // 1. Trigger phải nằm TRÊN PHAO (hookMesh), không phải trên đỉnh cần (hookWithLine)
            FishingHookTrigger triggerOnBobber = hookMesh.GetComponent<FishingHookTrigger>();
            Assert.IsNotNull(triggerOnBobber, "Phao (hookMesh) phải có FishingHookTrigger sau khi setup");

            Assert.IsNull(hookWithLine.GetComponent<FishingHookTrigger>(),
                "Không để FishingHookTrigger trên đỉnh cần (hookWithLine) — vị trí câu phải ở phao");

            // 2. Trigger phải được nối tới VRFishingController để gọi StartFishingInWater
            Assert.AreEqual(rod, triggerOnBobber.fishingController, "FishingHookTrigger phải trỏ về rod");

            // 3. Phao phải có SphereCollider isTrigger để kích hoạt OnTriggerEnter với vùng nước
            SphereCollider bobberCollider = hookMesh.GetComponent<SphereCollider>();
            Assert.IsNotNull(bobberCollider, "Phao phải có SphereCollider để chạm nước");
            Assert.IsTrue(bobberCollider.isTrigger, "Collider phao phải ở chế độ isTrigger");
        }

        [Test]
        public void Test_FishingController_PlaceBobberAtLineEnd_MovesWithLineLength()
        {
            // Giả lập phao bị đặt lung tung để kiểm tra việc kéo về đúng vị trí
            hookMesh.SetParent(null);
            hookMesh.position = new Vector3(99f, 99f, 99f);

            float someLength = 2.0f;
            hookWithLine.localScale = new Vector3(1f, someLength, 1f);

            rod.PlaceBobberAtLineEnd();

            // Phao phải được kéo làm con của hookWithLine
            Assert.AreEqual(hookWithLine, hookMesh.parent, "Phao phải nằm dưới hookWithLine");

            // Phao phải đặt ở cuối dây: localPosition.y = -chiều dài dây (thả xuống dưới)
            Assert.AreEqual(-someLength, hookMesh.localPosition.y, 0.001f,
                "Phao phải nằm tại cuối dây câu (y âm theo độ dài dây)");
        }
    }
}
