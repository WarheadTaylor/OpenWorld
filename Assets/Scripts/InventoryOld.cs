using UnityEngine;
using System.Collections;

using SimpleJSON;

public sealed class InventoryOld : MonoBehaviour {
	private int[] inventoryItems;
	private bool inventoryOpen = false;

	private JSONNode itemsValue;

	private InventoryItem[] InventoryItems;

	void Start () {
		inventoryItems = new int[9];
		InventoryItems = new InventoryItem[9];

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
		for (int i = 0; i < InventoryItems.Length; i++) {
			if (InventoryItems[i] == null) {
				InventoryItems[i] = new InventoryItem(item);

				if (!InventoryItems[i].IsValid) {
					InventoryItems[i] = null;
				}

				break;
			}
		}

		return true;
	}

	public GameObject getFromInventory (int position) {
		if (inventoryItems[position] == -1) {
			return null;
		}

		return Resources.Load<GameObject>("Prefabs/" + itemsValue[inventoryItems[position]]);
	}

	public bool getInventoryOpen () {
		return inventoryOpen;
	}
}
