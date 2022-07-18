using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerData
{
    public int Coins = 0;
    public SettingsList Settings = new SettingsList();

    public PlayerData(){

    }

    public PlayerData(int coins){
        Coins = coins; 
    }
}

[Serializable]
public class SettingsList {
    public float Volume = 0;
    public int Resolution = 0;
    public bool IsFullscreen = true;
    public int Quality = 0;
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

