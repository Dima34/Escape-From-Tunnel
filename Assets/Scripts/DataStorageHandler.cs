using UnityEngine;
using System.IO;

public class DataStorageHandler : MonoBehaviour
{
    [SerializeField] int defaultCoinsAmount = 0;
    [SerializeField] float defaultVolume = 0f;
    [SerializeField] int defaultResolution = 0;
    [SerializeField] bool isDefaultFullscreen = true;
    [SerializeField] int defaultQuality= 0;
    
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
            defaultCoinsAmount,
            defaultVolume,
            defaultResolution,
            isDefaultFullscreen,
            defaultQuality
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
