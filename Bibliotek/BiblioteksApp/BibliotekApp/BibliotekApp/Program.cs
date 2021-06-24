using System;
using System.Collections.Generic;

namespace BibliotekApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string tempstring;
            tempstring = Console.ReadLine();

            Library book = new Books(tempstring, "someone", 5, "o");
            Library movie = new Movies("ABCDEFG", "someone", 5, "R");

            book.Print();
            movie.Print();

            Console.ReadKey();
        }
    }
}
