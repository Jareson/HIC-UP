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
	public partial class ViewModifyItem : ContentPage
	{
		public ViewModifyItem()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
		}
	}
}