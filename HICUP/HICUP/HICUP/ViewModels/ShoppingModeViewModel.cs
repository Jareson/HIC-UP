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
    class ShoppingModeViewModel : BaseInventoryViewModel
    {
        public ICommand AddNewItemCommand { get; private set; }
        public ICommand IncreaseItemStockCommand { get; private set; }
        public ICommand ReduceItemStockCommand { get; private set; }


        public ShoppingModeViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _inventoryRepo = new InventoryRepo();

            AddNewItemCommand = new Command(async () => await AddNewItem());
            IncreaseItemStockCommand = new Command(async () => await IncreaseItemStock());
            ReduceItemStockCommand = new Command(async () => await ReduceItemStock());
        }

        async Task AddNewItem()
        {
            await _navigation.PushAsync(new AddNewItem());
        }

        async Task IncreaseItemStock()
        {
            await _navigation.PushAsync(new IncreaseItemStock());
        }

        async Task ReduceItemStock()
        {
            await _navigation.PushAsync(new ReduceItemStock());
        }
    }
}
