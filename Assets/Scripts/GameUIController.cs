using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [SerializeField] GameObject GameUI;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject GameOverMenu;
    [SerializeField] GameObject SuccessMenu;

    public void OpenGameUI(){
        CloseAllMenus();
        GameUI.active = true;
    }

    public void OpenPauseMenu(){
        CloseAllMenus();
        PauseMenu.active = true;
    }

    public void OpenGameOverMenu(){
        CloseAllMenus();
        GameOverMenu.active = true;
    }

    public void OpenSuccessMenu(){
        CloseAllMenus();
        SuccessMenu.active = true;
    }

    public void CloseAllMenus(){
        GameUI.active = false;
        PauseMenu.active = false;
        GameOverMenu.active = false;
        SuccessMenu.active = false;
    }

    

    public void ExitGame(){
        Application.Quit();
    } 
}
