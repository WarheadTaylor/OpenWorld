using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {
	private bool inventoryOpen = false;
	private int[] inventoryItems;

	void Start () {
		inventoryItems = new int[20];
	}

	void Update () {

	}

	void onGui () {
		GUI.Box(new Rect(0,0,640,480), "Inventory");
	}
}
