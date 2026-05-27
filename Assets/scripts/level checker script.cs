using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelcheckerscript : MonoBehaviour
{
    public int levelUnlocked;
    public string lastPlayableSceneString;

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
