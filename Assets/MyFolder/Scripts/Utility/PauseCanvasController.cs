using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PauseCanvasController : MonoBehaviour
{
    [SerializeField] ARSession m_Session;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        // enable pause menu UI
        this.gameObject.SetActive(true);
        // disable AR session
        m_Session.enabled = false;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        // disable pause menu UI
        this.gameObject.SetActive(false);
        // reset AR session
        m_Session.enabled = true;
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
        
    }
}
