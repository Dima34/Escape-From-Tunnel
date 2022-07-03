using System;
using System.Collections;
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
        }
    }

    private void checkHealth(){
        if(healthAmount <= 0){
            startDestroySequence();
        }
    }

    
    void startDestroySequence(){
        StartCoroutine(DestroyAnim());
    }

    // Animation of destroying
    IEnumerator DestroyAnim(){
        Instantiate(ExplosionObject, transform.position, transform.rotation);
        yield return new WaitForSeconds(1);

        Instantiate(ExplosionObject, transform.position, transform.rotation);
        yield return new WaitForSeconds(1);

        Instantiate(ExplosionObject, transform.position, transform.rotation);
        yield return new WaitForSeconds(1);

        DestroyTheObject();
    }

    void DestroyTheObject(){
        Destroy(this.gameObject);
    }

}
