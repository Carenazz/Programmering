using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace BibliotekApp
{
    public class LibraryData :IDisposable
    {
        public List<Books> books { get; private set; } = new List<Books>();
        public List<Movies> movies { get; private set; } = new List<Movies>();
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

            
            return sqlite_conn;
        }

        public void ReadData()
        {
            Open();
            books.Clear();
            movies.Clear();
            SQLiteDataReader sqlite_datareader;

            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM BookList";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                books.Add(new Books(sqlite_datareader.GetInt32(0), sqlite_datareader.GetString(1), sqlite_datareader.GetString(2), sqlite_datareader.GetInt32(3), sqlite_datareader.GetString(4)));
            }

            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM MovieList";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                movies.Add(new Movies(sqlite_datareader.GetInt32(0), sqlite_datareader.GetString(1), sqlite_datareader.GetString(2), sqlite_datareader.GetInt32(3), sqlite_datareader.GetString(4)));
            }
            Close();
        }

        public void UploadData(Library item)
        {
            Open();

            if (item is Books)
            {
                Books b = item as Books;
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = String.Format("INSERT INTO BookList(Title, Author, Pages, Rating) VALUES('{0}','{1}','{2}','{3}')",
                                                        b.Title,
                                                        b.Author,
                                                        b.Pages,
                                                        b.Rating);
                sqlite_cmd.ExecuteNonQuery();
            }
            if (item is Movies)
            {
                Movies m = item as Movies;
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = String.Format("INSERT INTO MovieList(Title, Director, PlayTime, Rating) VALUES('{0}','{1}','{2}','{3}')",
                                                        m.Title,
                                                        m.Director,
                                                        m.Playtime,
                                                        m.Rating);
                sqlite_cmd.ExecuteNonQuery();
            }

            Close();

            ReadData();
        }

        public void Modify(Library item)
        {
            if (item is Books)
            {

            }
            if (item is Movies)
            {
                Console.WriteLine("Movie!");
            }
        }

        public void RemoveData(Types type, int ID)
        {
            Open();
            switch (type)
            {
                case Types.Book:
                    sqlite_cmd = sqlite_conn.CreateCommand();
                    sqlite_cmd.CommandText = String.Format("DELETE FROM BookList WHERE BookID = '{0}'",
                                                            ID);
                    sqlite_cmd.ExecuteNonQuery();
                    books.RemoveAt(ID - 1);
                    break;
                case Types.Movie:
                    sqlite_cmd = sqlite_conn.CreateCommand();
                    sqlite_cmd.CommandText = String.Format("DELETE FROM MovieList WHERE MovieID = '{0}'",
                                                            ID);
                    sqlite_cmd.ExecuteNonQuery();
                    movies.RemoveAt(ID - 1);
                    break;
                default:
                    break;
            }
            Close();
        }

        public void ModifyData(Library item)
        {
            Open();
            if (item is Books)
            {
                Books b = item as Books;

                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = String.Format("UPDATE BookList SET Title = '{1}', Author = '{2}', Pages = {3}, Rating = '{4}' WHERE BookID = '{0}'",
                                                        b.GetID,
                                                        b.Title,
                                                        b.Author,
                                                        b.Pages,
                                                        b.Rating);
                sqlite_cmd.ExecuteNonQuery();
            }
            if (item is Movies)
            {
                Movies m = item as Movies;

                sqlite_cmd.CommandText = String.Format("UPDATE MovieList SET Title = '{1}', Director = '{2}', Playtime = {3}, Rating = '{4}' WHERE MovieID = '{0}'",
                                                        m.GetID,
                                                        m.Title,
                                                        m.Director,
                                                        m.Playtime,
                                                        m.Rating);
                sqlite_cmd.ExecuteNonQuery();
            }
            Close();

            ReadData();

        }

        private void Open()
        {
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void Close()
        {
            sqlite_conn.Close();
        }

        public void Dispose()
        {
            if (sqlite_conn != null && sqlite_conn.State == System.Data.ConnectionState.Open)
            {
                Close();
            }
        }
    }
}
