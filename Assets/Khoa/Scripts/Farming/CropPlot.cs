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
    [RequireComponent(typeof(XRSimpleInteractable))]
    [RequireComponent(typeof(BoxCollider))]
    public class CropPlot : MonoBehaviour
    {
        public PlotState currentState = PlotState.Empty;
        
        [Header("Prefabs")]
        public GameObject ricePrefab; // Prefab cây lúa sẽ được sinh ra
        
        [Header("Spawn Settings")]
        public Transform cropSpawnPoint; // Vị trí cây lúa mọc lên (nên là 1 empty object con)

        [Header("Visuals (Test)")]
        public MeshRenderer plotRenderer;
        public Color colorEmpty = new Color(0.6f, 0.4f, 0.2f); // Nâu nhạt
        public Color colorTilled = new Color(0.3f, 0.2f, 0.1f); // Nâu đậm (đất ướt)

        private XRSimpleInteractable xrInteractable;
        private RicePlant currentCrop; // Lưu trữ cây lúa hiện tại trên ô đất này

        void Awake()
        {
            xrInteractable = GetComponent<XRSimpleInteractable>();
            
            // Đăng ký sự kiện khi VR Controller tương tác (bấm nút trigger vào ô đất)
            xrInteractable.selectEntered.AddListener(OnVRSelect);

            UpdateVisuals();
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

        // Tương tác vật lý thực tế: Cầm công cụ đập vào đất hoặc cây lúa
        private void OnTriggerEnter(Collider other)
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
                    if (currentCrop.currentState == CropState.ReadyToHarvest)
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
            GameObject cropGO = Instantiate(ricePrefab, spawnPos, Quaternion.identity, transform);
            
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
            if (plotRenderer == null) return;

            if (currentState == PlotState.Empty)
                plotRenderer.material.color = colorEmpty;
            else if (currentState == PlotState.Tilled)
                plotRenderer.material.color = colorTilled;
            // Trạng thái Occupied sẽ không đổi màu ô đất nữa, vì cây lúa đã che lên
        }
    }
}
