using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class BookData
    {
        private static List<Book> books = new List<Book>();

        static public Book GetBook(int bookID) 
        {
            foreach (Book book in books)
            {
                if (book.ID == bookID)
                {
                    return book;
                }
            }
            throw new IndexOutOfRangeException("No book with the ID " + bookID + " was found");
        }

        static public void Connector()
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();
            ReadData(sqlite_conn);
        }

        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection(@"Data Source=C:\Users\ikkeo\OneDrive\Skrivebord\Programmering\Database\BookLibrary.db");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return sqlite_conn;
        }

        static void InsertData(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();

            sqlite_cmd.CommandText = "INSERT INTO SampleTable1(Col1, Col2) VALUES('Test3 Text3 ', 3); ";
            sqlite_cmd.ExecuteNonQuery();

        }

        public static void PrintData()
        {
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
        }


        public static void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM BookList";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                int myID = sqlite_datareader.GetInt32(0);
                string myTitle = sqlite_datareader.GetString(1);
                string myAuthor = sqlite_datareader.GetString(2);
                int myPages = sqlite_datareader.GetInt32(3);
                string myRating = sqlite_datareader.GetString(4);
                books.Add(new Book(myID, myTitle, myAuthor, myPages, myRating));
            }
        }
    }
}
