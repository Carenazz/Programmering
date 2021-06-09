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

        static public void RemoveBook()
        {
            Console.Write("Confirm choice? Y / N : ");
            string verification = Console.ReadLine();

            if (verification.ToLower() == "y")
            {
                BookData.BookRemoval(removal);
                Console.Clear();
                Console.WriteLine("Book has been removed");
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

//books.RemoveAt(removal);