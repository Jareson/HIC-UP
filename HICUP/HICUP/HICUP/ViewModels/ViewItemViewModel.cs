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
    class ViewItemViewModel : BaseInventoryViewModel
    {
        public ICommand ModifyItemCommand { get; private set; }
        public ICommand DeleteItemCommand { get; private set; }

        public ViewItemViewModel(INavigation navigation, int selectedItemID)
        {
            _navigation = navigation;
            _inventoryValidator = new InventoryValidator();
            _item = new Inventory();
            _item.Id = selectedItemID;
            _inventoryRepo = new InventoryRepo();

            ModifyItemCommand = new Command(async () => await ModifyItem());
            DeleteItemCommand = new Command(async () => await DeleteItem());

            FetchItem();
        }

        void FetchItem()
        {
            _item = _inventoryRepo.GetItem(_item.Id);
        }

        async Task ModifyItem()
        {
            await _navigation.PushAsync(new ModifyItem(_item.Id));
        }

        async Task DeleteItem()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Delete Item", "Delete Item?", "OK", "Cancel");
            if (isUserAccept)
            {
                _inventoryRepo.DeleteInventoryItem(_item.Id);
                await _navigation.PopAsync();
            }
        }
    }
}
