using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class VmCoinSlot
    {
        private readonly VmCoinValidator _validator;
        private readonly VmCoinReturn _coinReturn;
        private int _timesSendCoinToReturnWasCalled;
        private readonly List<string> _listOfCoinsInCurrentTransaction;

        public VmCoinSlot(List<string> listOfCoinsInCurrentTransaction, VmCoinReturn coinReturn, VmCoinValidator validator)
        {
            _listOfCoinsInCurrentTransaction = listOfCoinsInCurrentTransaction;
            _coinReturn = coinReturn;
            _validator = validator;
        }

        public bool ReceiveCoinAndSendToValidator(string coinToSend)
        {
            if (_validator.ValidateCoin(coinToSend))
            {
                _listOfCoinsInCurrentTransaction.Add(coinToSend);
                return true;
            }
                SendCoinToReturn(coinToSend);
                return false;
        }

        private void SendCoinToReturn(string coinToSend)
        {
            _coinReturn.ReceiveCoin(new List<string> {coinToSend});
            _timesSendCoinToReturnWasCalled ++;
        }

        public int GetTimesSendCoinToReturnWasCalled()
        {
            return _timesSendCoinToReturnWasCalled;
        }

        public List<string> GetCoinsInCurrentTransaction()
        {
            return _listOfCoinsInCurrentTransaction;
        }

        public void GiveRefund()
        {
            _listOfCoinsInCurrentTransaction.ForEach(SendCoinToReturn);
            _listOfCoinsInCurrentTransaction.Clear();
            _validator.CompleteTransaction();
        }
    }
}
