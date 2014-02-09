using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyWithinRange : MonoBehaviour {
	private List<GameObject> Enemies;

	private float TimePast = 0.0F;

	private void Start () {
		Enemies = new List<GameObject>();
	}

	private void FixedUpdate () {
		TimePast += Time.deltaTime;

		if (TimePast < 3.0F) {
			return;
		}

		TimePast = 0.0F;

		foreach (Collider collider in Physics.OverlapSphere(transform.position, 10.0F)) {
			GameObject hit = collider.transform.gameObject;

			if (!Enemies.Contains(hit)) {
				Enemies.Add(hit);
				print(hit);
			}
		}

		print(Enemies.ToArray().Length);
	}
}
