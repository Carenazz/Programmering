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
        string title, author, rating, verify;
        int pages, ID;

        // Lav et system som kan ændre dataen i SQL
        public void BookEdit()
        {
            bool stop = false;

            do
            {
                // Editing menuen
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

                // Checker for om c er valgt, hvis ikke, fortsætter koden.
                if (verification.ToLower() != "c" || verification == "")
                {
                    ChooseBook();
                }
                // Sørger for at når C er valgt, sker der ikke en "Kan ikke finde ID" fejl.
                else
                {
                    ID = 1;
                }

                Book book = data.GetBook(ID);
                // Checker efter valget
                switch (verification.ToLower())
                {
                    case "1":
                        Console.Write("Edit the title: ");
                        book.title = Console.ReadLine();

                        Console.Write("Is this title correct? " + book.title + "\n Y / N : ");
                        verify = Console.ReadLine();
                        if (verify.ToLower() == "y")
                        {
                            data.EditBookData(book);
                        }
                        break;

                    case "2":
                        Console.Write("Edit the author: ");
                        author = Console.ReadLine();
                        book.author = author;
                        Console.Write("Is the author correct? " + author + "\n Y / N : ");
                        verify = Console.ReadLine();
                        if (verify.ToLower() == "y")
                        {
                            data.EditBookData(book);
                        }
                        break;

                    case "3":
                        Console.Write("Edit the number of pages: ");
                        try
                        {
                            pages = Convert.ToInt32(Console.ReadLine());
                            book.pages = pages;
                            Console.Write("Is the amount of pages correct? " + pages + "\n Y / N : ");
                            verify = Console.ReadLine();
                            if (verify.ToLower() == "y")
                            {
                                data.EditBookData(book);
                            }
                        }
                        catch (Exception)
                        {
                            book.pages = 0;
                        }
                        break;

                    case "4":
                        Console.Write("Edit the rating: ");
                        rating = Console.ReadLine();
                        book.Rating = rating;
                        Console.Write("Is the rating correct? " + book.Rating + "\n Y / N : ");
                        verify = Console.ReadLine();
                        if (verify.ToLower() == "y")
                        {
                            data.EditBookData(book);
                        }
                        break;

                    case "5":
                        Console.Write("Edit the title: ");
                        title = Console.ReadLine();
                        Console.Write("Edit the author: ");
                        author = Console.ReadLine();
                        Console.Write("Edit the number of pages: ");
                        // Error handling.
                        try
                        {
                            pages = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            pages = 0;
                        }
                        Console.Write("Edit the rating: ");
                        rating = Console.ReadLine();

                        // Brugeren kan checke om de har tastet korrekt, hvis ikke kan det annuleres.
                        Console.WriteLine(title + "\n" +
                                          author + "\n" +
                                          pages + "\n" +
                                          rating + "\n" +
                                          "Is this information correct?\n" +
                                          "Y / N :");
                        verify = Console.ReadLine();

                        if (verify.ToLower() == "y")
                        {
                            book.title = title;
                            book.author = author;
                            book.pages = pages;
                            book.Rating = rating;
                            data.EditBookData(book);
                            Console.Clear();
                        }
                        break;
                    // Bryder løkken
                    case "c":
                        stop = true;
                        Console.Clear();
                        break;

                    default:
                        break;
                }
              Console.Clear();
            } while (!stop);
        }

        private void ChooseBook()
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
    }
}
