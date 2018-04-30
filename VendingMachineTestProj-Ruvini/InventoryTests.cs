using NUnit.Framework;
using System.Linq;
using VendingMachine_Ruvini;

namespace VendingMachineTestProj_Ruvini
{
    [TestFixture]
    public class InventoryTests : Inventory
    {
        [Test]
        public void AddItemTestAddSuccesfully()
        {
            // adds successfully
            InventoryItem item = new InventoryItem(new Product("Pepsi", 1.50m), 2);
            var numberBeforeAddingItem = InventoryList.First(c => c.Product.Name == "Pepsi").ProductCount;

            addItem(item);

            Assert.AreEqual((numberBeforeAddingItem + 2), InventoryList.First(c => c.Product.Name == "Pepsi").ProductCount);
        }

        [Test]
        public void AddItemTestAddUnsuccesfull()
        {
            // adds successfully
            InventoryItem item = new InventoryItem(new Product("Pepsi", 1.50m), 0);
            var numberBeforeAddingItem = InventoryList.First(c => c.Product.Name == "Pepsi").ProductCount;

            addItem(item);

            Assert.AreEqual((numberBeforeAddingItem), InventoryList.First(c => c.Product.Name == "Pepsi").ProductCount);
        }

        [Test]
        public void AddItemTestAddUnsuccesfull2()
        {
            // adds successfully
            InventoryItem item = new InventoryItem(new Product("Pepsi", 1.50m), 6);
            var numberBeforeAddingItem = InventoryList.First(c => c.Product.Name == "Pepsi").ProductCount;

            addItem(item);

            Assert.AreEqual((numberBeforeAddingItem), InventoryList.First(c => c.Product.Name == "Pepsi").ProductCount);
        }

        [Test]
        public void IsValidTest()
        {
            var result1 = isValid(1);
            Assert.AreEqual(true, result1);

            var result2 = isValid(6);
            Assert.AreEqual(false, result2);

            var result3 = isValid(0);
            Assert.AreEqual(false, result3);
        }

        [Test]
        public void RemoveItemTestAddSuccesfully()
        {
            // adds successfully
            InventoryItem item = new InventoryItem(new Product("Pepsi", 1.50m), 2);
            var numberBeforeRemovingItem = InventoryList.First(c => c.Product.Name == "Pepsi").ProductCount;

            removeItem(item);

            Assert.AreEqual((numberBeforeRemovingItem - 2), InventoryList.First(c => c.Product.Name == "Pepsi").ProductCount);
        }

        [Test]
        public void RemoveItemTestAddUnSuccesfull()
        {
            // adds successfully
            InventoryItem item = new InventoryItem(new Product("Pepsi", 1.50m), 0);
            var numberBeforeRemovingItem = InventoryList.First(c => c.Product.Name == "Pepsi").ProductCount;

            removeItem(item);

            Assert.AreEqual((numberBeforeRemovingItem), InventoryList.First(c => c.Product.Name == "Pepsi").ProductCount);
        }
    }
}
