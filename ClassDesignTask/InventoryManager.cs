namespace ClassDesignTask
{
    public class InventoryManager
    {
        public static void MoveAllItems(Inventory source, Inventory receiver)
        {
            foreach (Item item in source.Items)
            {
                receiver.AddItem(item);
            }
        }

        public void MoveItem(Inventory source, Inventory receiver, Item item, int numberToTake) 
        {
            if (!source.Items.Contains(item)) 
                throw new Exception("Item does not exist in the source inventory");

            if (item.Count <= numberToTake) 
            { 
                source.RemoveItem(item);
                return;
            }

            item.ChangeItemCount(-numberToTake);
        }
    }
}