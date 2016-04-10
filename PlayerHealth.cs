using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	// ... for values true or false ...
	public bool alive;
	[SerializeField]
	private GameObject pickupPrefab;

	// Use this for initialization
	void Start () {
		alive = true;
	}
	
	void OnTriggerEnter(Collider other){
		// ... comparing the collision with bird by enemy tag ...
		// ... one more verification .. if the player will collide with bird with multiple times ...
		if (other.CompareTag ("Enemy") && alive == true) {
			alive = false;

			// ... create the pick up particles ...
			Instantiate(pickupPrefab, transform.position, Quaternion.identity);

		}
	}
}
