using System;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    private float maximumValue;
    private float minimumValue;
    private float currentValue;
    public Image mask;

    void Start()
    {
        
    }

    void Update()
    {
        UpdateProgressBar();
    }
    public void SetCurrentValue(float value)
    {
        currentValue = value;
        UpdateProgressBar();
    }
    public void SetLimits(float min, float max)
    {
        minimumValue = min;
        maximumValue = max;
        UpdateProgressBar();
    }
    private void UpdateProgressBar()
    {
        float currentOffset = currentValue - minimumValue;
        float maxOffset = maximumValue - minimumValue;
        float fillAmount = currentOffset / maxOffset;
        mask.fillAmount = fillAmount;
    }
}
