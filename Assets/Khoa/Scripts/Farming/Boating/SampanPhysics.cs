using System;
using UnityEngine;

namespace Khoa.Farming.Boating
{
    /// <summary>
    /// Hệ thống vật lý thủy động lực học hybrid cho Xuồng Ba Lá Nam Bộ.
    /// Tính toán lực nổi Archimedes 4 điểm, giảm chấn dao động, và khống chế chuyển động để chống say sóng VR.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody))]
    public class SampanPhysics : MonoBehaviour
    {
        [Header("Mặt nước liên kết")]
        public WaterSurfaceVolume waterVolume;
        public float defaultWaterY = 98.9f;

        [Header("Điểm nổi (4 Float Points)")]
        [Tooltip("Các điểm đo độ sâu ngập nước: Mũi trái, Mũi phải, Lái trái, Lái phải")]
        public Transform[] floatPoints;
        public float buoyancyPerPoint = 450f; // Lực nâng tối đa trên mỗi điểm (tổng ~1800N cho xuồng 100kg + tải)
        public float waterDamping = 12f;      // Giảm chấn dao động thẳng đứng
        public float maxDepth = 0.4f;         // Độ sâu ngập nước bão hòa

        [Header("Cản thủy động học")]
        public float forwardDragCoeff = 25f;
        public float reverseDragCoeff = 45f;
        public float lateralDragCoeff = 180f; // Kháng trôi dạt ngang thân thuyền
        public float rotationalDragCoeff = 60f;

        [Header("Thông số giới hạn an toàn VR (VR Comfort Limits)")]
        public float maxRollAngleDeg = 10f;       // Góc lắc ngang tối đa
        public float maxPitchAngleDeg = 10f;      // Góc chúi mũi/lái tối đa
        public float maxForwardSpeed = 3.5f;      // Tốc độ tiến tối đa (m/s)
        public float maxReverseSpeed = 1.2f;      // Tốc độ lùi tối đa (m/s)
        public float maxYawSpeedDeg = 40f;        // Tốc độ xoay tối đa (độ/giây)
        public float maxAcceleration = 1.5f;      // Gia tốc tối đa (m/s2)
        public float uprightRestoringTorque = 80f; // Mô-men hồi phục thăng bằng

        [Header("Trạng thái (Read-Only)")]
        [SerializeField] private bool isFloating = false;
        [SerializeField] private float currentSpeed = 0f;
        [SerializeField] private Vector3 currentVelocity = Vector3.zero;

        public bool IsFloating => isFloating;
        public float CurrentSpeed => currentSpeed;
        public Rigidbody RigidbodyInstance
        {
            get
            {
                if (rb == null) rb = GetComponent<Rigidbody>();
                if (rb == null) rb = gameObject.AddComponent<Rigidbody>();
                return rb;
            }
        }

        private Rigidbody rb;
        private Vector3 previousVelocity = Vector3.zero;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.mass = 100f;
            rb.linearDamping = 0.5f;
            rb.angularDamping = 1.5f;
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

            // Nếu chưa có floatPoints, tự sinh 4 điểm mặc định
            if (floatPoints == null || floatPoints.Length == 0)
            {
                SetupDefaultFloatPoints();
            }

            if (waterVolume == null)
            {
                waterVolume = FindFirstObjectByType<WaterSurfaceVolume>();
            }
        }

        private void OnValidate()
        {
            maxDepth = Mathf.Max(0.05f, maxDepth);
            buoyancyPerPoint = Mathf.Max(0f, buoyancyPerPoint);
            maxForwardSpeed = Mathf.Max(0f, maxForwardSpeed);
            maxReverseSpeed = Mathf.Max(0f, maxReverseSpeed);
            maxYawSpeedDeg = Mathf.Max(0f, maxYawSpeedDeg);
            maxAcceleration = Mathf.Max(0.05f, maxAcceleration);
        }

        private void FixedUpdate()
        {
            ApplyBuoyancy();
            ApplyHydrodynamicDrag();
            ApplyUprightStability();
            ClampMotionForVRComfort();

            currentVelocity = rb.linearVelocity;
            currentSpeed = Vector3.Dot(rb.linearVelocity, transform.forward);
            previousVelocity = rb.linearVelocity;
        }

        private void ApplyBuoyancy()
        {
            int submergedPoints = 0;

            for (int i = 0; i < floatPoints.Length; i++)
            {
                if (floatPoints[i] == null) continue;

                Vector3 pointPos = floatPoints[i].position;
                if (waterVolume != null && !waterVolume.ContainsHorizontalPosition(pointPos)) continue;
                float waterY = (waterVolume != null) ? waterVolume.GetWaterSurfaceY(pointPos) : defaultWaterY;

                if (pointPos.y < waterY)
                {
                    submergedPoints++;
                    float depth = Mathf.Clamp01((waterY - pointPos.y) / maxDepth);
                    
                    // Lực Archimedes hướng lên
                    Vector3 buoyantForce = Vector3.up * (buoyancyPerPoint * depth);

                    // Lực cản giảm chấn vận tốc đứng
                    Vector3 pointVelocity = rb.GetPointVelocity(pointPos);
                    Vector3 dampingForce = Vector3.up * (-pointVelocity.y * waterDamping);

                    rb.AddForceAtPosition(buoyantForce + dampingForce, pointPos, ForceMode.Force);
                }
            }

            isFloating = (submergedPoints > 0);
        }

