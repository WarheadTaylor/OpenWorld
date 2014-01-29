using UnityEngine;
using System.Collections;

public class Webplayer : MonoBehaviour {

	void Start () {
	
	}

	void Update () {

		// Lock mouse to window.
		Screen.lockCursor = true;

		if (Application.CanStreamedLevelBeLoaded(1)) {
			Application.LoadLevel(1);
		}
	}
}
