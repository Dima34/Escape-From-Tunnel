using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using UnityEditor;
using System.IO;

public class LevelListGenerator : MonoBehaviour
{
    [SerializeField] GameObject LevelCard;
    [SerializeField] Level[] LevelList;

    private void Start() {
        // GenerateCards();
    }

    public void GenerateCards(){

        deleteOneChild(transform);

        foreach (var level in LevelList)
        {
            GameObject newCard = Instantiate(LevelCard, this.transform);
            LevelCard newCardScript = newCard.GetComponent<LevelCard>();
            

            newCardScript.levelName = level.name;

            if(level.LevelImage != null){
                newCardScript.levelImage = level.LevelImage;
            }

            newCardScript.setData();
        }
    }

    #if UNITY_EDITOR
    public void FillLevelList(){
        EditorBuildSettingsScene[] sceneEditorScenes = EditorBuildSettings.scenes;

        LevelList = new Level[sceneEditorScenes.Length];

        for (int i = 0; i < LevelList.Length; i++)
        {
            LevelList[i] = new Level(Path.GetFileNameWithoutExtension(sceneEditorScenes[i].path));
        }    
    }
    #endif

    public void deleteOneChild(Transform parentTransform){
        if(parentTransform.childCount != 0){
            DestroyImmediate(transform.GetChild(0).gameObject);

            deleteOneChild(parentTransform);
        }
    }
}

[Serializable] public class Level{
    public string name;
    public bool isLocked;
    public Sprite LevelImage;

    public Level(string name){
        this.name = name;
    }
}