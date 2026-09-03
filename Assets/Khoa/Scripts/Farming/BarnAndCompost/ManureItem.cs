using System;
using UnityEngine;

namespace Khoa.Farming
{
    /// <summary>
    /// Đống phân tươi sinh ra tại các chuồng trâu, bò, heo.
    /// Cung cấp giao dịch atomic TryScoop để tránh bị xúc trùng lặp bởi nhiều collider.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider))]
    public class ManureItem : MonoBehaviour
    {
        [Header("Thông tin nguồn gốc")]
        public BarnAnimalType sourceAnimal = BarnAnimalType.Cow;
        public BarnManureSource parentSource;

        [Header("Trạng thái giao dịch")]
        [SerializeField] private bool isScooped = false;
        public bool IsScooped => isScooped;

        [Header("Hiệu ứng phản hồi")]
        public ParticleSystem scoopParticleFX;
        public AudioClip scoopAudioClip;

        public event Action<ManureItem> OnScooped;

        private Collider itemCollider;

        private void Awake()
        {
            itemCollider = GetComponent<Collider>();
        }

        /// <summary>
        /// Giao dịch xúc phân atomic. Chỉ trả về true một lần duy nhất.
        /// </summary>
        public bool TryScoop(out float amount)
        {
            amount = 0f;
            if (isScooped)
            {
                return false;
            }

            isScooped = true;
            amount = 1f;

            // Ngắt collider ngay lập tức để multi-collider không kích hoạt thêm
            if (itemCollider != null)
            {
                itemCollider.enabled = false;
            }

            if (scoopParticleFX != null)
            {
                scoopParticleFX.transform.SetParent(null);
                scoopParticleFX.Play();
                if (Application.isPlaying) Destroy(scoopParticleFX.gameObject, 2f);
                else DestroyImmediate(scoopParticleFX.gameObject);
            }

            if (scoopAudioClip != null)
            {
                AudioSource.PlayClipAtPoint(scoopAudioClip, transform.position, 0.8f);
            }

            OnScooped?.Invoke(this);

            if (parentSource != null)
            {
                parentSource.OnItemCollected(this);
            }

            if (Application.isPlaying) Destroy(gameObject, 0.05f);
            else DestroyImmediate(gameObject);
            return true;
        }
    }
}
