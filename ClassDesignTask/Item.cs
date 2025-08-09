using System;
namespace ClassDesignTask
{
	public class Item
	{
		private readonly int _id;
		private readonly string _name;
		private int _count;
		private readonly string _description;
		private readonly int _healingFactor;

		public Item(int id, string name, string description)
		{
			_id = id;
			_name = name;
			_count = 1;
			_description = description;
			_healingFactor = 0;
		}

		public Item(int id, string name, string description, int healingFactor)
		{
			_id = id;
			_name = name;
			_count = 1;
			_description = description;
			_healingFactor = healingFactor;
		}

        public Item(int id, string name, int count, string description)
        {
            _id = id;
            _name = name;
            _count = count;
            _description = description;
            _healingFactor = 0;
        }

        public Item(int id, string name, int count, string description, int healingFactor)
		{
			_id = id;
			_name = name;
			_count = count;
			_description = description;
			_healingFactor = healingFactor;
		}

		public int GetID() { return _id; }
		public string GetName() { return _name; }

		public int GetCount() { return _count; }
		public void IncreaseCount(int val) { _count = _count + val; }
		public void DecreaseCount(int val) { _count = _count - val; }

		public String GetDescription() { return _description; }

		public int GetHealingFactor() { return _healingFactor; }
	}
}