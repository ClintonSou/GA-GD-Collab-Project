using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goalPoint : MonoBehaviour
{
    public GameObject refToPlayer;

    Scene currentScene;
    string sceneName;
    public bool isTouchingGoal;
    PlayerControl goalControl;
    void Start()
    {
        goalControl = new PlayerControl();
        refToPlayer = GameObject.FindGameObjectWithTag("Player");
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        isTouchingGoal = false;
        goalControl.inGameControl.Quit.performed += ctx => eastButtonPerformed();
        goalControl.inGameControl.Enable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTouchingGoal = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouchingGoal = false;
    }

    void eastButtonPerformed()
    {
        if (isTouchingGoal)
        {
            if (sceneName == ("scene_1"))
            {
                SceneManager.LoadScene("scene_2");
                sceneName = "loading";
            }
            if (sceneName == ("scene_2"))
            {
                SceneManager.LoadScene("scene_3_new");
            }
            if (sceneName == ("scene_3_new"))
            {

            }
        }
    }

    void Update()
    {

    }
}
