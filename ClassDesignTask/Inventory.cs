using System;
using System.Collections;
using System.Text;
namespace ClassDesignTask
{
	public class Inventory
	{
		public int MaxSize { get; private set; }
		public List<Item> Items { get;}

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

		public void RemoveItem(Item item)
        {
			if (Items.Count == 0)
				throw new Exception("Inventory is empty");

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
				contents.Append(i + 1);
				contents.Append(") ");
				contents.Append(Items[i].Name);
				contents.Append(", ");
                contents.Append(Items[i].Description);
                contents.Append(", quantity: ");
				contents.Append(Items[i].Count);
                contents.Append('\n');
            }

			return contents.ToString();
		}
	}
}