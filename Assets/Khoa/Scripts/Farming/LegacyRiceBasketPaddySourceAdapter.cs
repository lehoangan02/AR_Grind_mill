using System.Reflection;
using UnityEngine;

namespace Khoa.Farming
{
    /// <summary>
    /// Keeps Khoa's assembly independent from the legacy Assembly-CSharp basket while exposing
    /// its public IsFull/SetFull API as a transactional paddy source.
    /// </summary>
    public sealed class LegacyRiceBasketPaddySourceAdapter : MonoBehaviour, IPaddySource
    {
        [SerializeField] private MonoBehaviour legacyBasket;
        private MethodInfo isFullMethod;
        private MethodInfo setFullMethod;

        public bool HasPaddy
        {
            get
            {
                ResolveApi();
                return legacyBasket != null && isFullMethod != null && (bool)isFullMethod.Invoke(legacyBasket, null);
            }
        }

        public bool TryConsumePaddy()
        {
            ResolveApi();
            if (!HasPaddy || setFullMethod == null) return false;
            setFullMethod.Invoke(legacyBasket, new object[] { false });
            return !HasPaddy;
        }

        private void ResolveApi()
        {
            if (legacyBasket == null)
            {
                foreach (MonoBehaviour behaviour in GetComponents<MonoBehaviour>())
                {
                    if (behaviour != null && behaviour.GetType().Name == "RiceBasketController")
                    {
                        legacyBasket = behaviour;
                        break;
                    }
                }
            }

            if (legacyBasket == null) return;
            System.Type type = legacyBasket.GetType();
            isFullMethod ??= type.GetMethod("IsFull", BindingFlags.Instance | BindingFlags.Public, null, System.Type.EmptyTypes, null);
            setFullMethod ??= type.GetMethod("SetFull", BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(bool) }, null);
        }
    }
}
