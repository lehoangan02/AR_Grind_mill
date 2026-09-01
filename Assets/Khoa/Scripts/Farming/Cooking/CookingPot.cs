using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Khoa.Farming
{
    /// <summary>
    /// Các trạng thái nấu của Nồi Gang Cơm.
    /// </summary>
    public enum CookingState
    {
        Empty,          // Nồi rỗng
        HasRice,        // Có gạo đã vo, chưa có đủ nước
        ReadyToCook,    // Đã có cả gạo vo và nước đong chuẩn, đậy nắp sẵn sàng đun
        Boiling,        // Đang sôi sùng sục trên bếp củi
        Cooked,         // Cơm đã chín tới thơm phức
        Burnt           // Đun quá lâu bị cháy khét
    }

    /// <summary>
    /// Nồi gang nấu cơm truyền thống miền Tây (Cooking Pot).
    /// Hỗ trợ:
    /// - Nhận gạo đã vo sạch (WhiteRiceItem với isWashed == true) và nước từ gáo múc (WaterDipper).
    /// - Đậy/mở nắp vung (PotLid).
    /// - Đặt lên bếp củi đang cháy (WoodStove) -> tự động hấp thu nhiệt và chuyển trạng thái đun sôi -> chín cơm.
    /// - Hiệu ứng bốc hơi nghi ngút (Steam FX), nắp nồi rung lục bục, âm thanh sôi.
    /// - Xới cơm ra bát cơm nóng (CookedRiceBowl).
    /// </summary>
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(XRGrabInteractable))]
    public class CookingPot : MonoBehaviour, IWaterReceiver
    {
        public const int RequiredRiceAmount = 10;
        public const float RequiredWaterAmount = 1f;
        public const float WaterTolerance = 0.05f;

        [Header("State")]
        public CookingState currentState = CookingState.Empty;

        [Header("Ingredients")]
        [Tooltip("Số phần gạo hiện có trong nồi")]
        public int currentRiceAmount = 0;

        [Tooltip("Lượng nước hiện có trong nồi (cần ít nhất 1.0 để nấu)")]
        public float currentWaterAmount = 0f;
        [Min(1f)] public float maxWaterCapacity = 2f;

        [Tooltip("Nắp vung hiện tại có đang đậy trên nồi hay không")]
        public bool isLidClosed = true;

        [Header("Cooking Progression")]
        [Tooltip("Tiến độ nấu cơm (giây đun nóng)")]
        public float cookingTimer = 0f;

        [Tooltip("Thời gian đun sôi để cơm chín (giây)")]
        public float timeToCook = 15f;

        [Tooltip("Thời gian quá nhiệt làm cơm bị cháy (giây)")]
        public float timeToBurn = 40f;

        [Header("Visual & FX Elements")]
        [Tooltip("Visual hạt gạo/cơm trong lòng nồi")]
        public GameObject riceMeshVisual;
        public Material rawRiceMaterial;
        public Material cookedRiceMaterial;

        [Tooltip("Visual mặt nước trong nồi")]
        public GameObject waterSurfaceVisual;

        [Tooltip("Hiệu ứng hơi nước bốc lên khi sôi và khi cơm chín")]
        public ParticleSystem steamParticleFX;

        [Tooltip("Vị trí nắp vung nồi")]
        public Transform lidSnapPoint;

        [Header("Audio")]
        public AudioSource audioSource;
        public AudioClip boilingSound;
        public AudioClip whistleSound;
        public AudioClip riceCookedSound;

        [Header("Output Settings")]
        [Tooltip("Prefab Bát cơm nóng (CookedRiceBowl) sinh ra khi xới cơm")]
        public GameObject cookedRiceBowlPrefab;

        // Events
        public event Action<CookingState> OnCookingStateChanged;
        public event Action<float> OnCookingProgressChanged;
        public event Action<CookedRiceBowl> OnRiceServed;
        public event Action<string> OnFeedback;

        private Rigidbody rb;
        private XRGrabInteractable grabInteractable;
        private bool isOnFire = false;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            grabInteractable = GetComponent<XRGrabInteractable>();

            if (rb != null)
            {
                rb.mass = 1.5f;
                rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                rb.interpolation = RigidbodyInterpolation.Interpolate;
            }

            if (grabInteractable != null)
            {
                grabInteractable.throwOnDetach = true;
                grabInteractable.throwSmoothingDuration = 0.2f;
            }

            if (audioSource == null)
            {
                audioSource = GetComponent<AudioSource>();
                if (audioSource == null)
                {
                    audioSource = gameObject.AddComponent<AudioSource>();
                    audioSource.spatialBlend = 1f;
                    audioSource.playOnAwake = false;
                }
            }
            if (audioSource != null)
            {
                audioSource.playOnAwake = false;
                audioSource.spatialBlend = 1f;
            }

            UpdateVisuals();
        }

        private void Update()
        {
            bool canCook = isOnFire && isLidClosed;

            if (canCook && (currentState == CookingState.ReadyToCook || currentState == CookingState.Boiling))
            {
                cookingTimer += Time.deltaTime;
                float progressRatio = Mathf.Clamp01(cookingTimer / Mathf.Max(0.01f, timeToCook));
                OnCookingProgressChanged?.Invoke(progressRatio);

                if (currentState != CookingState.Boiling && cookingTimer >= 3f)
                {
                    currentState = CookingState.Boiling;
                    OnCookingStateChanged?.Invoke(currentState);

                    if (steamParticleFX != null && !steamParticleFX.isPlaying)
                    {
                        steamParticleFX.Play();
                    }

                    if (audioSource != null && boilingSound != null && !audioSource.isPlaying)
                    {
                        audioSource.clip = boilingSound;
                        audioSource.loop = true;
                        audioSource.Play();
                    }
                }

                if (cookingTimer >= timeToCook)
                {
                    CompleteCooking();
                }
            }
            else if (canCook && currentState == CookingState.Cooked)
            {
                cookingTimer += Time.deltaTime;
                if (cookingTimer >= timeToBurn)
                {
                    BurnRice();
                }
            }
            else if (!canCook && currentState == CookingState.Boiling)
            {
                if (audioSource != null && audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
                if (steamParticleFX != null && steamParticleFX.isPlaying)
                {
                    steamParticleFX.Stop();
                }
            }
        }

        /// <summary>
        /// Thêm gạo đã vo vào nồi cơm.
        /// </summary>
        public bool AddRice(WhiteRiceItem rice)
        {
            if (rice == null)
            {
                ReportFeedback("Chưa có gạo để cho vào nồi.");
                return false;
            }
            if (!rice.isWashed)
            {
                Debug.LogWarning("[CookingPot] Chỉ nhận gạo đã vo sạch.");
                ReportFeedback("Gạo chưa vo sạch nên chưa thể nấu.");
                return false;
            }
            if (rice.riceAmount != RequiredRiceAmount)
            {
                Debug.LogWarning($"[CookingPot] Một mẻ cần đúng {RequiredRiceAmount} phần gạo.");
                ReportFeedback($"Một mẻ cần đúng {RequiredRiceAmount} phần gạo.");
                return false;
            }
            if (currentState != CookingState.Empty || currentRiceAmount != 0)
            {
                Debug.LogWarning("[CookingPot] Nồi đã có một mẻ gạo; không thể thêm mẻ thứ hai.");
                ReportFeedback("Nồi đã có đủ một mẻ gạo.");
                return false;
            }

            if (currentWaterAmount > RequiredWaterAmount + WaterTolerance)
            {
                Debug.LogWarning("[CookingPot] Nồi đang có quá nhiều nước cho một mẻ gạo.");
                ReportFeedback("Nồi đang có quá nhiều nước cho mẻ gạo này.");
                return false;
            }

            currentRiceAmount = rice.riceAmount;
            if (HasValidRecipe())
            {
                currentState = CookingState.ReadyToCook;
            }
            else
            {
                currentState = CookingState.HasRice;
            }

            if (Application.isPlaying)
                Destroy(rice.gameObject);
            else
                DestroyImmediate(rice.gameObject);

            UpdateVisuals();
            OnCookingStateChanged?.Invoke(currentState);
            Debug.Log($"<color=white>[CookingPot] Đã cho gạo vào nồi (Số lượng: {currentRiceAmount}).</color>");
            return true;
        }

        /// <summary>
        /// Đong nước vào nồi nấu cơm.
        /// </summary>
        public void AddWater(float amount)
        {
            TryAddWater(amount);
        }

        public bool TryAddWater(float amount)
        {
            if (amount <= 0f ||
                (currentState != CookingState.Empty && currentState != CookingState.HasRice && currentState != CookingState.ReadyToCook))
            {
                return false;
            }

            float recipeCapacity = Mathf.Min(maxWaterCapacity, RequiredWaterAmount + WaterTolerance);
            float proposedAmount = currentWaterAmount + amount;
            if (proposedAmount > recipeCapacity + Mathf.Epsilon)
            {
                Debug.LogWarning($"[CookingPot] Một mẻ chỉ nhận {RequiredWaterAmount:F1} nước; nước không được rót vào nồi.");
                ReportFeedback($"Một mẻ chỉ cần {RequiredWaterAmount:F1} gáo nước.");
                return false;
            }

            currentWaterAmount = proposedAmount;

            if (currentRiceAmount > 0)
            {
                CookingState nextState = HasValidRecipe() ? CookingState.ReadyToCook : CookingState.HasRice;
                if (currentState != nextState)
                {
                    currentState = nextState;
                    OnCookingStateChanged?.Invoke(currentState);
                }
            }

            UpdateVisuals();
            Debug.Log($"<color=cyan>[CookingPot] Đã đong nước vào nồi (Nước: {currentWaterAmount:F1}).</color>");
            return true;
        }

        /// <summary>
        /// Đặt hoặc nhấc nồi khỏi bếp lửa đang cháy.
        /// </summary>
        public void SetHeatSource(bool onFire)
        {
            if (isOnFire == onFire) return;
            isOnFire = onFire;
            Debug.Log($"[CookingPot] Trạng thái tiếp xúc nhiệt bếp củi: {isOnFire}");
            if (!isOnFire) return;

            if (currentRiceAmount <= 0)
            {
                ReportFeedback("Nồi chưa có gạo đã vo.");
            }
            else if (currentWaterAmount < RequiredWaterAmount)
            {
                ReportFeedback("Nồi còn thiếu nước để nấu cơm.");
            }
            else if (!isLidClosed)
            {
                ReportFeedback("Hãy đậy nắp nồi để bắt đầu nấu.");
            }
        }

        /// <summary>
        /// Hoàn tất nấu cơm chín tới.
        /// </summary>
        public void CompleteCooking()
        {
            if ((currentState != CookingState.ReadyToCook && currentState != CookingState.Boiling) ||
                !isOnFire || !isLidClosed || !HasValidRecipe() || cookingTimer < timeToCook)
            {
                return;
            }

            currentState = CookingState.Cooked;
            cookingTimer = Mathf.Max(cookingTimer, timeToCook);
            currentWaterAmount = 0f; // Nước đã ngấm hết vào cơm

            if (audioSource != null)
            {
                audioSource.Stop();
                if (riceCookedSound != null)
                {
                    audioSource.PlayOneShot(riceCookedSound);
                }
            }

            UpdateVisuals();
            OnCookingStateChanged?.Invoke(currentState);
            Debug.Log("<color=green>[CookingPot] 🍚 Cơm gang đã chín tới thơm lừng mùi gạo mới! Mở nắp xới cơm thôi!</color>");
        }

        /// <summary>
        /// Cơm bị khét do đun quá lâu.
        /// </summary>
        public void BurnRice()
        {
            if (currentState != CookingState.Cooked || !isOnFire || !isLidClosed || cookingTimer < timeToBurn)
            {
                return;
            }

            currentState = CookingState.Burnt;
            UpdateVisuals();
            OnCookingStateChanged?.Invoke(currentState);
            Debug.LogWarning("[CookingPot] ⚠️ Cơm đun quá lâu đã bị cháy khét dưới đáy nồi!");
        }

        /// <summary>
        /// Xới cơm từ nồi ra bát.
        /// </summary>
        public CookedRiceBowl ServeRiceBowl()
        {
            if (currentState != CookingState.Cooked && currentState != CookingState.Burnt)
            {
                Debug.LogWarning("[CookingPot] Cơm chưa chín, chưa thể xới cơm!");
                ReportFeedback("Cơm chưa chín nên chưa thể xới.");
                return null;
            }
            if (isLidClosed)
            {
                Debug.LogWarning("[CookingPot] Hãy mở nắp nồi trước khi xới cơm.");
                ReportFeedback("Hãy mở nắp nồi trước khi xới cơm.");
                return null;
            }
            if (currentRiceAmount <= 0)
            {
                return null;
            }

            bool servedBurntRice = currentState == CookingState.Burnt;

            Vector3 spawnPos = transform.position + Vector3.up * 0.25f + transform.right * 0.2f;
            CookedRiceBowl bowl = null;

            if (cookedRiceBowlPrefab != null)
            {
                GameObject bowlGO = Instantiate(cookedRiceBowlPrefab, spawnPos, Quaternion.identity);
                bowl = bowlGO.GetComponent<CookedRiceBowl>();
            }
            else
            {
                GameObject fallbackBowl = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                fallbackBowl.name = "Cooked_Rice_Bowl";
                fallbackBowl.transform.position = spawnPos;
                fallbackBowl.transform.localScale = new Vector3(0.2f, 0.15f, 0.2f);

                Renderer ren = fallbackBowl.GetComponent<Renderer>();
                if (ren != null)
                {
                    if (Application.isPlaying) ren.material.color = Color.white;
                    else if (ren.sharedMaterial != null) ren.sharedMaterial.color = Color.white;
                }

                fallbackBowl.AddComponent<Rigidbody>();
                fallbackBowl.AddComponent<XRGrabInteractable>();
                bowl = fallbackBowl.AddComponent<CookedRiceBowl>();
            }

            if (bowl != null)
            {
                bowl.SetBurnt(servedBurntRice);
                currentRiceAmount = 0;
                currentWaterAmount = 0f;
                cookingTimer = 0f;
                currentState = CookingState.Empty;
                UpdateVisuals();
                OnCookingStateChanged?.Invoke(currentState);
                OnRiceServed?.Invoke(bowl);
                Debug.Log(servedBurntRice
                    ? "<color=red>[CookingPot] Đã xới ra một bát cơm bị cháy khét.</color>"
                    : "<color=yellow>[CookingPot] 🍲 Đã xới ra 1 bát cơm trắng thơm dẻo!</color>");
            }

            return bowl;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other == null) return;

            if (other.TryGetComponent<WhiteRiceItem>(out var rice))
            {
                AddRice(rice);
            }
        }

        private void UpdateVisuals()
        {
            if (riceMeshVisual != null)
            {
                riceMeshVisual.SetActive(currentRiceAmount > 0);
                Renderer rRen = riceMeshVisual.GetComponent<Renderer>();
                if (rRen != null)
                {
                    if ((currentState == CookingState.Cooked || currentState == CookingState.Burnt) && cookedRiceMaterial != null)
                    {
                        rRen.sharedMaterial = cookedRiceMaterial;
                    }
                    else if (rawRiceMaterial != null)
                    {
                        rRen.sharedMaterial = rawRiceMaterial;
                    }
                }
            }

            if (waterSurfaceVisual != null)
            {
                waterSurfaceVisual.SetActive(currentWaterAmount > 0.05f);
            }
        }

        private bool HasValidRecipe()
        {
            return currentRiceAmount == RequiredRiceAmount &&
                   currentWaterAmount >= RequiredWaterAmount &&
                   currentWaterAmount <= RequiredWaterAmount + WaterTolerance;
        }

        private void ReportFeedback(string message)
        {
            OnFeedback?.Invoke(message);
        }
    }
}
