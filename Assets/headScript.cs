using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headScript : MonoBehaviour
{
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (transform.position.y <= -6.25f)
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
