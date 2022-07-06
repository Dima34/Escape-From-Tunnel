using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static void PlaySound(AudioSource audioSource, AudioClip sound){
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(sound);
        }
    }

    public static void PlaySoundOnce(AudioSource audioSource, AudioClip sound){
        audioSource.PlayOneShot(sound);
    }

    public static void StopSound(AudioSource audioSource){
        audioSource.Stop();
    }

}
