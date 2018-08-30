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
        [ForeignKey(typeof(Family))]
        public int FamilyId { get; set; }
        public string Item { get; set; }
        public string ItemMeasurement { get; set; }
        public double ItemQuantity { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemLocation { get; set; }
        public DateTime PurchaseDate { get; set; }

        [ManyToOne]
        public Family Family { get; set; }

        public Inventory() { }
        public Inventory(string Item, string ItemMeasurement, int ItemQuantity, decimal ItemPrice, string ItemLocation)
        {
            this.Item = Item;
            this.ItemMeasurement = ItemMeasurement;
            this.ItemQuantity = ItemQuantity;
            this.ItemPrice = ItemPrice / ItemQuantity;
            this.ItemLocation = ItemLocation;
            this.PurchaseDate = DateTime.Now;
        }
    }
}
