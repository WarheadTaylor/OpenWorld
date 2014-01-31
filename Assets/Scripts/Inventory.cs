using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Inventory : MonoBehaviour {
	private bool inventoryOpen = false;
	private int[] inventoryItems;

	private JSONNode listOfItems;

	void Start () {
		inventoryItems = new int[20];
		listOfItems = JSON.Parse(Resources.Load<TextAsset>("items").text);

		for (int i = 0; i < inventoryItems.Length; i++) {
			inventoryItems[i] = -1;
		}
	}

	void Update () {

	}

	public bool addToInventory(string item) {
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
