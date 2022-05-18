using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretZoneEvent : MonoBehaviour
{
    public delegate void EventHandler(object obj);
    public event EventHandler zoneCollisionEvent;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("trigger were collided");
        zoneCollisionEvent?.Invoke(other);
    }

}
