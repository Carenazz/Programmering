using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class Hovedmenu
    {
        // Hovedmenu til valg af en bog, lave en bog eller fjernelse af en bog. Med en switch/case for at registrere et valid valg.
        static public void HovedMenu()
        {
            Console.WriteLine("Main Menu \n" +
                "------------------------------------- \n" +
                "1: Choose a book \n" +
                "2: Add a new book \n" +
                "3: Edit an existing book \n" +
                "4: Remove a book \n" +
                "\n" +
                "\n" +
                "\n" +
                "C: Close application \n" +
                "-------------------------------------");

            Console.Write("Enter an option in the menu: ");
            string menuSelect = Console.ReadLine().ToLower();
            Console.Clear();

            switch (menuSelect)
            {
                case "1":
                    SelectBook.BookSelect();
                    break;
                case "2":
                    AddBook newBook = new AddBook();
                    newBook.BookAdd();
                    break;
                case "3":
                    EditBook.BookEdit();
                    break;
                case "4":
                    RemoveBook.BookRemove();
                    break;
                case "c":
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("You typed something wrong, try again.");
                    HovedMenu();
                    break;
            }
            Console.ReadLine();
        }
    }
}
