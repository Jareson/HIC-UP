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
            if (user.CheckNotEmpty())
            {
                User dbCheck = App.UserDatabase.CheckUser(user.Email, user.Password);
                if (user.Email == dbCheck.Email && user.Password == dbCheck.Password)
                {
                    
                    await DisplayAlert("Login", "Login Success", "OK");
                    await Navigation.PushAsync(new MainPage());

                }
                else
                {
                    await DisplayAlert("Login", "Login Error, Invalid Email or Password", "OK");
                }
            }
            else
            {
                await DisplayAlert("Login", "Login Error, Please Enter Email or Password", "OK");
            }
        }
        async void OnRegister(Object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Register());
        }
	}
}