using System.Collections.Generic;

namespace VendingMachine
{
    public class VmFoodDispenser
    {
        private const string SODA_STRING = "Soda";
        private const string CHIPS_STRING = "Chips";
        private const string CANDY_STRING  = "Candy";

        private const int NUM_ITEMS_ADDED_IN_RESTOCK = 5;

        private readonly  List<string> _soda = new List<string>();
        private readonly List<string> _chips = new List<string>();
        private readonly List<string> _candy = new List<string>();

        private readonly List<List<string>> _inventory = new List<List<string>>();

        public VmFoodSlot FoodSlot = new VmFoodSlot();

        public bool Dispense(string itemToDispense)
        {
            if (itemToDispense == SODA_STRING && _soda.Count > 0)
            {
                _soda.Remove(SODA_STRING);
                FoodSlot.AcceptFood(itemToDispense);
                return true;
            }
            else if (itemToDispense == CHIPS_STRING && _chips.Count > 0)
            {
                _chips.Remove(CHIPS_STRING);
                FoodSlot.AcceptFood(itemToDispense);
                return true;
            }
            else if (itemToDispense == CANDY_STRING && _candy.Count > 0)
            {
                _candy.Remove(CANDY_STRING);
                FoodSlot.AcceptFood(itemToDispense);
                return true;
            }
            else
            {
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
    }
}
