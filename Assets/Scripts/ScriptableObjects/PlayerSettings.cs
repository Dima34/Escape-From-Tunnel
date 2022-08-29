using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "NewPlayerSettings", menuName = "New Player Settings", order = 53)]
public class PlayerSettings : ScriptableObject {
    [SerializeField] SettingsData settingsDataObject;
    [SerializeField] public float Volume = 0f;
    [SerializeField] public int SelectedResolutionIndex;
    [SerializeField] public bool IsFullscreen = true;
    [SerializeField] public int SelectedQualityIndex;
}
