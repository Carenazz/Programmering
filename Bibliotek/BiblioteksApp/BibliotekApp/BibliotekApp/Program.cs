﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace BibliotekApp
{
    class Program
    {

        static void Main(string[] args)
        {
            DataManipulation manipulator = new DataManipulation();
            manipulator.ConnectDataOnce();
            
            string tempTitle = "", tempString = "", tempRating = "", tempInt;
            int convertInt = 1, i = 1, pickType = 1;

            do
            {
                Console.Write("Write the title: ");
                tempTitle = Console.ReadLine();
                
                Console.Write("Write the author/director: ");
                tempString = Console.ReadLine();
                
                do
                {
                    Console.Write("Write the number of pages / duration on movie: ");
                    tempInt = Console.ReadLine();
                } while (!IsValidNum(tempInt));
                convertInt = Convert.ToInt32(tempInt);

                Console.Write("Indicate a rating: ");
                tempRating = Console.ReadLine();

                Console.WriteLine(new String('-', 15));
                foreach (var type in Enum.GetValues(typeof(DataManipulation.Types)))
                {
                    Console.Write("| " + i + ": " + type);
                    Console.Write(new String(' ', Console.WindowWidth));
                    Console.SetCursorPosition(14, Console.CursorTop - 1);
                    Console.WriteLine("|");

                    i += 1;
                }
                i = 1;

                Console.WriteLine(new String('-', 15));
                do
                {
                    Console.Write("Insert data into which list? (Use number): ");
                    tempInt = Console.ReadLine();
                } while (!IsValidNum(tempInt));
                pickType = Convert.ToInt32(tempInt);

                if (Enum.IsDefined(typeof(DataManipulation.Types), pickType)) 
                    manipulator.Add((DataManipulation.Types) pickType, tempTitle, tempString, convertInt, tempRating);
                
                manipulator.PrintTable((DataManipulation.Types) pickType);

            } while (Continue());

            Console.WriteLine("Thanks for using Mike's Library application");
            Console.ReadKey();
        }

        static private bool Continue()
        {
            Console.Write("Do you want to continue? (Y / N): ");

            ConsoleKeyInfo validate = Console.ReadKey();
            int CurrentLine = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, CurrentLine);
            Console.WriteLine("");

            return validate.Key == ConsoleKey.Y;
        }

        static private bool IsValidNum(string check)
        {
            if (check.All(char.IsDigit) && !string.IsNullOrWhiteSpace(check))
            {
                return true;
            }
            else
                Console.WriteLine("Is not a valid number, try again.");
                return false;
        }
    }
}
