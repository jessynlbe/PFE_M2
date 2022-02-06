using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arduino : MonoBehaviour
{
    public float magnetForce = 2;
    public bool docked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        float TriggerDistance = 2;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, TriggerDistance))
        {
            Vector3 direction = hit.point - transform.position;
            direction.Normalize ();

            gameObject.GetComponent<Rigidbody>().AddForceAtPosition(magnetForce * direction, hit.point);

            Debug.DrawRay(transform.position, transform.TransformDirection(direction) * hit.distance, Color.green);

            Debug.Log("Did Hit");

            docked = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 20, Color.red);
            
            //Debug.Log("Did not Hit");

            //docked = false;
        }
        
    }
}
