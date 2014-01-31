using UnityEngine;
using System.Collections;

public class PlaceObject : MonoBehaviour {
	private Transform firstPersonCamera;

	private bool inventoryOpen = false;
	private Inventory inventoryScript;

	private GameObject item;

	void Start () {
		firstPersonCamera = transform.Find("FirstPersonCamera");
		inventoryScript = transform.GetComponent<Inventory>();
	}

	void Update () {
		inventoryOpen = inventoryScript.getInventoryOpen();

		if (inventoryOpen) {
			if (Input.GetKeyDown(KeyCode.Alpha1)) {
				placeObject(0);
			} else if (Input.GetKeyDown(KeyCode.Alpha2)) {
				placeObject(1);
			} else if (Input.GetKeyDown(KeyCode.Alpha3)) {
				placeObject(2);
			} else if (Input.GetKeyDown(KeyCode.Alpha4)) {
				placeObject(3);
			} else if (Input.GetKeyDown(KeyCode.Alpha5)) {
				placeObject(4);
			} else if (Input.GetKeyDown(KeyCode.Alpha6)) {
				placeObject(5);
			} else if (Input.GetKeyDown(KeyCode.Alpha7)) {
				placeObject(6);
			} else if (Input.GetKeyDown(KeyCode.Alpha8)) {
				placeObject(7);
			} else if (Input.GetKeyDown(KeyCode.Alpha9)) {
				placeObject(8);
			}
		}
	}

	void placeObject (int position) {
		item = inventoryScript.getFromInventory(position);
		Instantiate(item, new Vector3(0, 0, 0), Quaternion.identity);
	}
}
