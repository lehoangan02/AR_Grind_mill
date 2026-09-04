using System;
using System.Reflection;
using UnityEngine;

namespace Khoa.Farming
{
    /// <summary>
    /// Bộ nhận & kết nối thóc từ Cối tuốt lúa (RiceThresher) sang Giỏ lúa (RiceBasket) và Túi đồ (Inventory).
    /// Áp dụng cơ chế Loose Coupling (Reflection/Type Lookup) an toàn 100%, không gây xung đột code với đồng đội.
    /// </summary>
    [RequireComponent(typeof(RiceThresher))]
    public class RiceThresherBasketReceiver : MonoBehaviour
    {
        [Header("Basket Detection Settings")]
        [Tooltip("Bán kính tìm kiếm Giỏ lúa (RiceBasket) đặt cạnh cối tuốt")]
        [Min(0.5f)]
        public float basketSearchRadius = 2.5f;

        [Tooltip("Điểm đặt giỏ lúa ưu tiên (nếu có)")]
        public Transform basketSlotTransform;

        [Header("Inventory Integration")]
        [Tooltip("Tự động nạp thóc vào Giỏ lúa trong Inventory của người chơi nếu không có giỏ đặt cạnh")]
        public bool autoFillInventoryBasket = true;

        [Header("Physical Paddy Output")]
        [Tooltip("Typed paddy batch spawned when no nearby empty basket is available.")]
        public GameObject paddyBatchPrefab;
        public Transform paddyOutputPoint;

        [Header("Audio & FX")]
        [Tooltip("Âm thanh rót thóc vào giỏ")]
        public AudioClip fillBasketSound;

        // Sự kiện khi đổ đầy thóc vào giỏ thành công
        public event Action<GameObject> OnBasketFilled;
        public event Action<PaddyBatchItem> OnPaddyBatchCreated;

        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        /// <summary>
        /// Thử chuyển thóc vào giỏ vật lý hoặc giỏ trong inventory.
        /// Trả về true chỉ khi đầu ra đã nhận thóc, để cối tuốt quyết định có tiêu thụ bó lúa hay không.
        /// </summary>
        public bool TryReceiveGrain(int grainAmount)
        {
            if (grainAmount <= 0)
            {
                return false;
            }

            bool filled = false;

            // 1. Ưu tiên tìm giỏ lúa vật lý đặt gần cối tuốt
            GameObject nearbyBasket = FindNearbyEmptyBasket();
            if (nearbyBasket != null)
            {
                filled = FillPhysicalBasket(nearbyBasket);
            }

            // 2. Luôn ưu tiên một output vật lý có thể mang đến hopper mới.
            if (!filled && paddyBatchPrefab != null)
            {
                Vector3 position = paddyOutputPoint != null
                    ? paddyOutputPoint.position
                    : transform.position + transform.right * 0.8f + Vector3.up * 0.4f;
                GameObject batchObject = Instantiate(paddyBatchPrefab, position, Quaternion.identity);
                PaddyBatchItem batch = batchObject.GetComponent<PaddyBatchItem>();
                if (batch != null)
                {
                    batch.SetHasPaddy(true);
                    OnPaddyBatchCreated?.Invoke(batch);
                    filled = true;
                }
                else
                {
                    if (Application.isPlaying) Destroy(batchObject); else DestroyImmediate(batchObject);
                }
            }

            // 3. Compatibility fallback cho inventory cũ khi chưa cấu hình output vật lý.
            if (!filled && autoFillInventoryBasket)
            {
                filled = FillPlayerInventoryBasket();
            }

            if (filled)
            {
                PlaySound(fillBasketSound);
            }
            else
            {
                Debug.Log($"<color=yellow>[RiceThresher] Thu được {grainAmount} thóc, nhưng chưa có giỏ lúa (RiceBasket) rỗng nào gần đó để hứng.</color>");
            }

            return filled;
        }

