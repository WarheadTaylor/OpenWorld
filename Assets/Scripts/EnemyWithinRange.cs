using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyWithinRange : MonoBehaviour {
	private float TimePast = 0.0F;

	private void FixedUpdate () {
		TimePast += Time.deltaTime;

		if (TimePast < 3.0F) {
			return;
		}

		TimePast = 0.0F;

		foreach (Collider collider in Physics.OverlapSphere(transform.position, 10.0F)) {
			GameObject hit = collider.transform.gameObject;

			if (hit.tag != "Enemy") {
				continue;
			}

			hit.GetComponent<FollowPlayer>().ActivateFollow(transform.position);
		}
	}
}
