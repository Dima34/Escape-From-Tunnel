using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] ParticleSystem successParticles;

    CollisionTrigger rocketColisionTrigger;
    GameManager gameManager;
    
    void Start()
    {
        rocketColisionTrigger = FindObjectOfType<CollisionTrigger>();
        gameManager = FindObjectOfType<GameManager>();

        rocketColisionTrigger.OnRocketBump += onRocketLanded;
    }

    void onRocketLanded(GameObject HitSource){
        if(HitSource.tag == "Finish" && gameManager.IsPlayerAlive()){
            successParticles.Play();
            gameManager.StartLevelSuccesSequence();
        }
    }
}
