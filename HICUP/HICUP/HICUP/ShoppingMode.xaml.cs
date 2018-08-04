using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace HICUP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShoppingMode : ContentPage
	{
        Label label;

        public ShoppingMode()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();     
        }
	}
}