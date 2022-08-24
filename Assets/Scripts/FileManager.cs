using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    string _dataFileName = "Data";
    string _dataDirectoryPath;
    string _dataFilePath;

    void Start()
    {
        _dataDirectoryPath = Application.dataPath + "/Data/";
        _dataFilePath = _dataDirectoryPath + _dataFileName + ".json";
    }
}
