using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject afterCollisionObject;
    [SerializeField] public float Damage = 15f;

    private void Awake()
    {
        GetComponent<AudioSource>().Play();
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
