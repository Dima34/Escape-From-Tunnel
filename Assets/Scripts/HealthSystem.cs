using System;
using System.Collections;
using UnityEngine;


[RequireComponent(typeof(CollisionTrigger))]
public class HealthSystem : MonoBehaviour
{
    [SerializeField] GameObject ExplosionObject;
    [SerializeField] int MaxHeartAmount = 3;
    [SerializeField] int HealthCreateCapacity = 1;

    [Header("Damage in Hearts")]
    [SerializeField] int LaserDamage = 1;
    [SerializeField] int BombDamage = 3;
    [SerializeField] int ObstacleDamage = 1;


    string DamageSourceTag;
    int HeartAmount;
    CollisionTrigger collisionTrigger;
    GameManager gameManager;
    Coroutine LaserDamageCoroutine;
    public event Action<int, int> OnHealthChange = delegate {};



    void Start()
    {
        collisionTrigger = GetComponent<CollisionTrigger>();
        gameManager = FindObjectOfType<GameManager>();

        // Subscribe to collision events for handling damage
        collisionTrigger.OnRocketBump += RocketBump;

        HeartAmount = MaxHeartAmount;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            ModifyHealth(-1);
        }
    }

    void BombHit(GameObject HitSource){
    }

    void LaserHit(GameObject HitSource){
        ModifyHealth(-LaserDamage);
    }

    void RocketBump(GameObject HitSource){
        string BumpObjectTag = HitSource.tag;
        DamageSourceTag = BumpObjectTag;

        switch (BumpObjectTag)
        {
            case "Obstacle":
                ModifyHealth(-ObstacleDamage);
                break;
            case "Bomb":
                ModifyHealth(-BombDamage);
                break;
            case "LaserRay":
                if(LaserDamageCoroutine == null){
                    LaserDamageCoroutine = StartCoroutine(LaserDamageProcess());
                }
                break;
            case "HealthCreate":
                ModifyHealth(HealthCreateCapacity);
                break;
            default:
                break;
        }
    }

    IEnumerator LaserDamageProcess(){
        ModifyHealth(-LaserDamage);
        yield return new WaitForSeconds(1);
        LaserDamageCoroutine = null;
    }

    void ModifyHealth(int AmountToAdd){
        HeartAmount += AmountToAdd;

        if(HeartAmount < 0 ) HeartAmount = 0;
        if(HeartAmount > MaxHeartAmount) HeartAmount = MaxHeartAmount;

        if(HeartAmount == 0){
            print("Player death");
            PlayerDeathSequence();
        }

        OnHealthChange(HeartAmount, MaxHeartAmount);
    }

    void PlayerDeathSequence(){
        gameManager.StartReloadSequence();
        Instantiate(ExplosionObject, transform.position, transform.rotation);
    }

    public int GetMaxHeartAmount(){
        return MaxHeartAmount;
    }   
}
