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
		}

        //Grid Key
        //0 = Item, 1 = Quantity, 2 = Price, 3 = Location, 4 = Date

        void inventoryGrid()
        {

            List<Inventory> inventory = App.InventoryDatabase.ViewInventory(Constants.userToken.familyId);
        }
	}
}