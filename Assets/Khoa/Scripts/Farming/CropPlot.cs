using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Khoa.Farming
{
    public enum PlotState
    {
        Empty,    // Đất trống
        Tilled,   // Đã bừa, sẵn sàng cấy
        Occupied  // Đã cấy lúa
    }

    // RequireComponent giúp tự động add các component này vào Prefab nếu chưa có
    [RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable))]
    [RequireComponent(typeof(BoxCollider))]
    public class CropPlot : MonoBehaviour
    {
        public PlotState currentState = PlotState.Empty;
        
        [Header("Prefabs")]
        public GameObject ricePrefab; // Prefab cây lúa sẽ được sinh ra
        
        [Header("Spawn Settings")]
        public Transform cropSpawnPoint; // Vị trí cây lúa mọc lên (nên là 1 empty object con)

        [Header("Models 3D (Optional)")]
        public GameObject emptyModel3D; // Model đất trống chưa cày (thả vào đây)
        public GameObject tilledModel3D; // Model luống đất đã cày (thả vào đây)

        [Header("Visuals (Test Mù màu)")]
        public MeshRenderer plotRenderer;
        public Color colorEmpty = new Color(0.6f, 0.4f, 0.2f); // Nâu nhạt
        public Color colorTilled = new Color(0.3f, 0.2f, 0.1f); // Nâu đậm (đất ướt)

        private UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable xrInteractable;
        private RicePlant currentCrop; // Lưu trữ cây lúa hiện tại trên ô đất này

        void Awake()
        {
            xrInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
            
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
            if (currentState == PlotState.Occupied && ricePrefab != null)
            {
                Vector3 spawnPos = cropSpawnPoint != null ? cropSpawnPoint.position : transform.position;
                Transform cropParent = transform.parent != null ? transform.parent : null;
                GameObject cropGO = Instantiate(ricePrefab, spawnPos, Quaternion.identity, cropParent);
                currentCrop = cropGO.GetComponent<RicePlant>();
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
            // Tương tác cơ bản bằng nút bấm VR
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

        // Xử lý logic dùng chung cho cả 2 loại va chạm
        private void HandleInteraction(Collider other)
        {
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
                // Có thể thêm: Destroy(other.gameObject) nếu muốn tiêu hao mạ
            }
            // Các tương tác khi đã có lúa (Occupied)
            else if (currentState == PlotState.Occupied && currentCrop != null)
            {
                // 3. Dùng Phân (Fertilizer) để bón
                if (other.CompareTag("Fertilizer") && !currentCrop.hasFertilizer)
                {
                    currentCrop.Fertilize();
                }
                // 4. Dùng Nước (Water) để tưới
                else if (other.CompareTag("Water"))
                {
                    currentCrop.WaterPlant(20f); // Mỗi lần tưới thêm 20 nước (tuỳ chỉnh)
                }
                // 5. Dùng Liềm (Sickle) để gặt
                else if (other.CompareTag("Sickle"))
                {
                    if (currentCrop.currentState == Khoa.Farming.CropState.ReadyToHarvest)
                    {
                        HarvestCrop();
                    }
                    else
                    {
                        Debug.LogWarning("Bạn đã chém đứt cây lúa chưa chín (hoặc đã chết)!");
                        DestroyCropAccidentally();
                    }
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

            // Tạo cây lúa
            Vector3 spawnPos = cropSpawnPoint != null ? cropSpawnPoint.position : transform.position;
            
            // QUAN TRỌNG: Gắn cây lúa làm con của transform.parent (cái Grid) thay vì cái Plot_Prefab.
            // Vì Plot_Prefab bị bẹp (Y=0.1) và bị xoay nghiêng, nên Unity sẽ bóp méo (shear) mọi object con.
            // Đưa ra ngoài Grid (có scale 1x1x1) sẽ giúp cây lúa không bao giờ bị méo, và nó sẽ tự động mọc thẳng đứng lên trời!
            Transform cropParent = transform.parent != null ? transform.parent : null;
            GameObject cropGO = Instantiate(ricePrefab, spawnPos, Quaternion.identity, cropParent);
            
            currentCrop = cropGO.GetComponent<RicePlant>();
            currentState = PlotState.Occupied;
            
            Debug.Log("Đã cấy mạ!");
        }

        public void HarvestCrop()
        {
            if (currentState != PlotState.Occupied || currentCrop == null) return;
            
            if (currentCrop.currentState == CropState.ReadyToHarvest)
            {
                // Xoá cây lúa (Trong thực tế sẽ sinh ra Item Hạt Lúa để nhặt)
                Destroy(currentCrop.gameObject);
                currentCrop = null;
                
                // Trở về đất trống
                currentState = PlotState.Empty;
                UpdateVisuals();
                Debug.Log("Đã gặt lúa thành công!");
            }
            else
            {
                Debug.Log("Lúa chưa chín, không thể gặt!");
            }
        }

        public void DestroyCropAccidentally()
        {
            if (currentState != PlotState.Occupied || currentCrop == null) return;
            
            Destroy(currentCrop.gameObject);
            currentCrop = null;
            
            // Trở về đất trống
            currentState = PlotState.Empty;
            UpdateVisuals();
        }

        private void UpdateVisuals()
        {
            // 1. Xử lý hiển thị bằng Model 3D xịn (Nếu bạn đã kéo thả vào)
            if (emptyModel3D != null && tilledModel3D != null)
            {
                emptyModel3D.SetActive(currentState == PlotState.Empty);
                tilledModel3D.SetActive(currentState != PlotState.Empty); // Khi đã xới hoặc đã trồng thì dùng đất ướt
                
                // Giấu cái hình khối hộp vuông vức của Unity đi
                if (plotRenderer != null) plotRenderer.enabled = false;
            }
            // 2. Xử lý hiển thị bằng màu sắc (Dùng tạm khi chưa có Model)
            else if (plotRenderer != null)
            {
                if (currentState == PlotState.Empty)
                    plotRenderer.material.color = colorEmpty;
                else if (currentState == PlotState.Tilled)
                    plotRenderer.material.color = colorTilled;
            }
        }
    }
}
