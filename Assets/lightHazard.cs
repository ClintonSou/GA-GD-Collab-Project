using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightHazard : MonoBehaviour
{
    public GameObject refToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        refToPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("enter");
            refToPlayer.GetComponent<playerHolder>().timerOn = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            Debug.Log("Exit");
            refToPlayer.GetComponent<playerHolder>().timerOn = false;
            refToPlayer.GetComponent<playerHolder>().gauge = 4;
            refToPlayer.GetComponent<playerHolder>().timer = 100;


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
