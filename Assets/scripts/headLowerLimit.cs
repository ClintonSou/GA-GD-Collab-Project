using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class headLowerLimit : MonoBehaviour
{
    Scene currentScene;
    public string sceneName;
    public float headLimit;
    public GameObject refToHead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        refToHead = GameObject.FindGameObjectWithTag("head");

        if (sceneName == ("scene_1"))
        {
            refToHead.GetComponent<headScript>().lowerLimit = -6.25f;
        }

        if (sceneName == ("scene_2"))
        {
            refToHead.GetComponent<headScript>().lowerLimit = -6.25f;
        }

        if (sceneName == ("scene_3_new"))
        {
            refToHead.GetComponent<headScript>().lowerLimit = -40f;
        }
    }
}
