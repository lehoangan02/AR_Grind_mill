using UnityEngine;
using CandyCoded.HapticFeedback;
using System;
enum TypeOfHapticFeedback
        {
            LIGHT,
            MEDIUM,
            HEAVY,
            NONE
        };
public class HapticRotationController : MonoBehaviour
{
    private Rigidbody rb;
    private TypeOfHapticFeedback HapticType;
    private float TimePerHapticFeedback;
    private float TotalTime;
    void Start()
    {
        // get rigidbody gameobject
        rb = GetComponent<Rigidbody>();
        TotalTime = 0;
    }

    void Update()
    {
        Vector3 AngularVelocity = rb.angularVelocity;
        float AngularVelocityY = AngularVelocity.y;
        AngularVelocityY = Math.Abs(AngularVelocityY);
        AngularVelocityY = Mathf.Max(AngularVelocityY, 0.1f);
        // Debug.Log("AngularVelocityY: " + AngularVelocityY);
        TimePerHapticFeedback = 0.2f / AngularVelocityY;
        if (TimePerHapticFeedback > 1.0f)
        {
            HapticType = TypeOfHapticFeedback.NONE;
        }
        else if (TimePerHapticFeedback > 0.1f)
        {
            HapticType = TypeOfHapticFeedback.LIGHT;
        }
        else if (TimePerHapticFeedback > 0.05f)
        {
            HapticType = TypeOfHapticFeedback.MEDIUM;
        }
        else if (TimePerHapticFeedback > 0.01f)
        {
            HapticType = TypeOfHapticFeedback.HEAVY;
        }
        const float MinimumTime = 0.05f;
        // Debug.Log("TimePerHapticFeedback: " + TimePerHapticFeedback);
        if (TimePerHapticFeedback < MinimumTime)
        {
            TimePerHapticFeedback = MinimumTime;
        }
        float DeltaTime = Time.deltaTime;
        TotalTime += DeltaTime;
        if (TotalTime >= TimePerHapticFeedback)
        {
            // Debug.Log("HapticFeedback");
            TotalTime = TotalTime = 0;
            switch (HapticType)
            {
                case TypeOfHapticFeedback.LIGHT:
                    HapticManager.LightHapticFeedback();
                    // Debug.Log("LightFeedback");
                    break;
                case TypeOfHapticFeedback.MEDIUM:
                    HapticManager.MediumHapticFeedback();
                    // Debug.Log("MediumFeedback");
                    break;
                case TypeOfHapticFeedback.HEAVY:
                    HapticManager.HeavyHapticFeedback();
                    // Debug.Log("HeavyFeedback");
                    break;
            }
        }
    }
}
