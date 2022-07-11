using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelCard : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI NameText;
    [SerializeField] string levelName;
    [SerializeField] bool isLocked;

    // Start is called before the first frame update
    void Start()
    {
        NameText.text = levelName;
    }
}
