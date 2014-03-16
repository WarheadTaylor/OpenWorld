using UnityEngine;
using System.Collections;

public sealed class Axe : Weapon {

	void Start () {
		Damage = 2.0F;
	}

	private void Hit () {
		transform.parent.parent.parent.GetComponent<UseWeapon>().Hit();
	}
}
