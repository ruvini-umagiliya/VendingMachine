using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_Ruvini
{
    public class Wallet
    {
        public List<WalletItem> Cash { get; set; }

        public Wallet()
        {
            WalletItem pence5 = new WalletItem(0.05m, 20);
            WalletItem pence10 = new WalletItem(0.10m, 20);
            WalletItem pence20 = new WalletItem(0.20m, 20);
            WalletItem pence50 = new WalletItem(0.50m, 20);
            WalletItem pound1 = new WalletItem(1.00m, 20);
            WalletItem pound2 = new WalletItem(2.00m, 10);

            Cash = new List<WalletItem>() { pence5, pence10, pence20, pence50, pound1,, pound2 };
        }

        public void AddCash(WalletItem cashAmount)
        {
            // add more of the accepted coins
        }

        public void RemoveCash(WalletItem cashAmount)
        {
            // remove the amount
        }

        public void RemoveAllCash()
        {
            // remove all the cash
        }

        /// <summary>
        /// Returns if a coin is approved or not to be used in the vending machine
        /// </summary>
        /// <param name="coin"></param>
        /// <returns></returns>
        public bool CoinApproved(double coin)
        {
            bool approved = false;

            // get the wallet and see if the coin is in the wallet, since only the accepted coins will in the wallet
            if (Cash.Exists(i => i.AcceptedCoin == coin))
            {
                approved = true;
            }

            return approved;
        }
    }

    public class WalletItem
    {
        public decimal AcceptedCoin { get; set; }

        public int NumOfCoins { get; set; }

        public WalletItem(decimal value, int numOfCoins)
        {
            AcceptedCoin = value;
            NumOfCoins = numOfCoins;
        }
    }
}
