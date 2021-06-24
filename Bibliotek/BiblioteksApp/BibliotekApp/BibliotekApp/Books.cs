﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekApp
{
    public class Books : Library
    {
        private string author;
        private int pages;
        
        public Books(string aTitle, string aAuthor, int aPages, string aRating)
        {
            Title = aTitle;
            author = aAuthor;
            pages = aPages;
            Rating = aRating;
        }

        public override void Print()
        {
            Console.WriteLine("Title: " + Title);
        }
    }
}
