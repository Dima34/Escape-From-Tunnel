using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static void NextLevel(){
        int sceneAmount = SceneManager.GetAllScenes().Length;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == sceneAmount){
            currentSceneIndex = 0;
        }else{
            currentSceneIndex ++;
        }

        SceneManager.LoadScene(currentSceneIndex);
    }

    public static void ReloadScene(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
