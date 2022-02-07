using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arduino : MonoBehaviour
{
    public float magnetForce = 10;
    public bool docked = false;
    public float TriggerDistance = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, TriggerDistance))
        {
            Vector3 direction = hit.point - transform.position;
            direction.Normalize ();

            //gameObject.GetComponent<Rigidbody>().AddForceAtPosition(magnetForce * direction, hit.point);

            gameObject.GetComponent<Rigidbody>().velocity = (hit.transform.position - (gameObject.GetComponent<Rigidbody>().transform.position + gameObject.GetComponent<Rigidbody>().centerOfMass)) * magnetForce * Time.deltaTime;

            Debug.DrawRay(transform.position, transform.TransformDirection(direction) * hit.distance, Color.green);

            Debug.Log("Did Hit");

            docked = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 20, Color.red);

            docked = false;
            
            //Debug.Log("Did not Hit");

        }
        
    }
}
