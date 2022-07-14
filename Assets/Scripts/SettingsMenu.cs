using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void ChangeVolume(float value){
        Debug.Log("slider - " + value);
        audioMixer.SetFloat("Volume",value);
    }

    public void SetResolution(int value){
        Debug.Log("SetResolution - " + value);
    }

    public void ToggleFullScreen(bool isFullScreen){
        Debug.Log("Full screen is - " + isFullScreen);
    }

    public void SetQuality(int value){
        Debug.Log("SetResolution - " + value);
    }

}
