using System;
using System.Diagnostics.CodeAnalysis;
namespace ClassDesignTask
{
    public enum ItemType 
		{ 
			Key,
			Healing,
            Weapon
		}
	

    public class Item
    {
        public int ID {  get; private set; }            // Item ID to simplify IEqualityComparer<> implementation
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ItemType Type { get; private set; }

        public Item(int newID, string newName, string newDescription, ItemType newType) 
        { 
            ID = newID;
            Name = newName;
            Description = newDescription;
            Type = newType;
        }
    }


    // Comparer allowing to use Item objects as keys in Dictionaries
    public class ItemEqualityComparer : IEqualityComparer<Item> 
    {
        public bool Equals(Item item1, Item item2) 
        { 
            if (item1 == null || item2 == null) return false;
            return item1.ID == item2.ID;
        }

        public int GetHashCode(Item item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            return item.ID.GetHashCode();
        }
    }
}