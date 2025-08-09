namespace ClassDesignTask
{
    using System;
    public class Test1
    {
        public static void Main(string[] args)
        {
            Character? character = null;
            while (character == null)
            {
                Console.WriteLine("Would you like to use the pre-set characteristics? (y/n)");
                string? baseStats = Console.ReadLine();
                Console.WriteLine("Select character class: 1) Knight 2) Hunter 3) Mage");
                string? classChoice = Console.ReadLine();
                if ((baseStats ?? "n").Equals("y", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("Enter character name:");
                    string? name = Console.ReadLine() ?? "NoName";
                    switch (classChoice)
                    {
                        case "1": character = new Knight(name, 16, 15, 17, 10, 8, 5); break;
                        case "2": character = new Hunter(name, 20); break;
                        case "3": character = new Mage(name, 10); break;
                        default: Console.WriteLine("Incorrect character class choice."); break;
                    }
                }
                else
                {
                    Console.WriteLine("Enter character name:");
                    string? name = Console.ReadLine() ?? "NoName";
                    Console.WriteLine("HP:");
                    int hp = int.TryParse(Console.ReadLine(), out var hptmp) ? hptmp : 10;
                    Console.WriteLine("Endurance:");
                    int end = int.TryParse(Console.ReadLine(), out var endtmp) ? endtmp : 10;
                    Console.WriteLine("Force:");
                    int force = int.TryParse(Console.ReadLine(), out var fortmp) ? fortmp : 10;
                    Console.WriteLine("Dexterity:");
                    int dex = int.TryParse(Console.ReadLine(), out var dextmp) ? dextmp : 10;
                    Console.WriteLine("Intelligence:");
                    int intel = int.TryParse(Console.ReadLine(), out var inttmp) ? inttmp : 10;
                    switch (classChoice)
                    {
                        case "1":
                            Console.WriteLine("Attack radius:");
                            int rad = int.TryParse(Console.ReadLine(), out var radtmp) ? radtmp : 5;
                            character = new Knight(name, hp, end, force, dex, intel, rad);
                            break;
                        case "2":
                            Console.WriteLine("Number of arrowa:");
                            int arrows = int.TryParse(Console.ReadLine(), out var arrtmp) ? arrtmp : 20;
                            character = new Hunter(name, hp, end, force, dex, intel, arrows);
                            break;
                        case "3":
                            Console.WriteLine("Max mana to be used:");
                            int mana = int.TryParse(Console.ReadLine(), out var manatmp) ? manatmp : 10;
                            character = new Mage(name, hp, end, force, dex, intel, mana);
                            break;
                        default: Console.WriteLine("Incorrect choice."); break;
                    }
                }
            }

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nMenu: 1) New storage 2) Open inventory 3) Quit");
                string? menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        var chest = new Inventory();
                        chest.AddItem(new Item(id: 1, name: "Key", description: "Mysterious key"));
                        chest.AddItem(new Item(id: 2, name: "Healing Potion", description: "Heals 10", healingFactor: 10));
                        chest.AddItem(new Item(id: 3, name: "Fabric", count: 3, description: "Ripped piece of fabric"));
                        Console.WriteLine($"Chest contains: {chest}");
                        Console.WriteLine("Select action: 1) Take only 1 item 2) Take all 3) Exit the chest");
                        string? chestChoice = Console.ReadLine();
                        if (chestChoice == "1")
                        {
                            Console.WriteLine("Which item to pick? (1-3)");
                            int itemNum = int.TryParse(Console.ReadLine(), out var itemtmp) ? itemtmp : 1;
                            if (itemNum >= 1 && itemNum <= chest.GetCurrSize())
                            {
                                var item = chest.GetItem(itemNum - 1);
                                character.GetInventory().AddItem(item);
                                Console.WriteLine($"You took: {item.GetName()}");
                            }
                        }
                        else if (chestChoice == "2")
                        {
                            character.FlushChest(chest);
                            Console.WriteLine("You gathered everything from the chest.");
                        }
                        else
                        {
                            Console.WriteLine("You decided to skip this chest.");
                        }
                        break;
                    case "2":
                        var inv = character.GetInventory();
                        Console.WriteLine("Your current inventory:");
                        Console.WriteLine(inv.ToString());
                        if (inv.GetCurrSize() > 0)
                        {
                            Console.WriteLine("Would you like to drop an item? (y/n)");
                            string? drop = Console.ReadLine();
                            if ((drop ?? "n").Equals("y", StringComparison.CurrentCultureIgnoreCase))
                            {
                                Console.WriteLine("Enter the item's number:");
                                int dropNum = int.TryParse(Console.ReadLine(), out var droptmp) ? droptmp : 1;
                                if (dropNum >= 1 && dropNum <= inv.GetCurrSize())
                                {
                                    var item = inv.GetItem(dropNum - 1);
                                    inv.RemoveItem(item);
                                    Console.WriteLine($"You have dropped: {item.GetName()}");
                                }
                            }
                        }
                        break;
                    case "3":
                        exit = true;
                        Console.WriteLine("Exiting the program. Good bye!");
                        break;
                    default:
                        Console.WriteLine("Incorrect entrie.");
                        break;
                }
            }
        }
    }
}
