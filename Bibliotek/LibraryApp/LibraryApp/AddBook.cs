﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class AddBook
    {
        string verification;
        public string title;
        public string author;
        public int pages;
        Book rate = new Book();
        BookData data = new BookData();
        public void BookAdd()
        {
            // Bogens information (Titel, forfatter, sider og rating)
            Console.Write("Enter a book name: ");
            title = Console.ReadLine();

            // Checking if string is empty.
            if (title == "")
            {
                Console.WriteLine("The book name can't be empty, try again.");
                BookAdd(); // TODO - Move cursor up one, reason: To not have multiple lines of the same prompt.
            }

            Console.Write("Enter the author: ");
            author = Console.ReadLine();

            Console.Write("Enter the amount of pages: ");
            try
            {
                pages = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Rating choices: G, PG, PG-13, R");
            Console.Write("Enter book rating: ");
            rate.Rating = Console.ReadLine().ToUpper();

            // Giver brugeren en chance for at se om der er tastet rigtigt
            Console.WriteLine(
                "---------------------------" + "\n" +
                title + "\n" +
                author + "\n" +
                pages + "\n" +
                rate.Rating + "\n" +
                "---------------------------"
                );

            // Verification på om bogen skulle tilføjes, hvis ja. Adder bogen til listen. (Databasen senere)
            Console.WriteLine("Book will be added, is the information correct? Y/N : \n" +
                "---------------------------");
            verification = Console.ReadLine();
            if (verification.ToLower() == "y")
            {
                data.InsertData(title, author, pages, rate.Rating);
                Console.Clear();
                Console.WriteLine("Book has been added");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Book addition has been cancelled.");
            }
        }
    }
}
