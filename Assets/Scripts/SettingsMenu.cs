using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] DataStorageHandler dataStorage;
    [SerializeField] AudioMixer audioMixer;

    [SerializeField] Slider volumeSlider;
    [SerializeField] TMPro.TMP_Dropdown resolutionDropDown;
    [SerializeField] Toggle fullScreenToggle;
    [SerializeField] TMPro.TMP_Dropdown qualityDropDown;

    Coroutine soundApplyCoroutine;
    PlayerData currentData;

    void Awake() {
        dataStorage.OnDataLoadedEvent += fillMenu;
        handleChangeListeners();
    }

    // fill settings menu based on saved data
    void fillMenu(){
        currentData = dataStorage.GetCurrentData();
        SettingsList settingList = currentData.Settings;

    // create options in dropdowns

        // create an quality options list
        Resolution[] resolutionList = OptionsData.GetResolutionList();
        List<string> resolutionOptions = new List<string>();

        for (int i = 0; i < resolutionList.Length; i++)
        {
            resolutionOptions.Add(resolutionList[i].GetName());
        }

        // Clear options dropdowh from default data
        resolutionDropDown.options = new List<TMPro.TMP_Dropdown.OptionData>();
        resolutionDropDown.AddOptions(resolutionOptions);

        // Check the right resolution
        resolutionDropDown.SetValueWithoutNotify(settingList.Resolution);


    // create a resolution options list
        Quality[] qualityList = OptionsData.GetQualities();
        List<string> qualityOptions = new List<string>();

        for (int i = 0; i < qualityList.Length; i++)
        {
            qualityOptions.Add(qualityList[i].GetName());
        }

        // Clear options dropdowh from default data
        qualityDropDown.options = new List<TMPro.TMP_Dropdown.OptionData>();
        qualityDropDown.AddOptions(qualityOptions);

        // Check the right resolution
        qualityDropDown.SetValueWithoutNotify(settingList.Quality);


    // fill a full screen toggle
        fullScreenToggle.isOn = settingList.IsFullscreen;


    // set a sound volume slider
        volumeSlider.SetValueWithoutNotify(settingList.Volume);
    }

    void handleChangeListeners()
    {
        volumeSlider.onValueChanged.AddListener(delegate { handleVolumeChange(); });
        resolutionDropDown.onValueChanged.AddListener(delegate { Debug.Log("resolutionDropDown"); saveChangedOptions(); });
        fullScreenToggle.onValueChanged.AddListener(delegate { Debug.Log("fullScreenToggle"); saveChangedOptions(); });
        qualityDropDown.onValueChanged.AddListener(delegate {Debug.Log("qualityDropDown");  saveChangedOptions(); });
    }

    IEnumerator VolumeSaveProcess(){
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Volume process");
        saveChangedOptions();
    }

    void handleVolumeChange()
    {
        if(soundApplyCoroutine == null){
            soundApplyCoroutine = StartCoroutine("VolumeSaveProcess");
        } else{
            StopCoroutine(soundApplyCoroutine);
            soundApplyCoroutine = StartCoroutine("VolumeSaveProcess");
        }
    }

    void saveChangedOptions(){
        Debug.Log("Save changes");
        PlayerData newPlayerData = dataStorage.GetCurrentData();
        SettingsList newSettings = new SettingsList(
            volumeSlider.value,
            resolutionDropDown.value,
            fullScreenToggle.isOn,
            qualityDropDown.value,
            newPlayerData.Settings.ControlsList
        );

        newPlayerData.Settings = newSettings;

        currentData = newPlayerData;
        dataStorage.SaveData(currentData);
    }
    
}
