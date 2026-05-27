using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditsController : MonoBehaviour
{
    PlayerControl creditControl;
    public GameObject enterAnimation;

    
    void Start()
    {
        creditControl = new PlayerControl();
        creditControl.inGameControl.Quit.performed += ctx => eastButtonPerformed();
        creditControl.inGameControl.Enable();

        Instantiate(enterAnimation);
    }

    void eastButtonPerformed()
    {
        SceneManager.LoadScene("MainMenu");
        creditControl.inGameControl.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
