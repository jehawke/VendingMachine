using System;

namespace VendingMachine
{
    public class VmUi
    {
        private bool _showMainUiWasCalled;
        private bool _showInsertCoinUiWasCalled;
        private bool _showDisplayUiWasShown;
        private bool _showCoinReturnUiWasCalled;
        private bool _showFoodSlotUiWasCalled;

        private readonly VmCoinSlot _coinSlot;
        private readonly VmCoinValidator _coinValidator;
        private readonly VmCoinReturn _coinReturn;
        private readonly VmFoodDispenser _foodDispenser;
        private readonly VmFoodSlot _foodSlot;
        private readonly VmCoinBank _coinBank;
        private readonly IConsole _console;
        private readonly VmDisplay _display;
        private string _entry;

        public VmUi(VmCoinSlot coinSlot, VmCoinValidator coinValidator, VmCoinReturn coinReturn, VmFoodDispenser foodDispenser, VmFoodSlot foodSlot, VmCoinBank coinBank, IConsole console, VmDisplay display)
        {
            _coinSlot = coinSlot;
            _coinValidator = coinValidator;
            _coinReturn = coinReturn;
            _foodDispenser = foodDispenser;
            _foodSlot = foodSlot;
            _coinBank = coinBank;
            _console = console;
            _display = display;

            _showMainUiWasCalled = false;
            _showInsertCoinUiWasCalled = false;
            _showDisplayUiWasShown = false;
            _showCoinReturnUiWasCalled = false;
            _showFoodSlotUiWasCalled = false;
        }

        public void ShowMainUi()
        {
            Console.Clear();
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

            _display.InsertCoinMessage();

            Console.WriteLine("Enter the letter of the item you wish to access");
            Console.WriteLine("-OR-");
            Console.WriteLine("Enter 'Display' at any time to check the display, or 'E' to Exit.");

            _showMainUiWasCalled = true;
            _entry = _console.ReadLine();

            switch (_entry)
            {
                case ("I"):
                    ShowInsertCoinUi();
                    break;
                case ("R"):
                    _coinSlot.GiveRefund();
                    ShowCoinReturnUi();
                    break;
                case ("S"):
                case ("H"):
                case ("C"):
                    if (_foodDispenser.Dispense(_entry, _coinValidator, _coinBank, _foodSlot, _display))
                    {
                        Console.WriteLine("You hear a *thunk* as an item lands in the Food Slot.");
                        ShowFoodSlotUi();
                    }
                    else
                    {
                        Console.WriteLine("Nothing happens.");
                        ShowDisplayUi();
                    }
                    break;
                case ("T"):
                    ShowFoodSlotUi();
                    break;
                case ("N"):
                    ShowCoinReturnUi();
                    break;
                case ("DISPLAY"):
                    ShowDisplayUi();
                    break;
                case ("E"):
                    break;
                default:
                    InvalidInput();
                    break;
            }

        }

        public void ShowInsertCoinUi()
        {
            Console.WriteLine("");
            Console.WriteLine("");

            _display.CurrentTotalMessage(_coinValidator.GetCurrentTransactionTotal());

            Console.WriteLine("");
            Console.WriteLine("You rummage through your pockets looking for a ");
            Console.WriteLine("(Q)uarter" + ", " + "(N)ickel" + ", or " + "(D)ime");
            Console.WriteLine("");
            Console.WriteLine("What will you insert in the coin slot?");

            _showInsertCoinUiWasCalled = true;

            _entry = _console.ReadLine();
            if (_entry == "DISPLAY")
            {
                ShowDisplayUi();
            }
            else
            {
                _coinSlot.ReceiveCoinAndSendToValidator(_entry);
                ShowInsertMoreCoinsUi();
            }
        }

        public void ShowInsertMoreCoinsUi()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            
            _display.CurrentTotalMessage(_coinValidator.GetCurrentTransactionTotal());

            Console.WriteLine("Will you insert more coins? (Y/N)");

            _showInsertCoinUiWasCalled = true;
            _entry = _console.ReadLine();
            switch (_entry)
            {
                case ("Y"):
                    ShowInsertCoinUi();
                    break;
                case ("N"):
                    ShowMainUi();
                    break;
                case ("DISPLAY"):
                    ShowDisplayUi();
                    break;
                case ("E"):
                    break;
                default:
                    InvalidInput();
                    break;
            }
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
                _console.ReadLine();
                ShowMainUi();
            }
            else
            {
                Console.WriteLine("It contains:");
                for (int j = 0; j < _coinReturn.CheckReturn().Count; j++)
                {
                    Console.WriteLine(_coinReturn.CheckReturn()[j]);
                }
                Console.WriteLine("Will you (T)ake the coins or (R)eturn to the machine?");
            }

            _showCoinReturnUiWasCalled = true;
            _entry = _console.ReadLine();
            switch (_entry)
            {
                case ("T"):
                    _coinReturn.RemoveCoinsInReturn();
                    ShowMainUi();
                    break;
                case ("R"):
                    ShowMainUi();
                    break;
                case ("DISPLAY"):
                    ShowDisplayUi();
                    break;
                case ("E"):
                    break;
                default:
                    InvalidInput();
                    break;
            }
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
                _console.ReadLine();
                ShowMainUi();
            }
            else
            {
                Console.WriteLine("It contains:");
                for (int j = 0; j < _foodSlot.GetListOfItemsInSlot().Count; j++)
                {
                    Console.WriteLine(_foodSlot.GetListOfItemsInSlot()[j]);
                }
                Console.WriteLine("Will you (T)ake your food, or (R)eturn to the machine?");
                _entry = _console.ReadLine();
                switch (_entry)
                {
                    case ("T"):
                        _foodSlot.RemoveItems();
                        ShowMainUi();
                        break;
                    case ("R"):
                        ShowMainUi();
                        break;
                    case ("P"):
                        ShowDisplayUi();
                        break;
                    case ("E"):
                        break;
                    default:
                        InvalidInput();
                        break;
                }
            }

            _showFoodSlotUiWasCalled = true;
        }

        public void ShowDisplayUi()
        {
            Console.WriteLine("");
           
            Console.WriteLine("Press any key to return to the machine...");
            _console.ReadLine();
            ShowMainUi();

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

        private void InvalidInput()
        {
            Console.WriteLine("That input isn't recognized");
            ShowMainUi();
        }
    }
}
