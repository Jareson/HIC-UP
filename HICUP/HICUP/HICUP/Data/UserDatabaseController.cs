using HICUP.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace HICUP.Data
{
    public class UserDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public UserDatabaseController()
        {
            database = DependencyService.Get<IDatabaseConnection>().GetConnection();
            database.CreateTable<User>();

        }

        public IEnumerable<User> GetUser()
        {
            lock (locker)
            {
                return (from i in database.Table<User>() select i).ToList();
            }
        }

        public User CheckUser(string email)
        {
            lock (locker)
            {
                return database.Table<User>().FirstOrDefault(x => x.Email == email);
            }
        }

        public User CheckUser(string email, string password)
        {
            lock (locker)
            {
                return database.Table<User>().FirstOrDefault(x => x.Email == email && x.Password == password);
            }
        }

        public int SaveUser(User user)
        {
            lock (locker)
            {
                if (user.Id != 0)
                {
                    database.Update(user);
                    return user.Id;
                }
                else
                {
                    return database.Insert(user);
                }
            }
        }

        public int DeleteUser(int id)
        {
            lock (locker)
            {
                return database.Delete<User>(id);
            }
        }
    }
}
