using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HICUP.Models;
using HICUP.Data;
using HICUP.Services;
using HICUP.Validator;
using HICUP.Views;
using Xamarin.Forms;

namespace HICUP.ViewModels
{
    class IncreaseItemStockViewModel: BaseInventoryViewModel
    {

        public ICommand IncreaseItemStockCommand { get; private set; }

        public IncreaseItemStockViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _inventoryValidator = new InventoryValidator();
            _item = new Inventory();
            _inventoryRepo = new InventoryRepo();

            IncreaseItemStockCommand = new Command(async () => await IncreaseItemStock(SelectedItem, ValueAdjuster, NewPrice, NewLocation));

            FetchInventory();

        }

        void FetchInventory()
        {
            InventoryList = _inventoryRepo.GetInventory();
        }

        async Task IncreaseItemStock(Inventory selectedItem, int ValueAdjuster, decimal NewPrice, string NewLocation)
        {
            bool checkEmptyItem = selectedItem != null;
            bool notEmptyValueAdjuster = !ValueAdjuster.Equals(0);           

            if (checkEmptyItem && notEmptyValueAdjuster)
            {
                bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Increase Item", "Increase Item Quantity?", "Ok", "Cancel");
                if (isUserAccept)
                {                    
                    _item = _inventoryRepo.GetItem(selectedItem.Id);
                    decimal NewItemPrice = NewPrice / ValueAdjuster;
                    if (_item.ItemPrice > NewItemPrice && NewPrice != 0)
                    {
                        _item.ItemPrice = NewItemPrice;
                        _item.ItemLocation = NewLocation;
                    }
                    _item.PurchaseDate = DateTime.Today;
                    _item.ItemQuantity += ValueAdjuster;
                    _inventoryRepo.UpdateItem(_item);
                    await _navigation.PopAsync();
                }
            }
            else if (checkEmptyItem == false)
            {
                await Application.Current.MainPage.DisplayAlert("Increase Item", "Please Select An Item!", "Ok");
            }
            else if (notEmptyValueAdjuster == false)
            {
                await Application.Current.MainPage.DisplayAlert("Increase Item", "'Increase By' cannot be 0 or empty!", "Ok");
            }
        }

        Inventory _selectedItem;
        public Inventory SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value != null)
                {
                    _selectedItem = value;
                    NotifyPropertyChanged("SelectedItem");
                }
            }
        }

        int _valueAdjuster;
        public int ValueAdjuster
        {
            get => _valueAdjuster;
            set
            {
                if (!value.Equals(0))
                {
                    _valueAdjuster = value;
                    NotifyPropertyChanged("ValueAdjuster");
                }
            }
        }

        decimal _newPrice;
        public decimal NewPrice
        {
            get => _newPrice;
            set
            {
                if (!value.Equals(0))
                {
                    _newPrice = value;
                    NotifyPropertyChanged("NewPrice");
                }
            }
        }

        string _newLocation;
        public string NewLocation
        {
            get => _newLocation;
            set
            {
                if (value != null)
                {
                    _newLocation = value;
                    NotifyPropertyChanged("NewPrice");
                }
            }
        }
    }
}
