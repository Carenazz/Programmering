using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlæggende_Programmerings_Opgaver
{
    public class SelectBook
    {
        public static void BookSelect()
        {
            // Skriver antallet af bøger ud.
            Console.WriteLine("Number of books: " + Book.bookCount);

            do
            {
                try
                {
                    Console.Write("Select a book from ID: ");
                    string bookID = Console.ReadLine();
                    Console.WriteLine(Book.books[Convert.ToInt32(bookID) - 1].Summary());
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
                    Console.WriteLine("Returning \n" +
                        "..................");
                }
                else if (verification.ToLower() == "n")
                {
                    Console.Clear();
                    Console.WriteLine("Returning to main menu \n" +
                        "..................");
                    Hovedmenu.HovedMenu();
                    break;
                }
                else
                {
                    Console.WriteLine(verification + " is not a valid input, closing program");
                    break;
                }
            } while (true);
        }
    }
}
