using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpNDownMover : MonoBehaviour
{
    [SerializeField] float EndPoint = 2f;
    [SerializeField] float SecondsToEnd = 2f;


    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

  
        


    }

    // Update is called once per frame
    void Update()
    {
        float RemindedTime = Time.unscaledTime % 10;

        float radians = Mathf.Deg2Rad * getDegreesFromNum(RemindedTime);
        float t = (Mathf.Cos(radians) + 1) / 2;
        Debug.Log(t);

        transform.position = Vector3.Lerp(startPos, startPos + transform.up * EndPoint, t);
    }

    float getDegreesFromNum(float num){
        return num * 36;
    }
}
