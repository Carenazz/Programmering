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
                if (value.ToUpper() == "G" ||
                    value.ToUpper() == "PG" ||
                    value.ToUpper() == "PG-13" ||
                    value.ToUpper() == "R" )
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
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            else
                return true;
        }

        public abstract void Print();
    }
}
