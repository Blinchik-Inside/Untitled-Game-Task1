using System;
namespace ClassDesignTask
{
	public class Item
	{
		private int ID;
		private string name;
		private int count;
		private string description;
		private int healingFactor;

		public Item(int id, string name, string description)
		{
			this.ID = id;
			this.name = name;
			count = 1;
			this.description = description;
			healingFactor = 0;
		}

		public Item(int id, string name, string description, int healingFactor)
		{
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

		public int GetID() { return ID; }
		public string GetName() { return name; }

		public int GetCount() { return count; }
		public void IncreaseCount(int val) { count = count + val; }
		public void DecreaseCount(int val) { count = count - val; }

		public String GetDescription() { return description; }

		public int GetHealingFactor() { return healingFactor; }
	}
}