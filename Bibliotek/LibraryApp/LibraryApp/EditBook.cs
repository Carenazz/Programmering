using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class EditBook
    {
        // Lav et system som kan ændre dataen i SQL
        public void BookEdit()
        {
            string title, author, rating;
            int pages;

            BookData.PrintData();

            Console.Write("Enter the bookID to add the book to a list for editing: ");
            string info = Console.ReadLine();
            try
            {
                Console.WriteLine(BookData.GetBook(Convert.ToInt32(info)).Summary());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
                Console.Clear();
                throw;
            }

            Console.WriteLine("------------------------ \n" +
                              "Choices \n" +
                              "1: Edit title \n" +
                              "2: Edit author \n" +
                              "3: Edit number of pages \n" +
                              "4: Edit the rating \n\n" +

                              "C: Back to main menu \n" +
                              "------------------------");
            Console.WriteLine("What do you want to modify on this book: ");
            string verification = Console.ReadLine();

            switch (verification.ToLower())
            {
                case "1":
                   Console.Write("Edit the title: ");
                   title = Console.ReadLine();
                   break;

                case "2":
                    Console.Write("Edit the author: ");
                    author = Console.ReadLine();
                    break;

                case "3":
                    Console.Write("Edit the number of pages: ");
                    try
                    {
                        pages = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.Write("The value entered is not a number, returning to the main menu");
                        Console.ReadKey();
                        Console.Clear();
                        throw;
                    }
                    break;

                case "4":
                    Console.Write("Edit the rating: ");
                    rating = Console.ReadLine();
                    break;

                case "c":
                    Console.Clear();
                    break;

                default:
                    break;
            }
        }
    }
}
