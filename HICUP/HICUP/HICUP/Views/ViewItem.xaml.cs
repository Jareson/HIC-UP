using HICUP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HICUP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HICUP.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewItem : ContentPage
	{
		public ViewItem(int itemID)
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.BindingContext = new ViewItemViewModel(Navigation, itemID);
		}

        /*async void OnModifyItem(Object Sender, EventArgs args)
        {
            await Navigation.PushAsync(new ModifyItem(new Inventory(itemName.Text, itemMeasurement.Text, Int32.Parse(itemQuantity.Text), Decimal.Parse(price.Text), location.Text)));
        }*/
    }
}