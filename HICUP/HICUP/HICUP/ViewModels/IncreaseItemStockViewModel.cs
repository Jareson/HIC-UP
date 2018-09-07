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

        public ICommand RemoveItemCommand { get; private set; }

        public IncreaseItemStockViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _inventoryValidator = new InventoryValidator();
            _item = new Inventory();
            _inventoryRepo = new InventoryRepo();

            RemoveItemCommand = new Command(async () => await RemoveItem());

        }

        async Task RemoveItem()
        {
            var validationResults = _inventoryValidator.Validate(_item);

            if(validationResults.IsValid)
            {
                bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Increase Item", "Add Item Quantity?", "Ok", "Cancel");
                if (isUserAccept)
                {
                    _inventoryRepo.UpdateItem(_item);
                    await _navigation.PopAsync();
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Remove Item", validationResults.Errors[0].ErrorMessage, "Ok");
            }
        }
    }
}
