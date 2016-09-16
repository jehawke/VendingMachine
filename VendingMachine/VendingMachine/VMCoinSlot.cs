using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class VmCoinSlot
    {
        private readonly VmCoinValidator _validator;
        private readonly VmCoinReturn _coinReturn;
        private bool _sendCoinToReturnWasCalled;
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
            }
            else
            {
                SendCoinToReturn(coinToSend);
            }
            return _validator.ValidateCoin(coinToSend);
        }

        private void SendCoinToReturn(string coinToSend)
        {
            _coinReturn.ReceiveCoin(coinToSend);
            _sendCoinToReturnWasCalled = true;
        }

        public bool GetSendCoinToReturnWasCalled()
        {
            return _sendCoinToReturnWasCalled;
        }

        public List<string> GetCoinsInCurrentTransaction()
        {
            return _listOfCoinsInCurrentTransaction;
        }
    }
}
