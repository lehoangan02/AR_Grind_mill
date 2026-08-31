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

            if (warmSteamFX != null && !warmSteamFX.isPlaying)
            {
                warmSteamFX.Play();
            }
        }
    }
}
