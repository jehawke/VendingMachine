using System;
using System.Runtime.InteropServices;

namespace VendingMachine
{
    public class VmDisplay
    {
        private const string THANK_YOU = "THANK YOU";
        private readonly IConsole _console;
        private string _displayString;
        private readonly VmCoinValidator _validator;

        public VmDisplay(VmCoinValidator validator, IConsole console)
        {
            _validator = validator;
            _console = console;
        }


        /*        private void SetDisplay()
                {
                    if (_validator.GetCurrentTransactionTotal() > 0)
                    {
                        _validator.GetCurrentTransactionTotal()
                        _displayString = _validator.GetCurrentTransactionTotal().ToString();
                        _displayString = _displayString.Insert(_displayString.Length -2, ".");
                    }
                    else
                    {
                        _displayString = "INSERT COIN";
                    }
                }*/

        public void ThankYouMessage()
        {
            DisplayMessage(THANK_YOU);
        }

        private void DisplayMessage(string message)
        {
            _console.WriteLine("The Display Reads: " + "[" + message + "]");
        }

/*        public string CheckDisplay()
        {
            SetDisplay();
            return _displayString;
        }*/
    }
}