        /// <summary>
        /// Tìm Giỏ lúa (RiceBasketController) rỗng trong phạm vi cối tuốt
        /// </summary>
        public GameObject FindNearbyEmptyBasket()
        {
            Vector3 searchCenter = basketSlotTransform != null ? basketSlotTransform.position : transform.position;
            Collider[] colliders = Physics.OverlapSphere(searchCenter, basketSearchRadius);

            foreach (var col in colliders)
            {
                if (col == null) continue;
                MonoBehaviour[] components = col.GetComponentsInParent<MonoBehaviour>();

                foreach (var comp in components)
                {
                    if (comp == null) continue;
                    if (comp.GetType().Name == "RiceBasketController")
                    {
                        if (!IsBasketFull(comp))
                        {
                            return comp.gameObject;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Đổ đầy thóc vào Giỏ lúa vật lý (RiceBasketController)
        /// </summary>
        public bool FillPhysicalBasket(GameObject basketGO)
        {
            if (basketGO == null) return false;

            MonoBehaviour[] components = basketGO.GetComponents<MonoBehaviour>();
            foreach (var comp in components)
            {
                if (comp != null && comp.GetType().Name == "RiceBasketController")
                {
                    MethodInfo setFullMethod = comp.GetType().GetMethod("SetFull", new Type[] { typeof(bool) });
                    if (setFullMethod != null)
                    {
                        setFullMethod.Invoke(comp, new object[] { true });
                        OnBasketFilled?.Invoke(basketGO);
                        Debug.Log($"<color=green>🌾 Đã đổ đầy thóc vàng vào Giỏ Lúa (RiceBasket) đặt cạnh cối tuốt!</color>");
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Nạp thóc vào Giỏ lúa trong Inventory của người chơi
        /// </summary>
        public bool FillPlayerInventoryBasket()
        {
            try
            {
                // Tìm Instance của InventoryController
                Type invType = Type.GetType("InventoryController, Assembly-CSharp");
                if (invType == null)
                {
                    // Fallback: Tìm qua Object trong Scene
                    MonoBehaviour[] allMonos = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
                    foreach (var mono in allMonos)
                    {
                        if (mono != null && mono.GetType().Name == "InventoryController")
                        {
                            invType = mono.GetType();
                            break;
                        }
                    }
                }

                if (invType == null) return false;

                PropertyInfo instanceProp = invType.GetProperty("instance", BindingFlags.Public | BindingFlags.Static);
                object invInstance = instanceProp != null ? instanceProp.GetValue(null) : null;
                if (invInstance == null) return false;

                // Lấy danh sách inventorySlots
                FieldInfo slotsField = invType.GetField("inventorySlots", BindingFlags.Public | BindingFlags.Instance);
                if (slotsField == null) return false;

                Array slots = slotsField.GetValue(invInstance) as Array;
                if (slots == null || slots.Length == 0) return false;

                // Duyệt qua các slot để tìm RiceBasketItemData chưa đầy
                foreach (var slot in slots)
                {
                    if (slot == null) continue;

                    MonoBehaviour slotMono = slot as MonoBehaviour;
                    if (slotMono == null) continue;

                    // Kiểm tra item trong slot
                    Component itemComponent = slotMono.GetComponentInChildren(Type.GetType("InventoryItem, Assembly-CSharp") ?? typeof(MonoBehaviour));
                    if (itemComponent == null) continue;

                    FieldInfo itemDataField = itemComponent.GetType().GetField("itemData", BindingFlags.Public | BindingFlags.Instance);
                    if (itemDataField == null) continue;

                    ScriptableObject itemData = itemDataField.GetValue(itemComponent) as ScriptableObject;
                    if (itemData != null && itemData.GetType().Name == "RiceBasketItemData")
                    {
                        MethodInfo isFullMethod = itemData.GetType().GetMethod("IsFull");
                        bool isFull = isFullMethod != null && (bool)isFullMethod.Invoke(itemData, null);

                        if (!isFull)
                        {
                            MethodInfo setFullMethod = itemData.GetType().GetMethod("SetFull", new Type[] { typeof(bool) });
                            if (setFullMethod != null)
                            {
                                setFullMethod.Invoke(itemData, new object[] { true });

                                // Cập nhật Sprite hiển thị trong túi đồ
                                MethodInfo getSpriteMethod = itemData.GetType().GetMethod("GetSprite", new Type[] { typeof(bool) });
                                Sprite filledSprite = getSpriteMethod != null ? (Sprite)getSpriteMethod.Invoke(itemData, new object[] { true }) : null;

                                MethodInfo setSpriteMethod = itemComponent.GetType().GetMethod("SetSprite", new Type[] { typeof(Sprite) });
                                if (setSpriteMethod != null && filledSprite != null)
                                {
                                    setSpriteMethod.Invoke(itemComponent, new object[] { filledSprite });
                                }

                                Debug.Log("<color=green>🌾 Đã nạp đầy thóc vàng vào Giỏ Lúa trong túi đồ (Inventory) của người chơi!</color>");
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogWarning($"[RiceThresherBasketReceiver] Lỗi khi kết nối Inventory: {ex.Message}");
            }

            return false;
        }

        private bool IsBasketFull(MonoBehaviour basket)
        {
            if (basket == null) return false;
            MethodInfo isFullMethod = basket.GetType().GetMethod("IsFull");
            if (isFullMethod != null)
            {
                return (bool)isFullMethod.Invoke(basket, null);
            }
            return false;
        }

        private void PlaySound(AudioClip clip)
        {
            if (clip != null && audioSource != null)
            {
                audioSource.PlayOneShot(clip);
            }
        }
    }
}
