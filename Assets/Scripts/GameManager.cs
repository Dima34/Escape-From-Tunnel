using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    [SerializeField] int LevelLoadDelay = 5;
    [SerializeField] int LevelReloadDelay = 3;

    [SerializeField] AudioClip successSound;
    [SerializeField] AudioClip crashSound;

    AudioSource audio;    
    bool isAlive = true;

    public delegate void OnReloadHandler();
    public event OnReloadHandler OnCrashEvent;

    public delegate void OnEndHandler();
    public event OnEndHandler OnLevelSuccessEvent;

    private void Start() {
        audio = GetComponent<AudioSource>();
    }

    public void StartCrashSequence(){
        OnCrashEvent?.Invoke();
        PlayOnce(crashSound);
        StartReloadSequence();
    }

    public void StartLevelSuccesSequence(){
        OnLevelSuccessEvent?.Invoke();
        PlayOnce(successSound);
        StartEndSequence();
    }

    public void StartReloadSequence()
    {
        print("Manager reload");
        Invoke("ReloadScene", LevelLoadDelay);
        MakePlayerDead();
    }

    public void StartEndSequence()
    {
        print("Manager end");
        Invoke("NextLevel", LevelReloadDelay);
        MakePlayerDead();
    }

    public void ReloadScene()
    {
        SceneController.ReloadScene();
    }

    public void NextLevel()
    {
        SceneController.NextLevel();
    }

    public void MakePlayerDead()
    {
        isAlive = false;
    }

    public bool IsPlayerAlive(){
        return isAlive;
    }

    void PlayOnce(AudioClip audioClip){
        audio.Stop();
        audio.PlayOneShot(audioClip);
    }
}
