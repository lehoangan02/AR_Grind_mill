using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Khoa.Farming
{
    /// <summary>
    /// Vật phẩm Bó Lúa vật lý rơi ra sau khi gặt bằng liềm trong VR.
    /// Hỗ trợ cầm nắm bằng XRGrabInteractable, mang vác, phơi lúa và tuốt hạt.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(XRGrabInteractable))]
    [RequireComponent(typeof(Collider))]
    public class RiceBundleItem : MonoBehaviour
    {
        [Header("Crop Information")]
        public CropData cropData;

        [Tooltip("Số lượng hạt lúa chứa trong bó này (dùng cho cối xay / máy tuốt)")]
        [Min(1)]
        public int grainAmount = 10;

        [Header("Drying State (Phơi lúa)")]
        [Tooltip("Lúa đã được phơi khô hay chưa (ảnh hưởng đến việc xay xát gạo)")]
        public bool isDry = false;

        [Range(0f, 100f)]
        public float drynessProgress = 0f;

        [Header("Audio & FX")]
        public AudioClip grabSound;
        public AudioClip dropSound;

        // Events cho Quest / Inventory / Sound Manager
        public event Action<RiceBundleItem> OnItemGrabbed;
        public event Action<RiceBundleItem> OnItemDropped;
        public event Action<RiceBundleItem> OnDriedComplete;

        private Rigidbody rb;
        private XRGrabInteractable grabInteractable;
        private AudioSource audioSource;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            grabInteractable = GetComponent<XRGrabInteractable>();

            // Setup Rigidbody cho trải nghiệm vật lý VR tự nhiên
            rb.mass = 1.0f;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            rb.interpolation = RigidbodyInterpolation.Interpolate;

            // Setup XRGrabInteractable
            if (grabInteractable != null)
            {
                grabInteractable.selectEntered.AddListener(OnGrab);
                grabInteractable.selectExited.AddListener(OnDrop);
                grabInteractable.throwOnDetach = true;
                grabInteractable.throwSmoothingDuration = 0.25f;
            }

            // AudioSource (nếu có sound)
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null && (grabSound != null || dropSound != null))
            {
                audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.spatialBlend = 1f; // 3D Spatial Audio
                audioSource.playOnAwake = false;
            }
        }

        private void OnDestroy()
        {
            if (grabInteractable != null)
            {
                grabInteractable.selectEntered.RemoveListener(OnGrab);
                grabInteractable.selectExited.RemoveListener(OnDrop);
            }
        }

        private void OnGrab(SelectEnterEventArgs args)
        {
            PlaySound(grabSound);
            OnItemGrabbed?.Invoke(this);
            Debug.Log($"Đã nhặt bó lúa ({grainAmount} hạt) lên tay VR!");
        }

        private void OnDrop(SelectExitEventArgs args)
        {
            PlaySound(dropSound);
            OnItemDropped?.Invoke(this);
        }

        [Header("Shelter State")]
        [Tooltip("Bó lúa có đang ở trong khu vực có mái che an toàn không")]
        public bool isSheltered = false;

        /// <summary>
        /// Tăng hoặc giảm tiến độ phơi khô (dương khi phơi nắng, âm khi dính mưa)
        /// </summary>
        public void AddDryness(float amount)
        {
            drynessProgress = Mathf.Clamp(drynessProgress + amount, 0f, 100f);

            if (drynessProgress >= 100f)
            {
                if (!isDry)
                {
                    isDry = true;
                    OnDriedComplete?.Invoke(this);
                    Debug.Log("Bó lúa đã được phơi khô hoàn toàn, sẵn sàng đem tuốt hạt!");
                }
            }
            else
            {
                isDry = false;
            }
        }

        private void PlaySound(AudioClip clip)
        {
            if (clip != null && audioSource != null)
            {
                audioSource.PlayOneShot(clip);
            }
        }
    }
}
