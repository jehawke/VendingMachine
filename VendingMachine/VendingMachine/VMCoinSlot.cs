using System;

namespace VendingMachine
{
    public class VmCoinSlot
    {
        private readonly VmCoinValidator _validator = new VmCoinValidator();

        public bool ReceiveCoinAndSendToValidator(string coinToSend)
        {
            return _validator.ValidateCoin(coinToSend);
        }

    }
}
