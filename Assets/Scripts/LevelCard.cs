using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCard : MonoBehaviour
{
    [SerializeField] 
    TMPro.TextMeshProUGUI NameText;
    [SerializeField]
    Image LevelImage;
    [SerializeField]
    string SceneToOpenName;


    [HideInInspector] 
    public bool isLocked;
    [HideInInspector] 
    public string levelName;
    [HideInInspector]
    public Sprite levelImage; 

    public void setData(){
        NameText.text = levelName;


        LevelImage.sprite = levelImage;
    }

    public void openScene(){
        SceneManager.LoadScene(levelName);
    }

}
