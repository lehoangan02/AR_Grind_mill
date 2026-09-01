using System;
using System.Collections.Generic;
using UnityEngine;

namespace Khoa.Farming
{
    /// <summary>
    /// Bếp củi đất nung / Kiềng 3 chân truyền thống Nam Bộ (Wood Stove).
    /// Hỗ trợ:
    /// - Nhận củi khô (FirewoodItem) chụm vào buồng đốt (tối đa 4 thanh củi).
    /// - Nhận lửa từ que diêm (MatchItem) để nhóm bếp bùng cháy.
    /// - Hiệu ứng ngọn lửa bập bùng (Fire FX), than hồng, khói (Smoke FX) và âm thanh củi nổ lách tách.
    /// - Cung cấp nhiệt lượng nấu chín nồi cơm (CookingPot) đặt trên kiềng bếp.
    /// </summary>
    [RequireComponent(typeof(BoxCollider))]
    public class WoodStove : MonoBehaviour
    {
        [Header("State")]
        [Tooltip("Bếp củi có đang cháy lửa hay không")]
        public bool isBurning = false;

        [Tooltip("Số lượng thanh củi đang có trong buồng đốt")]
        public int currentFirewoodCount = 0;
        public const int MaxFirewoodCapacity = 4;

        [Tooltip("Tổng thời gian cháy còn lại (giây)")]
        public float remainingFuelTime = 0f;

        [Header("Visual & Audio FX")]
        [Tooltip("Hiệu ứng ngọn lửa bếp củi")]
        public ParticleSystem fireParticles;

        [Tooltip("Hiệu ứng khói bốc lên từ bếp")]
        public ParticleSystem smokeParticles;

        [Tooltip("Khối củi hiển thị trong buồng đốt")]
        public GameObject firewoodPileVisual;

        [Tooltip("Ánh sáng bập bùng của lửa")]
        public Light firePointLight;

        [Tooltip("Nguồn phát âm thanh tiếng củi nổ tí tách")]
        public AudioSource fireAudioSource;
        public AudioClip ignitionSound;

        [Header("Pot Placement")]
        [Tooltip("Vị trí kiềng đặt nồi cơm trên bếp")]
        public Transform potPlacementPoint;
        public CookingPot placedPot;
        private readonly Dictionary<CookingPot, HashSet<int>> potContacts = new Dictionary<CookingPot, HashSet<int>>();

        // Events
        public event Action<bool> OnFireStateChanged;
        public event Action<int> OnFirewoodAdded;

        private void Awake()
        {
            BoxCollider col = GetComponent<BoxCollider>();
            if (col != null)
            {
                col.isTrigger = true;
            }

            UpdateVisuals();
        }

        private void Update()
        {
            if (isBurning)
            {
                remainingFuelTime -= Time.deltaTime;

                // Ánh lửa bập bùng nhẹ
                if (firePointLight != null)
                {
                    firePointLight.intensity = Mathf.Lerp(firePointLight.intensity, UnityEngine.Random.Range(1.8f, 2.5f), Time.deltaTime * 10f);
                }

                // Cung cấp nhiệt cho nồi đặt trên bếp
                foreach (CookingPot pot in potContacts.Keys)
                {
                    if (pot != null) pot.SetHeatSource(true);
                }

                if (remainingFuelTime <= 0f)
                {
                    ExtinguishFire();
                }
            }
            else
            {
                foreach (CookingPot pot in potContacts.Keys)
                {
                    if (pot != null) pot.SetHeatSource(false);
                }
            }
        }

        /// <summary>
        /// Thêm củi khô vào buồng đốt.
        /// </summary>
        public bool AddFirewood(FirewoodItem wood)
        {
            if (wood == null) return false;
            if (currentFirewoodCount >= MaxFirewoodCapacity)
            {
                Debug.LogWarning("[WoodStove] Buồng đốt đã đầy củi!");
                return false;
            }

            currentFirewoodCount++;
            remainingFuelTime += wood.fuelValue;

            if (Application.isPlaying)
                Destroy(wood.gameObject);
            else
                DestroyImmediate(wood.gameObject);

            UpdateVisuals();
            OnFirewoodAdded?.Invoke(currentFirewoodCount);
            Debug.Log($"<color=orange>[WoodStove] Đã chụm thêm 1 thanh củi vào bếp (Tổng củi: {currentFirewoodCount}/{MaxFirewoodCapacity}).</color>");
            return true;
        }

