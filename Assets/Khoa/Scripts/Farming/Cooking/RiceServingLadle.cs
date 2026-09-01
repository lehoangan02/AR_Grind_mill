using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Khoa.Farming
{
    /// <summary>
    /// Physical serving ladle. Grip selects/grabs it; controller trigger activates a scoop.
    /// Keyboard E provides the same action while the ladle overlaps a pot in simulator mode.
    /// </summary>
    [RequireComponent(typeof(BoxCollider), typeof(Rigidbody), typeof(XRGrabInteractable))]
    public sealed class RiceServingLadle : MonoBehaviour
    {
        private XRGrabInteractable grabInteractable;
        private CookingPot overlappingPot;

        private void Awake()
        {
            grabInteractable = GetComponent<XRGrabInteractable>();
            grabInteractable.activated.AddListener(OnActivated);
            Rigidbody body = GetComponent<Rigidbody>();
            body.mass = 0.25f;
            body.interpolation = RigidbodyInterpolation.Interpolate;
            body.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }

        private void OnDestroy()
        {
            if (grabInteractable != null) grabInteractable.activated.RemoveListener(OnActivated);
        }

        private void Update()
        {
            if (overlappingPot != null && CookingDevInputMap.WasServeCookedRicePressed(Keyboard.current))
            {
                TryServe(overlappingPot);
            }
        }

        public CookedRiceBowl TryServe(CookingPot pot)
        {
            return pot != null ? pot.ServeRiceBowl() : null;
        }

        private void OnActivated(ActivateEventArgs args)
        {
            TryServe(overlappingPot);
        }

        private void OnTriggerStay(Collider other)
        {
            TrackPot(other);
        }

        private void OnCollisionStay(Collision collision)
        {
            TrackPot(collision != null ? collision.collider : null);
        }

        private void TrackPot(Collider other)
        {
            if (other == null) return;
            CookingPot pot = other.GetComponentInParent<CookingPot>();
            if (pot != null) overlappingPot = pot;
        }

        private void OnTriggerExit(Collider other)
        {
            ClearPot(other);
        }

        private void OnCollisionExit(Collision collision)
        {
            ClearPot(collision != null ? collision.collider : null);
        }

        private void ClearPot(Collider other)
        {
            CookingPot pot = other != null ? other.GetComponentInParent<CookingPot>() : null;
            if (pot != null && pot == overlappingPot) overlappingPot = null;
        }
    }
}
