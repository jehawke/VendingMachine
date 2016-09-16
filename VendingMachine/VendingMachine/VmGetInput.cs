using System;

namespace VendingMachine
{
    public class VmGetInput : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine().ToUpper();
        }
    }
}