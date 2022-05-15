using UnityEngine;


public class CollisionTrigger : MonoBehaviour
{
    [SerializeField] int LevelLoadDelay = 3;
    [SerializeField] AudioClip successSound;
    [SerializeField] AudioClip crashSound;

    [SerializeField] ParticleSystem succesParticles;
    [SerializeField] ParticleSystem crashParticles;

    AudioSource audio;

    bool isTransitioning = true; // bool has default false value
    bool isCollisionDisabled = false;

    private void Start() {
        audio = GetComponent<AudioSource>();
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
                case "Fuel":
                    break;
                case "Finish":
                    StartEndSequence();
                    break;
                case "Friendly":
                    break;
                default:
                    StartCrashSequence();
                    break;                
            }
        }        

    }

    void disableControls(){
        Movement movementHandler = GetComponent<Movement>();
        movementHandler.enabled = false;
    }

    void setAudio(AudioClip audioClip){
        audio.Stop();
        audio.PlayOneShot(audioClip);
    }

    void StartCrashSequence(){
        crashParticles.Play();
        setAudio(crashSound);
        disableControls();
        isTransitioning = false;
        Invoke("ReloadScene", LevelLoadDelay);
    }

    void StartEndSequence(){
        succesParticles.Play();
        setAudio(successSound);
        disableControls();
        isTransitioning = false;
        Invoke("NextLevel", LevelLoadDelay);
    }

    public void ReloadScene(){
        SceneController.ReloadScene();
    }

    public void NextLevel(){
        SceneController.NextLevel();
    }
    
}
