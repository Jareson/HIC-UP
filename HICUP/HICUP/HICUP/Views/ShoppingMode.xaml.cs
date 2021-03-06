﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HICUP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HICUP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShoppingMode : ContentPage
	{
        public ShoppingMode ()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.BindingContext = new ShoppingModeViewModel(Navigation);
        }
    }
}