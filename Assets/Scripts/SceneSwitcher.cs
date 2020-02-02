using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void GotoMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void doExitGame()
    {
        Debug.Log("quit game?");
        Application.Quit();
    }
}
