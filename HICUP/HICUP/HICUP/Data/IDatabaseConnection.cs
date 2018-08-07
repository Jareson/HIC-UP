using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace HICUP.Data
{
    public interface IDatabaseConnection
    {
        SQLiteConnection GetConnection();
    }
}
