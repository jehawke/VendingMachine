using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            VmCoinValidator coinValidator = new VmCoinValidator();
            VmCoinReturn coinReturn = new VmCoinReturn();
            VmCoinSlot coinSlot = new VmCoinSlot(new List<string>(), coinReturn, coinValidator);
            VmFoodDispenser foodDispenser = new VmFoodDispenser();
            VmFoodSlot foodSlot = new VmFoodSlot();
            VmCoinBank coinBank = new VmCoinBank(new List<string>(),coinValidator);
            IConsole console = new VmGetInput();
            VmUi mainUi = new VmUi(coinSlot, coinValidator, coinReturn, foodDispenser, foodSlot, coinBank, console);
            foodDispenser.Restock();
            mainUi.ShowMainUi();
        }
    }
}
