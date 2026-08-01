using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement; // XRI 3.x Locomotion namespace

[RequireComponent(typeof(Slider))]
public class PlayerSpeedSliderUI : MonoBehaviour
{
    [Tooltip("The minimum speed the player can have.")]
    public float minSpeed = 1f;
    [Tooltip("The maximum speed the player can have.")]
    public float maxSpeed = 10f;
    
    private Slider speedSlider;
    private ContinuousMoveProvider moveProvider;
    private const string SPEED_PREF_KEY = "PlayerSavedMoveSpeed";

    void Start()
    {
        speedSlider = GetComponent<Slider>();
        speedSlider.minValue = minSpeed;
        speedSlider.maxValue = maxSpeed;

        // Find the player's movement provider
        moveProvider = FindObjectOfType<ContinuousMoveProvider>();
        
        if (moveProvider != null)
        {
            // Load saved speed from PlayerPrefs (default to current speed if not saved)
            float savedSpeed = PlayerPrefs.GetFloat(SPEED_PREF_KEY, moveProvider.moveSpeed);
            
            // Apply it
            moveProvider.moveSpeed = savedSpeed;
            speedSlider.value = savedSpeed;

            // Listen for slider changes
            speedSlider.onValueChanged.AddListener(OnSliderValueChanged);
        }
        else
        {
            Debug.LogWarning("PlayerSpeedSliderUI could not find a ContinuousMoveProvider in the scene.");
        }
    }

    private void OnSliderValueChanged(float newValue)
    {
        if (moveProvider != null)
        {
            // Update the player's speed
            moveProvider.moveSpeed = newValue;
            
            // Save it permanently so it remembers next time you play
            PlayerPrefs.SetFloat(SPEED_PREF_KEY, newValue);
            PlayerPrefs.Save();
        }
    }

    void OnDestroy()
    {
        if (speedSlider != null)
        {
            speedSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
        }
    }
}
