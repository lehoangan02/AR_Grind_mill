using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScreen : UIScreen
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private string mainMenuSceneName;

    [SerializeField, Tooltip("Time.timeScale to apply while this menu is open. Defaults to 0 (full physics pause).")]
    private float pausedTimeScale = 0f;

    [SerializeField, Tooltip("Time.timeScale restored on close. Defaults to 1 (normal playback).")]
    private float resumedTimeScale = 1f;

    private float timeScaleBeforePause;

    public override void OnOpen(UIScreenData openData = null)
    {
        timeScaleBeforePause = Time.timeScale;
        Time.timeScale = pausedTimeScale;
        base.OnOpen(openData);
    }

    public override void OnClose()
    {
        base.OnClose();
        Time.timeScale = resumedTimeScale > 0f
            ? (timeScaleBeforePause > 0f ? timeScaleBeforePause : resumedTimeScale)
            : resumedTimeScale;
    }

    private void Start()
    {
        if (resumeButton != null)
        {
            resumeButton.onClick.AddListener(() =>
            {
                UIManager.instance.Close();
            });
        }
        else
        {
            Debug.LogError($"[PauseMenuScreen] resumeButton is not assigned");
        }

        if (settingsButton != null)
        {
            settingsButton.onClick.AddListener(() =>
            {
                UIManager.instance.Open<SettingsScreen>();
            });
        }
        else
        {
            Debug.LogError($"[PauseMenuScreen] settingsButton is not assigned");
        }

        if (quitButton != null)
        {
            quitButton.onClick.AddListener(() =>
            {
                UIManager.instance.ShowConfirmation(
                    "Quit to main menu?",
                    () =>
                    {
                        UIManager.instance.CloseAll();
                        SceneManager.LoadScene(mainMenuSceneName);
                    },
                    null
                );
            });
        }
        else
        {
            Debug.LogError($"[PauseMenuScreen] quitButton is not assigned");
        }
    }
}
