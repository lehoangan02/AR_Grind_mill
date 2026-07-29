using UnityEngine;
using TMPro;

public class HUDScreen : UIScreen
{
    [SerializeField] private TMP_Text objectiveText;
    [SerializeField] private TMP_Text toolText;

    // Do NOT override OnOpen — base handles screenRoot.SetActive(true),
    // canvasGroup alpha/interactable/blocksRaycasts reset, and Debug.Log.

    public override void OnPause()
    {
        base.OnPause();
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0.5f;
        }
        Debug.Log($"[{GetType().Name}] HUD dimmed (alpha: 0.5)");
    }

    public override void OnResume()
    {
        base.OnResume();
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1f;
        }
        Debug.Log($"[{GetType().Name}] HUD restored (alpha: 1)");
    }

    public override void OnClose()
    {
        base.OnClose();
        // No special cleanup needed — base handles screenRoot.SetActive(false)
        // and canvasGroup disable.
    }

    public void SetObjective(string text)
    {
        if (objectiveText != null)
        {
            objectiveText.text = text;
        }
    }

    public void SetTool(string text)
    {
        if (toolText != null)
        {
            toolText.text = text;
        }
    }
}
