using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Animator playerAnimator;
	private float moveHorizontal;
	private float moveVertical;
	private Vector3 movement;
	private float turningSpeed = 20f; // for rotating the frog ...
	private Rigidbody playerRigidbody; // so, player can follow rules of physics ...
	[SerializeField]
	private RandomSoundPlayer playerFootSteps;

	// Use this for initialization
	void Start () {
		// gather the componets from the player gameObject ...
		playerAnimator = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		// gather input from code 
		moveHorizontal = Input.GetAxisRaw ("Horizontal");
		moveVertical = Input.GetAxisRaw ("Vertical");

		movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
	}

	void FixedUpdate () {
		// if the player movement vector != 0 ...
		if (movement != Vector3.zero) {

			// ... then create a target rotation based on the movement vector ...
			Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);

			// ... and create a another rotation that moves from the current rotation to the target rotation ...
			Quaternion newRotation = Quaternion.Lerp (playerRigidbody.rotation, targetRotation, turningSpeed * Time.deltaTime);

			// ... and change the player's rotation to the new incremental rotation ...
			playerRigidbody.MoveRotation(newRotation);

			// play the jump animation ...
			playerAnimator.SetFloat ("Speed", 3f);

			// ... player foorsteps sounds ...
			playerFootSteps.enabled = true;
		} else {
			// don't play the jump animation ...
			playerAnimator.SetFloat ("Speed", 0f);

			// ... don't play footsteps sounds ...
			playerFootSteps.enabled = false;
		}


	}

}
