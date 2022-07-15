using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject GameUI;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject GameOverMenu;
    [SerializeField] GameObject SuccessMenu;

    private void Start() {
        gameManager.OnPauseToggle += HandlePause;
        OpenGameUI();
    }

    public void OpenGameUI(){
        CloseAllMenus();
        GameUI.SetActive(true);
    }

    public void OpenPauseMenu(){
        CloseAllMenus();
        PauseMenu.SetActive(true);
    }

    public void OpenGameOverMenu(){
        CloseAllMenus();
        GameOverMenu.SetActive(true);
    }

    public void OpenSuccessMenu(){
        CloseAllMenus();
        SuccessMenu.SetActive(true);
    }

    public void CloseAllMenus(){
        GameUI.SetActive(false);
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        SuccessMenu.SetActive(false);
    }

    public void ExitGame(){
        Application.Quit();
    } 

    public void HandlePause(bool isPaused){
        if (isPaused)
        {
            OpenPauseMenu();
        } else{
            OpenGameUI();
        }
    }
}
