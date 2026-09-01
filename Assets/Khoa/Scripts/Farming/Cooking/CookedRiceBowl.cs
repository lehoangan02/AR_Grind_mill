using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Khoa.Farming
{
    /// <summary>
    /// Bát cơm trắng nóng hổi thành phẩm từ nồi gang (Cooked Rice Bowl).
    /// Đánh dấu mốc hoàn tất trọn vẹn chuỗi vòng đời Nông nghiệp -> Xay xát -> Vo gạo -> Nấu cơm.
    /// Hỗ trợ cầm nắm bằng XRGrabInteractable trong VR.
    /// </summary>
    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(XRGrabInteractable))]
    public class CookedRiceBowl : MonoBehaviour
    {
        [Tooltip("Bát cơm này có bị cháy khét hay không")]
        public bool isBurnt = false;

        [Tooltip("Hiệu ứng khói bốc nghi ngút từ bát cơm nóng")]
        public ParticleSystem warmSteamFX;

        public AudioClip grabSound;
        public AudioClip eatSound;
        public Renderer riceRenderer;
        public Color normalRiceColor = new Color(0.98f, 0.98f, 0.95f, 1f);
        public Color burntRiceColor = new Color(0.22f, 0.08f, 0.03f, 1f);

        private Rigidbody rb;
        private XRGrabInteractable grabInteractable;
        private AudioSource audioSource;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            grabInteractable = GetComponent<XRGrabInteractable>();

            if (rb != null)
            {
                rb.mass = 0.3f;
                rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                rb.interpolation = RigidbodyInterpolation.Interpolate;
            }

            if (grabInteractable != null)
            {
                grabInteractable.throwOnDetach = true;
                grabInteractable.throwSmoothingDuration = 0.2f;
            }

            audioSource = GetComponent<AudioSource>();
            if (riceRenderer == null) riceRenderer = GetComponentInChildren<Renderer>();
            ApplyAppearance();

            if (warmSteamFX != null && !warmSteamFX.isPlaying)
            {
                warmSteamFX.Play();
            }
        }

        public void SetBurnt(bool burnt)
        {
            isBurnt = burnt;
            ApplyAppearance();
        }

        private void ApplyAppearance()
        {
            if (riceRenderer == null) riceRenderer = GetComponentInChildren<Renderer>();
            if (riceRenderer == null) return;
            MaterialPropertyBlock block = new MaterialPropertyBlock();
            riceRenderer.GetPropertyBlock(block);
            Color color = isBurnt ? burntRiceColor : normalRiceColor;
            block.SetColor("_BaseColor", color);
            block.SetColor("_Color", color);
            riceRenderer.SetPropertyBlock(block);
        }
    }
}
