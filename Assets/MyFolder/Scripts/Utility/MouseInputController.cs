using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class MouseInputController : MonoBehaviour
{
    private double Scale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Scale = 0.1;
    }

    // Update is called once per frame
    void Update()
    {
        double inputX = Mouse.current.delta.x.ReadValue();
        double inputY = Mouse.current.delta.y.ReadValue();
        transform.Translate((float)(inputX * Scale), (float)(inputY * Scale), 0);
    }
}
