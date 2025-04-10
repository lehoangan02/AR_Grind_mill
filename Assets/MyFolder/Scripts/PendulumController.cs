using System;
using UnityEngine;

public class PendulumController : MonoBehaviour
{
    public float speed = 5.0f;    // Used for controlling the oscillation speed
    public float StartingFloat = 0.0f;  
    [SerializeField] private float Limit = 75.0f;  // Maximum angle limit
    public bool IsRandom = false; 

    void Start()
    {
        Limit = 75.0f; // Default value
        if (IsRandom)
        {
            StartingFloat = UnityEngine.Random.Range(0.0f, Mathf.PI * 2); // Adjust to full sine wave cycle
        }
    }

    void Update()
{
    float Angle = Mathf.Sin(Time.time * speed + StartingFloat) * Limit;
    // Debug.Log($"Limit: {Limit}");

    transform.localRotation = Quaternion.Euler(0.0f, 0.0f, Angle);
}
}