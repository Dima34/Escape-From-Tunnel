using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 TranspolateAmount;
    [SerializeField] float timeToReach = 5;
    [Range(0f, 1f)]
    public float Value;

    Vector3 startPoint;
    Vector3 endPoint;
    float percentPerSecond;
    Transform transform;
    
    bool reversed = false;

    void Start()
    {
        transform = GetComponent<Transform>();

        startPoint = GetComponent<Transform>().position;
        endPoint = startPoint + TranspolateAmount;

        float startMagnitude = startPoint.magnitude;
        float endMagnitude  = endPoint.magnitude;
        float magnitudeDiff = Math.Abs(startMagnitude - endMagnitude);
        float pointPerSecond = magnitudeDiff / timeToReach;

        percentPerSecond = pointPerSecond /  magnitudeDiff;

        // We need that to (transform.position == startPoint) not be true at first update
        Value += 0.001f; 
    }

    void Update()
    {
        CheckReverse();
        Value += getActualPersentPerSecond() * Time.deltaTime;
        transform.position = Vector3.Lerp(startPoint, endPoint, Value);
    }

    private void CheckReverse()
    {
        if (transform.position == endPoint)
        {
            toggleReverse();
        }

        if (transform.position == startPoint)
        {
            toggleReverse();
        }
    }

    void toggleReverse(){
        reversed = !reversed;
    }

    float getActualPersentPerSecond(){
        if(reversed){
            return -percentPerSecond;
        }
        else{
            return percentPerSecond;
        }
    }
}
