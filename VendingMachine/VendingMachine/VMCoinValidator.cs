using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VmCoinValidator
    {
        private const string QUARTER_STRING = "Quarter" ;
        private const string DIME_STRING = "Dime";
        private const string NICKEL_STRING = "Nickel";

        private const int QUARTER_VALUE = 25;
        private const int DIME_VALUE = 10;
        private const int NICKEL_VALUE = 5;

        public int CurrentTransactionTotal = 0;

        public bool ValidateCoin(string coinToValidate)
        {
            switch (coinToValidate)
            {
                case (QUARTER_STRING):
                    CurrentTransactionTotal += QUARTER_VALUE;
                    return true;
                case (DIME_STRING):
                    CurrentTransactionTotal += DIME_VALUE;
                    return true;
                case (NICKEL_STRING):
                    CurrentTransactionTotal += NICKEL_VALUE;
                    return true;

                default:
                    return false;                    
            }            
        }
    }
}
