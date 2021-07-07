using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace BibliotekApp
{
    public class LibraryData
    {
        public List<Books> books = new List<Books>();
        public List<Movies> movies = new List<Movies>();
        private static SQLiteConnection sqlite_conn;
        private static SQLiteCommand sqlite_cmd;

        public enum Types : int
        {
            Book = 1,
            Movie = 2,
        }

        public void Connection()
        {
            sqlite_conn = CreateConnection();
            sqlite_cmd = sqlite_conn.CreateCommand();
            ReadData();
        }
        
        // Remember to change the text after the Data Source= to your exported BookLibrary.db location
        SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;

            sqlite_conn = new SQLiteConnection(@"Data Source=C:\Users\ikkeo\OneDrive\Skrivebord\Programmering\Database\BookLibrary.db");

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

        public void ReadData()
        {
            SQLiteDataReader sqlite_datareader;

            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM BookList";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                books.Add(new Books(sqlite_datareader.GetString(1), sqlite_datareader.GetString(2), sqlite_datareader.GetInt32(3), sqlite_datareader.GetString(4)));
            }

            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM MovieList";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                movies.Add(new Movies(sqlite_datareader.GetString(1), sqlite_datareader.GetString(2), sqlite_datareader.GetInt32(3), sqlite_datareader.GetString(4)));
            }

            sqlite_conn.Close();
        }

        public void UploadData(Types type, string title, string creator, int length, string rating)
        {
            sqlite_conn.Open();
            switch (type)
            {
                case Types.Book:
                    sqlite_cmd = sqlite_conn.CreateCommand();
                    sqlite_cmd.CommandText = String.Format("INSERT INTO BookList(Title, Author, Pages, Rating) VALUES('{0}','{1}','{2}','{3}')",
                                                            title,
                                                            creator,
                                                            length,
                                                            rating);
                    sqlite_cmd.ExecuteNonQuery();
                    break;
                case Types.Movie:
                    sqlite_cmd = sqlite_conn.CreateCommand();
                    sqlite_cmd.CommandText = String.Format("INSERT INTO MovieList(Title, Director, PlayTime, Rating) VALUES('{0}','{1}','{2}','{3}')",
                                                            title,
                                                            creator,
                                                            length,
                                                            rating);
                    sqlite_cmd.ExecuteNonQuery();
                    break;
                default:
                    break;
            }
            sqlite_conn.Close();
        }
    }
}
