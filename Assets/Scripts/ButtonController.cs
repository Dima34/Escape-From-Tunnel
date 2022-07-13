using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    MenuController menuController;

    public void OpenMainMenu(){
        menuController.OpenMainMenu();
    }

    public void OpenLevelMenu(){
        menuController.OpenLevelMenu();
    }

    public void OpenOptionsMenu(){
        menuController.OpenOptionsMenu();
    }

    public void ExitGame(){
        menuController.ExitGame();
    }
}
