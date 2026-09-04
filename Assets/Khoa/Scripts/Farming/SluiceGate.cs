using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Khoa.Farming
{
    /// <summary>
    /// Van xả nước kênh mương (Sluice Gate / Irrigation Gate).
    /// Người chơi kéo cần gạt van trong VR để xả nước vào mương, tưới đồng loạt cho tất cả các ô ruộng kết nối.
    /// </summary>
    public class SluiceGate : MonoBehaviour
    {
        [Header("State")]
        [Tooltip("Trạng thái van đang mở hay đóng")]
        public bool isOpen = false;

        [SerializeField, Range(0f, 1f)]
        [Tooltip("Mức mở thực tế của van. 0 là đóng hoàn toàn, 1 là mở hoàn toàn.")]
        private float openAmount;

        [Tooltip("Tốc độ cấp nước mỗi giây cho từng ô ruộng (water units/s)")]
        [Min(0.1f)]
        public float waterFlowRate = 20f;

        [Tooltip("Khoảng thời gian giữa hai đợt cập nhật tưới. Giảm số lần quét ruộng lớn nhưng giữ nguyên lượng nước/giây.")]
        [Min(0.02f)]
        public float irrigationTickInterval = 0.1f;

        [Header("Connected Field Plots (Danh sách các ô ruộng kết nối)")]
        [Tooltip("Các ô ruộng nhận nước khi mở van")]
        public List<CropPlot> connectedPlots = new List<CropPlot>();

        [Tooltip("Tự tìm ruộng gần van khi scene chưa gán danh sách thủ công")]
        public bool autoFindNearbyPlotsOnStart = true;

        [Min(1f)]
        public float autoFindRadius = 25f;

        [Header("Visual & Audio Feedback")]
        [Tooltip("Hiệu ứng hạt dòng nước chảy khi mở van")]
        public GameObject waterFlowParticles;

        [Tooltip("Cần gạt hoặc bánh xe xoay van")]
        public Transform leverTransform;
        public Vector3 leverClosedRotation = Vector3.zero;
        public Vector3 leverOpenRotation = new Vector3(0f, 0f, 45f);

        [Tooltip("Nguồn phát âm thanh tiếng nước chảy")]
        public AudioSource waterAudioSource;

        [Header("XR Interaction")]
        [Tooltip("Component tương tác XR (tự động lấy nếu có)")]
        public XRSimpleInteractable xrInteractable;

        // Sự kiện khi đóng/mở van
        public event Action<bool> OnGateStateChanged;

        private float irrigationAccumulator;

        /// <summary>
        /// Gets the normalized physical opening of the gate.
        /// </summary>
        public float OpenAmount => openAmount;

        /// <summary>
        /// Gets the effective irrigation rate after applying the lever opening.
        /// </summary>
        public float CurrentWaterFlowRate => waterFlowRate * openAmount;

        void Awake()
        {
            // Scenes serialized before continuous control only stored the boolean state.
            if (isOpen && openAmount <= 0f)
            {
                openAmount = 1f;
            }

            openAmount = Mathf.Clamp01(openAmount);
            isOpen = openAmount > 0.001f;

            if (xrInteractable == null)
            {
                xrInteractable = GetComponent<XRSimpleInteractable>();
            }

            if (xrInteractable != null)
            {
                xrInteractable.selectEntered.AddListener(OnVRSelect);
            }

            UpdateVisuals();
        }

        void OnDestroy()
        {
            if (xrInteractable != null)
            {
                xrInteractable.selectEntered.RemoveListener(OnVRSelect);
            }
        }

        void Start()
        {
            if (autoFindNearbyPlotsOnStart && (connectedPlots == null || connectedPlots.Count == 0))
            {
                AutoFindNearbyPlots(autoFindRadius);
            }
        }

        private void OnVRSelect(SelectEnterEventArgs args)
        {
            ToggleGate();
        }

        void Update()
        {
            if (openAmount <= 0.001f || connectedPlots == null || connectedPlots.Count == 0)
            {
                irrigationAccumulator = 0f;
                return;
            }

            irrigationAccumulator += Time.deltaTime;
            float tickInterval = Mathf.Max(0.02f, irrigationTickInterval);
            if (irrigationAccumulator < tickInterval)
            {
                return;
            }

            float amountThisTick = CurrentWaterFlowRate * irrigationAccumulator;
            irrigationAccumulator = 0f;
            for (int i = 0; i < connectedPlots.Count; i++)
            {
                CropPlot plot = connectedPlots[i];
                if (plot != null)
                {
                    plot.WaterPlot(amountThisTick);
                }
            }
        }

        /// <summary>
        /// Đảo ngược trạng thái mở/đóng van
        /// </summary>
        public void ToggleGate()
        {
            if (isOpen)
                CloseGate();
            else
                OpenGate();
        }

        /// <summary>
        /// Mở van xả nước
        /// </summary>
        public void OpenGate()
        {
            SetOpenAmount(1f);
            Debug.Log("Đã mở van nước! Nước đang chảy vào các thửa ruộng...");
        }

        /// <summary>
        /// Đóng van nước
        /// </summary>
        public void CloseGate()
        {
            SetOpenAmount(0f);
            Debug.Log("Đã đóng van nước kênh mương.");
        }

        /// <summary>
        /// Sets the physical gate opening while preserving the legacy open/closed event contract.
        /// </summary>
        public void SetOpenAmount(float normalizedAmount)
        {
            float clampedAmount = Mathf.Clamp01(normalizedAmount);
            bool wasOpen = isOpen;
            openAmount = clampedAmount;
            isOpen = openAmount > 0.001f;

            if (!isOpen)
            {
                irrigationAccumulator = 0f;
            }

            UpdateVisuals();
            if (wasOpen != isOpen)
            {
                OnGateStateChanged?.Invoke(isOpen);
            }
        }

        /// <summary>
        /// Thêm ô ruộng vào mạng lưới kênh tưới
        /// </summary>
        public void AddConnectedPlot(CropPlot plot)
        {
            if (plot != null && !connectedPlots.Contains(plot))
            {
                connectedPlots.Add(plot);
            }
        }

        /// <summary>
        /// Tự động quét tìm tất cả các ô CropPlot nằm trong bán kính
        /// </summary>
        public void AutoFindNearbyPlots(float searchRadius = 25f)
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, searchRadius);
            connectedPlots.Clear();
            foreach (var col in hits)
            {
                if (col.TryGetComponent<CropPlot>(out var plot))
                {
                    AddConnectedPlot(plot);
                }
            }
            Debug.Log($"Van nước đã kết nối thành công với {connectedPlots.Count} ô ruộng lân cận.");
        }

        private void UpdateVisuals()
        {
            if (waterFlowParticles != null)
            {
                waterFlowParticles.SetActive(openAmount > 0.001f);
            }

            if (waterAudioSource != null)
            {
                waterAudioSource.volume = openAmount;
                if (isOpen && !waterAudioSource.isPlaying)
                    waterAudioSource.Play();
                else if (!isOpen && waterAudioSource.isPlaying)
                    waterAudioSource.Stop();
            }

            if (leverTransform != null)
            {
                leverTransform.localRotation = Quaternion.Slerp(
                    Quaternion.Euler(leverClosedRotation),
                    Quaternion.Euler(leverOpenRotation),
                    openAmount);
            }
        }

        private void OnValidate()
        {
            openAmount = Mathf.Clamp01(openAmount);
            isOpen = openAmount > 0.001f;
            irrigationTickInterval = Mathf.Max(0.02f, irrigationTickInterval);
            UpdateVisuals();
        }
    }
}
