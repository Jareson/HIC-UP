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
	public partial class SearchItem : ContentPage
	{
		public SearchItem()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            List<Inventory> inventory = App.InventoryDatabase.ViewInventory(Constants.userToken.FamilyId);
            foreach (Inventory i in inventory)
            {
                itemPicker.Items.Add(i.Item.ToString());
            }
        }

        async void OnDetailsButton(Object Sender, EventArgs args)
        {
            await Navigation.PushAsync(new ViewModifyItem(itemPicker.SelectedItem));
        }
	}
}