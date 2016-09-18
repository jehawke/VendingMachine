using System.Collections.Generic;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            StartMachine();
        }

        private static void StartMachine()
        {
            IConsole console = new VmGetInput();
            VmCoinValidator coinValidator = new VmCoinValidator();
            VmCoinReturn coinReturn = new VmCoinReturn();
            VmCoinSlot coinSlot = new VmCoinSlot(new List<string>(), coinReturn, coinValidator);
            VmFoodDispenser foodDispenser = new VmFoodDispenser();
            VmFoodSlot foodSlot = new VmFoodSlot();
            VmCoinBank coinBank = new VmCoinBank(new List<string>(),coinValidator, coinSlot, coinReturn);
            VmDisplay display = new VmDisplay(console);
            VmUi mainUi = new VmUi(coinSlot, coinValidator, coinReturn, foodDispenser, foodSlot, coinBank, console, display);
            coinBank.Restock();
            foodDispenser.Restock();
            mainUi.ShowMainUi();
        }
    }
}
