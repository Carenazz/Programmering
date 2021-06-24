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
            Console.WriteLine("Title: " + Title +
                              "\nRating: " + Rating);
        }

        public string Director {
            get { return director; }
            set
            {
                director = value;
            } 
        }

        // Property to handle playtime, in case the value is 0, we take a default assumption the movie is 90 minutes long.
        public int Playtime
        {
            get { return playtime; }
            set
            {
                if (char.IsNumber(Convert.ToChar(value)) || value != 0)
                {
                    playtime = value;
                }
                else
                {
                    playtime = 90;
                }
            }
        }
    }
}
