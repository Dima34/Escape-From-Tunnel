using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RickOscilator : MonoBehaviour
{
    
    Vector3 StartingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f; 
    float movementFactor = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        StartingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles;

        if(period == 0){ return;}
        cycles= Time.time / period;

        const float tau = Mathf.PI * 2;

        float rawSinWave = Mathf.Sin(cycles * tau);
        movementFactor = (rawSinWave + 1f) / 2f;
        
        Vector3 offset = movementVector * movementFactor;
        transform.position = offset + StartingPosition;
    }
}
