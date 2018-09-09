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
    class ReduceItemStockViewModel: BaseInventoryViewModel
    {

        public ICommand RemoveItemStockCommand { get; private set; }

        public ReduceItemStockViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _inventoryValidator = new InventoryValidator();
            _item = new Inventory();
            _inventoryRepo = new InventoryRepo();

            RemoveItemStockCommand = new Command(async () => await RemoveItemStock(SelectedItem.Id, ValueAdjuster));

            FetchInventory();

        }

        void FetchInventory()
        {
            InventoryList = _inventoryRepo.GetInventory();
        }



        async Task RemoveItemStock(int selectedItemID, int ValueAdjuster)
        {
            _item = _inventoryRepo.GetItem(selectedItemID);
            var validationResults = _inventoryValidator.Validate(_item);

            if (validationResults.IsValid)
            {
                bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Reduce Item", "Reduce Item Quantity?", "Ok", "Cancel");
                if (isUserAccept)
                {
                    if ((_item.ItemQuantity - ValueAdjuster < 0))
                    {
                        await Application.Current.MainPage.DisplayAlert("Reduce Item", "You cannot have less than 0 of an item", "Ok");
                    }
                    else
                    {
                        _inventoryRepo.UpdateItem(_item);
                        await _navigation.PopAsync();
                    }
                }
            }
            else if (validationResults.IsValid == false)
            {
                await Application.Current.MainPage.DisplayAlert("Reduce Item", validationResults.Errors[0].ErrorMessage, "Ok");
            }
            else if (string.IsNullOrEmpty(ValueAdjuster.ToString()) == true)
            {
                await Application.Current.MainPage.DisplayAlert("Reduce Item", "'Reduce By' cannot be empty!", "Ok");
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
                _valueAdjuster = value;
                NotifyPropertyChanged("ValueAdjuster");
            }
        }
    }
}
