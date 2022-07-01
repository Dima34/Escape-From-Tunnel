using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation360 : MonoBehaviour
{
    [SerializeField] float DegreesPerSecond = 90f;


    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(DegreesPerSecond * Time.deltaTime, Vector3.up);
    }
}
