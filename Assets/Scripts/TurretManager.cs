using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [SerializeField] TurretZoneEvent turretZoneScript;
    [SerializeField] GameObject TurretZone;
    [SerializeField] GameObject TurretBase;
    [SerializeField] float zoneRadius = 1.5f;
    [SerializeField] float degreesPerSecond = 20f;

    Ray ray;

    
    // Start is called before the first frame update
    private void Awake()
    {
        turretZoneScript.zoneCollisionEvent += onTurretZoneEnter;
        TurretZone.GetComponent<SphereCollider>().radius = zoneRadius;
       
    }

    private void OnDestroy()
    {
        turretZoneScript.zoneCollisionEvent -= onTurretZoneEnter;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void onTurretZoneEnter(object obj){
        Collider colliderInfo = (obj as Collider);

        if(colliderInfo == null) {return;}
        // Draw an up vector of turret
        Debug.DrawRay(TurretBase.transform.position, TurretBase.transform.forward * 5f, Color.red);

        Vector3 contactorVec = colliderInfo.transform.position - TurretBase.transform.position;
        contactorVec.Normalize();

        // Draw a toContactor ray
        Debug.DrawRay(TurretBase.transform.position, contactorVec * 5f, Color.green);

        

        TurretBase.transform.rotation = Quaternion.FromToRotation(Vector3.forward, contactorVec * Time.deltaTime / degreesPerSecond);
    }

    // Editor radius displaying
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, zoneRadius);
    }
}
