using UnityEngine;

namespace Khoa.Farming
{
    [CreateAssetMenu(fileName = "New Crop Data", menuName = "Khoa/Farming/Crop Data")]
    public class CropData : ScriptableObject
    {
        [Header("Basic Info")]
        public string plantName = "Lúa";
        
        [Header("Growth System")]
        [Tooltip("Thời gian để lúa chín (tính bằng giây)")]
        [Min(0.1f)]
        public float timeToHarvest = 180f; // 3 phút như user yêu cầu
        
        [Tooltip("Tốc độ sinh trưởng nhân thêm khi có phân bón")]
        [Min(1f)]
        public float fertilizerGrowthMultiplier = 1.5f;

        [Header("Water System")]
        [Tooltip("Lượng nước tối đa có thể giữ")]
        [Min(1f)]
        public float maxWater = 100f;
        
        [Tooltip("Lượng nước mất đi mỗi giây")]
        [Min(0f)]
        public float waterDepletionRate = 1f;
        
        [Tooltip("Mức nước tối thiểu để cây tiếp tục lớn (nếu dưới mức này cây sẽ dừng lớn)")]
        [Min(0f)]
        public float minWaterToGrow = 20f;
        
        [Tooltip("Thời gian cây có thể sống sót sau khi cạn sạch nước (0 nước)")]
        [Min(0f)]
        public float timeToDieWithoutWater = 30f;
    }
}
