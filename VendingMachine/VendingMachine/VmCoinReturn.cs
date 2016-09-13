using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VmCoinReturn
    {
        public List<string> coinsInReturn = new List<string>();

        public void ReceiveCoin(string rejectedCoin)
        {
            coinsInReturn.Add(rejectedCoin);
        }

        public void RemoveCoinsInReturn()
        {
            coinsInReturn.Clear();
        }
    }
}
