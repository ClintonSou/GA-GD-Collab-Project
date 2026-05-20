using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class headScript : MonoBehaviour
{
    GameObject player;
    public float lowerLimit;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
