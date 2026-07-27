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

    [Header("Audio & Animation")]
    public AudioSource audioSource;
    public AudioClip chirpSound;
    [Tooltip("Kéo Animator của gà con vào đây")]
    public Animator animator; // Thêm biến Animator

    [Header("Movement Settings")]
    public float walkSpeed = 1.2f; 

    private float stateTimer = 0f;

    void Start()
    {
        if (audioSource == null) audioSource = gameObject.AddComponent<AudioSource>();
        if (animator == null) animator = GetComponent<Animator>(); // Tự động lấy Animator nếu quên kéo vào
        
        ChangeState(ChickState.Idle);
    }

    void Update()
    {
        CheckMotherDistance();
        HandleStateTimer();
        UpdateMovement();
        UpdateAnimator(); // Gọi hàm cập nhật Animation
    }

    void CheckMotherDistance()
    {
        if (motherHen == null) return;

        float dist = Vector3.Distance(transform.position, motherHen.position);
        
        if (dist > followDistance && currentState != ChickState.FollowingMother)
        {
            ChangeState(ChickState.FollowingMother);
        }
        else if (dist <= stopDistance && currentState == ChickState.FollowingMother)
        {
            ChangeState(ChickState.Idle);
        }
    }

    void HandleStateTimer()
    {
        if (currentState == ChickState.FollowingMother) return;

        stateTimer -= Time.deltaTime;
        if (stateTimer <= 0) ChooseRandomState();
    }

    void ChooseRandomState()
    {
        float rand = Random.value;
        if (rand < 0.5f) ChangeState(ChickState.Walking);
        else ChangeState(ChickState.Idle);
    }

    void ChangeState(ChickState newState)
    {
        currentState = newState;
        stateTimer = Random.Range(1.5f, 3f); 

        if (newState == ChickState.Idle && chirpSound != null && Random.value > 0.3f)
        {
            audioSource.pitch = Random.Range(1.0f, 1.5f); 
            audioSource.PlayOneShot(chirpSound);
        }
        else if (newState == ChickState.Walking)
        {
            transform.Rotate(0, Random.Range(-120f, 120f), 0);
        }
    }

    void UpdateMovement()
    {
        if (currentState == ChickState.FollowingMother)
        {
            // 1. Xoay mặt về phía mẹ (bỏ trục Y)
            Vector3 dirToMother = (motherHen.position - transform.position).normalized;
            dirToMother.y = 0;
            
            if (dirToMother != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(dirToMother);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 8f);
            }
            
            // 2. Chạy nhanh theo mẹ: Dùng transform.forward để luôn di chuyển theo hướng mũi tên Z của mặt
            transform.position += transform.forward * (walkSpeed * 1.5f) * Time.deltaTime;
        }
        else if (currentState == ChickState.Walking)
        {
            // Đi dạo: Dùng transform.forward để không bị đi ngang
            transform.position += transform.forward * walkSpeed * Time.deltaTime;
        }
    }

    // Hàm mới xử lý Animator
    void UpdateAnimator()
    {
        if (animator != null)
        {
            // Nếu không phải trạng thái Idle, tức là đang di chuyển (Walking hoặc FollowingMother) -> Set True
            bool isMoving = (currentState != ChickState.Idle);
            animator.SetBool("IsWalking", isMoving);
        }
    }
}