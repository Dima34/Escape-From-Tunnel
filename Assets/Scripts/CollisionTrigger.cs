using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class CollisionTrigger : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [Header("Impact sounds")]
    [SerializeField] AudioClip LaserSound;
    [SerializeField] AudioClip ObstacleSound;


    
    // Variable for Cheats in Cheat script
    [HideInInspector]
    public bool isCollisionDisabled = false;

    GameManager GameManagerObj;

    // Creating an event for damage
    public delegate void HitHandler(GameObject HitSource);
    public event HitHandler OnRocketBump;



    private void Start() {
        GameManagerObj = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter(Collision other)
    {
        GameObject CollidedObj = other.gameObject;

        if (!isCollisionDisabled)
        {
            switch (CollidedObj.tag)
            {
                case "Finish":
                    GameManagerObj.StartLevelSuccesSequence();
                    break;
                case "Obstacle":
                    SoundManager.PlaySound(audioSource, ObstacleSound);
                    OnRocketBump(CollidedObj);
                    break;
                case "Bomb":
                    OnRocketBump(CollidedObj);
                    break;
                
                default:
                    SoundManager.PlaySound(audioSource, ObstacleSound);
                    break;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject CollidedObj = other.gameObject;

        if (!isCollisionDisabled)
        {
            switch (CollidedObj.tag)
            {
                case "LaserRay":
                    OnRocketBump(CollidedObj);
                    break;
                case "HealthCreate":
                    OnRocketBump(CollidedObj);
                    break;
            }
        }
    }

    void OnTriggerStay(Collider other) {
        if (!isCollisionDisabled)
        {
            switch (other.gameObject.tag)
            {
                case "LaserRay":
                    SoundManager.PlaySound(audioSource, LaserSound);
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (!isCollisionDisabled)
        {
            SoundManager.StopSound(audioSource);
        }
    }
}
