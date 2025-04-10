using Unity;
using UnityEngine;
public class TestOnEnable : MonoBehaviour
{
    private int onEnableFrame = -1;

    void OnEnable()
    {
        onEnableFrame = Time.frameCount;
        Debug.Log("OnEnable called at frame: " + onEnableFrame);
    }

    void Update()
    {
        if (onEnableFrame == Time.frameCount)
        {
            // Debug.Log("OnEnable was called in this frame; therefore, OnEnable is called first.");
        }
        if (onEnableFrame == Time.frameCount - 1)
        {
            // Debug.Log("OnEnable was called in the previous frame; therefore, Update is called first.");
        }
    }
}