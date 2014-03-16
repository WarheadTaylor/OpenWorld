using UnityEngine;
using System.Collections;

public sealed class UseWeapon : MonoBehaviour {
	private Transform FirstPersonCamera;
	private ObjectInteraction LocalObjectInteraction;

	private int TimesHit = 0;

	void Start () {
		FirstPersonCamera = transform.Find("FirstPersonCamera");
		LocalObjectInteraction = transform.GetComponent<ObjectInteraction>();
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			if (LocalObjectInteraction.ItemInHand.tag == "Weapon") {
				LocalObjectInteraction.ItemInHand.GetComponent<Animation>().Play("hit");
			}
		}
	}

	public void Hit () {
		RaycastHit hit;
		if (Physics.Raycast(FirstPersonCamera.position, FirstPersonCamera.forward, out hit, 1)) {
			foreach (InteractableObject Script in hit.transform.GetComponents<InteractableObject>()) {
				Script.Hit(LocalObjectInteraction.ItemInHand.gameObject);
			}
		}
	}
}
