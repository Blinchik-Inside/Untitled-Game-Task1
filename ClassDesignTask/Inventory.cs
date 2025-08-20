using System;
using System.Collections;
using System.Collections.Immutable;
using System.Text;
namespace ClassDesignTask
{
	public class Inventory
	{
		public int MaxSize { get; private set; }
		public IReadOnlyList<Item> Items { get;}	// Haven't changed this to Dictionary yet

		public Inventory(int size = 10)
		{
			MaxSize = size;
			Items = [];
		}

		public Item GetItem(int index) 
		{
			if (index < 0 || index >= Items.Count) 
				throw new ArgumentOutOfRangeException(nameof(index), "Index out of bounds");
			return Items[index]; 
		}

		public void AddItem(Item item)
		{
			if (item == null) throw new ArgumentNullException(nameof(item));

			if (Items.Count >= MaxSize)
				throw new Exception("Storage is full");

			for (int i = 0; i < Items.Count; i++)
			{
				if (Items[i].Name.CompareTo(item.Name) == 0)
				{
					// An identical item already exists in the inventory, just increase its count. 
					Items[i].ChangeItemCount(item.Count);
					return;
				}
			}

			Items.Add(item);
		}

        public void AddItem(Item item, int numberToAdd)
        {
            // TODO: Implement how to add only part of the item's count
			// Probably would me easier to make with dictionaries
        }

        public void RemoveItem(Item item)
        {
			if (!Items.Contains(item))
				throw new Exception("Item does not exist in the inventory");

            Items.Remove(item);
        }

		public override string ToString()
		{
			if (Items.Count == 0) return "Storage is empty.";
            StringBuilder contents = new StringBuilder();

            for (int i = 0; i < Items.Count; i++)
			{
				contents.Append($"{i + 1}) {Items[i].Name}, {Items[i].Description}, quantity: {Items.Count}\n");
            }

			return contents.ToString();
		}
	}
}