using UnityEngine;

public class FishSimulation : MonoBehaviour
{
    [Header("Capsule Roam Area")]
    public float capsuleLength = 10f;
    public float capsuleRadius = 3f;
    public Vector3 capsuleAxis = Vector3.forward;

    [Header("Movement Settings")]
    public float swimSpeed = 1.5f;
    public float rotationSpeed = 2.5f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float stuckTimer = 0f;

    // Lưu độ lệch góc giữa hướng trục Roam và hướng mặt con cá bạn setup trong Editor
    private Quaternion modelOffset;

    void Start()
    {
        startPosition = transform.position;

        // 1. Lấy hướng trục Roam chuẩn
        Vector3 baseDir = capsuleAxis != Vector3.zero ? capsuleAxis.normalized : Vector3.forward;
        Quaternion baseRotation = Quaternion.LookRotation(baseDir, Vector3.up);

        // 2. Đo Offset giữa góc bạn xếp trong Editor và hướng trục Roam
        modelOffset = transform.rotation * Quaternion.Inverse(baseRotation);

        PickNewTarget();
    }

    void Update()
    {
        CheckTargetDistance();
        UpdateMovement();
    }

    void CheckTargetDistance()
    {
        stuckTimer -= Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPosition) < 0.5f || stuckTimer <= 0)
        {
            PickNewTarget();
        }
    }

    void PickNewTarget()
    {
        targetPosition = GetRandomPointInCapsule();
        stuckTimer = 10f; 
    }

    Vector3 GetRandomPointInCapsule()
    {
        Vector3 axis = capsuleAxis.normalized;
        Vector3 p1 = startPosition - axis * (capsuleLength / 2f);
        Vector3 p2 = startPosition + axis * (capsuleLength / 2f);

        Vector3 randomPointOnLine = Vector3.Lerp(p1, p2, Random.value);
        Vector3 randomOffset = Random.insideUnitSphere * capsuleRadius;
        
        return randomPointOnLine + randomOffset;
    }

    void UpdateMovement()
    {
        Vector3 dirToTarget = (targetPosition - transform.position).normalized;

        if (dirToTarget != Vector3.zero)
        {
            // 1. Tính góc nhìn chuẩn về phía điểm đến
            Quaternion targetLook = Quaternion.LookRotation(dirToTarget, Vector3.up);

            // 2. Bù thêm Offset góc Editor vào để đầu cá chĩa đúng hướng
            Quaternion targetRot = targetLook * modelOffset;

            // 3. Xoay mượt mà
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * rotationSpeed);
        }

        // 4. Tính hướng bơi thực tế của đầu cá (khử Offset) và tiến về phía trước
        Vector3 visualForward = transform.rotation * Quaternion.Inverse(modelOffset) * Vector3.forward;
        transform.position += visualForward * swimSpeed * Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Vector3 center = Application.isPlaying ? startPosition : transform.position;
        Vector3 axis = capsuleAxis.normalized;
        
        Vector3 p1 = center - axis * (capsuleLength / 2f);
        Vector3 p2 = center + axis * (capsuleLength / 2f);

        Gizmos.DrawWireSphere(p1, capsuleRadius);
        Gizmos.DrawWireSphere(p2, capsuleRadius);
        Gizmos.DrawLine(p1, p2);
        
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(targetPosition, 0.15f);
            Gizmos.DrawLine(transform.position, targetPosition);
        }
    }
}