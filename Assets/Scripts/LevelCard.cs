using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelCard : MonoBehaviour
{
    [SerializeField] 
    TMPro.TextMeshProUGUI NameText;
    [SerializeField]
    Image LevelImage;


    [HideInInspector] 
    public bool isLocked;
    [HideInInspector] 
    public string levelName;
    [HideInInspector]
    public Sprite levelImage; 

    public void setData(){
        NameText.text = levelName;

        Debug.Log("Image info in card" + levelImage.name);


        LevelImage.sprite = levelImage;
    }
}