        private void ApplyHydrodynamicDrag()
        {
            if (!isFloating) return;

            Vector3 localVel = transform.InverseTransformDirection(rb.linearVelocity);

            // Cản tiến / lùi
            float forwardCoeff = (localVel.z >= 0f) ? forwardDragCoeff : reverseDragCoeff;
            float dragZ = -Mathf.Sign(localVel.z) * (localVel.z * localVel.z) * forwardCoeff * 0.5f;

            // Cản trượt ngang (khắc phục trượt không trọng lực)
            float dragX = -localVel.x * lateralDragCoeff;

            Vector3 localDrag = new Vector3(dragX, 0f, dragZ);
            Vector3 worldDrag = transform.TransformDirection(localDrag);

            rb.AddForce(worldDrag, ForceMode.Force);

            // Cản mô-men quay yaw
            rb.AddTorque(-transform.up * (rb.angularVelocity.y * rotationalDragCoeff), ForceMode.Force);
        }

        private void ApplyUprightStability()
        {
            // Tính góc nghiêng roll và pitch
            Vector3 forward = transform.forward;
            Vector3 right = transform.right;
            Vector3 up = transform.up;

            // Góc lệch so với trục thẳng đứng Vector3.up
            float rollAngle = Vector3.SignedAngle(Vector3.up, up, forward);
            float pitchAngle = Vector3.SignedAngle(Vector3.up, up, right);

            Vector3 torque = Vector3.zero;

            if (Mathf.Abs(rollAngle) > maxRollAngleDeg)
            {
                float excess = Mathf.Abs(rollAngle) - maxRollAngleDeg;
                torque -= forward * (Mathf.Sign(rollAngle) * excess * uprightRestoringTorque);
            }

            if (Mathf.Abs(pitchAngle) > maxPitchAngleDeg)
            {
                float excess = Mathf.Abs(pitchAngle) - maxPitchAngleDeg;
                torque -= right * (Mathf.Sign(pitchAngle) * excess * uprightRestoringTorque);
            }

            // Hồi phục hướng đứng tổng thể
            Vector3 uprightNormal = Vector3.Cross(up, Vector3.up);
            torque += uprightNormal * uprightRestoringTorque;

            rb.AddTorque(torque, ForceMode.Force);
        }

        private void ClampMotionForVRComfort()
        {
            if (rb == null) rb = RigidbodyInstance;
            if (rb == null) return;

            float dt = Time.fixedDeltaTime > 0f ? Time.fixedDeltaTime : 0.02f;

            // 1. Giới hạn gia tốc để tránh giật đột ngột
            Vector3 accel = (rb.linearVelocity - previousVelocity) / dt;
            if (accel.magnitude > maxAcceleration)
            {
                rb.linearVelocity = previousVelocity + accel.normalized * (maxAcceleration * dt);
            }

            // 2. Giới hạn tốc độ tiến / lùi
            Vector3 localVel = transform.InverseTransformDirection(rb.linearVelocity);
            if (localVel.z > maxForwardSpeed) localVel.z = maxForwardSpeed;
            if (localVel.z < -maxReverseSpeed) localVel.z = -maxReverseSpeed;
            rb.linearVelocity = transform.TransformDirection(localVel);

            // 3. Giới hạn tốc độ góc xoay yaw
            float maxYawRad = maxYawSpeedDeg * Mathf.Deg2Rad;
            Vector3 angVel = rb.angularVelocity;
            if (Mathf.Abs(angVel.y) > maxYawRad)
            {
                angVel.y = Mathf.Sign(angVel.y) * maxYawRad;
                rb.angularVelocity = angVel;
            }
        }

        /// <summary>
        /// Truyền lực đẩy chèo từ mái chèo vào thân thuyền tại vị trí cọc chèo.
        /// </summary>
        public void AddPropulsionForceAtPosition(Vector3 force, Vector3 worldPosition)
        {
            if (!isFloating) return;

            // Clamp lực tối đa tránh nổ vật lý do VR tracking spike
            float maxForceMagnitude = 350f;
            Vector3 clampedForce = Vector3.ClampMagnitude(force, maxForceMagnitude);

            rb.AddForceAtPosition(clampedForce, worldPosition, ForceMode.Force);
        }

        private void SetupDefaultFloatPoints()
        {
            GameObject fpParent = new GameObject("FloatPoints");
            fpParent.transform.SetParent(transform, false);

            floatPoints = new Transform[4];
            // Bow Left & Right, Stern Left & Right (dựa trên xuồng dài ~3.6m, rộng ~0.9m)
            Vector3[] localOffsets = new Vector3[]
            {
                new Vector3(-0.35f, -0.15f, 1.4f),  // Mũi trái
                new Vector3(0.35f, -0.15f, 1.4f),   // Mũi phải
                new Vector3(-0.35f, -0.15f, -1.4f), // Lái trái
                new Vector3(0.35f, -0.15f, -1.4f)   // Lái phải
            };

            for (int i = 0; i < 4; i++)
            {
                GameObject pt = new GameObject($"FloatPoint_{i + 1}");
                pt.transform.SetParent(fpParent.transform, false);
                pt.transform.localPosition = localOffsets[i];
                floatPoints[i] = pt.transform;
            }
        }
    }
}
