using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlæggende_Programmerings_Opgaver
{
    class RemoveBook
    {
        static public void BookRemove()
        {
            Console.Write("Enter the bookID to add the book to a list for removal: ");
            string info = Console.ReadLine();

            try
            {
                BookList.removal = Convert.ToInt32(info);
                if (Convert.ToInt32(info) <= Book.bookCount)
                {
                    BookList.RemoveBook();
                }

            }
            catch (FormatException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Hovedmenu.HovedMenu();
            }
        }
    }
}
