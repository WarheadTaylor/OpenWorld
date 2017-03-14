using UnityEngine;
using System.Collections;

public sealed class HUD : MonoBehaviour {
	private int FrameCount = 0;
	private float DeltaTime = 0.0F;
	private float FPS = 0.0F;
	private float UpdateRate = 5.0F;
	private GameObject Player;

	void Start () {
		Player = GameObject.Find("Player");
	}

	void Update () {
		FrameCount++;
		DeltaTime += Time.deltaTime;
		if (DeltaTime > 1.0F / UpdateRate) {
			FPS = FrameCount / DeltaTime ;
			FrameCount = 0;
			DeltaTime -= 1.0F / UpdateRate;
		}
	}

	void OnGUI () {
		GUI.Label(new Rect(10, 10, 150, 100), "Current FPS: " + ((int)FPS).ToString());
		// GUI.Label(new Rect(10, 50, 150, 100), "Current Health: " + Player.GetComponent<PlayerStats>().Health);
		GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 0, 0), "This is a crosshair");
	}
}
