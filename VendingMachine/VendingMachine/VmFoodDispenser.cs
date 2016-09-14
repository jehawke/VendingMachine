using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VmFoodDispenser
    {
        public List<string> Inventory = new List<string>();

        
        public string Dispense(string itemToDispense)
        {
            Inventory.Remove(itemToDispense);
            return itemToDispense;
        }

        public void Restock()
        {
            Inventory.Add("Soda");
        }
    }
}
