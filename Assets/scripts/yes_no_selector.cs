using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class yes_no_selector : MonoBehaviour
{
    PlayerControl control;

    public bool yesSelected;

    Vector2 controlMoveValueGameOver;

    public string currentScene;

    public Scene activeScene;

    public GameObject levelChecker;

    private void Awake()
    {
        control = new PlayerControl();


        control.inGameControl.jumpcling.performed += ctx => southButtonPerformed();
        control.inGameControl.Quit.performed += ctx => eastButtonPerformed();

        control.inGameControl.Enable();

        levelChecker = GameObject.FindGameObjectWithTag("levelChecker");

        activeScene = SceneManager.GetActiveScene();
        currentScene = activeScene.name;
    }


    void southButtonPerformed()
    {
        if (!yesSelected)

            if (currentScene == "game_Over")
            {
                {
                    currentScene = "no longer game Over";
                    SceneManager.LoadScene(levelChecker.GetComponent<levelcheckerscript>().lastPlayableSceneString);
                }
            }

    }
    void eastButtonPerformed()
    {
        if (currentScene == "game_Over")
        {
            if (!yesSelected)
            {
                currentScene = "no longer game Over";
                SceneManager.LoadScene("MainMenu");
            }
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
