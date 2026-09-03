using NUnit.Framework;
using UnityEngine;
using Khoa.Farming.Boating;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement;

namespace Khoa.Farming.Tests
{
    [TestFixture]
    public class SampanPhysicsAndRowingTests
    {
        private GameObject testRoot;

        [SetUp]
        public void SetUp()
        {
            testRoot = new GameObject("Boating_TestRoot");
        }

        [TearDown]
        public void TearDown()
        {
            if (testRoot != null)
            {
                Object.DestroyImmediate(testRoot);
            }
        }

        [Test]
        public void Test_SampanOar_BladeOutOfWater_ProducesZeroThrust()
        {
            GameObject sampanGO = new GameObject("Sampan");
            sampanGO.transform.SetParent(testRoot.transform);
            sampanGO.transform.position = new Vector3(0f, 100f, 0f);
            SampanPhysics physics = sampanGO.AddComponent<SampanPhysics>();
            physics.defaultWaterY = 98.9f;

            GameObject oarGO = new GameObject("Oar");
            oarGO.transform.SetParent(sampanGO.transform);
            oarGO.transform.position = new Vector3(0.5f, 100.5f, 0f);
            oarGO.AddComponent<Rigidbody>();
            oarGO.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            SampanOar oar = oarGO.AddComponent<SampanOar>();
            oar.sampan = physics;

            GameObject bladeTip = new GameObject("BladeTip");
            bladeTip.transform.SetParent(oarGO.transform);
            bladeTip.transform.position = new Vector3(0.5f, 99.5f, 0f); // Cao hơn 98.9f -> Không ngập nước
            oar.bladeTip = bladeTip.transform;

            // Quét mái chèo về sau khi ở trên cạn/trên không
            Vector3 backwardStroke = -sampanGO.transform.forward * 2.0f;
            oar.ComputeAndApplyHydrodynamicThrust(backwardStroke);

            Assert.AreEqual(0f, oar.LastStrokeForce);
        }

        [Test]
        public void Test_SampanOar_BackwardStrokeInWater_ProducesForwardThrust()
        {
            GameObject sampanGO = new GameObject("Sampan");
            sampanGO.transform.SetParent(testRoot.transform);
            sampanGO.transform.position = new Vector3(0f, 98.8f, 0f);
            SampanPhysics physics = sampanGO.AddComponent<SampanPhysics>();
            physics.defaultWaterY = 98.9f;

            GameObject oarGO = new GameObject("Oar");
            oarGO.transform.SetParent(sampanGO.transform);
            oarGO.AddComponent<Rigidbody>();
            oarGO.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            SampanOar oar = oarGO.AddComponent<SampanOar>();
            oar.sampan = physics;

            GameObject bladeTip = new GameObject("BladeTip");
            bladeTip.transform.SetParent(oarGO.transform);
            bladeTip.transform.position = new Vector3(0.5f, 98.5f, 0f); // Thấp hơn 98.9f -> Chìm trong nước
            oar.bladeTip = bladeTip.transform;

            // Quét mái chèo về sau trong nước
            Vector3 backwardStroke = -sampanGO.transform.forward * 2.5f;
            oar.SimulateStroke(backwardStroke);

            Assert.Greater(oar.LastStrokeForce, 0f, "Quét mái chèo về sau trong nước phải sinh lực đẩy tiến!");
        }

        [Test]
        public void Test_SampanOar_RecoveryStroke_ProducesZeroThrust()
        {
            GameObject sampanGO = new GameObject("Sampan");
            sampanGO.transform.SetParent(testRoot.transform);
            sampanGO.transform.position = new Vector3(0f, 98.8f, 0f);
            SampanPhysics physics = sampanGO.AddComponent<SampanPhysics>();
            physics.defaultWaterY = 98.9f;

            GameObject oarGO = new GameObject("Oar");
            oarGO.transform.SetParent(sampanGO.transform);
            oarGO.AddComponent<Rigidbody>();
            oarGO.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            SampanOar oar = oarGO.AddComponent<SampanOar>();
            oar.sampan = physics;

            GameObject bladeTip = new GameObject("BladeTip");
            bladeTip.transform.SetParent(oarGO.transform);
            bladeTip.transform.position = new Vector3(0.5f, 98.5f, 0f);
            oar.bladeTip = bladeTip.transform;

            // Kéo mái chèo về phía trước (recovery stroke)
            Vector3 forwardStroke = sampanGO.transform.forward * 2.0f;
            oar.SimulateStroke(forwardStroke);

            Assert.AreEqual(0f, oar.LastStrokeForce, "Recovery stroke không được sinh lực đẩy tiến giả!");
        }

        [Test]
        public void Test_SampanSeat_MountAndDismount_LocomotionToggled()
        {
            GameObject sampanGO = new GameObject("Sampan");
            sampanGO.transform.SetParent(testRoot.transform);
            SampanSeat seat = sampanGO.AddComponent<SampanSeat>();
            seat.seatAnchor = sampanGO.transform;

            // Tạo giả lập người chơi có ContinuousMoveProvider
            GameObject playerGO = new GameObject("Fake_Player_XROrigin");
            playerGO.transform.SetParent(testRoot.transform);
            ContinuousMoveProvider moveProvider = playerGO.AddComponent<ContinuousMoveProvider>();
            moveProvider.enabled = true;

            Assert.IsFalse(seat.IsSeated);
            Assert.IsTrue(moveProvider.enabled);

            // 1. Lên xuồng (Mount)
            bool mountSuccess = seat.Mount(playerGO);
            Assert.IsTrue(mountSuccess);
            Assert.IsTrue(seat.IsSeated);
            Assert.IsFalse(moveProvider.enabled, "Khi ngồi trên xuồng, ContinuousMoveProvider phải bị tắt để chống say!");
            Assert.AreEqual(sampanGO.transform, playerGO.transform.parent);

            // 2. Xuống xuồng (Dismount)
            bool dismountSuccess = seat.Dismount();
            Assert.IsTrue(dismountSuccess);
            Assert.IsFalse(seat.IsSeated);
            Assert.IsTrue(moveProvider.enabled, "Khi rời xuồng, ContinuousMoveProvider phải được phục hồi!");
            Assert.AreNotEqual(sampanGO.transform, playerGO.transform.parent);
        }

        [Test]
        public void Test_SampanPhysics_ComfortLimits_ClampsVelocity()
        {
            GameObject sampanGO = new GameObject("Sampan");
            sampanGO.transform.SetParent(testRoot.transform);
            SampanPhysics physics = sampanGO.AddComponent<SampanPhysics>();

            Rigidbody rb = physics.RigidbodyInstance;
            rb.isKinematic = false;

            // Đặt vận tốc vượt ngưỡng tiến 3.5 m/s
            rb.linearVelocity = sampanGO.transform.forward * 8.0f;

            // Gọi ClampMotionForVRComfort thông qua Reflection
            System.Reflection.MethodInfo clampMethod = typeof(SampanPhysics).GetMethod("ClampMotionForVRComfort", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            Assert.IsNotNull(clampMethod);
            clampMethod.Invoke(physics, null);

            float speed = Vector3.Dot(rb.linearVelocity, sampanGO.transform.forward);
            Assert.LessOrEqual(speed, physics.maxForwardSpeed + 0.01f, "Tốc độ tiến phải được khống chế dưới 3.5 m/s");
        }
    }
}
