using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class Hovedmenu
    {
        bool mustClose = false;

        // Hovedmenu til valg af en bog, lave en bog eller fjernelse af en bog. Med en switch/case for at registrere et valid valg.
        public void HovedMenu()
        {
            EditBook eb = new EditBook();
            AddBook newBook = new AddBook();

            do
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
                        newBook.BookAdd();
                        break;
                    case "3":
                        eb.BookEdit();
                        break;
                    case "4":
                        RemoveBook.BookRemove();
                        break;
                    case "c":
                        mustClose = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("You typed something wrong, try again.");
                        continue;
                }
            } while (!mustClose);
            Console.WriteLine("Thanks for using Mike's Library program");
        }
    }
}
