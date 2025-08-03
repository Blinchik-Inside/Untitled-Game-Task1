using System;

public class Item {
	private int ID;
	private string name;
	private int count;
	private string description;
	private int healingFactor;

	public Item(int id, string name, string description) {
        this.ID = id;
        this.name = name;
		count = 1;
		this.description = description;
		healingFactor = 0;
	}

	public Item(int id, string name, string description, int healingFactor) {
        this.ID = id;
        this.name = name;
        count = 1;
        this.description = description;
        this.healingFactor = healingFactor;
    }

    public Item(int id, string name, int count, string description, int healingFactor)
    {
        this.ID = id;
        this.name = name;
		this.count = count;
        this.description = description;
        this.healingFactor = healingFactor;
    }

    public int getID() { return ID; }
	public string getName() { return name; }
	
	public int getCount() { return count; }
	public void increaseCount(int val) { count = count + val; }
	public void decreaseCount(int val) { count = count - val; }

	public String getDescription() { return description; }

	public int getHealingFactor() { return healingFactor; }
}
