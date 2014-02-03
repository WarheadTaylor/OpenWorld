using UnityEngine;
using System.Collections;

public sealed class Inventory : MonoBehaviour {
	private InventoryItem[] InventoryItems;

	void Start () {
		InventoryItems = new InventoryItem[9];

		for (int i = 0 ; i < InventoryItems.Length; i++) {
			InventoryItems[i] = null;
		}
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
}
