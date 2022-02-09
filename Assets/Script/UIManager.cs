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

	void Update () {
       
	}

    public void Setup(){
        
        
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

    //Met à jour les variables statiques indiquant le nombre d'entitées à spawn
    public void updateText()  
    {
        
    } 


	//Recharge la scène actuelle
	public void Reload(){
		Application.LoadLevel(Application.loadedLevel);
	}


	//Charge le niveau donné en entrée
	public void LoadLevel(string level){
		SceneManager.LoadScene(level, LoadSceneMode.Single);
	}

    //Quitte l'application
    public void Quit(){
		Application.Quit();
	}
}