using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class CollisionTrigger : MonoBehaviour
{
    [SerializeField] int AfterDeathExplosionsAmount = 3;
    [SerializeField] AudioSource audioSource;

    [Header("Impact sounds")]
    [SerializeField] AudioClip LaserSound;
    [SerializeField] AudioClip ObstacleSound;


    
    // Variable for Cheats in Cheat script
    [HideInInspector]
    public bool isCollisionDisabled = false;

    GameManager gameManager;

    // Creating an event for damage
    public delegate void HitHandler(GameObject ContactorInfo);
    public event HitHandler OnRocketBump;
    public event HitHandler OnRocketTriggerStay;




    private void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter(Collision other)
    {
        GameObject CollidedObj = other.gameObject;

        if (!isCollisionDisabled && AfterDeathExplosionsAmount > 0)
        {
            OnRocketBump(CollidedObj);

            // Sound player. Bomb tag is excluded from playing default obstacle sound when bump
            switch (CollidedObj.tag){
                case "Bomb":
                    break;
                default:
                    SoundManager.PlaySound(audioSource, ObstacleSound);
                    break;
            }
        }

        if(!gameManager.IsPlayerAlive()){
            AfterDeathExplosionsAmount--;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject CollidedObj = other.gameObject;

        if (!isCollisionDisabled)
        {
           OnRocketBump(CollidedObj);
        }
    }

    void OnTriggerStay(Collider other) {
        if (!isCollisionDisabled)
        {
            switch (other.gameObject.tag)
            {
                case "LaserRay":
                    OnRocketTriggerStay(other.gameObject);
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
