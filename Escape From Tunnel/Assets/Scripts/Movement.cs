using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] float PushForce;
    [SerializeField] float TurnForce;
    [SerializeField] AudioClip engineSound;

    [SerializeField] ParticleSystem mainThrustParticles;
    [SerializeField] ParticleSystem leftThrustParticles;
    [SerializeField] ParticleSystem rightThrustParticles;



    Rigidbody rb;
    AudioSource audio;

    PlayerState state;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        state = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state.isAlive){
            HandlePush();
            HandleTurn();
        }
    }

    public void HandlePush(){
        if(Input.GetAxisRaw("Jump") == 1)
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    public void HandleTurn(){

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            RotateRight();
        }
        else if(Input.GetAxisRaw("Horizontal") == 1)
        {
            RotateLeft();
        }
    }

    void StopThrusting()
    {
        audio.Stop();
    }

    void StartThrusting()
    {
        mainThrustParticles.Play();
        if (!audio.isPlaying)
        {
            audio.PlayOneShot(engineSound);
        }
        rb.AddRelativeForce(0, 1 * PushForce * Time.deltaTime, 0);
    }

    void RotateLeft()
    {
        TurnRocket(TurnForce);
        leftThrustParticles.Play();
    }

    void RotateRight()
    {
        TurnRocket(-TurnForce);
        rightThrustParticles.Play();
    }

    public void TurnRocket(float force)
    {
        rb.freezeRotation = true;
        transform.Rotate(0, 0 ,force * Time.deltaTime);
        rb.constraints &= ~RigidbodyConstraints.FreezeRotationZ;
    }

}
