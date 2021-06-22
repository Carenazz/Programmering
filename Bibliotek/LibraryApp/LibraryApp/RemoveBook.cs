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
        bool stop = false;
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
            do
            {
                Console.Write("Confirm choice? Y / N : ");
                string verification = Console.ReadLine();

                if (verification.ToLower() == "y")
                {
                    data.BookRemoval(removal);
                    Console.WriteLine("Book has been removed");
                    Console.ReadKey();
                    stop = true;
                }
                else if(verification.ToLower() == "n")
                {
                    Console.WriteLine("Book removal has been cancelled");
                    Console.ReadKey();
                    stop = true;
                }
                else
                {
                    Console.WriteLine(verification + " Is entered incorrectly, try again");
                }
                Console.Clear();
            } while (!stop);
            stop = false;
        }
    }
}
