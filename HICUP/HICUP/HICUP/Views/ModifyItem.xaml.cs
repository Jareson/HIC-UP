using HICUP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HICUP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HICUP.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ModifyItem : ContentPage
	{
		public ModifyItem (int ItemID)
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();
            this.BindingContext = new ModifyItemViewModel(Navigation, ItemID);
        }
	}
}