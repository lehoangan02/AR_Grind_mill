using System;
using UnityEngine;

namespace Khoa.Farming
{
    /// <summary>
    /// Máy/Cối tuốt lúa (Rice Thresher).
    /// Nhận bó lúa đã phơi khô (RiceBundleItem), tuốt tách ra Hạt thóc vàng (Grains) và Rơm rạ (Straw).
    /// </summary>
    [RequireComponent(typeof(BoxCollider))]
    public class RiceThresher : MonoBehaviour
    {
        [Header("Threshing Settings")]
        [Tooltip("Hệ số nhân số lượng hạt thóc thu được")]
        [Min(1f)]
        public float grainYieldMultiplier = 1f;

        [Header("Prefabs Output (Tuỳ chọn)")]
        [Tooltip("Prefab đống rơm rạ văng ra sau khi tuốt")]
        public GameObject strawPrefab;
        [Tooltip("Vị trí rơm rạ rơi ra")]
        public Transform strawDropPoint;

        [Header("Visual & Audio FX")]
        [Tooltip("Hiệu ứng hạt thóc bắn ra")]
        public ParticleSystem grainParticleFX;
        [Tooltip("Âm thanh máy tuốt lúa quay")]
        public AudioSource thresherAudioSource;

        [Header("Output Receiver")]
        [Tooltip("Bộ nhận thóc. Nếu không có đầu ra hợp lệ, bó lúa sẽ không bị tiêu thụ.")]
        public RiceThresherBasketReceiver basketReceiver;

        // Sự kiện khi tuốt thành công 1 bó lúa
        public event Action<int> OnRiceThreshed;

        void Awake()
        {
            BoxCollider col = GetComponent<BoxCollider>();
            if (col != null)
            {
                col.isTrigger = true;
            }

            if (basketReceiver == null)
            {
                basketReceiver = GetComponent<RiceThresherBasketReceiver>();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other == null) return;

            RiceBundleItem bundle = other.GetComponent<RiceBundleItem>();
            if (bundle == null)
            {
                bundle = other.GetComponentInParent<RiceBundleItem>();
            }

            if (bundle != null)
            {
                ThreshRiceBundle(bundle);
            }
        }

        /// <summary>
        /// Thực hiện tuốt bó lúa
        /// </summary>
        public bool ThreshRiceBundle(RiceBundleItem bundle)
        {
            if (bundle == null) return false;

            // Kiểm tra điều kiện độ khô
            if (!bundle.isDry)
            {
                Debug.LogWarning("Bó lúa còn tươi/ẩm ướt! Bạn cần đem ra sân phơi nắng khô (100%) trước khi tuốt hạt.");
                return false;
            }

            int grainsHarvested = Mathf.RoundToInt(bundle.grainAmount * grainYieldMultiplier);

            if (basketReceiver == null)
            {
                basketReceiver = GetComponent<RiceThresherBasketReceiver>();
            }

            if (basketReceiver == null || !basketReceiver.TryReceiveGrain(grainsHarvested))
            {
                Debug.LogWarning("Không có giỏ lúa rỗng nhận thóc. Bó lúa được giữ lại để người chơi thử lại.");
                return false;
            }

            Debug.Log($"Tuốt lúa thành công! Thu được {grainsHarvested} hạt thóc vàng.");

            // Phát hiệu ứng và âm thanh
            if (grainParticleFX != null)
            {
                grainParticleFX.Play();
            }

            if (thresherAudioSource != null)
            {
                thresherAudioSource.Play();
            }

            // Sinh rơm rạ nếu có thiết lập
            if (strawPrefab != null)
            {
                Vector3 dropPos = strawDropPoint != null ? strawDropPoint.position : transform.position + transform.right * 1f;
                Instantiate(strawPrefab, dropPos, Quaternion.identity);
            }

            // Gọi sự kiện để Inventory / Game Manager nhận thóc
            OnRiceThreshed?.Invoke(grainsHarvested);

            // Huỷ bó lúa đã tuốt xong
            if (Application.isPlaying)
                Destroy(bundle.gameObject);
            else
                DestroyImmediate(bundle.gameObject);
            return true;
        }
    }
}
