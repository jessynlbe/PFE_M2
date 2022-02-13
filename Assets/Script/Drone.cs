using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    GameObject Arduino;
    GameObject ElectroAimant;
    List<GameObject> fans;
    GameObject UI;
    GameObject UIManager;
    public bool docked = false;
    public bool undocked = false;
    public bool landing = true;
    public float TriggerDistance = 0.3f;


    void OnCollisionEnter(Collision col){
        if(col.gameObject.name == "Plane"){
            stopMotors();
            landing = true;
        }
    }

    void OnCollisionExit(Collision col){
        if(col.gameObject.name == "Plane"){
            landing = false;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        Arduino = GameObject.Find("Arduino");
        ElectroAimant = GameObject.Find("ElectroAimant");
        UIManager = GameObject.Find("UIManager");
        m_Rigidbody = GetComponent<Rigidbody>();

        fans = new List<GameObject>();
        fans.Add(GameObject.Find("fan.001"));
        fans.Add(GameObject.Find("fan.002"));
        fans.Add(GameObject.Find("fan.003"));
        fans.Add(GameObject.Find("fan.004"));
    }

    // F = m*a
    // gravity = -9,81 --> F = -9.81 * m
    void Update()
    {
        if(UIManager.GetComponent<UIManager>().launched == true){
            
            if(landing == false){
                playMotors();
                UIManager.GetComponent<UIManager>().setMotorsText("Motors : On");
            }
            else{
                stopMotors();
                UIManager.GetComponent<UIManager>().setMotorsText("Motors : Off");
            }
            
            float upForce = (m_Rigidbody.mass * 9.81f) * 2f; // Double la force necessaire pour compenser la gravité
            if(docked == false){
                playMotors();
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
                UIManager.GetComponent<UIManager>().setMotorsText("Motors : Off");
                UIManager.GetComponent<UIManager>().setMagnetText("Magnet : On");

                stopMotors();
            }
        }  

        UIManager.GetComponent<UIManager>().setDistanceText( getDistance() );

    }

    float getDistance(){
        RaycastHit hit;
        int layerMask = 1 << 6;
        Vector3 pos = ElectroAimant.transform.position;
        Physics.Raycast(pos , Vector3.up * 100f , out hit , Mathf.Infinity , layerMask);
        Debug.DrawRay(pos, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
        return hit.distance;
    }

    void stopMotors(){
        foreach(GameObject fan in fans){
            fan.GetComponent<Animator>().enabled = false;
        }
    }

    void playMotors(){
        foreach(GameObject fan in fans){
            fan.GetComponent<Animator>().enabled = true;
        }
    }
}
