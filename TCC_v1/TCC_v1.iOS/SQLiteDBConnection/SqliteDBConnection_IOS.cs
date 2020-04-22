using System;
using Xamarin.Forms;
using TCC_v1.iOS.SQLiteDBConnection;
using SQLite;
using System.IO;
using TCC_v1.Infra;

[assembly: Dependency(typeof(SqLiteDbConnectionIos))]
namespace TCC_v1.iOS.SQLiteDBConnection
{
    internal class SqLiteDbConnectionIos : ISqLiteDbConnection
    {
        public SQLiteConnection DbConnection()
        {
            SQLitePCL.Batteries.Init();
            const string sqLiteFilename = "database.db3";
            var documentsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqLiteFilename);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}