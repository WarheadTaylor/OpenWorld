using UnityEngine;
using System.Collections;

using Pathfinding;

public class FollowPlayer : MonoBehaviour {
	private Seeker Seeker;
	private CharacterController Controller;

	private Path Path;

	private float NextWaypointDistance = 1.1F;
	private int CurrentWaypoint = 0;

	private GameObject Player;
	private float LastPathRebuild = 0.4F;

	private void Start () {
		Seeker = GetComponent<Seeker>();
		Controller = GetComponent<CharacterController>();
		Player = GameObject.Find("Player");
	}

	private void FixedUpdate () {
		LastPathRebuild += Time.deltaTime;

		if (Vector3.Distance(transform.position, Player.transform.position) > 20.0F) {
			return;
		}

		if (LastPathRebuild > 0.3F) {
			Seeker.StartPath(transform.position, Player.transform.position, OnPathComplete);
			LastPathRebuild = 0.0F;
		}

		if (Path == null || CurrentWaypoint >= Path.vectorPath.Count) {
			return;
		}

		if (Vector3.Distance(transform.position, Path.vectorPath[CurrentWaypoint]) < NextWaypointDistance) {
			CurrentWaypoint++;

			return;
		}

		Vector3 dir = (Path.vectorPath[CurrentWaypoint] - transform.position).normalized;
		dir *= 3.0F * Time.deltaTime;
		Controller.Move(dir);
	}

	private void OnPathComplete (Path p) {
		if (!p.error) {
			Path = p;
			CurrentWaypoint = 0;
		}
	}
}
