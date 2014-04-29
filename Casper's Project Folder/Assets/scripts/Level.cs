using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
	
	//Variables
	public float timer = 0f;
	public float threshold = 6f;
	public GameObject obstacleObject;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		timer += Time.deltaTime; //Adds 1 counter to timer every second
		
		if (timer > threshold){ //If timer reaches threshold
			Instantiate (obstacleObject, new Vector3(20,0,0), Quaternion.identity); //An obstacle object is instantiated at position 20, 0, 0
			timer = 0f; //Timer is reset
			threshold -= 0.1f; //Threshold is reduced by 0.1 second
			
			}
	}
	
	/*void OnGUI(){ //Function for debugging
		GUI.Label(new Rect(0,0,100,50), timer.ToString()); 
	}*/
	
}
