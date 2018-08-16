using HICUP.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace HICUP.Data
{
    public class InventoryDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public InventoryDatabaseController()
        {
            database = DependencyService.Get<IDatabaseConnection>().GetConnection();
            database.CreateTable<Inventory>();

        }

        public IEnumerable<Inventory> GetInventory()
        {
            lock (locker)
            {
                return (from i in database.Table<Inventory>() select i).ToList();
            }
        }

        public int SaveInventory(Inventory inventory)
        {
            lock (locker)
            {
                if (inventory.Id != 0)
                {
                    database.Update(inventory);
                    return inventory.Id;
                }
                else
                {
                    return database.Insert(inventory);
                }
            }
        }

        public int DeleteInventory(int id)
        {
            lock (locker)
            {
                return database.Delete<Inventory>(id);
            }
        }
    }
}
