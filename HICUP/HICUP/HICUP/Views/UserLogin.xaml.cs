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

        void FieldChange(Object sender, TextChangedEventArgs args)
        {
            List<string> blanks = new List<string>();
            blanks.Add(email.Text);
            blanks.Add(password.Text);

            foreach (string element in blanks)
            {
                if (string.IsNullOrEmpty(element))
                {
                    signInButton.IsEnabled = false;
                    break;
                }
                else
                {
                    signInButton.IsEnabled = true;
                }
            }
        }

        async void OnSignIn(Object sender, EventArgs args)
        {
            User user = new User(email.Text, password.Text);
            User dbCheck = App.UserDatabase.CheckUser(user.Email, user.Password);
            if (user.Email == dbCheck.Email)
            {
                if (user.Password == dbCheck.Password)
                {
                    Token newToken = new Token(dbCheck, dbCheck.FamilyId);
                    App.TokenDatabase.SaveToken(newToken);
                    await DisplayAlert("Login", "Login Success", "OK");
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Login", "Login Error, Invalid Password", "OK");
                }

            }
            else
            {
                await DisplayAlert("Login", "Login Error, Invalid Email", "OK");
            }
        }
        async void OnRegister(Object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Register());
        }
	}
}