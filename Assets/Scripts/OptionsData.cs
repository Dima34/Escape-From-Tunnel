using System;
using UnityEngine;

public class OptionsData : MonoBehaviour
{
    public static Resolution[] GetResolutionList(){
        return _resolutionsList;
    }

    public static Quality[] GetQualities(){
        return _qualityList;
    }

    static Resolution[] _resolutionsList = new Resolution[]
    {
        new Resolution(1920, 1080, "1920x1080"),
        new Resolution(1600, 900, "1600x900"),
        new Resolution(1440, 900, "1440x900"),
        new Resolution(1366, 768, "1366x768"),
        new Resolution(1280, 1024, "1280x1024"),
        new Resolution(1280, 720, "1280x720"),
    };

    static Quality[] _qualityList = new Quality[]{
        new Quality("Low", 0),
        new Quality("Medium", 1),
        new Quality("High", 2),
        new Quality("Ultra", 3),
    };
}

[Serializable]
public class ControlsList{
    public KeyCode Throttle = KeyCode.Space;
    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;
    public KeyCode Shoot = KeyCode.W;
    public KeyCode Pause = KeyCode.Escape;

    public ControlsList(){

    }

    public ControlsList(
        KeyCode throttle,
        KeyCode left,
        KeyCode right,
        KeyCode shoot,
        KeyCode pause
    ){
        Throttle = throttle;
        Left = left;
        Right = right;
        Shoot = shoot;
        Pause = pause;
    }
}

[Serializable]
public class Quality{
    string _name;
    int _settingIndex;

    public Quality(string name, int settingIndex){
        _name = name;
        _settingIndex = settingIndex;
    }

    public string GetName(){
        return _name;
    }

    public int GetSettingIndex(){
        return _settingIndex;
    }
}


[Serializable]
public class Resolution{
    int _width;
    int _height;
    string _name;

    public Resolution(int width, int height, string name){
        _width = width;
        _height = height;
        _name = name;
    }

    public int GetWidth(){
        return _width;
    }

    public int GetHeight(){
        return _height;
    }

    public string GetName(){
        return _name;
    }

    public override string ToString()
    {
        return (_width + "x" + _height);
    }
}