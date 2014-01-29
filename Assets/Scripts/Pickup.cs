using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
	private Transform firstPersonCamera;
	private GameObject objectHeld;

	void Start () {
		firstPersonCamera = transform.Find("FirstPersonCamera");
	}

	void Update () {
		// Ability to pickup GameObject's
		if (Input.GetKeyDown(KeyCode.E)) {
			RaycastHit hit;
			if (Physics.Raycast(firstPersonCamera.position, firstPersonCamera.forward, out hit, 2)) {
				if (hit.transform.gameObject.GetComponent<Rigidbody>()) {
					objectHeld = hit.collider.gameObject;
					objectHeld.GetComponent<Rigidbody>().isKinematic = true;
				}
			}
		} else if (Input.GetKeyUp(KeyCode.E) && objectHeld) {
			if (objectHeld.GetComponent<Rigidbody>()) {
				objectHeld.GetComponent<Rigidbody>().isKinematic = false;
			}
			objectHeld = null;
		} else if (objectHeld != null) {
			objectHeld.transform.position = Vector3.MoveTowards(objectHeld.transform.position, transform.position + transform.forward, 7.0F * Time.deltaTime);
		}
	}
}
