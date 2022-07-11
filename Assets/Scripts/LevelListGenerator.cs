using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class LevelListGenerator : MonoBehaviour
{
    [SerializeField] GameObject LevelCard;
    [SerializeField] Level[] LevelList;

    private void Start() {
        GenerateCards();
    }

    public void GenerateCards(){

        foreach (var item in LevelList)
        {
            Instantiate(LevelCard, this.transform);
        }
    }
}



[Serializable] public class Level{
    public string name;
    public bool isLocked;
}
