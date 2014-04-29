using UnityEngine;
using System.Collections;

public class score : MonoBehaviour 
{

    public float timer;
    public int absolutetimer;
    public int multiplier;
	public float multiplierTimer;
    public float pause;
	public bool showMenu;
	public int currentScore;

    


	// Use this for initialization
	void Start () 
    {
        timer = 0;
        absolutetimer = 0;
		pause = 0;
	}
    
    void OnGUI()
    {
		if (showMenu == true)
		{
			if (GUI.Button(new Rect((Screen.width - Screen.width*0.2f) * 0.5f, Screen.height * 0.2f, Screen.width*0.2f, Screen.height*0.05f), "Resume game")){ //Places button in middle, 20% from top
				pause += 1; //Exits the game menu
			}
			if (GUI.Button(new Rect((Screen.width - Screen.width*0.2f) * 0.5f, Screen.height * 0.4f, Screen.width*0.2f, Screen.height*0.05f), "Exit game")){ //Places button in the middle, 40% from top
				Application.LoadLevel(0); //Returns to main menu
			}
		}
        

		GUI.Label(new Rect(15, 10+15, 100, 50), "Timer:"); 						//Displays the timer
		GUI.Label(new Rect(15, 10+30, 100, 50), "Multiplier:"); 				//Displays the multiplier
		GUI.Label(new Rect(15, 10+45, 100, 50), "Score:"); 						//Displays the score

		GUI.Label(new Rect(15+60, 10+15, 100, 50), absolutetimer.ToString()); 	//Displays the timer
		GUI.Label(new Rect(15+60, 10+30, 100, 50), multiplier.ToString()); 		//Displays the multiplier
		GUI.Label(new Rect(15+60, 10+45, 100, 50), currentScore.ToString()); 	//Displays the score
        //GUI.Label(new Rect(0, 100, 100, 50), timer.ToString()); 				//Timer with decimals
    }

	// Update is called once per frame
	void Update () 
    {
		pauseGame(); 					//Checks if the game is paused or not        
        returnTimer(timer); 			//Consistently converts the timer
		calcMultiplier(multiplier); 	//Consistently calculates the score
        PlayerPrefs.SetInt("Score", currentScore); //Saves the score on the local computer
	}

    int startTimer()
    {
        timer += Time.deltaTime; 				//Timer that increments by 1 every second (with decimals)
		multiplierTimer += Time.deltaTime/10; 	//Multiplier that increments by 1 every 10 seconds (with decimals)
		multiplier = (int)multiplierTimer; 	//Typecasts the multiplier from float to int
        returnTimer(timer);						//Calls the timer typecast function
		return multiplier;						//Returns the multiplier
    }

    void stopTimer()
    {
        returnTimer(timer); //Calls the timer typecast function
    }

    int returnTimer(float t)
    {
        absolutetimer = (int)t; //Typecasts the float to int 
        return absolutetimer;	//Returns the integer of timer
    }

	void pauseGame()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 	//Pauses or unpauses game
			pause += 1;
		
		if (pause%2 == 0)						
		{
			startTimer();						//Starts the timer
			showMenu = false;					//Exits game menu
		}
		
		if (pause%2 == 1)						
		{
			stopTimer();						//Stops the timer
			showMenu = true;					//Opens the game menu

		}
	}

	int calcMultiplier(int x)
	{
		currentScore = (int)timer*x+(int)timer; //Calculates the score based on time and multiplier and typecasts from float to int
		return currentScore;					//Returns the score in interger values
	}
}
