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
        GameObject Drone = GameObject.Find("Drone");
        Drone.GetComponent<Drone>().docked = false;
        Drone.GetComponent<Drone>().undocked = false;
        launched = true;
        setMotorsText("Motors : On");
    } 

    public void Undock()  
    {
        GameObject Drone = GameObject.Find("Drone");
        Drone.GetComponent<Drone>().undocked = true;
        Drone.GetComponent<Rigidbody>().isKinematic = false;
        Drone.GetComponent<Rigidbody>().useGravity = true;
        setMagnetText("Magnet : Off");
        setMotorsText("Motors : On");
        
    } 

    //Quitte l'application
    public void Quit(){
		Application.Quit();
	}

    public void setDistanceText(float distance){
        string message = "Distance : " + distance.ToString();
        GameObject.Find("distanceText").GetComponent<Text>().text = message;

    }


    public void setMagnetText(string value){
        GameObject.Find("magnetText").GetComponent<Text>().text = value;
    }

    public void setMotorsText(string value){
        GameObject.Find("motorsText").GetComponent<Text>().text = value;
    }
}