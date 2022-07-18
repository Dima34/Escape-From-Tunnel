using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataStorageHandler : MonoBehaviour
{
 PlayerData _currentData;

 string _dataFileName = "Data";
 string _dataDirectoryPath;
 string _dataFilePath;

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
   Directory.CreateDirectory(_dataDirectoryPath);
   File.Create(_dataFilePath).Close();

   writeDefaultData();
  }
  // if data exists
  else
  {
   startDataGettingSequence();
  }
 }

 void writeDefaultData()
 {
  PlayerData playerData = new PlayerData();

  SaveCurrentData(playerData);

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

 public void SaveCurrentData(PlayerData newData)
 {
  // Get Json string of player`s data
  string jsonedData = getJsonLine(newData);

  StreamWriter dataFile = new StreamWriter(_dataFilePath);
  dataFile.WriteLine(jsonedData);

  dataFile.Close();
 }
}
