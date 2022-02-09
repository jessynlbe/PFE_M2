using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arduino : MonoBehaviour
{
    public float magnetForce = 500;
    public bool docked = false;
    public float TriggerDistance = 0.5f;
    Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    
    }

    
    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.name =="Plaque"){
            // Debug.Log("Hit magnet");
            //collision.gameObject.transform.parent = gameObject.transform;
            m_Rigidbody.AddForce(transform.up * 0);
            docked = true;
        }
        
    }

    /*
    
    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, TriggerDistance) && hit.collider.gameObject.name =="Plaque")
        {
            
            Vector3 direction = hit.point - transform.position;
            direction.Normalize ();

            //gameObject.GetComponent<Rigidbody>().AddForceAtPosition(magnetForce * direction, hit.point);

            gameObject.GetComponent<Rigidbody>().velocity = (hit.transform.position - (gameObject.GetComponent<Rigidbody>().transform.position + gameObject.GetComponent<Rigidbody>().centerOfMass)) * magnetForce * Time.deltaTime;

            //hit.transform.parent = gameObject.transform;

            Debug.DrawRay(transform.position, transform.TransformDirection(direction) * hit.distance, Color.green);

            Debug.Log("Did Hit");

            docked = true;
            Debug.Log("Hit magnet");
            hit.transform.parent = gameObject.transform;
            docked = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 20, Color.red);

            docked = false;
            
            //Debug.Log("Did not Hit");

        }
        
    }*/
}
