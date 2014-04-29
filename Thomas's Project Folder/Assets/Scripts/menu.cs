using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {

	private float height;
	private float width;
	private float buttonHeight;
	private float buttonWidth;
    private int lastScore;


	// Creates variables that scales with the screen upon loading the main menu scene
	void Start () {
		height = Screen.height; //Height of screen
		width = Screen.width; //Width of screen
		buttonHeight = height*0.05f; //Button height
		buttonWidth = width*0.2f; //Button width
        lastScore = PlayerPrefs.GetInt("Score"); //Gets the latest score
	}

	//Display on graphical user interface
	void OnGUI() {
		mainMenu(); 
	}

	// The main menu
	void mainMenu() {
		if (GUI.Button(new Rect((width - buttonWidth) * 0.5f, height * 0.2f, buttonWidth, buttonHeight), "Start game")){ //Places button in middle, 20% from top
			startGame();
		}

		if (GUI.Button(new Rect((width - buttonWidth) * 0.5f, height * 0.4f, buttonWidth, buttonHeight), "Exit game")){ //Places button in the middle, 60% from top
			exitGame();
		}
        GUI.Box(new Rect(10, 10, 150, 70), "Last Game"); 							//Makes a box
        GUI.Label(new Rect(15 + 60, 10 + 15, 100, 50), lastScore.ToString()); 	    //Displays the score for last game
        

	}

	//Load game function
	void startGame(){
		Application.LoadLevel(1); //Loads the game
		PlayerPrefs.SetInt("Score", 0); //Resets the score upon entering the game
	}

	//Exits game function
	void exitGame(){
		Application.Quit(); //Magically exits the game.
	}
}
