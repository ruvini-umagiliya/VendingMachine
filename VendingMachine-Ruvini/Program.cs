using System;
using System.Linq;

namespace VendingMachine_Ruvini
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // creates the vending machine
            VendingMachine vendingMachine = new VendingMachine();

            do
            {
                vendingMachine.ShowOptions();

                // get the option selected from user
                var keyPressed = Console.ReadKey();
                Console.WriteLine("");

                int valuePressed = -1;
                int.TryParse(keyPressed.KeyChar.ToString(), out valuePressed);

                // if the value in valid then goes forward, otherwise exits the application
                if (valuePressed > 0)
                {
                    // gives the options that are only for the operators
                    if (valuePressed == 9)
                    {
                        operatorOptions(vendingMachine);
                        Console.WriteLine("Back in the main menu");
                    }
                    // if between the numbers 1 and the number of items in the vending machine to dispense the item selected
                    else if ((valuePressed >= 1) && (valuePressed < vendingMachine.Inventory.InventoryList.Count + 1))
                    {
                        var itemSelected = vendingMachine.Inventory.InventoryList.ElementAt(valuePressed - 1);
                        if (itemSelected.ProductCount > 0)
                        {
                            Console.WriteLine("You've selected :" + itemSelected.Product.ToString());
                            vendingMachine.Register.HandleMoneyAndProductFromUser(itemSelected, vendingMachine.Register);

                            // remove the product from the vending machine as it has been dispenced
                            itemSelected.ProductCount = itemSelected.ProductCount - 1;
                        }
                        else
                        {
                            Console.WriteLine("Sorry there are no more items of +" + itemSelected.Product.Name + ". Please select something else.");
                        }
                    }
                    // error has given an invalid selection, lets the user select again
                    else
                    {
                        Console.WriteLine("Please make a selection as the previous selection is invalid");
                    }
                }
                else
                {
                    break;
                }
            }
            while (true);

            Console.WriteLine("Vending machine is getting desrtoyed...");
        }

        /// <summary>
        /// This method handles all the options that can be selected by the operators
        /// </summary>
        /// <param name="vendingMachine"></param>
        private static void operatorOptions(VendingMachine vendingMachine)
        {
            Console.WriteLine("Below are the operators options: ");
            Console.WriteLine("1 - Add cash");
            Console.WriteLine("2 - Remove cash");
            Console.WriteLine("3 - Add item");
            Console.WriteLine("4 - Remove item");
            Console.WriteLine("0 - Back to the main menu");

            do
            {
                // get the option selected from operator
                var keyPressed = Console.ReadKey();
                Console.WriteLine("");

                int valuePressed = -1;
                int.TryParse(keyPressed.KeyChar.ToString(), out valuePressed);

                // if the value in valid then goes forward, otherwise exits the application
                if (valuePressed > 0)
                {
                    if (valuePressed == 1)
                    {
                        vendingMachine.Register.AddCash();
                        break;
                    }
                    else if (valuePressed == 2)
                    {
                        vendingMachine.Register.RemoveCash();
                        break;
                    }
                    else if (valuePressed == 3)
                    {
                        vendingMachine.Inventory.AddItem();
                        break;
                    }
                    else if (valuePressed == 4)
                    {
                        vendingMachine.Inventory.RemoveItem();
                        break;
                    }
                    // error has given an invalid selection, lets the operator select again
                    else
                    {
                        Console.WriteLine("Please make a selection as the previous selection is invalid");
                    }
                }
                else
                {
                    break;
                }
            }
            while (true);
        }
    }
}
