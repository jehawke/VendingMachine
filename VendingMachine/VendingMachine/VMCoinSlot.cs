using System;

namespace VendingMachine
{
    public class VmCoinSlot
    {
        private readonly VmCoinValidator _validator = new VmCoinValidator();
        readonly VmCoinReturn _coinReturn = new VmCoinReturn();
        private bool _sendCoinToReturnWasCalled;


        public bool ReceiveCoinAndSendToValidator(string coinToSend)
        {
            if (_validator.ValidateCoin(coinToSend))
            {

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
    }
}
