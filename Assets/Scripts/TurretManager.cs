using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [SerializeField] GameObject TurretZone;
    [SerializeField] GameObject TurretBase;
    [SerializeField] float zoneRadius = 1.5f;
    [SerializeField] TurretZoneEvent turretZoneScript;

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

        Transform contactorTransform = colliderInfo.gameObject.transform;
        Vector3 direction = TurretBase.transform.position - contactorTransform.position;

        // TurretBase.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        TurretBase.transform.rotation = Quaternion.Lerp(TurretBase.transform.rotation, Quaternion.Euler(direction), 2f);

        // Draw ray when rocket is in collision
        ray = new Ray();
        ray.origin = TurretBase.transform.position;
        ray.direction = TurretBase.transform.forward;
        
        RaycastHit hit;

        bool isRocketOnWay = Physics.Raycast(ray,out hit, zoneRadius);

        // Visualize the ray
        Color RayColor;

        if(isRocketOnWay){
            RayColor = Color.green;
        }else{
            RayColor = Color.red;
        }

        Debug.DrawRay(TurretBase.transform.position, TurretBase.transform.forward*(-10f), RayColor);
    }   


    // Editor radius displaying
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, zoneRadius);
    }
}
