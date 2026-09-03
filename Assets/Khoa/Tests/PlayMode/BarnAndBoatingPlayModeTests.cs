using System;
using System.Collections;
using System.Text.RegularExpressions;
using Khoa.Farming;
using Khoa.Farming.Boating;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement;
using Unity.XR.CoreUtils;
using Object = UnityEngine.Object;

namespace Khoa.Farming.PlayModeTests
{
    public class BarnAndBoatingPlayModeTests
    {
        private GameObject testRoot;

        [SetUp]
        public void SetUp()
        {
            testRoot = new GameObject("PlayMode_TestRoot");
        }

        [TearDown]
        public void TearDown()
        {
            if (testRoot != null)
            {
                Object.Destroy(testRoot);
            }
        }

        [UnityTest]
        public IEnumerator PlayMode_BarnAndCompost_PhysicalLifecycle_ScoopDepositFertilize()
        {
            // 1. Khởi tạo chuồng và đống ủ
            GameObject sourceGO = new GameObject("BarnSource");
            sourceGO.transform.SetParent(testRoot.transform);
            BarnManureSource source = sourceGO.AddComponent<BarnManureSource>();
            source.animalType = BarnAnimalType.Buffalo;
            source.maxUncollected = 2;
            source.respawnCooldown = 60f;

            GameObject compostGO = new GameObject("CompostPile");
            compostGO.transform.SetParent(testRoot.transform);
            compostGO.transform.position = new Vector3(2f, 0f, 0f);
            BoxCollider compostCol = compostGO.AddComponent<BoxCollider>();
            compostCol.isTrigger = true;
            compostCol.size = new Vector3(2f, 2f, 2f);
            CompostPile compost = compostGO.AddComponent<CompostPile>();
            compost.requiredPortions = 3;
            compost.compostDuration = 0.5f; // Rút ngắn cho test

            GameObject shovelGO = new GameObject("Shovel");
            shovelGO.transform.SetParent(testRoot.transform);
            shovelGO.AddComponent<Rigidbody>();
            shovelGO.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            BoxCollider shovelBlade = shovelGO.AddComponent<BoxCollider>();
            shovelBlade.isTrigger = true;
            ManureShovel shovel = shovelGO.AddComponent<ManureShovel>();
            shovel.bladeTriggerCollider = shovelBlade;

            yield return null; // Chờ Awake

            // 2. Thu hoạch và đổ 3 phần phân tươi
            for (int i = 0; i < 3; i++)
            {
                ManureItem manure = source.SpawnManure();
                Assert.IsNotNull(manure, $"Đống phân thứ {i+1} phải được sinh ra!");

                // Xúc phân
                bool scooped = shovel.ScoopFrom(manure);
                Assert.IsTrue(scooped, $"Lần xúc thứ {i+1} phải thành công!");
                Assert.IsTrue(shovel.IsFull);

                // Trút phân vào đống ủ
                bool deposited = shovel.DepositTo(compost);
                Assert.IsTrue(deposited, $"Lần trút thứ {i+1} phải thành công!");
                Assert.IsFalse(shovel.IsFull);

                yield return null;
            }

            // Đống ủ bắt đầu ủ sinh học
            Assert.AreEqual(CompostState.Composting, compost.CurrentState);

            // Chờ quá trình ủ hoàn tất
            yield return new WaitForSeconds(0.6f);

            Assert.AreEqual(CompostState.Ready, compost.CurrentState);

            // 3. Lấy phân hoai mục bón cho CropPlot
            MatureFertilizerItem[] fertilizers = Object.FindObjectsByType<MatureFertilizerItem>(FindObjectsSortMode.None);
            Assert.AreEqual(3, fertilizers.Length, "Đống ủ chín phải sinh đúng 3 bao phân hoai mục!");

            GameObject plotGO = new GameObject("CropPlot");
            plotGO.transform.SetParent(testRoot.transform);
            plotGO.transform.position = new Vector3(5f, 0f, 0f);
            CropPlot plot = plotGO.AddComponent<CropPlot>();
            plot.PlowPlot(); // Chuyển sang Tilled
            Assert.AreEqual(PlotState.Tilled, plot.currentState);

            // Bón phân vào ruộng đã cày
            bool applied = fertilizers[0].TryApplyTo(plot);
            Assert.IsTrue(applied, "Bón lót phân hoai cho ô ruộng đã cày phải thành công!");

            // Thử bón lần 2 vào cùng ô ruộng -> Phải từ chối (không cộng dồn)
            bool appliedAgain = fertilizers[1].TryApplyTo(plot);
            Assert.IsFalse(appliedAgain, "Không được phép bón lót cộng dồn lên ô ruộng đã có phân!");

            yield return null;
        }

