using HICUP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HICUP.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewInventory : ContentPage
	{
		public ViewInventory ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();

            List<Inventory> inventory = App.InventoryDatabase.ViewInventory(Constants.userToken.FamilyId);
            int rowNum = 2;
            foreach (Inventory i in inventory)
            {
                inventoryGrid.Children.Add(new Label { Text = i.Item.ToString(), Style = plainButton }, 0, rowNum);
                inventoryGrid.Children.Add(new Label { Text = (i.ItemQuantity.ToString() + " " + i.ItemMeasurement.ToString()), Style = plainLabel }, 1, rowNum);
                inventoryGrid.Children.Add(new Label { Text = i.ItemPrice.ToString(), Style = plainLabel }, 2, rowNum);
                inventoryGrid.Children.Add(new Label { Text = i.ItemLocation.ToString(), Style = plainLabel }, 3, rowNum);
                inventoryGrid.Children.Add(new Label { Text = i.PurchaseDate.ToString(), Style = plainLabel }, 4, rowNum);
            }
        }

        /*Grid Key
        0 = Item, 1 = Quantity, 2 = Price, 3 = Location, 4 = Date*/
	}
}