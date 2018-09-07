using HICUP.Views;
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

        async void OnViewInventory()
        {
            await Navigation.PushAsync(new ViewInventory());
        }

        void OnSettings()
        {
            
        }
    }
}
