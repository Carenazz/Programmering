using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class RemoveBook
    {
        static public int removal;

        static public void BookRemove()
        {
            BookData.PrintData();

            Console.Write("Enter the bookID to add the book to a list for removal: ");
            string info = Console.ReadLine();

            try
            {
                removal = Convert.ToInt32(info);
                DeleteBook();
            }
            catch (FormatException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        static public void DeleteBook()
        {
            Console.Write("Confirm choice? Y / N : ");
            string verification = Console.ReadLine();

            if (verification.ToLower() == "y")
            {
                BookData.BookRemoval(removal);
                Console.Clear();
                Console.WriteLine("Book has been removed");
            }
            else if(verification.ToLower() == "n")
            {
                Console.Clear();
                Console.WriteLine("Book removal has been cancelled");
            }
            else
            {
                Console.WriteLine(verification + " Is entered incorrectly, tried again");
                DeleteBook();
            }
        }
    }
}
