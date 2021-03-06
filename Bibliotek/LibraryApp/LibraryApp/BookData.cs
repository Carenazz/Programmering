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
        private static SQLiteConnection sqlite_conn;
        private static SQLiteCommand sqlite_cmd;
        public Book GetBook(int bookID) 
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

        #region Connection creation
        public void Connector()
        {
            sqlite_conn = CreateConnection();
            sqlite_cmd = sqlite_conn.CreateCommand();
            ReadData(sqlite_conn);
            sqlite_conn.Close();
        }

        SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            // Create a new database connection, remember to change it to your own datasource when downloading from Github!!
            sqlite_conn = new SQLiteConnection(@"Data Source=C:\Users\ikkeo\OneDrive\Skrivebord\Programmering\Database\BookLibrary.db");
            // Opens the connection:
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
        #endregion

        #region Reading and printing Data.
        public void PrintData()
        {
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
        }


        public void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader sqlite_datareader;

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
            sqlite_conn.Close();
        }
        #endregion

        #region Insertion of Data
        public void InsertData(string title, string author, int pages, string rating)
        {
            InsertData(sqlite_conn, title, author, pages, rating);
        }

        public void InsertData(SQLiteConnection conn, string title, string author, int pages, string rating)
        {

            sqlite_conn.Open();
            sqlite_cmd = conn.CreateCommand();

            sqlite_cmd.CommandText = String.Format("INSERT INTO BookList(Title, Author, Pages, Rating) VALUES('{0}','{1}','{2}','{3}')", 
                                                    title,
                                                    author,
                                                    pages,
                                                    rating);
            sqlite_cmd.ExecuteNonQuery();

            books = new List<Book>();
            ReadData(sqlite_conn);
            sqlite_conn.Close();
        }
        #endregion

        #region Edit Data
        public void EditBookData(Book book)
        {
            EditBookData(sqlite_conn, book);
        }

        private void EditBookData(SQLiteConnection conn, Book book)
        {
            sqlite_conn.Open();
            sqlite_cmd = conn.CreateCommand();

            sqlite_cmd.CommandText = String.Format("UPDATE BookList SET Title = '{0}', Author = '{1}', Pages = {2}, Rating = '{3}' WHERE BookID = '{4}'",
                                                    book.title,
                                                    book.author,
                                                    book.pages,
                                                    book.Rating,
                                                    book.ID);

            sqlite_cmd.ExecuteNonQuery();

            books = new List<Book>();
            ReadData(sqlite_conn);
            sqlite_conn.Close();
        }
        #endregion

        #region Removal of Data
        public void BookRemoval(int ID)
        {
            BookRemoval(sqlite_conn, ID);
        }

        public void BookRemoval(SQLiteConnection conn, int ID)
        {
            sqlite_conn.Open();
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = String.Format("DELETE FROM BookList WHERE BookID = '{0}'",
                                                    ID);
            sqlite_cmd.ExecuteNonQuery();

            books = new List<Book>();
            ReadData(sqlite_conn);
            sqlite_conn.Close();
        }
        #endregion

    }
}
