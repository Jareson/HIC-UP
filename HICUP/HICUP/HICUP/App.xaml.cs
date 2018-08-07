using System;
using System.IO;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLitePCL;
using SQLite;
using HICUP.Data;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HICUP
{
    public partial class App : Application
    {
        static TokenDatabaseController tokenDatabase;
        static UserDatabaseController userDatabase;

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new UserLogin());

        }

        protected override void OnStart()
        {
            //Handle when your app starts

        }

        protected override void OnSleep()
        {
            //Handle when your app sleeps

        }

        protected override void OnResume()
        {
            //Handle when your app resumes

        }

        public static UserDatabaseController UserDatabase
        {
            get
            {
                if (userDatabase == null)
                {
                    userDatabase = new UserDatabaseController();
                }
                return userDatabase;
            }
        }
        public static TokenDatabaseController TokenDatabase
        {
            get
            {
                if (tokenDatabase == null)
                {
                    tokenDatabase = new TokenDatabaseController();
                }
                return tokenDatabase;
            }
        }

    }
}
