using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision other) {
        Destroy(this.gameObject);
    }
}
