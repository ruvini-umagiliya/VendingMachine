using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace VendingMachine_Ruvini
{
    /// <summary>
    /// Handles all the money in the Vending machine
    /// </summary>
    public class Register
    {
        public List<RegisterItem> Cash { get; set; }

        // to make sure that the machine has space to keep each coin
        private int totalLimitPerAcceptedCoin = 50;

        public Register()
        {
            RegisterItem pence5 = new RegisterItem(0.05m, 20);
            RegisterItem pence10 = new RegisterItem(0.10m, 20);
            RegisterItem pence20 = new RegisterItem(0.20m, 20);
            RegisterItem pence50 = new RegisterItem(0.50m, 20);
            RegisterItem pound1 = new RegisterItem(1.00m, 20);
            RegisterItem pound2 = new RegisterItem(2.00m, 10);

            Cash = new List<RegisterItem>() { pence5, pence10, pence20, pence50, pound1, pound2 };
        }

        /// <summary>
        /// Adds more coins from the accpeted coins in the machine
        /// </summary>
        public void AddCash()
        {
            Console.WriteLine("");
            Console.WriteLine("This machine only accepts 5p, 10p, 20p, 50p, £1 and £2 coins!");

            var lineEntered = "";
            decimal currentAdded = 0.0m;
            int numOfCoins = 0;

            do
            {
                Console.WriteLine("Please type 0.05, 0.10, 0.20, 0.50, 1 or 2 coins and press ENTER after each entry, to add more coins to that particular amount");
                Console.WriteLine("Or if you want to exit press 0 and then press ENTER");
                lineEntered = Console.ReadLine();

                Console.WriteLine("Entered: " + lineEntered);
                decimal.TryParse(lineEntered, out currentAdded);

                if (isValid(currentAdded))
                {
                    Console.WriteLine("Now add the number of " + currentAdded.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")) +
                                      " coins to be added and then press ENTER");

                    lineEntered = Console.ReadLine();
                    int.TryParse(lineEntered, out numOfCoins);
                    addCash(new RegisterItem(currentAdded, numOfCoins));
                }
                else if (currentAdded != 0.0m)
                {
                    Console.WriteLine("The amount entered is invalid. Please try again.");
                }
            }
            while (lineEntered != "0");

            Console.WriteLine("Exiting Add Cash function...");
        }

        protected void addCash(RegisterItem cashAmount)
        {
            if (cashAmount.NumOfCoins > 0)
            {
                // add more of the accepted coins, doesn't test if the coin is accepted as it checked before the method gets called
                var amountAdded = Cash.First(c => c.AcceptedCoin == cashAmount.AcceptedCoin);

                var newTotal = amountAdded.NumOfCoins + cashAmount.NumOfCoins;

                // checks if the new total will exceed the limit , if not add it otherwise show the error message to user
                if (newTotal <= totalLimitPerAcceptedCoin)
                {
                    amountAdded.NumOfCoins = amountAdded.NumOfCoins + cashAmount.NumOfCoins;
                    Console.WriteLine("The amount was sucessfully added to the register!");
                }
                else
                {
                    Console.WriteLine("The amount was not added to the register as the number of total coins exceeded the limit!");
                }
            }
            else
            {
                Console.WriteLine("The number of coins added is invalid. Please try again.");
            }
        }

        protected void addCash(List<RegisterItem> cashAmount)
        {
            cashAmount.ForEach(c => addCash(c));
        }

        /// <summary>
        /// Checks if the coin added is valid, if so proceed, otherwise reject it
        /// </summary>
        /// <param name="currentAdded"></param>
        /// <returns></returns>
        protected bool isValid(decimal currentAdded)
        {
            if ((currentAdded != 0.0m) && (coinApproved(currentAdded)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Removes a given number of coins from the accepted coins in the machine
        /// </summary>
        public void RemoveCash()
        {
            Console.WriteLine("");
            Console.WriteLine("This machine only accepts 5p, 10p, 20p, 50p, £1 and £2 coins!");

            var lineEntered = "";
            decimal currentAdded = 0.0m;
            int numOfCoins = 0;

            do
            {
                Console.WriteLine("Please type 0.05, 0.10, 0.20, 0.50, 1 or 2 coins and press ENTER after each entry, to add more coins to that particular amount");
                Console.WriteLine("Or if you want to exit press 0 and then press ENTER");
                lineEntered = Console.ReadLine();

                Console.WriteLine("Entered: " + lineEntered);
                decimal.TryParse(lineEntered, out currentAdded);

                // checks if the coin added is valid, if so proceed, otherwise reject it
                if (isValid(currentAdded))
                {
                    Console.WriteLine("Now add the number of " + currentAdded.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")) +
                                      " coins to be removed and then press ENTER");

                    lineEntered = Console.ReadLine();
                    int.TryParse(lineEntered, out numOfCoins);
                    removeCash(new RegisterItem(currentAdded, numOfCoins));
                }
                else if (currentAdded != 0.0m)
                {
                    Console.WriteLine("The amount entered is invalid. Please try again.");
                }
            }
            while (lineEntered != "0");

            Console.WriteLine("Exiting Remove Cash function...");
        }

        protected void removeCash(RegisterItem cashAmount)
        {
            if (cashAmount.NumOfCoins > 0)
            {
                // remove the amount
                var amountRemoved = Cash.First(c => c.AcceptedCoin == cashAmount.AcceptedCoin);
                amountRemoved.NumOfCoins = amountRemoved.NumOfCoins - cashAmount.NumOfCoins;

                Console.WriteLine("The amount was sucessfully removed from the register!");
            }
            else
            {
                Console.WriteLine("The number of coins to be removed is invalid. Please try again.");
            }
        }

        protected void removeCash(List<RegisterItem> cashAmount)
        {
            cashAmount.ForEach(c => removeCash(c));
        }

        public void HandleMoneyAndProductFromUser(InventoryItem itemSelected, Register wallet)
        {
            Console.WriteLine("Please pay with 5p, 10p 20p, 50p, £1 or £2 coins.");
            Console.WriteLine("Please type 0.05, 0.10, 0.20, 0.50, 1 or 2 coins and press ENTER after each entry");
            decimal totalAdded = 0.0m;
            decimal currentAdded = 0.0m;

            var lineEntered = "";
            do
            {
                lineEntered = Console.ReadLine();

                Console.WriteLine("Added: " + lineEntered);
                decimal.TryParse(lineEntered, out currentAdded);

                // checks if the coin added is valid, if so proceed, otherwise reject it
                if (isValid(currentAdded))
                {
                    totalAdded = totalAdded + currentAdded;

                    // add the given value to the register
                    addCash(new RegisterItem(currentAdded, 1));

                    var change = Decimal.Subtract(itemSelected.Product.Price, totalAdded);
                    Console.WriteLine("You've added " + totalAdded.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")) + ". Remaining " + change.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")));
                }
                else
                {
                    Console.WriteLine("The added coin " + lineEntered + " was rejected as its not valid");
                }
            }
            // loops until the user has added the price of the product or more than the price of the product
            while (!(Decimal.ToOACurrency(totalAdded) >= Decimal.ToOACurrency(itemSelected.Product.Price)));

            // the user needs to be given change
            if (userNeedsChange(totalAdded, itemSelected.Product.Price))
            {
                // give change
                var changeToBeGiven = calculateChange(totalAdded, itemSelected.Product.Price);

                var changeAmount = Decimal.Subtract(totalAdded, itemSelected.Product.Price);
                Console.WriteLine("Your change amount is: " + changeAmount.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")));
                Console.WriteLine("You've been given the change below:");
                changeToBeGiven.ForEach(c =>
                {
                    Console.WriteLine(c.ToString());
                });
            }

            Console.WriteLine("Your product has been dispensed. Please check the dispenser");
            Console.WriteLine("Thank you!");
        }

        /// <summary>
        /// Returns if the user needs change or not
        /// </summary>
        /// <param name="totalAdded"></param>
        /// <param name="productPrice"></param>
        /// <returns></returns>
        protected bool userNeedsChange(decimal totalAdded, decimal productPrice)
        {
            // the user needs to be given change
            if (Decimal.ToOACurrency(totalAdded) > Decimal.ToOACurrency(productPrice))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns if a coin is approved or not to be used in the vending machine
        /// </summary>
        /// <param name="coin"></param>
        /// <returns></returns>
        protected bool coinApproved(decimal coin)
        {
            // get the wallet and see if the coin is in the wallet, since only the accepted coins will in the wallet
            if (Cash.Exists(i => i.AcceptedCoin == coin))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Calculates and returns the amount of change that should be given to a user
        /// </summary>
        /// <param name="totalAdded"></param>
        /// <param name="productPrice"></param>
        /// <returns></returns>
        protected List<RegisterItem> calculateChange(decimal totalAdded, decimal productPrice)
        {
            List<RegisterItem> change = new List<RegisterItem>();

            var changeAmount = Decimal.Subtract(totalAdded, productPrice);

            // goes through each accepted coin and builds the change. It goes in the descenfing order to make sure that the bigger coins are checked first 
            foreach (var coin in Cash.OrderByDescending(c => c.AcceptedCoin))
            {
                // checks if the change amount is more than zero, if zero stops the loop and returns the Change list
                if (changeAmount > 0)
                {
                    var coinsRequired = (int)(changeAmount / coin.AcceptedCoin);

                    if (coin.AcceptedCoin <= changeAmount && coin.NumOfCoins >= coinsRequired)
                    {
                        change.Add(new RegisterItem(coin.AcceptedCoin, coinsRequired));

                        // update the amount
                        changeAmount = changeAmount - (coinsRequired * coin.AcceptedCoin);
                    }
                }
                else
                {
                    break;
                }
            }

            // if the change amount is still not zero that means that the item's price is not a divisable of 5p and therefore cannot be given
            if (changeAmount > 0)
            {
                Console.WriteLine("The machine can only provide change to the nearest 5p and therefore you will not get "
                                   + changeAmount.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")));
            }

            // substract the given change from the register
            removeCash(change);

            return change;
        }
    }

    public class RegisterItem
    {
        public decimal AcceptedCoin { get; set; }

        public int NumOfCoins { get; set; }

        public RegisterItem(decimal value, int numOfCoins)
        {
            AcceptedCoin = value;
            NumOfCoins = numOfCoins;
        }

        public override string ToString()
        {
            string value = string.Format("{0} - {1}", AcceptedCoin.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")), NumOfCoins);
            return value;
        }
    }
}
