using UnityEngine;
using System.Collections;

using Pathfinding;

public class FollowPlayer : MonoBehaviour {
	private Seeker Seeker;
	private CharacterController Controller;

	private Path Path;

	private float NextWaypointDistance = 3.0F;
	private int CurrentWaypoint = 0;

	private void Start () {
		Seeker = GetComponent<Seeker>();
		Controller = GetComponent<CharacterController>();
	}

	private void FixedUpdate () {
		if (Path == null || CurrentWaypoint >= Path.vectorPath.Count) {
			return;
		}

		Vector3 dir = (Path.vectorPath[CurrentWaypoint] - transform.position).normalized;
		dir *= 3.0F * Time.deltaTime;
		Controller.Move(dir);

		if (Vector3.Distance(transform.position, Path.vectorPath[CurrentWaypoint]) < NextWaypointDistance) {
			CurrentWaypoint++;
			return;
		}
	}

	private void OnPathComplete (Path p) {
		Utils.PyroLog("Yey, we got a path back. Did it have an error? " + p.error);

		if (!p.error) {
			Path = p;
			CurrentWaypoint = 0;
		}
	}

	public void ActivateFollow (Vector3 playerPosition) {
		Seeker.StartPath(transform.position, playerPosition, OnPathComplete);
	}
}
