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

            IncreaseItemStockCommand = new Command(async () => await IncreaseItemStock(SelectedItem.Id, ValueAdjuster));

            FetchInventory();

        }

        void FetchInventory()
        {
            InventoryList = _inventoryRepo.GetInventory();
        }

        async Task IncreaseItemStock(int selectedItemID, int ValueAdjuster)
        {
            _item = _inventoryRepo.GetItem(selectedItemID);
            var validationResults = _inventoryValidator.Validate(_item);

            if (validationResults.IsValid && !string.IsNullOrEmpty(ValueAdjuster.ToString()))
            {
                bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Increase Item", "Add Item Quantity?", "Ok", "Cancel");
                if (isUserAccept)
                {
                    _item.ItemQuantity += ValueAdjuster;
                    _inventoryRepo.UpdateItem(_item);
                    await _navigation.PopAsync();
                }
            }
            else if (validationResults.IsValid == false)
            {
                await Application.Current.MainPage.DisplayAlert("Increase Item", validationResults.Errors[0].ErrorMessage, "Ok");
            }
            else if (string.IsNullOrEmpty(ValueAdjuster.ToString()) == true)
            {
                await Application.Current.MainPage.DisplayAlert("Increase Item", "'Increase By' cannot be empty!", "Ok");
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
