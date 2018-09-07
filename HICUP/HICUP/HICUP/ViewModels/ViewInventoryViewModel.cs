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
    public class ViewInventoryViewModel : BaseInventoryViewModel
    {
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteInventoryCommand { get; private set; }

        public ViewInventoryViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _inventoryRepo = new InventoryRepo();

            AddCommand = new Command(async () => await ShowAddItem());
            DeleteInventoryCommand = new Command(async () => await DeleteInventory());

            FetchInventory();
        }

        void FetchInventory()
        {
            InventoryList = _inventoryRepo.GetInventory();
        }

        async Task ShowAddItem()
        {
            await _navigation.PushAsync(new AddItem());
        }

        async Task DeleteInventory()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Delete Inventory", "Delete Entire Inventory?", "OK", "Cancel");
            if (isUserAccept)
            {
                _inventoryRepo.DeleteInventory();
                await _navigation.PushAsync(new AddItem());
            }
        }

        async void ViewItem(int selectedItemID)
        {
            await _navigation.PushAsync(new ViewItem(selectedItemID));
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
                    ViewItem(value.Id);
                }
            }
        }
    }
}
