
namespace VendingMachine
{
    public class VmCoinValidator
    {
        private const string QUARTER_STRING = "Q" ;
        private const string DIME_STRING = "D";
        private const string NICKEL_STRING = "N";

        private const int QUARTER_VALUE = 25;
        private const int DIME_VALUE = 10;
        private const int NICKEL_VALUE = 5;

        private int _currentTransactionTotal;

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

        public string GetQuarterDefinition()
        {
            return QUARTER_STRING;
        }
        public string GetNickelDefinition()
        {
            return NICKEL_STRING;
        }
        public string GetDimeDefinition()
        {
            return DIME_STRING;
        }
    }
}
