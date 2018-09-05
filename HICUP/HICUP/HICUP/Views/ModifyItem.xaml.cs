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
	public partial class ModifyItem : ContentPage
	{
		public ModifyItem (object item)
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();

            Inventory selection = App.InventoryDatabase.CheckItem(item.ToString(), Constants.userToken.FamilyId);

            itemName.Text = selection.Item;
            itemMeasurement.Text = selection.ItemMeasurement;
            itemQuantity.Text = selection.ItemQuantity.ToString();
            price.Text = selection.ItemPrice.ToString();
            price.Placeholder = "Price Per Quantity";
            location.Text = selection.ItemLocation;
            location.Placeholder = "Location of Lowest Price";
            date.Text = selection.PurchaseDate.ToString();
        }

        async void OnSaveItem()
        {
            Inventory updateItem = new Inventory(itemName.Text, itemMeasurement.Text, Int32.Parse(itemQuantity.Text), Decimal.Parse(price.Text), location.Text);
            //TODO ADD DATABASE ACTION
            await Navigation.PushAsync(new ViewItem(updateItem.Item));
        }
	}
}