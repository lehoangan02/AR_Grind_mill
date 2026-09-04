using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace Khoa.Farming.Boating
{
    public enum OarSide
    {
        Left,
        Right
    }

    /// <summary>
    /// Mái chèo xuồng ba lá gắn trên cọc chèo (oarlock).
    /// Người chơi dùng Grip để cầm. Khi lưỡi chèo nhúng nước và quét về phía sau,
    /// tạo lực đẩy tiến và mô-men xoay yaw tương ứng lên thân xuồng.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(XRGrabInteractable))]
    [RequireComponent(typeof(Rigidbody))]
    public class SampanOar : MonoBehaviour
    {
        [Header("Liên kết thuyền & cọc chèo")]
        public SampanPhysics sampan;
        public Transform oarlockPivot;
        public OarSide side = OarSide.Left;

        [Header("Bộ phận lưỡi chèo (Blade)")]
        public Transform bladeTip;
        public Collider bladeCollider;
        public float bladeArea = 0.08f;       // Diện tích lưỡi chèo m2
        public float dragCoefficient = 1.2f;  // Hệ số cản nước
        public float thrustMultiplier = 180f; // Tỉ lệ chuyển đổi cản nước thành lực đẩy tiến

        [Header("Phản hồi xúc giác & FX")]
        public SampanAudioAndVFX audioAndVFX;
        public float maxHapticForce = 200f;

        [Header("Trạng thái (Read-Only)")]
        [SerializeField] private bool isHeld = false;
        [SerializeField] private bool isBladeInWater = false;
        [SerializeField] private Vector3 lastBladePosition = Vector3.zero;
        [SerializeField] private Vector3 bladeVelocity = Vector3.zero;
        [SerializeField] private float lastStrokeForce = 0f;

        public bool IsHeld => isHeld;
        public bool IsBladeInWater => isBladeInWater;
        public float LastStrokeForce => lastStrokeForce;

        private XRGrabInteractable grab;
        private Rigidbody rb;
        private IXRSelectInteractor holdingInteractor;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.mass = 3.5f;
            rb.interpolation = RigidbodyInterpolation.Interpolate;

            grab = GetComponent<XRGrabInteractable>();
            if (grab != null)
            {
                grab.selectEntered.AddListener(OnGrabEntered);
                grab.selectExited.AddListener(OnGrabExited);
            }

            if (bladeTip == null)
            {
                bladeTip = transform.Find("BladeTip") ?? transform;
            }

            lastBladePosition = bladeTip.position;
        }

        private void OnDestroy()
        {
            if (grab != null)
            {
                grab.selectEntered.RemoveListener(OnGrabEntered);
                grab.selectExited.RemoveListener(OnGrabExited);
            }
        }

        private void Start()
        {
            if (sampan == null)
            {
                sampan = GetComponentInParent<SampanPhysics>();
            }

            if (audioAndVFX == null && sampan != null)
            {
                audioAndVFX = sampan.GetComponent<SampanAudioAndVFX>();
            }
        }

        private void FixedUpdate()
        {
            Vector3 currentBladePos = bladeTip.position;
            bladeVelocity = (currentBladePos - lastBladePosition) / Time.fixedDeltaTime;
            lastBladePosition = currentBladePos;

            CheckWaterImmersion();

            if (isBladeInWater && sampan != null)
            {
                ComputeAndApplyHydrodynamicThrust(bladeVelocity);
            }
            else
            {
                lastStrokeForce = 0f;
            }
        }

        private void CheckWaterImmersion()
        {
            bool previouslyInWater = isBladeInWater;

            if (sampan != null && sampan.waterVolume != null)
            {
                isBladeInWater = sampan.waterVolume.IsPointSubmerged(bladeTip.position, out _);
            }
            else
            {
                float waterY = (sampan != null) ? sampan.defaultWaterY : 98.9f;
                isBladeInWater = (bladeTip.position.y < waterY);
            }

            // Sự kiện nhúng / rút lưỡi chèo khỏi nước
            if (!previouslyInWater && isBladeInWater)
            {
                if (audioAndVFX != null)
                {
                    audioAndVFX.PlayBladeSplash(bladeTip.position, bladeVelocity.magnitude);
                }
            }
        }

        /// <summary>
        /// Tính toán lực đẩy khi quét mái chèo trong nước.
        /// </summary>
        public void ComputeAndApplyHydrodynamicThrust(Vector3 currentBladeVel)
        {
            CheckWaterImmersion();
            if (!isBladeInWater || sampan == null)
            {
                lastStrokeForce = 0f;
                return;
            }

            // Vận tốc của lưỡi chèo tương đối so với thân xuồng
            Vector3 relativeVel = currentBladeVel - (sampan.RigidbodyInstance != null ? sampan.RigidbodyInstance.linearVelocity : Vector3.zero);

            // Chuyển relativeVel sang hệ tọa độ cục bộ của xuồng
            Vector3 boatLocalRelativeVel = sampan.transform.InverseTransformDirection(relativeVel);

            // Chèo về phía sau: boatLocalRelativeVel.z < 0
            // Chỉ khi quét mái chèo về sau trong nước thì mới sinh lực đẩy tiến (z > 0)
            if (boatLocalRelativeVel.z < -0.05f)
            {
                float backwardSpeed = -boatLocalRelativeVel.z;

                // Lực cản tỉ lệ bậc hai với vận tốc: F = 0.5 * rho * Cd * A * v^2
                float thrustMagnitude = 0.5f * 1000f * dragCoefficient * bladeArea * (backwardSpeed * backwardSpeed);
                thrustMagnitude = Mathf.Clamp(thrustMagnitude * thrustMultiplier * 0.01f, 0f, 300f);

                lastStrokeForce = thrustMagnitude;

                // Hướng lực đẩy: dọc theo hướng mũi xuồng (transform.forward)
                Vector3 thrustForce = sampan.transform.forward * thrustMagnitude;

                // Điểm đặt lực: tại cọc chèo (oarlockPivot) để tự nhiên sinh mô-men xoay yaw
                Vector3 forcePoint = (oarlockPivot != null) ? oarlockPivot.position : transform.position;

                sampan.AddPropulsionForceAtPosition(thrustForce, forcePoint);

                // Phản hồi xúc giác (Haptic Feedback) vào tay cầm
                TriggerHaptic(thrustMagnitude);

                if (audioAndVFX != null)
                {
                    audioAndVFX.OnPaddleStroke(thrustMagnitude);
                }
            }
            else
            {
                // Recovery stroke (kéo mái chèo về trước trong nước hoặc vuốt nước) không sinh lực đẩy giả
                lastStrokeForce = 0f;
            }
        }

        /// <summary>
        /// Dành cho unit test hoặc dev input mô phỏng cú chèo.
        /// </summary>
        public void SimulateStroke(Vector3 simulatedBladeVel)
        {
            isBladeInWater = true;
            ComputeAndApplyHydrodynamicThrust(simulatedBladeVel);
        }

        private void OnGrabEntered(SelectEnterEventArgs args)
        {
            isHeld = true;
            holdingInteractor = args.interactorObject;
        }

        private void OnGrabExited(SelectExitEventArgs args)
        {
            isHeld = false;
            holdingInteractor = null;
        }

        private void TriggerHaptic(float force)
        {
            if (holdingInteractor is XRBaseInputInteractor inputInteractor)
            {
                float normalized = Mathf.Clamp01(force / maxHapticForce);
                inputInteractor.SendHapticImpulse(normalized * 0.7f, 0.1f);
            }
        }
    }
}
