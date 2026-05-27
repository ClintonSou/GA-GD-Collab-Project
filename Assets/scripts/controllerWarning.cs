using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controllerWarning : MonoBehaviour
{
    public Color thisColor;
    public bool counted;

    void Start()
    {
        thisColor = gameObject.GetComponent<SpriteRenderer>().color;
        thisColor.a = 0f;
        gameObject.GetComponent<SpriteRenderer>().color = thisColor;
        counted = false;
        StartCoroutine(fadeIn());
        
    }

    IEnumerator fadeIn()
    {
        yield return new WaitForSeconds(1f);
        float colourValue = 0f;

        while (colourValue < 1f)
        {
            colourValue += 0.05f;
            thisColor.a = colourValue;

            
            gameObject.GetComponent<SpriteRenderer>().color = thisColor;
            
            yield return new WaitForFixedUpdate();

        }

        thisColor.a = 1f;
        colourValue = 1f;

        yield return new WaitForSeconds(2f);

        while (colourValue >0f )
        {
            colourValue -= 0.05f;
            thisColor.a = colourValue;


            gameObject.GetComponent<SpriteRenderer>().color = thisColor;

            yield return new WaitForFixedUpdate();

        }

        SceneManager.LoadScene("startGameScene");

    }
}
