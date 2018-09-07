using System;
using System.Collections.Generic;
using System.Text;
using HICUP.Models;

namespace HICUP.Services
{
    public interface IInventoryRepo
    {
        //Get Whole Inventory
        List<Inventory> GetInventory();

        //Get Specific Item
        Inventory GetItem(int itemID);

        //Update Item
        void UpdateItem(Inventory item);

        //Add New Item
        void InsertItem(Inventory item);

        //Delete Entire Inventory
        void DeleteInventory();

        //Delete Specific Item
        void DeleteInventoryItem(int itemID);
    }
}
