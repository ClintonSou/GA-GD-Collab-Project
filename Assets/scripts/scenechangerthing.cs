using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechangerthing : MonoBehaviour
{

    public GameObject enterAnimation;

    private void Start()
    {
        Instantiate(enterAnimation);
    }

}