        [UnityTest]
        public IEnumerator PlayMode_Sampan_PhysicsBuoyancy_FloatsOnWaterSurface()
        {
            float waterY = 98.9f;

            // 1. Tạo mặt nước
            GameObject waterGO = new GameObject("WaterSurface");
            waterGO.transform.SetParent(testRoot.transform);
            waterGO.transform.position = new Vector3(0f, waterY, 0f);
            BoxCollider waterBox = waterGO.AddComponent<BoxCollider>();
            waterBox.isTrigger = true;
            waterBox.size = new Vector3(50f, 10f, 50f);
            WaterSurfaceVolume waterVolume = waterGO.AddComponent<WaterSurfaceVolume>();
            waterVolume.waterSurfaceY = waterY;

            // 2. Tạo Xuồng Ba Lá hơi chìm dưới nước một chút (y = 98.4f)
            GameObject sampanGO = new GameObject("Sampan");
            sampanGO.transform.SetParent(testRoot.transform);
            sampanGO.transform.position = new Vector3(0f, 98.4f, 0f);
            SampanPhysics physics = sampanGO.AddComponent<SampanPhysics>();
            physics.waterVolume = waterVolume;
            physics.defaultWaterY = waterY;

            Rigidbody rb = physics.RigidbodyInstance;
            rb.isKinematic = false;

            // Chờ 30 physics ticks để lực nổi Archimedes đẩy xuồng lên cân bằng
            for (int i = 0; i < 30; i++)
            {
                yield return new WaitForFixedUpdate();
            }

            Assert.IsTrue(physics.IsFloating, "Xuồng phải ở trạng thái đang nổi trên nước!");
            Assert.Greater(sampanGO.transform.position.y, 98.4f, "Lực đẩy Archimedes phải đẩy xuồng nổi lên trên so với vị trí chìm ban đầu!");
            Assert.Less(sampanGO.transform.position.y, 100f, "Xuồng không được bay lên trời!");
        }

        [UnityTest]
        public IEnumerator PlayMode_Sampan_RowingThrust_PropelsSampanForward()
        {
            float waterY = 98.9f;

            GameObject waterGO = new GameObject("WaterSurface");
            waterGO.transform.SetParent(testRoot.transform);
            waterGO.transform.position = new Vector3(0f, waterY, 0f);
            BoxCollider waterBox = waterGO.AddComponent<BoxCollider>();
            waterBox.isTrigger = true;
            waterBox.size = new Vector3(50f, 10f, 50f);
            WaterSurfaceVolume waterVolume = waterGO.AddComponent<WaterSurfaceVolume>();
            waterVolume.waterSurfaceY = waterY;

            GameObject sampanGO = new GameObject("Sampan");
            sampanGO.transform.SetParent(testRoot.transform);
            sampanGO.transform.position = new Vector3(0f, 98.9f, 0f);
            SampanPhysics physics = sampanGO.AddComponent<SampanPhysics>();
            physics.waterVolume = waterVolume;
            physics.defaultWaterY = waterY;

            Rigidbody rb = physics.RigidbodyInstance;
            rb.isKinematic = false;

            GameObject oarGO = new GameObject("Oar");
            oarGO.transform.SetParent(sampanGO.transform);
            oarGO.transform.position = new Vector3(0.5f, 99.0f, 0f);
            oarGO.AddComponent<Rigidbody>();
            oarGO.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            SampanOar oar = oarGO.AddComponent<SampanOar>();
            oar.sampan = physics;

            GameObject bladeTip = new GameObject("BladeTip");
            bladeTip.transform.SetParent(oarGO.transform);
            bladeTip.transform.position = new Vector3(0.5f, 98.2f, 0f); // Dưới mặt nước 98.9f
            oar.bladeTip = bladeTip.transform;

            yield return new WaitForFixedUpdate();

            // Thực hiện động tác quét mái chèo về sau trong nước
            Vector3 backwardVelocity = -sampanGO.transform.forward * 2.5f;
            oar.ComputeAndApplyHydrodynamicThrust(backwardVelocity);

            Assert.Greater(oar.LastStrokeForce, 0f, "Lực đẩy chèo tiến phải lớn hơn 0!");

            // Chờ 5 fixed updates để lực đẩy tác động vào Rigidbody
            for (int i = 0; i < 5; i++)
            {
                yield return new WaitForFixedUpdate();
            }

            float forwardSpeed = Vector3.Dot(rb.linearVelocity, sampanGO.transform.forward);
            Assert.Greater(forwardSpeed, 0.01f, "Xuồng phải tiến về phía trước theo hướng chèo!");
        }

