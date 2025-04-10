using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPressController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool IsButtonPressed = false;
    private bool IsHandled = false;
    private int PressFrame = -1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        IsButtonPressed = true;
        // IsHandled = false;
        PressFrame = Time.frameCount;
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        IsButtonPressed = false;
        // IsHandled = false;
        PressFrame = -1;
    }
    public bool isButtonPressed()
    {
        return IsButtonPressed && PressFrame == Time.frameCount;
    }
}
