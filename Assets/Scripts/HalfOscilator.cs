using UnityEngine;
using System;

public class HalfOscilator : MonoBehaviour
{
    [SerializeField] float downToCenter = 5f;
    [SerializeField] float period = 1f;
    [Range(1,360)][SerializeField] float degreeToRotate = 180f;

    Vector3 DefaultPosition;
    Vector3 CenterFromDefault;

    DateTime time;
    
    // Start is called before the first frame update
    private void Start()
    {
        calculateRotation();
        time = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon) { return; }
        CenterFromDefault.y = DefaultPosition.y - downToCenter;
        float degrees;

        if(degreeToRotate == 360){
            degrees = degreeToRotate * ((Time.time / period) % -10 + 1);
        }else{
            // Time.time * 10 because from -1 to 1 = 10 seconds we multiply by 10 because I need 0 to 10 in 1 second and after that I can multiply on whatever secons i want to controll the time from -1 to 1
            // period * 2 because without it we will have -1 to 1 in period seconds. I need to multiply it by 2 to make it x2 faster(we can say from 0 to 1)
            degrees = degreeToRotate * (Mathf.Cos(Time.time * 10 / (period * 2)) / 2);
        }

        transform.position = Rotate(CenterFromDefault, DefaultPosition, degrees);
    } 


    void calculateRotation(){
        DefaultPosition = transform.position;

        CenterFromDefault.x = DefaultPosition.x;
        CenterFromDefault.y = DefaultPosition.y - downToCenter;
        CenterFromDefault.z = DefaultPosition.z;
    }

    public static Vector3 Rotate(Vector3 centerPoint, Vector3 pointToRotate, float degrees)
    {
        // convert degrees into radius
        float radians = -degrees * Mathf.PI / 180;;

        // if center point is not a center(0;0) - let`s make it a center
        float diffX = Mathf.Abs(0 - centerPoint.x);
        float diffY = Mathf.Abs(0 - centerPoint.y);

        float newX = pointToRotate.x - diffX;
        float newY = pointToRotate.y - diffY;

        float cos = Mathf.Cos(radians);
        float sin = Mathf.Sin(radians);

        // Rotate centered point
        Vector3 rotatedVec = new Vector3()
        {
            x = (float)(newX * cos - newY * sin) + diffX,
            y = (float)(newX * sin + newY * cos) + diffY,
            z = pointToRotate.z
        };        

        return rotatedVec; 
    }
}



