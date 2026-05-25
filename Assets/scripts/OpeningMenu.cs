using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningMenu : MonoBehaviour
{
    [Header("Scene Names")]
    public string levelSelectSceneName = "LevelSelect";

    public void StartGame()
    {
        SceneManager.LoadScene(levelSelectSceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Game Closed");
        Application.Quit();
    }
}