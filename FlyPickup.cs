using UnityEngine;
using System.Collections;

public class FlyPickup : MonoBehaviour {

	[SerializeField]
	private GameObject pickupPrefab;
	
	void OnTriggerEnter(Collider other) {
		// if the "Collider" other is tagged with "Player"...
		if (other.CompareTag ("Player")) {

			// ... add the pickup particles ...
			Instantiate(pickupPrefab, transform.position, Quaternion.identity);

			//  ... decrement the total no. fly's ...
			FlySpawner.totalFlies--;

			// ... update the score ...
			ScoreCounter.score++;

			Destroy (gameObject);
		}
	}
}