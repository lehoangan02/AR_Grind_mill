using UnityEngine;

namespace Khoa.Farming.Boating
{
    /// <summary>
    /// Vùng mặt nước quy định cao độ mực nước và dòng chảy cho xuồng ba lá.
    /// Gắn trên BoxCollider (isTrigger = true) phủ dọc theo sông hoặc kênh rạch.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider))]
    public class WaterSurfaceVolume : MonoBehaviour
    {
        [Header("Thông số mặt nước")]
        public float waterSurfaceY = 98.9f;
        public float waterDensity = 1000f; // kg/m3
        public Vector3 currentFlowVelocity = Vector3.zero;

        private Collider volumeCollider;

        private void Awake()
        {
            volumeCollider = GetComponent<Collider>();
            if (volumeCollider != null)
            {
                volumeCollider.isTrigger = true;
                // Nếu collider là Box, có thể cập nhật waterSurfaceY theo đỉnh trên của box
                if (volumeCollider is BoxCollider box)
                {
                    waterSurfaceY = transform.position.y + box.center.y + (box.size.y * 0.5f);
                }
            }
        }

        /// <summary>
        /// Lấy cao độ mặt nước tại toạ độ thế giới chỉ định.
        /// </summary>
        public float GetWaterSurfaceY(Vector3 worldPos)
        {
            return waterSurfaceY;
        }

        /// <summary>
        /// Kiểm tra một điểm có chìm dưới mặt nước hay không và trả về độ sâu ngập nước.
        /// </summary>
        public bool IsPointSubmerged(Vector3 point, out float depth)
        {
            float surfaceY = GetWaterSurfaceY(point);
            if (point.y < surfaceY)
            {
                depth = surfaceY - point.y;
                return true;
            }

            depth = 0f;
            return false;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(0f, 0.6f, 1f, 0.35f);
            Vector3 center = transform.position;
            Vector3 size = new Vector3(30f, 0.1f, 50f);
            if (volumeCollider is BoxCollider box)
            {
                center = transform.TransformPoint(box.center);
                size = Vector3.Scale(box.size, transform.lossyScale);
                center.y = waterSurfaceY;
                size.y = 0.05f;
            }
            Gizmos.DrawCube(center, size);
        }
    }
}
