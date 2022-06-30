using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWall : MonoBehaviour
{
    [SerializeField] GameObject LaserRay;
    [SerializeField] float BetweenDelay = 6f;
    [SerializeField] float ActiveTime = 4f;

    private void Awake()
    {
        TurnLaserOn();
    }

    void TurnLaserOn()
    {
        Debug.Log("Laser is ON");

        Ray distanceRay = new Ray(LaserRay.transform.position, Vector3.right);
        Debug.DrawRay(LaserRay.transform.position, Vector3.right * 100f,Color.red, ActiveTime);

        RaycastHit[] distanceRayHits = Physics.RaycastAll(distanceRay);

        // Check where is an obstacle to draw an laser line nessasary length
        if (distanceRayHits != null){
            foreach(RaycastHit hit in distanceRayHits)
            {
                string hitTag = hit.collider.tag;

                if (hitTag != "TriggerZone")
                {
                    float distToObstacle = hit.distance;

                    LaserRay.transform.localScale.Set(distToObstacle, LaserRay.transform.localScale.y, LaserRay.transform.localScale.z);
                    LaserRay.transform.Translate(LaserRay.transform.position + Vector3.right * distToObstacle);


                    print("Dist to obstacle - " + distToObstacle);
                }
            }
        }

        Invoke("TurnLaserOff", ActiveTime);
    }

    void TurnLaserOff()
    {
        Debug.Log("Laser is OFF");
        Invoke("TurnLaserOn", BetweenDelay);
    }

    
}
