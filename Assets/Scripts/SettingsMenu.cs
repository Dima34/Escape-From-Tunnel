using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    [SerializeField] Slider volumeSlider;
    [SerializeField] TMPro.TMP_Dropdown resolutionDropDown;
    [SerializeField] Toggle fullScreenToggle;
    [SerializeField] TMPro.TMP_Dropdown qualityDropDown;

    Coroutine soundApplyCoroutine;
    PlayerData currentData;

    // void Awake() {
    //     handleChangeListeners();
    // }

    // fill settings menu based on saved data
    // void fillMenu(){
    //     currentData = dataStorage.GetCurrentData();
    //     SettingsList settingList = currentData.Settings;
    //     applySettings();

    // // create options in dropdowns

    //     // create an quality options list
    //     // Resolution[] resolutionList = OptionsData.GetResolutionList();
    //     Resolution[] resolutionList = new Resolution[1];
        
    //     List<string> resolutionOptions = new List<string>();

    //     for (int i = 0; i < resolutionList.Length; i++)
    //     {
    //         resolutionOptions.Add(resolutionList[i].ToString());
    //     }

    //     // Clear options dropdowh from default data
    //     resolutionDropDown.options = new List<TMPro.TMP_Dropdown.OptionData>();
    //     resolutionDropDown.AddOptions(resolutionOptions);

    //     // Check the right resolution
    //     resolutionDropDown.SetValueWithoutNotify(settingList.Resolution);


    // // create a resolution options list
    //     // Quality[] qualityList = OptionsData.GetQualities();
    //     Quality[] qualityList = new Quality[1];
    //     List<string> qualityOptions = new List<string>();

    //     for (int i = 0; i < qualityList.Length; i++)
    //     {
    //         qualityOptions.Add(qualityList[i].GetName());
    //     }

    //     // Clear options dropdowh from default data
    //     qualityDropDown.options = new List<TMPro.TMP_Dropdown.OptionData>();
    //     qualityDropDown.AddOptions(qualityOptions);

    //     // Check the right resolution
    //     qualityDropDown.SetValueWithoutNotify(settingList.Quality);


    // // fill a full screen toggle
    //     fullScreenToggle.isOn = settingList.IsFullscreen;


    // // set a sound volume slider
    //     volumeSlider.SetValueWithoutNotify(settingList.Volume);
    // }

    // void handleChangeListeners()
    // {
    //     volumeSlider.onValueChanged.AddListener(delegate { changeVolumeSequence(); });
    //     resolutionDropDown.onValueChanged.AddListener(delegate { changeOptionsSequence(); });
    //     fullScreenToggle.onValueChanged.AddListener(delegate { changeOptionsSequence(); });
    //     qualityDropDown.onValueChanged.AddListener(delegate { changeOptionsSequence(); });
    // }

    // IEnumerator VolumeSaveProcess(){
    //     yield return new WaitForSeconds(0.5f);
    //     changeOptionsSequence();
    // }

    // void handleVolumeChange()
    // {
    //     if(soundApplyCoroutine == null){
    //         soundApplyCoroutine = StartCoroutine("VolumeSaveProcess");
    //     } else{
    //         StopCoroutine(soundApplyCoroutine);
    //         soundApplyCoroutine = StartCoroutine("VolumeSaveProcess");
    //     }
    // }

    // void changeVolumeSequence(){
    //     changeOptions();
    //     applySettings();
    //     handleVolumeChange();
    // }

    // void changeOptionsSequence(){
    //     changeOptions();
    //     applySettings();
    //     saveChangedOptions();
    // }

    // void changeOptions(){
    //     PlayerData newPlayerData = dataStorage.GetCurrentData();
    //     SettingsList newSettings = new SettingsList(
    //         volumeSlider.value,
    //         resolutionDropDown.value,
    //         fullScreenToggle.isOn,
    //         qualityDropDown.value
    //         // ,newPlayerData.Settings.ControlsList
    //     );

    //     newPlayerData.Settings = newSettings;
    //     currentData = newPlayerData;
    // }

    // void saveChangedOptions(){
    //     dataStorage.SaveData(currentData);
    // }
    
    // void applySettings(){
    //     SettingsList currentSettings = currentData.Settings;

    //     Resolution currentRes = OptionsData.GetResolutionList()[currentSettings.Resolution];
    //     bool isFullscreen = currentData.Settings.IsFullscreen;

    //     audioMixer.SetFloat("mainVolume" ,currentSettings.Volume);
    //     Screen.SetResolution(currentRes.GetWidth(), currentRes.GetHeight(), isFullscreen);
    //     QualitySettings.SetQualityLevel(currentSettings.Quality);
    // }
}
