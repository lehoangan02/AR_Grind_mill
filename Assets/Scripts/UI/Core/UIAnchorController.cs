using UnityEngine;

/// <summary>
/// Positions a world-space UI anchor in front of the player's gaze.
/// Stays world-fixed until the player exceeds distance/angle thresholds,
/// then gently eases back after a delay.
/// 
/// Attach to the same GameObject assigned as UIManager.uiAnchor.
/// </summary>
public class UIAnchorController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera mainCamera;

    [Header("Placement")]
    [SerializeField, Tooltip("Meters in front of the player's gaze")]
    private float spawnDistance = 1f;

    [Header("Recenter Triggers")]
    [SerializeField, Tooltip("How far the player can walk from the anchor before recentering")]
    private float maxDistance = 1.5f;

    [SerializeField, Tooltip("How far the player can look away from the anchor before recentering")]
    private float maxAngle = 45f;

    [SerializeField, Tooltip("Seconds the player must stay outside threshold before recenter begins")]
    private float recenterDelay = 3f;

    [Header("Animation")]
    [SerializeField, Tooltip("Duration of the smooth recenter animation")]
    private float recenterDuration = 1.5f;

    private Vector3 anchorWorldPosition;
    private float timeOutsideThreshold;
    private bool isRecentering;

    private Vector3 recenterStartPos;
    private Quaternion recenterStartRot;
    private float recenterElapsed;

    private void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
            if (mainCamera == null)
            {
                Debug.LogError("[UIAnchorController] No camera assigned and Camera.main is null");
                return;
            }
        }

        PositionToGaze();
    }

    private void Update()
    {
        if (mainCamera == null) return;

        if (isRecentering)
        {
            UpdateRecenter();
            return;
        }

        float distance = Vector3.Distance(mainCamera.transform.position, anchorWorldPosition);
        Vector3 directionToAnchor = (anchorWorldPosition - mainCamera.transform.position).normalized;
        float angle = Vector3.Angle(mainCamera.transform.forward, directionToAnchor);

        if (distance > maxDistance || angle > maxAngle)
        {
            timeOutsideThreshold += Time.deltaTime;

            if (timeOutsideThreshold >= recenterDelay)
            {
                StartRecenter();
            }
        }
        else
        {
            timeOutsideThreshold = 0f;
        }
    }

    /// <summary>
    /// Immediately snap the anchor to the player's current gaze position.
    /// Call this when opening the first screen for instant placement.
    /// </summary>
    public void PositionToGaze()
    {
        if (mainCamera == null) return;

        anchorWorldPosition = mainCamera.transform.position
            + mainCamera.transform.forward * spawnDistance;

        transform.position = anchorWorldPosition;
        FaceCamera();
        timeOutsideThreshold = 0f;
        isRecentering = false;
    }

    private void FaceCamera()
    {
        if (mainCamera == null) return;

        Vector3 direction = transform.position - mainCamera.transform.position;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    private void StartRecenter()
    {
        isRecentering = true;
        recenterStartPos = transform.position;
        recenterStartRot = transform.rotation;
        recenterElapsed = 0f;
    }

    private void UpdateRecenter()
    {
        recenterElapsed += Time.deltaTime;
        float t = Mathf.Clamp01(recenterElapsed / recenterDuration);

        // Ease out: 1 - (1-t)^2
        float easedT = 1f - (1f - t) * (1f - t);

        Vector3 targetPos = mainCamera.transform.position
            + mainCamera.transform.forward * spawnDistance;

        Vector3 targetDir = targetPos - mainCamera.transform.position;
        Quaternion targetRot = targetDir != Vector3.zero
            ? Quaternion.LookRotation(targetDir)
            : transform.rotation;

        transform.position = Vector3.Lerp(recenterStartPos, targetPos, easedT);
        transform.rotation = Quaternion.Slerp(recenterStartRot, targetRot, easedT);

        if (t >= 1f)
        {
            anchorWorldPosition = targetPos;
            isRecentering = false;
            timeOutsideThreshold = 0f;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if (mainCamera == null) return;

        // Recorded anchor position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(anchorWorldPosition, 0.1f);

        // Current gaze target (where recenter would go)
        Vector3 gazeTarget = mainCamera.transform.position
            + mainCamera.transform.forward * spawnDistance;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gazeTarget, 0.05f);
        Gizmos.DrawLine(mainCamera.transform.position, gazeTarget);

        // Threshold rings
        Gizmos.color = new Color(1f, 0.5f, 0f, 0.3f);
        Gizmos.DrawWireSphere(anchorWorldPosition, maxDistance);

        // Angle cone
        Vector3 toCamera = (mainCamera.transform.position - anchorWorldPosition).normalized;
        float coneRadius = Mathf.Tan(maxAngle * Mathf.Deg2Rad) * spawnDistance;
        Gizmos.color = new Color(1f, 0.5f, 0f, 0.15f);
        Vector3 coneEnd = anchorWorldPosition + toCamera;
        Gizmos.DrawLine(anchorWorldPosition, coneEnd);
    }
#endif
}
