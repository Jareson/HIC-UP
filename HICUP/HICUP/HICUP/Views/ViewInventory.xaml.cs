using HICUP.Models;
using HICUP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HICUP.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewInventory : ContentPage
	{
		public ViewInventory ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new ViewInventoryViewModel(Navigation);
        }


    }
}