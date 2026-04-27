using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_ground_detection_script : MonoBehaviour
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
        if ( collision.tag == "Ground")
        {
            parent.GetComponent<playerMovement>().grounded = true;

        }
        if ( collision.tag == "stableGround")
        {
            parent.GetComponent<playerMovement>().lastStableGround = parent.transform.position;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            parent.GetComponent<playerMovement>().grounded = false;

        }
    }
}
