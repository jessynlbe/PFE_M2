using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public Rigidbody drone;
    public float upForce;
    void Awake(){
        drone = GetComponent<Rigidbody>();
        upForce = 0f;
    }

    void FixedUpdate(){
        UpdateForce();

        drone.AddRelativeForce(Vector3.up * upForce);
    }

    void UpdateForce(){
        if(Input.GetKey(KeyCode.UpArrow)){
            upForce = 450f;
        }
        else if(Input.GetKey(KeyCode.DownArrow)){
            upForce = -200f;
        }
        else{
            upForce = 0f;
        }
    }
}