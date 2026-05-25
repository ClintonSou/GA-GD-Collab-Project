using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [Header("Level Scene Names")]
    public string levelOneScene = "Level1";
    public string levelTwoScene = "Level2";
    public string levelThreeScene = "Level3";

    [Header("Menu Scene")]
    public string openingMenuScene = "MainMenu";

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(levelOneScene);
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(levelTwoScene);
    }

    public void LoadLevelThree()
    {
        SceneManager.LoadScene(levelThreeScene);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(openingMenuScene);
    }
}