using UnityEngine;
using System.Collections;

public class WebPlayer : MonoBehaviour {
	
	void Start () {
		
	}
	
	void Update () {
		
		if (Application.isWebPlayer) {
			if (Application.CanStreamedLevelBeLoaded(1)) {
				Application.LoadLevel(1);
			}
		}
	}
}
