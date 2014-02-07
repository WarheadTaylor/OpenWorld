using UnityEngine;
using System.Collections;

public sealed class UseWeapon : MonoBehaviour {
	private ObjectInteraction LocalObjectInteraction;

	void Start () {
		LocalObjectInteraction = transform.GetComponent<ObjectInteraction>();
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			if (LocalObjectInteraction.ItemInHand.tag == "Weapon") {
				LocalObjectInteraction.ItemInHand.GetComponent<Animation>().Play("hit");
			}
		}
	}

}
