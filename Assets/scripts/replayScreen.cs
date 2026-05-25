using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayScreen : MonoBehaviour
{
    public string mainMenuScene = "MainMenu";
    private string currentLevel;

    private void Start()
    {
        currentLevel = PlayerPrefs.GetString("CurrentLevel");

        // UI erros might happen (sorry)
        Time.timeScale = 1f;
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}