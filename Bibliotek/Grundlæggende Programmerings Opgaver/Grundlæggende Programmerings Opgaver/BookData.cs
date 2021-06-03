using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlæggende_Programmerings_Opgaver
{
    class BookData
    {
        public static void BookInstantiate()
        {
            // Laver objekter og instanstiere book constructor klassen.
            Book book1 = new Book("Harry Potter", "JK Rowling", 309, "PG");
            Book book2 = new Book("Lord of the Rings", "Tolkein", 1214, "PG-13");
            Book book3 = new Book("Star Wars", "George Lucas", 512, "G");
            Book book4 = new Book("Den grimme ælling", "H.C. Andersen", 120, "G");
        }
    }
}
