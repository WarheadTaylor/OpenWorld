using UnityEngine;
using System.Collections;

public class Webplayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// Lock mouse to window.
		Screen.lockCursor = true;

	 if (Application.CanStreamedLevelBeLoaded(1)) {
			Application.LoadLevel(1);
		}
}
}
