using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekApp
{
    public class Movies : Library
    {
        private string director;
        private int playtime;

        public Movies(string aTitle, string aDirector, int aPlaytime, string aRating)
        {
            Title = aTitle;
            director = aDirector;
            playtime = aPlaytime;
            Rating = aRating;
        }

        public override void Print()
        {
            Console.WriteLine("Title: " + Title);
        }

        public string Director {
            get { return director; }
            set
            {
                director = value;
            } 
        }

        public int Playtime
        {
            get { return playtime; }
            set
            {
                if (char.IsDigit(Convert.ToChar(value)))
                {
                    playtime = value;
                }
            }
        }
    }
}
