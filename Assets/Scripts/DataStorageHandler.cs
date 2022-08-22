using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;


public class DataStorageHandler : MonoBehaviour
{
    
    [SerializeField] float _volume = 0f;
    [SerializeField] int _selectedResolution = 0;
    [SerializeField] bool _isFullscreen = true;
    [SerializeField] int _selectedQuality = 0;


    [SerializeField] List<Control> _controls = new List<Control>(){
        new Control("Throttle", KeyCode.Space),
        new Control("Left", KeyCode.A),
        new Control("Right", KeyCode.D),
        new Control("Shoot", KeyCode.W),
        new Control("Pause", KeyCode.Escape)
    };

    [SerializeField] Resolution[] _resolutionsList = new Resolution[]
    {
        new Resolution(1920, 1080),
        new Resolution(1600, 900),
        new Resolution(1440, 900),
        new Resolution(1366, 768),
        new Resolution(1280, 1024),
        new Resolution(1280, 720),
    };

    [SerializeField] Quality[] _qualityList = new Quality[]{
        new Quality("Low", 0),
        new Quality("Medium", 1),
        new Quality("High", 2),
        new Quality("Ultra", 3),
    };

    PlayerData _currentData;

    string _dataFileName = "Data";
    string _dataDirectoryPath;
    string _dataFilePath;

    public delegate void OnDataLoadedHandle();
    public event OnDataLoadedHandle OnDataLoadedEvent;

    void Start()
    {
        _dataDirectoryPath = Application.dataPath + "/Data/";
        _dataFilePath = _dataDirectoryPath + _dataFileName + ".json";

        checkData();    
    }

    string getJsonLine(PlayerData data)
    {
        return JsonUtility.ToJson(data); ;
    }

    bool isDataExist()
    {
        return File.Exists(_dataFilePath);
    }

    void checkData()
    {

        // if data doesn`t exist
        if (!isDataExist())
        {
            startDefaultCreationSequence();
        }
        // if data exists
        else
        {
            startDataGettingSequence();
        }

        OnDataLoadedEvent?.Invoke();
    }

    void startDefaultCreationSequence()
    {
        Debug.Log("Creation");
        Directory.CreateDirectory(_dataDirectoryPath);
        File.Create(_dataFilePath).Close();

        PlayerData playerData = new PlayerData(
            _coinsAmount,
            _volume,
            _selectedResolution,
            _isFullscreen,
            _selectedQuality
        );

        SaveData(playerData);

        SetCurrentData(playerData);
    }

    void startDataGettingSequence()
    {
        string recievedJsonData = File.ReadAllLines(_dataFilePath)[0];

        PlayerData recievedDataObj = JsonUtility.FromJson<PlayerData>(recievedJsonData);

        SetCurrentData(recievedDataObj);
    }

    public PlayerData GetCurrentData()
    {
        return _currentData;      
    }

    public void SetCurrentData(PlayerData newCurrentData)
    {
        _currentData = newCurrentData;
    }

    public void SaveData(PlayerData newData)
    {
        // Get Json string of player`s data
        string jsonedData = getJsonLine(newData);

        StreamWriter dataFile = new StreamWriter(_dataFilePath);
        dataFile.WriteLine(jsonedData);

        dataFile.Close();
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

    public Resolution(int width, int height){
        _width = width;
        _height = height;
    }

    public int GetWidth(){
        return _width;
    }

    public int GetHeight(){
        return _height;
    }

    public override string ToString()
    {
        return (_width + "x" + _height);
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