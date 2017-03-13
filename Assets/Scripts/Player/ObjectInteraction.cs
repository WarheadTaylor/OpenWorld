using UnityEngine;
using System.Collections;

public sealed class ObjectInteraction : MonoBehaviour {
	public GameObject ItemInHand;

	private int SelectedItem;

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

		// Control drop
		if (Input.GetKeyDown(KeyCode.Q)) {
			DropItem();
		}
	}

	private void SelectItem (int keyDown) {
		Destroy(ItemInHand);

		SelectedItem = keyDown;

		if (LocalInventory.IfExists(keyDown)) {
			ItemInHand = (GameObject) GameObject.Instantiate(LocalInventory.GetItem(keyDown));
			ItemInHand.GetComponent<Rigidbody>().detectCollisions = false;
			ItemInHand.GetComponent<Rigidbody>().useGravity = false;
			//Taylor's bullshit play idle animation when you select item
			ItemInHand.GetComponent<Animation>().Play("idle");
            ItemInHand.layer = LayerMask.NameToLayer("Weapon");
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

	private void DropItem () {
		LocalInventory.Remove(SelectedItem);

		GameObject DroppedItem = (GameObject)Instantiate(ItemInHand, transform.position, transform.rotation);
		DroppedItem.transform.position += FirstPersonCamera.forward;
		DroppedItem.GetComponent<Rigidbody>().AddForce(FirstPersonCamera.forward * (Input.GetAxis("Vertical") + 1) * 5, ForceMode.Impulse);
		DroppedItem.GetComponent<Rigidbody>().detectCollisions = true;
		DroppedItem.GetComponent<Rigidbody>().useGravity = true;
        DroppedItem.layer = LayerMask.NameToLayer("Default");
		DroppedItem.name = DroppedItem.name.Substring(0, DroppedItem.name.IndexOf("(Clone)"));

		Destroy(ItemInHand);
	}
}
