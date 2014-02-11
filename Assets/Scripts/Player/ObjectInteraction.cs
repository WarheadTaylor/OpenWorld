using UnityEngine;
using System.Collections;

public sealed class ObjectInteraction : MonoBehaviour {
	public GameObject ItemInHand;

	private Transform FirstPersonCamera;
	private Inventory LocalInventory;

	void Start () {
		FirstPersonCamera = transform.Find("FirstPersonCamera");
		LocalInventory = transform.GetComponent<Inventory>();

		ItemInHand = new GameObject("Empty Inventory Slot");
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
		Destroy(ItemInHand);

		if (LocalInventory.IfExists(keyDown)) {
			ItemInHand = (GameObject) GameObject.Instantiate(LocalInventory.GetItem(keyDown));
			ItemInHand.GetComponent<Rigidbody>().detectCollisions = false;
			ItemInHand.GetComponent<Rigidbody>().useGravity = false;
			//Taylor's bullshit play idle animation when you select item
			ItemInHand.GetComponent<Animation>().Play("idle");
		} else {
			ItemInHand = new GameObject("Empty Inventory Slot");
		}

		ItemInHand.transform.parent = FirstPersonCamera.transform.Find("Hand").transform;
		ItemInHand.transform.localPosition = Vector3.zero;
		ItemInHand.transform.localRotation = Quaternion.identity;
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
