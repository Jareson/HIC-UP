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
            inventoryButton.Text = "Inventory";
        }

        void OnMakeGroceryList()
        {
            makeGroceryListButton.IsEnabled = false;
            makeGroceryListButton.Text = "Make Grocery List";
        }

        void OnSettings()
        {
            makeGroceryListButton.IsEnabled = false;
            makeGroceryListButton.Text = "Settings";
        }
    }
}
