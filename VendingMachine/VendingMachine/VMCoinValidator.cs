using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VMCoinValidator
    {
        const string QUARTER_STRING = "Quarter" ;
        const string DIME_STRING = "Dime";
        const string NICKEL_STRING = "Nickel";

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
