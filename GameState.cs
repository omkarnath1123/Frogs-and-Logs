using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

	private bool gameStarted = false;
	[SerializeField]
	private Text gameStateText;
	[SerializeField]
	private GameObject player;
	[SerializeField]
	private BirdMovement birdMovement;
	[SerializeField]
	private FollowCamera followCamera;
	private float restartDelay = 5f;
	private float restartTimer;
	private PlayerMovement playerMovement;
	private PlayerHealth playerHealth;
	
	// Use this for initialization
	void Start () {
		Cursor.visible = false;

		playerMovement = player.GetComponent<PlayerMovement> ();
		playerHealth = player.GetComponent<PlayerHealth> ();

		// ... preavent the player movement at the start of the game ...
		playerMovement.enabled = false;

		// ... prevent the bird movement at the start of the game ...
		birdMovement.enabled = false;

		// ... preavent the follow camera moving at the start of the game ...
		followCamera.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		// ... if the is not started and the player presses the space bar ...
		if (gameStarted == false && Input.GetKeyUp (KeyCode.Space)){

			// ... then start the game ...
			StartGame();
		}

		// ... if the player is no longer alive then end the game ...
		if (playerHealth.alive == false){

			// ... end the game ...
			EndGame ();

			// ... increment the timer upto count upto starting ...
			restartTimer = restartTimer + Time.deltaTime;

			// ... and if it reaches to the restart delay ...
			if (restartTimer >= restartDelay){

				// ... then load the current lodedlevel1 ...
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	// ... declearing the functions which is use in the update fun. ...
	private void StartGame (){

		// ... get the game state ...
		gameStarted = true;

		// ... remove start text from the screen ...
		gameStateText.color = Color.clear;

		// ... allow the player to move ...
		playerMovement.enabled = true;

		// ... allow the bird to move ...
		birdMovement.enabled = true;

		//... allow the camera to move ...
		followCamera.enabled = true;

	}

	private void EndGame () {

		// ... set the game state ...
		gameStarted = false;

		// ... show the game over text ...
		gameStateText.color = Color.red;
		gameStateText.text = "Game Over !!!";

		// ... remove the player from the game ...
		player.SetActive (false);

	}
}