using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Khoa.Farming
{
    /// <summary>
    /// Thanh củi khô dùng để chụm vào bếp củi (WoodStove).
    /// Hỗ trợ cầm nắm bằng XRGrabInteractable, ném và thả vào buồng đốt của bếp.
    /// </summary>
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(XRGrabInteractable))]
    public class FirewoodItem : MonoBehaviour
    {
        [Tooltip("Giá trị nhiên liệu (thời gian cháy cung cấp cho bếp, giây)")]
        public float fuelValue = 30f;

        [Tooltip("Củi đã bị đốt cháy hết hay chưa")]
        public bool isBurntOut = false;

        public AudioClip grabSound;
        public AudioClip dropSound;

        private Rigidbody rb;
        private XRGrabInteractable grabInteractable;
        private AudioSource audioSource;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            grabInteractable = GetComponent<XRGrabInteractable>();

            if (rb != null)
            {
                rb.mass = 0.6f;
                rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                rb.interpolation = RigidbodyInterpolation.Interpolate;
            }

            if (grabInteractable != null)
            {
                grabInteractable.throwOnDetach = true;
                grabInteractable.throwSmoothingDuration = 0.2f;
            }

            audioSource = GetComponent<AudioSource>();
            if (!gameObject.CompareTag("Firewood"))
            {
                try
                {
                    gameObject.tag = "Firewood";
                }
                catch
                {
                    // Tag fallback
                }
            }
        }
    }
}
