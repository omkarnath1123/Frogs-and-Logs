using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	public static DontDestroy instance = null;

	void Awake() {

		// If there is no instance of this class...
		if (instance == null) {
			// ...then set the instance to this.
			instance = this;
		}
		
		// Otherwise, if an instance does not equal this...
		else if (instance != this) {
			// ...then destroy this game object to enforce the singleton pattern.
			Destroy (gameObject);
		}

		// When a new scene loads, don't destroy this game object.
		DontDestroyOnLoad(this.gameObject);

	}
}
