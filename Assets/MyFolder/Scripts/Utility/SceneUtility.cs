using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUtility : MonoBehaviour
{
    public void GoToScene(string Name)
    {
        SceneManager.LoadScene(Name);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("App is quitting");
        Debug.Log("App has quit");
    }
}
