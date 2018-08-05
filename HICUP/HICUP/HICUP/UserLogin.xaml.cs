using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HICUP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserLogin : ContentPage
	{
		public UserLogin ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
		}

        async void OnSignIn(Object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MainPage());
        }
        async void OnRegister(Object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Register());
        }
	}
}