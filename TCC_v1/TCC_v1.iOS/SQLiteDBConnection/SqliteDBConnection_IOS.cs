using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using TCC_v1.iOS.SQLiteDBConnection;
using TCC_v1.Infra;
using SQLite;
using System.IO;

[assembly: Dependency(typeof(SqliteDBConnection_IOS))]
namespace TCC_v1.iOS.SQLiteDBConnection
{
    class SqliteDBConnection_IOS : SqliteDBConnection
    {

        SQLiteConnection SqliteDBConnection.DbConnection => dbConnection();

        public SQLiteConnection dbConnection()
        {
            SQLitePCL.Batteries.Init();
            var sqliteFilename = "teste1.db3";
            string documentsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFilename);
            // create the connection
            var conn = new SQLite.SQLiteConnection(path);
            //return the database connection
            return conn;
        }

        
    }
}