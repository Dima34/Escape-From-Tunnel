using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
 
    // Start is called before the first frame update
    void Start()
    {
        GameManagerObj = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
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
