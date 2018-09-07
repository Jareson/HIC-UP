using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace HICUP.Models
{
    [Table("Inventory")]
    public class Inventory
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string Item { get; set; }
        public string ItemMeasurement { get; set; }
        public int ItemQuantity { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemLocation { get; set; }
        public DateTime PurchaseDate { get; set; }

        /*public Inventory() { }
        public Inventory(string Item, string ItemMeasurement, int ItemQuantity, decimal ItemPrice, string ItemLocation)
        {
            this.Item = Item.ToUpper();
            this.ItemMeasurement = ItemMeasurement;
            this.ItemQuantity = ItemQuantity;
            this.ItemPrice = ItemPrice / ItemQuantity;
            this.ItemLocation = ItemLocation.ToUpper();
            this.PurchaseDate = DateTime.Now;            
        }

        public Inventory(string Item, string ItemMeasurement, int ItemQuantity, decimal ItemPrice, string ItemLocation, DateTime PurchaseDate)
        {
            this.Item = Item.ToUpper();
            this.ItemMeasurement = ItemMeasurement;
            this.ItemQuantity = ItemQuantity;
            this.ItemPrice = ItemPrice;
            this.ItemLocation = ItemLocation.ToUpper();
            this.PurchaseDate = PurchaseDate;
        }*/

    }
}
