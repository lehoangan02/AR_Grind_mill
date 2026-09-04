using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Khoa.Farming
{
    public enum CompostState
    {
        Empty,          // Đống ủ trống, chưa có phân
        Filling,        // Đang tích lũy phân tươi (1/3 hoặc 2/3)
        Composting,     // Đang trong quá trình ủ lên men vi sinh (90s)
        Ready           // Phân đã chín hoai mục, đã xuất 3 phần phân thành phẩm
    }

    /// <summary>
    /// Đống ủ phân hữu cơ sinh học truyền thống.
    /// Nhận đủ 3 phần phân tươi từ xẻng -> ủ trong 90 giây sinh nhiệt -> tạo 3 phần phân hoai MatureFertilizerItem.
    /// </summary>
    [DisallowMultipleComponent]
    public class CompostPile : MonoBehaviour
    {
        [Header("Cấu hình chu trình ủ")]
        public int requiredPortions = 3;
        public float compostDuration = 90f;

        [Header("Trạng thái hiện tại (Read-Only)")]
        [SerializeField] private CompostState currentState = CompostState.Empty;
        [SerializeField] private int currentPortions = 0;
        [SerializeField] private float compostTimer = 0f;
        [SerializeField] private bool hasSpawnedOutputs = false;
        [SerializeField] private int lastDisplayedSecond = -1;

        public CompostState CurrentState => currentState;
        public int CurrentPortions => currentPortions;
        public float CompostTimer => compostTimer;
        public float Progress01 => (compostDuration > 0f && currentState == CompostState.Composting) 
            ? Mathf.Clamp01(1f - (compostTimer / compostDuration)) 
            : (currentState == CompostState.Ready ? 1f : 0f);

        [Header("Output thành phẩm")]
        public GameObject matureFertilizerPrefab;
        public Transform[] outputSpawnPoints;
        public float outputSpawnRadius = 0.8f;
        [SerializeField] private List<MatureFertilizerItem> spawnedOutputs = new List<MatureFertilizerItem>();

        [Header("Hiệu ứng Visual & Âm thanh")]
        public Renderer pileRenderer;
        public Color emptyColor = new Color(0.5f, 0.4f, 0.3f);
        public Color fillingColor = new Color(0.38f, 0.26f, 0.14f);
        public Color compostingColor = new Color(0.25f, 0.16f, 0.08f);
        public Color readyColor = new Color(0.18f, 0.12f, 0.06f);

        public ParticleSystem warmSteamFX;
        public AudioSource compostAudioSource;
        public AudioClip depositSound;
        public AudioClip completeSound;

        [Header("Bảng hiển thị tiến độ World-Space")]
        public TextMeshPro progressText;

        public event Action<CompostState> OnStateChanged;
        public event Action<int> OnPortionAdded;
        public event Action OnCompostCompleted;

        private void Start()
        {
            UpdateVisuals();
            UpdateUI();
        }

        private void OnValidate()
        {
            requiredPortions = Mathf.Max(1, requiredPortions);
            compostDuration = Mathf.Max(0.1f, compostDuration);
            outputSpawnRadius = Mathf.Max(0.1f, outputSpawnRadius);
        }

        private void Update()
        {
            if (currentState == CompostState.Composting)
            {
                compostTimer -= Time.deltaTime;
                int displayedSecond = Mathf.CeilToInt(compostTimer);
                if (displayedSecond != lastDisplayedSecond)
                {
                    lastDisplayedSecond = displayedSecond;
                    UpdateUI();
                }

                if (compostTimer <= 0f)
                {
                    CompleteComposting();
                }
            }
            else if (currentState == CompostState.Ready)
            {
                CheckAndResetIfOutputsCleared();
            }
        }

        /// <summary>
        /// Giao dịch tiếp nhận phân tươi từ xẻng.
        /// </summary>
        public bool TryDepositManure(ManureShovel shovel)
        {
            if (shovel == null || !shovel.IsFull)
            {
                return false;
            }

            if (currentState == CompostState.Composting || currentState == CompostState.Ready)
            {
                Debug.LogWarning("[CompostPile] Đống ủ đang trong quá trình lên men hoặc đã chín, không nhận thêm phân tươi!");
                return false;
            }

            currentPortions++;
            OnPortionAdded?.Invoke(currentPortions);

            if (depositSound != null && compostAudioSource != null)
            {
                compostAudioSource.PlayOneShot(depositSound);
            }

            if (currentPortions >= requiredPortions)
            {
                StartComposting();
            }
            else
            {
                currentState = CompostState.Filling;
                OnStateChanged?.Invoke(currentState);
            }

            UpdateVisuals();
            UpdateUI();
            return true;
        }

        private void StartComposting()
        {
            currentState = CompostState.Composting;
            compostTimer = compostDuration;
            lastDisplayedSecond = Mathf.CeilToInt(compostTimer);
            hasSpawnedOutputs = false;

            if (warmSteamFX != null && !warmSteamFX.isPlaying)
            {
                warmSteamFX.Play();
            }

            if (compostAudioSource != null && !compostAudioSource.isPlaying)
            {
                compostAudioSource.loop = true;
                compostAudioSource.Play();
            }

            OnStateChanged?.Invoke(currentState);
            Debug.Log("<b>[CompostPile]</b> Đã nhận đủ 3 phần phân! Bắt đầu quá trình ủ vi sinh sinh học (90s).");
        }

        public void CompleteComposting()
        {
            if (currentState != CompostState.Composting && currentState != CompostState.Filling) return;

            currentState = CompostState.Ready;
            compostTimer = 0f;

            if (warmSteamFX != null)
            {
                warmSteamFX.Stop();
            }

            if (compostAudioSource != null && compostAudioSource.isPlaying)
            {
                compostAudioSource.Stop();
            }

            if (completeSound != null)
            {
                AudioSource.PlayClipAtPoint(completeSound, transform.position, 1.0f);
            }

            SpawnOutputs();

            UpdateVisuals();
            UpdateUI();

            OnStateChanged?.Invoke(currentState);
            OnCompostCompleted?.Invoke();
            Debug.Log("<color=green><b>[CompostPile]</b> Phân ủ đã chín hoai mục! Đã tạo 3 phần phân bón lót ruộng lúa.</color>");
        }

        private void SpawnOutputs()
        {
            if (hasSpawnedOutputs) return;
            hasSpawnedOutputs = true;
            spawnedOutputs.Clear();

            for (int i = 0; i < requiredPortions; i++)
            {
                Vector3 spawnPos = GetOutputSpawnPosition(i);
                GameObject itemGO;

                if (matureFertilizerPrefab != null)
                {
                    itemGO = Instantiate(matureFertilizerPrefab, spawnPos, Quaternion.identity);
                }
                else
                {
                    itemGO = CreateFallbackMatureFertilizer(spawnPos, i);
                }

                MatureFertilizerItem item = itemGO.GetComponent<MatureFertilizerItem>();
                if (item == null)
                {
                    item = itemGO.AddComponent<MatureFertilizerItem>();
                }

                spawnedOutputs.Add(item);
            }
        }

        private Vector3 GetOutputSpawnPosition(int index)
        {
            if (outputSpawnPoints != null && index < outputSpawnPoints.Length && outputSpawnPoints[index] != null)
            {
                return outputSpawnPoints[index].position;
            }

            float angle = index * (360f / requiredPortions) * Mathf.Deg2Rad;
            Vector3 offset = new Vector3(Mathf.Cos(angle), 0.1f, Mathf.Sin(angle)) * outputSpawnRadius;
            return transform.position + offset;
        }

        private GameObject CreateFallbackMatureFertilizer(Vector3 pos, int index)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.name = $"MatureFertilizer_{index + 1}";
            go.transform.position = pos;
            go.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            go.tag = "Fertilizer";

            Rigidbody rb = go.GetComponent<Rigidbody>();
            if (rb == null) rb = go.AddComponent<Rigidbody>();
            rb.mass = 2f;
            rb.interpolation = RigidbodyInterpolation.Interpolate;

            Renderer r = go.GetComponent<Renderer>();
            if (r != null)
            {
                MaterialPropertyBlock block = new MaterialPropertyBlock();
                block.SetColor("_BaseColor", new Color(0.18f, 0.12f, 0.06f));
                block.SetColor("_Color", new Color(0.18f, 0.12f, 0.06f));
                r.SetPropertyBlock(block);
            }

            return go;
        }

        public void FastForwardTimer(float seconds)
        {
            if (currentState == CompostState.Composting)
            {
                compostTimer -= seconds;
                if (compostTimer <= 0f)
                {
                    CompleteComposting();
                }
            }
        }

        private void UpdateVisuals()
        {
            if (pileRenderer == null) return;

            MaterialPropertyBlock block = new MaterialPropertyBlock();
            pileRenderer.GetPropertyBlock(block);

            Color targetColor = emptyColor;
            switch (currentState)
            {
                case CompostState.Empty: targetColor = emptyColor; break;
                case CompostState.Filling: targetColor = fillingColor; break;
                case CompostState.Composting: targetColor = compostingColor; break;
                case CompostState.Ready: targetColor = readyColor; break;
            }

            block.SetColor("_BaseColor", targetColor);
            block.SetColor("_Color", targetColor);
            pileRenderer.SetPropertyBlock(block);
        }

        private void UpdateUI()
        {
            if (progressText == null) return;

            switch (currentState)
            {
                case CompostState.Empty:
                    progressText.text = $"<color=yellow>ĐỐNG Ủ PHÂN</color>\nTrống (0/{requiredPortions})\n<i>Dùng xẻng xúc phân đổ vào</i>";
                    break;
                case CompostState.Filling:
                    progressText.text = $"<color=yellow>ĐỐNG Ủ PHÂN</color>\nĐã nhận ({currentPortions}/{requiredPortions})\n<i>Cần thêm {requiredPortions - currentPortions} phần</i>";
                    break;
                case CompostState.Composting:
                    int remainSec = Mathf.CeilToInt(compostTimer);
                    int percent = Mathf.RoundToInt(Progress01 * 100f);
                    progressText.text = $"<color=#FFA500>ĐANG Ủ LÊN MEN...</color>\nTiến độ: {percent}%\nThời gian: {remainSec}s\n<i>Đang sinh nhiệt phân hủy</i>";
                    break;
                case CompostState.Ready:
                    progressText.text = "<color=green>PHÂN HOAI MỤC ĐÃ CHÍN!</color>\nĐã có 3 phần phân bón\n<i>Bón lót cho ruộng đã cày (1.5x)</i>";
                    break;
            }
        }

        /// <summary>
        /// Kiểm tra nếu tất cả phân bón thành phẩm đã được lấy đi hoặc tiêu thụ hết thì tự động chuyển về Empty.
        /// </summary>
        public void CheckAndResetIfOutputsCleared()
        {
            if (currentState != CompostState.Ready || !hasSpawnedOutputs) return;

            bool allOutputsCleared = true;
            for (int i = 0; i < spawnedOutputs.Count; i++)
            {
                MatureFertilizerItem item = spawnedOutputs[i];
                if (item != null && !item.IsConsumed)
                {
                    // Nếu vẫn còn tồn tại và nằm gần đống ủ (trong bán kính spawn + 0.6m), coi như chưa lấy hết
                    if (Vector3.Distance(item.transform.position, transform.position) < outputSpawnRadius + 0.6f)
                    {
                        allOutputsCleared = false;
                        break;
                    }
                }
            }

            if (allOutputsCleared)
            {
                ResetToEmpty();
            }
        }

        /// <summary>
        /// Dọn sạch đống ủ và đưa trạng thái về Empty để tiếp tục chu kỳ ủ mới.
        /// </summary>
        public void ResetToEmpty()
        {
            currentState = CompostState.Empty;
            currentPortions = 0;
            compostTimer = 0f;
            lastDisplayedSecond = -1;
            hasSpawnedOutputs = false;
            spawnedOutputs.Clear();
            UpdateVisuals();
            UpdateUI();
            OnStateChanged?.Invoke(currentState);
            Debug.Log("<b>[CompostPile]</b> Đống ủ đã được dọn sạch thành phẩm và sẵn sàng cho mẻ ủ phân mới!");
        }
    }
}
