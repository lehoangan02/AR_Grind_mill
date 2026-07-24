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
    private float currentTurnSpeed;

    [Header("Thời gian chuyển trạng thái")]
    public float minStateTime = 3f;
    public float maxStateTime = 7f;
    private float stateTimer = 0f;

    // Biến lưu trữ góc xoay ban đầu
    private float defaultZRotation;
    private float targetZRotation;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        // Ghi nhớ góc xoay Z ban đầu của model trên Scene
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

            if (currentState == PigState.ContinuousOinking)
                oinkTimer = continuousOinkInterval;
            else
                oinkTimer = normalOinkInterval;
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
            // Xoay (Rotation) dựa trên góc Y hiện tại
            transform.Rotate(Vector3.up, currentTurnSpeed * Time.deltaTime);
            
            // Tịnh tiến (Position) dựa trên vị trí và hướng mặt hiện tại
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    private void PickNewState()
    {
        currentState = (PigState)Random.Range(0, System.Enum.GetValues(typeof(PigState)).Length);
        stateTimer = Random.Range(minStateTime, maxStateTime);

        if (currentState == PigState.Moving)
        {
            currentTurnSpeed = Random.Range(-60f, 60f);
        }
        else if (currentState == PigState.Oinking)
        {
            oinkTimer = 0f; 
        }

        // Cập nhật target rotation dựa trên góc ban đầu, không set cứng
        if (currentState == PigState.LyingDown)
            targetZRotation = defaultZRotation + 90f; // Nằm xuống: cộng thêm 90 độ
        else
            targetZRotation = defaultZRotation;       // Đứng dậy: trả về góc ban đầu
    }

    private void HandlePosture()
    {
        // Lấy Rotation hiện tại của model
        Vector3 currentEuler = transform.eulerAngles;
        
        // Chỉ Lerp từ từ trục Z (hoặc trục X tùy theo model của bạn)
        float newZ = Mathf.LerpAngle(currentEuler.z, targetZRotation, Time.deltaTime * 3f);
        
        // Gắn lại vị trí xoay mới mà không làm ảnh hưởng trục X và Y hiện hành
        transform.eulerAngles = new Vector3(currentEuler.x, currentEuler.y, newZ);
    }
}