using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScreen : UIScreen
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private string mainMenuSceneName;

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

        // NOTE: Uncomment when SettingsScreen.cs exists (Wave 4)
#if false
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
#endif

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
