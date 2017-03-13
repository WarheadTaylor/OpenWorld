using UnityEngine;
using System.Collections;

public sealed class Utils : MonoBehaviour {
	public bool LockCursor = false;

	void Start () {
		// Disable mouse in build
		if (!Application.isEditor) {
			Cursor.visible = false;
		}
	}

	void Update () {
		// Quit Game
		if (Input.GetKeyUp(KeyCode.Escape)) {
			Application.Quit();
		}

		// Lock mouse to window.
		if (LockCursor) {
			Screen.lockCursor = true;
		}
	}

	public static void PyroLog (string logMessage) {
		if (Debug.isDebugBuild) {
			Debug.Log(logMessage);
		}
	}
}
