using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace PrismSportApp.Services
{
    public interface ISqliteInterface
    {
        SQLiteConnection GetConnection();
    }
}
