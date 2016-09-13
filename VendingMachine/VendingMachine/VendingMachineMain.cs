using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("______________________VENDING MACHINE_______________________");
            Console.WriteLine("| (I) Insert Coin                               (R) Refund |");
            Console.WriteLine("|                                                          |");
            Console.WriteLine("| (S) Soda: 1.00       (H) Chips: .50       (C) Candy: .65 |");
            Console.WriteLine("|                                                          |");
            Console.WriteLine("| (T) Take Item (0 items)        (N) Coin Return (0 items) |");
            Console.WriteLine("____________________________________________________________");
            Console.WriteLine("");
            Console.WriteLine("You rummage through your pockets looking for a ");
            Console.WriteLine("Quarter" + ", " + "Nickel" + ", or " + "Dime");
            Console.WriteLine("");
            Console.WriteLine("The Display Reads: " + "[" + "INSERT COIN" + " " + "0.00" + "]");
            Console.Write("You decide to: ");

            string coin = Console.ReadLine();
            
        }
    }
}
