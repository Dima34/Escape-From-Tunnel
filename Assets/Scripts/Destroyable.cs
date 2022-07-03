using System;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    [SerializeField] float MaxHealth = 100f;
    [SerializeField] GameObject ExplosionObject;

    public event Action<float, float> OnHealthChange = delegate {};

    private float healthAmount;

    private void OnEnable() {
        healthAmount = MaxHealth;
    }
    
    private void OnCollisionEnter(Collision other) {
        GameObject gameObject = other.gameObject;

        if(gameObject.tag == "Bomb"){
            healthAmount -= gameObject.GetComponent<Bomb>().Damage;
            OnHealthChange(healthAmount,MaxHealth);
            checkHealth();
            print("My health is - " + healthAmount);
        }
    }

    private void checkHealth(){
        if(healthAmount <= 0){
            Destroy(this.gameObject);
            Instantiate(ExplosionObject, transform.position, transform.rotation);
        }
    }

   

}
