using System;
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
    bool isPaused = false;

    public delegate void OnEndHandler();
    public event OnEndHandler OnLevelSuccessEvent;
    public event OnEndHandler OnLevelFailEvent;


    public event Action<bool> OnPauseToggle = delegate { };

    private void Start() {
        audio = GetComponent<AudioSource>();
    }

    private void Update() {
        HandlePause();
    }

    public void HandlePause(){
        if(Input.GetAxisRaw("Pause") == 1 && isAlive){
            isPaused = !isPaused;
            OnPauseToggle?.Invoke(isPaused);
        }
    }

    public void StartFailSequence(){
        OnLevelFailEvent?.Invoke();
        SoundManager.PlaySoundOnce(audio,crashSound);
    }

    public void StartLevelSuccesSequence(){
        OnLevelSuccessEvent?.Invoke();
        SoundManager.PlaySoundOnce(audio,successSound);
    }

    public void DisableAlive(){
        isAlive = false;
    }

    public bool IsPlayerAlive(){
        return isAlive;
    }
}
