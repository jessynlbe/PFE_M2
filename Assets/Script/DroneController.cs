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
        float dist = getDistance();
        UpdateForce();

        if(dist > 10f){
            drone.AddRelativeForce(Vector3.up * upForce);
        }
        else{
            drone.velocity = Vector3.zero;
        }
    }

    void UpdateForce(){
        if(Input.GetKey(KeyCode.UpArrow)){
            upForce = 4.8f;
        }
        else if(Input.GetKey(KeyCode.DownArrow)){
            upForce = -200f;
        }
        else{
            upForce = 0f;
        }
    }

    float getDistance(){
        RaycastHit hit;
        int layerMask = 1 << 6;
        Physics.Raycast(transform.position , Vector3.up * 100f , out hit , Mathf.Infinity , layerMask);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.red);

        return hit.distance;
    }
}