using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goalPoint : MonoBehaviour
{
    public GameObject refToPlayer;
    public GameObject exitAnimation;
    public GameObject levelChecker;


    Scene currentScene;
    string sceneName;
    public bool isTouchingGoal;
    PlayerControl goalControl;
    void Start()
    {
        refToPlayer = GameObject.FindGameObjectWithTag("Player");
        levelChecker = GameObject.FindGameObjectWithTag("levelChecker");

        goalControl = new PlayerControl();

        goalControl.inGameControl.Quit.performed += ctx => eastButtonPerformed();
        goalControl.inGameControl.Enable();

        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        isTouchingGoal = false;

        updateLevelChecker();
        
        
    }

    void updateLevelChecker()
    {
        if (sceneName == ("scene_1"))
        {
            levelChecker.GetComponent<levelcheckerscript>().lastPlayableSceneString = "scene_1";

        }
        else if (sceneName == ("scene_2"))
        {
            levelChecker.GetComponent<levelcheckerscript>().levelUnlocked = 1;
            levelChecker.GetComponent<levelcheckerscript>().lastPlayableSceneString = "scene_2";


        }
        else if (sceneName == ("scene_3_new"))
        {
            levelChecker.GetComponent<levelcheckerscript>().levelUnlocked = 2;
            levelChecker.GetComponent<levelcheckerscript>().lastPlayableSceneString = "scene_3_new";


        }

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
            goalControl.inGameControl.Disable();
            refToPlayer.GetComponent<playerMovement>().disablePlayerControl();
            StartCoroutine(levelEndAnim());

        }
    }
    IEnumerator levelEndAnim()
    {
        Instantiate(exitAnimation, new Vector3(refToPlayer.transform.position.x, refToPlayer.transform.position.y, refToPlayer.transform.position.z -3), Quaternion.identity);

        yield return new WaitForSeconds(0.762f);

        if (sceneName == ("scene_1"))
        {
            SceneManager.LoadScene("scene_2");
        }
        else if (sceneName == ("scene_2"))
        {
            SceneManager.LoadScene("scene_3_new");
        }
        else if (sceneName == ("scene_3_new"))
        {
            SceneManager.LoadScene("MainMenu");

        }
    }
}