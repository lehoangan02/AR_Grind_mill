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

        [Tooltip("Tốc độ cấp nước mỗi giây cho từng ô ruộng (water units/s)")]
        [Min(0.1f)]
        public float waterFlowRate = 20f;

        [Header("Connected Field Plots (Danh sách các ô ruộng kết nối)")]
        [Tooltip("Các ô ruộng nhận nước khi mở van")]
        public List<CropPlot> connectedPlots = new List<CropPlot>();

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

        void Awake()
        {
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

        private void OnVRSelect(SelectEnterEventArgs args)
        {
            ToggleGate();
        }

        void Update()
        {
            if (isOpen && connectedPlots != null && connectedPlots.Count > 0)
            {
                float amountThisFrame = waterFlowRate * Time.deltaTime;
                for (int i = 0; i < connectedPlots.Count; i++)
                {
                    CropPlot plot = connectedPlots[i];
                    if (plot != null)
                    {
                        plot.WaterPlot(amountThisFrame);
                    }
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
            isOpen = true;
            UpdateVisuals();
            OnGateStateChanged?.Invoke(true);
            Debug.Log("Đã mở van nước! Nước đang chảy vào các thửa ruộng...");
        }

        /// <summary>
        /// Đóng van nước
        /// </summary>
        public void CloseGate()
        {
            isOpen = false;
            UpdateVisuals();
            OnGateStateChanged?.Invoke(false);
            Debug.Log("Đã đóng van nước kênh mương.");
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
                waterFlowParticles.SetActive(isOpen);
            }

            if (waterAudioSource != null)
            {
                if (isOpen && !waterAudioSource.isPlaying)
                    waterAudioSource.Play();
                else if (!isOpen && waterAudioSource.isPlaying)
                    waterAudioSource.Stop();
            }

            if (leverTransform != null)
            {
                leverTransform.localEulerAngles = isOpen ? leverOpenRotation : leverClosedRotation;
            }
        }
    }
}
