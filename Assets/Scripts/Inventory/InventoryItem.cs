using UnityEngine;
using System.Collections;

using SimpleJSON;

public sealed class InventoryItem {
	public bool IsValid;

	private int Type;
	private string Name;
	
	public InventoryItem (string name) {
		Name = name;
		Type = GetType();
	}

	public GameObject GetItem () {
		return Resources.Load<GameObject>("Prefabs/" + Name);
	}

	private int GetType () {
		JSONNode Result = JSON.Parse(Resources.Load<TextAsset>("TextAssets/itemsKey").text);

		ValidateItem(Result);

		return Result[Name].AsInt;
	}

	private void ValidateItem (JSONNode result) {
		if (result[Name] == null) {
			IsValid = false;
		} else {
			IsValid = true;
		}
	}
}
