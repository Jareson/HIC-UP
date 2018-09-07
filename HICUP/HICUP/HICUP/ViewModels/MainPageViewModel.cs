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
    class MainPageViewModel : BaseInventoryViewModel
    {
        public ICommand ShoppingModeCommand { get; private set; }
        public ICommand ViewInventoryCommand { get; private set; }
        public ICommand DeleteInventoryCommand { get; private set; }


        public MainPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _inventoryRepo = new InventoryRepo();

            ShoppingModeCommand = new Command(async () => await ShoppingMode());
            ViewInventoryCommand = new Command(async () => await ViewInventory());

            DeleteInventoryCommand = new Command(async () => await DeleteInventory());

            FetchInventory();
        }

        void FetchInventory()
        {
            InventoryList = _inventoryRepo.GetInventory();
        }

        async Task ShoppingMode()
        {
            await _navigation.PushAsync(new ShoppingMode());
        }

        async Task ViewInventory()
        {
            await _navigation.PushAsync(new ViewInventory());
        }


        async Task DeleteInventory()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Delete Inventory", "Delete Entire Inventory?", "OK", "Cancel");
            if (isUserAccept)
            {
                bool isUserAcceptConfirm = await Application.Current.MainPage.DisplayAlert("Delete Inventory", "Are you absolutely sure? This cannot be undone", "Yes", "No");
                if (isUserAcceptConfirm)
                {
                    _inventoryRepo.DeleteInventory();
                }
            }
        }

    }
}
