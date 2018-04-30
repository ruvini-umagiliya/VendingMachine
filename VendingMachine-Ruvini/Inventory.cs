using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine_Ruvini
{
    /// <summary>
    /// A list of all the products available in the Vending machine and the count of each product that is in
    /// </summary>
    public class Inventory
    {
        public List<InventoryItem> InventoryList { get; set; }

        // to make sure that the machine has space to keep each product
        private int totalLimitPerProduct = 10;

        public Inventory()
        {
            InventoryItem item1 = new InventoryItem(new Product("Pepsi", 1.50m), 5);
            InventoryItem item2 = new InventoryItem(new Product("KitKat", 0.75m), 10);
            InventoryItem item3 = new InventoryItem(new Product("Mars", 1.00m), 10);
            InventoryItem item4 = new InventoryItem(new Product("Hula Hoops", 1.20m), 7);

            InventoryList = new List<InventoryItem>() { item1, item2, item3, item4 };
        }

        /// <summary>
        /// Adds more items to the inventory for which the Product already exists
        /// </summary>
        public void AddItem()
        {
            Console.WriteLine("");
            var lineEntered = "";
            int itemNumberSelected = 0;
            int numOfIems = 0;

            do
            {
                Console.WriteLine("Below are the options:");
                Console.WriteLine("1 - Select the item by presing between 1 and " + (InventoryList.Count + 1) + ". Options are: ");
                InventoryList.ForEach(item =>
                {
                    Console.WriteLine("\t" + (InventoryList.IndexOf(item) + 1) + " - " + item.Product.ToString());
                });
                Console.WriteLine("Or if you want to exit press 0 and then press ENTER");
                lineEntered = Console.ReadLine();

                int.TryParse(lineEntered, out itemNumberSelected);

                // checks if the selection is valid, if so proceed, otherwise reject it
                if (isValid(itemNumberSelected))
                {
                    var itemSelected = InventoryList.ElementAt(itemNumberSelected - 1);
                    Console.WriteLine("Now add the number of " + itemSelected.Product.Name + "to be added and then press ENTER");

                    lineEntered = Console.ReadLine();
                    int.TryParse(lineEntered, out numOfIems);
                    addItem(new InventoryItem(itemSelected.Product, numOfIems));
                }
                else
                {
                    Console.WriteLine("The selection entered is invalid. Please try again.");
                }
            }
            while (lineEntered != "0");
            Console.WriteLine("Exiting Add Item function...");
        }

        protected void addItem(InventoryItem newItem)
        {
            if (newItem.ProductCount > 0)
            {
                var item = InventoryList.Single(x => x.Product.Name == newItem.Product.Name);
                var newTotal = item.ProductCount + newItem.ProductCount;

                if (totalLimitPerProduct >= newTotal)
                {
                    item.ProductCount = item.ProductCount + newItem.ProductCount;
                    Console.WriteLine("Added the items successfully");
                }
                else
                {
                    Console.WriteLine("The items were not added as it has exceeded the total");
                }
            }
            else
            {
                Console.WriteLine("The number of items added is invalid. Please try again.");
            }

        }

        protected bool isValid(int itemNumberSelected)
        {
            // checks if the selection is valid, if so proceed, otherwise reject it
            if ((itemNumberSelected >= 1) && (itemNumberSelected < InventoryList.Count + 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Removes a given number of items from an existing Product
        /// </summary>
        public void RemoveItem()
        {
            Console.WriteLine("");

            var lineEntered = "";
            int itemNumberSelected = 0;
            int numOfIems = 0;

            do
            {
                Console.WriteLine("Below are the options:");
                Console.WriteLine("1 - Select the item by presing between 1 and " + (InventoryList.Count + 1) + ". Options are: ");
                InventoryList.ForEach(item =>
                {
                    Console.WriteLine("\t" + (InventoryList.IndexOf(item) + 1) + " - " + item.Product.ToString());
                });
                Console.WriteLine("Or if you want to exit press 0 and then press ENTER");
                lineEntered = Console.ReadLine();

                int.TryParse(lineEntered, out itemNumberSelected);

                // checks if the selection is valid, if so proceed, otherwise reject it
                if (isValid(itemNumberSelected))
                {
                    var itemSelected = InventoryList.ElementAt(itemNumberSelected - 1);
                    Console.WriteLine("Now add the number of " + itemSelected.Product.Name + "to be removed and then press ENTER");

                    lineEntered = Console.ReadLine();
                    int.TryParse(lineEntered, out numOfIems);
                    removeItem(new InventoryItem(itemSelected.Product, numOfIems));
                }
                else
                {
                    Console.WriteLine("The selection entered is invalid. Please try again.");
                }
            }
            while (lineEntered != "0");

            Console.WriteLine("Exiting Remove Item function...");
        }

        protected void removeItem(InventoryItem removeitem)
        {
            if (removeitem.ProductCount > 0)
            {
                var item = InventoryList.Single(x => x.Product.Name == removeitem.Product.Name);
                item.ProductCount = item.ProductCount - removeitem.ProductCount;

                Console.WriteLine("Removed the items successfully");
            }
            else
            {
                Console.WriteLine("The number of items removed is invalid. Please try again.");
            }
        }
    }

    /// <summary>
    /// Saves a product and the number of those left in the Vending machine
    /// </summary>
    public class InventoryItem
    {
        public Product Product { get; set; }

        public int ProductCount { get; set; }

        public InventoryItem(Product product, int count)
        {
            Product = product;
            ProductCount = count;
        }
    }
}
