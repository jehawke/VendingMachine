using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VmCoinReturn
    {
        public List<string> CoinsInReturn = new List<string>();

        public void ReceiveCoin(string rejectedCoin)
        {
            CoinsInReturn.Add(rejectedCoin);
        }

        public void RemoveCoinsInReturn()
        {
            CoinsInReturn.Clear();
        }
    }
}
