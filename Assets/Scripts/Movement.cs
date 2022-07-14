using UnityEngine;

public class Movement : MonoBehaviour
{
    [Tooltip("Embed separate audioSource")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip engineSound;

    [SerializeField] ParticleSystem mainThrustParticles;
    [SerializeField] ParticleSystem leftThrustParticles;
    [SerializeField] ParticleSystem rightThrustParticles;
    [SerializeField] float PushForce;
    [SerializeField] float TurnForce;

    Rigidbody rb;

    GameManager GameManagerObj;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameManagerObj = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManagerObj.IsPlayerAlive()){
            HandlePush();
            HandleTurn();
            HandleSound();
        } else{
            StopSound();
        }

    }

    public void HandlePush(){
        if(Input.GetAxisRaw("Jump") == 1)
        {
            StartThrusting();
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

    public void HandleSound(){
        if(
            Input.GetAxisRaw("Jump") == 1 ||
            Input.GetAxisRaw("Horizontal") != 0
        ){
            PlayThrustSound();
        } else{
            StopSound();
        }
    }

    void StartThrusting()
    {
        mainThrustParticles.Play();
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

    void TurnRocket(float force)
    {
        rb.freezeRotation = true;
        transform.Rotate(0, 0 ,force * Time.deltaTime);
        rb.constraints &= ~RigidbodyConstraints.FreezeRotationZ;
    }

    void PlayThrustSound(){
        SoundManager.PlaySound(audioSource, engineSound);
    }

    void StopSound(){
        SoundManager.StopSound(audioSource);
    }

}
