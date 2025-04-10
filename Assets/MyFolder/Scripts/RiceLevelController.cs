using UnityEngine;
using UnityEngine.UI;

public class RiceLevelController : MonoBehaviour
{
    [SerializeField]
    private GameObject riceHeap;
    private Rigidbody rb;
    private float previousTime;
    private float currentTime;
    public float currentLevel;
    private readonly float maxLevel = 0.1f;
    private readonly float shiftAmount = 0.33f;
    [SerializeField]
    private ProgressBarController progressBarController;
    [SerializeField]
    private GameObject riceParticleSystem;
    private float originalYPosition;
    private float emptyYPosition;
    private bool riceGrinded;
    [SerializeField]
    private GameObject grindedRice;
    public bool pouredFirstTime;
    public Image UI_Debug;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        previousTime = Time.time;
        progressBarController.SetLimits(0, maxLevel);
        currentLevel = 0;
        progressBarController.SetCurrentValue(currentLevel);
        originalYPosition = riceHeap.transform.localPosition.y;
        emptyYPosition = originalYPosition - shiftAmount;
        riceGrinded = false;
        pouredFirstTime = false;
        SetEmpty();
        
    }
    void Update()
    {
        currentTime = Time.time;
        float deltaTime = currentTime - previousTime;
        previousTime = currentTime;
        float angularVelocityY = Mathf.Abs(rb.angularVelocity.y);
        float downAmount = angularVelocityY * deltaTime * 0.001f;
        currentLevel += downAmount;
        if (currentLevel > maxLevel)
        {
            downAmount = 0;
        }
        riceHeap.transform.localPosition -= new Vector3(0, downAmount * shiftAmount / maxLevel, 0);
        // Debug.Log("Current Level: " + currentLevel);
        progressBarController.SetCurrentValue(currentLevel);
        if (currentLevel > maxLevel && pouredFirstTime)
        {
            // Trigger the end of the game or any other action
            Debug.Log("Game Over: Rice level reached maximum!");
            var riceEmissionModule = riceParticleSystem.GetComponent<ParticleSystem>().emission;
            riceEmissionModule.rateOverTime = 0; // Stop the rice particle emission
            riceGrinded = true;
            grindedRice.SetActive(true);
            Debug.Log("Grinded rice activated!");
            currentLevel = maxLevel;
        }
        if (!pouredFirstTime)
        {
            progressBarController.SetCurrentValue(0);
        }
    }
    public void ResetRiceLevel()
    {
        currentLevel = 0;
        riceHeap.transform.localPosition = new Vector3(riceHeap.transform.localPosition.x, originalYPosition, riceHeap.transform.localPosition.z);
        progressBarController.SetCurrentValue(currentLevel);
        riceGrinded = false;
        gameObject.GetComponent<RiceParticleEmission>().EnableEmission();
        pouredFirstTime = true;
        
    }
    public void SetEmpty()
    {
        currentLevel = maxLevel;
        riceHeap.transform.localPosition = new Vector3(riceHeap.transform.localPosition.x, emptyYPosition, riceHeap.transform.localPosition.z);
        progressBarController.SetCurrentValue(0);
        gameObject.GetComponent<RiceParticleEmission>().DisableEmission();
        // Debug.Log("Set to empty!");
        grindedRice.SetActive(false);
    }
}
