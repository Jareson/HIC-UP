using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using HICUP.Views;

namespace HICUP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShoppingMode : ContentPage
	{
        public ShoppingMode ()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();     
        }

        async void OnAddItem()
        {
            await Navigation.PushAsync(new AddItem());
        }

        async void OnRemoveItem()
        {
            await Navigation.PushAsync(new RemoveItem());
        }

        async void OnModifyItem()
        {
            await Navigation.PushAsync(new ModifyItem());
        }
    }
}