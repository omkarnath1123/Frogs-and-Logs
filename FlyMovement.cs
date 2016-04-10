using UnityEngine;
using System.Collections;

public class FlyMovement : MonoBehaviour {

	[SerializeField]
	private Transform center;// transforming the center of the fly ...

	private float flySpeed;

	// Use this for initialization
	void Start () {
		flySpeed = Random.Range (300f, 700f);// random class will picks a random value in the desired class ...
	
	}
	
	// FixedUpdate is called once per frame and stop the fly to move at the fast rate ...
	void FixedUpdate () {
		// now transforming the value of fly during the playing ...
		// center.position = tansform variable with position vector3 ...
		//Vector3.up = is the position on y-axis ...
		//flySpeed * Time.deltaTime = to randomsied the speed of flys so that it appears in the real time ...

		transform.RotateAround (center.position, Vector3.up, flySpeed * Time.deltaTime);
	}
}
