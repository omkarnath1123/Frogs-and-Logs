using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomSoundPlayer : MonoBehaviour {

	private AudioSource audioSource;
	[SerializeField]
	private List<AudioClip> soundClips = new List<AudioClip>();
	[SerializeField]
	private float soundTimeDelay = 3f;
	private float soundTimer;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	

	void FixedUpdate () {
		// ... increment a timer to count up to restarting ...
		soundTimer = soundTimer * Time.deltaTime;

		// ... if the timer reaches the delay ...
		if (soundTimer >= soundTimeDelay){


			// ... reset the timer ...
			soundTimer = 0f;

			// ... choose a random sound ...
			AudioClip randomSound = soundClips[Random.Range (0, soundClips.Count - 1)];

			// ... and play the sound ...
			audioSource.PlayOneShot (randomSound);
		}
	}
}