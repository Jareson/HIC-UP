using HICUP.Models;
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
            Init();
		}

        void Init()
        {
            email.Completed += (s, e) => password.Focus();
            password.Completed += (s, e) => OnSignIn(s, e);
        }

        async void OnSignIn(Object sender, EventArgs args)
        {
            User user = new User(email.Text, password.Text);
            if (user.CheckInformation())
            {
                await DisplayAlert("Login", "Login Success", "OK");
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Login", "Login Not Correct Email or Password", "OK");
            }
        }
        async void OnRegister(Object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Register());
        }
	}
}