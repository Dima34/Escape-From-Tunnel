using UnityEngine;


public class CollisionTrigger : MonoBehaviour
{
    [SerializeField] int LevelLoadDelay = 3;
    [SerializeField] AudioClip successSound;
    [SerializeField] AudioClip crashSound;

    [SerializeField] ParticleSystem succesParticles;
    [SerializeField] ParticleSystem crashParticles;

    AudioSource audio;
    PlayerState state;


    bool isTransitioning = true; // bool has default false value
    bool isCollisionDisabled = false;

    private void Start() {
        audio = GetComponent<AudioSource>();
        state = GetComponent<PlayerState>();
    }

    private void Update() {
        Cheats();
    }

    void Cheats(){
        if(Input.GetKeyDown(KeyCode.L)){
            SceneController.NextLevel();
        }

        if(Input.GetKeyDown(KeyCode.C)){
            isCollisionDisabled =! isCollisionDisabled;
        }
    }

    void OnCollisionEnter(Collision other) {

        if (isTransitioning && !isCollisionDisabled)
        {
            switch (other.gameObject.tag){
                case "Finish":
                    StartEndSequence();
                    break;
                case "Friendly":
                    break;
                case "Obstacle":
                    StartCrashSequence();
                    break;        
                case "Bomb":
                    StartCrashSequence();
                    break;            
            }
        }       
    }

    void OnTriggerEnter(Collider other) {

        if (isTransitioning && !isCollisionDisabled)
        {
            switch (other.gameObject.tag){
                case "Obstacle":
                    StartCrashSequence();
                    break;                
            }
        }       
    }

    void setAudio(AudioClip audioClip){
        audio.Stop();
        audio.PlayOneShot(audioClip);
    }

    void StartCrashSequence(){
        crashParticles.Play();
        setAudio(crashSound);
        MakePlayerDead();
        isTransitioning = false;
        Invoke("ReloadScene", LevelLoadDelay);
    }

    void StartEndSequence(){
        succesParticles.Play();
        setAudio(successSound);
        MakePlayerDead();
        isTransitioning = false;
        Invoke("NextLevel", LevelLoadDelay);
    }

    public void ReloadScene(){
        SceneController.ReloadScene();
    }

    public void NextLevel(){
        SceneController.NextLevel();
    }

    public void MakePlayerDead(){
        state.isAlive = false;
    }

        
}
