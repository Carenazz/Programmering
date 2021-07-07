using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekApp
{
    class Menu
    {
        public void TheMenu()
        {
            DataManipulation manipulator = new DataManipulation();
            manipulator.ConnectDataOnce();

            string tempTitle = "", tempString = "", tempRating = "", tempInt;
            int convertInt = 1, pickType = 1, menuChoice;

            do
            {
                Console.Clear();
                MenuText();
                do
                {
                    Console.Write("Pick an option from the menu: ");
                    tempInt = Console.ReadLine();
                } while (!IsValidNum(tempInt));
                menuChoice = Convert.ToInt32(tempInt);

                switch (menuChoice)
                {
                    case 1:
                        EnumTable();
                        do
                        {
                            Console.Write("Select a list of books or movies: ");
                            tempInt = Console.ReadLine();
                        } while (!IsValidNum(tempInt));
                        pickType = Convert.ToInt32(tempInt);
                        manipulator.PrintTable((DataManipulation.Types)pickType);
                        break;
                    case 2:
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

                        EnumTable();

                        do
                        {
                            Console.Write("Insert data into which list? (Use number): ");
                            tempInt = Console.ReadLine();
                        } while (!IsValidNum(tempInt));
                        pickType = Convert.ToInt32(tempInt);

                        if (Enum.IsDefined(typeof(DataManipulation.Types), pickType))
                            manipulator.Add((DataManipulation.Types)pickType, tempTitle, tempString, convertInt, tempRating);

                        manipulator.PrintTable((DataManipulation.Types)pickType);
                        break;
                    default:
                        Console.WriteLine("Is not an option in the menu");
                        break;
                }
            } while (Continue());
        }

        // Checks if the user wants to continue at the end of the program.
        private bool Continue()
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

        // Checks if a string is a number.
        private bool IsValidNum(string check)
        {
            if (check.All(char.IsDigit) && !string.IsNullOrWhiteSpace(check))
                return true;
            else
                Console.WriteLine("Is not a valid number, try again.");
            return false;
        }

        private void MenuText()
        {
            Console.WriteLine(new String('-', 30));
            Console.WriteLine("Main Menu");
            Console.WriteLine("1: See all books / movies.");
            Console.WriteLine("2: Add a new book / movie");
            Console.WriteLine("3: Remove a book / movie");
            Console.WriteLine("4: Edit a book / movie");
            Console.WriteLine(new String('-', 30));
        }

        // Table from enum in Datamanipulation to print out the two choices.
        private void EnumTable()
        {
            int i = 1;
            Console.WriteLine(new String('-', 15));
            foreach (var type in Enum.GetValues(typeof(DataManipulation.Types)))
            {
                Console.Write("| " + i + ": " + type);
                Console.Write(new String(' ', Console.WindowWidth));
                Console.SetCursorPosition(14, Console.CursorTop - 1);
                Console.WriteLine("|");

                i += 1;
            }
            Console.WriteLine(new String('-', 15));
        }
    }
}
