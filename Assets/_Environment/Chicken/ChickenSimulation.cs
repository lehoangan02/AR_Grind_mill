using UnityEngine;

public class ChickenSimulation : MonoBehaviour
{
    public enum ChickenState { Idle, Walking, Eating, Crowing }
    
    [Header("Current State")]
    public ChickenState currentState = ChickenState.Idle;

    [Header("Bone References")]
    public Transform spine;
    public Transform neck;
    public Transform leg1L;
    public Transform leg1R;

    [Header("Rotation Axes")]
    public Vector3 spineAxis = new Vector3(1, 0, 0);
    public Vector3 neckAxis = new Vector3(1, 0, 0);
    public Vector3 legAxis = new Vector3(1, 0, 0);

    [Header("Animation Angles")]
    public float eatSpineAngle = 45f;
    public float eatNeckAngle = 30f;
    public float crowSpineAngle = -30f;
    public float crowNeckAngle = -45f;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip cluckSound; 
    public AudioClip crowSound;  

    [Header("Movement & Boundary Settings")]
    public float walkSpeed = 1f;
    public float walkLegAngle = 30f; 
    public float stateChangeInterval = 4f; 
    
    [Tooltip("Bán kính tối đa gà được phép đi dạo (tính từ điểm xuất phát)")]
    public float roamRadius = 5f;
    [Tooltip("Hiển thị vòng tròn giới hạn màu xanh lá trong Scene")]
    public bool showBoundaryGizmo = true;

    private Quaternion initSpine, initNeck, initLeg1L, initLeg1R;
    private float stateTimer = 0f;
    private float walkCycle = 0f;
    private Vector3 startPosition; // Lưu vị trí gốc

    void Start()
    {
        // Ghi nhớ vị trí ban đầu làm tâm của vòng tròn giới hạn
        startPosition = transform.position;

        if (spine) initSpine = spine.localRotation;
        if (neck) initNeck = neck.localRotation;
        if (leg1L) initLeg1L = leg1L.localRotation;
        if (leg1R) initLeg1R = leg1R.localRotation;

        if (audioSource == null) audioSource = gameObject.AddComponent<AudioSource>();
        
        ChangeState(ChickenState.Idle);
    }

    void Update()
    {
        HandleStateTimer();
        UpdateAnimations();
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
        float rand = Random.value;
        if (rand < 0.4f) ChangeState(ChickenState.Walking);
        else if (rand < 0.7f) ChangeState(ChickenState.Eating);
        else if (rand < 0.9f) ChangeState(ChickenState.Idle);
        else ChangeState(ChickenState.Crowing);
    }

    void ChangeState(ChickenState newState)
    {
        currentState = newState;
        stateTimer = (newState == ChickenState.Crowing) ? 3f : Random.Range(3f, stateChangeInterval);

        if (newState == ChickenState.Eating || newState == ChickenState.Idle)
        {
            if (Random.value > 0.5f && cluckSound) 
            {
                audioSource.pitch = Random.Range(0.9f, 1.1f);
                audioSource.PlayOneShot(cluckSound);
            }
        }
        else if (newState == ChickenState.Crowing && crowSound)
        {
            audioSource.pitch = 1f;
            audioSource.PlayOneShot(crowSound);
        }
        else if (newState == ChickenState.Walking)
        {
            // Xoay hướng ngẫu nhiên trước khi đi
            transform.Rotate(0, Random.Range(-90f, 90f), 0);
        }
    }

    void UpdateAnimations()
    {
        Quaternion targetSpine = initSpine;
        Quaternion targetNeck = initNeck;
        Quaternion targetLegL = initLeg1L;
        Quaternion targetLegR = initLeg1R;

        float smoothSpeed = 5f;

        switch (currentState)
        {
            case ChickenState.Walking:
                // --- XỬ LÝ VÒNG TRÒN GIỚI HẠN ---
                float distanceFromStart = Vector3.Distance(transform.position, startPosition);
                if (distanceFromStart > roamRadius)
                {
                    // Nếu đi quá giới hạn, từ từ xoay người hướng về lại tâm (startPosition)
                    Vector3 directionToCenter = (startPosition - transform.position).normalized;
                    directionToCenter.y = 0; // Đảm bảo gà không ngẩng/cúi đầu khi xoay
                    
                    if (directionToCenter != Vector3.zero)
                    {
                        Quaternion targetRotation = Quaternion.LookRotation(directionToCenter);
                        // Xoay mượt mà (tốc độ xoay là 3f)
                        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3f);
                    }
                }
                // --------------------------------

                // Gà tiến lên phía trước
                transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
                
                // Hoạt ảnh bước chân
                walkCycle += Time.deltaTime * walkSpeed * 10f;
                float legAngleL = Mathf.Sin(walkCycle) * walkLegAngle;
                float legAngleR = Mathf.Sin(walkCycle + Mathf.PI) * walkLegAngle; 

                targetLegL = initLeg1L * Quaternion.Euler(legAxis * legAngleL);
                targetLegR = initLeg1R * Quaternion.Euler(legAxis * legAngleR);
                targetNeck = initNeck * Quaternion.Euler(neckAxis * 15f); 
                smoothSpeed = 10f; 
                break;

            case ChickenState.Eating:
                targetSpine = initSpine * Quaternion.Euler(spineAxis * eatSpineAngle); 
                float peckMotion = Mathf.Abs(Mathf.Sin(Time.time * 10f)) * eatNeckAngle; 
                targetNeck = initNeck * Quaternion.Euler(neckAxis * peckMotion); 
                break;

            case ChickenState.Crowing:
                targetSpine = initSpine * Quaternion.Euler(spineAxis * crowSpineAngle);
                targetNeck = initNeck * Quaternion.Euler(neckAxis * crowNeckAngle);
                smoothSpeed = 3f; 
                break;

            case ChickenState.Idle:
                float breathe = Mathf.Sin(Time.time * 2f) * 2f;
                targetSpine = initSpine * Quaternion.Euler(spineAxis * breathe);
                break;
        }

        if (spine) spine.localRotation = Quaternion.Slerp(spine.localRotation, targetSpine, Time.deltaTime * smoothSpeed);
        if (neck) neck.localRotation = Quaternion.Slerp(neck.localRotation, targetNeck, Time.deltaTime * smoothSpeed);
        if (leg1L) leg1L.localRotation = Quaternion.Slerp(leg1L.localRotation, targetLegL, Time.deltaTime * smoothSpeed);
        if (leg1R) leg1R.localRotation = Quaternion.Slerp(leg1R.localRotation, targetLegR, Time.deltaTime * smoothSpeed);
    }

    // Vẽ vòng tròn giới hạn trong Scene view để dễ quan sát
    private void OnDrawGizmosSelected()
    {
        if (showBoundaryGizmo)
        {
            Gizmos.color = Color.green;
            // Nếu game đang chạy, vẽ từ vị trí gốc. Nếu chưa chạy, vẽ từ vị trí hiện tại.
            Vector3 center = Application.isPlaying ? startPosition : transform.position;
            
            // Vẽ một loạt các đường thẳng tạo thành vòng tròn
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
}