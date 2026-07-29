using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ConfirmationDialog : UIScreen
{
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    public override void OnOpen(UIScreenData data = null)
    {
        base.OnOpen(data);

        string message = data?.Get<string>("message") ?? string.Empty;
        Action onYes = data?.Get<Action>("onYes");
        Action onNo = data?.Get<Action>("onNo");

        if (messageText != null)
        {
            messageText.text = message;
        }

        if (yesButton != null)
        {
            yesButton.onClick.AddListener(() =>
            {
                Debug.Log("[ConfirmationDialog] Yes button clicked");
                onYes?.Invoke();
                UIManager.instance.Close();
            });
        }

        if (noButton != null)
        {
            noButton.onClick.AddListener(() =>
            {
                Debug.Log("[ConfirmationDialog] No button clicked");
                onNo?.Invoke();
                UIManager.instance.Close();
            });
        }
    }

    public override void OnClose()
    {
        if (yesButton != null)
        {
            yesButton.onClick.RemoveAllListeners();
        }

        if (noButton != null)
        {
            noButton.onClick.RemoveAllListeners();
        }

        base.OnClose();
    }
}
