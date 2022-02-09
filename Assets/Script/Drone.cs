using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    GameObject Arduino;
    GameObject UIManager;

    public float magnetForce = 500;
    public bool docked = false;
    public float TriggerDistance = 0.5f;
    // Start is called before the first frame update

    
    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.name =="Plaque"){
            m_Rigidbody.AddForce(transform.up * 0);
            docked = true;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Arduino = GameObject.Find("Arduino");
        UIManager = GameObject.Find("UIManager");
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(UIManager.GetComponent<UIManager>().launched == true){
            if(docked == false){
                m_Rigidbody.AddForce(transform.up * 1);
            }else{
                m_Rigidbody.AddForce(transform.up * 0);
            }
        }        
        
            
        
    }
}
