using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_wall_detection_script : MonoBehaviour
{
    GameObject parent;

    private void Awake()
    {
        if (parent == null)
        {
            parent = GameObject.FindGameObjectWithTag("Player");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "ziplineWall")
        {
            parent.GetComponent<playerMovement>().wallable = true;

        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ziplineWall")
        {
            parent.GetComponent<playerMovement>().wallable = false;

        }
    }
}
