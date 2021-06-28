using System;
using System.Linq;
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
            string tempTitle = "", tempString = "", tempRating = "", tempInt;
            int convertInt = 1;
            bool isValidNum;

            data.Connection();

            bookList = data.books;
            movieList = data.movies;

            Console.Write("Write the title: ");
            tempTitle = Console.ReadLine();
            Console.Write("Write the author/director: ");
            tempString = Console.ReadLine();
            do
            {
                Console.Write("Write the number of pages / duration on movie: ");
                tempInt = Console.ReadLine();
                isValidNum = !tempInt.All(char.IsDigit);
                if (isValidNum)
                {
                    Console.WriteLine("Is not a valid number, try again.");
                }
            } while (isValidNum);
            
            convertInt = Convert.ToInt32(tempInt);
            Console.Write("Indicate a rating: ");
            tempRating = Console.ReadLine();

            Books book = new Books(tempTitle, tempString, convertInt, tempRating);
            bookList.Add(book);

            foreach (Books print in bookList)
            {
                Console.WriteLine("-----------------------");
                print.Print();
            }

            foreach (Movies print in movieList)
            {
                Console.WriteLine("-----------------------");
                print.Print();
            }

            Console.ReadKey();
        }
    }
}
