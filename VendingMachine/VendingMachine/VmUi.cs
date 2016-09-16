using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VmUi
    {
        private bool _showMainUiWasCalled;
        private bool _showInsertCoinUiWasCalled;
        private bool _showDisplayUiWasShown;
        private bool _showCoinReturnUiWasCalled;
        private bool _showFoodSlotUiWasCalled;

        private readonly VmCoinReturn _coinReturn = new VmCoinReturn();
        private readonly VmFoodSlot _foodSlot = new VmFoodSlot();

        public VmUi()
        {
            _showMainUiWasCalled = false;
            _showInsertCoinUiWasCalled = false;
            _showDisplayUiWasShown = false;
            _showCoinReturnUiWasCalled = false;
            _showFoodSlotUiWasCalled = false;
        }

        public void ShowMainUi()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("______________________VENDING MACHINE_______________________");
            Console.WriteLine("| (I) Insert Coin                               (R) Refund |");
            Console.WriteLine("|                                                          |");
            Console.WriteLine("| (S) Soda: 1.00       (H) Chips: .50       (C) Candy: .65 |");
            Console.WriteLine("|                                                          |");
            Console.WriteLine("| (T) Take Item (" + _foodSlot.GetListOfItemsInSlot().Count + " items)        (N) Coin Return (" + _coinReturn.CheckReturn().Count + " items) |");
            Console.WriteLine("____________________________________________________________");
            Console.WriteLine("");
            Console.WriteLine("Enter the letter of the item you wish to access");
            Console.WriteLine("-OR-");
            Console.WriteLine("Enter 'D' at any time to check the display.");

            _showMainUiWasCalled = true;
        }

        public void ShowInsertCoinUi()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("You rummage through your pockets looking for a ");
            Console.WriteLine("(Q)uarter" + ", " + "(N)ickel" + ", or " + "(D)ime");
            Console.WriteLine("");
            Console.WriteLine("The Display reads: " + "SOMETHING");
            Console.WriteLine("What will you insert in the coin slot?");

            _showInsertCoinUiWasCalled = true;
        }

        public void ShowCoinReturnUi()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("You flip open the coin return.");
            if (_coinReturn.CheckReturn().Count == 0)
            {
                Console.WriteLine("It's empty.");
                Console.WriteLine("Press any key to return to the machine...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("It contains:");
                Console.WriteLine(_coinReturn.CheckReturn());
                Console.WriteLine("Will you (E)mpty the coin return or (R)eturn to the machine?");
            }

            _showCoinReturnUiWasCalled = true;
        }


        public void ShowFoodSlotUi()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("You look inside the food slot.");
            if (_foodSlot.GetListOfItemsInSlot().Count == 0)
            {
                Console.WriteLine("It's empty.");
                Console.WriteLine("Press any key to return to the machine...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("It contains:");
                Console.WriteLine(_foodSlot.GetListOfItemsInSlot());
                Console.WriteLine("Will you (T)ake your food, or (R)eturn to the machine?");
            }

            _showFoodSlotUiWasCalled = true;
        }

        public void ShowDisplayUi()
        {
            Console.WriteLine("");
            Console.WriteLine("The Display Reads: " + "[" + "INSERT COIN" + " " + "0.00" + "]");

            _showDisplayUiWasShown = true;
        }
        
        public bool GetMainUiWasShown()
        {
            return _showMainUiWasCalled;
        }

        public bool GetInsertCoinUiWasShown()
        {
            return _showInsertCoinUiWasCalled;
        }

        public bool GetCoinReturnUiWasShown()
        {
            return _showCoinReturnUiWasCalled;
        }

        public bool GetFoodSlotUiWasShown()
        {
            return _showFoodSlotUiWasCalled;
        }

        public bool GetDisplayUiWasShown()
        {
            return _showDisplayUiWasShown;
        }
    }
}
