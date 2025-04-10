using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUtility : MonoBehaviour
{
    public void goToScene(string Name)
    {
        SceneManager.LoadScene(Name);
    }
    public void quit()
    {
        Application.Quit();
        Debug.Log("App is quitting");
        Debug.Log("App has quit");
    }
}
