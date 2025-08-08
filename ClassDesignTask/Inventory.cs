using System;
using System.Collections;
namespace ClassDesignTask
{
	public class Inventory
	{
		private readonly int _maxSize;
		private readonly List<Item> _items;

		public Inventory()
		{
			_maxSize = 10;
			_items = [];
		}

		public Inventory(int size)
		{
			_maxSize = size;
			_items = [];
		}

		public int GetMaxSize() { return _maxSize; }
		public int GetCurrSize() { return _items.Count; }

		public Item GetItem(int index) { return _items[index]; }
		public List<Item> GetAllItems() { return _items; }

		/*
		 * Returns an int code depending on succes of the operation:
		 *  - 0 if an item was added successfully.
		 *  - 1 if an item to be added is null.
		 *  - 2 if there is not enough space for that item in the inventory.
		 */
		public int AddItem(Item item)
		{
			if (item == null) return 1;
			if (_items.Count >= _maxSize) return 2;

			for (int i = 0; i < _items.Count; i++)
			{
				if (_items[i].GetID == item.GetID)
				{
					// An identical item already exists in the inventory, just increase its count. 
					_items[i].IncreaseCount(item.GetCount());
					return 0;
				}
			}

			_items.Add(item);
			return 0;
		}

		/*
		 * Returns an int code depending on succes of the operation:
		 *  - 0 if an item was removed successfully.
		 *  - 1 if an item to be added is null.
		 *  - 2 if the inventory is empty.
		 *  - 3 if the item does not exist in the inventory.
		 */
		public int RemoveItem(Item item)
        {
            if (item == null) return 1;
            if (_items.Count == 0) return 2;

            if (!_items.Contains(item))
            {
                return 3;
            }

            _items.Remove(item);
            return 0;
        }

        public int TakeItem(Item item, int num)
		{
			if (item == null) return 1;
			if (!_items.Contains(item)) return 3;

			if (item.GetCount() <= num) return RemoveItem(item);

			item.DecreaseCount(num);
			return 0;
		}

		public void PrintInventory()
		{
			if (_items.Count == 0) return;

			for (int i = 0; i < _items.Count; i++)
			{
				Console.WriteLine($"{i + 1}) {_items[i].GetName()}, {_items[i].GetDescription()}");
			}
		}
	}
}