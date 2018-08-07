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
            List<string> blanks = new List<string>();
            blanks.Add(email.Text);
            blanks.Add(confirmEmail.Text);
            blanks.Add(password.Text);
            blanks.Add(confirmPassword.Text);

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
            if (email.Text.Equals(confirmEmail.Text))
            {
                confirmEmail.TextColor = Color.Black;

                if (password.Text.Equals(confirmPassword.Text))
                {

                    confirmPassword.TextColor = Color.Black;
                    User dbCheck = App.UserDatabase.CheckUser(email.Text);

                    if (string.IsNullOrEmpty(familyName.Text))
                    {
                        if (dbCheck == null)
                        {
                            User user = new User(email.Text, password.Text);
                            App.UserDatabase.SaveUser(user);
                            await DisplayAlert("Success", "New Account Created", "Ok");
                            await Navigation.PushAsync(new UserLogin());
                        }
                        else
                        {
                            email.TextColor = Color.Red;
                            confirmEmail.TextColor = Color.Red;
                            await DisplayAlert("Email", "This email is already taken!", "Ok");

                        }
                    }
                    else
                    {
                        if (dbCheck == null)
                        {
                            User user = new User(email.Text, password.Text, familyName.Text);
                            App.UserDatabase.SaveUser(user);
                            await DisplayAlert("Success", "New Account Created", "Ok");
                            await Navigation.PushAsync(new UserLogin());
                        }
                        else
                        {
                            email.TextColor = Color.Red;
                            confirmEmail.TextColor = Color.Red;
                            await DisplayAlert("Email", "This email is already taken!", "Ok");

                        }
                    }
                }
                else
                {
                    confirmPassword.TextColor = Color.Red;
                    await DisplayAlert("Password", "Your passwords do not match!", "Ok");
                }
            }
            else
            {
                confirmEmail.TextColor = Color.Red;
                await DisplayAlert("Email", "Your email does not match!", "Ok");
            }
        }
    }
}