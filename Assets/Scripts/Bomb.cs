using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject afterCollisionObject;

    private void Awake() {
        GetComponent<AudioSource>().Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(afterCollisionObject, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

    
}
