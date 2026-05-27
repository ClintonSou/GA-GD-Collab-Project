using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controllerWarning : MonoBehaviour
{
    public Color thisColor;
    public float colourValue = 0f;
    public bool counted;
    // Start is called before the first frame update
    void Start()
    {
        thisColor = gameObject.GetComponent<SpriteRenderer>().color;
        thisColor.a = 0f;
        gameObject.GetComponent<SpriteRenderer>().color = thisColor;
        counted = false;
        //StartCoroutine(wait());
        
    }

    private void FixedUpdate()
    {
        gameObject.GetComponent<SpriteRenderer>().color = thisColor;

        if (colourValue < 1f && counted == false)
        {
            colourValue += 0.01f;
            thisColor.a += colourValue;
        }

        if (colourValue >= 1f && counted == false)
        {
            new WaitForSeconds(3f);
            counted = true;

        }

        if (colourValue >= 1f && counted == true)
        {
            colourValue -= 0.01f;
            thisColor.a += -colourValue;
        }

        if (colourValue <= 1f && counted == true)
        {
            colourValue -= 0.01f;
            thisColor.a += -colourValue;
        }

        if (colourValue <= 0f && counted == true)
        {
            SceneManager.LoadScene("startGameScene");
        }
    }
    //cannot figure out how to reverse this oml
    //IEnumerator wait()
    //{
    //    float colourValue = 0f;
    //    yield return new WaitForSeconds(1.5f);

    //    while (colourValue != 0f)
    //    {
    //        colourValue += 0.01f;
    //        thisColor.a += colourValue;

    //        if (colourValue <= 0f)
    //        {
    //            yield return new WaitForSeconds(1.5f);

    //            Debug.Log(gameObject.name + "done");

    //            SceneManager.LoadScene("startGameScene");

    //            yield break;

    //        }

    //        gameObject.GetComponent<SpriteRenderer>().color = thisColor;

    //        yield return new WaitForFixedUpdate();

    //    }
    //}
}
