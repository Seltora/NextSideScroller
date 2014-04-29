using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private int life = 5; 		// variable to set amount of life's for player
	public float jump = 400; 	// variable to set the jump force
	public Transform explosion; // variable to add explosion to player

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		playerJump(); 			//checks the playerJump function in update to see if it is initialized
	}

	//function to make player jump
	void playerJump(){
		if (Input.GetKeyDown (KeyCode.Space)&& transform.position.y < 1.65) // if-statement checking if spacebar is pressed and asking for the position of player to be lower than 1.65 
			rigidbody.AddForce (0,jump,0); 				// adding force to players y-coordinate to make him jump up
		else{}
	}

	//function to check if player collides with objects
	void OnCollisionEnter (Collision col){
		if(col.gameObject.name == "Obstacle(Clone)"){ //checks if the collision is with "Obstacle(Clone)"
			life -= 1;				// then subtract 1 life from player
			Debug.Log(life);
			isAlive();				// everytime player loose 1 life, this checks to see if player is still alive
		}
	}

	//boolean checking if player is dead or alive
	bool isAlive (){
		if (life < 1)
		{
			Destroy(this.gameObject); //destroy the player
			Instantiate(explosion, transform.position, transform.rotation); //add explosion to player when destroyed
			Debug.Log("Game Over");
			Application.LoadLevel(0);
			return false;
		}
		else {
			Debug.Log("Game NOT Over");
			return true;
		}
	}
	// function to show the amount of lifes left, in top left corner
	void OnGUI(){
		GUI.Box(new Rect(10,10,150,80), "Scoreboard"); 	//Displays the scoreboard box
		GUI.Label(new Rect(15+60, 10+60, 100, 50), life.ToString());
		GUI.Label(new Rect(15, 10+60, 100, 50), "Life:"); 						//Displays the score
	}
}
