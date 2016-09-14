using System.Collections.Generic;

namespace VendingMachine
{
    public class VmCoinReturn
    {
        private readonly List<string> _coinsInReturn = new List<string>();

        public void ReceiveCoin(string rejectedCoin)
        {
            _coinsInReturn.Add(rejectedCoin);
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
