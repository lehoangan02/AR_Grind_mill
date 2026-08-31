using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Khoa.Farming
{
    /// <summary>
    /// Vật phẩm Gạo Trắng vật lý (White Rice / Milled Rice) thu được sau khi xay xát lúa qua Cối Xay Gạo.
    /// Dùng làm nguyên liệu cho khâu Vo Gạo và Nấu Cơm bếp củi.
    /// Hỗ trợ cầm nắm bằng XRGrabInteractable trong VR, tương tác vật lý và bỏ vào thau/nồi vo gạo.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(XRGrabInteractable))]
    [RequireComponent(typeof(Collider))]
    public class WhiteRiceItem : MonoBehaviour
    {
        [Header("Rice Properties")]
        [Tooltip("Lượng gạo trắng chứa trong thúng/bát này")]
        [Min(1)]
        public int riceAmount = 10;

        [Tooltip("Gạo đã được vo sạch hay chưa")]
        public bool isWashed = false;

        [Tooltip("Gạo đã được nấu chín thành cơm hay chưa")]
        public bool isCooked = false;

        [Header("Visual & Audio FX")]
        public AudioClip grabSound;
        public AudioClip dropSound;

        // Events
        public event Action<WhiteRiceItem> OnGrabbed;
        public event Action<WhiteRiceItem> OnDropped;

        private Rigidbody rb;
        private XRGrabInteractable grabInteractable;
        private AudioSource audioSource;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            grabInteractable = GetComponent<XRGrabInteractable>();

            if (rb != null)
            {
                rb.mass = 0.8f;
                rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                rb.interpolation = RigidbodyInterpolation.Interpolate;
            }

            if (grabInteractable != null)
            {
                grabInteractable.selectEntered.AddListener(OnGrab);
                grabInteractable.selectExited.AddListener(OnDrop);
                grabInteractable.throwOnDetach = true;
                grabInteractable.throwSmoothingDuration = 0.25f;
            }

            audioSource = GetComponent<AudioSource>();
            if (audioSource == null && (grabSound != null || dropSound != null))
            {
                audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.spatialBlend = 1f;
                audioSource.playOnAwake = false;
            }

            if (!gameObject.CompareTag("WhiteRice"))
            {
                try
                {
                    gameObject.tag = "WhiteRice";
                }
                catch
                {
                    // Tag fallback
                }
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
            OnGrabbed?.Invoke(this);
            Debug.Log($"[WhiteRiceItem] Đã nhặt thúng gạo trắng ({riceAmount} phần) lên tay!");
        }

        private void OnDrop(SelectExitEventArgs args)
        {
            PlaySound(dropSound);
            OnDropped?.Invoke(this);
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
