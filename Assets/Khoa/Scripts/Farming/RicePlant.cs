using UnityEngine;

namespace Khoa.Farming
{
    public enum CropState
    {
        Seedling, // Mạ
        Growing,  // Đang phát triển
        Maturing, // Bắt đầu chín
        ReadyToHarvest, // Chín vàng
        Dead      // Chết héo
    }

    public class RicePlant : MonoBehaviour
    {
        [Header("Configuration")]
        public CropData cropData;
        
        [Header("Runtime State")]
        public CropState currentState = CropState.Seedling;
        public float currentWater;
        public bool hasFertilizer = false;
        
        [Range(0f, 100f)]
        public float growthProgress = 0f;
        
        private float dryTimer = 0f;

        [Header("Visual Feedback")]
        public MeshRenderer cropRenderer; // Tạm thời dùng màu để phân biệt state
        public Color colorSeedling = Color.green;
        public Color colorGrowing = new Color(0.2f, 0.8f, 0.2f);
        public Color colorMaturing = new Color(0.8f, 0.8f, 0.2f);
        public Color colorReady = Color.yellow;
        public Color colorDead = Color.gray;
        
        [Header("Organic Growth")]
        [Tooltip("Kích thước tối đa của cây lúa khi chín")]
        public Vector3 maxScale = new Vector3(0.5f, 1f, 0.5f);
        public Vector3 minScale = new Vector3(0.1f, 0.2f, 0.1f);

        void Start()
        {
            if (cropData == null)
            {
                Debug.LogError("RicePlant: CropData is missing!");
                enabled = false;
                return;
            }

            currentWater = cropData.maxWater; // Khởi tạo nước đầy
            UpdateVisuals();
            UpdateScale();
        }

        void Update()
        {
            if (currentState == CropState.ReadyToHarvest || currentState == CropState.Dead)
                return; // Không xử lý nữa nếu đã chín hoặc đã chết

            HandleWaterLogic();
            HandleGrowthLogic();
        }

        private void HandleWaterLogic()
        {
            // Trừ nước theo thời gian
            currentWater -= cropData.waterDepletionRate * Time.deltaTime;
            currentWater = Mathf.Clamp(currentWater, 0f, cropData.maxWater);

            if (currentWater <= 0)
            {
                // Bắt đầu chết khát
                dryTimer += Time.deltaTime;
                if (dryTimer >= cropData.timeToDieWithoutWater)
                {
                    Die();
                }
            }
            else
            {
                // Có nước thì reset timer chết khát
                dryTimer = 0f;
            }
        }

        private void HandleGrowthLogic()
        {
            // Cây chỉ lớn khi lượng nước đủ mức tối thiểu
            if (currentWater >= cropData.minWaterToGrow)
            {
                // Tính % lớn mỗi giây
                float percentPerSecond = (100f / cropData.timeToHarvest);
                
                // Áp dụng bón phân
                float growthMultiplier = hasFertilizer ? cropData.fertilizerGrowthMultiplier : 1f;
                
                growthProgress += percentPerSecond * growthMultiplier * Time.deltaTime;
                growthProgress = Mathf.Clamp(growthProgress, 0f, 100f);

                UpdateStateBasedOnProgress();
                UpdateScale();
            }
        }

        private void UpdateScale()
        {
            if (currentState == CropState.Dead) return;
            // Thay đổi kích thước từ từ (Lerp) dựa trên % tiến độ
            float t = growthProgress / 100f;
            transform.localScale = Vector3.Lerp(minScale, maxScale, t);
        }

        private void UpdateStateBasedOnProgress()
        {
            CropState newState = currentState;

            if (growthProgress >= 100f)
                newState = CropState.ReadyToHarvest;
            else if (growthProgress >= 66f)
                newState = CropState.Maturing;
            else if (growthProgress >= 33f)
                newState = CropState.Growing;
            else
                newState = CropState.Seedling;

            if (newState != currentState)
            {
                currentState = newState;
                UpdateVisuals();
            }
        }

        private void Die()
        {
            currentState = CropState.Dead;
            UpdateVisuals();
            Debug.Log("Cây lúa đã chết héo vì thiếu nước!");
        }

        public void WaterPlant(float amount)
        {
            if (currentState == CropState.Dead) return;
            
            currentWater += amount;
            currentWater = Mathf.Clamp(currentWater, 0f, cropData.maxWater);
            Debug.Log("Đã tưới nước! Lượng nước: " + currentWater);
        }

        public void Fertilize()
        {
            if (currentState == CropState.Dead) return;
            
            hasFertilizer = true;
            Debug.Log("Đã bón phân! Cây sẽ lớn nhanh hơn.");
        }

        // Tương tác trực tiếp vào thân cây lúa (Dành cho VR đập trúng phần ngọn)
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Sickle"))
            {
                CropPlot parentPlot = GetComponentInParent<CropPlot>();
                if (parentPlot == null) return;

                if (currentState == CropState.ReadyToHarvest)
                {
                    // Gặt lúa thành công
                    parentPlot.HarvestCrop();
                }
                else
                {
                    // Cắt nhầm cây lúa chưa chín hoặc cây đã chết -> Bị phá huỷ
                    Debug.LogWarning("Bạn đã chém đứt cây lúa chưa chín (hoặc đã chết)!");
                    parentPlot.DestroyCropAccidentally();
                }
                return; // Đã xử lý xong liềm thì thoát
            }

            if (currentState == CropState.Dead) return;

            if (other.CompareTag("Fertilizer") && !hasFertilizer)
            {
                Fertilize();
            }
            else if (other.CompareTag("Water"))
            {
                WaterPlant(20f); // Tùy chỉnh lượng nước mỗi lần tưới
            }
        }

        // Tạm thời dùng màu sắc để test logic
        private void UpdateVisuals()
        {
            if (cropRenderer == null) return;

            switch (currentState)
            {
                case CropState.Seedling:
                    cropRenderer.material.color = colorSeedling;
                    break;
                case CropState.Growing:
                    cropRenderer.material.color = colorGrowing;
                    break;
                case CropState.Maturing:
                    cropRenderer.material.color = colorMaturing;
                    break;
                case CropState.ReadyToHarvest:
                    cropRenderer.material.color = colorReady;
                    break;
                case CropState.Dead:
                    cropRenderer.material.color = colorDead;
                    break;
            }
        }
    }
}
