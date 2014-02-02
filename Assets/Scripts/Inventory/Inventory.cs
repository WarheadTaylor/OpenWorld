public sealed class Inventory {
	private InventoryItem[] InventoryItems;

	public bool Insert (string name) {
		for (int i = 0; i < InventoryItems.Length; i++) {
			if (InventoryItems[i] != null) {
				break;
			}

			InventoryItems[i] = new InventoryItem(name);
			if (!InventoryItems[i].IsValid) {
				InventoryItems[i] = null;

				return false;
			}
		}

		return true;
	}
}
