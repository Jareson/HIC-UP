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
		public ModifyItem (Inventory item)
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();

            itemName.Text = item.Item;
            itemMeasurement.Text = item.ItemMeasurement;
            itemQuantity.Text = item.ItemQuantity.ToString();
            price.Text = item.ItemPrice.ToString();
            price.Placeholder = "Price Per Quantity";
            location.Text = item.ItemLocation;
            location.Placeholder = "Location of Lowest Price";
            date.Date = item.PurchaseDate;
            itemID.Text = item.ItemID.ToString();
        }

        async void OnSaveItem()
        {
            Inventory updateItem = new Inventory(itemName.Text, itemMeasurement.Text, Int32.Parse(itemQuantity.Text), Decimal.Parse(price.Text), location.Text, date.Date, Int32.Parse(itemID.Text) );
            //TODO ADD DATABASE ACTION
            await Navigation.PushAsync(new ViewItem(updateItem.Item));
        }
	}
}