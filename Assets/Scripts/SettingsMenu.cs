using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] DataStorageHandler dataStorage;
    [SerializeField] AudioMixer audioMixer;

    [SerializeField] Slider volumeSlider;
    [SerializeField] TMPro.TMP_Dropdown resolutionDropDown;
    [SerializeField] Toggle fullScreenToggle;
    [SerializeField] TMPro.TMP_Dropdown QualityDropDown;



    private void Start() {

    }

    // fill settings menu based on saved data
    void fillMenu(){
        PlayerData currentData =  dataStorage.GetCurrentData();
        SettingsList settingList = currentData.Settings;

        // create options in dropdowns

        // create an quality options list
        Resolution[] resolutionList = OptionsData.GetResolutionList();
        string[] qualityOptions = new string[resolutionList.Length];

        for (int i = 0; i < resolutionList.Length; i++)
        {
            qualityOptions[i] = resolutionList[i].GetName();
        }


        // TODO: Fill the list of options
        // resolutionDropDown.AddOptions(qualityOptions);
    }

}
