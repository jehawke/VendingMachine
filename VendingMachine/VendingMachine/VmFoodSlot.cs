using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class VmFoodSlot
    {
        private readonly List<string> _itemsInFoodSlot;

        public VmFoodSlot()
        {
            _itemsInFoodSlot = new List<string>();
        }

        public void RemoveItems()
        {
            _itemsInFoodSlot.Clear();
        }

        public List<string> GetListOfItemsInSlot()
        {
            return _itemsInFoodSlot;
        }

        public void AcceptFood(string itemToAccept)
        {
           _itemsInFoodSlot.Add(itemToAccept);
        }
    }
}
