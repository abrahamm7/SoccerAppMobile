using PrismSportApp.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteModel))]
namespace PrismSportApp.Services
{
    public class SqliteModel: ISqliteInterface
    {
        public SQLiteConnection GetConnection()
        {
            var dbase = "FavoriteTeams";
            var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbpath, dbase);
            var connection = new SQLiteConnection(path);
            return connection;

        }

        
    }
}
