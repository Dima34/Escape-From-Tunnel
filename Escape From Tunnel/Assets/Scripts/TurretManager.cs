using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [SerializeField] GameObject turretBase;
    [SerializeField] TurretZoneEvent turretZoneScript;

    
    // Start is called before the first frame update
    void Start()
    {
        turretZoneScript.zoneCollisionEvent += onTurretZoneEnter;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void onTurretZoneEnter(object obj){
        Collider colliderInfo = (obj as Collider);

        if(colliderInfo == null) {return;};

        Transform contactorTransform = colliderInfo.transform;
        turretBase.transform.LookAt(contactorTransform.position, Vector3.up);
    }   
}
