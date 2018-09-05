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
    public partial class Register : ContentPage
    {
        public Register()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        void FieldChange(Object sender, TextChangedEventArgs args)
        {
            List<string> blanks = new List<string> { username.Text, email.Text, password.Text, confirmPassword.Text };

            foreach (string element in blanks)
            {
                if (string.IsNullOrEmpty(element))
                {
                    registerButton.IsEnabled = false;
                    break;
                }
                else
                {
                    registerButton.IsEnabled = true;
                }
            }
        }

        async void OnRegister(Object sender, EventArgs args)
        {
            if (password.Text.Equals(confirmPassword.Text))
            {

                confirmPassword.TextColor = Color.Black;
                User userCheck = App.UserDatabase.CheckUser(email.Text);

                if (userCheck == null)
                {
                    if (string.IsNullOrEmpty(familyName.Text))
                    {
                        User user = new User(username.Text, email.Text, password.Text);
                        App.UserDatabase.SaveUser(user);
                        await DisplayAlert("Success", "New Account Created", "Ok");
                        await Navigation.PushAsync(new UserLogin());
                    }
                    else
                    {
                        Family familyCheck = App.FamilyDatabase.CheckFamily(familyName.Text);
                        if (familyCheck == null)
                        {
                            User user = new User(username.Text, email.Text, password.Text, familyName.Text);
                            App.UserDatabase.SaveUser(user);
                            await DisplayAlert("Success", "New Account Created", "Ok");
                            await Navigation.PushAsync(new UserLogin());
                        }
                        else
                        {
                            familyName.TextColor = Color.Red;
                            await DisplayAlert("Family", "This Family Name is already in use. If you would like to join it, create an account and request access.", "Ok");
                        }
                    }
                }
                else
                {
                    email.TextColor = Color.Red;
                    await DisplayAlert("Email", "This email is already taken!", "Ok");

                }
            }
            else
            {
                confirmPassword.TextColor = Color.Red;
                await DisplayAlert("Password", "Your passwords do not match!", "Ok");
            }
        }
    }
}