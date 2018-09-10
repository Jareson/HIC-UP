using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
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
    class ModifyItemViewModel : BaseInventoryViewModel
    {
        public ICommand UpdateItemCommand { get; private set; }

        public ModifyItemViewModel(INavigation navigation, int selectedItemID)
        {
            _navigation = navigation;
            _inventoryValidator = new InventoryValidator();
            _item = new Inventory();
            _item.Id = selectedItemID;
            _inventoryRepo = new InventoryRepo();

            UpdateItemCommand = new Command(async () => await UpdateItem());

            FetchItem();

        }

        void FetchItem()
        {
            _item = _inventoryRepo.GetItem(_item.Id);
        }


        async Task UpdateItem()
        {
            var validationResults = _inventoryValidator.Validate(_item);

            if (validationResults.IsValid)
            {
                bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Update Item", "Save Item Details?", "OK", "Cancel");
                if (isUserAccept)
                {
                    _item.Item = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_item.Item);
                    _inventoryRepo.UpdateItem(_item);                    
                    for (var counter = 1; counter < 2; counter++)
                    {
                        _navigation.RemovePage(_navigation.NavigationStack[_navigation.NavigationStack.Count - 2]);
                    }
                    await _navigation.PopAsync();
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Modify Item", validationResults.Errors[0].ErrorMessage, "Ok");
            }
        }
    }
}
