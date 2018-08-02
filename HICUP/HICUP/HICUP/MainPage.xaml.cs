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
            viewInventory.IsEnabled = false;
            viewInventory.Text = "View Inventory";
        }

        void OnModInventory()
        {
            modifyInventory.IsEnabled = false;
            modifyInventory.Text = "Modify Inventory";
        }

        void OnMakeGroceryList()
        {
            makeGroceryList.IsEnabled = false;
            makeGroceryList.Text = "Make Grocery List";
        }
    }
}
