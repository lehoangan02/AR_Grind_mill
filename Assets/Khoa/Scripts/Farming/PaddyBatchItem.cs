using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Khoa.Farming
{
    /// <summary>A physical, single-use batch of unprocessed paddy.</summary>
    [RequireComponent(typeof(BoxCollider), typeof(Rigidbody), typeof(XRGrabInteractable))]
    public sealed class PaddyBatchItem : MonoBehaviour, IPaddySource
    {
        [SerializeField] private bool hasPaddy = true;
        public bool HasPaddy => hasPaddy;

        private void Awake()
        {
            Rigidbody body = GetComponent<Rigidbody>();
            body.mass = 0.8f;
            body.interpolation = RigidbodyInterpolation.Interpolate;
            body.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }

        public bool TryConsumePaddy()
        {
            if (!hasPaddy) return false;
            hasPaddy = false;
            return true;
        }

        public void SetHasPaddy(bool value)
        {
            hasPaddy = value;
        }
    }
}
