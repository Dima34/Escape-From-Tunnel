using UnityEngine;

[CreateAssetMenu(fileName = "FileManager", menuName = "New FileManager", order = 54)]
public class FileManager : ScriptableObject {
    public SettingsData SettingsData;
    public PlayerSettings PlayerSettings;
    public PlayerData PlayerData;
}