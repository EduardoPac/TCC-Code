using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_v1.Infra
{
    public interface SqliteDBConnection
    {
        SQLiteConnection DbConnection();
    }
}
