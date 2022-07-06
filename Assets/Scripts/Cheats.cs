using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    GameManager GameManagerObj;
 
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
            GameManagerObj.NextLevel();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            // CollisionTriggerScript.isCollisionDisabled = !CollisionTriggerScript.isCollisionDisabled;
        }
    }
}
