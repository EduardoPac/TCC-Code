using SQLite;

namespace TCC_v1.Infra
{
    public interface ISqLiteDbConnection
    {
        SQLiteConnection DbConnection();
    }
}
