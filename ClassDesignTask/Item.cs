using System;
namespace ClassDesignTask
{
    public enum ItemType 
		{ 
			Key,
			Heling,
            Weapon
		}
	
    public class Item(string newName, string newDescription, ItemType newType, int newCount = 1)
    {
        public string Name { get; private set; } = newName;
        public string Description { get; private set; } = newDescription;
        public int Count { get; private set; } = newCount;
        public ItemType Type { get; private set; } = newType;

        public void ChangeItemCount(int change) 
        { 
            Count += change; 
        }
    }
}