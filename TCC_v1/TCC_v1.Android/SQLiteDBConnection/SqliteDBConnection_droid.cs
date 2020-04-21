using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using TCC_v1.Droid.SQLiteDBConnection;
using TCC_v1.Infra;
using SQLite;
using System.IO;

[assembly: Dependency(typeof(SqliteDBConnection_droid))]
namespace TCC_v1.Droid.SQLiteDBConnection
{
    class SqliteDBConnection_droid : SqliteDBConnection
    {
        public SqliteDBConnection_droid()
        {

        }
        public SQLiteConnection DbConnection()
        {
            SQLitePCL.Batteries.Init();
            var sqliteFilename = "Teste17.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            // create the connection
            var conn = new SQLite.SQLiteConnection(path);
            //return the database connection
            return conn;
        }
    }
}