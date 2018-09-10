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
    public class AddNewItemViewModel : BaseInventoryViewModel
    {
        public ICommand AddItemCommand { get; private set; }

        public AddNewItemViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _inventoryValidator = new InventoryValidator();
            _item = new Inventory();
            _inventoryRepo = new InventoryRepo();

            AddItemCommand = new Command(async () => await AddItem());
        }

        async Task AddItem()
        {
            var validationResults = _inventoryValidator.Validate(_item);
            var checkDuplicate = _inventoryRepo.GetItemByName(_item.Item) == null;

            if (validationResults.IsValid && checkDuplicate)
            {
                bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Add Item", "Do you want to add this item to your inventory?", "OK", "Cancel");
                if (isUserAccept)
                {
                    _item.PurchaseDate = DateTime.Today;
                    _item.ItemPrice = Math.Round(_item.ItemPrice / _item.ItemQuantity, 2);
                    _inventoryRepo.InsertItem(_item);
                    await _navigation.PopAsync();
                }
            }
            else if (validationResults.IsValid == false)
            {
                await Application.Current.MainPage.DisplayAlert("Add Item", validationResults.Errors[0].ErrorMessage, "Ok");
            }
            else if (checkDuplicate == false)
            {
                await Application.Current.MainPage.DisplayAlert("Add Item", "Cannot have duplicate items", "Ok");
            }
        }
    }
}
