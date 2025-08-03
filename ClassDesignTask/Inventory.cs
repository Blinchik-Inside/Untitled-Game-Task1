using System;
using System.Collections;

public class Inventory {
	private int maxSize;
	private List<Item> items;

	public Inventory() {
		maxSize = 10;
		items = new List<Item>();
    }

	public Inventory(int size) {
		this.maxSize = size;
        items = new List<Item>();
    }

    public int getMaxSize() { return maxSize; }
    public int getCurrSize() { return items.Count; }

    /*
	 * Returns an int code depending on succes of the operation:
	 *  - 0 if an item was added successfully.
	 *  - 1 if an item to be added is null.
	 *  - 2 if there is not enough space for that item in the inventory.
	 */
    public int addItem(Item item) {
		if (item == null) return 1;
		if (items.Count >= maxSize) return 2;

		for (int i = 0; i < items.Count; i++) {
			if (items[i].getID == item.getID) {
				// An identical item already exists in the inventory, just increase its count. 
				items[i].increaseCount( item.getCount());
				return 0;
			}
		}

		items.Add(item);
		return 0;
	}

    /*
	 * Returns an int code depending on succes of the operation:
	 *  - 0 if an item was removed successfully.
	 *  - 1 if an item to be added is null.
	 *  - 2 if the inventory is empty.
	 *  - 3 if the item does not exist in the inventory.
	 */
    public int removeItem(Item item) {
		if (item == null) return 1;
		if (items.Count == 0) return 2;

		if (items.Contains(item)) { 
			items.Remove(item);
			return 0;
		}
		
		return 3;
	}

	public int takeItem(Item item, int num) {
		if (item == null) return 1;
		if (!items.Contains(item)) return 3;

		if (item.getCount() <= num) return removeItem(item);

		item.decreaseCount(num);
		return 0;
	}

	public void printInventory() { 
		if (items.Count == 0) return;

		for (int i = 0; i < items.Count; i++) {
			Console.WriteLine($"{i+1}) {items[i].getName()}, {items[i].getDescription()}");
		}
	}
}
