using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement; // XRI Locomotion namespace

public class PlayerSpeedSetter : MonoBehaviour
{
    [Header("Player Movement Settings")]
    [Tooltip("Drag this slider to precisely set the player's movement speed!")]
    [Range(0.1f, 20f)] // This attribute is what turns it into a slider in the Editor!
    public float movementSpeed = 3.0f;

    void Start()
    {
        ApplySpeed();
    }

    // OnValidate runs instantly whenever you drag the slider in the Unity Inspector
    void OnValidate()
    {
        ApplySpeed();
    }

    private void ApplySpeed()
    {
        // Use reflection to find any script that has a "moveSpeed" property, 
        // ensuring it works with any custom or XR player controller!
        MonoBehaviour[] allScripts = FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        int modifiedCount = 0;
        
        foreach (var script in allScripts)
        {
            if (script == null || script == this) continue;
            
            System.Type type = script.GetType();
            
            // Look for standard move speeds AND XR Device Simulator WASD speeds!
            string[] fieldNames = { 
                "moveSpeed", "MoveSpeed", "m_MoveSpeed", "SprintSpeed", "sprintSpeed",
                "keyboardXTranslateSpeed", "keyboardYTranslateSpeed", "keyboardZTranslateSpeed",
                "m_KeyboardXTranslateSpeed", "m_KeyboardYTranslateSpeed", "m_KeyboardZTranslateSpeed"
            };
            
            foreach (string fieldName in fieldNames)
            {
                System.Type currentType = type;
                while (currentType != null && currentType != typeof(MonoBehaviour))
                {
                    // Try fields
                    System.Reflection.FieldInfo field = currentType.GetField(fieldName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    if (field != null && field.FieldType == typeof(float))
                    {
                        field.SetValue(script, movementSpeed);
                        modifiedCount++;
                    }
                    
                    // Try properties
                    System.Reflection.PropertyInfo prop = currentType.GetProperty(fieldName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    if (prop != null && prop.PropertyType == typeof(float) && prop.CanWrite)
                    {
                        prop.SetValue(script, movementSpeed);
                        modifiedCount++;
                    }
                    
                    currentType = currentType.BaseType;
                }
            }
        }

        if (modifiedCount > 0)
        {
            Debug.Log($"[PlayerSpeedSetter] Successfully forced speed to {movementSpeed} on {modifiedCount} controller components!");
        }
        else
        {
            Debug.LogWarning($"[PlayerSpeedSetter] Could not find any movement script to apply speed {movementSpeed} to!");
        }
    }
}
