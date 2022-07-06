using UnityEngine;
using System;

public class CollisionTrigger : MonoBehaviour
{
    // Variable for Cheats in GameManager
    [HideInInspector]
    public bool isCollisionDisabled = false;

    GameManager GameManagerObj;

    // Creating an event for each type of damage collisions
    public delegate void ObstacleHitHandler();
    public event ObstacleHitHandler OnObstacleHit;

    public delegate void BombHitHandler();
    public event BombHitHandler OnBombHit;

    public delegate void LaserHitHandler();
    public event LaserHitHandler OnLaserHit;


    private void Start() {
        GameManagerObj = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter(Collision other)
    {

        if (!isCollisionDisabled)
        {
            switch (other.gameObject.tag)
            {
                case "Finish":
                    GameManagerObj.StartLevelSuccesSequence();
                    break;
                case "Obstacle":
                    OnObstacleHit();
                    break;
                case "Bomb":
                    OnBombHit();
                    break;
                default:
                    break;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (!isCollisionDisabled)
        {
            switch (other.gameObject.tag)
            {
                case "LaserRay":
                    OnLaserHit();
                    break;
            }
        }
    }

}
