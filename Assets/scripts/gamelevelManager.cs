using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevelManager : MonoBehaviour
{
    [Header("REPLAY SCENE")]
    public string replayScene = "ReplayScene";

    private void Start()
    {
        PlayerPrefs.SetString("CurrentLevel",
        SceneManager.GetActiveScene().name);
    }

    public void OpenReplayScreen()
    {
        SceneManager.LoadScene(replayScene);
    }
}