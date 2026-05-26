using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameTitle_script : MonoBehaviour
{
    Color thisColor;

    void Start()
    {
        thisColor = gameObject.GetComponent<SpriteRenderer>().color;
        thisColor.a = 0f;
        gameObject.GetComponent<SpriteRenderer>().color = thisColor;
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        float colourValue = 0f;
        yield return new WaitForSeconds(1f);

        while (colourValue < 1f)
        {
            colourValue += 0.01f;
            thisColor.a += colourValue;

            if (colourValue >= 1f)
            {

                Debug.Log(gameObject.name + "done");

                yield break;

            }
            gameObject.GetComponent<SpriteRenderer>().color = thisColor;


            yield return new WaitForFixedUpdate();
        }

    }

}
