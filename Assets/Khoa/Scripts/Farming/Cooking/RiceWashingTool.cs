using UnityEngine;

namespace Khoa.Farming
{
    /// <summary>
    /// Identifies a physical washing tool. Progress comes from its path through the basin,
    /// never from its name or a single trigger-enter callback.
    /// </summary>
    public sealed class RiceWashingTool : MonoBehaviour
    {
        private void OnTriggerStay(Collider other)
        {
            RiceWashingPot pot = other.GetComponentInParent<RiceWashingPot>();
            if (pot != null)
            {
                pot.RecordStirPoint(transform.position, Time.time);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            RiceWashingPot pot = other.GetComponentInParent<RiceWashingPot>();
            if (pot != null)
            {
                pot.EndStirGesture();
            }
        }
    }
}
