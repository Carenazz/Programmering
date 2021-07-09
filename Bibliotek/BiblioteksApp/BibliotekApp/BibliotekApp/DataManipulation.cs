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
        LibraryData data = new LibraryData();

        List<Books> bookList = null;
        List<Movies> movieList = null;

        public DataManipulation()
        {
            this.bookList = data.books;
            this.movieList = data.movies;
        }

        public enum Types : int
        {
            Book = 1,
            Movie = 2,
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

        // Add a book or a movie to the list.
        public void Add(Types type, string title, string creator, int length, string rating)
        {
            switch (type)
            {
                case Types.Book:
                    data.UploadData(new Books(title, creator, length, rating));
                    break;
                case Types.Movie:
                    data.UploadData(new Books(title, creator, length, rating));
                    break;
            }
        }

        // Remove a book or movie from a list.
        public void Remove(Types type, int ID)
        {
            switch (type)
            {
                case Types.Book:
                    // ID - 1 is equal to the indexing of the list. The first index being 0 but 1 in the ID.
                    data.RemoveData((LibraryData.Types)1, ID);
                    break;
                case Types.Movie:
                    data.RemoveData((LibraryData.Types)2, ID);
                    break;
                default:
                    break;
            }
        }

        // Modify a book or movie in the list.
        public void Modify(Types type, int ID, string title, string creator, int length, string rating)
        {

            switch (type)
            {
                case Types.Book:
                    data.ModifyData(new Books(ID, title, creator, length, rating));
                    break;
                case Types.Movie:
                    data.ModifyData(new Movies(ID, title, creator, length, rating));
                    break;
                default:
                    break;
            }

        }

        public void ConnectDataOnce()
        {
            data.Connection();
        }
    }
}