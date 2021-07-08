using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekApp
{
    public class Books : Library
    {
        private string author;
        private int pages;

        public Books(string aTitle, string aAuthor, int aPages, string aRating)
        {
            Title = aTitle;
            author = aAuthor;
            pages = aPages;
            Rating = aRating;
        }
        public Books(int aID, string aTitle, string aAuthor, int aPages, string aRating)
        {
            ID = aID;
            Title = aTitle;
            author = aAuthor;
            pages = aPages;
            Rating = aRating;
        }

        public override void Print()
        {
            Console.WriteLine(new String('-', 25));
            Console.WriteLine("ID: " + ID +
                              "\nTitle: " + Title +
                              "\nPages: " + pages +
                              "\nRating: " + Rating);
        }

        public string Author
        {
            get { return author; }
            set
            {
                author = value;
            }
        }

        // Propery to handle pages, if given the wrong information or 0, we give the book a default value
        public int Pages
        {
            get { return pages; }
            set
            {
                pages = value;
            }
        }
    }
}
