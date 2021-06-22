using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class AddBook
    {
        string verification;
        BookData data = new BookData();
        public void BookAdd()
        {
            Book book = new Book();
            // Bogens information (Titel, forfatter, sider og rating)
            Console.Write("Enter a book name: ");
            book.title = Console.ReadLine();

            // Checking if string is empty.
            if (book.title == "")
            {
                Console.WriteLine("The book name can't be empty, try again.");
                BookAdd(); // TODO - Move cursor up one, reason: To not have multiple lines of the same prompt.
            }

            Console.Write("Enter the author: ");
            book.author = Console.ReadLine();

            Console.Write("Enter the amount of pages: ");
            try
            {
                book.pages = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                book.pages = 0;
            }
            Console.WriteLine("Rating choices: G, PG, PG-13, R");
            Console.Write("Enter book rating: ");
            book.Rating = Console.ReadLine().ToUpper();

            // Giver brugeren en chance for at se om der er tastet rigtigt
            Console.WriteLine(
                "---------------------------" + "\n" +
                book.title + "\n" +
                book.author + "\n" +
                book.pages + "\n" +
                book.Rating + "\n" +
                "---------------------------"
                );

            // Verification på om bogen skulle tilføjes, hvis ja. Adder bogen til listen. (Databasen senere)
            Console.WriteLine("Book will be added, is the information correct? Y/N : \n" +
                "---------------------------");
            verification = Console.ReadLine();
            if (verification.ToLower() == "y")
            {
                data.InsertData(book.title, book.author, book.pages, book.Rating);
                Console.Clear();
                Console.WriteLine(book.title + " has been added");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Adding the book has been cancelled.");
            }
        }
    }
}