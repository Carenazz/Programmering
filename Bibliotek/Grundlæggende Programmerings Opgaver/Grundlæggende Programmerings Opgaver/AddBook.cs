﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlæggende_Programmerings_Opgaver
{
    class AddBook
    {
        string verification;
        public string title;
        public string author;
        public int pages;
        private string rating;

        public void BookAdd()
        {
            // Bogens information (Titel, forfatter, sider og rating)
            Console.Write("Enter a book name: ");
            title = Console.ReadLine();

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
            Console.Write("Enter book rating: ");
            Rating = Console.ReadLine();

            // Giver brugeren en chance for at se om der er tastet rigtigt
            Console.WriteLine(title + "\n" +
                author + "\n" +
                pages + "\n" +
                Rating);
            
            // Verification på om bogen skulle tilføjes, hvis ja. Adder bogen til listen. (Databasen senere)
            Console.WriteLine("Book will be added, is the information correct? Y/N : \n" +
                ".................");
            verification = Console.ReadLine();
            if (verification.ToLower() == "y")
            {
                Book newBook = new Book(title, author, pages, Rating);
                Console.Clear();
                Console.WriteLine("Book has been added");
                Hovedmenu.HovedMenu();
            }
            else
            {
                Hovedmenu.HovedMenu();
                Console.WriteLine("Book addition has been cancelled.");
            }
        }

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
    }
}
