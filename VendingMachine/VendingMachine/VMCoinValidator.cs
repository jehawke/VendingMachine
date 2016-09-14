
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

        private int _currentTransactionTotal = 0;

        public bool ValidateCoin(string coinToValidate)
        {
            switch (coinToValidate)
            {
                case (QUARTER_STRING):
                    _currentTransactionTotal += QUARTER_VALUE;
                    return true;
                case (DIME_STRING):
                    _currentTransactionTotal += DIME_VALUE;
                    return true;
                case (NICKEL_STRING):
                    _currentTransactionTotal += NICKEL_VALUE;
                    return true;

                default:
                    return false;                    
            }            
        }

        public int GetCurrentTransactionTotal()
        {
            return _currentTransactionTotal;
        }
    }
}
