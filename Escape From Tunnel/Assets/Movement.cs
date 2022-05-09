using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float PushForce;
    [SerializeField] float TurnForce;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandlePush();
        HandleTurn();
    }

    public void HandlePush(){
        if(Input.GetKey(KeyCode.Space)){
            rb.AddRelativeForce(0,1 * PushForce * Time.deltaTime,0);
        }
    }

    public void HandleTurn(){
        

        if (Input.GetKey(KeyCode.A))
        {
            TurnRocket(-TurnForce);
        }
        else if(Input.GetKey(KeyCode.D)){
            TurnRocket(TurnForce);
        }
    }

    public void TurnRocket(float force)
    {
        rb.freezeRotation = true;
        transform.Rotate(0, 0 ,force * Time.deltaTime);
        rb.constraints &= ~RigidbodyConstraints.FreezeRotationZ;
    }
}
