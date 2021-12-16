using SmartApp.Helpers;
using SmartApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();
            //MainPage = new NavigationPage(new RegisterPage());
        }

        private void SetMainPage()
        {
            if (!string.IsNullOrEmpty(Settings.AccessToken))
            {
                MainPage = new NavigationPage(new IdeasPage());
            }
            else if (!string.IsNullOrEmpty(Settings.Username)
                && !string.IsNullOrEmpty(Settings.Password))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new RegisterPage());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
