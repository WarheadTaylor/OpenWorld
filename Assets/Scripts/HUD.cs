using UnityEngine;
using System.Collections;

public sealed class HUD : MonoBehaviour {
	private int frameCount = 0;
	private float dt = 0.0F;
	private float fps = 0.0F;
	private float updateRate = 4.0F;

	void Start () {

	}

	void Update () {
		frameCount++;
		dt += Time.deltaTime;
		if (dt > 1.0F / updateRate) {
			fps = frameCount / dt ;
			frameCount = 0;
			dt -= 1.0F / updateRate;
		}
	}

	void OnGUI () {
		GUI.Label(new Rect(10, 10, 150, 100), "Current FPS: " + ((int)fps).ToString());
		GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 0, 0), "This is a crosshair");
	}
}
