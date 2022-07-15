using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    void Update()
    {
        HandleCheats();
    }

    void HandleCheats()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            NextLevel();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            // CollisionTriggerScript.isCollisionDisabled = !CollisionTriggerScript.isCollisionDisabled;
        }
    }

    public void NextLevel()
    {
        SceneController.NextLevel();
    }
}
