using HICUP.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace HICUP.Data
{
    public class FamilyDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public FamilyDatabaseController()
        {
            database = DependencyService.Get<IDatabaseConnection>().GetConnection();
            database.CreateTable<User>();

        }

        public IEnumerable<Family> GetFamily()
        {
            lock (locker)
            {
                return (from i in database.Table<Family>() select i).ToList();
            }
        }

        public Family CheckFamily(string familyName)
        {
            lock (locker)
            {
                return database.Table<Family>().FirstOrDefault(x => x.FamilyName == familyName);
            }
        }

        public int SaveFamily(Family family)
        {
            lock (locker)
            {
                if (family.Id != 0)
                {
                    database.Update(family);
                    return family.Id;
                }
                else
                {
                    return database.Insert(family);
                }
            }
        }

        public int DeleteFamily(int id)
        {
            lock (locker)
            {
                return database.Delete<Family>(id);
            }
        }
    }
}
