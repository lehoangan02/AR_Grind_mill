using UnityEngine;

namespace Khoa.Farming
{
    /// <summary>Marker for a clean water volume that can fill a dipper.</summary>
    [RequireComponent(typeof(Collider))]
    public sealed class WaterSource : MonoBehaviour
    {
        private void Awake()
        {
            Collider sourceCollider = GetComponent<Collider>();
            sourceCollider.isTrigger = true;
        }
    }
}
