using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlæggende_Programmerings_Opgaver
{
    class Input
    {
        public static void WithExit(string print)
        {
            Console.WriteLine(print);
            string returnString = "";
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.Escape:
                            System.Environment.Exit(0);
                            break;
                        case ConsoleKey.Backspace:
                            if (returnString != "")
                            {
                                returnString = returnString.Remove(returnString.Length - 1);
                            }
                            break;
                        case ConsoleKey.Enter:
                            break;

                        default:
                            if (key.KeyChar == '\u0000') 
                            {

                            }
                            break;
                    }
                }
            } while (keyInfo.Key != ConsoleKey.Enter);
        }
    }
}
