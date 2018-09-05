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
	public partial class ViewItem : ContentPage
	{
		public ViewItem(object item)
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            Inventory selection = App.InventoryDatabase.CheckItem(item.ToString(), Constants.userToken.FamilyId);

            itemName.Text = selection.Item;
            itemMeasurement.Text = selection.ItemMeasurement;
            itemQuantity.Text = selection.ItemQuantity.ToString();
            price.Text = selection.ItemPrice.ToString();
            location.Text = selection.ItemLocation;
            date.Text = selection.PurchaseDate.ToString();
		}

        async void OnModifyItem(Object Sender, EventArgs args)
        {
            await Navigation.PushAsync(new ModifyItem(itemName));
        }
    }
}