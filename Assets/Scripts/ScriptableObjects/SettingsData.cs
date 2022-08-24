using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
[CreateAssetMenu(fileName = "NewSettingsData", menuName = "New Settings Data", order = 52)]
public class SettingsData : ScriptableObject {
    [SerializeField] public List<Control> Controls = new List<Control>(){
        new Control("Throttle", KeyCode.Space),
        new Control("Left", KeyCode.A),
        new Control("Right", KeyCode.D),
        new Control("Shoot", KeyCode.W),
        new Control("Pause", KeyCode.Escape)
    };

    [SerializeField] public List<Resolution> ResolutionsList = new List<Resolution>
    {
        new Resolution(1920, 1080),
        new Resolution(1600, 900),
        new Resolution(1440, 900),
        new Resolution(1366, 768),
        new Resolution(1280, 1024),
        new Resolution(1280, 720),
    };

    [SerializeField] public List<Quality> QualityList = new List<Quality>{
        new Quality("Low", 0),
        new Quality("Medium", 1),
        new Quality("High", 2),
        new Quality("Ultra", 3),
    };
}

[Serializable]
public class Quality{
    public string Name;
    public int SettingIndex;

    public Quality(string name, int settingIndex){
        Name = name;
        SettingIndex = settingIndex;
    }

    public string GetName(){
        return Name;
    }

    public int GetSettingIndex(){
        return SettingIndex;
    }
}


[Serializable]
public class Resolution{
    public int Width;
    public int Height;

    public Resolution(int width, int height){
        Width = width;
        Height = height;
    }

    public int GetWidth(){
        return Width;
    }

    public int GetHeight(){
        return Height;
    }

    public override string ToString()
    {
        return (Width + "x" + Height);
    }
}

[Serializable] 
public class Control{
    public string Name;
    public KeyCode KeyCode;

    public Control(string name, KeyCode keyCode){
        Name = name;
        KeyCode = keyCode;
    }
}