using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerSettings", menuName = "New Player Settings", order = 53)]
public class PlayerSettings : ScriptableObject {
    public float _volume = 0f;
    public int _selectedResolution = 0;
    public bool _isFullscreen = true;
    public int _selectedQuality = 0;
}
