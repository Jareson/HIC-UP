using System;
using Xamarin.Forms;

namespace HICUP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
		}

        async void OnShoppingMode(Object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ShoppingMode());
        }

        void OnViewInventory()
        {
            inventoryButton.IsEnabled = false;
        }

        void OnMakeGroceryList()
        {
            makeGroceryListButton.IsEnabled = false;
        }

        void OnSettings()
        {
            makeGroceryListButton.IsEnabled = false;
        }
    }
}
