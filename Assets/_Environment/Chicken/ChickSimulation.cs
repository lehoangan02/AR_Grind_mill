using UnityEngine;

public class ChickSimulation : MonoBehaviour
{
    public enum ChickState { Idle, Walking, FollowingMother }
    
    [Header("Current State")]
    public ChickState currentState = ChickState.Idle;

    [Header("Flock Settings")]
    [Tooltip("Kéo object Gà Mẹ vào đây")]
    public Transform motherHen; 
    
    [Tooltip("Khoảng cách tối đa trước khi gà con hoảng hốt chạy đuổi theo mẹ")]
    public float followDistance = 2.5f;
    
    [Tooltip("Khoảng cách gà con dừng lại khi đã đuổi kịp mẹ")]
    public float stopDistance = 1f;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip chirpSound; // Tiếng chiếp chiếp

    [Header("Movement Settings")]
    public float walkSpeed = 1.2f; 

    private float stateTimer = 0f;

    void Start()
    {
        if (audioSource == null) audioSource = gameObject.AddComponent<AudioSource>();
        
        ChangeState(ChickState.Idle);
    }

    void Update()
    {
        CheckMotherDistance();
        HandleStateTimer();
        UpdateMovement();
    }

    // Liên tục kiểm tra xem có bị tụt lại phía sau không
    void CheckMotherDistance()
    {
        if (motherHen == null) return;

        float dist = Vector3.Distance(transform.position, motherHen.position);
        
        // Bị lạc -> Chạy đuổi theo mẹ
        if (dist > followDistance && currentState != ChickState.FollowingMother)
        {
            ChangeState(ChickState.FollowingMother);
        }
        // Đã đuổi kịp mẹ -> Chuyển sang đứng chơi hoặc đi dạo
        else if (dist <= stopDistance && currentState == ChickState.FollowingMother)
        {
            ChangeState(ChickState.Idle);
        }
    }

    void HandleStateTimer()
    {
        // Không tự đổi trạng thái lăng nhăng nếu đang mải chạy theo mẹ
        if (currentState == ChickState.FollowingMother) return;

        stateTimer -= Time.deltaTime;
        if (stateTimer <= 0) ChooseRandomState();
    }

    void ChooseRandomState()
    {
        // 50% đi dạo, 50% đứng yên
        float rand = Random.value;
        if (rand < 0.5f) ChangeState(ChickState.Walking);
        else ChangeState(ChickState.Idle);
    }

    void ChangeState(ChickState newState)
    {
        currentState = newState;
        // Gà con đổi trạng thái nhanh hơn lăng xăng hơn gà lớn
        stateTimer = Random.Range(1.5f, 3f); 

        // Thỉnh thoảng kêu chiếp chiếp khi đang đứng yên
        if (newState == ChickState.Idle && chirpSound != null && Random.value > 0.3f)
        {
            audioSource.pitch = Random.Range(1.0f, 1.5f); // Chỉnh pitch để tiếng kêu đa dạng hơn
            audioSource.PlayOneShot(chirpSound);
        }
        // Nếu chuyển sang đi dạo, xoay mặt ngẫu nhiên
        else if (newState == ChickState.Walking)
        {
            transform.Rotate(0, Random.Range(-120f, 120f), 0);
        }
    }

    void UpdateMovement()
    {
        if (currentState == ChickState.FollowingMother)
        {
            // 1. Xoay mặt về phía mẹ (lọc bỏ trục Y để gà không bị ngóc đầu lên trời)
            Vector3 dirToMother = (motherHen.position - transform.position).normalized;
            dirToMother.y = 0;
            
            if (dirToMother != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(dirToMother);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 8f);
            }
            
            // 2. Chạy nhanh theo mẹ (tốc độ nhân 1.5)
            transform.Translate(Vector3.forward * (walkSpeed * 1.5f) * Time.deltaTime);
        }
        else if (currentState == ChickState.Walking)
        {
            // Đi dạo bình thường
            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
        }
    }
}