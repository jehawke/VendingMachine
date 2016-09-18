
namespace VendingMachine
{
    public class VmDisplay
    {
        private const string THANK_YOU = "THANK YOU";
        private const string SOLD_OUT = "SOLD OUT";
        private const string EXACT_CHANGE = "EXACT CHANGE ONLY";
        private const string INSERT_COIN = "INSERT COIN";
        private readonly IConsole _console;


        public VmDisplay(IConsole console)
        {
            _console = console;
        }

        public void ThankYouMessage()
        {
            DisplayMessage(THANK_YOU);
        }

        public void SoldOutMessage()
        {
            DisplayMessage(SOLD_OUT);
        }

        private void DisplayMessage(string message)
        {
            _console.WriteLine("The Display Reads: " + "[" + message + "]");
        }

        public void PriceMessage(int priceOfProduct)
        {
            _console.WriteLine("The Display Reads: " + "[PRICE: " + priceOfProduct + "]");
        }

        public void ExactChangeMessage()
        {
            DisplayMessage(EXACT_CHANGE);
        }

        public void InsertCoinMessage()
        {
            DisplayMessage(INSERT_COIN);
        }

        public void CurrentTotalMessage(int currentTransactionTotal)
        {
            _console.WriteLine("The Display Reads: " + "[" + currentTransactionTotal + "]");
        }
    }
}