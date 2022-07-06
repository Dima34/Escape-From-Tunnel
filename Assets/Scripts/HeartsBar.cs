using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeartsBar : MonoBehaviour
{
    [SerializeField] HealthSystem HealthSystemScript;
    [SerializeField] Sprite FilledHeartSprite;
    [SerializeField] Sprite EmptyHeartSprite;
    
    Image[] HeartList;
    
    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
        HealthSystemScript.OnHealthChange += UpdateHearts;        
    }

    void InitHearts(){
        int MaxHeartAmount = HealthSystemScript.MaxHeartAmount;

        HeartList = new Image[MaxHeartAmount];

        for (int i = 0; i < MaxHeartAmount; i++)
        {
            GameObject HeartImage = new GameObject("HeartPlaceholder");
            HeartImage.AddComponent<Image>().sprite = FilledHeartSprite;
            HeartImage.transform.SetParent(this.transform);
            HeartImage.transform.localScale = new Vector3(1,1,1);

            HeartList[i] = HeartImage.GetComponent<Image>();
        }
    }

    void UpdateHearts(int currentAmount, int maxAmount){
        for (int i = currentAmount; i < maxAmount; i++)
        {
            HeartList[i].sprite = EmptyHeartSprite;
        }
    }
}
