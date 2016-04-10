using UnityEngine;
using System.Collections;

public class GameQuality : MonoBehaviour {

	[SerializeField]
	private GameObject water;
	[SerializeField]
	private GameObject dust;
	[SerializeField]
	private Terrain terrain;

	void Awake () {

		// If the quality level is less than 1...
		if (QualitySettings.GetQualityLevel () < 1) {

			// ...then disable the water...
			water.SetActive(false);

			// ...and disable the dust...
			dust.SetActive(false);

			// ...increase the pixel error on the heightmap.
			terrain.heightmapPixelError = 12;

		}
	}
}
