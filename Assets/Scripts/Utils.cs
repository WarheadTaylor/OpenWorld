using UnityEngine;
using System.Collections;

public class Utils : MonoBehaviour {

	void Start () {
		// Disable mouse in build
		if (!Application.isEditor) {
			Screen.showCursor = false;
		}
	}

	void Update () {
		// Quit Game
		if (Input.GetKeyUp(KeyCode.Escape)) {
			Application.Quit();
		}
	}
	

}
