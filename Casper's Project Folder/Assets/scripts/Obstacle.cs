using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour 
{
	//Variables
	public float maxHeight;
	public float obstacleSize;
	public float timer;
	public uint threshold;
	public Transform explosion2;
	
	// Use this for initializations
	void Start () 
	{
		
		timer = 0;
		threshold = 10;
		maxHeight = 3.5f;
		obstacleSize = Random.Range(1f, maxHeight);
		changeColor ();
		transform.localScale = new Vector3 (0.7f,obstacleSize,1f); //Sets the height of the obstacle to be equal to obstacle size
		transform.Translate(new Vector3 (0, obstacleSize/2, 0)); //Moves the obstacle up the y axis so that all obstacles are aligned
			
		}
		
		// Update is called once per frame
		void Update () 
		{
			
			transform.Translate(new Vector3 (-6,0,0) * Time.deltaTime); // Moves the obstacle 4 units to left every second
			timer += Time.deltaTime; //Adds 1 counter per second to timer
			
			if (timer > threshold){ //Destroys the obstacle when the timer reaches the threshold to save memory
				Destroy (this.gameObject);
				timer = 0f;
			}
		}
		
		//Function to change color of obstacle based on height
		void changeColor () 
		{
			
			if (obstacleSize < (maxHeight+1.5)/3)
			{
				renderer.material.color = Color.green;
			}
			if (obstacleSize < ((maxHeight+1)/3)*2 && obstacleSize > (maxHeight)/3)
			{
				renderer.material.color = Color.blue;
			}
			if (obstacleSize > ((maxHeight+1)/3)*2)
			{
				renderer.material.color = Color.red;
			}
		}
		
		//Collision Detection
		void OnCollisionEnter(Collision col)
		{
			if (col.gameObject.name == "Player") // Checks for a collision with and object with the name "Player"
			{
				
				Destroy(this.gameObject); //Destroys the object
				Instantiate (explosion2, transform.position, transform.rotation); //Creates an explosion

			}
		}
	}
