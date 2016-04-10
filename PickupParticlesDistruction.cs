using UnityEngine;
using System.Collections;

public class PickupParticlesDistruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// ... destroy the pick up particles after 5 sec ...
		Destroy (gameObject, 5f);
	}
	

}
