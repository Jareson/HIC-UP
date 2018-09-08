using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using FluentValidation;
using HICUP.Models;
using HICUP.Data;
using HICUP.Services;
using Xamarin.Forms;
using System.ComponentModel;

namespace HICUP.ViewModels
{
    public class BaseInventoryViewModel : INotifyPropertyChanged
    {
        public Inventory _item;

        public INavigation _navigation;
        public IValidator _inventoryValidator;
        public IInventoryRepo _inventoryRepo;

        public string Item
        {
            get => _item.Item;
            set
            {
                _item.Item = value.ToUpper();
                NotifyPropertyChanged("Item");
            }
        }

        public string ItemMeasurement
        {
            get => _item.ItemMeasurement;
            set
            {
                _item.ItemMeasurement = value;
                NotifyPropertyChanged("ItemMeasurement");
            }
        }

        public int ItemQuantity
        {
            get => _item.ItemQuantity;
            set
            {
                _item.ItemQuantity = value;
                NotifyPropertyChanged("ItemQuantity");
            }
        }

        public decimal ItemPrice
        {
            get => _item.ItemPrice;
            set
            {
                _item.ItemPrice = Math.Round(value, 2);
                NotifyPropertyChanged("ItemPrice");
            }
        }

        public string ItemLocation
        {
            get => _item.ItemLocation;
            set
            {
                _item.ItemLocation = value;
                NotifyPropertyChanged("ItemLocation");
            }
        }

        public DateTime PurchaseDate
        {
            get => _item.PurchaseDate;
            set
            {

                    _item.PurchaseDate = value;
                    NotifyPropertyChanged("PurchaseDate");
            }
        }

        List<Inventory> _inventory;
        public List<Inventory> InventoryList
        {
            get => _inventory;
            set
            {
                _inventory = value;
                NotifyPropertyChanged("InventoryList");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
