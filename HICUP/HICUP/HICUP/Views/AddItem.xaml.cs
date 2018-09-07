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
	public partial class AddItem : ContentPage
	{
		public AddItem()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.BindingContext = new AddItemViewModel(Navigation);
        }
	}
}