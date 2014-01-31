using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Inventory : MonoBehaviour {
	private int[] inventoryItems;
	private bool inventoryOpen = false;

	private JSONNode itemsKey;
	private JSONNode itemsValue;

	void Start () {
		inventoryItems = new int[9];
		itemsKey = JSON.Parse(Resources.Load<TextAsset>("TextAssets/itemsKey").text);
		itemsValue = JSON.Parse(Resources.Load<TextAsset>("TextAssets/itemsValue").text);

		for (int i = 0; i < inventoryItems.Length; i++) {
			inventoryItems[i] = -1;
		}
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.I)) {
			inventoryOpen = !inventoryOpen;
		}
	}

	void OnGUI () {
		if (inventoryOpen) {
			GUI.Label(new Rect(10, 30, 150, 100), "Inventory is open!");
		}
	}

	public bool addToInventory (string item) {
		if (itemsKey[item] == null) {
			return false;
		}

		for (int i = 0; i < inventoryItems.Length; i++) {
			if (inventoryItems[i] == -1) {
				inventoryItems[i] = itemsKey[item].AsInt;

				Debug.Log (item + " added to position: " + i.ToString());

				break;
			}
		}

		return true;
	}

	public GameObject getFromInventory (int position) {
		if (inventoryItems[position] == -1) {
			return null;
		}

		Debug.Log (itemsValue[inventoryItems[position]]);

		return Resources.Load<GameObject>("Prefabs/" + itemsValue[inventoryItems[position]]);
	}

	public bool getInventoryOpen () {
		return inventoryOpen;
	}
}
