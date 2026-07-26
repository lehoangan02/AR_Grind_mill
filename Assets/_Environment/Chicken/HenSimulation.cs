using UnityEngine;

public class HenSimulation : MonoBehaviour
{
    public enum HenState { Idle, Walking }
    
    [Header("Current State")]
    public HenState currentState = HenState.Idle;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip cluckSound; 

    [Header("Movement Settings")]
    public float walkSpeed = 0.8f;
    [Tooltip("Thời gian tối đa trước khi đổi trạng thái (đi -> đứng, đứng -> đi)")]
    public float stateChangeInterval = 4f; 
    
    [Tooltip("Bán kính tối đa gà mẹ được phép đi dạo quanh ổ")]
    public float roamRadius = 5f;

    private float stateTimer = 0f;
    private Vector3 startPosition;

    void Start()
    {
        // Lưu lại vị trí ban đầu làm tâm
        startPosition = transform.position;

        if (audioSource == null) audioSource = gameObject.AddComponent<AudioSource>();
        
        ChangeState(HenState.Idle);
    }

    void Update()
    {
        HandleStateTimer();
        UpdateMovement();
    }

    void HandleStateTimer()
    {
        stateTimer -= Time.deltaTime;
        if (stateTimer <= 0) 
        {
            ChooseRandomState();
        }
    }

    void ChooseRandomState()
    {
        // 50% tỉ lệ đi dạo, 50% tỉ lệ đứng yên kêu cục tác
        float rand = Random.value;
        if (rand < 0.5f) ChangeState(HenState.Walking);
        else ChangeState(HenState.Idle);
    }

    void ChangeState(HenState newState)
    {
        currentState = newState;
        stateTimer = Random.Range(2f, stateChangeInterval);

        // Nếu chuyển sang đứng yên, có tỉ lệ phát ra tiếng kêu
        if (newState == HenState.Idle && cluckSound != null && Random.value > 0.4f)
        {
            audioSource.pitch = Random.Range(0.9f, 1.2f); 
            audioSource.PlayOneShot(cluckSound);
        }
        // Nếu bắt đầu đi, xoay mặt ngẫu nhiên sang hướng mới
        else if (newState == HenState.Walking)
        {
            transform.Rotate(0, Random.Range(-90f, 90f), 0);
        }
    }

    void UpdateMovement()
    {
        if (currentState == HenState.Walking)
        {
            // Kiểm tra xem gà mẹ có đi quá xa vị trí gốc không
            float dist = Vector3.Distance(transform.position, startPosition);
            if (dist > roamRadius)
            {
                // Quay đầu đi về hướng tâm
                Vector3 dir = (startPosition - transform.position).normalized;
                dir.y = 0; // Khóa trục Y để gà không bị lật
                if (dir != Vector3.zero)
                {
                    Quaternion targetRot = Quaternion.LookRotation(dir);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * 3f);
                }
            }

            // Tiến lên phía trước
            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
        }
    }

    // Vẽ vòng tròn vàng trong Scene để bạn dễ căn chỉnh giới hạn
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 center = Application.isPlaying ? startPosition : transform.position;
        
        int segments = 30;
        float angle = 0f;
        Vector3 prevPoint = center + new Vector3(Mathf.Sin(angle) * roamRadius, 0, Mathf.Cos(angle) * roamRadius);
        
        for (int i = 1; i <= segments; i++)
        {
            angle += (Mathf.PI * 2f) / segments;
            Vector3 newPoint = center + new Vector3(Mathf.Sin(angle) * roamRadius, 0, Mathf.Cos(angle) * roamRadius);
            Gizmos.DrawLine(prevPoint, newPoint);
            prevPoint = newPoint;
        }
    }
}