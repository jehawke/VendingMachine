using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class VmGetConsoleInput
    {
        public virtual string GetInputFromConsole()
        {
            return Console.ReadLine();
        }
    }
}
