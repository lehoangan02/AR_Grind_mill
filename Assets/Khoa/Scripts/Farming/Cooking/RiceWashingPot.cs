using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Khoa.Farming
{
    /// <summary>
    /// Các trạng thái trong chu trình Vo Gạo.
    /// </summary>
    public enum RiceWashingState
    {
        Empty,              // Thau rỗng
        HasRice,            // Đã đổ gạo trắng vào, chưa có nước
        HasRiceAndWater,    // Đã có gạo và nước trong veo
        Washing,            // Đang dùng tay vo/khuấy gạo trong nước
        WashedRiceReady     // Đã vo sạch và chắt ráo nước, gạo sẵn sàng đem nấu
    }

    /// <summary>
    /// Thau / Rá / Nồi Vo Gạo miền Tây (Rice Washing Pot / Basin).
    /// Hỗ trợ:
    /// - Nhận gạo trắng (WhiteRiceItem) và nước từ gáo múc nước (WaterDipper).
    /// - Tương tác chạm tay / khuấy vòng tròn để vo gạo.
    /// - Nước vo gạo chuyển dần sang màu trắng đục đặc trưng (Milky Rice Water FX).
    /// - Cầm thau nghiêng chắt nước ra ngoài -> sinh ra Gạo Sạch Đã Vo (Washed Rice).
    /// </summary>
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(XRGrabInteractable))]
    public class RiceWashingPot : MonoBehaviour
    {
        [Header("State")]
        public RiceWashingState currentState = RiceWashingState.Empty;

        [Header("Washing Progression")]
        [Tooltip("Tiến độ vo sạch hạt gạo (0 - 100%)")]
        [Range(0f, 100f)]
        public float washProgress = 0f;

        [Tooltip("Lượng nước hiện có trong thau")]
        public float currentWater = 0f;

        [Tooltip("Lượng gạo hiện có trong thau")]
        public int currentRiceAmount = 0;

        [Header("Visual & FX Elements")]
        [Tooltip("Khối gạo hiển thị trong thau")]
        public GameObject riceMeshVisual;

        [Tooltip("Mặt nước trong thau")]
        public Renderer waterSurfaceRenderer;

        [Tooltip("Màu nước lúc mới đổ vào (trong veo hơi ánh xanh)")]
        public Color clearWaterColor = new Color(0.7f, 0.9f, 1.0f, 0.5f);

        [Tooltip("Màu nước sau khi vo gạo (trắng đục nước vo gạo)")]
        public Color milkyWaterColor = new Color(0.95f, 0.95f, 0.92f, 0.9f);

        [Tooltip("Hiệu ứng nước đục chảy ra khi chắt nước")]
        public ParticleSystem drainWaterFX;

        [Header("Audio & Settings")]
        public AudioSource audioSource;
        public AudioClip washSound;
        public AudioClip drainSound;

        [Tooltip("Góc nghiêng để chắt nước (độ)")]
        [Range(30f, 90f)]
        public float drainTiltAngle = 45f;

        // Events
        public event Action<RiceWashingState> OnStateChanged;
        public event Action<float> OnWashProgressChanged;
        public event Action<WhiteRiceItem> OnRiceWashedCompleted;

        private Rigidbody rb;
        private XRGrabInteractable grabInteractable;
        private MaterialPropertyBlock mpb;
        private static readonly int BaseColorId = Shader.PropertyToID("_BaseColor");
        private static readonly int ColorId = Shader.PropertyToID("_Color");

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            grabInteractable = GetComponent<XRGrabInteractable>();

            if (rb != null)
            {
                rb.mass = 1.2f;
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

            mpb = new MaterialPropertyBlock();
            UpdateVisuals();
        }

        private void Update()
        {
            // Kiểm tra hành vi nghiêng thau chắt nước
            if (currentWater > 0.05f)
            {
                float tilt = Vector3.Angle(transform.up, Vector3.up);
                if (tilt >= drainTiltAngle)
                {
                    DrainWater();
                }
            }
        }

        /// <summary>
        /// Đổ gạo trắng vào thau vo gạo.
        /// </summary>
        public bool AddRice(WhiteRiceItem riceItem)
        {
            if (riceItem == null) return false;
            if (currentState == RiceWashingState.HasRice || currentState == RiceWashingState.HasRiceAndWater || currentState == RiceWashingState.WashedRiceReady)
            {
                return false;
            }

            currentRiceAmount = riceItem.riceAmount;
            if (currentWater > 0.05f)
            {
                currentState = RiceWashingState.HasRiceAndWater;
            }
            else
            {
                currentState = RiceWashingState.HasRice;
            }

            if (Application.isPlaying)
                Destroy(riceItem.gameObject);
            else
                DestroyImmediate(riceItem.gameObject);

            UpdateVisuals();
            OnStateChanged?.Invoke(currentState);
            Debug.Log($"<color=white>[RiceWashingPot] Đã cho {currentRiceAmount} phần gạo trắng vào thau!</color>");
            return true;
        }

        /// <summary>
        /// Thêm nước vào thau vo gạo.
        /// </summary>
        public void AddWater(float amount)
        {
            currentWater += amount;

            if (currentRiceAmount > 0)
            {
                if (currentState == RiceWashingState.HasRice || currentState == RiceWashingState.Empty)
                {
                    currentState = RiceWashingState.HasRiceAndWater;
                    OnStateChanged?.Invoke(currentState);
                }
            }

            UpdateVisuals();
            Debug.Log($"<color=cyan>[RiceWashingPot] Đã thêm nước vào thau (Tổng nước: {currentWater:F1}).</color>");
        }

        /// <summary>
        /// Thực hiện thao tác khuấy / vo gạo trong nước.
        /// </summary>
        public void StirRice(float amount = 15f)
        {
            if (currentState != RiceWashingState.HasRiceAndWater && currentState != RiceWashingState.Washing)
            {
                return;
            }

            currentState = RiceWashingState.Washing;
            washProgress = Mathf.Clamp(washProgress + amount, 0f, 100f);

            if (audioSource != null && washSound != null && !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(washSound);
            }

            UpdateVisuals();
            OnWashProgressChanged?.Invoke(washProgress);
            OnStateChanged?.Invoke(currentState);

            if (washProgress >= 100f)
            {
                Debug.Log("<color=yellow>[RiceWashingPot] 🌾 Gạo đã được vo sạch kỹ càng! Hãy nghiêng thau chắt nước vo gạo ra ngoài.</color>");
            }
        }

        /// <summary>
        /// Chắt nước vo gạo ra ngoài.
        /// </summary>
        public void DrainWater()
        {
            if (currentWater <= 0.05f) return;

            currentWater = 0f;

            if (drainWaterFX != null)
            {
                drainWaterFX.Play();
            }

            if (audioSource != null && drainSound != null)
            {
                audioSource.PlayOneShot(drainSound);
            }

            if (currentRiceAmount > 0 && washProgress >= 60f)
            {
                currentState = RiceWashingState.WashedRiceReady;
                Debug.Log("<color=green>[RiceWashingPot] ✨ Đã chắt ráo nước! Gạo sạch ngậm nước sẵn sàng cho vào nồi gang nấu cơm!</color>");
            }
            else if (currentRiceAmount > 0)
            {
                currentState = RiceWashingState.HasRice;
                Debug.Log("<color=yellow>[RiceWashingPot] Đã chắt nước. Gạo chưa vo đủ kỹ, bạn có thể thêm nước vo tiếp.</color>");
            }
            else
            {
                currentState = RiceWashingState.Empty;
            }

            UpdateVisuals();
            OnStateChanged?.Invoke(currentState);
        }

        /// <summary>
        /// Trích xuất gạo đã vo sạch ra vật phẩm WhiteRiceItem (isWashed = true).
        /// </summary>
        public WhiteRiceItem TakeOutWashedRice()
        {
            if (currentState != RiceWashingState.WashedRiceReady && currentState != RiceWashingState.HasRice)
            {
                return null;
            }

            GameObject riceGO = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            riceGO.name = "Washed_Rice_Item";
            riceGO.transform.position = transform.position + Vector3.up * 0.2f;
            riceGO.transform.localScale = new Vector3(0.3f, 0.12f, 0.3f);

            Renderer ren = riceGO.GetComponent<Renderer>();
            if (ren != null)
            {
                if (Application.isPlaying) ren.material.color = new Color(0.98f, 0.98f, 0.98f);
                else if (ren.sharedMaterial != null) ren.sharedMaterial.color = new Color(0.98f, 0.98f, 0.98f);
            }

            riceGO.AddComponent<Rigidbody>();
            riceGO.AddComponent<XRGrabInteractable>();
            WhiteRiceItem washedRice = riceGO.AddComponent<WhiteRiceItem>();
            washedRice.riceAmount = currentRiceAmount;
            washedRice.isWashed = (washProgress >= 60f);

            currentRiceAmount = 0;
            currentState = RiceWashingState.Empty;
            washProgress = 0f;

            UpdateVisuals();
            OnStateChanged?.Invoke(currentState);
            OnRiceWashedCompleted?.Invoke(washedRice);

            return washedRice;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other == null) return;

            if (other.TryGetComponent<WhiteRiceItem>(out var rice))
            {
                AddRice(rice);
            }
            else if (other.name.Contains("Hand") || other.name.Contains("Controller") || other.name.Contains("Finger"))
            {
                StirRice(20f);
            }
        }

        private void UpdateVisuals()
        {
            if (riceMeshVisual != null)
            {
                riceMeshVisual.SetActive(currentRiceAmount > 0);
            }

            if (waterSurfaceRenderer != null)
            {
                bool showWater = currentWater > 0.05f;
                waterSurfaceRenderer.gameObject.SetActive(showWater);

                if (showWater)
                {
                    float cloudinessRatio = washProgress / 100f;
                    Color targetColor = Color.Lerp(clearWaterColor, milkyWaterColor, cloudinessRatio);
                    SetRendererColor(waterSurfaceRenderer, targetColor);
                }
            }
        }

        private void SetRendererColor(Renderer r, Color c)
        {
            if (r == null) return;
            if (mpb == null) mpb = new MaterialPropertyBlock();
            r.GetPropertyBlock(mpb);
            mpb.SetColor(BaseColorId, c);
            mpb.SetColor(ColorId, c);
            r.SetPropertyBlock(mpb);
        }
    }
}
