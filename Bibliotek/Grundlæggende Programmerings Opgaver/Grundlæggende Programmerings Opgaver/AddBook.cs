using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlæggende_Programmerings_Opgaver
{
    class AddBook
    {
        public string title;
        public string author;
        public int pages;
        private string rating;

        public void BookAdd()
        {
            Console.Write("Enter a book name: ");
            title = Console.ReadLine();

            Console.Write("Enter the author: ");
            author = Console.ReadLine();

            Console.Write("Enter the amount of pages: ");
            try
            {
                pages = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Write("Enter book rating: ");
            Rating = Console.ReadLine();

            Book newBook = new Book(title, author, pages, Rating);

            Console.WriteLine("Book: " + title + " has been added, returning to menu \n" +
                ".................");

            Hovedmenu.HovedMenu();
        }

        public string Rating
        {
            get { return rating; }
            set
            {
                if (value == "G" || value == "PG" || value == "PG-13" || value == "R" || value == "NR")
                {
                    rating = value;
                }
                else
                {
                    rating = "NR";
                }
            }
        }
    }
}
