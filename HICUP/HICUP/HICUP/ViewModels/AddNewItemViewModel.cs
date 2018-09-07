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

            if (validationResults.IsValid)
            {
                bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Add Item", "Do you want to add this item to your inventory?", "OK", "Cancel");
                if (isUserAccept)
                {
                    _inventoryRepo.InsertItem(_item);
                    await _navigation.PushAsync(new ShoppingMode());
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Add Item", validationResults.Errors[0].ErrorMessage, "Ok");
            }
        }
    }
}
