using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plaque : MonoBehaviour
{

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.name =="Drone"){
            GameObject emptyObject = new GameObject();
            emptyObject.transform.parent = gameObject.transform;
            collision.gameObject.transform.parent = emptyObject.transform;
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log("Hit magnet");

        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
