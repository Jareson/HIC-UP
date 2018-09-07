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
    }
}
