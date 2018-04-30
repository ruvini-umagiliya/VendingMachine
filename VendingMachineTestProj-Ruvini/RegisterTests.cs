using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using VendingMachine_Ruvini;

namespace VendingMachineTestProj_Ruvini
{
    [TestFixture]
    public class RegisterTests : Register
    {
        [Test]
        public void IsValidTest()
        {
            var result1 = isValid(0.05m);
            Assert.AreEqual(true, result1);

            var result2 = isValid(1.02m);
            Assert.AreEqual(false, result2);

            var result3 = isValid(0.00m);
            Assert.AreEqual(false, result3);
        }


        [Test]
        public void AddCashTestAddSuccesfully()
        {
            // adds successfully
            RegisterItem item = new RegisterItem(0.05m, 10);
            var numberBeforeAddingCash = Cash.First(c => c.AcceptedCoin == 0.05m).NumOfCoins;
            addCash(item);
            Assert.AreEqual((numberBeforeAddingCash + 10), Cash.First(c => c.AcceptedCoin == 0.05m).NumOfCoins);
        }

        [Test]
        public void AddCashTestAddUnSuccesful()
        {
            // unsuccessful as the coins amount entered is not accepted
            RegisterItem item = new RegisterItem(0.05m, 0);
            var numberBeforeAddingCash = Cash.First(c => c.AcceptedCoin == 0.05m).NumOfCoins;
            addCash(item);
            Assert.AreEqual((numberBeforeAddingCash), Cash.First(c => c.AcceptedCoin == 0.05m).NumOfCoins);
        }

        [Test]
        public void AddCashTestListAddSuccesfully()
        {
            // adds successfully
            RegisterItem item = new RegisterItem(0.05m, 10);
            RegisterItem item2 = new RegisterItem(0.10m, 10);

            var numberBeforeAddingCashItem = Cash.First(c => c.AcceptedCoin == 0.05m).NumOfCoins;
            var numberBeforeAddingCashItem2 = Cash.First(c => c.AcceptedCoin == 0.10m).NumOfCoins;
            addCash(new List<RegisterItem>() { item, item2 });

            Assert.AreEqual((numberBeforeAddingCashItem + 10), Cash.First(c => c.AcceptedCoin == 0.05m).NumOfCoins);
            Assert.AreEqual((numberBeforeAddingCashItem2 + 10), Cash.First(c => c.AcceptedCoin == 0.10m).NumOfCoins);
        }

        [Test]
        public void AddCashTestListAddUnSuccesful()
        {
            // unsuccessful as the coins amount entered is not accepted
            RegisterItem item = new RegisterItem(0.05m, 0);
            RegisterItem item2 = new RegisterItem(0.10m, 0);

            var numberBeforeAddingCashItem = Cash.First(c => c.AcceptedCoin == 0.05m).NumOfCoins;
            var numberBeforeAddingCashItem2 = Cash.First(c => c.AcceptedCoin == 0.10m).NumOfCoins;
            addCash(new List<RegisterItem>() { item, item2 });

            Assert.AreEqual((numberBeforeAddingCashItem), Cash.First(c => c.AcceptedCoin == 0.05m).NumOfCoins);
            Assert.AreEqual((numberBeforeAddingCashItem2), Cash.First(c => c.AcceptedCoin == 0.10m).NumOfCoins);
        }

        [Test]
        public void AddCashTestListAddHalfSuccesful()
        {
            // unsuccessful as the coins amount entered is not accepted
            RegisterItem item = new RegisterItem(0.05m, 0);
            // successful
            RegisterItem item2 = new RegisterItem(0.10m, 5);

            var numberBeforeAddingCashItem = Cash.First(c => c.AcceptedCoin == 0.05m).NumOfCoins;
            var numberBeforeAddingCashItem2 = Cash.First(c => c.AcceptedCoin == 0.10m).NumOfCoins;
            addCash(new List<RegisterItem>() { item, item2 });

            Assert.AreEqual((numberBeforeAddingCashItem), Cash.First(c => c.AcceptedCoin == 0.05m).NumOfCoins);
            Assert.AreEqual((numberBeforeAddingCashItem2 + 5), Cash.First(c => c.AcceptedCoin == 0.10m).NumOfCoins);
        }


        [Test]
        public void RemoveCashTestRemoveSuccesfully()
        {
            // remove successfully
            RegisterItem item = new RegisterItem(0.05m, 10);
            var numberBeforeRemovingCash = Cash.First(c => c.AcceptedCoin == 0.05m).NumOfCoins;
            removeCash(item);
            Assert.AreEqual((numberBeforeRemovingCash - 10), Cash.First(c => c.AcceptedCoin == 0.05m).NumOfCoins);
        }

        [Test]
        public void RemoveCashTestRemoveUnSuccesful()
        {
            // unsuccessful as the coin value entered is not accepted
            RegisterItem item = new RegisterItem(0.05m, 0);
            var numberBeforeAddingCash = Cash.First(c => c.AcceptedCoin == 0.05m).NumOfCoins;
            removeCash(item);
            Assert.AreEqual((numberBeforeAddingCash), Cash.First(c => c.AcceptedCoin == 0.05m).NumOfCoins);
        }

