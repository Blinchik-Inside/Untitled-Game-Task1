using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
namespace ClassDesignTask
{
	public class Inventory
	{
		public int MaxSize { get; private set; }
		public Dictionary<Item, int> Items { get; }		// Downside: can be affected by outside classes, maybe look into ImmutableDictionary??

		public Inventory(int size = 10)
		{
			MaxSize = size;
			Items = new Dictionary<Item, int>(new ItemEqualityComparer());
		}

		public void AddItem(Item item, int numberToAdd)
		{
			if (item == null) 
				throw new ArgumentNullException(nameof(item));

			if (Items.Count >= MaxSize) 
				throw new Exception("Storage is full");

            if (!Items.TryGetValue(item, out int count))
                Items.Add(item, 1);
            else
                Items[item] = count + numberToAdd;
        }

        public void RemoveItem(Item item)
        {
            if (item == null) 
				throw new ArgumentNullException(nameof(item));

			if (!Items.ContainsKey(item))
				throw new Exception("Item does not exist in the inventory");

            Items.Remove(item);
        }

		public override string ToString()
		{
			if (Items.Count == 0) return "Storage is empty.";
            StringBuilder contents = new StringBuilder();

			int i = 1;
            foreach (Item item in Items.Keys)
			{
				contents.Append($"{i}) {item.Name}, {item.Description}, quantity: {Items[item]}\n");
            }

			return contents.ToString();
		}
	}
}