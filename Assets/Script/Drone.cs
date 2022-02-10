using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    GameObject Arduino;
    GameObject ElectroAimant;
    GameObject UIManager;
    public bool docked = false;
    public bool undocked = false;
    public float TriggerDistance = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Arduino = GameObject.Find("Arduino");
        ElectroAimant = GameObject.Find("ElectroAimant");
        UIManager = GameObject.Find("UIManager");
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // F = m*a
    // gravity = -9,81 --> F = -9.81 * m
    void FixedUpdate()
    {
        if(UIManager.GetComponent<UIManager>().launched == true){
            float upForce = (m_Rigidbody.mass * 9.81f) * 2f; // Double la force necessaire pour compenser la gravité
            if(docked == false){

                if(getDistance() > TriggerDistance){
                    m_Rigidbody.AddForce(Vector3.up * upForce);
                }
                else{
                    docked = true;
                }

            }
            else if(undocked == true){
                m_Rigidbody.AddForce(Vector3.up * -upForce);
            }
            else{
                m_Rigidbody.AddForce(transform.up * 0);
                m_Rigidbody.velocity = Vector3.zero;
                m_Rigidbody.useGravity = false;
                m_Rigidbody.isKinematic = true;
            }
        }        
        
    }

    float getDistance(){
        RaycastHit hit;
        int layerMask = 1 << 6;
        Vector3 pos = ElectroAimant.transform.position;
        Physics.Raycast(pos , Vector3.up * 100f , out hit , Mathf.Infinity , layerMask);
        Debug.DrawRay(pos, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
        return hit.distance;
    }
}
