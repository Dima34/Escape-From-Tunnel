using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    [Header("Options fields")]
    [SerializeField] Slider VolSlider;
    [SerializeField] TMPro.TMP_Dropdown ResolutionDropDown;
    [SerializeField] Toggle FullScreenCheckbox;
    [SerializeField] TMPro.TMP_Dropdown QualityDropDown;
    [SerializeField] Resolutions CurrentRS = 0 ;

    Resolution[] ResolutionList = new Resolution[]{
        new Resolution(1920, 1080),
        new Resolution(1600, 900),
        new Resolution(1440, 900),
        new Resolution(1366, 768),
        new Resolution(1280, 1024),
        new Resolution(1280, 720)
    };    

    float CurrentVol;
    Resolution CurrentRes;
    bool IsFullScreen = false;
    int CurrentQuality;

    private void Start() {
        // Debug.Log("Current res - " + Screen.currentResolution);
        CurrentRes = ResolutionList[0];

        // Sync load settings with settings screen
        // Fullscreen
        FullScreenCheckbox.isOn = Screen.fullScreen;
        // Volume
        float loadVol;
        audioMixer.GetFloat("MainValue", out loadVol);
        VolSlider.value = loadVol;
    }

    public void ChangeVolume(float value){
        audioMixer.SetFloat("MainValue",value);
    }

    public void SetResolution(int value){

        Debug.Log("Res list len - " + ResolutionList.Length + " value - " + value);
        
        if(value < ResolutionList.Length){
            CurrentRes = ResolutionList[value];
        } else{
            CurrentRes = ResolutionList[0];
        }

        CurrentRes.SetCurrent(IsFullScreen);

        Debug.Log("Current res - " + Screen.currentResolution);
    }

    public void ToggleFullScreen(bool isFullScreen){
        IsFullScreen = isFullScreen;
        CurrentRes.SetCurrent(IsFullScreen);
    }

    public void SetQuality(int value){
        QualitySettings.SetQualityLevel(value);
    }

}

public enum Resolutions
{
    r1920x1080 = 0,
    r1600x900 = 1,
    r1440x900 = 2,
    r1366x768 = 3,
    r1280x1024 = 4,
    r1280x720 = 5 
}

class Resolution{
    public int width;
    public int height;

    public Resolution(int width, int height){
        this.width = width;
        this.height = height;
    }

    public void SetCurrent(bool isFullScreen){
        Screen.SetResolution(width, height, isFullScreen);
    }
}
