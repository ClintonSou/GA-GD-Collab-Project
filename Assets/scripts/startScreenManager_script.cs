using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScreenManager_script : MonoBehaviour
{
    MenuUIControl menuControl;

    public GameObject leaveAnimationPfb;

    private void Awake()
    {
        menuControl = new MenuUIControl();

        menuControl.startSceneControl.anybutton.performed += ctx => goToMenu();

        menuControl.startSceneControl.Disable();

        StartCoroutine(allowButtonPress());
    }

    IEnumerator allowButtonPress()
    {
        yield return new WaitForSeconds(5f);

        Debug.Log(gameObject.name + "done");

        menuControl.startSceneControl.Enable();
    }

    void goToMenu()
    {
        menuControl.startSceneControl.Disable();

        

        StartCoroutine(sceneTransition());
    }

    IEnumerator sceneTransition()
    {
        Instantiate(leaveAnimationPfb);
        yield return new WaitForSeconds(0.762f);
        SceneManager.LoadScene("MainMenu");

    }

}
