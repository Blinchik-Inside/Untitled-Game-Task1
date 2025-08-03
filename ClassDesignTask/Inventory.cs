using System;
using System.Collections;

public class Inventory {
	private int maxSize;
	private ArrayList items;

	public Inventory() {
		maxSize = 10;
		items = new ArrayList();
    }

	public Inventory(int size) {
		this.maxSize = size;
        items = new ArrayList();
    }

	/*
	 * Returns an error code if failed to add an item to the inventory:
	 *  - 0 if an item was added successfully.
	 *  - 1 if an item to be added is null.
	 *  - 2 if there is not enough space for that item in the inventory.
	 */  
	public int addItem(Item item) {
		if (item == null) return 1;
		if (items.Count >= maxSize) return 2;
	}
}
