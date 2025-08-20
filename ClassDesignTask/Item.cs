using System;
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
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Count { get; private set; } 
        public ItemType Type { get; private set; }

        public Item(string newName, string newDescription, ItemType newType, int newCount = 1) 
        { 
            Name = newName;
            Description = newDescription;
            Type = newType;
            Count = newCount;
        }

        // Can take both positive and negative values to update the count
        public void ChangeItemCount(int change) 
        { 
            Count += change; 
        }
    }
}