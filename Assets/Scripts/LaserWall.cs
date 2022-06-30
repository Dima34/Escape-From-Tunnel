using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWall : MonoBehaviour
{
    [SerializeField] GameObject LaserRay;
    [SerializeField] float BetweenDelay = 6f;
    [SerializeField] float ActiveTime = 4f;


    Vector3 defaultLaserSize;
    Vector3 defaultLaserPos;

    private void Awake()
    {
        defaultLaserSize = LaserRay.transform.localScale;
        defaultLaserPos = LaserRay.transform.position;
        
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

                if (hitTag == "Obstacle")
                {
                    // Get distance to ray collided object
                    float distToObstacle = hit.distance;

                    print("Dist to obstacle - " + distToObstacle);

                    // Set laser length to ray length
                    LaserRay.transform.localScale = new Vector3(distToObstacle, LaserRay.transform.localScale.y, LaserRay.transform.localScale.z);

                    // Set position to center of ray
                    LaserRay.transform.position = LaserRay.transform.position + LaserRay.transform.right * (distToObstacle / 2);
                }
            }
        }

        Invoke("TurnLaserOff", ActiveTime);
    }

    void TurnLaserOff()
    {
        Debug.Log("Laser is OFF");

        // set default position and scale
        LaserRay.transform.localScale = defaultLaserSize;
        LaserRay.transform.position = defaultLaserPos;

        Invoke("TurnLaserOn", BetweenDelay);
    }

    
}
