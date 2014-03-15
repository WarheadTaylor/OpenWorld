using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
    private int Health = 100;

	void Start () {
	
	}
	
	void Update () {
	
	}

	void RemoveHealth(int amountOfHealth) {
		Health -= amountOfHealth;
		if (Health <= 0) {
			Utils.PyroLog("You're dead motherfucker!");
		}
	}
}
