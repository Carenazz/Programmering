﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace BibliotekApp
{
    public class LibraryData
    {
        public List<Books> books = new List<Books>();
        private static SQLiteConnection sqlite_conn;
        private static SQLiteCommand sqlite_cmd;

        public void Connection()
        {
            sqlite_conn = CreateConnection();
            sqlite_cmd = sqlite_conn.CreateCommand();
            ReadData(sqlite_conn);
        }

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

        public void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader sqlite_datareader;

            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM BookList";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                books.Add(new Books(sqlite_datareader.GetString(1), sqlite_datareader.GetString(2), sqlite_datareader.GetInt32(3), sqlite_datareader.GetString(4)));
            }
            sqlite_conn.Close();
        }
    }
}