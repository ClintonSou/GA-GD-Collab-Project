using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelcheckerscript : MonoBehaviour
{
    public int levelUnlocked;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

    }
    void Start()
    {
        levelUnlocked = 0;
    }

    void Update()
    {
        
    }
}
