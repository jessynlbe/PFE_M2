using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Tentavive de le faire monter droit si l'aimant n'est pas actif, surement besoin de quatre forces pour équilibrer
        GameObject Arduino = GameObject.Find("Arduino");
        if(Arduino.GetComponent<Arduino>().docked == false){
            m_Rigidbody.AddForce(transform.up * 1);
        }else{
            m_Rigidbody.AddForce(transform.up * 0);
        }
            
        
    }
}
