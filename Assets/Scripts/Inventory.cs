using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Inventory : MonoBehaviour {
	private bool inventoryOpen = false;
	private int[] inventoryItems;

	private JSONNode listOfItems;

	void Start () {
		inventoryItems = new int[8];
		listOfItems = JSON.Parse(Resources.Load<TextAsset>("items").text);

		for (int i = 0; i < inventoryItems.Length; i++) {
			inventoryItems[i] = -1;
		}
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.I)) {
			inventoryOpen = !inventoryOpen;
		}

		if (inventoryOpen) {
			if (Input.GetKeyDown(KeyCode.Alpha1)) {
				Debug.Log(inventoryItems[0]);
			} else if (Input.GetKeyDown(KeyCode.Alpha2)) {
				Debug.Log(inventoryItems[1]);
			} else if (Input.GetKeyDown(KeyCode.Alpha3)) {
				Debug.Log(inventoryItems[2]);
			} else if (Input.GetKeyDown(KeyCode.Alpha4)) {
				Debug.Log(inventoryItems[3]);
			} else if (Input.GetKeyDown(KeyCode.Alpha5)) {
				Debug.Log(inventoryItems[4]);
			} else if (Input.GetKeyDown(KeyCode.Alpha6)) {
				Debug.Log(inventoryItems[5]);
			} else if (Input.GetKeyDown(KeyCode.Alpha7)) {
				Debug.Log(inventoryItems[6]);
			} else if (Input.GetKeyDown(KeyCode.Alpha8)) {
				Debug.Log(inventoryItems[7]);
			} else if (Input.GetKeyDown(KeyCode.Alpha9)) {
				Debug.Log(inventoryItems[8]);
			}
		}
	}

	void OnGUI () {
		if (inventoryOpen) {
			GUI.Label(new Rect(10, 30, 150, 100), "Inventory is open!");
		}
	}

	public bool addToInventory (string item) {
		if (listOfItems[item] == null) {
			return false;
		}

		for (int i = 0; i < inventoryItems.Length; i++) {
			if (inventoryItems[i] == -1) {
				inventoryItems[i] = listOfItems[item].AsInt;

				Debug.Log (item + " added to position: " + i.ToString());

				break;
			}
		}

		return true;
	}
}
