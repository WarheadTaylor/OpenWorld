﻿using UnityEngine;
using System.Collections;

public sealed class PlayAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Animation>().Play("hit");
	}
}
