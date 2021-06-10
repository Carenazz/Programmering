using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class Book
    {
        public int ID;
        public string title;
        public string author;
        public int pages;
        private string rating;

        // Constructor til titel, author, pages og rating til en bog og tilføjer den til listen og holder styr på antallet af bøger.
        public Book(int aID, string aTitle, string aAuthor, int aPages, string aRating)
        {
            ID = aID;
            title = aTitle;
            author = aAuthor;
            pages = aPages;
            Rating = aRating;
        }

        public Book()
        {

        }

        // Property for rating og sikrer værdierne ikke kan sættes til hvad som helst.
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

        // Returner informationer på bogen.
        public string Summary()
        {
            return "Title: " + this.title +
                    "\nAuthor: " + this.author +
                    "\nPages: " + this.pages +
                    "\nRating: " + this.Rating;
        }

        public override string ToString()
        {
            return this.ID + " : " + this.title;
        }
    }
}
