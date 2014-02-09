using UnityEngine;
using System.Collections;

using Pathfinding;

public class FollowPlayer : MonoBehaviour {
/*	private Seeker Seeker;
	private CharacterController Controller;

	private Path Path;

	private float NextWaypointDistance = 3.0F;
	private int CurrentWaypoint = 0;

	private void Start () {
		Seeker = GetComponent<Seeker>();
		Controller = GetComponent<CharacterController>();

		//Seeker.StartPath(transform.position, new Vector3(23.0F, 0, 17.0F), OnPathComplete);
	}

	private void FixedUpdate () {

		if (Path == null) {
			return;
		}

		if (CurrentWaypoint >= Path.vectorPath.Count) {
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
	}*/
}
