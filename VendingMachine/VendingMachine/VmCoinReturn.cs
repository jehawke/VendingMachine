using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class VmCoinReturn
    {
        private readonly List<string> _coinsInReturn = new List<string>();

        public void ReceiveCoin(List<string> rejectedCoin)
        {
            Console.WriteLine("You hear a *clink* as something falls into the coin return.");
            rejectedCoin.ForEach(_coinsInReturn.Add);
        }

        public void RemoveCoinsInReturn()
        {
            _coinsInReturn.Clear();
        }

        public List<string> CheckReturn()
        {
            return _coinsInReturn;
        }
    }
}
