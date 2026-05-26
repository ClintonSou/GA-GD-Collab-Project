using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class levelselectmanagerscript : MonoBehaviour
{
    MenuUIControl menuControl;

    public GameObject level1UI;
    public GameObject level2UI;
    public GameObject level3UI;

    public GameObject levelChecker;
    public GameObject selectUI;

    public int levelIndex;

    private void Awake()
    {
        menuControl = new MenuUIControl();

        menuControl.uicontrol.left.performed += ctx => moveLeft();
        menuControl.uicontrol.right.performed += ctx => moveRight();
        menuControl.uicontrol.selectLevel.performed += ctx => select();

        levelIndex = 0;

        menuControl.uicontrol.Enable();

    }
    void Start()
    {
        levelChecker = GameObject.FindGameObjectWithTag("levelChecker");
    }

    void Update()
    {
        if (levelIndex == 0)
        {
            level1UI.transform.localScale = new Vector3(0.375f, 0.375f, 0.375f);
            level2UI.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            level3UI.transform.localScale = new Vector3(0.175f, 0.175f, 0.175f);

            selectUI.transform.position = new Vector3(level1UI.transform.position.x + 0.37f, level1UI.transform.position.y + 2.63f, level1UI.transform.position.z);
        }
        else if (levelIndex == 1)
        {
            level1UI.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            level2UI.transform.localScale = new Vector3(0.275f, 0.275f, 0.275f);
            level3UI.transform.localScale = new Vector3(0.175f, 0.175f, 0.175f);

            selectUI.transform.position = new Vector3(level2UI.transform.position.x + 2.08f, level2UI.transform.position.y + 2.03f, level2UI.transform.position.z);

        }
        else if (levelIndex == 2)
        {
            level1UI.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            level2UI.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            level3UI.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

            selectUI.transform.position = new Vector3(level3UI.transform.position.x -0.96f, level3UI.transform.position.y + 1.8f, level3UI.transform.position.z);

        }

        if (levelChecker.GetComponent<levelcheckerscript>().levelUnlocked == 0)
        {
            level2UI.GetComponent<SpriteRenderer>().color = new Color(0.4196078f, 0.4196078f, 0.4196078f);
            level3UI.GetComponent<SpriteRenderer>().color = new Color(0.4196078f, 0.4196078f, 0.4196078f);

        }
        else if (levelChecker.GetComponent<levelcheckerscript>().levelUnlocked == 1)
        {
            level2UI.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
            level3UI.GetComponent<SpriteRenderer>().color = new Color(0.4196078f, 0.4196078f, 0.4196078f);

        }
        else if (levelChecker.GetComponent<levelcheckerscript>().levelUnlocked == 2)
        {
            level2UI.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
            level3UI.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);

        }
    }

    void moveLeft()
    {
        levelIndex --;
        if (levelIndex < 0)
        {
            levelIndex = levelChecker.GetComponent<levelcheckerscript>().levelUnlocked;
        }
    }

    void moveRight()
    {
        levelIndex ++;
        if (levelIndex > levelChecker.GetComponent<levelcheckerscript>().levelUnlocked)
        {
            levelIndex = 0;
        }
    }

    void select()
    {
        if (levelIndex == 0)
        {
            SceneManager.LoadScene("scene_1");

        }
        else if (levelIndex == 1)
        {
            SceneManager.LoadScene("scene_2");

        }
        else if (levelIndex == 2)
        {
            SceneManager.LoadScene("scene_3_new");

        }
    }
}
