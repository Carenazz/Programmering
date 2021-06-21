using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class EditBook
    {
        BookData data = new BookData();

        // Lav et system som kan ændre dataen i SQL
        public void BookEdit()
        {
            string title, author, rating, verify;
            int pages, ID;
            bool stop = false;

            do
            {
                Console.WriteLine("------------------------ \n" +
                                  "Choices \n" +
                                  "1: Edit title \n" +
                                  "2: Edit author \n" +
                                  "3: Edit number of pages \n" +
                                  "4: Edit the rating \n" +
                                  "5: Edit all data \n\n" +

                                  "C: Back to main menu \n" +
                                  "------------------------");
                Console.WriteLine("Select an option from the menu: ");
                string verification = Console.ReadLine();

                if (verification.ToLower() != "c")
                {
                    data.PrintData();
                    Console.Write("------------------------ \n" + 
                                  "Enter the bookID to add the book to a list for editing: ");
                    try
                    {
                        ID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(data.GetBook(Convert.ToInt32(ID)).Summary());
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e);
                        Console.ReadKey();
                        Console.Clear();
                        throw;
                    }
                }
                // Made to prevent "No ID" error
                else
                {
                    ID = 0;
                }

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

                    case "5":
                        Console.Write("Edit the title: ");
                        title = Console.ReadLine();
                        Console.Write("Edit the author: ");
                        author = Console.ReadLine();
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
                        Console.Write("Edit the rating: ");
                        rating = Console.ReadLine();

                        Console.WriteLine(title + "\n" +
                                          author + "\n" +
                                          pages + "\n" +
                                          rating + "\n" +
                                          "Is this information correct?\n" +
                                          "Y / N :");
                        verify = Console.ReadLine();

                        if (verify.ToLower() == "y")
                        {
                            data.EditBookData(title, author, pages, rating, ID);
                        }
                        break;

                    case "c":
                        stop = true;
                        Console.Clear();
                        break;

                    default:
                        break;
                }
            } while (!stop);
        }
    }
}
