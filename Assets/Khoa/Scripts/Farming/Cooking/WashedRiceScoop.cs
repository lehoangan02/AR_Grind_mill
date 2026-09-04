using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Khoa.Farming
{
    /// <summary>Grip to hold, controller trigger to transfer one drained washed-rice batch.</summary>
    [RequireComponent(typeof(BoxCollider), typeof(Rigidbody), typeof(XRGrabInteractable))]
    public sealed class WashedRiceScoop : MonoBehaviour
    {
        private XRGrabInteractable grabInteractable;
        private RiceWashingPot overlappingPot;
        private readonly Dictionary<RiceWashingPot, HashSet<int>> potContacts = new Dictionary<RiceWashingPot, HashSet<int>>();

        private void Awake()
        {
            grabInteractable = GetComponent<XRGrabInteractable>();
            grabInteractable.activated.AddListener(OnActivated);
            Rigidbody body = GetComponent<Rigidbody>();
            body.mass = 0.2f;
            body.interpolation = RigidbodyInterpolation.Interpolate;
            body.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }

        private void OnDestroy()
        {
            if (grabInteractable != null) grabInteractable.activated.RemoveListener(OnActivated);
        }

        private void OnDisable()
        {
            potContacts.Clear();
            overlappingPot = null;
        }

        private void Update()
        {
            if (overlappingPot != null && CookingDevInputMap.WasExtractWashedRicePressed(Keyboard.current))
            {
                TryExtract(overlappingPot);
            }
        }

        public WhiteRiceItem TryExtract(RiceWashingPot pot)
        {
            return pot != null ? pot.TakeOutWashedRice() : null;
        }

        private void OnActivated(ActivateEventArgs args)
        {
            TryExtract(overlappingPot);
        }

        private void OnTriggerStay(Collider other) => Track(other);
        private void OnCollisionStay(Collision collision) => Track(collision != null ? collision.collider : null);

        private void Track(Collider other)
        {
            RiceWashingPot pot = other != null ? other.GetComponentInParent<RiceWashingPot>() : null;
            if (pot == null) return;
            if (!potContacts.TryGetValue(pot, out HashSet<int> contacts))
            {
                contacts = new HashSet<int>();
                potContacts.Add(pot, contacts);
            }
            contacts.Add(other.GetInstanceID());
            overlappingPot = pot;
        }

        private void OnTriggerExit(Collider other) => Clear(other);
        private void OnCollisionExit(Collision collision) => Clear(collision != null ? collision.collider : null);

        private void Clear(Collider other)
        {
            RiceWashingPot pot = other != null ? other.GetComponentInParent<RiceWashingPot>() : null;
            if (pot == null || !potContacts.TryGetValue(pot, out HashSet<int> contacts)) return;
            contacts.Remove(other.GetInstanceID());
            if (contacts.Count > 0) return;
            potContacts.Remove(pot);
            if (pot != overlappingPot) return;
            overlappingPot = null;
            foreach (RiceWashingPot remaining in potContacts.Keys)
            {
                if (remaining != null)
                {
                    overlappingPot = remaining;
                    break;
                }
            }
        }
    }
}
