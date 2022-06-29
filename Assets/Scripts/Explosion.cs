using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] float deleteDelay = 2f;

    private void Awake()
    {
        explosionParticles.Play();
        Destroy(this.gameObject, deleteDelay);
    }
}
