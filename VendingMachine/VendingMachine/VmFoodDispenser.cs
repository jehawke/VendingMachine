using System.Collections.Generic;

namespace VendingMachine
{
    public class VmFoodDispenser
    {
        private const string SODA_STRING = "S";
        private const string CHIPS_STRING = "H";
        private const string CANDY_STRING  = "C";

        private const int SODA_COST = 100;
        private const int CHIPS_COST = 50;
        private const int CANDY_COST = 65;

        private const int NUM_ITEMS_ADDED_IN_RESTOCK = 5;

        private readonly  List<string> _soda = new List<string>();
        private readonly List<string> _chips = new List<string>();
        private readonly List<string> _candy = new List<string>();

        private readonly List<List<string>> _inventory = new List<List<string>>();

        public bool Dispense(string itemToDispense, VmCoinValidator validator, VmCoinBank coinBank, VmFoodSlot foodSlot, VmDisplay display)
        {
            int currentTransactionTotal = validator.GetCurrentTransactionTotal();

            if (itemToDispense == SODA_STRING && _soda.Count == 0 || itemToDispense == CHIPS_STRING && _chips.Count == 0 ||
                itemToDispense == CANDY_STRING && _candy.Count == 0)
            {
                display.SoldOutMessage();
                return false;
            }

            if (itemToDispense == SODA_STRING && currentTransactionTotal < SODA_COST)
            {
                display.PriceMessage(SODA_COST);
                return false;
            }
            if (itemToDispense == CHIPS_STRING && currentTransactionTotal < CHIPS_COST)
            {
                display.PriceMessage(CHIPS_COST);
                return false;
            }
            if (itemToDispense == CANDY_STRING && currentTransactionTotal < CANDY_COST)
            {
                display.PriceMessage(CANDY_COST);
                return false;
            }

            switch (itemToDispense)
            {
                case SODA_STRING:
                    DispenseSoda(currentTransactionTotal, coinBank, foodSlot, itemToDispense, display);
                    display.ThankYouMessage();
                    validator.CompleteTransaction();
                    return true;
                case CHIPS_STRING:
                    DispenseChips(currentTransactionTotal, coinBank, foodSlot, itemToDispense, display);
                    display.ThankYouMessage();
                    validator.CompleteTransaction();
                    return true;
                case CANDY_STRING:
                    DispenseCandy(currentTransactionTotal, coinBank, foodSlot, itemToDispense, display);
                    display.ThankYouMessage();
                    validator.CompleteTransaction();
                    return true;
                default:
                    return false;
            }
        }

        public void Restock()
        {
            for (int numAdded = 0; numAdded < NUM_ITEMS_ADDED_IN_RESTOCK; numAdded++)
            {
                _soda.Add(SODA_STRING);
                _chips.Add(CHIPS_STRING);
                _candy.Add(CANDY_STRING);
            }
            
            _inventory.Add(_soda);
            _inventory.Add(_chips);
            _inventory.Add(_candy);
        }

        public List<List<string>> GetInventory()
        {
            return _inventory;
        }

        private void DispenseSoda(int currentTransactionTotal, VmCoinBank coinBank, VmFoodSlot foodSlot, string itemToDispense, VmDisplay display)
        {
            if (_soda.Count == 0)
            {
                display.SoldOutMessage();
            }
            else if (currentTransactionTotal < SODA_COST)
            {
                display.PriceMessage(SODA_COST);
            }
            else
            {
                _soda.Remove(SODA_STRING);
                coinBank.MakeChange(currentTransactionTotal - SODA_COST);
                foodSlot.AcceptFood(itemToDispense);
            }
        }

        private void DispenseChips(int currentTransactionTotal, VmCoinBank coinBank, VmFoodSlot foodSlot, string itemToDispense, VmDisplay display)
        {
            if (_chips.Count == 0)
            {
                display.SoldOutMessage();
            }
            else if (currentTransactionTotal < CHIPS_COST)
            {
                display.PriceMessage(SODA_COST);
            }
            else
            {
                _chips.Remove(CHIPS_STRING);
                coinBank.MakeChange(currentTransactionTotal - CHIPS_COST);
                foodSlot.AcceptFood(itemToDispense);
            }
        }

        private void DispenseCandy(int currentTransactionTotal, VmCoinBank coinBank, VmFoodSlot foodSlot, string itemToDispense, VmDisplay display)
        {
            if (_candy.Count == 0)
            {
                display.SoldOutMessage();
            }
            else if (currentTransactionTotal < CANDY_COST)
            {
                display.PriceMessage(SODA_COST);
            }
            else
            {
                _candy.Remove(CANDY_STRING);
                coinBank.MakeChange(currentTransactionTotal - CANDY_COST);
                foodSlot.AcceptFood(itemToDispense);
            }
        }
    }
}
