using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAction : MonoBehaviour
{
    public enum ActionType
    {
        StartGame,
        Quit,
        Level1,
        Level2,
        Level3,
        Back
    }

    public ActionType action;

    public MainMenuManager menu;

    public void Execute()
    {
        switch (action)
        {
            case ActionType.StartGame:
                menu.OpenLevelSelect();
                break;

            case ActionType.Quit:
                menu.QuitGame();
                break;

            case ActionType.Level1:
                menu.LoadLevel1();
                break;

            case ActionType.Level2:
                menu.LoadLevel2();
                break;

            case ActionType.Level3:
                menu.LoadLevel3();
                break;

            case ActionType.Back:
                menu.BackToMenu();
                break;
        }
    }
}