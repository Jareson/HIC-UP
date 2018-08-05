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
		public Register ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();
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

                    if (string.IsNullOrEmpty(familyName.Text))
                    {
                        await Navigation.PushAsync(new UserLogin());
                    }
                    else
                    {
                        await Navigation.PushAsync(new UserLogin());
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