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

        public Inventory CheckItem(string item, int family)
        {
            lock (locker)
            {
                return database.Table<Inventory>().FirstOrDefault(x => x.Item == item && x.FamilyId == family);
            }
        }

        public Inventory CheckItem(int itemID, int family)
        {
            lock (locker)
            {
                return database.Table<Inventory>().FirstOrDefault(x => x.ItemID == itemID && x.FamilyId == family);
            }
        }


        public List<Inventory> ViewInventory(int familyID)
        {
            lock (locker)
            {
                return database.Table<Inventory>().Where(x => x.FamilyId == familyID).ToList();
            }
        }

        public int UpdateItem(Inventory item)
        {
            lock (locker)
            { 
                return database.Update(item);
            }
        }
        public int SaveInventory(Inventory inventory)
        {
            lock (locker)
            { 
                    return database.Insert(inventory);
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
