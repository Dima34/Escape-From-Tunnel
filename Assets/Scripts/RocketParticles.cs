using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CollisionTrigger))]
public class RocketParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem succesParticles;
    [SerializeField] ParticleSystem crashParticles;

    GameManager GameManagerObj;

    
    void Start()
    {
        GameManagerObj = FindObjectOfType<GameManager>();


        GameManagerObj.OnCrashEvent += PlayCrashParticles;
        GameManagerObj.OnLevelSuccessEvent += PlaySuccessParticles;
    }

    void PlayCrashParticles(){
        crashParticles.Play();
    }

    void PlaySuccessParticles(){
        succesParticles.Play();
    }
}
