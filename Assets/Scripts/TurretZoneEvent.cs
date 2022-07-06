using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretZoneEvent : MonoBehaviour
{
    public delegate void EventHandler(object obj);
    public event EventHandler zoneCollisionEvent;

    private void OnTriggerStay(Collider other) {
        zoneCollisionEvent?.Invoke(other);
    }
}
