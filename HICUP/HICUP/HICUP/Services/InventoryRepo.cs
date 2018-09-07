using System;
using System.Collections.Generic;
using System.Text;
using HICUP.Models;
using HICUP.Data;

namespace HICUP.Services
{
    public class InventoryRepo : IInventoryRepo
    {
        InventoryDatabaseController _inventoryDatabaseController;

        public InventoryRepo()
        {
            _inventoryDatabaseController = new InventoryDatabaseController();
        }

        public List<Inventory> GetInventory()
        {
            return _inventoryDatabaseController.GetInventory();
        }

        public Inventory GetItem(int itemID)
        {
            return _inventoryDatabaseController.GetItem(itemID);
        }

        public Inventory GetItemByName(string item)
        {
            return _inventoryDatabaseController.GetItemByName(item);
        }

        public void UpdateItem(Inventory item)
        {
            _inventoryDatabaseController.UpdateItem(item);
        }

        public void InsertItem(Inventory item)
        {
            _inventoryDatabaseController.InsertItem(item);
        }

        public void DeleteInventory()
        {
            _inventoryDatabaseController.DeleteInventory();
        }

        public void DeleteInventoryItem(int itemID)
        {
            _inventoryDatabaseController.DeleteInventoryItem(itemID);
        }

    }
}
