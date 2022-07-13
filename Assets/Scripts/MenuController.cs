using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject LevelMenu;
    [SerializeField] GameObject OptionsMenu;


    public void ExitGame(){
        Application.Quit();
    }

    public void OpenMainMenu(){
        CloseAllMenus();
        MainMenu.active = true;
    }

    public void OpenLevelMenu(){
        CloseAllMenus();
        LevelMenu.active = true;
    }
    
    public void OpenOptionsMenu(){
        CloseAllMenus();
        OptionsMenu.active = true;
    }

    public void CloseAllMenus(){
        MainMenu.active = false;
        LevelMenu.active = false;
        OptionsMenu.active = false;
    }
}
