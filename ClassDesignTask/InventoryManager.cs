namespace ClassDesignTask
{
    public class InventoryManager
    {
        // Moves all items from the source inventory into the receiver
        public static void MoveAllItems(Inventory source, Inventory receiver)
        {
            if (source == null) throw new NullReferenceException(nameof(source));
            if (receiver == null) throw new NullReferenceException(nameof(receiver));

            foreach (Item item in source.Items)
            {
                receiver.AddItem(item);
            }
        }

        // Moves an item from source inventory into the receiver by adding a specified amount of an item into the receiver
        // and updating the item's count in the source
        public void MoveItem(Inventory source, Inventory receiver, Item item, int numberToTake) 
        {
            // If one of the object pointers is null, exit
            if (source == null)     throw new NullReferenceException(nameof(source));
            if (receiver == null)   throw new NullReferenceException(nameof(receiver));
            if (item == null)       throw new NullReferenceException(nameof(item));
            // Several checks for easier recognition which pointer was null

            if (!source.Items.Contains(item)) 
                throw new Exception("Item does not exist in the source inventory");

            if (item.Count <= numberToTake)     
            { 
                // Just add the item directly into the receiver and remove from the source,
                // if item's count is <= than the asked amount
                receiver.AddItem(item);
                source.RemoveItem(item);
                return;
            }

            // Otherwise only move part of the items and reduce the count in the source
            receiver.AddItem(item, numberToTake);
            item.ChangeItemCount(-numberToTake);
        }
    }
}