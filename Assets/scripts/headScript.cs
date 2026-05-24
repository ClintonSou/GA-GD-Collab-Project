using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class headScript : MonoBehaviour
{
    Scene currentScene;
    public string sceneName;
    GameObject player;
    public float lowerLimit;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (sceneName == ("scene_1"))
        {
            lowerLimit = -6.25f;
        }

        if (sceneName == ("scene_2"))
        {
            lowerLimit = -6.25f;
        }

        if (sceneName == ("scene_3_new"))
        {
            lowerLimit = -40f;
        }

    }

    private void Update()
    {
        if (transform.position.y <= lowerLimit)
        {
            player.transform.position = player.GetComponent<playerMovement>().lastStableGround;
            player.GetComponent<playerMovement>().currentPlayerStateIs = playerMovement.PlayerStates.normal;
            Destroy(gameObject);
        }

    }

    public void lowtiergodNOW()
    {
        Destroy(gameObject);
    }

}
