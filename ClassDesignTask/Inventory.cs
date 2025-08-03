using System;

public class Inventory {
	private int size;
	private Item[] items;

	public Inventory() {
		size = 10;
		items = new Item[size];
	}

	public Inventory(int size) {
		this.size = size;
        items = new Item[size];
    }
}
