using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject openingPanel;
    public GameObject levelSelectPanel;

    void Start()
    {
        openingPanel.SetActive(true);
        levelSelectPanel.SetActive(false);
    }

    public void OpenLevelSelect()
    {
        openingPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        openingPanel.SetActive(true);
        levelSelectPanel.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    /// add in the name of the scene levels in the quotes ofc
    public void LoadLevel1() => SceneManager.LoadScene("scene_1"); // level 1
    public void LoadLevel2() => SceneManager.LoadScene("scene_2"); // level 2
    public void LoadLevel3() => SceneManager.LoadScene("scene_3"); // level 3
}