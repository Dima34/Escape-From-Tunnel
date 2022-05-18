using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [SerializeField] GameObject turretBase;
    [SerializeField] TurretZoneEvent turretZoneScript;
    [SerializeField] string turretName;

    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        turretZoneScript.zoneCollisionEvent += somethingEntered;
    }

    public void somethingEntered(object obj){
        Debug.Log("Oh something were entered collision with " + turretName);
    }
}
