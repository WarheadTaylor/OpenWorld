using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public int Health = 100;

	void Start () {
	
	}
	
	void Update () {
	
	}

	public void RemoveHealth (int amountOfHealth) {
		Health -= amountOfHealth;
		if (Health <= 0) {
			Utils.PyroLog("You're dead motherfucker!");
		}
	}
}
