using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject afterCollisionObject;
    [SerializeField] public float minDamage = 15f;
    [SerializeField] public float maxDamage = 50f;

    [HideInInspector] public int Damage;

    private void Awake()
    {
        GetComponent<AudioSource>().Play();
        Damage = Mathf.FloorToInt(Random.Range(minDamage, maxDamage));
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCrashSequnce();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Obstacle") StartCrashSequnce();
    }

    void StartCrashSequnce()
    {
        Instantiate(afterCollisionObject, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
