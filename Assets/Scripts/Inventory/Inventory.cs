using UnityEngine;
using System.Collections;

public sealed class Inventory : MonoBehaviour {
	private InventoryItem[] InventoryItems;

	void Start () {
		InventoryItems = new InventoryItem[9];
	}

	public bool Insert (string name) {
		for (int i = 0; i < InventoryItems.Length; i++) {
			if (InventoryItems[i] != null) {
				continue;
			}

			InventoryItems[i] = new InventoryItem(name);

			if (!InventoryItems[i].IsValid) {
				InventoryItems[i] = null;

				return false;
			}

			Debug.Log(name + " added to inventory slot: " + (i + 1));

			return true;
		}

		return false;
	}

	public GameObject Remove (int inventoryIndex) {
		InventoryItem Item = InventoryItems[inventoryIndex];
		InventoryItems[inventoryIndex] = null;

		Debug.Log(Item.GetName() + " removed at position: " + (inventoryIndex + 1));

		return Item.GetItem();
	}

	public bool IfExists (int InventoryIndex) {
		if (InventoryItems[InventoryIndex] != null) {
			return true;
		} else {
			return false;
		}
	}
}
