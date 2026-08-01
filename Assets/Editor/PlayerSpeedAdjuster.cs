using UnityEngine;
using UnityEditor;
using System.Reflection;

public class PlayerSpeedAdjuster : EditorWindow
{
    float speedMultiplier = 2.0f;
    float newSpeedValue = 5.0f;
    bool useMultiplier = true;

    [MenuItem("Tools/Adjust Player Speed & Size")]
    public static void ShowWindow()
    {
        GetWindow<PlayerSpeedAdjuster>("Player Settings Adjuster");
    }

    void OnGUI()
    {
        GUILayout.Label("Player Speed Settings", EditorStyles.boldLabel);
        
        useMultiplier = EditorGUILayout.Toggle("Multiply Current Speed", useMultiplier);
        
        if (useMultiplier)
        {
            speedMultiplier = EditorGUILayout.Slider("Multiplier (e.g. 2 for double)", speedMultiplier, 0.1f, 10f);
        }
        else
        {
            newSpeedValue = EditorGUILayout.Slider("Set Exact Speed To", newSpeedValue, 0.1f, 20f);
        }

        if (GUILayout.Button("Apply Speed to Player(s)"))
        {
            ApplySpeed();
        }

        GUILayout.Space(20);
        GUILayout.Label("Player Physical Size Fix", EditorStyles.boldLabel);
        GUILayout.Label("If you get pushed out of houses, your player is too fat to fit through the doors.", EditorStyles.wordWrappedLabel);

        if (GUILayout.Button("Make Player Slimmer (Fix Doorways)"))
        {
            FixPlayerSize();
        }
    }

    void ApplySpeed()
    {
        int count = 0;
        
        MonoBehaviour[] allScripts = FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        
        foreach (var script in allScripts)
        {
            if (script == null) continue;
            
            System.Type type = script.GetType();
            string[] fieldNames = { "moveSpeed", "MoveSpeed", "m_MoveSpeed", "SprintSpeed", "sprintSpeed" };
            
            bool modified = false;
            foreach (string fieldName in fieldNames)
            {
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (field != null && field.FieldType == typeof(float))
                {
                    float currentSpeed = (float)field.GetValue(script);
                    float updatedSpeed = useMultiplier ? currentSpeed * speedMultiplier : newSpeedValue;
                    
                    if (!useMultiplier && fieldName.ToLower().Contains("sprint"))
                    {
                        updatedSpeed = newSpeedValue * 1.5f;
                    }

                    field.SetValue(script, updatedSpeed);
                    modified = true;
                }
                
                PropertyInfo prop = type.GetProperty(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (prop != null && prop.PropertyType == typeof(float) && prop.CanWrite && prop.CanRead)
                {
                    float currentSpeed = (float)prop.GetValue(script);
                    float updatedSpeed = useMultiplier ? currentSpeed * speedMultiplier : newSpeedValue;
                    
                    if (!useMultiplier && fieldName.ToLower().Contains("sprint"))
                    {
                        updatedSpeed = newSpeedValue * 1.5f;
                    }

                    prop.SetValue(script, updatedSpeed);
                    modified = true;
                }
            }
            
            if (modified)
            {
                EditorUtility.SetDirty(script);
                count++;
            }
        }
        
        if (count > 0)
        {
            UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
            Debug.Log($"Successfully updated speed on {count} controller(s) in the scene!");
        }
    }

    void FixPlayerSize()
    {
        int count = 0;
        
        // Fix standard Capsule Colliders
        CapsuleCollider[] capsules = FindObjectsByType<CapsuleCollider>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (var cap in capsules)
        {
            // If it looks like a player (radius is default 0.5)
            if (cap.radius >= 0.4f && cap.gameObject.name.ToLower().Contains("player"))
            {
                cap.radius = 0.2f; // Slim down to 40cm diameter
                EditorUtility.SetDirty(cap);
                count++;
            }
        }

        // Fix Character Controllers
        CharacterController[] controllers = FindObjectsByType<CharacterController>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (var cc in controllers)
        {
            if (cc.radius >= 0.4f)
            {
                cc.radius = 0.2f;
                // Also increase step offset so they don't get stuck on steps/stilts
                if (cc.stepOffset < 0.5f) cc.stepOffset = 0.5f; 
                EditorUtility.SetDirty(cc);
                count++;
            }
        }
        
        if (count > 0)
        {
            UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
            Debug.Log($"Successfully slimmed down {count} player collider(s) so they fit through small doors!");
        }
        else
        {
            Debug.LogWarning("No large player colliders found to shrink.");
        }
    }
}
