using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHolder : MonoBehaviour
{
    public int timer;
    public int gauge;
    public bool timerOn;
    public GameObject gauge1;
    public GameObject gauge2;
    public GameObject gauge3;
    public GameObject gauge4;
    public GameObject gaugeBar;
    public Color on;
    public Color gaugeOn;
    public Color off;
    // Start is called before the first frame update
    void Start()
    {
        timerOn = false;
        gauge = 4;
        timer = 100;
        updateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn == true)
        {
            timer += -1;
            if (timer <= 0 && gauge > 0)
            {
                timer = 100;
                gauge += -1;
               
            }
        }
        updateHealth();

        if (gauge <= 0)
        {
            SceneManager.LoadScene("game_Over");
        }


    }

    void updateHealth()
    {
        if (timerOn == false && timer == 100)
        {
            gauge = 4;
            timer = 100;
            gaugeBar.SetActive(false);
            gauge1.SetActive(false);
            gauge2.SetActive(false);
            gauge3.SetActive(false);
            gauge4.SetActive(false);
        }

        if (gauge == 4 && timer < 100)
        {
            gaugeBar.SetActive(true);
            gauge1.SetActive(true);
            gauge2.SetActive(true);
            gauge3.SetActive(true);
            gauge4.SetActive(true);
        }
        if (gauge == 3 && timer < 100)
        {
            gaugeBar.SetActive(true);
            gauge1.SetActive(false);
            gauge2.SetActive(true);
            gauge3.SetActive(true);
            gauge4.SetActive(true);
        }
        if (gauge == 2 && timer < 100)
        {
            gaugeBar.SetActive(true);
            gauge1.SetActive(false);
            gauge2.SetActive(false);
            gauge3.SetActive(true);
            gauge4.SetActive(true);
        }
        if (gauge == 1 && timer < 100)
        {
            gaugeBar.SetActive(true);
            gauge1.SetActive(false);
            gauge2.SetActive(false);
            gauge3.SetActive(false);
            gauge4.SetActive(true);
        }
        if (gauge == 0 && timer < 100)
        {
            gaugeBar.SetActive(true);
            gauge1.SetActive(false);
            gauge2.SetActive(false);
            gauge3.SetActive(false);
            gauge4.SetActive(false);
        }
    }
}
