using System;
using Xamarin.Forms;

namespace HICUP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        void OnShoppingMode()
        {
            shoppingMode.IsEnabled = false;
            shoppingMode.Text = "Shopping Mode";
        }

        void OnViewInventory()
        {
            inventory.IsEnabled = false;
            inventory.Text = "Inventory";
        }

        void OnMakeGroceryList()
        {
            makeGroceryList.IsEnabled = false;
            makeGroceryList.Text = "Make Grocery List";
        }

        void OnSettings()
        {
            makeGroceryList.IsEnabled = false;
            makeGroceryList.Text = "Settings";
        }
    }
}
