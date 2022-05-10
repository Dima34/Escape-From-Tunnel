using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionTrigger : MonoBehaviour
{
    [SerializeField] int LevelLoadDelay = 3;
    [SerializeField] AudioClip successSound;
    [SerializeField] AudioClip crashSound;

    AudioSource audio;

    bool isTransitioning = true; // bool has default false value

    private void Start() {
        audio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other) {

        if (isTransitioning)
        {
            switch (other.gameObject.tag){
                case "Fuel":
                    Debug.Log("You just picked up a fuel");
                    break;
                case "Finish":
                    StartEndSequence();
                    break;
                case "Friendly":
                    Debug.Log("It`s our friend");
                    break;
                default:
                    StartCrashSequence();
                    break;                
            }
        }        

    }

    void StartCrashSequence(){
        setAudio(crashSound);
        disableControls();
        isTransitioning = false;
        Invoke("ReloadScene", LevelLoadDelay);
    }

    void StartEndSequence(){
        setAudio(successSound);
        disableControls();
        isTransitioning = false;
        Invoke("NextLevel", LevelLoadDelay);
    }

    void disableControls(){
        Movement movementHandler = GetComponent<Movement>();
        movementHandler.enabled = false;
    }

    void ReloadScene(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void setAudio(AudioClip audioClip){
        audio.Stop();
        audio.PlayOneShot(audioClip);
    }

    void NextLevel(){
        int sceneAmount = SceneManager.GetAllScenes().Length;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == sceneAmount){
            currentSceneIndex = 0;
        }else{
            currentSceneIndex ++;
        }

        SceneManager.LoadScene(currentSceneIndex);
    }
}
