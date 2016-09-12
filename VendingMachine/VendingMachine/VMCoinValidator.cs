using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VMCoinValidator
    {
        private const string QUARTER_STRING = "Quarter" ;
        private const string DIME_STRING = "Dime";
        private const string NICKEL_STRING = "Nickel";

        public bool ValidateCoin(string coinToValidate)
        {
            switch (coinToValidate)
            {
                case (QUARTER_STRING):
                    return true;
                case (DIME_STRING):
                    return true;
                case (NICKEL_STRING):
                    return true;

                default:
                    return false;                    
            }            
        }
    }
}
