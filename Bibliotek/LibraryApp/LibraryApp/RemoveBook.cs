using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class RemoveBook
    {
        bool stop = false;
        BookData data = new BookData();

        public void BookRemove(int ID)
        {
            data.PrintData();

            do
            {
                Console.Write("Confirm choice? Y / N : ");
                string verification = Console.ReadLine();

                if (verification.ToLower() == "y")
                {
                    data.BookRemoval(ID);
                    Console.WriteLine("Book has been removed");
                    Console.ReadKey();
                    stop = true;
                }
                else if (verification.ToLower() == "n")
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
