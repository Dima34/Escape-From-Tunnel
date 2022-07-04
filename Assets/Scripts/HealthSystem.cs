using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] public int MaxHeartAmount = 3;

    private int HeartAmount;

    private void OnEnable() {
        HeartAmount = MaxHeartAmount;
    }

    public event Action<int, int> OnHealthChange = delegate {};
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            ModifyHealth(-1);
        }
    }

    void ModifyHealth(int AmountToAdd){
        HeartAmount += AmountToAdd;

        if(HeartAmount < 0 ) HeartAmount = 0;
        if(HeartAmount > MaxHeartAmount) HeartAmount = MaxHeartAmount;

        OnHealthChange(HeartAmount, MaxHeartAmount);
    }
}
