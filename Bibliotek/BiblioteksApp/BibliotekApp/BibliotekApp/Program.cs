using System;
using System.Collections.Generic;

namespace BibliotekApp
{
    class Program
    {
        static List<Books> bookList = new List<Books>();
        static List<Movies> movieList = new List<Movies>();

        static void Main(string[] args)
        {
            LibraryData data = new LibraryData();

            data.Connection();

            bookList = data.books;

            foreach (Books print in bookList)
            {
                print.Print();
            }

            foreach (Movies print in movieList)
            {
                print.Print();
            }

            Console.ReadKey();
        }
    }
}
