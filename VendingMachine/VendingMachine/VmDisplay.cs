using System.Runtime.InteropServices;

namespace VendingMachine
{
    public class VmDisplay
    {
        private string _displayString;
        private readonly VmCoinValidator _validator;

        public VmDisplay(VmCoinValidator validator)
        {
            _validator = validator;
        }

        private void SetDisplay()
        {
            if (_validator.GetCurrentTransactionTotal() > 0)
            {
                _displayString = _validator.GetCurrentTransactionTotal().ToString();
                _displayString = _displayString.Insert(_displayString.Length -2, ".");
            }
            else
            {
                _displayString = "INSERT COIN";
            }
        }


        public string CheckDisplay()
        {
            SetDisplay();
            return _displayString;
        }
    }
}