using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool launched = false;

	void Start () {
		Time.timeScale = 1;
        
	}
    
    public void Launch()  
    {
        launched = true;
        Debug.Log("BEGIN");
    } 

    public void Undock()  
    {
        GameObject Drone = GameObject.Find("Drone");
        Drone.transform.parent = null;
        Drone.GetComponent<Rigidbody>().isKinematic = false;
    } 

    //Quitte l'application
    public void Quit(){
		Application.Quit();
	}
}