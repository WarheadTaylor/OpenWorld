using UnityEngine;

using SimpleJSON;

public sealed class InventoryItem {
	public bool IsValid;

	private string Name;
	
	public InventoryItem (string name) {
		Name = name;
		ValidateItem(name);
	}

	public GameObject GetItem () {
		return Resources.Load<GameObject>("Prefabs/" + Name);
	}

	public string GetName () {
		return Name;
	}

	private void ValidateItem (string name) {
		JSONNode Result = JSON.Parse(Resources.Load<TextAsset>("TextAssets/items").text);

		if (Result[name].AsBool) {
			IsValid = true;
		} else {
			IsValid = false;
		}
	}
}
