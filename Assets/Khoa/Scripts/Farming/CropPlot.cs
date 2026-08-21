using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Khoa.Farming
{
    public enum PlotState
    {
        Empty,    // Đất trống
        Tilled,   // Đã bừa, sẵn sàng cấy
        Occupied  // Đã cấy lúa
    }

    // RequireComponent giúp tự động add các component này vào Prefab nếu chưa có
    [RequireComponent(typeof(XRSimpleInteractable))]
    [RequireComponent(typeof(BoxCollider))]
    public class CropPlot : MonoBehaviour
    {
        public PlotState currentState = PlotState.Empty;
        
        [Header("Prefabs")]
        public GameObject ricePrefab; // Prefab cây lúa sẽ được sinh ra
        
        [Header("Harvest Drops (Vật phẩm rơi khi gặt)")]
        [Tooltip("Prefab Bó Lúa sẽ sinh ra khi gặt bằng liềm")]
        public GameObject harvestItemPrefab;

        [Header("Spawn Settings")]
        public Transform cropSpawnPoint; // Vị trí cây lúa mọc lên (nên là 1 empty object con)

        [Header("Models 3D (Optional)")]
        public GameObject emptyModel3D; // Model đất trống chưa cày (thả vào đây)
        public GameObject tilledModel3D; // Model luống đất đã cày (thả vào đây)

        [Header("Visuals & Moisture (Đất động & Độ ẩm nước)")]
        public MeshRenderer plotRenderer;
        public Color colorEmpty = new Color(0.6f, 0.4f, 0.2f); // Nâu vàng đất tự nhiên
        public Color colorDry = new Color(0.55f, 0.43f, 0.27f);  // Nâu sáng đất xới khô
        public Color colorWet = new Color(0.18f, 0.11f, 0.05f);  // Nâu đen bùn phù sa ướt
        [Tooltip("Lớp váng nước mỏng trên mặt ruộng (sẽ hiện khi ruộng đủ nước)")]
        public GameObject waterSurfaceMesh;
        [Range(0f, 1f)]
        public float currentMoisture = 0f;

        [Header("Gleaning Settings (Mót lúa rơi vãi)")]
        [Tooltip("Prefab bông lúa rơi vãi để người chơi mót")]
        public GameObject gleanStalkPrefab;
        [Tooltip("Tỉ lệ rơi vãi bông lúa mót sau khi gặt (0-1)")]
        [Range(0f, 1f)]
        public float gleanSpawnChance = 0.8f;
        [Tooltip("Số bông lúa mót tối thiểu sinh ra")]
        [Min(0)]
        public int minGleanStalks = 1;
        [Tooltip("Số bông lúa mót tối đa sinh ra")]
        [Min(1)]
        public int maxGleanStalks = 3;

        // Events cho Game Manager / Quest Manager / Audio Manager
        public event Action<PlotState> OnStateChanged;
        public event Action<CropPlot, RiceBundleItem> OnCropHarvestedWithItem;
        public event Action<CropPlot> OnCropHarvested;
        public event Action<CropPlot> OnCropPlanted;

        private XRSimpleInteractable xrInteractable;
        private RicePlant currentCrop; // Lưu trữ cây lúa hiện tại trên ô đất này

        private static MaterialPropertyBlock _mpb;
        private static readonly int BaseColorId = Shader.PropertyToID("_BaseColor");
        private static readonly int ColorId = Shader.PropertyToID("_Color");

        void Awake()
        {
            xrInteractable = GetComponent<XRSimpleInteractable>();
            
            // Đăng ký sự kiện khi VR Controller tương tác (bấm nút trigger vào ô đất)
            if (xrInteractable != null)
            {
                xrInteractable.selectEntered.AddListener(OnVRSelect);
            }

            UpdateVisuals();
        }

        void Start()
        {
            // Tính năng Test nhanh: Nếu chọn sẵn Occupied trong Inspector, game chạy sẽ tự mọc lúa luôn
            if (currentState == PlotState.Occupied && ricePrefab != null && currentCrop == null)
            {
                SpawnRicePlant();
            }
        }

        void OnDestroy()
        {
            if (xrInteractable != null)
                xrInteractable.selectEntered.RemoveListener(OnVRSelect);
        }

        // Hàm này chạy khi người chơi bấm tương tác (bắn tia Ray hoặc cầm tay chạm vào bằng XR Interaction Toolkit)
        private void OnVRSelect(SelectEnterEventArgs args)
        {
            InteractWithPlot();
        }

        // Hỗ trợ cả va chạm xuyên thấu (Trigger)
        private void OnTriggerEnter(Collider other)
        {
            HandleInteraction(other);
        }

        // Hỗ trợ cả va chạm cứng (Physical Collision)
        private void OnCollisionEnter(Collision collision)
        {
            HandleInteraction(collision.collider);
        }

        // Xử lý logic va chạm ở cấp độ ô đất (Plot)
        private void HandleInteraction(Collider other)
        {
            if (other == null) return;

            // 1. Dùng Bừa (Plow) để xới đất trống
            if (other.CompareTag("Plow"))
            {
                if (currentState == PlotState.Empty)
                {
                    PlowPlot();
                }
                else if (currentState == PlotState.Occupied)
                {
                    // Lỡ tay cuốc trúng cây lúa -> Phá huỷ cây lúa và xới lại đất
                    Debug.LogWarning("Bạn đã lỡ tay cuốc trúng cây lúa, cây lúa đã bị phá huỷ!");
                    DestroyCropAccidentally();
                    PlowPlot();
                }
            }
            // 2. Dùng Mạ (Seed) để cấy lên đất đã xới
            else if (other.CompareTag("Seed") && currentState == PlotState.Tilled)
            {
                PlantCrop();
            }
            // Các tương tác chăm sóc cây (khi có lúa) nếu đập trúng đất thay vì trúng thân cây
            else if (currentState == PlotState.Occupied && currentCrop != null)
            {
                if (other.CompareTag("Fertilizer") && !currentCrop.hasFertilizer)
                {
                    currentCrop.Fertilize();
                }
                else if (other.CompareTag("Water"))
                {
                    currentCrop.WaterPlant(20f);
                }
            }
        }

        // Hàm xử lý chung khi bấm bằng tia Laser VR (Dùng để dự phòng / Test)
        private void InteractWithPlot()
        {
            if (currentState == PlotState.Empty) PlowPlot();
            else if (currentState == PlotState.Tilled) PlantCrop();
            else if (currentState == PlotState.Occupied)
            {
                if (currentCrop != null && !currentCrop.hasFertilizer) currentCrop.Fertilize();
            }
        }

        public void PlowPlot()
        {
            if (currentState != PlotState.Empty) return;
            
            currentState = PlotState.Tilled;
            UpdateVisuals();
            OnStateChanged?.Invoke(currentState);
            Debug.Log("Đã dùng Bừa để xới đất!");
        }

        public void PlantCrop()
        {
            if (currentState != PlotState.Tilled) return;
            if (ricePrefab == null)
            {
                Debug.LogError("Chưa gán Rice Prefab cho ô đất!");
                return;
            }

            SpawnRicePlant();
            currentState = PlotState.Occupied;
            UpdateVisuals();
            OnStateChanged?.Invoke(currentState);
            OnCropPlanted?.Invoke(this);
            
            Debug.Log("Đã cấy mạ!");
        }

        private void SpawnRicePlant()
        {
            Vector3 spawnPos = cropSpawnPoint != null ? cropSpawnPoint.position : transform.position;
            
            // Gắn cây lúa làm con của transform.parent (Grid) để tránh méo scale Y=0.1 của Plot_Prefab
            Transform cropParent = transform.parent != null ? transform.parent : null;
            GameObject cropGO = Instantiate(ricePrefab, spawnPos, Quaternion.identity, cropParent);
            
            currentCrop = cropGO.GetComponent<RicePlant>();
            if (currentCrop != null)
            {
                currentCrop.Initialize(this);
            }
        }

        public void HarvestCrop()
        {
            if (currentState != PlotState.Occupied || currentCrop == null) return;
            
            if (currentCrop.currentState == CropState.ReadyToHarvest)
            {
                RiceBundleItem spawnedBundle = null;

                // Sinh ra Bó Lúa vật lý để người chơi có thể cầm nắm bằng tay VR
                if (harvestItemPrefab != null)
                {
                    Vector3 spawnPos = cropSpawnPoint != null ? cropSpawnPoint.position + Vector3.up * 0.15f : transform.position + Vector3.up * 0.15f;
                    GameObject bundleGO = Instantiate(harvestItemPrefab, spawnPos, Quaternion.identity);

                    spawnedBundle = bundleGO.GetComponent<RiceBundleItem>();
                    if (spawnedBundle != null)
                    {
                        spawnedBundle.cropData = currentCrop.cropData;
                    }

                    // Thêm lực nảy nhẹ (pop impulse) để bó lúa văng nhẹ ra đất cực đẹp mắt
                    Rigidbody bundleRb = bundleGO.GetComponent<Rigidbody>();
                    if (bundleRb != null)
                    {
                        Vector3 popDir = new Vector3(UnityEngine.Random.Range(-0.3f, 0.3f), 1.2f, UnityEngine.Random.Range(-0.3f, 0.3f));
                        bundleRb.linearVelocity = popDir;
                    }
                }

                // Sinh các bông lúa rơi vãi để người chơi mót lúa
                if (gleanStalkPrefab != null && UnityEngine.Random.value <= gleanSpawnChance)
                {
                    int stalkCount = UnityEngine.Random.Range(minGleanStalks, maxGleanStalks + 1);
                    for (int i = 0; i < stalkCount; i++)
                    {
                        Vector2 randomOffset = UnityEngine.Random.insideUnitCircle * 0.45f;
                        Vector3 stalkPos = transform.position + new Vector3(randomOffset.x, 0.1f, randomOffset.y);
                        GameObject stalkGO = Instantiate(gleanStalkPrefab, stalkPos, Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f));
                        Rigidbody stalkRb = stalkGO.GetComponent<Rigidbody>();
                        if (stalkRb != null)
                        {
                            stalkRb.linearVelocity = new Vector3(randomOffset.x * 0.5f, 0.5f, randomOffset.y * 0.5f);
                        }
                    }
                }

                OnCropHarvested?.Invoke(this);
                OnCropHarvestedWithItem?.Invoke(this, spawnedBundle);

                if (Application.isPlaying)
                    Destroy(currentCrop.gameObject);
                else
                    DestroyImmediate(currentCrop.gameObject);
                currentCrop = null;
                
                // Trở về đất trống
                currentState = PlotState.Empty;
                UpdateVisuals();
                OnStateChanged?.Invoke(currentState);
                Debug.Log("Đã gặt lúa thành công và sinh ra Bó Lúa!");
            }
            else
            {
                Debug.Log("Lúa chưa chín, không thể gặt!");
            }
        }

        public void DestroyCropAccidentally()
        {
            if (currentState != PlotState.Occupied || currentCrop == null) return;
            
            if (Application.isPlaying)
                Destroy(currentCrop.gameObject);
            else
                DestroyImmediate(currentCrop.gameObject);
            currentCrop = null;
            
            // Trở về đất trống
            currentState = PlotState.Empty;
            UpdateVisuals();
            OnStateChanged?.Invoke(currentState);
        }

        /// <summary>
        /// Cấp nước cho ô đất (dùng bởi Bình tưới, Van nước kênh mương, hoặc trời mưa)
        /// </summary>
        public void WaterPlot(float amount)
        {
            if (currentState == PlotState.Occupied && currentCrop != null)
            {
                currentCrop.WaterPlant(amount);
            }
            else
            {
                // Khi chưa trồng cây nhưng được xả nước kênh vào ruộng
                currentMoisture = Mathf.Clamp01(currentMoisture + (amount / 100f));
                UpdateVisuals();
            }
        }

        public void UpdateSoilMoistureVisuals(float moistureRatio)
        {
            currentMoisture = Mathf.Clamp01(moistureRatio);
            UpdateVisuals();
        }

        private void UpdateVisuals()
        {
            // 1. Xử lý hiển thị bằng Model 3D xịn (Nếu bạn đã kéo thả vào)
            if (emptyModel3D != null && tilledModel3D != null)
            {
                emptyModel3D.SetActive(currentState == PlotState.Empty);
                tilledModel3D.SetActive(currentState != PlotState.Empty);
                
                if (plotRenderer != null) plotRenderer.enabled = false;
            }
            // 2. Xử lý hiển thị bằng màu sắc & độ ẩm nước (Dùng MaterialPropertyBlock để tránh clone Material)
            else if (plotRenderer != null)
            {
                plotRenderer.enabled = true;
                Color baseColor = (currentState == PlotState.Empty) ? colorEmpty : colorDry;
                Color targetColor = Color.Lerp(baseColor, colorWet, currentMoisture);
                SetRendererColor(plotRenderer, targetColor);
            }

            // 3. Xử lý lớp váng nước phẳng phản chiếu khi ruộng đủ nước
            if (waterSurfaceMesh != null)
            {
                bool showWater = (currentState == PlotState.Occupied && currentMoisture >= 0.35f) || (currentState != PlotState.Empty && currentMoisture >= 0.7f);
                waterSurfaceMesh.SetActive(showWater);
            }
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
