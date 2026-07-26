using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PigBehavior : MonoBehaviour
{
    public enum PigState { Idle, Moving, LyingDown, Oinking, ContinuousOinking }
    
    [Header("Trạng thái hiện tại")]
    public PigState currentState = PigState.Idle;

    [Header("Cài đặt Âm thanh")]
    public List<AudioClip> oinkSounds;
    public float normalOinkInterval = 5f;
    public float continuousOinkInterval = 1f; 
    
    private AudioSource audioSource;
    private float oinkTimer = 0f;

    [Header("Cài đặt Di chuyển")]
    public float moveSpeed = 2f;
    [Tooltip("Tốc độ xoay mặt về hướng điểm đến")]
    public float turnSpeed = 5f;
    [Tooltip("Nếu model đi lùi hoặc đi ngang, hãy đổi số này (VD: 180, 90, -90) để chỉnh lại mặt")]
    public float modelYRotationOffset = 0f; 

    private Vector3 targetWalkPosition;

    [Header("Hiệu ứng Di chuyển (Wobble)")]
    public float wobbleSpeed = 15f; 
    public float wobbleAngle = 7f;

    [Header("Thời gian chuyển trạng thái")]
    public float minStateTime = 3f;
    public float maxStateTime = 7f;
    private float stateTimer = 0f;

    [Header("Cài đặt Giới hạn Chuồng (Pigsty Bounds)")]
    public Transform pigstyCenter; 
    public Vector2 pigstySize = new Vector2(10f, 10f); 

    private float defaultZRotation;
    private float targetZRotation;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        defaultZRotation = transform.eulerAngles.z;
        PickNewState();
    }

    void Update()
    {
        HandleOinking();
        HandleStateLogic();
        HandlePosture();
    }

    private void HandleOinking()
    {
        if (oinkSounds == null || oinkSounds.Count == 0) return;

        oinkTimer -= Time.deltaTime;
        if (oinkTimer <= 0f)
        {
            PlayRandomSound();
            oinkTimer = (currentState == PigState.ContinuousOinking) ? continuousOinkInterval : normalOinkInterval;
        }
    }

    private void PlayRandomSound()
    {
        int randomIndex = Random.Range(0, oinkSounds.Count);
        audioSource.PlayOneShot(oinkSounds[randomIndex]);
    }

    private void HandleStateLogic()
    {
        stateTimer -= Time.deltaTime;
        
        if (stateTimer <= 0f)
        {
            PickNewState();
        }

        if (currentState == PigState.Moving)
        {
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        // Tính toán hướng đi (từ vị trí hiện tại đến điểm đích)
        Vector3 moveDir = (targetWalkPosition - transform.position).normalized;
        // Loại bỏ trục Y để lợn không bị chúi đầu xuống đất hoặc ngóc lên trời
        moveDir.y = 0; 

        if (moveDir != Vector3.zero)
        {
            // 1. Xoay từ từ mặt con lợn về hướng điểm đến (kết hợp với bù trừ góc model)
            Quaternion targetRotation = Quaternion.LookRotation(moveDir) * Quaternion.Euler(0, modelYRotationOffset, 0);
            
            // Lấy góc Y hiện tại và Lerp mượt mà
            float currentY = transform.eulerAngles.y;
            float newY = Mathf.LerpAngle(currentY, targetRotation.eulerAngles.y, Time.deltaTime * turnSpeed);
            
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, newY, transform.eulerAngles.z);

            // 2. Di chuyển tịnh tiến theo vector hướng đi (thay vì dựa vào transform.forward dễ bị ngược)
            transform.position += moveDir * moveSpeed * Time.deltaTime;

            // Kiểm tra xem đã đến gần đích chưa, nếu đến rồi thì đứng lại hoặc chọn trạng thái khác sớm
            if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), 
                                 new Vector3(targetWalkPosition.x, 0, targetWalkPosition.z)) < 0.2f)
            {
                PickNewState(); // Đổi trạng thái khi đã đến nơi
            }
        }
    }

    private void PickNewState()
    {
        currentState = (PigState)Random.Range(0, System.Enum.GetValues(typeof(PigState)).Length);
        stateTimer = Random.Range(minStateTime, maxStateTime);

        if (currentState == PigState.Moving)
        {
            FindNewDestination();
        }
        else if (currentState == PigState.Oinking)
        {
            oinkTimer = 0f; 
        }

        if (currentState == PigState.LyingDown)
            targetZRotation = defaultZRotation + 70f; 
        else
            targetZRotation = defaultZRotation;       
    }

    private void FindNewDestination()
    {
        // Tìm một điểm ngẫu nhiên thực tế nằm bên trong ranh giới chuồng
        if (pigstyCenter != null)
        {
            float randomX = Random.Range(pigstyCenter.position.x - (pigstySize.x / 2f), pigstyCenter.position.x + (pigstySize.x / 2f));
            float randomZ = Random.Range(pigstyCenter.position.z - (pigstySize.y / 2f), pigstyCenter.position.z + (pigstySize.y / 2f));
            
            targetWalkPosition = new Vector3(randomX, transform.position.y, randomZ);
        }
        else
        {
            // Dự phòng nếu quên gắn pigstyCenter
            Vector3 randomDirection = Random.insideUnitSphere * 3f;
            randomDirection.y = 0;
            targetWalkPosition = transform.position + randomDirection;
        }
    }

    private void HandlePosture()
    {
        Vector3 currentEuler = transform.eulerAngles;
        float finalTargetZ = targetZRotation;

        if (currentState == PigState.Moving)
        {
            float wobble = Mathf.Sin(Time.time * wobbleSpeed) * wobbleAngle;
            finalTargetZ += wobble;
        }

        float lerpSpeed = (currentState == PigState.Moving) ? 15f : 3f;
        float newZ = Mathf.LerpAngle(currentEuler.z, finalTargetZ, Time.deltaTime * lerpSpeed);
        
        transform.eulerAngles = new Vector3(currentEuler.x, currentEuler.y, newZ);
    }
    
    private void OnDrawGizmosSelected()
    {
        if (pigstyCenter != null)
        {
            Gizmos.color = Color.green;
            Vector3 size = new Vector3(pigstySize.x, 2f, pigstySize.y);
            Gizmos.DrawWireCube(pigstyCenter.position, size);
        }
        
        // Vẽ thêm 1 đường thẳng chỉ hướng lợn đang muốn đi tới (màu đỏ)
        if (Application.isPlaying && currentState == PigState.Moving)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, targetWalkPosition);
            Gizmos.DrawWireSphere(targetWalkPosition, 0.3f);
        }
    }
}