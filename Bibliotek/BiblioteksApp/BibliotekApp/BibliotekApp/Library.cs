using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekApp
{
    public abstract class Library
    {
        private string title, rating;

        public string Title
        {
            get { return title; }
            protected set 
            {
                if (Validate(value))
                {
                    title = value;
                }
                else
                {
                    title = "Not a valid title";
                }
            }
        }

        public string Rating
        {
            get { return rating; }
            protected set
            {
                value = value.ToUpper();
                if (value == "G" ||
                    value == "PG" ||
                    value == "PG-13" ||
                    value == "R" )
                {
                    rating = value;
                }
                else
                {
                    rating = "NR";
                }
            }
        }

        private bool Validate(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        public abstract void Print();
    }
}
