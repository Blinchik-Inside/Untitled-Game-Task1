using System;

public class Item {
	private int ID;
	private string name;
	private int count;
	private string description;
	private int healingFactor;

	public Item(int id, string name) {
        this.ID = id;
        this.name = name;
		count = 1;
		description = "";
		healingFactor = 0;
	}


}
