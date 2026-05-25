using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class yes_no_selector : MonoBehaviour
{
    PlayerControl control;
    public bool yesSelected;
    Vector2 controlMoveValueGameOver;
    public SpriteRenderer yesButton;
    public SpriteRenderer noButton;
    public Sprite eye;
    public string currentScene;
    public Scene activeScene;
    // Start is called before the first frame update

    private void Awake()
    {
        control = new PlayerControl();

        control.inGameControl.jumpcling.performed += ctx => southButtonPerformed();
        control.inGameControl.Quit.performed += ctx => eastButtonPerformed();
        control.inGameControl.Enable();
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
                    SceneManager.LoadScene("scene_1");
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
                SceneManager.LoadScene("menu");
            }
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (yesSelected)
        {
            yesButton.sprite = eye;
            noButton.sprite = null;

        }

        if (!yesSelected)
        {
            yesButton.sprite = null;
            noButton.sprite = eye;
        }
    }
}
