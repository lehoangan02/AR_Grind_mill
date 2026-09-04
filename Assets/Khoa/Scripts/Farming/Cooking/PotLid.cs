using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Khoa.Farming
{
    /// <summary>
    /// Nắp vung nồi gang (Pot Lid).
    /// Người chơi có thể cầm nắm bằng XRGrabInteractable để mở hoặc đậy nắp nồi cơm.
    /// </summary>
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(XRGrabInteractable))]
    public class PotLid : MonoBehaviour
    {
        [Tooltip("Nồi cơm liên kết")]
        public CookingPot attachedPot;

        public AudioClip openSound;
        public AudioClip closeSound;
        [Min(0.05f)] public float maxSnapDistance = 0.22f;
        [Range(1f, 90f)] public float maxSnapAngle = 30f;

        private Rigidbody rb;
        private XRGrabInteractable grabInteractable;
        private AudioSource audioSource;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            grabInteractable = GetComponent<XRGrabInteractable>();

            if (rb != null)
            {
                rb.mass = 0.4f;
                rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                rb.interpolation = RigidbodyInterpolation.Interpolate;
            }

            if (grabInteractable != null)
            {
                grabInteractable.selectEntered.AddListener(OnLidGrabbed);
                grabInteractable.selectExited.AddListener(OnLidReleased);
                grabInteractable.throwOnDetach = true;
            }

            audioSource = GetComponent<AudioSource>();
        }

        private void OnDestroy()
        {
            if (grabInteractable != null)
            {
                grabInteractable.selectEntered.RemoveListener(OnLidGrabbed);
                grabInteractable.selectExited.RemoveListener(OnLidReleased);
            }
        }

        private void OnLidGrabbed(SelectEnterEventArgs args)
        {
            transform.SetParent(null);
            if (rb != null)
            {
                rb.isKinematic = false;
            }

            if (attachedPot != null)
            {
                attachedPot.isLidClosed = false;
            }

            if (audioSource != null && openSound != null)
            {
                audioSource.PlayOneShot(openSound);
            }

            Debug.Log("[PotLid] Đã mở nắp vung nồi!");
        }

        private void OnLidReleased(SelectExitEventArgs args)
        {
            // Kiểm tra nếu thả gần miệng nồi thì tự động đậy nắp
            if (attachedPot != null)
            {
                if (CanSnapTo(attachedPot))
                {
                    SnapToPot(attachedPot);
                }
            }
        }

        public bool CanSnapTo(CookingPot pot)
        {
            if (pot == null || pot.lidSnapPoint == null || pot.lidSnapPoint == transform) return false;
            float distance = Vector3.Distance(transform.position, pot.lidSnapPoint.position);
            float angle = Quaternion.Angle(transform.rotation, pot.lidSnapPoint.rotation);
            return distance <= maxSnapDistance && angle <= maxSnapAngle;
        }

        public bool SnapToPot(CookingPot pot)
        {
            if (!CanSnapTo(pot)) return false;
            attachedPot = pot;
            if (pot != null)
            {
                transform.SetParent(pot.transform);

                if (pot.lidSnapPoint != null)
                {
                    transform.position = pot.lidSnapPoint.position;
                    transform.rotation = pot.lidSnapPoint.rotation;
                }
                else
                {
                    transform.localPosition = new Vector3(0f, 0.25f, 0f);
                    transform.localRotation = Quaternion.identity;
                }

                pot.isLidClosed = true;

                if (rb != null)
                {
                    rb.isKinematic = true;
                    rb.linearVelocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }

                if (audioSource != null && closeSound != null)
                {
                    audioSource.PlayOneShot(closeSound);
                }

                Debug.Log("[PotLid] Đã đậy nắp vung nồi khít chặt!");
                return true;
            }
            return false;
        }
    }
}
