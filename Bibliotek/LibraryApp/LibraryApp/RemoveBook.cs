using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class RemoveBook
    {
        public int removal;
        BookData data = new BookData();

        public void BookRemove()
        {
            data.PrintData();

            Console.Write("Enter the bookID to add the book to a list for removal: ");
            string info = Console.ReadLine();

            try
            {
                removal = Convert.ToInt32(info);
                VerifyRemoval();
            }
            catch (FormatException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public void VerifyRemoval()
        {
            Console.Write("Confirm choice? Y / N : ");
            string verification = Console.ReadLine();

            if (verification.ToLower() == "y")
            {
                data.BookRemoval(removal);
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
                Console.WriteLine(verification + " Is entered incorrectly, try again");
                VerifyRemoval();
            }
        }
    }
}
