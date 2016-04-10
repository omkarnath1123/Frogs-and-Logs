using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	[SerializeField]
	private Transform target;

	private NavMeshAgent birdAgent;
	private Animator birdAnimator;
	[SerializeField]
	private RandomSoundPlayer birdFootsteps;

	// Use this for initialization
	void Start () {
	
		birdAgent = GetComponent<NavMeshAgent> ();
		birdAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		// ... set to the bird destination to frog when every frames moves ...
		birdAgent.SetDestination (target.position);
		// ... measure the velocity of newmesh component ...
		float speed = birdAgent.velocity.magnitude;
		// ... pass the velocity to the animator component ...
		birdAnimator.SetFloat ("Speed", speed);

		if (speed > 0f) {
			birdFootsteps.enabled = true;
		} else {
			birdFootsteps.enabled = false;
		}
	}
}
