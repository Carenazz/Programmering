using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class SelectBook
    {
        BookData data = new BookData();

        public void BookSelect()
        {
            bool stop = false;
            // Skriver ID + bogens titel ud
            data.PrintData();
            
            do
            {
                try
                {
                    Console.Write("--------------------------- \n" +
                        "Select a book from ID for more information: ");
                    string bookID = Console.ReadLine();
                    Console.WriteLine(data.GetBook(Convert.ToInt32(bookID)).Summary());
                    Console.WriteLine("---------------------------");
                }
                // Error Handling, hvis man kom til at skrive f.eks. q i stedet for 1 eller der ikke findes en bog med ID'et.
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch
                {
                    Console.WriteLine("No such book");
                    continue;
                }
                // Giver brugeren en mulighed for at se flere bøger.
                Console.Write("Search for another book? Y/N : ");
                string verification = Console.ReadLine();
                if (verification.ToLower() == "y")
                {
                    continue;
                }
                else if (verification.ToLower() == "n")
                {
                    Console.WriteLine("Returning to main menu \n" +
                        "----------------------------");
                    stop = true;
                }
                else
                {
                    Console.WriteLine(verification + " is not a valid input, returning to main menu");
                    Console.ReadKey();
                    stop = true;
                }
                Console.Clear();
            } while (!stop);
        }
    }
}
