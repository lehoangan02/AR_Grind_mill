using System;
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

        // Sự kiện khi trạng thái cây lúa thay đổi (dùng cho Quest, FX, Âm thanh)
        public event Action<CropState> OnCropStateChanged;

        [HideInInspector]
        public CropPlot assignedPlot; // Tham chiếu trực tiếp đến ô đất sở hữu cây này
        
        private float dryTimer = 0f;
        private float _growthRatePerSecond = 0.555f;

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

        private static MaterialPropertyBlock _mpb;
        private static readonly int BaseColorId = Shader.PropertyToID("_BaseColor");
        private static readonly int ColorId = Shader.PropertyToID("_Color");

        public void Initialize(CropPlot plot)
        {
            assignedPlot = plot;
        }

        void Start()
        {
            if (cropData == null)
            {
                Debug.LogError("RicePlant: CropData is missing!");
                enabled = false;
                return;
            }

            _growthRatePerSecond = cropData.timeToHarvest > 0.01f ? (100f / cropData.timeToHarvest) : 0.555f;
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

            if (currentWater <= 0f)
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
                // Áp dụng bón phân
                float growthMultiplier = hasFertilizer ? cropData.fertilizerGrowthMultiplier : 1f;
                
                growthProgress += _growthRatePerSecond * growthMultiplier * Time.deltaTime;
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
            Vector3 targetScale = Vector3.Lerp(minScale, maxScale, t);
            
            // Khử đi sự bóp méo hình dạng của ô đất (vì ô đất có scale Y = 0.1)
            if (transform.parent != null)
            {
                Vector3 parentScale = transform.parent.localScale;
                if (parentScale.x > 0.001f) targetScale.x /= parentScale.x;
                if (parentScale.y > 0.001f) targetScale.y /= parentScale.y;
                if (parentScale.z > 0.001f) targetScale.z /= parentScale.z;
            }
            
            transform.localScale = targetScale;
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
                OnCropStateChanged?.Invoke(currentState);
            }
        }

        private void Die()
        {
            currentState = CropState.Dead;
            UpdateVisuals();
            OnCropStateChanged?.Invoke(currentState);
            Debug.Log("Cây lúa đã chết héo vì thiếu nước!");
        }

        public void WaterPlant(float amount)
        {
            if (currentState == CropState.Dead) return;
            
            currentWater += amount;
            currentWater = Mathf.Clamp(currentWater, 0f, cropData.maxWater);
            Debug.Log($"Đã tưới nước! Lượng nước: {currentWater:F1}");
        }

        public void Fertilize()
        {
            if (currentState == CropState.Dead || hasFertilizer) return;
            
            hasFertilizer = true;
            Debug.Log("Đã bón phân! Cây sẽ lớn nhanh hơn.");
        }

        // Hỗ trợ va chạm xuyên thấu (Trigger)
        private void OnTriggerEnter(Collider other)
        {
            HandleInteraction(other);
        }

        // Hỗ trợ va chạm cứng (Collision)
        private void OnCollisionEnter(Collision collision)
        {
            HandleInteraction(collision.collider);
        }

        // Tương tác trực tiếp vào thân cây lúa (Dành cho VR đập trúng phần ngọn)
        private void HandleInteraction(Collider other)
        {
            if (other == null) return;

            CropPlot targetPlot = assignedPlot != null ? assignedPlot : GetComponentInParent<CropPlot>();

            if (other.CompareTag("Sickle"))
            {
                if (targetPlot != null)
                {
                    if (currentState == CropState.ReadyToHarvest)
                    {
                        targetPlot.HarvestCrop();
                    }
                    else
                    {
                        Debug.LogWarning("Bạn đã chém đứt cây lúa chưa chín (hoặc đã chết)!");
                        targetPlot.DestroyCropAccidentally();
                    }
                }
                return;
            }

            if (currentState == CropState.Dead) return;

            if (other.CompareTag("Fertilizer") && !hasFertilizer)
            {
                Fertilize();
            }
            else if (other.CompareTag("Water"))
            {
                WaterPlant(20f);
            }
        }

        // Cập nhật màu sắc bằng MaterialPropertyBlock tránh phân mảnh bộ nhớ RAM và Draw Calls
        private void UpdateVisuals()
        {
            if (cropRenderer == null) return;

            Color targetColor;
            switch (currentState)
            {
                case CropState.Seedling:
                    targetColor = colorSeedling;
                    break;
                case CropState.Growing:
                    targetColor = colorGrowing;
                    break;
                case CropState.Maturing:
                    targetColor = colorMaturing;
                    break;
                case CropState.ReadyToHarvest:
                    targetColor = colorReady;
                    break;
                case CropState.Dead:
                default:
                    targetColor = colorDead;
                    break;
            }

            SetRendererColor(cropRenderer, targetColor);
        }

        private void SetRendererColor(Renderer r, Color c)
        {
            if (r == null) return;
            if (_mpb == null) _mpb = new MaterialPropertyBlock();
            r.GetPropertyBlock(_mpb);
            _mpb.SetColor(BaseColorId, c);
            _mpb.SetColor(ColorId, c);
            r.SetPropertyBlock(_mpb);
        }
    }
}
