using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TurretManager : MonoBehaviour
{
    [SerializeField] TurretZoneEvent turretZoneScript;
    [SerializeField] GameObject TurretZone;
    [SerializeField] GameObject TurretBase;
    [SerializeField] GameObject TurretGun;
    [SerializeField] GameObject Bomb;
    [SerializeField] AudioClip ShootSound;
    [SerializeField] float zoneRadius = 1.5f;
    [SerializeField] float degreesPerSecond = 20f;
    [SerializeField] float shootingSpeedS = 2f;
    [SerializeField] float bombForce = 20f;

    
    AudioSource audioSource;
    bool isReloading = false;
    bool isLoaded = true;
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        turretZoneScript.zoneCollisionEvent += onTurretZoneEnter;
        TurretZone.GetComponent<SphereCollider>().radius = zoneRadius;       
    }

    private void OnDestroy()
    {
        turretZoneScript.zoneCollisionEvent -= onTurretZoneEnter;
    }

    public void Shoot()
    {
        isLoaded = false;

        // get the front end gun coordinates
        Vector3 BombSpawnPos = TurretGun.transform.position + (-TurretGun.transform.up);

        GameObject bomb = Instantiate(Bomb, BombSpawnPos, TurretGun.transform.rotation);
        Rigidbody bombRb = bomb.GetComponent<Rigidbody>();

        // Play shoot sound
        SoundManager.PlaySoundOnce(audioSource,ShootSound);

        // add forward impulse to bomb to simulate a shoot;
        bombRb.AddForce(-(TurretGun.transform.up) * bombForce);
    }

    public void Reload()
    {
        isReloading = true;
        Invoke("SetGunLoaded", shootingSpeedS);
    }

    public void SetGunLoaded()
    {
        isLoaded = true;
    }

    public void onTurretZoneEnter(object obj){
        Collider colliderInfo = (obj as Collider);

        if(colliderInfo == null) {return;}

        Quaternion lookRotation = Quaternion.LookRotation(colliderInfo.transform.position - TurretBase.transform.position);
        Quaternion rotation = Quaternion.RotateTowards(TurretBase.transform.rotation , lookRotation, degreesPerSecond * Time.deltaTime);
        TurretBase.transform.rotation = rotation;

        Color gunRayColor = Color.red;
        Ray ray = new Ray(TurretGun.transform.position, -TurretGun.transform.up);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)){

            // Cheking if rocket is in front of a gun
            if (hit.collider.gameObject.tag == "Player")
            {
                // Shoot & Reloading proces
                if (isLoaded)
                {
                    isReloading = false;
                    Shoot();
                };
                if (!isLoaded && !isReloading) Reload();




                gunRayColor = Color.green;
            }  
            
            if(isReloading) gunRayColor = Color.magenta;
        }



        // Draw an up vector of turret
        Debug.DrawRay(TurretGun.transform.position, -TurretGun.transform.up * zoneRadius, gunRayColor);
    }

    // Editor radius displaying
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, zoneRadius);
    }
}
