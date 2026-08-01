using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScreen : UIScreen
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private string gameplaySceneName;

    private void Start()
    {
        if (string.IsNullOrEmpty(gameplaySceneName))
        {
            Debug.LogError("[MainMenuScreen] gameplaySceneName is not assigned. Start button will not work.");
        }

        if (startButton != null)
        {
            startButton.onClick.AddListener(() =>
            {
                Debug.Log($"[MainMenuScreen] Loading scene: {gameplaySceneName}");
                SceneManager.LoadScene(gameplaySceneName);
            });
        }
        else
        {
            Debug.LogError("[MainMenuScreen] startButton is not assigned in the Inspector.");
        }

        if (quitButton != null)
        {
            quitButton.onClick.AddListener(() =>
            {
                Debug.Log("[MainMenuScreen] Quit button clicked.");
                UIManager.instance.ShowConfirmation("Quit game?",
                    () =>
                    {
                        Debug.Log("[MainMenuScreen] Quit confirmed. Exiting application.");
                        Application.Quit();
                    },
                    null);
            });
        }
        else
        {
            Debug.LogError("[MainMenuScreen] quitButton is not assigned in the Inspector.");
        }
    }
}
