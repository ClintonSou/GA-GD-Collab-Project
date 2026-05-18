using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search.Providers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goalPoint : MonoBehaviour
{
    public GameObject refToPlayer;
    Scene currentScene;
    string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        refToPlayer = GameObject.FindGameObjectWithTag("Player");
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (sceneName == ("scene_1"))
        {
            SceneManager.LoadScene("scene_2");
        }

        if (sceneName == ("scene_2"))
        {
            SceneManager.LoadScene("scene_3");
        }

        if (sceneName == ("scene_3"))
        {

        }



    }
    // Update is called once per frame
    void Update()
    {

    }
}
