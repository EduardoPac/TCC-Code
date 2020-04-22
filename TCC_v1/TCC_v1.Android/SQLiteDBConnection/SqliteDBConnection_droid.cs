using Xamarin.Forms;
using TCC_v1.Droid.SQLiteDBConnection;
using TCC_v1.Infra;
using SQLite;
using System.IO;

[assembly: Dependency(typeof(SqLiteDbConnectionDroid))]
namespace TCC_v1.Droid.SQLiteDBConnection
{
    internal class SqLiteDbConnectionDroid : ISqLiteDbConnection
    {
        public SqLiteDbConnectionDroid()
        {
        }
        public SQLiteConnection DbConnection()
        {
            SQLitePCL.Batteries.Init();
            const string sqLiteFileName = "data.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqLiteFileName);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}