using UnityEngine;

[CreateAssetMenu(fileName = "FileManager", menuName = "New FileManager", order = 54)]
public class FileManager : ScriptableObject {
    public SettingsData SettingsData;
    public PlayerSettings PlayerSettings;
    public PlayerData PlayerData;

    string savePat = "";

    // public void GetSettingsData(){
    //     SettingsData localVersion = getLocalVersion<SettingsData>();
    // }

    // public void GetPlayerSettings(){
    //     PlayerSettings localVersion = getLocalVersion<PlayerSettings>();
    // }

    // public void GetPlayerData(){
    //     PlayerData localVersion = getLocalVersion<PlayerData>();
    // }

    // T getLocalVersion<T>(){
    //     T localObj;

    //     return (T)localObj;
    // }

    // T saveLocalVersion<T>(){

    // }
}