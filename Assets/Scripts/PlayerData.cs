using System;

public class PlayerData
{
    public int Coins = 0;
    public SettingsList Settings = new SettingsList();

    public PlayerData(){

    }

    public PlayerData(
        int coins,
        float volume,
        int resolution,
        bool isFullscreen,
        int quality
    ){
        Coins = coins;
        Settings.Volume = volume;
        Settings.Resolution = resolution;
        Settings.IsFullscreen = isFullscreen;
        Settings.Quality = quality;
    }
}

[Serializable]
public class SettingsList {
    public float Volume = 0;
    public int Resolution = 0;
    public bool IsFullscreen = true;
    public int Quality = 3;
    public ControlsList ControlsList;

    public SettingsList(){

    }

    public SettingsList(float volume, int resolution, bool isFullscreen, int quality, ControlsList controlsList){
        Volume = volume;
        Resolution = resolution;
        IsFullscreen = isFullscreen;
        Quality = quality;
        ControlsList = controlsList;
    }
}

