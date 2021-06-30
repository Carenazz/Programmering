using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekApp
{
    // <summary>
    // Add, remove or modify a book from the list.
    // </summary>
    public class DataManipulation
    {
        static List<Books> bookList = new List<Books>();
        static List<Movies> movieList = new List<Movies>();

        public enum Types 
        {
            Book,
            Movie,
        }

        public void PrintTable(Types type)
        {
            switch (type)
            {
                case Types.Book:
                    foreach (Books print in bookList)
                    {
                        print.Print();
                    }
                    break;
                case Types.Movie:
                    foreach (Movies print in movieList)
                    {
                        print.Print();
                    }
                    break;
                default:
                    break;
            }
        }

        public void Add(Types type, string title, string creator, int length, string rating)
        {
            switch (type)
            {
                case Types.Book:
                    bookList.Add(new Books(title, creator, length, rating));
                    break;
                case Types.Movie:
                    movieList.Add(new Movies(title, creator, length, rating));
                    break;
            }

        }

        public void Remove(Types type, int ID)
        {

        }

        public void Modify(Types type, int ID, string title, string creator, int length, string rating)
        {

        }
    }
}
