using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaTreeWind : MonoBehaviour
{
    [Header("Wind Settings")]
    [Tooltip("Tốc độ gió - Càng lớn rung càng nhanh")]
    public float windSpeed = 1.5f;
    
    [Tooltip("Biên độ gió - Góc xoay tối đa của lá hoặc cây (độ)")]
    public float swayAmount = 5f; 

    [Header("Fall & Destroy Settings")]
    [Tooltip("Tỉ lệ % cây bị đổ mỗi lần kiểm tra")]
    [Range(0f, 100f)] public float fallChance = 2f; 
    
    [Tooltip("Thời gian (giây) giữa mỗi lần đổ xí ngầu kiểm tra tỉ lệ đổ")]
    public float fallCheckInterval = 10f;
    
    [Tooltip("Tốc độ ngã của cây (giây)")]
    public float fallDuration = 2f;

    private List<Transform> targetsToShake = new List<Transform>();
    private List<Quaternion> initialRotations = new List<Quaternion>();
    
    // Cờ đánh dấu cây đang ngã, để ngừng hiệu ứng rung lá
    private bool isFalling = false;

    void Start()
    {
        // 1. Tìm lá trong Prefab
        FindLeaves(transform);

        if (targetsToShake.Count == 0)
        {
            targetsToShake.Add(transform);
            Debug.Log($"[{gameObject.name}] Không tìm thấy lá, sẽ rung toàn bộ cây.");
        }
        else
        {
            Debug.Log($"[{gameObject.name}] Tìm thấy {targetsToShake.Count} lá.");
        }

        foreach (var target in targetsToShake)
        {
            initialRotations.Add(target.localRotation);
        }

        // 2. Bắt đầu bộ đếm giờ kiểm tra ngã đổ
        StartCoroutine(FallCheckRoutine());
    }

    void FindLeaves(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.name.ToLower().Contains("leaf"))
            {
                targetsToShake.Add(child);
            }
            FindLeaves(child);
        }
    }

    void Update()
    {
        // Nếu cây đang đổ thì bỏ qua hiệu ứng gió rung
        if (isFalling) return;

        for (int i = 0; i < targetsToShake.Count; i++)
        {
            Transform target = targetsToShake[i];
            Quaternion initialRot = initialRotations[i];

            float timeOffset = i * 0.3f; 
            
            float timeX = Time.time * windSpeed + timeOffset;
            float timeZ = Time.time * windSpeed + (timeOffset * 1.5f); 

            float noiseX = (Mathf.PerlinNoise(timeX, 0f) - 0.5f) * 2f;
            float noiseZ = (Mathf.PerlinNoise(0f, timeZ) - 0.5f) * 2f;

            Quaternion windRotation = Quaternion.Euler(noiseX * swayAmount, 0, noiseZ * swayAmount);
            target.localRotation = initialRot * windRotation;
        }
    }

    // Coroutine kiểm tra tỉ lệ đổ định kỳ
    private IEnumerator FallCheckRoutine()
    {
        while (!isFalling)
        {
            // Đợi một khoảng thời gian trước khi kiểm tra
            yield return new WaitForSeconds(fallCheckInterval);

            // Sinh một số ngẫu nhiên từ 0 đến 100
            float randomValue = Random.Range(0f, 100f);

            // Nếu số ngẫu nhiên rơi vào tỉ lệ fallChance, cho cây đổ
            if (randomValue <= fallChance)
            {
                StartCoroutine(FallAndDestroyRoutine());
                break; // Thoát khỏi vòng lặp kiểm tra
            }
        }
    }

    // Coroutine xử lý animation ngã và xóa cây
    private IEnumerator FallAndDestroyRoutine()
    {
        isFalling = true; // Chặn Update() rung lá
        Debug.Log($"[{gameObject.name}] Cây đã bị ngã!");

        Quaternion startRot = transform.localRotation;
        // Xoay cây ngã 90 độ theo trục X (bạn có thể đổi trục Z tùy theo model 3D)
        Quaternion targetRot = startRot * Quaternion.Euler(90f, 0f, 0f);

        float elapsedTime = 0f;

        // Làm mượt hiệu ứng ngã trong khoảng thời gian fallDuration
        while (elapsedTime < fallDuration)
        {
            transform.localRotation = Quaternion.Slerp(startRot, targetRot, elapsedTime / fallDuration);
            elapsedTime += Time.deltaTime;
            yield return null; // Chờ frame tiếp theo
        }

        // Đảm bảo cây ngã chính xác góc đích
        transform.localRotation = targetRot;

        // Chờ 2 giây sau khi ngã hẳn để người chơi kịp nhìn thấy
        yield return new WaitForSeconds(2f);

        // Hủy object khỏi Scene
        Destroy(gameObject);
    }
}