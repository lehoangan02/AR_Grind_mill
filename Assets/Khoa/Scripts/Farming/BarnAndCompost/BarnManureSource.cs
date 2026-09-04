using System;
using System.Collections.Generic;
using UnityEngine;

namespace Khoa.Farming
{
    /// <summary>
    /// Điểm sinh phân tươi tại chuồng trại (Chuồng trâu, bò, heo).
    /// Bắt đầu với 1 đống phân tươi, tái tạo sau 120s sau khi thu gom, tối đa 2 đống tồn tại cùng lúc.
    /// </summary>
    [DisallowMultipleComponent]
    public class BarnManureSource : MonoBehaviour
    {
        [Header("Cấu hình chuồng trại")]
        public BarnAnimalType animalType = BarnAnimalType.Cow;
        public float respawnCooldown = 120f;
        public int maxUncollected = 2;

        [Header("Prefab & Vị trí sinh phân")]
        public GameObject manurePrefab;
        public Transform[] spawnPoints;
        public float spawnRadius = 1.2f;

        [Header("Trạng thái hiện tại (Read-Only)")]
        [SerializeField] private float respawnTimer = 0f;
        [SerializeField] private List<ManureItem> activePiles = new List<ManureItem>();

        public float RespawnTimer => respawnTimer;
        public int ActivePileCount
        {
            get
            {
                CleanupNullPiles();
                return activePiles.Count;
            }
        }

        public event Action<ManureItem> OnManureSpawned;

        private void Start()
        {
            CleanupNullPiles();
            if (activePiles.Count == 0)
            {
                SpawnManure();
            }
        }

        private void OnValidate()
        {
            respawnCooldown = Mathf.Max(1f, respawnCooldown);
            maxUncollected = Mathf.Max(1, maxUncollected);
            spawnRadius = Mathf.Max(0.1f, spawnRadius);
        }

        private void Update()
        {
            CleanupNullPiles();

            // Nếu số đống chưa đạt tối đa, đếm ngược thời gian tái tạo
            if (activePiles.Count < maxUncollected)
            {
                respawnTimer += Time.deltaTime;
                if (respawnTimer >= respawnCooldown)
                {
                    respawnTimer = 0f;
                    SpawnManure();
                }
            }
            else
            {
                respawnTimer = 0f;
            }
        }

        /// <summary>
        /// Tạo một đống phân tươi mới tại vị trí chỉ định hoặc quanh chuồng.
        /// </summary>
        public ManureItem SpawnManure()
        {
            CleanupNullPiles();
            if (activePiles.Count >= maxUncollected)
            {
                return null;
            }

            Vector3 spawnPos = CalculateSpawnPosition();
            GameObject pileGO;

            if (manurePrefab != null)
            {
                pileGO = Instantiate(manurePrefab, spawnPos, Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f));
            }
            else
            {
                pileGO = CreateFallbackManureGameObject(spawnPos);
            }

            ManureItem manureItem = pileGO.GetComponent<ManureItem>();
            if (manureItem == null)
            {
                manureItem = pileGO.AddComponent<ManureItem>();
            }

            manureItem.sourceAnimal = animalType;
            manureItem.parentSource = this;

            activePiles.Add(manureItem);
            OnManureSpawned?.Invoke(manureItem);

            return manureItem;
        }

        public void OnItemCollected(ManureItem item)
        {
            if (activePiles.Contains(item))
            {
                activePiles.Remove(item);
            }
            // Reset timer bắt đầu đếm 120s tái tạo mới
            respawnTimer = 0f;
        }

        public void ForceSpawnManure()
        {
            SpawnManure();
        }

        public void SetRespawnTimer(float time)
        {
            respawnTimer = time;
        }

        private void CleanupNullPiles()
        {
            activePiles.RemoveAll(p => p == null || p.IsScooped);
        }

        private Vector3 CalculateSpawnPosition()
        {
            if (spawnPoints != null && spawnPoints.Length > 0)
            {
                int index = activePiles.Count % spawnPoints.Length;
                if (spawnPoints[index] != null)
                {
                    return spawnPoints[index].position;
                }
            }

            Vector2 circle = UnityEngine.Random.insideUnitCircle * spawnRadius;
            return transform.position + new Vector3(circle.x, 0.1f, circle.y);
        }

        private GameObject CreateFallbackManureGameObject(Vector3 pos)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.name = $"ManurePile_{animalType}_{activePiles.Count + 1}";
            go.transform.position = pos;
            go.transform.localScale = new Vector3(0.5f, 0.25f, 0.5f);

            Renderer r = go.GetComponent<Renderer>();
            if (r != null)
            {
                MaterialPropertyBlock block = new MaterialPropertyBlock();
                block.SetColor("_BaseColor", new Color(0.35f, 0.22f, 0.12f));
                block.SetColor("_Color", new Color(0.35f, 0.22f, 0.12f));
                r.SetPropertyBlock(block);
            }

            return go;
        }
    }
}
