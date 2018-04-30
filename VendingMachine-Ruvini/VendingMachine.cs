using System;

namespace VendingMachine_Ruvini
{
    public class VendingMachine
    {
        public Inventory Inventory { get; set; }
        public Register Register { get; set; }

        public VendingMachine()
        {
            Inventory = new Inventory();
            Register = new Register();
        }

        public void ShowOptions()
        {
            Console.WriteLine("");
            Console.WriteLine("This machine only accepts 5p, 10p, 20p, 50p, £1 and £2 coins!");
            Console.WriteLine("Below are the options:");
            Console.WriteLine("1 - Select the item by presing between 1 and " + (Inventory.InventoryList.Count + 1) + ". Options are: ");
            Inventory.InventoryList.ForEach(item =>
            {
                Console.WriteLine("\t" + (Inventory.InventoryList.IndexOf(item) + 1) + " - " + item.Product.ToString());
            });

            Console.WriteLine("");
            Console.WriteLine("2 - If you need to exit the game type press any key thats not between 1-9");
            Console.WriteLine("");
            Console.WriteLine("3 - If you are an operator press '9'");
            Console.WriteLine("");
        }
    }
}
