using UnityEngine;

namespace Khoa.Farming
{
    /// <summary>Lives on the hopper trigger and forwards typed paddy sources to its mill.</summary>
    [RequireComponent(typeof(Collider))]
    public sealed class GrindMillHopperReceiver : MonoBehaviour
    {
        [SerializeField] private GrindMillStation station;

        public void Configure(GrindMillStation targetStation)
        {
            station = targetStation;
            Collider trigger = GetComponent<Collider>();
            trigger.isTrigger = true;
        }

        private void Awake()
        {
            if (station == null) station = GetComponentInParent<GrindMillStation>();
            GetComponent<Collider>().isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (station == null || other == null) return;
            MonoBehaviour[] candidates = other.GetComponentsInParent<MonoBehaviour>();
            foreach (MonoBehaviour candidate in candidates)
            {
                if (candidate is IPaddySource source)
                {
                    station.TryLoadPaddy(source);
                    return;
                }
            }
        }
    }
}
