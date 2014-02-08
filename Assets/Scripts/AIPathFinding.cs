using UnityEngine;
using System.Collections;

using Pathfinding;

public class AIPathFinding : MonoBehaviour {

	public void Start () {
		Seeker Seeker = GetComponent<Seeker>();
		Seeker.StartPath(transform.position, new Vector3(0, 0, 0), OnPathComplete);
	}

	public void OnPathComplete (Path p) {
		Utils.PyroLog("Yey, we got a path back. Did it have an error? " + p.error);
	}
}
