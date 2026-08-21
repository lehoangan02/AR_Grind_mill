using System.Collections.Generic;
using UnityEngine;

namespace Khoa.Farming
{
    /// <summary>
    /// Khu vực có mái che / Nhà kho (Rice Shelter Zone).
    /// Khi đặt các bó lúa vào vùng này, bó lúa được bảo vệ an toàn trước trời mưa (không bị giảm độ khô).
    /// </summary>
    [RequireComponent(typeof(BoxCollider))]
    public class RiceShelterZone : MonoBehaviour
    {
        [Header("Sheltered Bundles")]
        [Tooltip("Danh sách các bó lúa đang được che chở trong khu vực")]
        public List<RiceBundleItem> shelteredBundles = new List<RiceBundleItem>();

        private void Awake()
        {
            BoxCollider col = GetComponent<BoxCollider>();
            if (col != null)
            {
                col.isTrigger = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other == null) return;

            RiceBundleItem bundle = other.GetComponent<RiceBundleItem>();
            if (bundle == null)
            {
                bundle = other.GetComponentInParent<RiceBundleItem>();
            }

            if (bundle != null && !shelteredBundles.Contains(bundle))
            {
                shelteredBundles.Add(bundle);
                bundle.isSheltered = true;
                Debug.Log($"<color=green>Đã đưa bó lúa vào khu vực có mái che an toàn!</color>");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other == null) return;

            RiceBundleItem bundle = other.GetComponent<RiceBundleItem>();
            if (bundle == null)
            {
                bundle = other.GetComponentInParent<RiceBundleItem>();
            }

            if (bundle != null && shelteredBundles.Contains(bundle))
            {
                shelteredBundles.Remove(bundle);
                bundle.isSheltered = false;
                Debug.Log($"Đã mang bó lúa ra ngoài khu vực có mái che.");
            }
        }
    }
}
