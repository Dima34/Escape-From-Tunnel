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
        SoundManager.PlaySoundOnce(audio,crashSound);
        DisableAlive();
    }

    public void StartLevelSuccesSequence(){
        OnLevelSuccessEvent?.Invoke();
        SoundManager.PlaySoundOnce(audio,successSound);
        DisableAlive();
    }

    public void DisableAlive(){
        isAlive = false;
    }

    public bool IsPlayerAlive(){
        return isAlive;
    }
}
