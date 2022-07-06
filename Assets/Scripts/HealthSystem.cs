using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CollisionTrigger))]
public class HealthSystem : MonoBehaviour
{
    [SerializeField] public int MaxHeartAmount = 3;

    [Header("Damage in Hearts")]
    [SerializeField] int LaserDamage = 1;
    [SerializeField] int BombDamage = 3;
    [SerializeField] int ObstacleDamage = 1;


    private int HeartAmount;
    CollisionTrigger collisionTrigger;
    public event Action<int, int> OnHealthChange = delegate {};



    void Start()
    {
        collisionTrigger = GetComponent<CollisionTrigger>();

        // Subscribe to collision events for handling damage
        collisionTrigger.OnBombHit += BombHit;
        collisionTrigger.OnLaserHit += LaserHit;
        collisionTrigger.OnObstacleHit += ObstacleHit;

        HeartAmount = MaxHeartAmount;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            ModifyHealth(-1);
        }
    }

    void BombHit(){
        ModifyHealth(-BombDamage);
    }

    void LaserHit(){
        ModifyHealth(-LaserDamage);
    }

    void ObstacleHit(){
        ModifyHealth(-ObstacleDamage);
    }

    void ModifyHealth(int AmountToAdd){
        HeartAmount += AmountToAdd;

        if(HeartAmount < 0 ) HeartAmount = 0;
        if(HeartAmount > MaxHeartAmount) HeartAmount = MaxHeartAmount;

        print("Heart amount - " + HeartAmount);

        OnHealthChange(HeartAmount, MaxHeartAmount);
    }
}