        [Test]
        public void RemoveCashTestListRemoveSuccesfully()
        {
            // remove successfully
            RegisterItem item = new RegisterItem(0.05m, 10);
            RegisterItem item2 = new RegisterItem(0.10m, 10);

            var numberBeforeRemovingCashItem = Cash.First(c => c.AcceptedCoin == 0.05m).NumOfCoins;
            var numberBeforeRemovingCashItem2 = Cash.First(c => c.AcceptedCoin == 0.10m).NumOfCoins;
            removeCash(new List<RegisterItem>() { item, item2 });

            Assert.AreEqual((numberBeforeRemovingCashItem - 10), Cash.First(c => c.AcceptedCoin == 0.05m).NumOfCoins);
            Assert.AreEqual((numberBeforeRemovingCashItem2 - 10), Cash.First(c => c.AcceptedCoin == 0.10m).NumOfCoins);
        }

        [Test]
        public void RemoveCashTestListRemoveUnSuccesful()
        {
            // unsuccessful as the coins amount entered is not accepted
            RegisterItem item = new RegisterItem(0.05m, 0);
            RegisterItem item2 = new RegisterItem(0.10m, 0);

            var numberBeforeRemovingCashItem = Cash.First(c => c.AcceptedCoin == 0.05m).NumOfCoins;
            var numberBeforeRemovingCashItem2 = Cash.First(c => c.AcceptedCoin == 0.10m).NumOfCoins;
            removeCash(new List<RegisterItem>() { item, item2 });

            Assert.AreEqual((numberBeforeRemovingCashItem), Cash.First(c => c.AcceptedCoin == 0.05m).NumOfCoins);
            Assert.AreEqual((numberBeforeRemovingCashItem2), Cash.First(c => c.AcceptedCoin == 0.10m).NumOfCoins);
        }

        [Test]
        public void RemoveCashTestListRemoveHalfSuccesful()
        {
            // unsuccessful as the coins amount entered is not accepted
            RegisterItem item = new RegisterItem(0.05m, 0);
            // successful
            RegisterItem item2 = new RegisterItem(0.10m, 5);

            var numberBeforeRemovingCashItem = Cash.First(c => c.AcceptedCoin == 0.05m).NumOfCoins;
            var numberBeforeRemovingCashItem2 = Cash.First(c => c.AcceptedCoin == 0.10m).NumOfCoins;
            removeCash(new List<RegisterItem>() { item, item2 });

            Assert.AreEqual((numberBeforeRemovingCashItem), Cash.First(c => c.AcceptedCoin == 0.05m).NumOfCoins);
            Assert.AreEqual((numberBeforeRemovingCashItem2 - 5), Cash.First(c => c.AcceptedCoin == 0.10m).NumOfCoins);
        }

        [Test]
        public void userNeedsChangeTest()
        {
            var result = userNeedsChange(2, 1.50m);
            Assert.AreEqual(true, result);

            var result1 = userNeedsChange(1.50m, 1.50m);
            Assert.AreEqual(false, result1);

            var result2 = userNeedsChange(1.40m, 1.50m);
            Assert.AreEqual(false, result2);
        }

        [Test]
        public void coinApprovedTest()
        {
            var result = coinApproved(1);
            Assert.AreEqual(true, result);

            var result1 = coinApproved(0.50m);
            Assert.AreEqual(true, result1);

            var result2 = coinApproved(1.50m);
            Assert.AreEqual(false, result2);

            var result3 = coinApproved(0.00m);
            Assert.AreEqual(false, result3);
        }

        [Test]
        public void calculateChangeTest()
        {
            var numberBeforeRemovingCashItem = Cash.First(c => c.AcceptedCoin == 0.50m).NumOfCoins;

            var result = calculateChange(2, 1.50m);

            Assert.AreEqual(0.50m, result.First().AcceptedCoin);
            Assert.AreEqual(1, result.First().NumOfCoins);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual((numberBeforeRemovingCashItem - 1), Cash.First(c => c.AcceptedCoin == 0.50m).NumOfCoins);
        }

        [Test]
        public void calculateChangeTest2()
        {
            var numberBeforeRemovingCashItem = Cash.First(c => c.AcceptedCoin == 0.05m).NumOfCoins;
            var numberBeforeRemovingCashItem2 = Cash.First(c => c.AcceptedCoin == 0.20m).NumOfCoins;

            var result = calculateChange(1, 0.75m);

            Assert.AreEqual(0.20m, result[0].AcceptedCoin);
            Assert.AreEqual(1, result[0].NumOfCoins);
            Assert.AreEqual(0.05m, result[1].AcceptedCoin);
            Assert.AreEqual(1, result[1].NumOfCoins);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual((numberBeforeRemovingCashItem - 1), Cash.First(c => c.AcceptedCoin == 0.05m).NumOfCoins);
            Assert.AreEqual((numberBeforeRemovingCashItem2 - 1), Cash.First(c => c.AcceptedCoin == 0.20m).NumOfCoins);
        }

        [Test]
        public void calculateChangeTest3()
        {
            var numberBeforeRemovingCashItem = Cash.First(c => c.AcceptedCoin == 0.50m).NumOfCoins;

            // remove all the 50p coins
            removeCash(new RegisterItem(0.50m, numberBeforeRemovingCashItem));

            var result = calculateChange(2, 1.50m);

            Assert.AreEqual(0.20m, result[0].AcceptedCoin);
            Assert.AreEqual(2, result[0].NumOfCoins);
            Assert.AreEqual(0.10m, result[1].AcceptedCoin);
            Assert.AreEqual(1, result[1].NumOfCoins);
            Assert.AreEqual(2, result.Count);
        }
    }
}
