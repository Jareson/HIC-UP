using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HICUP.Data;
using Xamarin.Forms;
using HICUP.Droid.Data;

[assembly: Dependency(typeof(SQLite_Android))]

namespace HICUP.Droid.Data
{
    public class SQLite_Android : IDatabaseConnection
    {
        public SQLite_Android() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var dbFileName = "HICUPDB.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, dbFileName);
            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}