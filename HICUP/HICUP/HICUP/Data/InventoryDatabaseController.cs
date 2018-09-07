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

        //Create Table
        public InventoryDatabaseController()
        {
            database = DependencyService.Get<IDatabaseConnection>().GetConnection();
            database.CreateTable<Inventory>();

        }

        //Get Entire Inventory
        public List<Inventory> GetInventory()
        {
            lock (locker)
            {
                return (from i in database.Table<Inventory>() select i).ToList();
            }
        }

        //Get Specific Item
        public Inventory GetItem(int id)
        {
            lock (locker)
            {
                return database.Table<Inventory>().FirstOrDefault(x => x.Id == id);
            }
        }

        //Get Specific Item By Name
        public Inventory GetItemByName(string item)
        {
            lock (locker)
            {
                return database.Table<Inventory>().FirstOrDefault(x => x.Item == item.ToUpper());
            }
        }

        //Update Item
        public void UpdateItem(Inventory item)
        {
            lock (locker)
            {
                database.Update(item);
            }
        }

        //Add New Item
        public void InsertItem(Inventory inventory)
        {
            lock (locker)
            {
                database.Insert(inventory);
            }
        }

        //Delete Entire Inventory
        public void DeleteInventory()
        {
            lock (locker)
            {
                database.DeleteAll<Inventory>();
            }
        }

        //Delete Specific Item
        public void DeleteInventoryItem(int id)
        {
            lock (locker)
            {
                database.Delete<Inventory>(id);
            }
        }

    }
}