        [UnityTest]
        public IEnumerator PlayMode_SampanSeat_MountDismount_AnchorsAndRestoresLocomotion()
        {
            LogAssert.Expect(LogType.Warning, new Regex(".*Camera.*"));
            LogAssert.Expect(LogType.Warning, new Regex(".*Camera.*"));
            LogAssert.Expect(LogType.Error, new Regex("Locomotion Provider requires.*"));
            LogAssert.Expect(LogType.Exception, new Regex(".*NullReferenceException.*"));

            GameObject playerGO = new GameObject("VR_Player_Rig");
            playerGO.transform.SetParent(testRoot.transform);
            playerGO.transform.position = new Vector3(-13.5f, 99.2f, -19.5f);
            playerGO.AddComponent<XROrigin>();
            ContinuousMoveProvider moveProvider = playerGO.AddComponent<ContinuousMoveProvider>();
            moveProvider.enabled = true;

            GameObject sampanGO = new GameObject("Sampan");
            sampanGO.transform.SetParent(testRoot.transform);
            sampanGO.transform.position = new Vector3(-13.5f, 98.9f, -19.5f);

            GameObject seatGO = new GameObject("SampanSeat");
            seatGO.transform.SetParent(sampanGO.transform);
            seatGO.transform.position = sampanGO.transform.position + new Vector3(0f, 0.2f, 0f);
            SampanSeat seat = seatGO.AddComponent<SampanSeat>();

            GameObject anchorGO = new GameObject("SeatAnchor");
            anchorGO.transform.SetParent(seatGO.transform);
            anchorGO.transform.localPosition = Vector3.zero;
            seat.seatAnchor = anchorGO.transform;

            yield return null;

            // 1. Lên ngồi xuồng
            seat.Mount(playerGO);
            Assert.IsTrue(seat.IsSeated, "Người chơi phải đang ở trạng thái ngồi trên xuồng!");
            Assert.IsFalse(moveProvider.enabled, "ContinuousMoveProvider phải bị vô hiệu hóa khi ngồi trên xuồng!");
            Assert.AreEqual(anchorGO.transform, playerGO.transform.parent, "Người chơi phải được neo vào seatAnchor của xuồng!");

            // 2. Rời xuồng
            seat.Dismount();
            Assert.IsFalse(seat.IsSeated, "Người chơi phải không còn ngồi trên xuồng!");
            Assert.IsTrue(moveProvider.enabled, "ContinuousMoveProvider phải được khôi phục khi rời xuồng!");
            Assert.AreNotEqual(anchorGO.transform, playerGO.transform.parent, "Người chơi không còn bị neo vào xuồng!");
            moveProvider.enabled = false; // Tắt mock để tránh tick Update không có input action trong test runner

            yield return null;
        }
    }
}
