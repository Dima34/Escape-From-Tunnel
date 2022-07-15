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
        MainMenu.SetActive(true);
    }

    public void OpenLevelMenu(){
        CloseAllMenus();
        LevelMenu.SetActive(true);
    }
    
    public void OpenOptionsMenu(){
        CloseAllMenus();
        OptionsMenu.SetActive(true);
    }

    public void CloseAllMenus(){
        MainMenu.SetActive(false);
        LevelMenu.SetActive(false);
        OptionsMenu.SetActive(false);
    }
}
