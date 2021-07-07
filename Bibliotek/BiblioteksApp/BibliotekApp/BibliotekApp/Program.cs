using System;
using System.Linq;
using System.Collections.Generic;

namespace BibliotekApp
{
    class Program
    {

        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.TheMenu();

            Console.WriteLine("Thanks for using Mike's Library application");
            Console.ReadKey();
        }

        
    }
}
