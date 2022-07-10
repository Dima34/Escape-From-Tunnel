using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject LevelMenu;
    [SerializeField] GameObject OptionsMenu;



    public void toggleStart(){
        SceneController.NextLevel();
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void CloseAllMenus(){
        MainMenu.active = false;
        LevelMenu.active = false;
        OptionsMenu.active = false;
    }
}
