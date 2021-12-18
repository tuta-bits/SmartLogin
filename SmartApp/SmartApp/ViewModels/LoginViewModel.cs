using SmartApp.Helpers;
using SmartApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartApp.ViewModels
{
    public class LoginViewModel
    {
        private ApiServices _apiServices = new ApiServices();

        public string Username { get; set; }

        public string Password { get; set; }



        /// <summary>Gets the login command.</summary>
        /// <value>The login command.</value>
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accesstoken = await _apiServices.LoginAsync(Username, Password);

                    Settings.AccessToken = accesstoken;

                });
            }
        }


        /// <summary>Initializes a new instance of the <see cref="LoginViewModel" /> class.</summary>
        public LoginViewModel()
        {
            Username = Settings.Username;
            Password = Settings.Password;
        }


        public ICommand LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    Settings.AccessToken = "";
                    Settings.Username = "";
                    Settings.Password = "";
                });
            }
        }
    }
}
