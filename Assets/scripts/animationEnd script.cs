using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationEndscript : MonoBehaviour
{
    public float destroyTime;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
