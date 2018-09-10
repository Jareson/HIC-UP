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

            RemoveItemStockCommand = new Command(async () => await RemoveItemStock(SelectedItem, ValueAdjuster));

            FetchInventory();

        }

        void FetchInventory()
        {
            InventoryList = _inventoryRepo.GetInventory();
        }



        async Task RemoveItemStock(Inventory selectedItem, int ValueAdjuster)
        {
            bool checkEmptyItem = selectedItem != null;
            bool notEmptyValueAdjuster = !ValueAdjuster.Equals(0);         

            if (checkEmptyItem && notEmptyValueAdjuster)
            {
                bool aboveZeroCheck = selectedItem.ItemQuantity - ValueAdjuster > 0;
                if (aboveZeroCheck)
                {
                    bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Reduce Item", "Reduce Item Quantity?", "Ok", "Cancel");
                    if (isUserAccept)
                    {
                        _item = _inventoryRepo.GetItem(selectedItem.Id);
                        _item.ItemQuantity -= ValueAdjuster;
                        _inventoryRepo.UpdateItem(_item);
                        bool UserContinue = await Application.Current.MainPage.DisplayAlert("Reduce Item", "Reduce Another Item Quantity?", "Yes", "No");
                        if (!UserContinue)
                        {
                            await _navigation.PopAsync();
                        }
                    }
                }
                else if (aboveZeroCheck == false)
                {
                    await Application.Current.MainPage.DisplayAlert("Reduce Item", "You cannot have less than 0 of an item", "Ok");
                }
            }
            else if (checkEmptyItem == false)
            {
                await Application.Current.MainPage.DisplayAlert("Reduce Item", "Please Select An Item!", "Ok");
            }
            else if (notEmptyValueAdjuster == false)
            {
                await Application.Current.MainPage.DisplayAlert("Reduce Item", "'Reduce By' cannot be 0 or empty!", "Ok");
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
    }
}
