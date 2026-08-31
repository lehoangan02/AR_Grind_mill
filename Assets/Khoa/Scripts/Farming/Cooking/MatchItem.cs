using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Khoa.Farming
{
    /// <summary>
    /// Que diêm / Bật lửa mồi lửa (Match / Lighter).
    /// Dùng để châm lửa cho bếp củi (WoodStove).
    /// Hỗ trợ cầm nắm bằng XRGrabInteractable, quẹt lửa và tự tàn sau thời gian cháy.
    /// </summary>
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(XRGrabInteractable))]
    public class MatchItem : MonoBehaviour
    {
        [Header("State")]
        [Tooltip("Que diêm có đang cháy lửa hay không")]
        public bool isLit = false;

        [Tooltip("Thời gian cháy của que diêm (giây)")]
        public float burnDuration = 15f;

        [Header("Visual & FX")]
        [Tooltip("Đốm lửa trên đầu que diêm")]
        public ParticleSystem flameFX;

        [Tooltip("Âm thanh quẹt diêm / tiếng lửa cháy")]
        public AudioSource audioSource;
        public AudioClip strikeSound;

        private float currentBurnTimer = 0f;
        private Rigidbody rb;
        private XRGrabInteractable grabInteractable;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            grabInteractable = GetComponent<XRGrabInteractable>();

            if (rb != null)
            {
                rb.mass = 0.1f;
                rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                rb.interpolation = RigidbodyInterpolation.Interpolate;
            }

            if (audioSource == null)
            {
                audioSource = GetComponent<AudioSource>();
            }

            UpdateVisuals();
        }

        private void Update()
        {
            if (isLit)
            {
                currentBurnTimer += Time.deltaTime;
                if (currentBurnTimer >= burnDuration)
                {
                    Extinguish();
                }
            }
        }

        /// <summary>
        /// Quẹt diêm bén lửa.
        /// </summary>
        public void StrikeMatch()
        {
            if (isLit) return;

            isLit = true;
            currentBurnTimer = 0f;

            if (audioSource != null && strikeSound != null)
            {
                audioSource.PlayOneShot(strikeSound);
            }

            UpdateVisuals();
            Debug.Log("<color=red>[MatchItem] 🔥 Đã quẹt que diêm bùng cháy!</color>");
        }

        /// <summary>
        /// Dập tắt que diêm.
        /// </summary>
        public void Extinguish()
        {
            isLit = false;
            UpdateVisuals();
            Debug.Log("[MatchItem] Que diêm đã tàn.");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other == null) return;

            // Quẹt vào bao diêm hoặc vật cứng để đánh lửa
            if (!isLit && (other.name.Contains("Box") || other.name.Contains("Striker") || other.CompareTag("Interactable")))
            {
                StrikeMatch();
            }
        }

        private void UpdateVisuals()
        {
            if (flameFX != null)
            {
                if (isLit && !flameFX.isPlaying)
                    flameFX.Play();
                else if (!isLit && flameFX.isPlaying)
                    flameFX.Stop();
            }
        }
    }
}
