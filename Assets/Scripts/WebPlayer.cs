using UnityEngine;
using System.Collections;

public class WebPlayer : MonoBehaviour {
	
	void Start () {
		
	}
	
	void Update () {
		
		if (Application.isWebPlayer) {
			// Lock mouse to window.
			Screen.lockCursor = true;
			
			if (Application.CanStreamedLevelBeLoaded(1)) {
				Application.LoadLevel(1);
			}
		}
	}
}
