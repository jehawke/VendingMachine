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

        public bool Dispense(string itemToDispense,VmCoinValidator validator, VmCoinBank coinBank, VmFoodSlot foodSlot)
        {
            int currentTransactionTotal = validator.GetCurrentTransactionTotal();
            if (itemToDispense == SODA_STRING && _soda.Count > 0 && currentTransactionTotal >= SODA_COST)
            {
                _soda.Remove(SODA_STRING);
                foodSlot.AcceptFood(itemToDispense);
                coinBank.GiveChange(currentTransactionTotal - SODA_COST);
                return true;
            }
            if (itemToDispense == CHIPS_STRING && _chips.Count > 0 && currentTransactionTotal >= CHIPS_COST)
            {
                _chips.Remove(CHIPS_STRING);
                foodSlot.AcceptFood(itemToDispense);
                coinBank.GiveChange(currentTransactionTotal - CHIPS_COST);
                return true;
            }
            if (itemToDispense == CANDY_STRING && _candy.Count > 0 && currentTransactionTotal >= CANDY_COST)
            {
                _candy.Remove(CANDY_STRING);
                foodSlot.AcceptFood(itemToDispense);
                coinBank.GiveChange(currentTransactionTotal - CANDY_COST);
                return true;
            }
            return false;
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
    }
}
