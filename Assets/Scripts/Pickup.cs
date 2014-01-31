using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
	private Transform firstPersonCamera;

	private GameObject item;
	private Inventory inventoryScript;

	void Start () {
		firstPersonCamera = transform.Find("FirstPersonCamera");
		inventoryScript = transform.GetComponent<Inventory>();
	}

	void Update () {
		// Ability to pickup GameObject's
		if (Input.GetKeyDown(KeyCode.E)) {
			RaycastHit hit;
			if (Physics.Raycast(firstPersonCamera.position, firstPersonCamera.forward, out hit, 2)) {
				item = hit.transform.gameObject;
				if (inventoryScript.addToInventory(item.name)) {
					DestroyObject(item);
				}
			}
		}
	}
}
