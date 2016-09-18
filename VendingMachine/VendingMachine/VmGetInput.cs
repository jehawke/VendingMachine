using System;

namespace VendingMachine
{
    public class VmGetInput : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine().ToUpper();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public string GetLastMessageDisplayed()
        {
            return null;
        }
    }
}