        /// <summary>
        /// Nhóm lửa bếp củi bằng que diêm.
        /// </summary>
        public bool Ignite(MatchItem match)
        {
            if (isBurning) return true;
            if (match == null || !match.isLit)
            {
                Debug.LogWarning("[WoodStove] Cần một que diêm đang cháy để nhóm bếp.");
                return false;
            }
            if (currentFirewoodCount == 0)
            {
                Debug.LogWarning("[WoodStove] Chưa có củi trong bếp, không thể nhóm lửa!");
                return false;
            }

            isBurning = true;

            if (fireAudioSource != null && ignitionSound != null)
            {
                fireAudioSource.PlayOneShot(ignitionSound);
            }

            UpdateVisuals();
            OnFireStateChanged?.Invoke(isBurning);
            Debug.Log("<color=red>[WoodStove] 🔥 Bếp củi đã bùng cháy rực rỡ! Hãy đặt nồi cơm lên kiềng bếp để nấu.</color>");
            return true;
        }

        /// <summary>
        /// Dập tắt lửa bếp củi.
        /// </summary>
        public void ExtinguishFire()
        {
            isBurning = false;
            remainingFuelTime = 0f;
            currentFirewoodCount = 0;
            foreach (CookingPot pot in potContacts.Keys)
            {
                if (pot != null) pot.SetHeatSource(false);
            }

            UpdateVisuals();
            OnFireStateChanged?.Invoke(isBurning);
            Debug.Log("[WoodStove] Bếp củi đã tắt lửa.");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other == null) return;

            if (other.TryGetComponent<FirewoodItem>(out var wood) || (other.transform.parent != null && other.transform.parent.TryGetComponent(out wood)))
            {
                AddFirewood(wood);
            }
            else if (other.TryGetComponent<MatchItem>(out var match) || (other.transform.parent != null && other.transform.parent.TryGetComponent(out match)))
            {
                if (match.isLit)
                {
                    Ignite(match);
                }
            }
            else if (other.TryGetComponent<CookingPot>(out var pot) || (other.transform.parent != null && other.transform.parent.TryGetComponent(out pot)))
            {
                RegisterPotContact(pot, other.GetInstanceID());
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other == null) return;

            if (other.TryGetComponent<CookingPot>(out var pot) || (other.transform.parent != null && other.transform.parent.TryGetComponent(out pot)))
            {
                UnregisterPotContact(pot, other.GetInstanceID());
            }
        }

        public void RegisterPotContact(CookingPot pot, int colliderId)
        {
            if (pot == null) return;
            if (!potContacts.TryGetValue(pot, out HashSet<int> contacts))
            {
                contacts = new HashSet<int>();
                potContacts.Add(pot, contacts);
            }
            contacts.Add(colliderId);
            if (placedPot == null) placedPot = pot;
            if (isBurning) pot.SetHeatSource(true);
        }

        public void UnregisterPotContact(CookingPot pot, int colliderId)
        {
            if (pot == null || !potContacts.TryGetValue(pot, out HashSet<int> contacts)) return;
            contacts.Remove(colliderId);
            if (contacts.Count > 0) return;

            potContacts.Remove(pot);
            pot.SetHeatSource(false);
            if (placedPot == pot)
            {
                placedPot = null;
                foreach (CookingPot remaining in potContacts.Keys)
                {
                    if (remaining != null)
                    {
                        placedPot = remaining;
                        break;
                    }
                }
            }
        }

        private void UpdateVisuals()
        {
            if (fireParticles != null)
            {
                if (isBurning && !fireParticles.isPlaying) fireParticles.Play();
                else if (!isBurning && fireParticles.isPlaying) fireParticles.Stop();
            }

            if (smokeParticles != null)
            {
                if (isBurning && !smokeParticles.isPlaying) smokeParticles.Play();
                else if (!isBurning && smokeParticles.isPlaying) smokeParticles.Stop();
            }

            if (firePointLight != null)
            {
                firePointLight.enabled = isBurning;
            }

            if (fireAudioSource != null)
            {
                if (isBurning && !fireAudioSource.isPlaying) fireAudioSource.Play();
                else if (!isBurning && fireAudioSource.isPlaying) fireAudioSource.Stop();
            }

            if (firewoodPileVisual != null)
            {
                firewoodPileVisual.SetActive(currentFirewoodCount > 0);
            }
        }
    }
}
