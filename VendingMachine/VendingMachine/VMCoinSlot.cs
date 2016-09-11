using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VMCoinSlot
    {
        public bool bItemWasInserted = false;

        public void sendInsertedItemToValidator()
        {
            bItemWasInserted = true;
        }
    }
}
