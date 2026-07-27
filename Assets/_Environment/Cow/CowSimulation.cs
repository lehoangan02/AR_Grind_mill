using UnityEngine;

public class CowSimulation : MonoBehaviour
{
    public enum CowState { Idle, Eating, Walking }

    [Header("Current State")]
    public CowState currentState = CowState.Idle;

    [Header("Components")]
    [Tooltip("Kéo object chứa Animator của bò vào đây")]
    public Animator cowAnimator;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip mooSound; 

    [Header("Legs for Procedural Animation")]
    public Transform frontLeftLeg;
    public Transform frontRightLeg;
    public Transform backLeftLeg;
    public Transform backRightLeg;

    [Header("Movement Settings")]
    public float walkSpeed = 1.0f;
    public float legSwingSpeed = 10f;
    public float legSwingAngle = 15f;

    [Header("Roam Area Settings")]
    [Tooltip("Bán kính tối đa mà bò được phép đi dạo")]
    public float roamRadius = 10f;
    private Vector3 startPosition; // Lưu vị trí gốc của bò

    [Header("Simulation Settings")]
    public float minStateTime = 3f;
    public float maxStateTime = 8f;

    private float stateTimer = 0f;
    private Quaternion flStartRot, frStartRot, blStartRot, brStartRot;

    void Start()
    {
        if (cowAnimator == null) cowAnimator = GetComponentInChildren<Animator>();
        if (audioSource == null) audioSource = gameObject.AddComponent<AudioSource>();

        // Lưu lại vị trí ban đầu làm tâm của vòng tròn giới hạn
        startPosition = transform.position;

        if (frontLeftLeg) flStartRot = frontLeftLeg.localRotation;
        if (frontRightLeg) frStartRot = frontRightLeg.localRotation;
        if (backLeftLeg) blStartRot = backLeftLeg.localRotation;
        if (backRightLeg) brStartRot = backRightLeg.localRotation;
        
        ChooseRandomState();
    }

    void Update()
    {
        HandleStateTimer();
        UpdateMovementAndLegs();
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
        int rand = Random.Range(0, 3);
        currentState = (CowState)rand;

        if (currentState == CowState.Walking)
        {
            transform.Rotate(0, Random.Range(-90f, 90f), 0);
        }

        if (cowAnimator != null)
        {
            cowAnimator.SetBool("isEating", currentState == CowState.Eating);
        }

        if (mooSound != null && Random.value > 0.6f)
        {
            audioSource.pitch = Random.Range(0.8f, 1.2f); 
            audioSource.PlayOneShot(mooSound);
        }

        stateTimer = Random.Range(minStateTime, maxStateTime);
    }

    void UpdateMovementAndLegs()
    {
        if (currentState == CowState.Walking)
        {
            // --- LOGIC GIỚI HẠN BÁN KÍNH ---
            // Nếu bò đi xa hơn bán kính cho phép, từ từ bẻ lái xoay mặt về vị trí trung tâm
            if (Vector3.Distance(transform.position, startPosition) > roamRadius)
            {
                Vector3 dirToCenter = (startPosition - transform.position).normalized;
                dirToCenter.y = 0; // Đảm bảo bò không ngóc đầu lên hoặc cắm mặt xuống đất
                
                if (dirToCenter != Vector3.zero)
                {
                    Quaternion targetRot = Quaternion.LookRotation(dirToCenter);
                    // Dùng Slerp để xoay mượt mà với tốc độ 3f
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * 3f);
                }
            }

            // Di chuyển tới trước
            transform.position += transform.forward * walkSpeed * Time.deltaTime;

            // Đung đưa chân
            float swing = Mathf.Sin(Time.time * legSwingSpeed) * legSwingAngle;

            if (frontLeftLeg) frontLeftLeg.localRotation = flStartRot * Quaternion.Euler(swing, 0, 0);
            if (backRightLeg) backRightLeg.localRotation = brStartRot * Quaternion.Euler(swing, 0, 0);
            if (frontRightLeg) frontRightLeg.localRotation = frStartRot * Quaternion.Euler(-swing, 0, 0);
            if (backLeftLeg) backLeftLeg.localRotation = blStartRot * Quaternion.Euler(-swing, 0, 0);
        }
        else
        {
            // Bò đứng yên hoặc ăn cỏ -> trả chân về vị trí gốc
            float returnSpeed = Time.deltaTime * 5f;
            if (frontLeftLeg) frontLeftLeg.localRotation = Quaternion.Lerp(frontLeftLeg.localRotation, flStartRot, returnSpeed);
            if (frontRightLeg) frontRightLeg.localRotation = Quaternion.Lerp(frontRightLeg.localRotation, frStartRot, returnSpeed);
            if (backLeftLeg) backLeftLeg.localRotation = Quaternion.Lerp(backLeftLeg.localRotation, blStartRot, returnSpeed);
            if (backRightLeg) backRightLeg.localRotation = Quaternion.Lerp(backRightLeg.localRotation, brStartRot, returnSpeed);
        }
    }

    // --- LOGIC VẼ GIZMO ---
    // Hàm này sẽ tự động vẽ một vòng tròn màu xanh lá cây trong tab Scene khi bạn click chọn con bò
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        
        // Nếu game đang chạy thì lấy startPosition làm tâm, nếu chưa chạy thì lấy vị trí hiện tại của bò
        Vector3 center = Application.isPlaying ? startPosition : transform.position;
        
        // Vẽ vòng tròn bán kính
        Gizmos.DrawWireSphere(center, roamRadius);
    }
}