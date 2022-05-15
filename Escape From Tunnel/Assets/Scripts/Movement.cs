using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] float PushForce;
    [SerializeField] float TurnForce;
    [SerializeField] float TankCapacity;
    [SerializeField] float FuelConsumtion;
    [SerializeField] AudioClip engineSound;
    [SerializeField] Text fuelText;

    [SerializeField] ParticleSystem mainThrustParticles;
    [SerializeField] ParticleSystem leftThrustParticles;
    [SerializeField] ParticleSystem rightThrustParticles;



    Rigidbody rb;
    AudioSource audio;
    float fuelAmount;

    bool isAlive;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        fuelAmount = TankCapacity;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTankFull()){
            HandlePush();
            HandleTurn();
        }
        
        HandleFuelUI();
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
            cosumeFuel();
        }
        else if(Input.GetAxisRaw("Horizontal") == 1)
        {
            RotateLeft();
            cosumeFuel();
        }
    }

    void StopThrusting()
    {
        audio.Stop();
        mainThrustParticles.Stop();
    }

    void StartThrusting()
    {
        mainThrustParticles.Play();
        if (!audio.isPlaying)
        {
            audio.PlayOneShot(engineSound);
        }
        rb.AddRelativeForce(0, 1 * PushForce * Time.deltaTime, 0);
        cosumeFuel();
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

    public void HandleFuelUI(){
        fuelText.text = ((int)fuelAmount).ToString();
    }

    public void cosumeFuel(){
        if(isTankFull()){
            fuelAmount -= FuelConsumtion * Time.deltaTime;
        }
    }

    public bool isTankFull(){
        if(fuelAmount <= 0){
            return false;
        }

        return true;
    }
}
