using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class BookList
    {
        static public int removal;

        // Lavede det her kun for nedarvnings eksempel til at lave en liste af bøger udenfor Book klassen.
        public static List<Book> books = new List<Book>();

        static public void RemoveBook()
        {
            Console.Write("Confirm choice? Y / N : ");
            string verification = Console.ReadLine();

            if (verification.ToLower() == "y")
            {
                books.RemoveAt(removal - 1);
                Console.Clear();
                Console.WriteLine("Book has been removed");
                Book.RemovedBook();
                Hovedmenu.HovedMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Book removal has been cancelled");
                Hovedmenu.HovedMenu();
            }
        }
    }
}
