using UnityEngine;

public abstract class UIScreen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup canvasGroup;

    public virtual void OnOpen(UIScreenData data = null)
    {
        Debug.Log($"[{GetType().Name}] OnOpen");

        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
    }
    public virtual void OnClose()
    {
        Debug.Log($"[{GetType().Name}] OnClose");

        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
    public virtual void OnPause()
    {
        Debug.Log($"[{GetType().Name}] OnPause");

        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public virtual void OnResume()
    {
        Debug.Log($"[{GetType().Name}] OnResume");

        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
    }
}
