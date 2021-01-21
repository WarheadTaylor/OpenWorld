using UnityEngine;
using System.Collections;

public sealed class Utils : MonoBehaviour {
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () {
		// Quit Game
		if (Input.GetKeyUp(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	public static void PyroLog (string logMessage) {
		if (Debug.isDebugBuild) {
			Debug.Log(logMessage);
		}
	}
}
