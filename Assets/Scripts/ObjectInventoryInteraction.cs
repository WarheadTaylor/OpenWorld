using UnityEngine;
using System.Collections;

public sealed class ObjectInventoryInteraction : MonoBehaviour {
	private Transform FirstPersonCamera;
	private Inventory LocalInventory;

	void Start () {
		FirstPersonCamera = transform.Find("FirstPersonCamera");
		LocalInventory = transform.GetComponent<Inventory>();
	}

	void Update () {
		// Select hotbar
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			SelectItem(0);
		} else if (Input.GetKeyDown(KeyCode.Alpha2)) {
			SelectItem(1);
		} else if (Input.GetKeyDown(KeyCode.Alpha3)) {
			SelectItem(2);
		} else if (Input.GetKeyDown(KeyCode.Alpha4)) {
			SelectItem(3);
		} else if (Input.GetKeyDown(KeyCode.Alpha5)) {
			SelectItem(4);
		} else if (Input.GetKeyDown(KeyCode.Alpha6)) {
			SelectItem(5);
		} else if (Input.GetKeyDown(KeyCode.Alpha7)) {
			SelectItem(6);
		} else if (Input.GetKeyDown(KeyCode.Alpha8)) {
			SelectItem(7);
		} else if (Input.GetKeyDown(KeyCode.Alpha9)) {
			SelectItem(8);
		}

		// Control pickup
		if (Input.GetKeyDown(KeyCode.E)) {
			InsertItem();
		}
	}

	private void SelectItem (int keyDown) {
		if (!LocalInventory.IfExists(keyDown)) {
			return;
		}

		GameObject Item = LocalInventory.Remove(keyDown);

		GameObject.Instantiate(Item, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
	}

	private void InsertItem () {
		RaycastHit hit;
		if (Physics.Raycast(FirstPersonCamera.position, FirstPersonCamera.forward, out hit, 2)) {
			GameObject item = hit.transform.gameObject;
			if (LocalInventory.Insert(item.name)) {
				DestroyObject(item);
			}
		}
	}
}
